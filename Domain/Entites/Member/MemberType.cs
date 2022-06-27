using Domain.Entites.BaseEntity;

namespace Domain
{
    public class MemberType : Entity<Guid>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<MemberTypeRecord>? MemberTypeRecord { get; set; }
    }
}
