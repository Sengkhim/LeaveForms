using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
    public interface IEntity 
    {
        [Key] public Guid Id { get; set; }
        public Guid? CreatedByUser { get; set; }
        public Guid? ModifiedByUser { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
