using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Domain.Authentication
{
    public class UserClaim : IdentityUserClaim<Guid>//, IEntity
    {
        //public Guid? CreatedByUser { get; set; }
        //public Guid? ModifiedByUser { get; set; }
        //public DateTimeOffset CreatedDate { get; set; }
        //public DateTimeOffset? ModifiedDate { get; set; }
    }
}
