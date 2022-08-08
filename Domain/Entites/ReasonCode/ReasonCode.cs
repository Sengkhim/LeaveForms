using Domain.Authentication;
using Domain.Entites.BaseEntity;

namespace Domain
{
    public class ReasonCode : Entity<Guid>
    {
        public string? Code { get; set; }
        public string? Description { get; set; }   
    }
}
