using Domain.Entites;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class DepartermentRecord : Entity<Guid>
    {
        public Guid ReasoncodeId { get; set; }  
        public Guid DepartermentId { get; set; }
        public Guid PeriodId { get; set; }
        public Guid RecordStatusTypeId { get; set; }
        [StringLength(200)] public string? Description { get; set; }
        [ForeignKey(nameof(PeriodId))] public Period? Period { get; set; }
        public Departerment? Departerment { get; set; }
        [ForeignKey(nameof(ReasoncodeId))] public ReasonCode? ReasonCode { get; set; }

        [ForeignKey(nameof(RecordStatusTypeId))]
        public RecordStatusType? RecordStatusType { get; set; }
    }
}
