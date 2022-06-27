using Application.BusinessObejct;
using Domain;
using MediatR;
using Share.Wapper;

namespace Application.Feature
{
    public class AddPositionCommand : EntityCommandAdd, IRequest<IResponse>
    {
        public string? Name { get; set; }
        public string? Code { get; set; }

        public async Task<Position> ToPositionAsync(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, bool recordIncluded = false)
        {
            var entity = new Position
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedUserId = userId,
                Code = Code,
                Description = Description,
                Name = Name
            };
            return entity;
        }

        public override async Task<Guid> AddToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, bool isSaved = true)
        {
            try
            {
                var entity = await ToPositionAsync(logics, userId, DateTimeOffset.UtcNow);
                logics.DataContext.Position.Add(entity);
                if (isSaved) await logics.DataContext.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new CommandException(ex.Message);
            }
        }

        public class Handler : IRequestHandler<AddPositionCommand, IResponse>
        {

            private readonly IBusinessLogics _logics;

            public Handler(IBusinessLogics logics)
            {
                _logics = logics;
            }

            public async Task<IResponse> Handle(AddPositionCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding position";
                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                if (request != null) return await AddToDbHandle(request!, cancellationToken);
                return await Response<Guid>.SuccessAsync(
                  $"{prefixMsg} successfully saved.");
            }
            protected virtual async Task<IResponse> AddToDbHandle(AddPositionCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding position";
                var actingDate = DateTimeOffset.UtcNow;
                var actingUser = await _logics.GetActingUser();
                if (actingUser == null)
                    return await Response<Guid>.FailAsync($"{prefixMsg} > A user to perform the action was not found.");
                try
                {
                    await request.AddToDbHandle(_logics, actingUser.Id, actingDate, false);
                    await _logics.DataContext.SaveChangesAsync(cancellationToken);
                    return await Response<Guid>.SuccessAsync(
                        $"{prefixMsg} > were successfully saved.");
                }

                catch (CommandException ex)
                {
                    return await Response<Guid>.FailAsync($"{prefixMsg} > {ex.Message}");
                }
                catch (Exception ex)
                {
                    return await Response<Guid>.FailAsync(
                        $"{prefixMsg} > Failed in saving new position > {ex.Message}");
                }
            }
        }
    }
}
