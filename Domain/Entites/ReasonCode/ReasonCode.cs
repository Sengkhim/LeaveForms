using Domain.Authentication;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ReasonCode : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }   
        public ICollection<ReasonCodeRecord>? ReasonCodeRecord { get; set; }
        [ForeignKey(nameof(UserId))] public User? User { get ; set ; }
    }
}
