using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class ContactRecordConfig : IEntityTypeConfiguration<ContactRecord>
    {
        public void Configure(EntityTypeBuilder<ContactRecord> builder)
        {
            builder.ToTable("ContactRecords", "Contact").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
        }
    }
}
