
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class MemberAdvanceLeaveRecordConfig : IEntityTypeConfiguration<MemberAdvanceLeaveRecord>
    {
        public void Configure(EntityTypeBuilder<MemberAdvanceLeaveRecord> builder)
        {
            builder.ToTable(" MemberAdvanceLeaveRecord", "AdvanceLeave").HasKey(f => f.Id);
        }
    }
    public class MemberAdvanceLeaveRequestConfig : IEntityTypeConfiguration<MemberAdvanceLeaveRequest>
    {
        public void Configure(EntityTypeBuilder<MemberAdvanceLeaveRequest> builder)
        {
            builder.ToTable(" MemberAdvanceLeaveRequest", "AdvanceLeave").HasKey(f => f.Id);
        }
    }
}