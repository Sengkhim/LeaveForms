namespace Application.Conmon.Request.Identity
{
    public class RoleClaimsRequest
    {
        public string? Type { get; set; }
        public string? Value { get; set; }
        public bool Selected { get; set; }
    }

    public class UserClaimRequests
    {
        public string? Type { get; set; }
        public string? Value { get; set; }
        public bool Selected { get; set; }
    }
}