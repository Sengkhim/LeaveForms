

using Application.Repositery;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllMemberAdvanceLeaveQuery : IRequest<Response<List<MemberAdvanceLeaveRequestResponse>>>
    {
        public class Handler : IRequestHandler<GetAllMemberAdvanceLeaveQuery, Response<List<MemberAdvanceLeaveRequestResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }
            public async Task<Response<List<MemberAdvanceLeaveRequestResponse>>> Handle(GetAllMemberAdvanceLeaveQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var query = _unitOfWork.Repository<MemberAdvanceLeaveRequest>().GetToQueryable();
                    var data = await query.ToListAsync();
                    var mapData = _mapper.Map<List<MemberAdvanceLeaveRequestResponse>>(data);

                    return await Response<List<MemberAdvanceLeaveRequestResponse>>.SuccessAsync(mapData, "Get all AdvanceLeave.");
                }
                catch (Exception ex)
                {
                    return await Response<List<MemberAdvanceLeaveRequestResponse>>.FailAsync($"Get all AdvanceLeave > {ex.Message}");
                }
            }
        }

    }
}
