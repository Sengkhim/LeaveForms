using Domain.Authentication;
using Domain.Entites;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Member : Entity<Guid>
    {
        public Guid MemberId { get; set; }
        public Guid DepartermentId { get; set; }
        public Guid PositonId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<MemberAdvanceLeave>? MemberAdvanceLeave { get; set; }
        public ICollection<MemberActualLeave>? MemberActualLeave { get; set; }
        public User? User { get ; set ; }
        [ForeignKey(nameof(DepartermentId))] public Department? Departerment { get; set; }
        [ForeignKey(nameof(PositonId))] public Position? Position { get; set; }
    }
}
