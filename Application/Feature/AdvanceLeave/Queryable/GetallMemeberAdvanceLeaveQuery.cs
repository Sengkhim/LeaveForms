using Application.Repositery;
using AutoMapper;
using Domain;
using Domain.Entites;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetallMemeberAdvanceLeaveQuery : IRequest<Response<List<MemberAdvanceLeaveResponse>>>
    {
        public class Handler : IRequestHandler<GetallMemeberAdvanceLeaveQuery, Response<List<MemberAdvanceLeaveResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }
            public async Task<Response<List<MemberAdvanceLeaveResponse>>> Handle(GetallMemeberAdvanceLeaveQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var query = _unitOfWork.Repository<MemberAdvanceLeave>().GetToQueryable();
                    var include = query.Include(e => e.AdvanceLeave).Include(m => m.Member)
                                       .ThenInclude(e => e.User).Include(m => m.Member)
                                       .ThenInclude(p => p.Position).Include(m => m.Member)
                                       .ThenInclude(d => d.Departerment).AsQueryable();
                     
                    var data = await include.ToListAsync();
                    var mapData = _mapper.Map<List<MemberAdvanceLeaveResponse>>(data);

                    return await Response<List<MemberAdvanceLeaveResponse>>.SuccessAsync(mapData, "Get all MemberAdvanceLeave.");
                }
                catch (Exception ex)
                {
                    return await Response<List<MemberAdvanceLeaveResponse>>.FailAsync($"Get all MemberAdvanceLeave > {ex.Message}");
                }
            }
        }

    }
}
