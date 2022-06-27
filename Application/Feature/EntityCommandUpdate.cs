
using Application.BusinessObejct;

namespace Application.Feature
{
    public abstract class EntityCommandUpdate
    {
        public Guid? Id { get; set; }
        public string? Description { get; set; }
        public abstract Task<Guid> UpdateToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, bool isSaved = true);
    }

}
