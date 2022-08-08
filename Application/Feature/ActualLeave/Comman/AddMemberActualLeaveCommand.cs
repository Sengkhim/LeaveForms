using Application.Repositery;
using Domain;
using MediatR;
using Presistance.DataBase;
using Share.Wapper;

namespace Application.Feature
{
    public class AddMemberActualLeaveCommand : IRequest<IResponse>
    {
        public Guid ActualLeaveId { get; set; }
        public Guid MemberId { get; set; }

        public class Handler : IRequestHandler<AddMemberActualLeaveCommand, IResponse>
        {

            private readonly IUnitOfWork _unit;
            private readonly IUserSerive _user;

            public Handler(IUnitOfWork unit, IUserSerive user)
            {
                _unit = unit;
                _user = user;
            }

            public async Task<IResponse> Handle(AddMemberActualLeaveCommand request, CancellationToken cancellationToken)
            {

                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                var entity = new MemberActualLeave
                {
                    Id = Guid.NewGuid(),
                    MemberId = request.MemberId,
                    ActualLeaveId = request.ActualLeaveId,
                };
                try
                {
                    await _unit.Repository<MemberActualLeave>().AddAsync(entity);
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
