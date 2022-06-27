using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class CompanyDepartermentRecordConfig : IEntityTypeConfiguration<CompanyDepartermentRecord>
    {
        public void Configure(EntityTypeBuilder<CompanyDepartermentRecord> builder)
        {
            builder.ToTable("CompanyDepartermentRecords", "Company").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.HasOne(e => e.CompanyDeparterment).WithMany(f => f.CompanyDepartermentRecords)
                                                      .HasForeignKey(f => f.CompanyDepartermentId);
        }
    }
}
