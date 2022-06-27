using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class CompanyMemberRecordConfig : IEntityTypeConfiguration<CompanyMemberRecord>
    {
        public void Configure(EntityTypeBuilder<CompanyMemberRecord> builder)
        {
            builder.ToTable("CompanyMemberRecord", "Company").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.HasOne(e => e.CompanyMember).WithMany(r => r.CompanyMemberRecord).HasForeignKey(f => f.CompanyMemberId);
        }
    }
}
