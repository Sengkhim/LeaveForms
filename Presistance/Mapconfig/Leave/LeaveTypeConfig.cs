
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class LeaveTypeConfig : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.ToTable("LeaveTypes", "Leave").HasKey(f => f.Id);
            builder.Property(e => e.Description).IsUnicode().HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(30).IsRequired().HasColumnType("varchar");
        }
    }
}
