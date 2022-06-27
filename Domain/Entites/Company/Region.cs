using Domain.Entites.BaseEntity;
using Domain.Entites.Company;
namespace Domain
{
    public class Region : Entity<Guid>
    {
        public Guid CompanyDetailId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CompanyDetail? CompanyDetail { get; set; }
        public ICollection<RegionRecord>? ReasonCodeRecord { get; set; }
    }
}
