using Domain.Entites.BaseEntity;

namespace Domain.Entites.Company
{
    public class Contact : Entity<Guid>
    {
        public Guid CompanyDetailId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Contacts { get; set; }
        public string? Description { get; set; }
        public CompanyDetail? CompanyDetail { get; set; }
        public ICollection<ContactRecord>? ContactRecord { get; set;}

    }
}
