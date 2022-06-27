using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class MemberActualLeaveRecordConfig : IEntityTypeConfiguration<MemberActualLeaveRecord>
    {
        public void Configure(EntityTypeBuilder<MemberActualLeaveRecord> builder)
        {
            builder.ToTable(" MemberActualLeaveRecord", "ActualLeave").HasKey(f => f.Id);
        }
    }
}
