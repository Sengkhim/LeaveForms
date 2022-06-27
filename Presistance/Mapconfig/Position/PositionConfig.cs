
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions", "Position").HasKey(f => f.Id);
            builder.HasIndex(e => new { e.Code }).IsUnique();
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Code).HasMaxLength(20).IsRequired().HasColumnType("varchar");
            builder.HasMany(e => e.PositionRecord).WithOne(x => x.Position).HasForeignKey(x => x.PositionId);
        }
    }
}
