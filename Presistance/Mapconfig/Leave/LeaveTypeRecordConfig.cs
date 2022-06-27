using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class LeaveTypeRecordConfig : IEntityTypeConfiguration<LeaveTypeRecord>
    {
        public void Configure(EntityTypeBuilder<LeaveTypeRecord> builder)
        {
            builder.ToTable("LeaveTypeRecords", "Leave").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);

        }
    }
}
