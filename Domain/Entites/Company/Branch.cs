using Domain.Authentication;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites.Company
{
    public class Branch : Entity<Guid>
    {
        public Guid CompanyDetailId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Total { get; set; }
        public CompanyDetail? CompanyDetail { get; set; }
        public ICollection<BranchRecord>? BranchRecord { get; set; }
    }
}
