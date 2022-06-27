using Domain.Entites.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class CompanyPositionConfig : IEntityTypeConfiguration<CompanyPosition>
    {
        public void Configure(EntityTypeBuilder<CompanyPosition> builder)
        {
            builder.ToTable("CompanyPositions", "Company").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);

            builder.HasMany(e => e.CompanyPositionRecords).WithOne(r => r.CompanyPosition)
                                                          .HasForeignKey(f => f.CompanyPositionId);

        }
    }
}
