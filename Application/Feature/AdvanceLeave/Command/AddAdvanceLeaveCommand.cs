using Application.Repositery;
using Domain;
using Domain.Enumerable;
using MediatR;
using Presistance.DataBase;
using Share.Wapper;
using System.Linq.Expressions;

namespace Application.Feature
{
    public class AddAdvanceLeaveCommand : EntityCommandHandler<AdvanceLeave>, IRequest<IResponse>
    {
        public Guid LeaveTypeId { get; set; }
        public Guid ReasonCodeId { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }

        public override async Task<AdvanceLeave> VerifyData(IUnitOfWork unitOf, Guid UserId, CancellationToken cancellationToken)
        {
            var expression = unitOf.Repository<AdvanceLeave>().Entities.Any(e => e.UserId == UserId);
            var data = EntityData(unitOf, UserId, cancellationToken).Result!;
            Expression<Func<bool, AdvanceLeave>> func = expression => 
                expression == true ?
                  data : data;
            return await Task.FromResult(data);
        }

        public override async Task<AdvanceLeave?> EntityData(IUnitOfWork unitOf, Guid UserId, CancellationToken cancellationToken)
        {
            var entity = new AdvanceLeave
            {
                Id = Guid.NewGuid(),
                UserId = UserId,
                LeaveTypeId = LeaveTypeId,
                ReasonCodeId = ReasonCodeId,
                FromDate = FromDate,
                ToDate = ToDate,
                TotalLeave = ToDate.Date.Subtract(FromDate.Date).TotalDays,
                Description = Description,
                FeedBacks = FeedBack.Pending,
                CreatedDate = DateTimeOffset.UtcNow
            };
            return await Task.FromResult(entity);
        }

        public override async Task<AdvanceLeave> SavedToDbHandle(IUnitOfWork unitOf, Guid UserId, CancellationToken cancellationToken)
        {
            var entity = VerifyData(unitOf, UserId, cancellationToken).Result;
            try
            {
                await unitOf.Repository<AdvanceLeave>().AddAsync(entity);
                await unitOf.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return await Task.FromResult(entity!);           
        }

        public class Handler : IRequestHandler<AddAdvanceLeaveCommand, IResponse>
        {

            private readonly IUnitOfWork _unit;
            private readonly IUserSerive _userService;
            public Handler(IUnitOfWork unit, IUserSerive userService)
            {
                _unit = unit;
                _userService = userService;
            }
            public async Task<IResponse> Handle(AddAdvanceLeaveCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    await request.SavedToDbHandle(_unit, _userService.UserId, cancellationToken);
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
