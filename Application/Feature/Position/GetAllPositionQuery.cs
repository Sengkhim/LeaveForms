using Application.Repositery;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllPositionQuery : IRequest<Response<List<PositionResponse>>>
    {
        public class Handler : IRequestHandler<GetAllPositionQuery, Response<List<PositionResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOf;
            public Handler(IMapper mapper, IUnitOfWork unitOf)
            {
                _mapper = mapper;
                _unitOf = unitOf;
            }

            public async Task<Response<List<PositionResponse>>> Handle(GetAllPositionQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var query = _unitOf.Repository<Position>().GetToQueryable();
                    var data = await query.ToListAsync(cancellationToken);
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
