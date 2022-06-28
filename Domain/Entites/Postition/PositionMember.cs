using Domain.Authentication;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites.Postition
{
    public class PositionMember : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid PositionId { get; set; }    
        [StringLength(200)] public string? Description { get; set; }    
        public double? Total { get; set; }
        [ForeignKey(nameof(PositionId))] public Position? Position { get; set; }
        [ForeignKey(nameof(UserId))] public User? User { get; set; }
    }
}
