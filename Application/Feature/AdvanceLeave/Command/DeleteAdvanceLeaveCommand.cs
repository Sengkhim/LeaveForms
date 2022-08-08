using Application.Repositery;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presistance.DataBase;
using Share.Wapper;

namespace Application.Feature
{
    public class DeleteAdvanceLeaveCommand : EntityCommandHandler<AdvanceLeave>,IRequest<IResponse>
    {
        public Guid Id { get; set; }

        public override async Task<AdvanceLeave?> EntityData(IUnitOfWork unitOf, Guid UserId, CancellationToken cancellationToken)
        {
            var entity = unitOf.Repository<AdvanceLeave>().Entities.Where(e => e.Id == Id && e.UserId == UserId).FirstOrDefault();
            if (entity == null) throw new QueryException(nameof(Id));
            entity.IsDeleted = true;
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

        public override Task<AdvanceLeave> VerifyData(IUnitOfWork unitOf, Guid UserId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public class Handler : IRequestHandler<DeleteAdvanceLeaveCommand, IResponse>
        {

            private readonly IUnitOfWork _unit;
            private readonly IUserSerive _userService;
            public Handler(IUnitOfWork unit, IUserSerive userService)
            {
                _unit = unit;
                _userService = userService;
            }

            public async Task<IResponse> Handle(DeleteAdvanceLeaveCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    await request.SavedToDbHandle(_unit, _userService.UserId, cancellationToken);
                }
                catch (ApiException e)
                {
                    return (Response)await Response.FailAsync(e.Message);
                }

                return (Response)await Response.SuccessAsync("Object has been delete!");
            }
        }
        
    }
    
}
