using Application.Repositery;
using Domain;
using MediatR;
using Share.Wapper;

namespace Application.Feature
{
    public class AddReasonCodeCommand : IRequest<IResponse>
    {
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        public class Handler : IRequestHandler<AddReasonCodeCommand, IResponse>
        {
            private readonly IUnitOfWork _unit;
            public Handler(IUnitOfWork unit)
            {
                _unit = unit;
            }

            public async Task<IResponse> Handle(AddReasonCodeCommand request, CancellationToken cancellationToken)
            {
                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                var entity = new ReasonCode
                {
                    Id = Guid.NewGuid(),
                    Code = request.Code,
                    Description = request.Description,
                };
                try
                {
                    await _unit.Repository<ReasonCode>().AddAsync(entity);
                    await _unit.CommitAsync(cancellationToken);
                }
                catch (ApiException e)
                {
                    return (Response)await Response.FailAsync(e.Message);
                }

                return (Response)await Response.SuccessAsync("Object has been added!");
            }
        }
    }
}
