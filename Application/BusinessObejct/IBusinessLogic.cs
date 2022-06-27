using Domain;
using Domain.Authentication;
using Domain.Entites;
using Presistance.DataBase;

namespace Application.BusinessObejct
{
    public interface IBusinessLogics
    {
        IDataContext DataContext { get; }
        Codes Code { get; }
        User GetAdminUser();
        Task<User> GetActingUser();
        Task<Period> GetOrCreatePeriodAsync(Guid userId, DateTimeOffset? beginning, DateTimeOffset? ending);
        Task<MemberType> GetActiveMemberTypeAsync(Guid UserId, string code, DateTimeOffset actingDate, CancellationToken cancellationToken = default);
        Task<ReasonCode> GetActiveReasonCodeCoverPeriodAsync(Guid UserId, string code, DateTimeOffset? beginDate, DateTimeOffset? endDate, CancellationToken cancellationToken = default);
        Task<RecordStatusType> GetRecordStatusTypeCoverPeriodAsync(Guid UserId, string code, DateTimeOffset? beginDate, DateTimeOffset? endDate, CancellationToken cancellationToken = default);


        #region IQueryable
        Task<IQueryable<Period>> GetPeriodsQueryableAsync(Guid UserId);
        Task<IQueryable<ReasonCode>> GetActiveReasonCodesQueryableAsync(Guid UserId, DateTimeOffset actingDate);
        Task<IQueryable<Departerment>> GetDepartermentQueryableAsync(DateTimeOffset? actingDate);
        Task<IQueryable<Member>> GetMemberQueryableAsync(DateTimeOffset actingDate);
        //Task<IQueryable<MemberAdvanceLeave>> GetMemberAdvanceLeaveQueryableAsync(DateTimeOffset actingDate);
        Task<IQueryable<Position>> GetActivePositionQueryableAsync(Guid UserId, DateTimeOffset actingDate);
        #endregion


    }
}
