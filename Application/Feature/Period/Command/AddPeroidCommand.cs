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
    public class PeriodCommand : IRequest<IResponse>
    {
        public DateTimeOffset BeginDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string? Description { get; set; }

        public class Handler : IRequestHandler<PeriodCommand, IResponse>
        {
            private readonly UserManager<User> _manager;
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unit;
            private readonly IUserSerive _user;
            private readonly IBusinessLogics _logics;

            public Handler(IUnitOfWork unit, IMapper mapper, IUserSerive user,
                UserManager<User> manager, IBusinessLogics logics)
            {
                _unit = unit;
                _mapper = mapper;
                _user = user;
                _manager = manager;
                _logics = logics;
            }

            public async Task<IResponse> Handle(PeriodCommand request, CancellationToken cancellationToken)
            {
                var user = await _logics.GetActingUser();

                if (user is null) return await Response<Period>.FailAsync("Invalid user.");

                var validate = new PeriodValidation();
                var result = validate.Validate(request);
                if (!result.IsValid)
                {
                    return await Response.FailAsync(result.Errors.Select(e => e.ErrorMessage).ToList());
                }
            
                    var period = new Period
                    {
                        Id = Guid.NewGuid(),
                        Description = request.Description,
                        BeginDate = request.BeginDate,
                        EndDate = request.EndDate,
                        UserId = user.Id
                    };
                    await _unit.Repository<Period>().AddAsync(period);
                    await _unit.CommitAsync(cancellationToken);
                    return await Response.SuccessAsync("Period has been added.");
            }
        }
    }
}
