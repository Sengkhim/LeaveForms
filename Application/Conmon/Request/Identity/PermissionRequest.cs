namespace Application.Conmon.Request.Identity
{
    public class PermissionRequest
    {
        public string? RoleId { get; set; }
        public ICollection<RoleClaimsRequest>? RoleClaims { get; set; }
    }
    public class UserClaimPermissions
    {
        public string? UserId { get; set; }
        public List<UserClaimRequests>? userClaims { get; set; }
    }
}