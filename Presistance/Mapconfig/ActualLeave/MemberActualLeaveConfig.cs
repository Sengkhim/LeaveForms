using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class MemberActualLeaveConfig : IEntityTypeConfiguration<MemberActualLeave>
    {
        public void Configure(EntityTypeBuilder<MemberActualLeave> builder)
        {
            builder.ToTable(" MemberActualLeave", "ActualLeave").HasKey(f => f.Id);
        }
    }
}
