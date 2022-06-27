
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class PositionRecordConfig : IEntityTypeConfiguration<PositionRecord>
    {
        public void Configure(EntityTypeBuilder<PositionRecord> builder)
        {
            builder.ToTable("PositionRecords", "Position").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
        }
    }
}
