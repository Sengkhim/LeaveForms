using Application.Conmon.Request.Identity;
using Share.Wapper;

namespace Application.Repositery.Service
{
    public interface IUserClaimService
    {
        Task<IResponse<string>> CreateUserPermissionsAsync(UserClaimPermissions request);
        Task<IResponse<string>> UpdateUserPermissionsAsync(UserClaimPermissions request);
        Task<IResponse<string>> DeleteUserPermissionsAsync(string? Id);
        Task<IResponse<List<UserClaimRequests>>> GetUserPermissionAsync(string UserId);
    }
}
