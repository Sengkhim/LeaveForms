
using Domain.Entites.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branchs", "Branch").HasKey(f => f.Id);
            builder.HasIndex(e => new { e.Code }).IsUnique();
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Code).HasMaxLength(20).IsRequired().HasColumnType("varchar");
            builder.Property(e => e.Name).HasMaxLength(30).IsRequired().HasColumnType("varchar");

            builder.HasMany(e => e.BranchRecord).WithOne(r => r.Branch).HasForeignKey(f => f.BranchId);
            builder.HasOne(e => e.CompanyDetail).WithMany(r => r.Branches).HasForeignKey(f => f.CompanyDetailId);
        }
    }
}
