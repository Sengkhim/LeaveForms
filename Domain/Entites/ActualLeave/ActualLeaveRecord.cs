using Domain.Entites;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ActualLeaveRecord : Entity<Guid>
    {
        public Guid ActualLeaveId { get; set; }
        public Guid PeriodId { get; set; }
        public Guid ReasonCodeId { get; set; }
        public Guid RecordStatusTypeId { get; set; }
        [StringLength(200)] public string? Description { get; set; }

        [ForeignKey(nameof(ActualLeaveId))]
        public ActualLeave? ActualLeave { get; set; }
        [ForeignKey(nameof(PeriodId))] public Period? Period { get; set; }
        [ForeignKey(nameof(ReasonCodeId))] public ReasonCode? ReasonCode { get; set; }

        [ForeignKey(nameof(RecordStatusTypeId))]
        public RecordStatusType? RecordStatusType { get; set; }
    }

}
