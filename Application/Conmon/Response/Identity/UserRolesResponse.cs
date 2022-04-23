using Application.Conmon.Request.Identity;

namespace Application.Conmon.Response.Identity
{
    public class UserRolesResponse
    {
        public List<UserRoleModel> UserRoles { get; set; } = new();
    }
}
