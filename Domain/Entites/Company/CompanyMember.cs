using Domain.Authentication;
using Domain.Entites.BaseEntity;
using Domain.Entites.Company;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class CompanyMember : Entity<Guid>
    {
        public Guid CompanyDetailId { get; set; }
        public Guid UserId { get; set; }
        public string? Description { get; set; }
        public double? Total { get; set; }
        public CompanyDetail? CompanyDetail { get; set; }
        [ForeignKey(nameof(UserId))] public User? User { get; set; }
        public ICollection<CompanyMemberRecord>? CompanyMemberRecord { get; set; }

    }
}
