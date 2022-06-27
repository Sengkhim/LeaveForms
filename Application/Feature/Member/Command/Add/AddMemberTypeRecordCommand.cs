using Application.BusinessObejct;
using Domain;

namespace Application.Feature
{
    public class AddMemberTypeRecordCommand : EntityRecordCommand
    {
        public async Task<MemberTypeRecord> ToMemberTypeRecordAsync(IBusinessLogics logics, Guid UserId,
            DateTimeOffset actingDate, Guid entityId)
        {
            var period = await logics.GetOrCreatePeriodAsync(UserId, PeriodBeginDate, PeriodEndDate);
            if (period == null)
                throw new CommandException($"Cannot get/create a period [{PeriodBeginDate}, {PeriodEndDate}]");
            //var rsc = await logics.GetActiveReasonCodeCoverPeriodAsync(UserId, ReasonCode, PeriodBeginDate,
            //   PeriodEndDate);
            //if (rsc == null)
            //    throw new CommandException(
            //        $"Cannot get a active reason code with the code {ReasonCode} in the period [{PeriodBeginDate}, {PeriodEndDate}]");
            var entity = new MemberTypeRecord
            {

                Id = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedUserId = UserId,
                PeriodId = period.Id,
                MemberTypeId = entityId,
                //ReasonCodeId = Guid.Parse("B4067C87-38AC-4C2E-293E-08DA42D41399"),
                Description = Description
            };
            return entity;
        }
        public override async Task<Guid> AddToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, Guid entityId, bool isSaved = true)
        {
            try
            {
                var recordEntity = await ToMemberTypeRecordAsync(logics, userId, actingDate, entityId);
                logics.DataContext.MemberTypesRecord.Add(recordEntity);
                if (isSaved) await logics.DataContext.SaveChangesAsync();
                return recordEntity.Id;
            }
            catch (CommandException ex)
            {
                throw new CommandException( $"Adding member type record: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override Task<Guid> UpdateToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDateGuid, Guid entityId, bool isSaved = true)
        {
            throw new NotImplementedException();
        }
    }
}
