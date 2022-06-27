using Application.Repositery;
using Domain;
using Domain.Enumerable;
using MediatR;
using Share.Wapper;

namespace Application.Feature
{
    public class AddAdvanceLeaveCommand : IRequest<IResponse>
    {
        public Guid LeaveTypeId { get; set; }
        public Guid ReasonCodeId { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public double Remaining { get; set; }
        public FeedBack? FeedBacks { get; set; } = FeedBack.Pending;
        public class Handler : IRequestHandler<AddAdvanceLeaveCommand, IResponse>
        {

            private readonly IUnitOfWork _unit;

            public Handler(IUnitOfWork unit)
            {
                _unit = unit;
            }

            public async Task<IResponse> Handle(AddAdvanceLeaveCommand request, CancellationToken cancellationToken)
            {

                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                var entity = new AdvanceLeave
                {
                    Id = Guid.NewGuid(),
                    LeaveTypeId = request.LeaveTypeId,
                    ReasonCodeId = request.ReasonCodeId,
                    FromDate = request.FromDate,
                    ToDate = request.ToDate,
                    Description = request.Description,
                    Remaining = request.Remaining,
                    FeedBacks = request.FeedBacks,
                };
                try
                {
                    await _unit.Repository<AdvanceLeave>().AddAsync(entity);
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
