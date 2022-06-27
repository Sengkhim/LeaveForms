using Application.BusinessObejct;
using Domain;

namespace Application.Feature
{
    public class AddReasonCodeRecordCommand : EntityRecordCommand
    {
        public string? RecordStatusTypeCode { get; set; }
        public async Task<ReasonCodeRecord> ToReasonCodeRecordAsync(IBusinessLogics logics, Guid UserId,
            DateTimeOffset actingDate, Guid entityId)
        {
            var beginDate = PeriodBeginDate?.ToUniversalTime();
            var endDate = PeriodEndDate?.ToUniversalTime();

            var period = await logics.GetOrCreatePeriodAsync(UserId, PeriodBeginDate, PeriodEndDate);
            if (period == null)
                throw new CommandException($"Cannot get/create a period [{PeriodBeginDate}, {PeriodEndDate}]");

            var rst = await logics.GetRecordStatusTypeCoverPeriodAsync(UserId, RecordStatusTypeCode!, beginDate,endDate);
            if (rst == null)
                throw new CommandException(
                    $"Cannot get a active record status type with the code {RecordStatusTypeCode} in the period [{PeriodBeginDate}, {PeriodEndDate}]");
           
            var entity = new ReasonCodeRecord
            {

                Id = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedUserId = UserId,
                PeriodId = period.Id,
                RecordStatusTypeId = rst.Id,
                ReasonCodeId = entityId,
                Description = Description
            };
            return entity;
        }
        public override async Task<Guid> AddToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, Guid entityId, bool isSaved = true)
        {
            try
            {
                var recordEntity = await ToReasonCodeRecordAsync(logics, userId, actingDate, entityId);
                logics.DataContext.ReasonCodeRecord.Add(recordEntity);
                if (isSaved) await logics.DataContext.SaveChangesAsync();
                return recordEntity.Id;
            }
            catch (CommandException ex)
            {
                throw new CommandException($"Adding Reason Code record: {ex.Message}");
            }
        }

        protected override Task<Guid> UpdateToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDateGuid, Guid entityId, bool isSaved = true)
        {
            throw new NotImplementedException();
        }
    }
}
