using Domain.Authentication;
using Domain.Entites.BaseEntity;
using Domain.Enumerable;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class AdvanceLeave : Entity<Guid>
    {
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))] public User? User { get; set; }
        public Guid LeaveTypeId { get; set; }
        public Guid ReasonCodeId { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public double TotalLeave { get; set; }
        public FeedBack? FeedBacks { get; set; } = FeedBack.Pending;
        public ICollection<MemberAdvanceLeave>? MemberAdvanceLeave { get; set; }
        [ForeignKey(nameof(LeaveTypeId))] public LeaveType? LeaveType { get; set; }
        [ForeignKey(nameof(ReasonCodeId))] public ReasonCode? ReasonCode { get; set; }
    }
}
