
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class DepartermentMemberConfig : IEntityTypeConfiguration<DepartermentMember>
    {
        public void Configure(EntityTypeBuilder<DepartermentMember> builder)
        {
            builder.ToTable("DepartermentMembers", "Departerment").HasKey(f => f.Id);
            builder.HasMany(e => e.DepartermentMemberRecord).WithOne(r => r.DepartermentMember)
                                                            .HasForeignKey(f => f.DepartermentMemberId);
        }
    }
}
