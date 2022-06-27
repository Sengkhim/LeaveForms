using Domain.Entites.BaseEntity;
namespace Domain
{
    public class LeaveType : Entity<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Leave>? Leave { get; set; }
        public ICollection<LeaveTypeRecord>? LeaveTypeRecord { get; set; }
    }
}
