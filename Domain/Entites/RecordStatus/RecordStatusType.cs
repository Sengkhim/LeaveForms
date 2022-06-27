using Domain.Entites.BaseEntity;

namespace Domain
{
    public class RecordStatusType : Entity<Guid>
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
        public ICollection<RecordStatusTypeMember>? RecordStatusTypeMember { get; set; }
    }
}
