using Domain.Entites.Chat;
using Microsoft.AspNetCore.Identity;

namespace Domain.Authentication
{
    public class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName  { get { return FirstName + LastName; } }
        public string? Avatar { get; set; }
        public string? UserProfile { get; set; }
        public bool Status { get; set; } //= EntityStatus.Active;
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ModifiedDate { get; set; }
        public Member? Member { get; set; }
        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
