using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Domain.Authentication
{
    public class RoleClaim : IdentityRoleClaim<Guid>//, IEntity
    {
        //public Guid? CreatedByUser { get; set; }
        //public Guid? ModifiedByUser { get; set; }
        //public DateTimeOffset CreatedDate { get; set; }
        //public DateTimeOffset? ModifiedDate { get; set; } = DateTimeOffset.Now;
        //public RoleClaim()
        //{
        //    CreatedDate = DateTimeOffset.Now;   
        //}
        //public RoleClaim(DateTimeOffset? ModifiedDate)
        //{
        //    this.ModifiedDate = ModifiedDate;
        //}
    }
}
