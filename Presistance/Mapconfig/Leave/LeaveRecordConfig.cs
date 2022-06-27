
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class LeaveRecordConfig : IEntityTypeConfiguration<LeaveRecord>
    {
        public void Configure(EntityTypeBuilder<LeaveRecord> builder)
        {
            builder.ToTable("Leave", "LeaveRecord").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.HasOne(e => e.Leave).WithMany(r => r.LeaveRecord).HasForeignKey(f => f.LeaveId);
        }
    }
}
