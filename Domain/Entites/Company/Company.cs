using Domain.Entites.BaseEntity;
namespace Domain.Entites.Company
{
    public class Company : Entity<Guid>
    {
        public string? Logo { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CommpanyType { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public ICollection<CompanyDetail>? CompanyDetails { get; set; }
        public ICollection<CompanyRecord>? CompanyRecords { get; set; }

    }
}
