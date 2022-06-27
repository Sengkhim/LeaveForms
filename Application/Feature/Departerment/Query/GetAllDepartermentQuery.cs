
using Application.BusinessObejct;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllDepartermentQuery : IRequest<Response<List<DepartermentResponse>>>
    {
        public class Handler : IRequestHandler<GetAllDepartermentQuery, Response<List<DepartermentResponse>>>
        {
            private readonly IBusinessLogics _logics;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IBusinessLogics logics)
            {
                _mapper = mapper;
                _logics = logics;
            }

            public async Task<Response<List<DepartermentResponse>>> Handle(GetAllDepartermentQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var actingDate = DateTimeOffset.UtcNow;

                    var queryResult = await _logics.GetDepartermentQueryableAsync(actingDate);
                    var data = await queryResult.ToListAsync(cancellationToken);
                    var mapData = _mapper.Map<List<DepartermentResponse>>(data);

                    return await Response<List<DepartermentResponse>>.SuccessAsync(mapData, "Get all Departerment.");
                }
                catch (Exception ex)
                {
                    return await Response<List<DepartermentResponse>>.FailAsync($"Get all Departerment > {ex.Message}");
                }
            }
        }
    }
}
