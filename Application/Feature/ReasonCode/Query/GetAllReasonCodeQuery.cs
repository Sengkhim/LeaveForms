using Application.Repositery;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllReasonCodeQuery : IRequest<Response<List<ReasonCodeResponse>>>
    {
        public class Handler : IRequestHandler<GetAllReasonCodeQuery, Response<List<ReasonCodeResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOf;
            public Handler(IMapper mapper, IUnitOfWork unitOf)
            {
                _mapper = mapper;
                _unitOf = unitOf;
            }

            public async Task<Response<List<ReasonCodeResponse>>> Handle(GetAllReasonCodeQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var query = _unitOf.Repository<ReasonCode>().GetToQueryable();
                    var data = await query.ToListAsync(cancellationToken);
                    var mapData = _mapper.Map<List<ReasonCodeResponse>>(data);

                    return await Response<List<ReasonCodeResponse>>.SuccessAsync(mapData, "Get all ReasonCode.");
                }
                catch (Exception ex)
                {
                    return await Response<List<ReasonCodeResponse>>.FailAsync($"Get all ReasonCode > {ex.Message}");
                }
            }
        }
    }
}
