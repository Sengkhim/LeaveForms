using Domain.Enumerable;

namespace Application.Feature
{
    public class MemberActaulLeaveResponse : IEntityResponse
    {
        public Guid Id { get; set; }
        public string? ReasonCode { get; set; }
        public string? ReasonCodeDescription { get; set; }
        public double Remaining { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public FeedBack? FeedBacks { get; set; } = FeedBack.Pending;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Departerment { get; set; }
        public string? Position { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
    }
}
