using Domain.Entites;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ReasonCodeRecord : Entity<Guid>
    {
        public Guid ReasonCodeId { get; set; }
        public Guid PeriodId { get; set; }
        public Guid RecordStatusTypeId { get; set; }
        public string? Description { get; set; }
        public ReasonCode? ReasonCode { get; set; }

        [ForeignKey(nameof(RecordStatusTypeId))]
        public RecordStatusType? RecordStatusType { get; set; }
        [ForeignKey(nameof(PeriodId))] public Period? Period { get; set; } 
    }
}
