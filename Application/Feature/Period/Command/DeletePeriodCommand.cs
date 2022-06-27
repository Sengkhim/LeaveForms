using Application.BusinessObejct;
using Application.Repositery;
using AutoMapper;
using Domain.Authentication;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Presistance.DataBase;
using Share.Wapper;

namespace Application.Feature
{
    public class DeletePeriodCommand : IRequest<IResponse>
    {
        public DeletePeriodCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public class Handler : IRequestHandler<DeletePeriodCommand, IResponse>
        {
            private readonly UserManager<User> _manager;
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unit;
            private readonly IUserSerive _user;
            private readonly IBusinessLogics _logics;

            public Handler(IUnitOfWork unit, IMapper mapper, UserManager<User> manager, IUserSerive user, IBusinessLogics logics)
            {
                _unit = unit;
                _mapper = mapper;
                _manager = manager;
                _user = user;
                _logics = logics;
            }

            public async Task<IResponse> Handle(DeletePeriodCommand request, CancellationToken cancellationToken)
            {
                var user = await _logics.GetActingUser();

                if (user is null)
                    return await Response<Period>.FailAsync("This user is not active");
                var period = await _unit.Repository<Period>().GetByIdAsync(request.Id);
                if (period != null)
                {
                    await _unit.Repository<Period>().DeleteAsync(period);
                    await _unit.CommitAsync(cancellationToken);
                    return (Response)await Response.SuccessAsync("Period has been deleted.");
                }

                return (Response)await Response.FailAsync("Unable to delete this item.");
            }
        }
    }
}
