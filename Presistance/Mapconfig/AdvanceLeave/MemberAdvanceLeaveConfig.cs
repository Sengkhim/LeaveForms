
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class MemberAdvanceLeaveConfig : IEntityTypeConfiguration<MemberAdvanceLeave>
    {
        public void Configure(EntityTypeBuilder<MemberAdvanceLeave> builder)
        {
            builder.ToTable(" MemberAdvanceLeave", "AdvanceLeave").HasKey(f => f.Id);
        }
    }
}
