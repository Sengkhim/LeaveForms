namespace Application.Conmon.Response.Identity
{
    public class RoleClaimsResponse
    {
        public string? Type { get; set; }
        public string? Value { get; set; }
        public bool Selected { get; set; }
    }
    public class UserPermissionResponse
    {
        public string? Type { get; set; }
        public string? Value { get; set; }
        public bool Selected { get; set; }
    }
}
