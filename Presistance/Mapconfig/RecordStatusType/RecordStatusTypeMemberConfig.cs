
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class RecordStatusTypeMemberConfig : IEntityTypeConfiguration<RecordStatusTypeMember>
    {
        public void Configure(EntityTypeBuilder<RecordStatusTypeMember> builder)
        {
            builder.ToTable(" RecordStatusTypeMember", "RecordStatusType").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);

        }
    }
}
