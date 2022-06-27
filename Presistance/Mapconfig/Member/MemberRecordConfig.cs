using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class MemberRecordConfig : IEntityTypeConfiguration<MemberRecord>
    {
        public void Configure(EntityTypeBuilder<MemberRecord> builder)
        {
            builder.ToTable("MemberRecords", "Member").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
        }
    }
}
