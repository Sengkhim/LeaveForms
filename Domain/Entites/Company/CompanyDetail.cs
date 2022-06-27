using Domain.Entites.BaseEntity;

namespace Domain.Entites.Company
{
    public class CompanyDetail : Entity<Guid>   
    {    
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }   
        public ICollection<Region>? Regions { get; set; }   
        public ICollection<Contact>? Contacts { get; set; }
        public ICollection<CompanyMember>? CompanyMembers { get; set; }
        public ICollection<CompanyDeparterment>? CompanyDeparterments { get; set; }
        public ICollection<CompanyPosition>? CompanyPositions { get; set; }
        public ICollection<Branch>? Branches { get; set; }
    }
}
