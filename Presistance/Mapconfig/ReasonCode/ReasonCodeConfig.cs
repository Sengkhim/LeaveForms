

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class ReasonCodeConfig : IEntityTypeConfiguration<ReasonCode>
    {
        public void Configure(EntityTypeBuilder<ReasonCode> builder)
        {

            builder.ToTable("ReasonCodes", "ReasonCode").HasKey(f => f.Id);
            builder.HasIndex(e => new { e.Code }).IsUnique();
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Code).HasMaxLength(20).IsRequired().HasColumnType("varchar");
            builder.HasMany(e => e.ReasonCodeRecord).WithOne(x => x.ReasonCode).HasForeignKey(f => f.ReasonCodeId);
        }
    }
}
