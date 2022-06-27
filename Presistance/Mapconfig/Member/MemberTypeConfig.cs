using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class MemberTypeConfig : IEntityTypeConfiguration<MemberType>
    {
        public void Configure(EntityTypeBuilder<MemberType> builder)
        {
            builder.ToTable("MemberTypes", "Member").HasKey(f => f.Id);
            builder.HasIndex(e => new { e.Code,  }).IsUnique();
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
        }
    }
}
