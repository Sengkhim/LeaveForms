
namespace Domain.Entites
{
    public interface IEntity
    {
        public Guid? CreatedByUser { get; set; }
        public Guid? ModifiedByUser { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
