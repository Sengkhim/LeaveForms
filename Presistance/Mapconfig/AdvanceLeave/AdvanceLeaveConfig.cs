
using Domain;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class AdvanceLeaveConfig : IEntityTypeConfiguration<AdvanceLeave>
    {
        public void Configure(EntityTypeBuilder<AdvanceLeave> builder)
        {
            builder.ToTable("AdvanceLeaves", "AdvanceLeave").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);

            //builder.HasMany(e => e.AdvanceLeaveRecords).WithOne(r => r.AdvanceLeave).HasForeignKey(f => f.AdvanceLeaveId);
        }
    }
}
public class AdvanceLeaveConfig : IEntityTypeConfiguration<MemberAdvanceLeave>
{
    public void Configure(EntityTypeBuilder<MemberAdvanceLeave> builder)
    {
        builder.ToTable("MemberAdvanceLeave", "AdvanceLeave").HasKey(f => f.Id);   
    }
}
