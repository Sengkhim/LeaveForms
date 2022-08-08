using Application.Repositery;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Share.Wapper;

namespace Application.Feature
{
    public class GetAllDepartermentQuery  : IRequest<Response<List<DepartmentResponse>>>
    {
        public class Handler : IRequestHandler<GetAllDepartermentQuery, Response<List<DepartmentResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOf;
            public Handler(IMapper mapper, IUnitOfWork unitOf)
            {
                _mapper = mapper;
                _unitOf = unitOf;
            }

            public async Task<Response<List<DepartmentResponse>>> Handle(GetAllDepartermentQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var query = _unitOf.Repository<Department>().GetToQueryable();
                    var data = await query.ToListAsync(cancellationToken);
                    var mapData = _mapper.Map<List<DepartmentResponse>>(data);

                    return await Response<List<DepartmentResponse>>.SuccessAsync(mapData, "Get all Department.");
                }
                catch (Exception ex)
                {
                    return await Response<List<DepartmentResponse>>.FailAsync($"Get all Department > {ex.Message}");
                }
            }
        }
    }
}
