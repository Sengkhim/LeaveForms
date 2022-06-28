using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistance.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ActualLeave");

            migrationBuilder.EnsureSchema(
                name: "AdvanceLeave");

            migrationBuilder.EnsureSchema(
                name: "Departerment");

            migrationBuilder.EnsureSchema(
                name: "Leave");

            migrationBuilder.EnsureSchema(
                name: "Member");

            migrationBuilder.EnsureSchema(
                name: "Position");

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
                name: "AdvanceLeaves",
                schema: "AdvanceLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FromDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ToDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Remaining = table.Column<double>(type: "float", nullable: false),
                    FeedBacks = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceLeaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvanceLeaves_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceLeaves_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departerments",
                schema: "Departerment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departerments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departerments_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departerments_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                schema: "Leave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveTypes_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveTypes_Users_ModifiedUserId",
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeginDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Period_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "Position",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Positions_Users_ModifiedUserId",
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
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_ReasonCode_Users_UserId",
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
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "DepartermentMembers",
                schema: "Departerment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartermentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartermentMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartermentMembers_Departerments_DepartermentId",
                        column: x => x.DepartermentId,
                        principalSchema: "Departerment",
                        principalTable: "Departerments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentMembers_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentMembers_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentMembers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                schema: "Leave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalSchema: "Leave",
                        principalTable: "LeaveTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leaves_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leaves_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartermentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Departerments_DepartermentId",
                        column: x => x.DepartermentId,
                        principalSchema: "Departerment",
                        principalTable: "Departerments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Positions_PositonId",
                        column: x => x.PositonId,
                        principalSchema: "Position",
                        principalTable: "Positions",
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
                name: "PositionMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionMember_Positions_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "Position",
                        principalTable: "Positions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionMember_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionMember_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionMember_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActualLeaves",
                schema: "ActualLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Remaining = table.Column<double>(type: "float", nullable: false),
                    FromDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ToDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FeedBacks = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualLeaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualLeaves_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalSchema: "Leave",
                        principalTable: "LeaveTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeaves_ReasonCode_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalTable: "ReasonCode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeaves_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeaves_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: " MemberAdvanceLeave",
                schema: "AdvanceLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvanceLeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ MemberAdvanceLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeave_AdvanceLeaves_AdvanceLeaveId",
                        column: x => x.AdvanceLeaveId,
                        principalSchema: "AdvanceLeave",
                        principalTable: "AdvanceLeaves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeave_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Member",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeave_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeave_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: " MemberActualLeave",
                schema: "ActualLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActualLeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ MemberActualLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ MemberActualLeave_ActualLeaves_ActualLeaveId",
                        column: x => x.ActualLeaveId,
                        principalSchema: "ActualLeave",
                        principalTable: "ActualLeaves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberActualLeave_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberActualLeave_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberActualLeave_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "db",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName", "UserProfile" },
                values: new object[] { new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"), 0, "2708d6d2-9657-423a-bb75-34be3b1e2821", new DateTimeOffset(new DateTime(2022, 6, 28, 23, 16, 47, 175, DateTimeKind.Unspecified).AddTicks(1742), new TimeSpan(0, 7, 0, 0, 0)), "benz@gmail.com", true, "BenZ", "UTC", false, null, null, "BENZ@GMAIL.COM", "BENZ", "AQAAAAEAACcQAAAAEL9cktyP+gHmmzf9H/EDjjVr7yan9Xo8kNhEBsfAC2o4xxxuluEo71+aVTpUB7YG7Q==", "012273893", true, "WPOJONETW3HXSDNK4LQR47BNYJSG7OFG", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "WPOJONETW3HXSDNK4LQR47BNYJSG7OFG", true, false, "BenZ", null });

            migrationBuilder.CreateIndex(
                name: "IX_ MemberActualLeave_ActualLeaveId",
                schema: "ActualLeave",
                table: " MemberActualLeave",
                column: "ActualLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberActualLeave_CreatedUserId",
                schema: "ActualLeave",
                table: " MemberActualLeave",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberActualLeave_ModifiedUserId",
                schema: "ActualLeave",
                table: " MemberActualLeave",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberActualLeave_UserId",
                schema: "ActualLeave",
                table: " MemberActualLeave",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeave_AdvanceLeaveId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave",
                column: "AdvanceLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeave_CreatedUserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeave_MemberId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeave_ModifiedUserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeaves_CreatedUserId",
                schema: "ActualLeave",
                table: "ActualLeaves",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeaves_LeaveTypeId",
                schema: "ActualLeave",
                table: "ActualLeaves",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeaves_ModifiedUserId",
                schema: "ActualLeave",
                table: "ActualLeaves",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeaves_ReasonCodeId",
                schema: "ActualLeave",
                table: "ActualLeaves",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceLeaves_CreatedUserId",
                schema: "AdvanceLeave",
                table: "AdvanceLeaves",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceLeaves_ModifiedUserId",
                schema: "AdvanceLeave",
                table: "AdvanceLeaves",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentMembers_CreatedUserId",
                schema: "Departerment",
                table: "DepartermentMembers",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentMembers_DepartermentId",
                schema: "Departerment",
                table: "DepartermentMembers",
                column: "DepartermentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentMembers_ModifiedUserId",
                schema: "Departerment",
                table: "DepartermentMembers",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentMembers_UserId",
                schema: "Departerment",
                table: "DepartermentMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departerments_Code_Name",
                schema: "Departerment",
                table: "Departerments",
                columns: new[] { "Code", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departerments_CreatedUserId",
                schema: "Departerment",
                table: "Departerments",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departerments_ModifiedUserId",
                schema: "Departerment",
                table: "Departerments",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_Code",
                schema: "Leave",
                table: "Leaves",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_CreatedUserId",
                schema: "Leave",
                table: "Leaves",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_LeaveTypeId",
                schema: "Leave",
                table: "Leaves",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_ModifiedUserId",
                schema: "Leave",
                table: "Leaves",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypes_CreatedUserId",
                schema: "Leave",
                table: "LeaveTypes",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypes_ModifiedUserId",
                schema: "Leave",
                table: "LeaveTypes",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Code",
                schema: "Member",
                table: "Members",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_CreatedUserId",
                schema: "Member",
                table: "Members",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_DepartermentId",
                schema: "Member",
                table: "Members",
                column: "DepartermentId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberId",
                schema: "Member",
                table: "Members",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_ModifiedUserId",
                schema: "Member",
                table: "Members",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PositonId",
                schema: "Member",
                table: "Members",
                column: "PositonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Period_CreatedUserId",
                table: "Period",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Period_ModifiedUserId",
                table: "Period",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Period_UserId",
                table: "Period",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionMember_CreatedUserId",
                table: "PositionMember",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionMember_ModifiedUserId",
                table: "PositionMember",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionMember_PositionId",
                table: "PositionMember",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionMember_UserId",
                table: "PositionMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Code",
                schema: "Position",
                table: "Positions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CreatedUserId",
                schema: "Position",
                table: "Positions",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_ModifiedUserId",
                schema: "Position",
                table: "Positions",
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
                name: "IX_ReasonCode_UserId",
                table: "ReasonCode",
                column: "UserId");

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
                name: " MemberActualLeave",
                schema: "ActualLeave");

            migrationBuilder.DropTable(
                name: " MemberAdvanceLeave",
                schema: "AdvanceLeave");

            migrationBuilder.DropTable(
                name: "DepartermentMembers",
                schema: "Departerment");

            migrationBuilder.DropTable(
                name: "Leaves",
                schema: "Leave");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "PositionMember");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "db");

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
                name: "ActualLeaves",
                schema: "ActualLeave");

            migrationBuilder.DropTable(
                name: "AdvanceLeaves",
                schema: "AdvanceLeave");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "Member");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "db");

            migrationBuilder.DropTable(
                name: "LeaveTypes",
                schema: "Leave");

            migrationBuilder.DropTable(
                name: "ReasonCode");

            migrationBuilder.DropTable(
                name: "Departerments",
                schema: "Departerment");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "Position");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "db");
        }
    }
}
