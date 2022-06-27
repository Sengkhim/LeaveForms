using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class ReasonCodeRecordConfig : IEntityTypeConfiguration<ReasonCodeRecord>
    {
        public void Configure(EntityTypeBuilder<ReasonCodeRecord> builder)
        {

            builder.ToTable("ReasonCodeRecords", "ReasonCode").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
        }
    }
}
