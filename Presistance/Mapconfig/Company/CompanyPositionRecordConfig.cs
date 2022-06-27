using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
        public class CompanyPositionRecordConfig : IEntityTypeConfiguration<CompanyPositionRecord>
        {
            public void Configure(EntityTypeBuilder<CompanyPositionRecord> builder)
            {
                builder.ToTable("CompanyPositionRecord", "Company").HasKey(f => f.Id);
                builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            }
        }
    
}
