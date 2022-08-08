
using Application.Repositery;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllLeaveTypeQuery : IRequest<Response<List<LeaveTypeResponse>>>
    {
        public class Handler : IRequestHandler<GetAllLeaveTypeQuery, Response<List<LeaveTypeResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOf;
            public Handler(IMapper mapper, IUnitOfWork unitOf)
            {
                _mapper = mapper;
                _unitOf = unitOf;
            }

            public async Task<Response<List<LeaveTypeResponse>>> Handle(GetAllLeaveTypeQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var query = _unitOf.Repository<LeaveType>().GetToQueryable();
                    var data = await query.ToListAsync(cancellationToken);
                    var mapData = _mapper.Map<List<LeaveTypeResponse>>(data);

                    return await Response<List<LeaveTypeResponse>>.SuccessAsync(mapData, "Get all LeaveType.");
                }
                catch (Exception ex)
                {
                    return await Response<List<LeaveTypeResponse>>.FailAsync($"Get all LeaveType > {ex.Message}");
                }
            }
        }
    }
}
