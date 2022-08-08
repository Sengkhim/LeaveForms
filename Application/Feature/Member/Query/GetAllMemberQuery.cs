using Application.Feature;
using Application.Repositery;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application
{
    public class GetAllMemberQuery : IRequest<Response<List<MemberResponse>>>
    {
        public class Handler : IRequestHandler<GetAllMemberQuery, Response<List<MemberResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOf;
            public Handler(IMapper mapper, IUnitOfWork unitOf)
            {
                _mapper = mapper;
                _unitOf = unitOf;
            }

            public async Task<Response<List<MemberResponse>>> Handle(GetAllMemberQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var query = _unitOf.Repository<Member>().GetToQueryable();
                    var toData = query.Include(e => e.Position).Include(d => d.Departerment)
                                      .Include(u => u.User).Include(t => t.MemberAdvanceLeave!)
                                      .ThenInclude(a => a.AdvanceLeave).ThenInclude(r => r.ReasonCode)
                                      .Include(ac => ac.MemberActualLeave!).ThenInclude(a => a.ActualLeave)
                                      .ThenInclude(r => r.ReasonCode)
                                      .AsQueryable();
                    var data = await toData.ToListAsync(cancellationToken);
                    var mapData = _mapper.Map<List<MemberResponse>>(data);

                    return await Response<List<MemberResponse>>.SuccessAsync(mapData, "Get all member.");
                }
                catch (Exception ex)
                {
                    return await Response<List<MemberResponse>>.FailAsync($"Get all member > {ex.Message}");
                }
            }
        }
    }
}
