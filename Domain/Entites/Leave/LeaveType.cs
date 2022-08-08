using Domain.Entites.BaseEntity;
namespace Domain
{
    public class LeaveType : Entity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

    }
}
