
using Domain.Enumerable;

namespace Application.Feature
{
    public class AdvanceLeaveResponse
    {
        public Guid LeaveTypeId { get; set; }
        public Guid ReasonCodeId { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public double Remaining { get; set; }
        public FeedBack? FeedBacks { get; set; } = FeedBack.Pending;
        //public LeaveType? LeaveType { get; set; }
        //public ReasonCode? ReasonCode { get; set; }
    }
}
