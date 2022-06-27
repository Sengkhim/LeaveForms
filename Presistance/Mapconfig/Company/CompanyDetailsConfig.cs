using Domain.Entites.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class CompanyDetailsConfig : IEntityTypeConfiguration<CompanyDetail>
    {
        public void Configure(EntityTypeBuilder<CompanyDetail> builder)
        {
            builder.ToTable("CompanyDetails", "Company").HasKey(f => f.Id);
            builder.HasOne(e => e.Company).WithMany(r => r.CompanyDetails).HasForeignKey(f => f.CompanyId);
            builder.HasMany(e => e.Regions).WithOne(r => r.CompanyDetail).HasForeignKey(f => f.CompanyDetailId);
            builder.HasMany(e => e.Contacts).WithOne(r => r.CompanyDetail).HasForeignKey(f => f.CompanyDetailId);
            builder.HasMany(e => e.CompanyMembers).WithOne(r => r.CompanyDetail).HasForeignKey(f => f.CompanyDetailId);
            builder.HasMany(e => e.CompanyDeparterments).WithOne(r => r.CompanyDetail).HasForeignKey(f => f.CompanyDetailId);
            builder.HasMany(e => e.CompanyPositions).WithOne(r => r.CompanyDetail).HasForeignKey(f => f.CompanyDetailId);
            builder.HasMany(e => e.Branches).WithOne(r => r.CompanyDetail).HasForeignKey(f => f.CompanyDetailId);       
        }
    }
}
