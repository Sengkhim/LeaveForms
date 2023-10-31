
using Application.Repositery;
using Domain;
using Domain.Enumerable;
using MediatR;
using Microsoft.AspNetCore.Http;
using Share.Wapper;
using System.Security.Claims;

namespace Application.Feature
{
    public class AddActualLeaveCommand : IRequest<IResponse>
    {
        public Guid LeaveTypeId { get; set; }
        public Guid ReasonCodeId { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public FeedBack? FeedBacks { get; set; } = FeedBack.Pending;

        public class Handler : IRequestHandler<AddActualLeaveCommand, IResponse>
        {
            private readonly IUnitOfWork _unit;
            private readonly IHttpContextAccessor _httpContext;

            public Handler(IUnitOfWork unit, IHttpContextAccessor httpContext)
            {
                _unit = unit;
                _httpContext = httpContext;
            }

            public async Task<IResponse> Handle(AddActualLeaveCommand request, CancellationToken cancellationToken)
            {

                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                var userId = _httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                var entity = new ActualLeave
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.Parse(userId!),
                    LeaveTypeId = request.LeaveTypeId,
                    ReasonCodeId = request.ReasonCodeId,
                    FromDate = request.FromDate,
                    ToDate = request.ToDate,
                    Description = request.Description,
                    FeedBacks = request.FeedBacks,
                };
                try
                {
                    await _unit.Repository<ActualLeave>().AddAsync(entity);
                    await _unit.CommitAsync(cancellationToken);
                }
                catch (ApiException e)
                {
                    return (Response)await Response.FailAsync(e.Message);
                }

                return (Response)await Response.SuccessAsync("Object has been added!");
            }
        }
    }
}
