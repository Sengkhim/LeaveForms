using Application.Conmon.Request.Identity;
using Application.Conmon.Response.Identity;
using Share.Wapper;

namespace Application
{
    public interface IUserService
    {
        Task<IResponse<List<UserResponse>>> GetAllAsync();
        Task<IResponse<UserResponse>> GetAsync(Guid userId);
        Task<IResponse> RegisterAsync(RegisterRequest request, string origin);
        Task<IResponse<UserRolesResponse>> GetRolesAsync(Guid id);
        Task<IResponse> UpdateRolesAsync(UpdateUserRolesRequest request);
        Task<IResponse> ForgotPasswordAsync(string emailId, string origin);
        Task<IResponse> ResetPasswordAsync(ResetPasswordRequest request, string token);
        Task<IResponse> CreateClaimRoleAsync(CreateUserRoleModel update);
        Task<IResponse<UserResponse>> GetPersonal();
        Task<IResponse> CreateUserClaimAsync(UserClaimRequest request);
        Task<IResponse<string>> ConfirmEmailAsync(Guid userId, string code);
    }
}
