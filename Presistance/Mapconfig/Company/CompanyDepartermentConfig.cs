using Domain.Entites.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class CompanyDepartermentConfig : IEntityTypeConfiguration<CompanyDeparterment>
    {
        public void Configure(EntityTypeBuilder<CompanyDeparterment> builder)
        {
            builder.ToTable("CompanyDeparterments", "Company").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.HasOne(e => e.CompanyDetail).WithMany(r => r.CompanyDeparterments).HasForeignKey(f => f.CompanyDetailId);
        }
    }
}
