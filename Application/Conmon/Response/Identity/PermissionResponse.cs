namespace Application.Conmon.Response.Identity
{
    public class PermissionResponse
    {
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public ICollection<RoleClaimsResponse>? RoleClaims { get; set; }
    }
}
