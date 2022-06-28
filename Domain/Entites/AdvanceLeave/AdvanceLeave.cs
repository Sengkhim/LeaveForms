using Domain.Entites;
using Domain.Entites.BaseEntity;
using Domain.Enumerable;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class AdvanceLeave : Entity<Guid>
    {
        //public Guid LeaveTypeId { get; set; }
        //public Guid ReasonCodeId { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public double Remaining { get; set; }
        public FeedBack? FeedBacks { get; set; } = FeedBack.Pending;
        public List<MemberAdvanceLeave>? MemberAdvanceLeave { get; set; }
        //[ForeignKey(nameof(LeaveTypeId))] public LeaveType? LeaveType { get; set; }
        //[ForeignKey(nameof(ReasonCodeId))] public ReasonCode? ReasonCode { get; set; }
        //public ICollection<AdvanceLeaveRecord>? AdvanceLeaveRecords { get; set; }
    }
}
