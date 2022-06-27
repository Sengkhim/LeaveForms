using Application.Repositery;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllAdvanceLeaveQuery : IRequest<Response<List<AdvanceLeaveResponse>>>
    {
        public class Handler : IRequestHandler<GetAllAdvanceLeaveQuery, Response<List<AdvanceLeaveResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<List<AdvanceLeaveResponse>>> Handle(GetAllAdvanceLeaveQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var query = _unitOfWork.Repository<AdvanceLeave>().GetToQueryable();
                    var data = await query.ToListAsync();
                    var mapData = _mapper.Map<List<AdvanceLeaveResponse>>(data);

                    return await Response<List<AdvanceLeaveResponse>>.SuccessAsync(mapData, "Get all AdvanceLeave.");
                }
                catch (Exception ex)
                {
                    return await Response<List<AdvanceLeaveResponse>>.FailAsync($"Get all AdvanceLeave > {ex.Message}");
                }
            }
        }
    }
}
