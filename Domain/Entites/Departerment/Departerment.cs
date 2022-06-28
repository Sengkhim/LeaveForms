using Domain.Entites.BaseEntity;

namespace Domain
{
    public class Departerment : Entity<Guid>
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public ICollection<DepartermentMember>? DepartermentMember { get; set; }
    }
}
