
using Application.BusinessObejct;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllPositionQuery : IRequest<Response<List<PositionResponse>>>
    {
        public class Handler : IRequestHandler<GetAllPositionQuery, Response<List<PositionResponse>>>
        {
            private readonly IBusinessLogics _logics;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IBusinessLogics logics)
            {
                _mapper = mapper;
                _logics = logics;
            }

            public async Task<Response<List<PositionResponse>>> Handle(GetAllPositionQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var actingDate = DateTimeOffset.UtcNow;
                    var user = await _logics.GetActingUser();
                    if (user == null)
                        throw new QueryException("The acting user was not found.");

                    var queryResult = await _logics.GetActivePositionQueryableAsync(user.Id, actingDate);
                    var data = await queryResult.ToListAsync(cancellationToken);
                    var mapData = _mapper.Map<List<PositionResponse>>(data);

                    return await Response<List<PositionResponse>>.SuccessAsync(mapData, "Get all Position.");
                }
                catch (Exception ex)
                {
                    return await Response<List<PositionResponse>>.FailAsync($"Get all Position > {ex.Message}");
                }
            }
        }
    }
}
