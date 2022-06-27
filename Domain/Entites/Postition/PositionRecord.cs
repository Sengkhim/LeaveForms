using Domain.Entites;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class PositionRecord : Entity<Guid>
    {
        public Guid ReasonCodeId { get; set; }
        public Guid PositionId { get; set; }
        public Guid PeriodId { get; set; }
        public Guid RecordStatusTypeId { get; set; }
        public string? Description { get; set; }
        [ForeignKey(nameof(PeriodId))] public Period? Period { get; set; }
        public Position? Position { get; set; }
        [ForeignKey(nameof(ReasonCodeId))] public ReasonCode? ReasonCode { get; set; }

        [ForeignKey(nameof(RecordStatusTypeId))]
        public RecordStatusType? RecordStatusType { get; set; }
    }
}
