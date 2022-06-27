
using Application.BusinessObejct;
using Application.Feature;
using Domain;
using MediatR;
using Share.Wapper;

namespace Application.Featur
{
    public class AddDepartermentCommand : EntityCommandAdd, IRequest<IResponse>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public async Task<Departerment> ToDepartermentAsync(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, bool recordIncluded = false)
        {
            var entity = new Departerment
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
                var entity = await ToDepartermentAsync(logics, userId, DateTimeOffset.UtcNow);
                logics.DataContext.Departerment.Add(entity);
                if (isSaved) await logics.DataContext.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new CommandException(ex.Message);
            }
        }

        public class Handler : IRequestHandler<AddDepartermentCommand, IResponse>
        {

            private readonly IBusinessLogics _logics;

            public Handler(IBusinessLogics logics)
            {
                _logics = logics;
            }

            public async Task<IResponse> Handle(AddDepartermentCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding departerment";
                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                if (request != null) return await AddToDbHandle(request!, cancellationToken);
                return await Response<Guid>.SuccessAsync(
                  $"{prefixMsg} successfully saved.");
            }
            protected virtual async Task<IResponse> AddToDbHandle(AddDepartermentCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding departerment";
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
                        $"{prefixMsg} > Failed in saving new departerment > {ex.Message}");
                }
            }
        }
    }
}
