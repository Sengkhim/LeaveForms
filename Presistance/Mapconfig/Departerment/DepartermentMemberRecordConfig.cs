
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class DepartermentMemberRecordConfig : IEntityTypeConfiguration<DepartermentMemberRecord>
    {
        public void Configure(EntityTypeBuilder<DepartermentMemberRecord> builder)
        {
            builder.ToTable("DepartermentMemberRecords", "Departerment").HasKey(f => f.Id);
        }
    }
}
