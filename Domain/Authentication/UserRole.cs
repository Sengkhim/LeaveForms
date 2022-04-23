using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Domain.Authentication
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public Guid Id { get; set; }
        //public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        //public DateTimeOffset? ModifiedDate { get; set; }
        //public Guid? CreatedByUser { get; set; }
        //public Guid? ModifiedByUser { get; set; }

        public UserRole()
        {
            Id = Guid.NewGuid();
        }
    }
}
