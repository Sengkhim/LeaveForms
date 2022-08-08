
namespace Application.Feature
{
    public class MemberResponse
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Departerment { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public ICollection<MemberAdvanceLeaveResponse>? MemberAdvanceLeaveResponse { get; set; }
        public ICollection<MemberActaulLeaveResponse>? MemberActaulLeaveResponse { get; set; }
    }
}
