using Domain.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.BaseEntity
{
    public abstract class Entity<TKey> : IEntity
    {
        [ForeignKey(nameof(CreatedByUser))] public User? CreateUser { get; set; }

        [ForeignKey(nameof(ModifiedByUser))] public User? ModifiedUser { get; set; }

        [Key] public TKey? Id { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public Guid? CreatedByUser { get; set; }
        public Guid? ModifiedByUser { get; set; }
    }
}
