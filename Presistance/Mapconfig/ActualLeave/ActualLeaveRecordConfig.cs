using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class ActualLeaveRecordConfig : IEntityTypeConfiguration<ActualLeaveRecord>
    {
        public void Configure(EntityTypeBuilder<ActualLeaveRecord> builder)
        {
            builder.ToTable("ActualLeaveRecord", "ActualLeave").HasKey(f => f.Id);
        }
    }
}
