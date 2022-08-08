using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
    public  class Period : Entity<Guid>
    {
        public DateTimeOffset? BeginDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        [StringLength(200)] public string? Description { get; set; }
    }
}
