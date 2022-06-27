using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class MemberTypeRecordConfig : IEntityTypeConfiguration<MemberTypeRecord>
    {
        public void Configure(EntityTypeBuilder<MemberTypeRecord> builder)
        {
            builder.ToTable("MemberTypeRecords", "Member").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.HasOne(e => e.MemberType).WithMany(x => x.MemberTypeRecord).HasForeignKey(f => f.MemberTypeId);
        }
    }
}
