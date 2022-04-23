using Application.Conmon.Request.Identity;
using Application.Helper;
using Application.Repositery.Service;
using Domain.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Share.Permission;
using Share.Wapper;

namespace Application.Implementation.Service
{
    public class UserClaimService : IUserClaimService
    {
        private readonly UserManager<User>? _userManager;
        private readonly IStringLocalizer<UserClaimService>? _localizer;

        public UserClaimService(UserManager<User>? userManager, IStringLocalizer<UserClaimService>? localizer)
        {
            _userManager = userManager;
            _localizer = localizer;
        }

        public async Task<IResponse<string>> CreateUserPermissionsAsync(UserClaimPermissions request)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null) return await Response<string>.FailAsync(
                        _localizer["Not have role id here."]);
                var claims = await _userManager.GetClaimsAsync(user);
                var selectedClaims = request.userClaims.Where(a => a.Selected).ToList();
                foreach (var claim in selectedClaims)
                {
                    await _userManager.AddUserClaimPermission(user, claim.Value);
                }
                return await Response<string>.SuccessAsync(_localizer["User Permission Created."]);
            }
            catch (Exception ex)
            {
                return await Response<string>.FailAsync(ex.Message);
            }
        }

        public async Task<IResponse<List<UserClaimRequests>>> GetUserPermissionAsync(string UserId)
        {
            var model = new UserClaimPermissions();
            var allPermissions = new List<UserClaimRequests>();
            allPermissions.GetAllUserPermission(typeof(Permissions.UserPermission), UserId);

            var user = await _userManager.FindByIdAsync(UserId);
            if (user != null)
            {
                model.UserId = user.Id.ToString();
                var claims = await _userManager.GetClaimsAsync(user);
                var allClaimValues = allPermissions.Select(a => a.Value).ToList();
                var roleClaimValues = claims.Select(a => a.Value).ToList();
                var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
                foreach (var permission in allPermissions.Where(permission =>
                    authorizedClaims.Any(a => a == permission.Value))) permission.Selected = true;
            }

            return await Response<List<UserClaimRequests>>.SuccessAsync(allPermissions);
        }

        public async Task<IResponse<string>> UpdateUserPermissionsAsync(UserClaimPermissions request)
        {
            try
            {
                var data = new UserClaimPermissions();
                data = request;
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null) return await Response<string>.FailAsync(_localizer["Not have role id here."]);
                var claims = await _userManager.GetClaimsAsync(user);
                foreach (var item in claims) await _userManager.RemoveClaimAsync(user, item);

                var selectedClaims = request.userClaims.Where(a => a.Selected).ToList();
                
                foreach (var claim in selectedClaims)
                    await _userManager.AddUserClaimPermission(user, claim.Value);

                return await Response<string>.SuccessAsync(_localizer["User Permission Update."]);
            }
            catch (Exception ex)
            {
                return await Response<string>.FailAsync(ex.Message);
            }
        }

        public Task<IResponse<string>> DeleteUserPermissionsAsync(string? Id)
        {
            throw new NotImplementedException();
        }
    }
}
