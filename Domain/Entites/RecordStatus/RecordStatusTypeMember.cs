using Domain.Authentication;
using Domain.Entites;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class RecordStatusTypeMember : Entity<Guid>
    {
        public string? Description { get; set; }
        public Guid? RecordStatusTypeId { get; set; }
        public Guid PeriodId { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))] public User? User { get; set; }
        [ForeignKey(nameof(PeriodId))] public Period? Period { get; set; }

        [ForeignKey(nameof(RecordStatusTypeId))] 
        public RecordStatusType? RecordStatusType { get; set; }
    }
}
