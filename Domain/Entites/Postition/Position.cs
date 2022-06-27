using Domain.Entites.BaseEntity;
using Domain.Entites.Postition;

namespace Domain
{
    public class Position : Entity<Guid>
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public Member? Member { get; set; }
        public ICollection<PositionRecord>? PositionRecord { get; set; }
        public ICollection<PositionMember>? PositionMember { get; set; }
    }
}
