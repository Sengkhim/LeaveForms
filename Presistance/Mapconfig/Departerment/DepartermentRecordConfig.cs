
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class DepartermentRecordConfig : IEntityTypeConfiguration<DepartermentRecord>
    {
        public void Configure(EntityTypeBuilder<DepartermentRecord> builder)
        {
            builder.ToTable("DepartermentRecords", "Departerment").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
        }
    }
}


