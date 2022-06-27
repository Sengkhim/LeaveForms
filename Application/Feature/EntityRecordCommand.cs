
using Application.BusinessObejct;

namespace Application.Feature
{
    public abstract class EntityRecordCommand
    {
        public Guid? Id { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? PeriodBeginDate { get; set; }
        public DateTimeOffset? PeriodEndDate { get; set; }
        public string? ReasonCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logics"></param>
        /// <param name="userId"></param>
        /// <param name="actingDateGuid"></param>
        /// <param name="entityId"></param>
        /// <param name="isSaved"></param>
        /// <returns></returns>
        public abstract Task<Guid> AddToDbHandle(IBusinessLogics logics, Guid userId,
        DateTimeOffset actingDateGuid, Guid entityId, bool isSaved = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logics"></param>
        /// <param name="userId"></param>
        /// <param name="actingDateGuid"></param>
        /// <param name="entityId"></param>
        /// <param name="isSaved"></param>
        /// <returns></returns>
        protected abstract Task<Guid> UpdateToDbHandle(IBusinessLogics logics, Guid userId,
            DateTimeOffset actingDate, Guid entityId, bool isSaved = true);
    }
}
