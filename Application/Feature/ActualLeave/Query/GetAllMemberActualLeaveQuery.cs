
using Application.Repositery;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllMemberActualLeaveQuery : IRequest<Response<List<MemberActaulLeaveResponse>>>
    {
        public class Handler : IRequestHandler<GetAllMemberActualLeaveQuery, Response<List<MemberActaulLeaveResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }
            public async Task<Response<List<MemberActaulLeaveResponse>>> Handle(GetAllMemberActualLeaveQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var query = _unitOfWork.Repository<MemberActualLeave>().GetToQueryable();
                    var include = query.Include(e => e.ActualLeave).ThenInclude(r => r.ReasonCode).Include(m => m.Member)
                                       .ThenInclude(e => e.User).Include(m => m.Member)
                                       .ThenInclude(p => p.Position).Include(m => m.Member)
                                       .ThenInclude(d => d.Departerment).AsQueryable();

                    var data = await include.ToListAsync();
                    var mapData = _mapper.Map<List<MemberActaulLeaveResponse>>(data);

                    return await Response<List<MemberActaulLeaveResponse>>.SuccessAsync(mapData, "Get all MemberActualLeave.");
                }
                catch (Exception ex)
                {
                    return await Response<List<MemberActaulLeaveResponse>>.FailAsync($"Get all MemberActualLeave > {ex.Message}");
                }
            }
        }
    }
}
