using Domain.Entites;
using Domain.Entites.BaseEntity;
using Domain.Entites.Company;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class CompanyDepartermentRecord : Entity<Guid>
    {
        public Guid ReasonCodeId { get; set; }
        public Guid CompanyDepartermentId { get; set; }
        public Guid PeriodId { get; set; }
        public Guid RecordStatusTypeId { get; set; }
        public string? Description { get; set; }
        public CompanyDeparterment? CompanyDeparterment { get; set; }
        [ForeignKey(nameof(PeriodId))] public Period? Period { get; set; }
        [ForeignKey(nameof(ReasonCodeId))] public ReasonCode? ReasonCode { get; set; }

        [ForeignKey(nameof(RecordStatusTypeId))]
        public RecordStatusType? RecordStatusType { get; set; }
    }
}
