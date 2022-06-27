
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class BranchRecordConfig : IEntityTypeConfiguration<BranchRecord>
    {
        public void Configure(EntityTypeBuilder<BranchRecord> builder)
        {
            builder.ToTable("BranchRecords", "Branch").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
        }
    }
}
