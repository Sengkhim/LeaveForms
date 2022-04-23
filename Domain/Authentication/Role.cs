using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Domain.Authentication
{
    public sealed class Role : IdentityRole<Guid>, IEntity
    {
        public Role()
        {
        }

        public Role(string role)
        {
            Name = role;
        }

        public Role(string role, string description) : this()
        {
            Name = role;
            Description = description;
            CreatedByUser = DefaultEntity.User;
            CreatedDate = DateTimeOffset.UtcNow;
            NormalizedName = role.ToUpper();
        }

        public string Description { get; set; }
        public Guid? CreatedByUser { get ; set ; }
        public Guid? ModifiedByUser { get; set; }
        public DateTimeOffset CreatedDate { get ; set ; }
        public DateTimeOffset? ModifiedDate { get ; set ; }
    }
}
