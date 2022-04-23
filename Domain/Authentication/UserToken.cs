using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Domain.Authentication
{
    public class UserToken : IdentityUserToken<Guid>, IEntity
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public Guid? CreatedByUser { get; set; }
        public Guid? ModifiedByUser { get; set; }
    }
}
