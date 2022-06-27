
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class MemberAdvanceLeaveRequest : Entity<Guid>
    {
        public Guid MemberId { get; set; }
        public Guid AdvanceLeaveId { get; set; }
        [ForeignKey(nameof(MemberId))] public Member Member { get; set; }
        [ForeignKey(nameof(AdvanceLeaveId))] public AdvanceLeave AdvanceLeave { get; set; }
        public string? Description { get; set; }
    }
}
