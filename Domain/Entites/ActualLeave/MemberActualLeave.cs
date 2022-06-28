using Domain.Authentication;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class MemberActualLeave : Entity<Guid>
    {
        public Guid ActualLeaveId { get; set; }
        [ForeignKey(nameof(ActualLeaveId))] public ActualLeave? ActualLeave { get; set ; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))] public User? User { get; set; }
    }

}
