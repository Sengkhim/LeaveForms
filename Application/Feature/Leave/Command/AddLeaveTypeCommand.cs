using Application.Repositery;
using Domain;
using MediatR;
using Presistance.DataBase;
using Share.Wapper;

namespace Application.Feature
{
    public class AddLeaveTypeCommand : IRequest<IResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public class Handler : IRequestHandler<AddLeaveTypeCommand, IResponse>
        {
            private readonly IUnitOfWork _unit;
            private readonly IUserSerive _user;

            public Handler(IUnitOfWork unit, IUserSerive user)
            {
                _unit = unit;
                _user = user;
            }

            public async Task<IResponse> Handle(AddLeaveTypeCommand request, CancellationToken cancellationToken)
            {
                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                var entity = new LeaveType
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description,
                };
                try
                {
                    await _unit.Repository<LeaveType>().AddAsync(entity);
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
