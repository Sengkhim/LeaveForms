using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Authentication
{
    public class UserLogin : IdentityUserLogin<Guid>, IEntity
    {
        [Key] public Guid Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public Guid? CreatedByUser { get ; set ; }
        public Guid? ModifiedByUser { get ; set ; }
    }
}
