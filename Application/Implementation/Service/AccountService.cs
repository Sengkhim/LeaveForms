using Application.Conmon.Request.Identity;
using Application.Repositery.Service;
using Domain.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.FeatureManagement;
using Share.Wapper;


namespace Application.Implementation.Service
{
    public class AccountService : IAccountService
    {
    //    private readonly IMailService _emailService;
    //    private readonly IFeatureManager _featureManager;
    //    private readonly RoleManager<Role> _roleManager;
    //    private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountService(UserManager<User> userManager)
            //RoleManager<Role> roleManager,
            //SignInManager<User> signInManager,
            //IFeatureManager featureManager,
            //IMailService emailService)
        {
            _userManager = userManager;
            //_roleManager = roleManager;
            //_signInManager = signInManager;
            //_featureManager = featureManager;
            //_emailService = emailService;
        }

        public async Task<IResponse> ChangePasswordAsync(ChangePasswordRequest model, Guid userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user == null) return await Response.FailAsync("User Not Found.");

                var identityResult = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
                var errors = identityResult.Errors.Select(e => e.Description).ToList();
                return identityResult.Succeeded ? 
                      await Response.SuccessAsync("Password change succussfully") 
                    : await Response.FailAsync(errors);
            }
            catch (Exception ex)
            {
                return await Response.FailAsync($"{ex.Message}");
            }
          
        }

    }
}
