using Domain;
using Domain.Authentication;
using Domain.Entites;
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

        DbSet<Member> Members { get; set; }
        DbSet<Position> Position { get; set; }
        DbSet<PositionMember> PositionMember { get; set; }
        DbSet<ReasonCode> ReasonCode { get; set; }
        DbSet<Period> Period { get; set; }
        DbSet<Leave> Leave { get; set; }
        DbSet<LeaveType> LeaveType { get; set; }
        DbSet<Departerment> Departerment { get; set; }
        DbSet<DepartermentMember> DepartermentMember { get; set; }
        DbSet<ActualLeave> ActualLeave { get; set; }
        DbSet<MemberActualLeave> MemberActualLeave { get; set; }
        DbSet<AdvanceLeave> AdvanceLeave { get; set; }
        DbSet<MemberAdvanceLeave> TestAdvances { get; set; }
        DbSet<Project> Project { get; set; }
        DbSet<Working> Working { get; set; }
        DbSet<WorkingType> WorkingType { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
    }
}
