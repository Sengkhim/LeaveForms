using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class Regionconfig : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Regions", "Region").HasKey(f => f.Id);
            builder.HasIndex(e => new { e.Code }).IsUnique();
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Code).HasMaxLength(20).IsRequired().HasColumnType("varchar");
            builder.Property(e => e.Name).HasMaxLength(30).IsRequired().HasColumnType("varchar");

            builder.HasMany(e => e.ReasonCodeRecord).WithOne(r => r.Region).HasForeignKey(f => f.RegionId);
        }
    }
}
