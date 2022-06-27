using Domain.Entites.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public  class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companys", "Company").HasKey(f => f.Id); 
            builder.HasIndex(e => new { e.Code }).IsUnique();
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Code).HasMaxLength(20).IsRequired().HasColumnType("varchar");
            builder.Property(e => e.Name).HasMaxLength(30).IsRequired().HasColumnType("varchar");
            builder.Property(e => e.CommpanyType).HasMaxLength(30).IsRequired().HasColumnType("varchar");

            builder.HasMany(e => e.CompanyRecords).WithOne(r => r.Company).HasForeignKey(f => f.CompanyId);
        }
    }
}
