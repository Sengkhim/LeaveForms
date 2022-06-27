using Application.BusinessObejct;
using Application.Repositery;
using Domain;
using MediatR;
using Presistance.DataBase;
using Share.Wapper;

namespace Application.Featur
{
    public class AddMemberCommand : IRequest<IResponse>
    {
        public Guid DepartermentId { get; set; }
        public Guid PositonId { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }

        public class Handler : IRequestHandler<AddMemberCommand, IResponse>
        {
            private readonly IUnitOfWork _unit;
            private readonly IUserSerive _user;

            public Handler(IUnitOfWork unit, IUserSerive user)
            {
                _unit = unit;
                _user = user;   
            }

            public async Task<IResponse> Handle(AddMemberCommand request, CancellationToken cancellationToken)
            {
                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                var entity = new Member
                {
                    Id = Guid.NewGuid(),
                    MemberId = _user.UserId,
                    DepartermentId = request.DepartermentId,
                    PositonId = request.PositonId,
                    Code = request.Code,
                    Description = request.Description,
                };
                try
                {
                    await _unit.Repository<Member>().AddAsync(entity);
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
