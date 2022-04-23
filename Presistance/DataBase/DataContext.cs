using Domain.Authentication;
using Domain.Entites;
using Domain.Entites.BaseEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace Presistance.DataBase
{
    public class DataContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IDataContext
    {
        private readonly ICurrentUserService _currentUser;
        public DataContext()
        {
        }

        public DataContext(DbContextOptions options, ICurrentUserService currentUser) : base(options)
        {
            _currentUser = currentUser;
        }

        public IDbConnection Connection => Database.GetDbConnection();
        public DbSet<Student> Students { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4OH8OSU;Initial Catalog=LeaveForms;Persist Security Info=True;User ID=sa;Password=12345");
            }
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            if (builder == null) return;
            //builder.UseCollation("SQL_Latin1_General_CP437_BIN2");
            builder.Entity<User>().ToTable("Users", "db");
            builder.Entity<Role>().ToTable("Roles", "db");
            builder.Entity<UserClaim>().ToTable("UserClaims", "db");
            builder.Entity<UserRole>().ToTable("UserRoles", "db");
            builder.Entity<UserLogin>().ToTable("UserLogins", "db");
            builder.Entity<RoleClaim>().ToTable("RoleClaims", "db");
            builder.Entity<UserToken>().ToTable("UserTokens", "db");
            builder.Entity<User>().HasIndex(x => x.UserName).IsUnique();

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var user =
                await Users.FirstOrDefaultAsync(e => e.Id == _currentUser.UserId, cancellationToken);
            foreach (var entry in ChangeTracker.Entries<Entity<Guid>>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                        entry.Entity.CreatedUserId = _currentUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTimeOffset.UtcNow;
                        entry.Entity.ModifiedUserId = _currentUser.UserId;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            if (user is not null)
                foreach (var entry in ChangeTracker.Entries<IUser>())
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.Id = Users.Select(e => e.Id).FirstOrDefault();
                            break;
                        case EntityState.Modified:
                            break;
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                        case EntityState.Deleted:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

            return await base.SaveChangesAsync(cancellationToken);
        }

       

    }
}
