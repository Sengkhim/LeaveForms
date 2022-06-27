
namespace Application.Feature
{
    public interface IEntityResponse 
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        
    }
}
