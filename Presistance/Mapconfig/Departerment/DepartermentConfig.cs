
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class DepartermentConfig : IEntityTypeConfiguration<Departerment>
    {
        public void Configure(EntityTypeBuilder<Departerment> builder)
        {
            builder.ToTable("Departerments", "Departerment").HasKey(f => f.Id);
            builder.HasIndex(e => new { e.Code, e.Name }).IsUnique();
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Code).HasMaxLength(20).IsRequired().HasColumnType("varchar");
            builder.Property(e => e.Name).HasMaxLength(30).IsRequired().HasColumnType("varchar");
            builder.HasMany(e => e.DepartermentRecord).WithOne(r => r.Departerment).HasForeignKey(f => f.DepartermentId);
            builder.HasMany(e => e.DepartermentMember).WithOne(r => r.Departerment).HasForeignKey(f => f.DepartermentId);
        }
    }
}
