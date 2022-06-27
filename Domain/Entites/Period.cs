using Domain.Authentication;
using Domain.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites
{
    public  class Period : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public DateTimeOffset? BeginDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        [StringLength(200)] public string? Description { get; set; }
        [ForeignKey(nameof(UserId))] public User? User { get; set; }
    }
}
