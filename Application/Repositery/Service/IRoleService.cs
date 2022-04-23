using Application.Conmon.Request.Identity;
using Application.Conmon.Response.Identity;
using Share.Wapper;

namespace Application.Repositery.Service
{
    public interface IRoleService 
    {
        Task<IResponse<List<RoleResponse>>> GetAllAsync();
        Task<IResponse<RoleResponse>> GetByIdAsync(string id);
        Task<IResponse<string>> SaveAsync(RoleRequest request);
        Task<IResponse<string>> DeleteAsync(string id);
        Task<IResponse<PermissionResponse>> GetAllPermissionsAsync(string roleId);
        Task<IResponse<string>> UpdatePermissionsAsync(PermissionRequest request);
        Task<IResponse<string>> CreatePermissionsAsync(PermissionRequest request);
        Task<IResponse<string>> UpdateRoleAsync(RoleRequest request);
    }
}
