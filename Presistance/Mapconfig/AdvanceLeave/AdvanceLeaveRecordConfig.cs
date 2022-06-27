
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class AdvanceLeaveRecordConfig : IEntityTypeConfiguration<AdvanceLeaveRecord>
    {
        public void Configure(EntityTypeBuilder<AdvanceLeaveRecord> builder)
        {
            builder.ToTable(" AdvanceLeaveRecord", "AdvanceLeave").HasKey(f => f.Id);
        }
    }
}
