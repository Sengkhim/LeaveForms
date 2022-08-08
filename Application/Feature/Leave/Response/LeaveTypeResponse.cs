

namespace Application.Feature
{
    public class LeaveTypeResponse : IEntityResponse
    {
        public Guid Id { get ; set ; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset CreatedDate { get ; set ; }
        public DateTimeOffset? ModifiedDate { get ; set ; }
        public Guid CreatedUserId { get ; set ; }
        public Guid? ModifiedUserId { get ; set ; }
    }
}
