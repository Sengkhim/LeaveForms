using Domain.Entites;
using Domain.Enumerable;
using Microsoft.AspNetCore.Identity;

namespace Domain.Authentication
{
    public class User : IdentityUser<Guid>//, IEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Status { get; set; } //= EntityStatus.Active;
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ModifiedDate { get; set; }
        //public Guid? CreatedByUser { get; set; }
        //public Guid? ModifiedByUser { get; set; }
    }
}
