using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members", "Member").HasKey(f => f.Id);
            builder.HasIndex(e => new { e.Code }).IsUnique();
            builder.Property(e => e.Description).HasMaxLength(200);
            builder.HasMany(e => e.MemberRecord).WithOne(x => x.Member).HasForeignKey(f => f.MemberId);

            //builder.HasMany(e => e.MemberAdvanceLeave).WithOne(x => x.Member).HasForeignKey(f => f.MemberId);
        }
    }
}
