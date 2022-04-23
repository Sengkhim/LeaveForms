namespace Application.Conmon.Request.Identity
{
    public class UpdateUserRolesRequest
    {
        public Guid UserId { get; set; }
        public IList<UserRoleModel>? UserRoles { get; set; }
    }

    public class CreateUserRoleModel
    {
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
    }
}