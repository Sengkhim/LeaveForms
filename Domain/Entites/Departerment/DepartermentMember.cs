using Domain.Authentication;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class DepartermentMember : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid DepartermentId { get; set; }
        public double? Total { get; set; }
        public Departerment? Departerment { get; set; }
        [ForeignKey(nameof(UserId))] public User? User { get; set; }
    }
}
