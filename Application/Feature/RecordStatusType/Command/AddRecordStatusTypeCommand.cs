using Application.BusinessObejct;
using Application.Repositery;
using Domain;
using MediatR;
using Share.Wapper;

namespace Application.Feature
{
    public class AddRecordStatusTypeCommand : EntityCommandAdd, IRequest<IResponse>
    {
        public string? Code { get; set; }

        public async Task<RecordStatusType> ToRecordStatusTypeAsync(IBusinessLogics logics, Guid UserId, DateTimeOffset actingDate, bool recordInclude = false)
        {
          
            var entity = new RecordStatusType
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedUserId = UserId,
                Code = Code,
                Description = Description,
            };
            return  entity;
        }
        public override async Task<Guid> AddToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, bool isSaved = true)
        {
            try
            {
                var entity = await ToRecordStatusTypeAsync(logics, userId, actingDate);
                logics.DataContext.RecordStatusType.Add(entity);
                if (isSaved) await logics.DataContext.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new CommandException(ex.Message);
            }
        }
        public class Handler : IRequestHandler<AddRecordStatusTypeCommand, IResponse>
        {
            private readonly IBusinessLogics _logics;
            private readonly IUnitOfWork _unit; 

            public Handler(IBusinessLogics logics, IUnitOfWork unit)
            {
                _logics = logics;
                _unit = unit;
            }

            public async Task<IResponse> Handle(AddRecordStatusTypeCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding record status type";
                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                if (request is null) return await AddToDbHandle(request, cancellationToken);
                return await Response<Guid>.SuccessAsync(
                  $"{prefixMsg} successfully saved.");
            }
            protected virtual async Task<IResponse> AddToDbHandle(AddRecordStatusTypeCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding record status type";
                var actingDate = DateTimeOffset.UtcNow;
                var actingUser = await _logics.GetActingUser();
                if (actingUser == null)
                    return await Response<Guid>.FailAsync($"{prefixMsg} > A user to perform the action was not found.");
                //await using var transaction = _logics.DataContext.Database.BeginTransaction();
                try
                {
                     await request.AddToDbHandle(_logics, actingUser.Id, actingDate, false);//Handle Adding to record status type
                    await _logics.DataContext.SaveChangesAsync(cancellationToken);
                    //await _unit.CommitAsync(cancellationToken);
                    return await Response<Guid>.SuccessAsync(
                        $"{prefixMsg} >  were successfully saved.");
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
                        $"{prefixMsg} > Failed in saving new record status type, records status member. > {ex.Message}");
                }
            }
        }
    }
}
