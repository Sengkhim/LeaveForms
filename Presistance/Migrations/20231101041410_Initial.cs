using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "db");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "db",
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Department_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeaveType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveType_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveType_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeginDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Period_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Period_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Position_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReasonCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonCode_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReasonCode_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "db",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedByUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "db",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "db",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "db",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedByUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Working",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Working", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Working_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Working_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkingType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingType_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkingType_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartermentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Department_DepartermentId",
                        column: x => x.DepartermentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Position_PositonId",
                        column: x => x.PositonId,
                        principalTable: "Position",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Users_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActualLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalLeave = table.Column<double>(type: "float", nullable: false),
                    FromDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ToDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FeedBacks = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualLeave_LeaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeave_ReasonCode_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalTable: "ReasonCode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeave_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeave_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeave_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdvanceLeave",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ToDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TotalLeave = table.Column<double>(type: "float", nullable: false),
                    FeedBacks = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvanceLeave_LeaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceLeave_ReasonCode_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalTable: "ReasonCode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceLeave_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceLeave_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceLeave_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FromUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToRoomId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Rooms_ToRoomId",
                        column: x => x.ToRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserActualLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActualLeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActualLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActualLeave_ActualLeave_ActualLeaveId",
                        column: x => x.ActualLeaveId,
                        principalTable: "ActualLeave",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserActualLeave_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserActualLeave_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserActualLeave_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAdvanceLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvanceLeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdvanceLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdvanceLeave_AdvanceLeave_AdvanceLeaveId",
                        column: x => x.AdvanceLeaveId,
                        principalSchema: "db",
                        principalTable: "AdvanceLeave",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAdvanceLeave_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAdvanceLeave_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAdvanceLeave_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeave_CreatedUserId",
                table: "ActualLeave",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeave_LeaveTypeId",
                table: "ActualLeave",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeave_ModifiedUserId",
                table: "ActualLeave",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeave_ReasonCodeId",
                table: "ActualLeave",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeave_UserId",
                table: "ActualLeave",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceLeave_CreatedUserId",
                schema: "db",
                table: "AdvanceLeave",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceLeave_LeaveTypeId",
                schema: "db",
                table: "AdvanceLeave",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceLeave_ModifiedUserId",
                schema: "db",
                table: "AdvanceLeave",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceLeave_ReasonCodeId",
                schema: "db",
                table: "AdvanceLeave",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceLeave_UserId",
                schema: "db",
                table: "AdvanceLeave",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_CreatedUserId",
                table: "Department",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ModifiedUserId",
                table: "Department",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveType_CreatedUserId",
                table: "LeaveType",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveType_ModifiedUserId",
                table: "LeaveType",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_CreatedUserId",
                table: "Members",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_DepartermentId",
                table: "Members",
                column: "DepartermentId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberId",
                table: "Members",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_ModifiedUserId",
                table: "Members",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PositonId",
                table: "Members",
                column: "PositonId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToRoomId",
                table: "Messages",
                column: "ToRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Period_CreatedUserId",
                table: "Period",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Period_ModifiedUserId",
                table: "Period",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_CreatedUserId",
                table: "Position",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_ModifiedUserId",
                table: "Position",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedUserId",
                table: "Project",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ModifiedUserId",
                table: "Project",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonCode_CreatedUserId",
                table: "ReasonCode",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonCode_ModifiedUserId",
                table: "ReasonCode",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "db",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "db",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActualLeave_ActualLeaveId",
                table: "UserActualLeave",
                column: "ActualLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActualLeave_CreatedUserId",
                table: "UserActualLeave",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActualLeave_MemberId",
                table: "UserActualLeave",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActualLeave_ModifiedUserId",
                table: "UserActualLeave",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvanceLeave_AdvanceLeaveId",
                table: "UserAdvanceLeave",
                column: "AdvanceLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvanceLeave_CreatedUserId",
                table: "UserAdvanceLeave",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvanceLeave_MemberId",
                table: "UserAdvanceLeave",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvanceLeave_ModifiedUserId",
                table: "UserAdvanceLeave",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "db",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "db",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "db",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "db",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "db",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Working_CreatedUserId",
                table: "Working",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Working_ModifiedUserId",
                table: "Working",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingType_CreatedUserId",
                table: "WorkingType",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingType_ModifiedUserId",
                table: "WorkingType",
                column: "ModifiedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "db");

            migrationBuilder.DropTable(
                name: "UserActualLeave");

            migrationBuilder.DropTable(
                name: "UserAdvanceLeave");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "db");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "db");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "db");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "db");

            migrationBuilder.DropTable(
                name: "Working");

            migrationBuilder.DropTable(
                name: "WorkingType");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "ActualLeave");

            migrationBuilder.DropTable(
                name: "AdvanceLeave",
                schema: "db");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "db");

            migrationBuilder.DropTable(
                name: "LeaveType");

            migrationBuilder.DropTable(
                name: "ReasonCode");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "db");
        }
    }
}
