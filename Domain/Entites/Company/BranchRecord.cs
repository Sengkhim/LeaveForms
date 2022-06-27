using Domain.Entites;
using Domain.Entites.BaseEntity;
using Domain.Entites.Company;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class BranchRecord : Entity<Guid>
    {
        public Guid ReasonCodeId { get; set; }
        public Guid BranchId { get; set; }
        public Guid PeriodId { get; set; }
        public string? Description { get; set; } 
        public Branch? Branch { get; set; }
        [ForeignKey(nameof(PeriodId))] public Period? Period { get; set; }
        [ForeignKey(nameof(ReasonCodeId))] public ReasonCode? ReasonCode { get; set; }
        public Guid RecordStatusTypeId { get; set; }

        [ForeignKey(nameof(RecordStatusTypeId))] 
        public RecordStatusType? RecordStatusType { get; set; }
    }
}
