using Application.Conmon.Request.Identity;
using Application.Conmon.Response.Identity;
using Application.Repositery.Service;
using AutoMapper;
using Domain.Authentication;
using Domain.Enumerable;
using Domain.Settings;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Share.Wapper;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Application
{

    public class UserService : IUserService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStringLocalizer<UserService> _localizer;
        private readonly IMailService _mailService;

        public UserService(RoleManager<Role> roleManager, UserManager<User> userManager,
        IMapper mapper, IHttpContextAccessor httpContextAccessor, IStringLocalizer<UserService> localizer,
        IMailService mailService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _localizer = localizer;
            _mailService = mailService;
        }

        public async Task<IResponse> ForgotPasswordAsync(string emailId, string origin)
        {
            var user = await _userManager.FindByEmailAsync(emailId);
            if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
                // Don't reveal that the user does not exist or is not confirmed
                return await Response.FailAsync("An Error has occur!");

            var code =  _userManager.GeneratePasswordResetTokenAsync(user).Result;
   
            //var resetLink = Url.ReferenceEquals("ResetPassword", "Account", new { token = code }, protocol: HttpContext.Request.Scheme);
            //var message = "<a href=\"" + resetLink + "\">Click here to reset your password</a>";

            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "api/User/reset-password";
            var uri = new Uri(string.Concat($"{origin}/", route));
            var passwordResetURL = QueryHelpers.AddQueryString(uri.ToString(), "Token", code);
            var request = new MailRequest
            {
                Body =
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(passwordResetURL)}'>clicking here</a>.",
                Subject = "Reset Password",
                To = emailId
            };
            BackgroundJob.Enqueue(() => _mailService.SendAsync(request));
            return await Response.SuccessAsync("Password Reset Mail has been sent to your authorized Email.");
        }

        public async Task<IResponse<List<UserResponse>>> GetAllAsync()
        {
            var users = await _userManager.Users.Where(e => e.Status == true).ToListAsync();
            var result = _mapper.Map<List<UserResponse>>(users);
            return await Response<List<UserResponse>>.SuccessAsync(result, "Get all user!");
        }
        public async Task<IResponse<UserResponse>> GetAsync(Guid userId)
        {
            var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            var result = _mapper.Map<UserResponse>(user);
            return await Response<UserResponse>.SuccessAsync(result);
        }
        public async Task<IResponse<UserRolesResponse>> GetRolesAsync(Guid id)
        {
            var viewModel = new List<UserRoleModel>();
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = await _roleManager.Roles.ToListAsync();
            foreach (var role in roles)
            {
                var userRolesViewModel = new UserRoleModel
                {
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    userRolesViewModel.Selected = true;
                else
                    userRolesViewModel.Selected = false;
                viewModel.Add(userRolesViewModel);
            }

            var result = new UserRolesResponse { UserRoles = viewModel };
            return await Response<UserRolesResponse>.SuccessAsync(result);
        }
        public async Task<IResponse> RegisterAsync(RegisterRequest request, string origin)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
                return await Response.FailAsync($"UserName '{request.UserName}' is already taken.");
            try
            {

                var user = new User
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    PhoneNumber = request.PhoneNumber,
                    Status = request.ActivateUser,
                    EmailConfirmed = request.AutoConfirmEmail,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    CreatedDate = DateTimeOffset.Now,
                    PhoneNumberConfirmed = true                
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());
                    if (!request.AutoConfirmEmail)
                    {
                        var verificationUri = await SendVerificationEmail(user, origin);
                        //TODO: Attach Email Service here and configure it via appsettings
                        BackgroundJob.Enqueue(() => _mailService.SendAsync(new MailRequest
                        {
                            From = "khimup.ads@gmail.com",
                            To = user.Email,
                            Body = $"Please confirm your account by <a href='{verificationUri}'>clicking here</a>.",
                            Subject = "Confirm Registration"
                        }));
                        return await Response<Guid>.SuccessAsync(user.Id, "User Registered Mailbox");
                    }

                    return await Response<Guid>.SuccessAsync(user.Id, "User Registered");
                }

                if (!result.Succeeded)
                    return await Response.FailAsync(result.Errors.Select(a => a.Description).ToList());

                if (request.AutoConfirmEmail != true)
                    return await Response.FailAsync(result.Errors.Select(a => a.Description).ToList());

                //await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());

                return await Response<Guid>.SuccessAsync(user.Id, "User Registered");
            }
            catch (Exception ex)
            {
                return await Response.FailAsync($"Message error > {ex.Message}");
            }

        }
        public async Task<IResponse> ResetPasswordAsync(ResetPasswordRequest request, string? token)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                // Don't reveal that the user does not exist
                return await Response.FailAsync("An Error has occur!");

            var result = await _userManager.ResetPasswordAsync(user, token = request.Token!.ToString(), request.Password);

             if (result.Succeeded)
                return await Response.SuccessAsync("Password Reset Successful!");
            return await Response.FailAsync(result.Errors.Select(d => d.Description).ToList());
        }
        public async Task<IResponse> CreateClaimRoleAsync(CreateUserRoleModel update)
        {
            try
            {
                var UserStore = new List<User>();
                var User = await _userManager.FindByIdAsync(update.UserId);
                if (User == null) return await Response.FailAsync($" '{User.UserName}' is not have.");
                var Role = await _roleManager.FindByIdAsync(update.RoleId);
                if (User == null) return await Response.FailAsync($" '{Role.Name}' is not have.");
                UserStore.Add(User);
                await _userManager.DeleteAsync(User);
                foreach (var item in UserStore)
                {
                    await _userManager.CreateAsync(item);
                    await _userManager.AddToRoleAsync(item, Role.Name);
                }

                return await Response<Guid>.SuccessAsync(User.Id, $"{User.UserName} get Claimed new role > {Role.Name}");

            }
            catch (Exception ex)
            {
                return await Response.FailAsync($"Message error > {ex.Message}");
            }
        }
        public Task<IResponse> UpdateRolesAsync(UpdateUserRolesRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<IResponse<UserResponse>> GetPersonal()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var entity = await _userManager.Users.Where(e => e.Id == new Guid(userId)).FirstOrDefaultAsync();
            var result = _mapper.Map<UserResponse>(entity);
            return await Response<UserResponse>.SuccessAsync(result, "Get personal data !");
        }
        public async Task<IResponse> CreateUserClaimAsync(UserClaimRequest request)
        {
            try
            {
                var user = _userManager.Users.Where(e => e.Id == new Guid(request.UserId)).FirstOrDefault();
                if (user == null) return await Response.FailAsync("Id is null");

                var claim = new Claim(request.type, request.value);
                var result = await _userManager.AddClaimAsync(user, claim);

                if (!result.Succeeded)
                    return await Response<string>.FailAsync(result.Errors.Select(e => _localizer[e.Description].Value).ToList());
           
                return await Response<string>.SuccessAsync(_localizer[$"{user.UserName} get permission > {request.value}"]);
            }
            catch (Exception ex)
            {
                return await Response<string>.FailAsync(ex.Message);
            }
        }
        private async Task<string> SendVerificationEmail(User user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "api/User/confirm-email";
            var uri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(uri.ToString(), "userId", user.Id.ToString());
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
            return verificationUri;
        }
        public async Task<IResponse<string>> ConfirmEmailAsync(Guid userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return await Response<string>.SuccessAsync(user.Id.ToString(),
                    $"Account Confirmed for {user.Email}. You can now use the /api/identity/token endpoint to generate JWT.");

            throw new ApiException($"An error occur while confirming {user.Email}.");
        }
    }
}
