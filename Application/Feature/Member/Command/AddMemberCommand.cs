
//using Application.BusinessObejct;
//using Domain;
//using MediatR;
//using Share.Wapper;

//namespace Application.Feature
//{
//    public class AddMemberCommand : EntityCommandAdd, IRequest<IResponse>
//    {
//        public Guid DepartermentId { get; set; }
//        public Guid PositonId { get; set; }
//        public string? Code { get; set; }
//        public string? Name { get; set; }
//        public async Task<Member>? ToMemberAsync(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, bool recordIncluded = false)
//        {

//            var entity = new Member
//            {
//                Id = Guid.NewGuid(),
//                MemberId = userId,
//                DepartermentId = DepartermentId,
//                PositonId = PositonId,
//                CreatedDate = DateTimeOffset.UtcNow,
//                CreatedUserId = userId,
//                Code = Code,
//                Description = Description,
//            };
//            return entity;
//        }
//        public override async Task<Guid> AddToDbHandle(IBusinessLogics logics, Guid userId, DateTimeOffset actingDate, bool isSaved = true)
//        {
//            try
//            {
//                var entity = await ToMemberAsync(logics, userId, DateTimeOffset.UtcNow);
//                logics.DataContext.Members.Add(entity);
//                if (isSaved) await logics.DataContext.SaveChangesAsync();
//                return entity.Id;
//            }
//            catch (Exception ex)
//            {
//                throw new CommandException(ex.Message);
//            }
//        }

//        public class Handler : IRequestHandler<AddMemberCommand, IResponse>
//        {

//            private readonly IBusinessLogics _logics;

//            public Handler(IBusinessLogics logics)
//            {
//                _logics = logics;
//            }

//            public async Task<IResponse> Handle(AddMemberCommand request, CancellationToken cancellationToken)
//            {
//                var prefixMsg = "Adding member";
//                if (request is null) return await Response<Guid>.FailAsync("Request object can not null!");
//                if (request != null) return await AddToDbHandle(request!, cancellationToken);
//                return await Response<Guid>.SuccessAsync(
//                  $"{prefixMsg} successfully saved.");
//            }
//            protected virtual async Task<IResponse> AddToDbHandle(AddMemberCommand request, CancellationToken cancellationToken)
//            {
//                var prefixMsg = "Adding member";
//                var actingDate = DateTimeOffset.UtcNow;
//                var actingUser = await _logics.GetActingUser();
//                if (actingUser == null)
//                    return await Response<Guid>.FailAsync($"{prefixMsg} > A user to perform the action was not found.");
//                try
//                {
//                    await request.AddToDbHandle(_logics, actingUser.Id, actingDate, false);
//                    await _logics.DataContext.SaveChangesAsync(cancellationToken);
//                    return await Response<Guid>.SuccessAsync(
//                        $"{prefixMsg} > were successfully saved.");
//                }

//                catch (CommandException ex)
//                {
//                    return await Response<Guid>.FailAsync($"{prefixMsg} > {ex.Message}");
//                }
//                catch (Exception ex)
//                {
//                    return await Response<Guid>.FailAsync(
//                        $"{prefixMsg} > Failed in saving new member > {ex.Message}");
//                }
//            }
//        }
//    }
//}
