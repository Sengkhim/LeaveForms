using Domain.Authentication;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class MemberActualLeave : Entity<Guid>
    {
        public Guid ActualLeaveId { get; set; }
        [ForeignKey(nameof(ActualLeaveId))] public ActualLeave? ActualLeave { get; set ; }
        public Guid MemberId { get; set; }
        [ForeignKey(nameof(MemberId))] public Member? Member { get; set; }
    }

}
