using Domain.Entites.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts", "Contact").HasKey(f => f.Id);
            builder.HasIndex(e => new { e.Code }).IsUnique();
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Code).HasMaxLength(20).IsRequired().HasColumnType("varchar");
            builder.Property(e => e.Name).HasMaxLength(30).IsRequired().HasColumnType("varchar");
            builder.Property(e => e.Contacts).HasMaxLength(30).IsRequired().HasColumnType("varchar");
            builder.HasMany(e => e.ContactRecord).WithOne(r => r.Contact).HasForeignKey(f => f.ContactId);
        }
    }
}
