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
            private readonly IUnitOfWork _unitOf;
            public Handler(IMapper mapper, IUnitOfWork unitOf)
            {
                _mapper = mapper;
                _unitOf = unitOf;
            }

            public async Task<Response<List<AdvanceLeaveResponse>>> Handle(GetAllAdvanceLeaveQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var query = _unitOf.Repository<AdvanceLeave>().GetToQueryable().Where(d => d.IsDeleted == false);
                    var ToData = query.Include(e => e.MemberAdvanceLeave!).ThenInclude(q => q.Member).ThenInclude(p => p.Position)
                                      .Include(d => d.MemberAdvanceLeave!).ThenInclude(q => q.Member).ThenInclude(p => p.Departerment)
                                      .Include(d => d.MemberAdvanceLeave!).ThenInclude(q => q.Member).ThenInclude(p => p.User)
                                      .Include(r => r.ReasonCode).Include(w => w.LeaveType)
                                      .OrderByDescending(d => d.CreatedDate).AsQueryable();
                    var data = await ToData.ToListAsync(cancellationToken);
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
