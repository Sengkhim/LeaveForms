
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class RecordStatusTypeConfig : IEntityTypeConfiguration<RecordStatusType>
    {
        public void Configure(EntityTypeBuilder<RecordStatusType> builder)
        {
            builder.ToTable("RecordStatusTypes", "RecordStatusType").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.HasIndex(e => new { e.Code }).IsUnique();
        }
    }
}
