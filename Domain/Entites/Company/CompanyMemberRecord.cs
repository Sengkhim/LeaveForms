using Domain.Entites;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class CompanyMemberRecord : Entity<Guid>
    {
        public Guid RecordStatusTypeId { get; set; }
        public Guid ReasonCodeId { get; set; }  
        public Guid CompanyMemberId { get; set; }
        public Guid PerIodId { get; set; }
        public string? Description { get; set; }
        public CompanyMember? CompanyMember { get; set; }
        [ForeignKey(nameof(PerIodId))] public Period? Period { get; set; }
        [ForeignKey(nameof(ReasonCodeId))] public ReasonCode? ReasonCode { get; set; }

        [ForeignKey(nameof(RecordStatusTypeId))]
        public RecordStatusType? RecordStatusType { get; set; }

    }
}
