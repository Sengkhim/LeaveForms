using Application.BusinessObejct;
using Domain;
using MediatR;
using Share.Wapper;

namespace Application.Feature
{
    public class AddReasonCodeCommand : EntityCommandAdd, IRequest<IResponse>
    {
        public string? Code { get; set; }
        public ICollection<AddReasonCodeRecordCommand>? ReasonCodeRecord { get; set; }

        public async Task<ReasonCode> ToReasonCodeAsync(IBusinessLogics logics, Guid UserId, Guid userId, DateTimeOffset actingDate, bool recordIncluded = false)
        {
            var entity = new ReasonCode
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedUserId = userId,
                UserId = UserId,
                Code = Code,
                Description = Description
            };
            if (recordIncluded && ReasonCodeRecord != null)
            {
                entity.ReasonCodeRecord = new List<ReasonCodeRecord>();
                foreach (var recordCmd in ReasonCodeRecord)
                {
                    var record =
                        await recordCmd.ToReasonCodeRecordAsync(logics, userId, actingDate, entity.Id);
                    if (record != null) entity.ReasonCodeRecord.Add(record);
                }
            }

            return entity;
        }

        public override async Task<Guid> AddToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, bool isSaved = true)
        {
            try
            {
                var entity = await ToReasonCodeAsync(logics, userId, userId, DateTimeOffset.UtcNow);
                logics.DataContext.ReasonCode.Add(entity);
                if (isSaved) await logics.DataContext.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new CommandException(0, ex.Message); //0-Add
            }
        }

        public class Handler : IRequestHandler<AddReasonCodeCommand, IResponse>
        {
            private readonly IBusinessLogics _logics;

            public Handler(IBusinessLogics logics)
            {
                _logics = logics;
            }

            public async Task<IResponse> Handle(AddReasonCodeCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding reason code ";
                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                if (request is null) return await AddToDbHandle(request!, cancellationToken);
                return await Response<Guid>.SuccessAsync(
                  $"{prefixMsg} successfully saved.");
            }
            protected virtual async Task<IResponse> AddToDbHandle(AddReasonCodeCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding reason code";
                var actingDate = DateTimeOffset.UtcNow;
                var actingUser = await _logics.GetActingUser();
                if (actingUser == null)
                    return await Response<Guid>.FailAsync($"{prefixMsg} > A user to perform the action was not found.");
                if (request.ReasonCodeRecord == null || request.ReasonCodeRecord.Count == 0)
                    return await Response<Guid>.FailAsync(
                        $"{prefixMsg} > Reason code to be added required at least a record.");
                try
                {
                    var reasonCodeId = await request.AddToDbHandle(_logics, actingUser.Id, actingDate, false);//Handle Adding to reason code 

                    //Handle adding to Member Type Record
                    if (request.ReasonCodeRecord is { Count: > 0 })
                    {
                        foreach (var recordCmd in request.ReasonCodeRecord)
                        {
                            await recordCmd.AddToDbHandle(_logics, actingUser.Id, actingDate, reasonCodeId, false);
                        }
                    }
                    await _logics.DataContext.SaveChangesAsync(cancellationToken);
                    return await Response<Guid>.SuccessAsync(
                        $"{prefixMsg} > A reason code, and records were successfully saved.");
                }

                catch (CommandException ex)
                {
                    return await Response<Guid>.FailAsync($"{prefixMsg} > {ex.Message}");
                }
                catch (Exception ex)
                {
                    return await Response<Guid>.FailAsync(
                        $"{prefixMsg} > Failed in saving new reacode code, records. > {ex.Message}");
                }
            }
        }
    }
}
