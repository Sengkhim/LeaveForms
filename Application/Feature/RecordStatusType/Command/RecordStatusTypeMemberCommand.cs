
using Application.BusinessObejct;
using Application.Repositery;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class RecordStatusTypeMemberCommand : EntityCommandAdd, IRequest<IResponse>
    {
        public DateTimeOffset? PeriodBeginDate { get; set; }
        public DateTimeOffset? PeriodEndDate { get; set; }
        public Guid RecordStatusTypeId { get; set; }
        public string? RecordStatusTypeCode { get; set; }
        public async Task<RecordStatusTypeMember> ToRecordStatusTypeMemberAsync(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate)
        {
            var beginDate = PeriodBeginDate?.ToUniversalTime();
            var endDate = PeriodEndDate?.ToUniversalTime();

            var period = await logics.GetOrCreatePeriodAsync(userId, beginDate, endDate);
            if (period == null)
                throw new CommandException($"Cannot get/create a period [{PeriodBeginDate}, {PeriodEndDate}]");

            var rst = await logics.DataContext.RecordStatusType.FirstOrDefaultAsync(e =>
                e.Id == RecordStatusTypeId || e.Code == RecordStatusTypeCode);
            if (rst == null)
                throw new CommandException(
                    $"Cannot get record status type with id {RecordStatusTypeId} or the code {RecordStatusTypeCode}");

            var record = new RecordStatusTypeMember
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedUserId = userId,
                UserId = userId,
                PeriodId = period.Id,
                RecordStatusTypeId = rst.Id,
                Description = Description
            };
            return record;
        }
        public override async Task<Guid> AddToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, bool isSaved = true)
        {
            try
            {
                var recordEntity =
                    await ToRecordStatusTypeMemberAsync(logics, userId, actingDate);
                logics.DataContext.RecordStatusTypeMember.Add(recordEntity);
                if (isSaved) await logics.DataContext.SaveChangesAsync();
                return recordEntity.Id;
            }
            catch (CommandException ex)
            {
                throw new CommandException( $"Adding record status type member: {ex.Message}");
            }
        }

        public class Handler : IRequestHandler<RecordStatusTypeMemberCommand, IResponse>
        {
            private readonly IBusinessLogics _logics;
            private readonly IUnitOfWork _unit;

            public Handler(IBusinessLogics logics, IUnitOfWork unit)
            {
                _logics = logics;
                _unit = unit;
            }

            public async Task<IResponse> Handle(RecordStatusTypeMemberCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding record status type";
                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                if (request is null) return await AddToDbHandle(request, cancellationToken);
                return await Response<Guid>.SuccessAsync(
                  $"{prefixMsg} successfully saved.");
            }
            protected virtual async Task<IResponse> AddToDbHandle(RecordStatusTypeMemberCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding record status type membr";
                var actingDate = DateTimeOffset.UtcNow;
                var actingUser = await _logics.GetActingUser();
                if (actingUser == null)
                    return await Response<Guid>.FailAsync($"{prefixMsg} > A user to perform the action was not found.");
                //await using var transaction = _logics.DataContext.Database.BeginTransaction();
                try
                {
                    await request.AddToDbHandle(_logics, actingUser.Id, actingDate,false); //Handle Adding to record status type member
                    await _logics.DataContext.SaveChangesAsync(cancellationToken);
                    return await Response<Guid>.SuccessAsync(
                        $"{prefixMsg} > were successfully saved.");
                }

                catch (CommandException ex)
                {
                    //transaction.Rollback();
                    return await Response<Guid>.FailAsync($"{prefixMsg} > {ex.Message}");
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    return await Response<Guid>.FailAsync(
                        $"{prefixMsg} > Failed in saving new record status type member. > {ex.Message}");
                }
            }
        }
    }
}
