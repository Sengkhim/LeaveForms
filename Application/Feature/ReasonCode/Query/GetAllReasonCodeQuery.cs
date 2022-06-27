
using Application.BusinessObejct;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllReasonCodeQuery : IRequest<Response<List<ReasonCodeResponse>>>
    {
        public DateTimeOffset? ActingDate { get; set; } = null;

        public class Handler : IRequestHandler<GetAllReasonCodeQuery, Response<List<ReasonCodeResponse>>>
        {
            private readonly IBusinessLogics _logics;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IBusinessLogics logics)
            {
                _mapper = mapper;
                _logics = logics;
            }

            public async Task<Response<List<ReasonCodeResponse>>> Handle(GetAllReasonCodeQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var user = await _logics.GetActingUser();
                    if (user == null) throw new QueryException("The acting user was not found.");

                    var actingDate = request.ActingDate?.ToUniversalTime() ?? DateTimeOffset.UtcNow;
                    var queryResult = await _logics.GetActiveReasonCodesQueryableAsync(user.Id, actingDate);
                    var data = await queryResult.ToListAsync(cancellationToken);

                    var mapData = _mapper.Map<List<ReasonCodeResponse>>(data);

                    return await Response<List<ReasonCodeResponse>>.SuccessAsync(mapData, "Get all reason codes.");
                }
                catch (Exception ex)
                {
                    return await Response<List<ReasonCodeResponse>>.FailAsync($"Get all reason codes > {ex.Message}");
                }
            }
        }
    }
}
