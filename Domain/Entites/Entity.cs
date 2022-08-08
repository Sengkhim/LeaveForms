using Domain.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites.BaseEntity
{
    public abstract class Entity<Key> 
    { 
        [Key] public Key? Id { get ; set ; }
        [ForeignKey(nameof(CreatedUserId))] public User? CreateUser { get; set; }
        [ForeignKey(nameof(ModifiedUserId))] public User? ModifiedUser { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
