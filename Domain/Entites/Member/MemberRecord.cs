using Domain.Entites;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class MemberRecord : Entity<Guid>
    {
        public Guid ReasonCodeId { get; set; }
        public Guid MemberId { get; set; }
        public Guid PeriodId { get; set; }
        public Guid RecordStatusTypeId { get; set; }
        public string? Description { get; set; }
        public Member? Member { get; set; }
        [ForeignKey(nameof(PeriodId))] public Period? period { get; set; }
        [ForeignKey(nameof(ReasonCodeId))] public ReasonCode? ReasonCode { get; set; }

        [ForeignKey(nameof(RecordStatusTypeId))] 
        public RecordStatusType? RecordStatusType { get; set; }
    }
}
