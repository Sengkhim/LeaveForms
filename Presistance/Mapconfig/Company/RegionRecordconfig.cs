using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class RegionRecordconfig : IEntityTypeConfiguration<RegionRecord>
    {
        public void Configure(EntityTypeBuilder<RegionRecord> builder)
        {
            builder.ToTable("RegionRecords", "Region").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
        }
    }
}
