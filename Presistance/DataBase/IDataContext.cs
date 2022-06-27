using Domain;
using Domain.Authentication;
using Domain.Entites;
using Domain.Entites.Company;
using Domain.Entites.Postition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Presistance.DataBase
{
    public interface IDataContext
    {
        DatabaseFacade Database { get; }
        #region Identity

        /// <summary>
        ///     Gets/sets the users set.
        /// </summary>
        DbSet<User> Users { get; set; }

        /// <summary>
        ///     Gets/sets the roles set.
        /// </summary>
        DbSet<Role> Roles { get; set; }

        /// <summary>
        ///     Gets/sets the user claims set.
        /// </summary>
        DbSet<UserClaim> UserClaims { get; set; }

        /// <summary>
        ///     Gets/sets the user roles set.
        /// </summary>
        DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        ///     Gets/sets the user roles set.
        /// </summary>
        DbSet<UserLogin> UserLogins { get; set; }

        /// <summary>
        ///     Gets/sets the roles claims set.
        /// </summary>
        DbSet<RoleClaim> RoleClaims { get; set; }

        /// <summary>
        ///     Gets/sets the user tokes set.
        /// </summary>
        DbSet<UserToken> UserTokens { get; set; }

        /// <summary>
        ///     Saves the changes made to the context.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        ///     Saves the changes made to the context.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        #endregion

        #region Member
        DbSet<Member> Members { get; set; }
        DbSet<MemberRecord> MembersRecord { get; set; }
        DbSet<MemberType> MemberTypes { get; set; }
        DbSet<MemberTypeRecord> MemberTypesRecord { get; set; }

        #endregion

        #region Position
        DbSet<Position> Position { get; set; }
        DbSet<PositionRecord> PositionRecord { get; set; }
        DbSet<PositionMember> PositionMember { get; set; }
        DbSet<PositionMemberRecord> PositionMemberRecord { get; set; }
        #endregion

        DbSet<ReasonCode> ReasonCode { get; set; }
        DbSet<ReasonCodeRecord> ReasonCodeRecord { get; set; }
        DbSet<Period> Period { get; set; }

        #region Leave
        DbSet<Leave> Leave { get; set; }
        DbSet<LeaveRecord> LeaveRecord { get; set; }
        DbSet<LeaveType> LeaveType { get; set; }
        DbSet<LeaveTypeRecord> LeaveTypeRecord { get; set; }
        #endregion

        #region Departerment
        DbSet<Departerment> Departerment { get; set; }
        DbSet<DepartermentRecord> DepartermentRecord { get; set; }
        DbSet<DepartermentMember> DepartermentMember { get; set; }
        DbSet<DepartermentMemberRecord> DepartermentMemberRecord { get; set; }
        #endregion

        #region Company
        DbSet<Company> Company { get; set; }
        DbSet<CompanyRecord> CompanyRecord { get; set; }
        DbSet<Branch> Branche { get; set; }
        DbSet<BranchRecord> BranchRecord { get; set; }
        DbSet<CompanyDeparterment> CompanyDeparterment { get; set; }
        DbSet<CompanyDepartermentRecord> CompanyDepartermentRecord { get; set; }
        DbSet<CompanyDetail> CompanyDetail { get; set; }
        DbSet<CompanyMember> CompanyMember { get; set; }
        DbSet<CompanyMemberRecord> CompanyMemberRecord { get; set; }
        DbSet<CompanyPosition> CompanyPosition { get; set; }
        DbSet<CompanyPositionRecord> CompanyPositionRecord { get; set; }
        DbSet<Contact> Contact { get; set; }
        DbSet<ContactRecord> ContactRecord { get; set; }
        DbSet<Region> Region { get; set; }
        DbSet<RegionRecord> RegionRecord { get; set; }
        #endregion

        #region Leave Apply
        DbSet<ActualLeave> ActualLeave { get; set; }
        DbSet<ActualLeaveRecord> ActualLeaveRecord { get; set; }
        DbSet<MemberActualLeave> MemberActualLeave { get; set; }
        DbSet<MemberActualLeaveRecord> MemberActualLeaveRecord { get; set; }
        DbSet<AdvanceLeave> AdvanceLeave { get; set; }
        DbSet<AdvanceLeaveRecord> AdvanceLeaveRecord { get; set; }
        //DbSet<MemberAdvanceLeave> MemberAdvanceLeave { get; set; }
        DbSet<MemberAdvanceLeaveRecord> MemberAdvanceLeaveRecord { get; set; }
        DbSet<RecordStatusType> RecordStatusType { get; set; }
        DbSet<RecordStatusTypeMember> RecordStatusTypeMember { get; set; }
        DbSet<MemberAdvanceLeaveRequest> MemberAdvanceLeaveRequests { get; set; }
        #endregion

        #region Project
        DbSet<Project> Project { get; set; }
        DbSet<ProjectRecord> ProjectRecord { get; set; }
        DbSet<Working> Working { get; set; }
        DbSet<WorkingType> WorkingType { get; set; }
        DbSet<WorkingRecord> WorkingRecord { get; set; }
        DbSet<WorkingTypeRecord> WorkingTypeRecord { get; set; }
        #endregion

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
    }
}
