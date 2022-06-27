using Domain.Entites;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class RegionRecord : Entity<Guid>
    {
        public Guid RecordStatusTypeId { get; set; }
        public Guid ReasonCodeId { get; set; }
        public Guid RegionId { get; set; }  
        public Guid PeriodId { get; set; }
        public string? Description { get; set; }
        public Region? Region { get; set; }
        [ForeignKey(nameof(ReasonCodeId))] public ReasonCode? ReasonCode { get; set; }
        [ForeignKey(nameof(PeriodId))] public Period? Period { get; set; }

        [ForeignKey(nameof(RecordStatusTypeId))]
        public RecordStatusType? RecordStatusType { get; set; }
    }
}
