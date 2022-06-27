using Application.BusinessObejct;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllPeriodQuery : IRequest<Response<List<PeriodResponse>>>
    {
        public class Handler : IRequestHandler<GetAllPeriodQuery, Response<List<PeriodResponse>>>
        {
            private readonly IBusinessLogics _logics;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IBusinessLogics logics)
            {
                _mapper = mapper;
                _logics = logics;
            }

            public async Task<Response<List<PeriodResponse>>> Handle(GetAllPeriodQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var user = await _logics.GetActingUser();
                    if (user == null)
                        throw new QueryException("The acting user was not found.");

                    var queryResult = await _logics.GetPeriodsQueryableAsync(user.Id);
                    var data = await queryResult.ToListAsync(cancellationToken);
                    var mapData = _mapper.Map<List<PeriodResponse>>(data);

                    return await Response<List<PeriodResponse>>.SuccessAsync(mapData, "Get all periods.");
                }
                catch (Exception ex)
                {
                    return await Response<List<PeriodResponse>>.FailAsync($"Get all periods > {ex.Message}");
                }
            }
        }
    }
}
