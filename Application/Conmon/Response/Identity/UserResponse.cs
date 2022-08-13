using Domain.Enumerable;

namespace Application.Conmon.Response.Identity
{
    public class UserResponse
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? CurrentRoom { get; set; }
        public string? Device { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool Status { get; set; }// = EntityStatus.Active;
        public bool EmailConfirmed { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }
    }
}
