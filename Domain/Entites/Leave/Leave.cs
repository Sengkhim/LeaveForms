using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Leave : Entity<Guid>
    {
        public Guid LeaveTypeId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public LeaveType? LeaveType { get; set; }
    }

}
