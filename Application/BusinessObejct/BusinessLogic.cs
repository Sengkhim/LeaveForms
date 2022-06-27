using Application.Repositery;
using Domain;
using Domain.Authentication;
using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presistance.DataBase;

namespace Application.BusinessObejct
{
    public class BusinessLogics : IBusinessLogics
    {
        private readonly DataContext _db;
        private User adminUserInDb;
        private readonly UserManager<User> _userMgr;
        private readonly IUserSerive _curUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork unit;
        public BusinessLogics(UserManager<User> userMgr, DataContext dbContext, IUserSerive curUserService
        , IHttpContextAccessor httpContextAccessor, IUnitOfWork unit)
        {
            _db = dbContext;
            _userMgr = userMgr;
            _curUserService = curUserService;
            adminUserInDb = GetAdminUser();
            _httpContextAccessor = httpContextAccessor;
            this.unit = unit;
        }
        public User GetAdminUser()
        {
            var task = _userMgr.FindByNameAsync("admin");
            task.Wait();
            return task.Result;
        }
        public async Task<User> GetActingUser()
        {
            try
            {
                return await _db.Users.Where(e => e.Id == _curUserService.UserId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IDataContext DataContext => _db;

        public Codes Code => new Codes();

        public async Task<Period?> GetOrCreatePeriodAsync(Guid userId, DateTimeOffset? beginning, DateTimeOffset? ending)
        {
            var period = (await _db.Set<Period>().Where(e => e.UserId == userId).ToListAsync())
                            .FirstOrDefault(f => f.UserId == userId && f.IsDatesEquals(beginning, ending));
            if (period == null)
            {
                _db.Set<Period>().Add(period = new Period
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    BeginDate = beginning,
                    EndDate = ending,
                    CreatedDate = DateTimeOffset.UtcNow,
                    CreatedUserId = userId
                });
                await _db.SaveChangesAsync();
            }
            return period;
        }

        public async Task<ReasonCode?> GetActiveReasonCodeCoverPeriodAsync(Guid UserId, string code, DateTimeOffset? beginDate,
            DateTimeOffset? endDate, CancellationToken cancellationToken = default)
        {
            return (await _db.ReasonCode.Include(e => e.ReasonCodeRecord!).ThenInclude(p => p.Period)
                    .Where(u => u.UserId == UserId && u.Code == code).ToListAsync(cancellationToken))
                    .FirstOrDefault(e => e.ReasonCodeRecord!.Any(r => r.Period!.IsCover(beginDate, endDate)));
        }

        public async Task<MemberType?> GetActiveMemberTypeAsync(Guid UserId, string code, DateTimeOffset actingDate, 
            CancellationToken cancellationToken = default)
        {
            return ( await _db.MemberTypes.Include(e => e.MemberTypeRecord!).ThenInclude(p => p.Period!)
                   .Where(w => w.Code == code).ToListAsync(cancellationToken))
                   .FirstOrDefault(f => f.MemberTypeRecord!.Any(p => p.Period!.IsCover(actingDate)));
        }

        public async Task<RecordStatusType> GetRecordStatusTypeCoverPeriodAsync(Guid UserId, string code,
            DateTimeOffset? beginDate, DateTimeOffset? endDate, CancellationToken cancellationToken = default)
        {
            var rstSubs = (await _db.RecordStatusTypeMember.Include(e => e.RecordStatusType).Include(e => e.Period)
                        .Where(e => e.UserId == UserId && e.RecordStatusType!.Code == code)
                        .ToListAsync(cancellationToken)).FirstOrDefault(e => e.Period!.IsCover(beginDate, endDate));
            return rstSubs?.RecordStatusType!;
        }

        public async Task<IQueryable<Period>> GetPeriodsQueryableAsync(Guid UserId)
        {
            var result = DataContext.Period.Where(e => e.UserId == UserId).AsQueryable();
            return await Task.FromResult(result);
        }

        public async Task<IQueryable<ReasonCode>> GetActiveReasonCodesQueryableAsync(Guid UserId, DateTimeOffset actingDate)
        {
            var result = DataContext.ReasonCode
              .Where(e => e.UserId == UserId
                          && e.ReasonCodeRecord!.Any(typeRecord => (typeRecord.Period!.BeginDate == null || typeRecord.Period.BeginDate <= actingDate)
                          && (typeRecord.Period.EndDate == null || actingDate <= typeRecord.Period.EndDate) 
                          && typeRecord.RecordStatusType!.Code == Code.RecordStatusTypeCodes.GetActiveCode()))
              .Include(e => e.ReasonCodeRecord!.Where(typeRecord => (typeRecord.Period!.BeginDate == null || typeRecord.Period.BeginDate <= actingDate)
                          && (typeRecord.Period.EndDate == null || actingDate <= typeRecord.Period.EndDate)
                          && typeRecord.RecordStatusType!.Code == Code.RecordStatusTypeCodes.GetActiveCode()))
              .ThenInclude(e => e.Period).Include(re => re.ReasonCodeRecord!).ThenInclude(b => b.RecordStatusType);
            return await Task.FromResult(result);
        }

        public async Task<IQueryable<Departerment>> GetDepartermentQueryableAsync(DateTimeOffset? actingDate)
        {
            var result = DataContext.Departerment.AsQueryable();
            return await Task.FromResult(result);
        }

        public async Task<IQueryable<Position>> GetActivePositionQueryableAsync(Guid UserId, DateTimeOffset actingDate)
        {
            //var result = DataContext.Position.AsQueryable().Where(e => e.Member!.UserId == UserId);
            return await Task.FromResult(DataContext.Position.AsQueryable());
        }
         
        public async Task<IQueryable<Member>> GetMemberQueryableAsync(DateTimeOffset actingDate)
        {
            var result = _db.Members.ToListAsync();
            var results = DataContext.Members.ToListAsync();
            //Include(x => x.MemberAdvanceLeave)
            return await Task.FromResult(DataContext.Members.AsQueryable());
        }

        //public async Task<IQueryable<MemberAdvanceLeave>> GetMemberAdvanceLeaveQueryableAsync(DateTimeOffset actingDate)
        //{
        //    var ResultQuery = DataContext.MemberAdvanceLeave/*.Include(e => e.AdvanceLeave)*/
        //                            //.Include(m => m.Member)/*.Include(x => x.MemberAdvanceLeaveRecords)*/
        //                                 .AsQueryable();
        //    var ResultQuery1 = DataContext.MemberAdvanceLeave.AsQueryable();
        //    var ResultQuery2 = DataContext.MemberAdvanceLeave.ToList();

        //    Console.WriteLine("");
        //    return await Task.FromResult(ResultQuery);
        //}
    }
}
