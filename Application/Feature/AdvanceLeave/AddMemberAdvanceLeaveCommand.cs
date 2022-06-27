
using Application.Repositery;
using Domain;
using MediatR;
using Presistance.DataBase;
using Share.Wapper;

namespace Application.Feature
{
    public class AddMemberAdvanceLeaveCommand : IRequest<IResponse>
    {
        public Guid AdvanceLeaveId { get; set; }
        public Guid MemberId { get; set; }
        public class Handler : IRequestHandler<AddMemberAdvanceLeaveCommand, IResponse>
        {

            private readonly IUnitOfWork _unit;
            private readonly IUserSerive _user;

            public Handler(IUnitOfWork unit, IUserSerive user)
            {
                _unit = unit;
                _user = user;   
            }

            public async Task<IResponse> Handle(AddMemberAdvanceLeaveCommand request, CancellationToken cancellationToken)
            {

                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                var entity = new MemberAdvanceLeave
                {
                    Id = Guid.NewGuid(),
                    MemberId = request.MemberId,
                    AdvanceLeaveId = request.AdvanceLeaveId,
                };
                try
                {
                    await _unit.Repository<MemberAdvanceLeave>().AddAsync(entity);
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
