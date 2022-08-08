using Application.Repositery;
using Domain;
using Domain.Enumerable;
using MediatR;
using Presistance.DataBase;
using Share.Wapper;
using System.Linq.Expressions;

namespace Application.Feature
{
    public class UpdateAdvanceLeaveCommand : EntityCommandHandler<AdvanceLeave>, IRequest<IResponse>
    {
        public Guid Id { get; set; }
        public Guid LeaveTypeId { get; set; }
        public Guid ReasonCodeId { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }

        public override async Task<AdvanceLeave?> EntityData(IUnitOfWork unitOf, Guid UserId, CancellationToken cancellationToken)
        {
            var entity = unitOf.Repository<AdvanceLeave>().Entities.Where(e => e.Id == Id && e.UserId == UserId).FirstOrDefault();
            if (entity == null) throw new QueryException(nameof(Id));

            entity.LeaveTypeId = LeaveTypeId;
            entity.ReasonCodeId = ReasonCodeId;
            entity.FromDate = FromDate;
            entity.ToDate = ToDate;
            entity.TotalLeave = ToDate.Date.Subtract(FromDate.Date).TotalDays;
            entity.Description = Description;
            entity.FeedBacks = FeedBack.Pending;

            return await Task.FromResult(entity);
        }

        public override async Task<AdvanceLeave> SavedToDbHandle(IUnitOfWork unitOf, Guid UserId, CancellationToken cancellationToken)
        {

            var entity = EntityData(unitOf, UserId, cancellationToken).Result;
            try
            {
                await unitOf.Repository<AdvanceLeave>().UpdateAsync(entity!);
                await unitOf.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return await Task.FromResult(entity!);
        }

        public override  Task<AdvanceLeave> VerifyData(IUnitOfWork unitOf, Guid UserId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public class Handler : IRequestHandler<UpdateAdvanceLeaveCommand, IResponse>
        {

            private readonly IUnitOfWork _unit;
            private readonly IUserSerive _userService;
            public Handler(IUnitOfWork unit, IUserSerive userService)
            {
                _unit = unit;
                _userService = userService;
            }

            public async Task<IResponse> Handle(UpdateAdvanceLeaveCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    await request.SavedToDbHandle(_unit, _userService.UserId, cancellationToken);
                }
                catch (ApiException e)
                {
                    return (Response)await Response.FailAsync(e.Message);
                }

                return (Response)await Response.SuccessAsync("Object has been update!");
            }
        }
    }
}
