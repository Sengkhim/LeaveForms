
using Application.BusinessObejct;
using Application.Feature;
using Domain;
using MediatR;
using Share.Wapper;

namespace Application
{
    public class AddMemberTypeCommand : EntityCommandAdd, IRequest<IResponse>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public ICollection<AddMemberTypeRecordCommand>? MemberTypeRecord { get; set; }


        public async Task<MemberType> ToMemberType(IBusinessLogics logics,Guid UserId, DateTimeOffset actingDate, bool recordInclude = false)
        {
            //var MemberType = await logics.GetActiveMemberTypeAsync(UserId, Code, actingDate);
            //if (MemberType == null)
            //    throw new CommandException(
            //        $"Cannot get a active member type with the code {Code} in the period on the date {actingDate}");
           
            var entity = new MemberType
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedUserId = UserId,
                Code = Code,
                Name = Name,
                Description = Description,
            };
            if (MemberTypeRecord != null)
            {
                entity.MemberTypeRecord = new List<MemberTypeRecord>();
                foreach (var recordCmd in MemberTypeRecord)
                {
                    var record = await recordCmd.ToMemberTypeRecordAsync(logics, UserId, actingDate, entity.Id);
                }
            }
            return entity;
        }

        public override async Task<Guid> AddToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, bool isSaved = true)
        {
            try
            {
                var entity = await ToMemberType(logics, userId, actingDate);
                logics.DataContext.MemberTypes.Add(entity);
                if (isSaved) await logics.DataContext.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new CommandException(0, ex.Message);
            }
        }

        public class Handler : IRequestHandler<AddMemberTypeCommand, IResponse>
        {
            private readonly IBusinessLogics _logics;

            public Handler(IBusinessLogics logics)
            {
                _logics = logics;
            }

            public async Task<IResponse> Handle(AddMemberTypeCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding member type";
                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
                if (request is null) return await AddToDbHandle(request, cancellationToken);
                return await Response<Guid>.SuccessAsync(
                  $"{prefixMsg} successfully saved.");
            }
            protected virtual async Task<IResponse> AddToDbHandle(AddMemberTypeCommand request, CancellationToken cancellationToken)
            {
                var prefixMsg = "Adding member type";
                var actingDate = DateTimeOffset.UtcNow;
                var actingUser = await _logics.GetActingUser();
                if (actingUser == null)
                    return await Response<Guid>.FailAsync($"{prefixMsg} > A user to perform the action was not found.");
                if (request.MemberTypeRecord == null || request.MemberTypeRecord.Count == 0)
                    return await Response<Guid>.FailAsync(
                        $"{prefixMsg} > Member type to be added required at least a record.");
                //await using var transaction = _logics.DataContext.Database.BeginTransaction();
                try
                {
                    var memberTypeId = await request.AddToDbHandle(_logics, actingUser.Id, actingDate, false);//Handle Adding to Member Type
                    
                    //Handle adding to Member Type Record
                    if(request.MemberTypeRecord is {Count:> 0 })
                    {
                        foreach (var recordCmd in request.MemberTypeRecord)
                        {
                            await recordCmd.AddToDbHandle(_logics, actingUser.Id, actingDate,memberTypeId, false);
                        }
                    }
                    await _logics.DataContext.SaveChangesAsync(cancellationToken);
                    //await _logics.Unit.CommitAsync(cancellationToken);
                    return await Response<Guid>.SuccessAsync(
                        $"{prefixMsg} > A member types, and records were successfully saved.");
                }

                catch (CommandException ex)
                {
                    //transaction.Rollback();
                    return await Response<Guid>.FailAsync($"{prefixMsg} > {ex.Message}");
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    return await Response<Guid>.FailAsync(
                        $"{prefixMsg} > Failed in saving new member, records. > {ex.Message}");
                }            
            }
        }
    }
}
