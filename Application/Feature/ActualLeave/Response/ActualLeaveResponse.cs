
using Domain.Enumerable;

namespace Application.Feature
{
    public class ActualLeaveResponse : IEntityResponse
    {
        public Guid Id { get; set; }
        public Guid LeaveTypeId { get; set; }
        public Guid ReasonCodeId { get; set; }
        public string? Description { get; set; }
        public double Remaining { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public FeedBack? FeedBacks { get; set; } = FeedBack.Pending;
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public ICollection<MemberActaulLeaveResponse>? MemberActaulLeaveResponse { get; set; }
    }
}
