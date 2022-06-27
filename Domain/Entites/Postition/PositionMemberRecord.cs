using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites.Postition
{
    public class PositionMemberRecord : Entity<Guid>
    {
        public Guid PeriodId { get; set; }
        public Guid PositionMemberId { get; set; }
        public Guid ReasconCodeId { get; set; }
        public Guid RecordStatusTypeId { get; set; }
        [StringLength(200)] public string? Description { get; set; }

        [ForeignKey(nameof(PositionMemberId))]
        public PositionMember? PositionMember { get; set; }
        [ForeignKey(nameof(PeriodId))] public Period? Period { get; set; }

        [ForeignKey(nameof(ReasconCodeId))] 
        public ReasonCode? ReasonCode { get; set; }

        [ForeignKey(nameof(RecordStatusTypeId))]
        public RecordStatusType? RecordStatusType { get; set; }
    }
}
