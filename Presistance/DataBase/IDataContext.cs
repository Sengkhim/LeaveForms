using Domain.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Presistance.DataBase
{
    public interface IDataContext
    {
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
    }
}
