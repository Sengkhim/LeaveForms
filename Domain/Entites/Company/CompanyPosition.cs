using Domain.Entites.BaseEntity;

namespace Domain.Entites.Company
{
    public class CompanyPosition : Entity<Guid>
    {
        public Guid CompanyDetailId { get; set; }
        public Guid PositionId { get; set; }
        public string? Description { get; set; }
        public double? Total { get; set; }
        public CompanyDetail? CompanyDetail { get; set; }   
        public ICollection<CompanyPositionRecord>? CompanyPositionRecords { get; set; }
    }
}
