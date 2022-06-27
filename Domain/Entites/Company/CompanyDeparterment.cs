using Domain.Entites.BaseEntity;

namespace Domain.Entites.Company
{
    public class CompanyDeparterment : Entity<Guid>
    {
        public Guid CompanyDetailId { get; set; }
        public Guid DepartermentId { get; set; }
        public string? Description { get; set; }
        public double? Total { get; set; }
        public CompanyDetail? CompanyDetail { get; set; }
        public ICollection<CompanyDepartermentRecord>? CompanyDepartermentRecords { get; set; }
    }
}
