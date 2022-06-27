using Domain;
using Domain.Authentication;
using Domain.Entites;
using Domain.Entites.BaseEntity;
using Domain.Entites.Company;
using Domain.Entites.Postition;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
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
        public IDbConnection Connection => Database.GetDbConnection();
        public DbSet<Member> Members { get ; set ; }
        public DbSet<MemberRecord> MembersRecord { get ; set ; }
        public DbSet<MemberType> MemberTypes { get ; set ; }
        public DbSet<MemberTypeRecord> MemberTypesRecord { get ; set ; }
        public DbSet<Position> Position { get ; set ; }
        public DbSet<PositionRecord> PositionRecord { get ; set ; }
        public DbSet<PositionMember> PositionMember { get ; set ; }
        public DbSet<PositionMemberRecord> PositionMemberRecord { get ; set ; }
        public DbSet<ReasonCode> ReasonCode { get ; set ; }
        public DbSet<ReasonCodeRecord> ReasonCodeRecord { get ; set ; }
        public DbSet<Period> Period { get ; set ; }
        public DbSet<Leave> Leave { get ; set ; }
        public DbSet<LeaveRecord> LeaveRecord { get ; set ; }
        public DbSet<LeaveType> LeaveType { get ; set ; }
        public DbSet<LeaveTypeRecord> LeaveTypeRecord { get ; set ; }
        public DbSet<Departerment> Departerment { get ; set ; }
        public DbSet<DepartermentRecord> DepartermentRecord { get ; set ; }
        public DbSet<DepartermentMember> DepartermentMember { get ; set ; }
        public DbSet<DepartermentMemberRecord> DepartermentMemberRecord { get ; set ; }
        public DbSet<Company> Company { get ; set ; }
        public DbSet<CompanyRecord> CompanyRecord { get ; set ; }
        public DbSet<Branch> Branche { get ; set ; }
        public DbSet<BranchRecord> BranchRecord { get ; set ; }
        public DbSet<CompanyDeparterment> CompanyDeparterment { get ; set ; }
        public DbSet<CompanyDepartermentRecord> CompanyDepartermentRecord { get ; set ; }
        public DbSet<CompanyDetail> CompanyDetail { get ; set ; }
        public DbSet<CompanyMember> CompanyMember { get ; set ; }
        public DbSet<CompanyMemberRecord> CompanyMemberRecord { get ; set ; }
        public DbSet<CompanyPosition> CompanyPosition { get ; set ; }
        public DbSet<CompanyPositionRecord> CompanyPositionRecord { get ; set ; }
        public DbSet<Contact> Contact { get ; set ; }
        public DbSet<ContactRecord> ContactRecord { get ; set ; }
        public DbSet<Region> Region { get ; set ; }
        public DbSet<RegionRecord> RegionRecord { get ; set ; }
        public DbSet<ActualLeave> ActualLeave { get ; set ; }
        public DbSet<AdvanceLeave> AdvanceLeave { get ; set ; }
        public DbSet<RecordStatusType> RecordStatusType { get ; set ; }
        public DbSet<RecordStatusTypeMember> RecordStatusTypeMember { get ; set ; }
        public DbSet<Project> Project { get ; set ; }
        public DbSet<ProjectRecord> ProjectRecord { get ; set ; }
        public DbSet<Working> Working { get ; set ; }
        public DbSet<WorkingType> WorkingType { get ; set ; }
        public DbSet<WorkingRecord> WorkingRecord { get ; set ; }
        public DbSet<WorkingTypeRecord> WorkingTypeRecord { get ; set ; }
        public DbSet<ActualLeaveRecord> ActualLeaveRecord { get ; set ; }
        public DbSet<MemberActualLeave> MemberActualLeave { get ; set ; }
        public DbSet<MemberActualLeaveRecord> MemberActualLeaveRecord { get ; set ; }
        public DbSet<AdvanceLeaveRecord> AdvanceLeaveRecord { get ; set ; }
        public DbSet<MemberAdvanceLeaveRecord> MemberAdvanceLeaveRecord { get ; set ; }
        public DbSet<MemberAdvanceLeaveRequest> MemberAdvanceLeaveRequests { get ; set ; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4OH8OSU;Initial Catalog=LeaveForms;Persist Security Info=True;User ID=sa;Password=12345");
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
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var cascade = builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())
             .Where(e => e.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var c in cascade) c.DeleteBehavior = DeleteBehavior.NoAction;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        
        {
            var entries = ChangeTracker.Entries<Entity<Guid>>().Where(e => e.State == EntityState.Added 
            || e.State == EntityState.Modified).ToList();
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
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
