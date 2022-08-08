using Application.Repositery;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllActualLeaveQuery : IRequest<Response<List<ActualLeaveResponse>>>
    {
        public class Handler : IRequestHandler<GetAllActualLeaveQuery, Response<List<ActualLeaveResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOf;
            public Handler(IMapper mapper, IUnitOfWork unitOf)
            {
                _mapper = mapper;
                _unitOf = unitOf;
            }

            public async Task<Response<List<ActualLeaveResponse>>> Handle(GetAllActualLeaveQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var query = _unitOf.Repository<ActualLeave>().GetToQueryable();
                    var ToData = query.Include(e => e.MemberActualLeave!).ThenInclude(q => q.Member).ThenInclude(p => p.Position)
                                       .Include(d => d.MemberActualLeave!).ThenInclude(q => q.Member).ThenInclude(p => p.Departerment)
                                       .Include(d => d.MemberActualLeave!).ThenInclude(q => q.Member).ThenInclude(p => p.User)
                                       .Include(r => r.ReasonCode).Include(w => w.LeaveType).AsQueryable();
                    var data = await ToData.ToListAsync(cancellationToken);
                    var mapData = _mapper.Map<List<ActualLeaveResponse>>(data);

                    return await Response<List<ActualLeaveResponse>>.SuccessAsync(mapData, "Get all ActualLeave.");
                }
                catch (Exception ex)
                {
                    return await Response<List<ActualLeaveResponse>>.FailAsync($"Get all ActualLeave > {ex.Message}");
                }
            }
        }
    }
}
