
using Application.BusinessObejct;

namespace Application.Feature
{
    public abstract class EntityCommandAdd
    {
        public string? Description { get; set; }
        public abstract Task<Guid>? AddToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, bool isSaved = true);
    }

}
