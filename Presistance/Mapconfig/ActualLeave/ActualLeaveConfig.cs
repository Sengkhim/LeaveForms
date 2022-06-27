using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class ActualLeaveConfig : IEntityTypeConfiguration<ActualLeave>
    {
        public void Configure(EntityTypeBuilder<ActualLeave> builder)
        {
            builder.ToTable("ActualLeaves", "ActualLeave").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);

            builder.HasMany(e => e.ActualLeaveRecord).WithOne(r => r.ActualLeave).HasForeignKey(f => f.ActualLeaveId);
        }
    }
}
