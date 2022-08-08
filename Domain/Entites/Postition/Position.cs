using Domain.Entites.BaseEntity;
namespace Domain
{
    public class Position : Entity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
