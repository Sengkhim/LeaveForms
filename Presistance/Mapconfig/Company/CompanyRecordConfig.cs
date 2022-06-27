using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class CompanyRecordConfig : IEntityTypeConfiguration<CompanyRecord>
    {
        public void Configure(EntityTypeBuilder<CompanyRecord> builder)
        {
            builder.ToTable("CompanyRecords", "Company").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
        }
    }
}
