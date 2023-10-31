using Domain;
using Domain.Authentication;
using Domain.Entites;
using Domain.Entites.BaseEntity;
using Domain.Entites.Chat;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Presistance.DataBase
{
    public class DataContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IDataContext
    {
        private readonly IUserSerive _currentUser;
        public DataContext() 
        {
        }

        public DataContext(DbContextOptions options, IUserSerive currentUser) : base(options)
        {
            _currentUser = currentUser;
        }
        #region Entity Dbset
        public DbSet<Member> Members { get ; set ; }
        public DbSet<Position> Position { get ; set ; }
        public DbSet<ReasonCode> ReasonCode { get ; set ; }
        public DbSet<Period> Period { get ; set ; }

        public DbSet<LeaveType> LeaveType { get ; set ; }
        public DbSet<Department> Department { get ; set ; }
        public DbSet<ActualLeave> ActualLeave { get ; set ; }
        public DbSet<AdvanceLeave> AdvanceLeave { get ; set ; }
        public DbSet<Project> Project { get ; set ; }
        public DbSet<Working> Working { get ; set ; }
        public DbSet<WorkingType> WorkingType { get ; set ; }
        public DbSet<MemberActualLeave> UserActualLeave { get ; set ; }
        public DbSet<MemberAdvanceLeave> UserAdvanceLeave { get; set; }

        //chatting entity
        public DbSet<Room> Rooms { get ; set ; }
        public DbSet<Message> Messages { get ; set ; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=sqlserver,1433;Database=LeavePlatform;User=sa;Password=password@12345#;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            if (builder == null) return;
            builder.Entity<User>().ToTable("Users", "db")
                   .HasOne(e => e.Member).WithOne(x => x.User).HasForeignKey<Member>(b => b.MemberId);
            builder.Entity<Role>().ToTable("Roles", "db");
            builder.Entity<UserClaim>().ToTable("UserClaims", "db");
            builder.Entity<UserRole>().ToTable("UserRoles", "db");
            builder.Entity<UserLogin>().ToTable("UserLogins", "db");
            builder.Entity<RoleClaim>().ToTable("RoleClaims", "db");
            builder.Entity<UserToken>().ToTable("UserTokens", "db");
            builder.Entity<AdvanceLeave>().ToTable("AdvanceLeave", "db").HasKey(e => e.Id);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var cascade = builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())
             .Where(e => e.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var c in cascade) c.DeleteBehavior = DeleteBehavior.NoAction;
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        
        {
            var entries = ChangeTracker.Entries<Entity<Guid>>().Where(e => e.State == EntityState.Added 
            || e.State == EntityState.Modified || e.State == EntityState.Deleted).ToList();
            if (entries is not null)
            {
                foreach (var entityEntry in entries)
                {
                    switch (entityEntry.State)
                    {
                        case EntityState.Added:
                            entityEntry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                            entityEntry.Entity.CreatedUserId = _currentUser.UserId;
                            break;
                        case EntityState.Modified:
                            entityEntry.Entity.ModifiedDate = DateTimeOffset.UtcNow;
                            entityEntry.Entity.ModifiedUserId = _currentUser.UserId;
                            break;
                        case EntityState.Deleted:
                            entityEntry.Entity.ModifiedDate = DateTimeOffset.UtcNow;
                            entityEntry.Entity.ModifiedUserId = _currentUser.UserId;
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        Task<int> IDataContext.SaveChanges()
        {
            return Task.FromResult(SaveChanges());
        }
    }
}
