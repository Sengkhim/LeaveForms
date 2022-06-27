using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistance.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AdvanceLeave");

            migrationBuilder.EnsureSchema(
                name: "ActualLeave");

            migrationBuilder.EnsureSchema(
                name: "RecordStatusType");

            migrationBuilder.EnsureSchema(
                name: "Branch");

            migrationBuilder.EnsureSchema(
                name: "Company");

            migrationBuilder.EnsureSchema(
                name: "Contact");

            migrationBuilder.EnsureSchema(
                name: "Departerment");

            migrationBuilder.EnsureSchema(
                name: "LeaveRecord");

            migrationBuilder.EnsureSchema(
                name: "Leave");

            migrationBuilder.EnsureSchema(
                name: "Member");

            migrationBuilder.EnsureSchema(
                name: "Position");

            migrationBuilder.EnsureSchema(
                name: "ReasonCode");

            migrationBuilder.EnsureSchema(
                name: "Region");

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
                name: "Companys",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CommpanyType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companys_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companys_Users_ModifiedUserId",
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
                name: "MemberTypes",
                schema: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberTypes_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemberTypes_Users_ModifiedUserId",
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
                name: "ProjectRecord",
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
                    table.PrimaryKey("PK_ProjectRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectRecord_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectRecord_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReasonCodes",
                schema: "ReasonCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonCodes_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReasonCodes_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReasonCodes_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecordStatusTypes",
                schema: "RecordStatusType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordStatusTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordStatusTypes_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecordStatusTypes_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
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
                name: "WorkingRecord",
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
                    table.PrimaryKey("PK_WorkingRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingRecord_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkingRecord_Users_ModifiedUserId",
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
                name: "WorkingTypeRecord",
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
                    table.PrimaryKey("PK_WorkingTypeRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingTypeRecord_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkingTypeRecord_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyDetails_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Company",
                        principalTable: "Companys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyDetails_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyDetails_Users_ModifiedUserId",
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartermentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_Members_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Users_UserId",
                        column: x => x.UserId,
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
                        name: "FK_ActualLeaves_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
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
                name: "AdvanceLeaves",
                schema: "AdvanceLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_AdvanceLeaves_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalSchema: "Leave",
                        principalTable: "LeaveTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceLeaves_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
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
                name: " RecordStatusTypeMember",
                schema: "RecordStatusType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ RecordStatusTypeMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ RecordStatusTypeMember_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ RecordStatusTypeMember_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ RecordStatusTypeMember_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ RecordStatusTypeMember_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ RecordStatusTypeMember_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyRecords",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyRecords_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Company",
                        principalTable: "Companys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyRecords_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartermentRecords",
                schema: "Departerment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasoncodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartermentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartermentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartermentRecords_Departerments_DepartermentId",
                        column: x => x.DepartermentId,
                        principalSchema: "Departerment",
                        principalTable: "Departerments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentRecords_ReasonCodes_ReasoncodeId",
                        column: x => x.ReasoncodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypeRecords",
                schema: "Leave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveTypeRecords_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalSchema: "Leave",
                        principalTable: "LeaveTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveTypeRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveTypeRecords_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveTypeRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveTypeRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveTypeRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MemberTypeRecords",
                schema: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MemberTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTypeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberTypeRecords_MemberTypes_MemberTypeId",
                        column: x => x.MemberTypeId,
                        principalSchema: "Member",
                        principalTable: "MemberTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemberTypeRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemberTypeRecords_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemberTypeRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemberTypeRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemberTypeRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PositionRecords",
                schema: "Position",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionRecords_Positions_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "Position",
                        principalTable: "Positions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionRecords_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReasonCodeRecords",
                schema: "ReasonCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonCodeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonCodeRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReasonCodeRecords_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReasonCodeRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReasonCodeRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReasonCodeRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Branchs",
                schema: "Branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branchs_CompanyDetails_CompanyDetailId",
                        column: x => x.CompanyDetailId,
                        principalSchema: "Company",
                        principalTable: "CompanyDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Branchs_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Branchs_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyDeparterments",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartermentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDeparterments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyDeparterments_CompanyDetails_CompanyDetailId",
                        column: x => x.CompanyDetailId,
                        principalSchema: "Company",
                        principalTable: "CompanyDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyDeparterments_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyDeparterments_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyMembers",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyMembers_CompanyDetails_CompanyDetailId",
                        column: x => x.CompanyDetailId,
                        principalSchema: "Company",
                        principalTable: "CompanyDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyMembers_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyMembers_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyMembers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyPositions",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_CompanyPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyPositions_CompanyDetails_CompanyDetailId",
                        column: x => x.CompanyDetailId,
                        principalSchema: "Company",
                        principalTable: "CompanyDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyPositions_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyPositions_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Contacts = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_CompanyDetails_CompanyDetailId",
                        column: x => x.CompanyDetailId,
                        principalSchema: "Company",
                        principalTable: "CompanyDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "Region",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_CompanyDetails_CompanyDetailId",
                        column: x => x.CompanyDetailId,
                        principalSchema: "Company",
                        principalTable: "CompanyDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Regions_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Regions_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartermentMemberRecords",
                schema: "Departerment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartermentMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartermentMemberRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartermentMemberRecords_DepartermentMembers_DepartermentMemberId",
                        column: x => x.DepartermentMemberId,
                        principalSchema: "Departerment",
                        principalTable: "DepartermentMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentMemberRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentMemberRecords_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentMemberRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentMemberRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartermentMemberRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Leave",
                schema: "LeaveRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leave_Leaves_LeaveId",
                        column: x => x.LeaveId,
                        principalSchema: "Leave",
                        principalTable: "Leaves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leave_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leave_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leave_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leave_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leave_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MemberRecords",
                schema: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberRecords_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Member",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemberRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemberRecords_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemberRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemberRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemberRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PositionMemberRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasconCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionMemberRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionMemberRecord_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionMemberRecord_PositionMember_PositionMemberId",
                        column: x => x.PositionMemberId,
                        principalTable: "PositionMember",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionMemberRecord_ReasonCodes_ReasconCodeId",
                        column: x => x.ReasconCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionMemberRecord_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionMemberRecord_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionMemberRecord_Users_ModifiedUserId",
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
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_ MemberActualLeave_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Member",
                        principalTable: "Members",
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

            migrationBuilder.CreateTable(
                name: "ActualLeaveRecord",
                schema: "ActualLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActualLeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualLeaveRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualLeaveRecord_ActualLeaves_ActualLeaveId",
                        column: x => x.ActualLeaveId,
                        principalSchema: "ActualLeave",
                        principalTable: "ActualLeaves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeaveRecord_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeaveRecord_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeaveRecord_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeaveRecord_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActualLeaveRecord_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: " AdvanceLeaveRecord",
                schema: "AdvanceLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvanceLeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ AdvanceLeaveRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ AdvanceLeaveRecord_AdvanceLeaves_AdvanceLeaveId",
                        column: x => x.AdvanceLeaveId,
                        principalSchema: "AdvanceLeave",
                        principalTable: "AdvanceLeaves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ AdvanceLeaveRecord_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ AdvanceLeaveRecord_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ AdvanceLeaveRecord_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ AdvanceLeaveRecord_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ AdvanceLeaveRecord_Users_ModifiedUserId",
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvanceLeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeave_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BranchRecords",
                schema: "Branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchRecords_Branchs_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Branch",
                        principalTable: "Branchs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchRecords_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyDepartermentRecords",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyDepartermentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDepartermentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyDepartermentRecords_CompanyDeparterments_CompanyDepartermentId",
                        column: x => x.CompanyDepartermentId,
                        principalSchema: "Company",
                        principalTable: "CompanyDeparterments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyDepartermentRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyDepartermentRecords_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyDepartermentRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyDepartermentRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyDepartermentRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyMemberRecord",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerIodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMemberRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyMemberRecord_CompanyMembers_CompanyMemberId",
                        column: x => x.CompanyMemberId,
                        principalSchema: "Company",
                        principalTable: "CompanyMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyMemberRecord_Period_PerIodId",
                        column: x => x.PerIodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyMemberRecord_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyMemberRecord_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyMemberRecord_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyMemberRecord_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyPositionRecord",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyPositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPositionRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyPositionRecord_CompanyPositions_CompanyPositionId",
                        column: x => x.CompanyPositionId,
                        principalSchema: "Company",
                        principalTable: "CompanyPositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyPositionRecord_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyPositionRecord_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyPositionRecord_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyPositionRecord_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyPositionRecord_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactRecords",
                schema: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactRecords_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "Contact",
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactRecords_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegionRecords",
                schema: "Region",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegionRecords_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegionRecords_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegionRecords_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegionRecords_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "Region",
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegionRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegionRecords_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: " MemberActualLeaveRecord",
                schema: "ActualLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberActualLeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ MemberActualLeaveRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ MemberActualLeaveRecord_ MemberActualLeave_MemberActualLeaveId",
                        column: x => x.MemberActualLeaveId,
                        principalSchema: "ActualLeave",
                        principalTable: " MemberActualLeave",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberActualLeaveRecord_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberActualLeaveRecord_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberActualLeaveRecord_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberActualLeaveRecord_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberActualLeaveRecord_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: " MemberAdvanceLeaveRecord",
                schema: "AdvanceLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberAdvanceLeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ MemberAdvanceLeaveRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeaveRecord_ MemberAdvanceLeave_MemberAdvanceLeaveId",
                        column: x => x.MemberAdvanceLeaveId,
                        principalSchema: "AdvanceLeave",
                        principalTable: " MemberAdvanceLeave",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeaveRecord_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeaveRecord_ReasonCodes_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "ReasonCode",
                        principalTable: "ReasonCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeaveRecord_RecordStatusTypes_RecordStatusTypeId",
                        column: x => x.RecordStatusTypeId,
                        principalSchema: "RecordStatusType",
                        principalTable: "RecordStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeaveRecord_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeaveRecord_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "db",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName", "UserProfile" },
                values: new object[] { new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"), 0, "2708d6d2-9657-423a-bb75-34be3b1e2821", new DateTimeOffset(new DateTime(2022, 6, 25, 9, 28, 41, 927, DateTimeKind.Unspecified).AddTicks(8911), new TimeSpan(0, 7, 0, 0, 0)), "benz@gmail.com", true, "BenZ", "UTC", false, null, null, "BENZ@GMAIL.COM", "BENZ", "AQAAAAEAACcQAAAAEL9cktyP+gHmmzf9H/EDjjVr7yan9Xo8kNhEBsfAC2o4xxxuluEo71+aVTpUB7YG7Q==", "012273893", true, "WPOJONETW3HXSDNK4LQR47BNYJSG7OFG", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "WPOJONETW3HXSDNK4LQR47BNYJSG7OFG", true, false, "BenZ", null });

            migrationBuilder.CreateIndex(
                name: "IX_ AdvanceLeaveRecord_AdvanceLeaveId",
                schema: "AdvanceLeave",
                table: " AdvanceLeaveRecord",
                column: "AdvanceLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_ AdvanceLeaveRecord_CreatedUserId",
                schema: "AdvanceLeave",
                table: " AdvanceLeaveRecord",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ AdvanceLeaveRecord_ModifiedUserId",
                schema: "AdvanceLeave",
                table: " AdvanceLeaveRecord",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ AdvanceLeaveRecord_PeriodId",
                schema: "AdvanceLeave",
                table: " AdvanceLeaveRecord",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ AdvanceLeaveRecord_ReasonCodeId",
                schema: "AdvanceLeave",
                table: " AdvanceLeaveRecord",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ AdvanceLeaveRecord_RecordStatusTypeId",
                schema: "AdvanceLeave",
                table: " AdvanceLeaveRecord",
                column: "RecordStatusTypeId");

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
                name: "IX_ MemberActualLeave_MemberId",
                schema: "ActualLeave",
                table: " MemberActualLeave",
                column: "MemberId");

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
                name: "IX_ MemberActualLeaveRecord_CreatedUserId",
                schema: "ActualLeave",
                table: " MemberActualLeaveRecord",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberActualLeaveRecord_MemberActualLeaveId",
                schema: "ActualLeave",
                table: " MemberActualLeaveRecord",
                column: "MemberActualLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberActualLeaveRecord_ModifiedUserId",
                schema: "ActualLeave",
                table: " MemberActualLeaveRecord",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberActualLeaveRecord_PeriodId",
                schema: "ActualLeave",
                table: " MemberActualLeaveRecord",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberActualLeaveRecord_ReasonCodeId",
                schema: "ActualLeave",
                table: " MemberActualLeaveRecord",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberActualLeaveRecord_RecordStatusTypeId",
                schema: "ActualLeave",
                table: " MemberActualLeaveRecord",
                column: "RecordStatusTypeId");

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
                name: "IX_ MemberAdvanceLeave_UserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRecord_CreatedUserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRecord",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRecord_MemberAdvanceLeaveId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRecord",
                column: "MemberAdvanceLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRecord_ModifiedUserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRecord",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRecord_PeriodId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRecord",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRecord_ReasonCodeId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRecord",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRecord_RecordStatusTypeId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRecord",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ RecordStatusTypeMember_CreatedUserId",
                schema: "RecordStatusType",
                table: " RecordStatusTypeMember",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ RecordStatusTypeMember_ModifiedUserId",
                schema: "RecordStatusType",
                table: " RecordStatusTypeMember",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ RecordStatusTypeMember_PeriodId",
                schema: "RecordStatusType",
                table: " RecordStatusTypeMember",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ RecordStatusTypeMember_RecordStatusTypeId",
                schema: "RecordStatusType",
                table: " RecordStatusTypeMember",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ RecordStatusTypeMember_UserId",
                schema: "RecordStatusType",
                table: " RecordStatusTypeMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeaveRecord_ActualLeaveId",
                schema: "ActualLeave",
                table: "ActualLeaveRecord",
                column: "ActualLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeaveRecord_CreatedUserId",
                schema: "ActualLeave",
                table: "ActualLeaveRecord",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeaveRecord_ModifiedUserId",
                schema: "ActualLeave",
                table: "ActualLeaveRecord",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeaveRecord_PeriodId",
                schema: "ActualLeave",
                table: "ActualLeaveRecord",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeaveRecord_ReasonCodeId",
                schema: "ActualLeave",
                table: "ActualLeaveRecord",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualLeaveRecord_RecordStatusTypeId",
                schema: "ActualLeave",
                table: "ActualLeaveRecord",
                column: "RecordStatusTypeId");

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
                name: "IX_AdvanceLeaves_LeaveTypeId",
                schema: "AdvanceLeave",
                table: "AdvanceLeaves",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceLeaves_ModifiedUserId",
                schema: "AdvanceLeave",
                table: "AdvanceLeaves",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceLeaves_ReasonCodeId",
                schema: "AdvanceLeave",
                table: "AdvanceLeaves",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchRecords_BranchId",
                schema: "Branch",
                table: "BranchRecords",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchRecords_CreatedUserId",
                schema: "Branch",
                table: "BranchRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchRecords_ModifiedUserId",
                schema: "Branch",
                table: "BranchRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchRecords_PeriodId",
                schema: "Branch",
                table: "BranchRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchRecords_ReasonCodeId",
                schema: "Branch",
                table: "BranchRecords",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchRecords_RecordStatusTypeId",
                schema: "Branch",
                table: "BranchRecords",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_Code",
                schema: "Branch",
                table: "Branchs",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_CompanyDetailId",
                schema: "Branch",
                table: "Branchs",
                column: "CompanyDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_CreatedUserId",
                schema: "Branch",
                table: "Branchs",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_ModifiedUserId",
                schema: "Branch",
                table: "Branchs",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDepartermentRecords_CompanyDepartermentId",
                schema: "Company",
                table: "CompanyDepartermentRecords",
                column: "CompanyDepartermentId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDepartermentRecords_CreatedUserId",
                schema: "Company",
                table: "CompanyDepartermentRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDepartermentRecords_ModifiedUserId",
                schema: "Company",
                table: "CompanyDepartermentRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDepartermentRecords_PeriodId",
                schema: "Company",
                table: "CompanyDepartermentRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDepartermentRecords_ReasonCodeId",
                schema: "Company",
                table: "CompanyDepartermentRecords",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDepartermentRecords_RecordStatusTypeId",
                schema: "Company",
                table: "CompanyDepartermentRecords",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDeparterments_CompanyDetailId",
                schema: "Company",
                table: "CompanyDeparterments",
                column: "CompanyDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDeparterments_CreatedUserId",
                schema: "Company",
                table: "CompanyDeparterments",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDeparterments_ModifiedUserId",
                schema: "Company",
                table: "CompanyDeparterments",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDetails_CompanyId",
                schema: "Company",
                table: "CompanyDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDetails_CreatedUserId",
                schema: "Company",
                table: "CompanyDetails",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDetails_ModifiedUserId",
                schema: "Company",
                table: "CompanyDetails",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMemberRecord_CompanyMemberId",
                schema: "Company",
                table: "CompanyMemberRecord",
                column: "CompanyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMemberRecord_CreatedUserId",
                schema: "Company",
                table: "CompanyMemberRecord",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMemberRecord_ModifiedUserId",
                schema: "Company",
                table: "CompanyMemberRecord",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMemberRecord_PerIodId",
                schema: "Company",
                table: "CompanyMemberRecord",
                column: "PerIodId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMemberRecord_ReasonCodeId",
                schema: "Company",
                table: "CompanyMemberRecord",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMemberRecord_RecordStatusTypeId",
                schema: "Company",
                table: "CompanyMemberRecord",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMembers_CompanyDetailId",
                schema: "Company",
                table: "CompanyMembers",
                column: "CompanyDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMembers_CreatedUserId",
                schema: "Company",
                table: "CompanyMembers",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMembers_ModifiedUserId",
                schema: "Company",
                table: "CompanyMembers",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMembers_UserId",
                schema: "Company",
                table: "CompanyMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositionRecord_CompanyPositionId",
                schema: "Company",
                table: "CompanyPositionRecord",
                column: "CompanyPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositionRecord_CreatedUserId",
                schema: "Company",
                table: "CompanyPositionRecord",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositionRecord_ModifiedUserId",
                schema: "Company",
                table: "CompanyPositionRecord",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositionRecord_PeriodId",
                schema: "Company",
                table: "CompanyPositionRecord",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositionRecord_ReasonCodeId",
                schema: "Company",
                table: "CompanyPositionRecord",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositionRecord_RecordStatusTypeId",
                schema: "Company",
                table: "CompanyPositionRecord",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositions_CompanyDetailId",
                schema: "Company",
                table: "CompanyPositions",
                column: "CompanyDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositions_CreatedUserId",
                schema: "Company",
                table: "CompanyPositions",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositions_ModifiedUserId",
                schema: "Company",
                table: "CompanyPositions",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRecords_CompanyId",
                schema: "Company",
                table: "CompanyRecords",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRecords_CreatedUserId",
                schema: "Company",
                table: "CompanyRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRecords_ModifiedUserId",
                schema: "Company",
                table: "CompanyRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRecords_PeriodId",
                schema: "Company",
                table: "CompanyRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRecords_ReasonCodeId",
                schema: "Company",
                table: "CompanyRecords",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRecords_RecordStatusTypeId",
                schema: "Company",
                table: "CompanyRecords",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Companys_Code",
                schema: "Company",
                table: "Companys",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companys_CreatedUserId",
                schema: "Company",
                table: "Companys",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companys_ModifiedUserId",
                schema: "Company",
                table: "Companys",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactRecords_ContactId",
                schema: "Contact",
                table: "ContactRecords",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactRecords_CreatedUserId",
                schema: "Contact",
                table: "ContactRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactRecords_ModifiedUserId",
                schema: "Contact",
                table: "ContactRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactRecords_PeriodId",
                schema: "Contact",
                table: "ContactRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactRecords_ReasonCodeId",
                schema: "Contact",
                table: "ContactRecords",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactRecords_RecordStatusTypeId",
                schema: "Contact",
                table: "ContactRecords",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Code",
                schema: "Contact",
                table: "Contacts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyDetailId",
                schema: "Contact",
                table: "Contacts",
                column: "CompanyDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CreatedUserId",
                schema: "Contact",
                table: "Contacts",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ModifiedUserId",
                schema: "Contact",
                table: "Contacts",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentMemberRecords_CreatedUserId",
                schema: "Departerment",
                table: "DepartermentMemberRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentMemberRecords_DepartermentMemberId",
                schema: "Departerment",
                table: "DepartermentMemberRecords",
                column: "DepartermentMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentMemberRecords_ModifiedUserId",
                schema: "Departerment",
                table: "DepartermentMemberRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentMemberRecords_PeriodId",
                schema: "Departerment",
                table: "DepartermentMemberRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentMemberRecords_ReasonCodeId",
                schema: "Departerment",
                table: "DepartermentMemberRecords",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentMemberRecords_RecordStatusTypeId",
                schema: "Departerment",
                table: "DepartermentMemberRecords",
                column: "RecordStatusTypeId");

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
                name: "IX_DepartermentRecords_CreatedUserId",
                schema: "Departerment",
                table: "DepartermentRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentRecords_DepartermentId",
                schema: "Departerment",
                table: "DepartermentRecords",
                column: "DepartermentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentRecords_ModifiedUserId",
                schema: "Departerment",
                table: "DepartermentRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentRecords_PeriodId",
                schema: "Departerment",
                table: "DepartermentRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentRecords_ReasoncodeId",
                schema: "Departerment",
                table: "DepartermentRecords",
                column: "ReasoncodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartermentRecords_RecordStatusTypeId",
                schema: "Departerment",
                table: "DepartermentRecords",
                column: "RecordStatusTypeId");

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
                name: "IX_Leave_CreatedUserId",
                schema: "LeaveRecord",
                table: "Leave",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_LeaveId",
                schema: "LeaveRecord",
                table: "Leave",
                column: "LeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_ModifiedUserId",
                schema: "LeaveRecord",
                table: "Leave",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_PeriodId",
                schema: "LeaveRecord",
                table: "Leave",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_ReasonCodeId",
                schema: "LeaveRecord",
                table: "Leave",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_RecordStatusTypeId",
                schema: "LeaveRecord",
                table: "Leave",
                column: "RecordStatusTypeId");

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
                name: "IX_LeaveTypeRecords_CreatedUserId",
                schema: "Leave",
                table: "LeaveTypeRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypeRecords_LeaveTypeId",
                schema: "Leave",
                table: "LeaveTypeRecords",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypeRecords_ModifiedUserId",
                schema: "Leave",
                table: "LeaveTypeRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypeRecords_PeriodId",
                schema: "Leave",
                table: "LeaveTypeRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypeRecords_ReasonCodeId",
                schema: "Leave",
                table: "LeaveTypeRecords",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypeRecords_RecordStatusTypeId",
                schema: "Leave",
                table: "LeaveTypeRecords",
                column: "RecordStatusTypeId");

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
                name: "IX_MemberRecords_CreatedUserId",
                schema: "Member",
                table: "MemberRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRecords_MemberId",
                schema: "Member",
                table: "MemberRecords",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRecords_ModifiedUserId",
                schema: "Member",
                table: "MemberRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRecords_PeriodId",
                schema: "Member",
                table: "MemberRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRecords_ReasonCodeId",
                schema: "Member",
                table: "MemberRecords",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRecords_RecordStatusTypeId",
                schema: "Member",
                table: "MemberRecords",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Code",
                schema: "Member",
                table: "Members",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

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
                name: "IX_Members_UserId",
                schema: "Member",
                table: "Members",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberTypeRecords_CreatedUserId",
                schema: "Member",
                table: "MemberTypeRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTypeRecords_MemberTypeId",
                schema: "Member",
                table: "MemberTypeRecords",
                column: "MemberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTypeRecords_ModifiedUserId",
                schema: "Member",
                table: "MemberTypeRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTypeRecords_PeriodId",
                schema: "Member",
                table: "MemberTypeRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTypeRecords_ReasonCodeId",
                schema: "Member",
                table: "MemberTypeRecords",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTypeRecords_RecordStatusTypeId",
                schema: "Member",
                table: "MemberTypeRecords",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTypes_Code",
                schema: "Member",
                table: "MemberTypes",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTypes_CreatedUserId",
                schema: "Member",
                table: "MemberTypes",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTypes_ModifiedUserId",
                schema: "Member",
                table: "MemberTypes",
                column: "ModifiedUserId");

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
                name: "IX_PositionMemberRecord_CreatedUserId",
                table: "PositionMemberRecord",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionMemberRecord_ModifiedUserId",
                table: "PositionMemberRecord",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionMemberRecord_PeriodId",
                table: "PositionMemberRecord",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionMemberRecord_PositionMemberId",
                table: "PositionMemberRecord",
                column: "PositionMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionMemberRecord_ReasconCodeId",
                table: "PositionMemberRecord",
                column: "ReasconCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionMemberRecord_RecordStatusTypeId",
                table: "PositionMemberRecord",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionRecords_CreatedUserId",
                schema: "Position",
                table: "PositionRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionRecords_ModifiedUserId",
                schema: "Position",
                table: "PositionRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionRecords_PeriodId",
                schema: "Position",
                table: "PositionRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionRecords_PositionId",
                schema: "Position",
                table: "PositionRecords",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionRecords_ReasonCodeId",
                schema: "Position",
                table: "PositionRecords",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionRecords_RecordStatusTypeId",
                schema: "Position",
                table: "PositionRecords",
                column: "RecordStatusTypeId");

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
                name: "IX_ProjectRecord_CreatedUserId",
                table: "ProjectRecord",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRecord_ModifiedUserId",
                table: "ProjectRecord",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonCodeRecords_CreatedUserId",
                schema: "ReasonCode",
                table: "ReasonCodeRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonCodeRecords_ModifiedUserId",
                schema: "ReasonCode",
                table: "ReasonCodeRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonCodeRecords_PeriodId",
                schema: "ReasonCode",
                table: "ReasonCodeRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonCodeRecords_ReasonCodeId",
                schema: "ReasonCode",
                table: "ReasonCodeRecords",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonCodeRecords_RecordStatusTypeId",
                schema: "ReasonCode",
                table: "ReasonCodeRecords",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonCodes_Code",
                schema: "ReasonCode",
                table: "ReasonCodes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReasonCodes_CreatedUserId",
                schema: "ReasonCode",
                table: "ReasonCodes",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonCodes_ModifiedUserId",
                schema: "ReasonCode",
                table: "ReasonCodes",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonCodes_UserId",
                schema: "ReasonCode",
                table: "ReasonCodes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordStatusTypes_Code",
                schema: "RecordStatusType",
                table: "RecordStatusTypes",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecordStatusTypes_CreatedUserId",
                schema: "RecordStatusType",
                table: "RecordStatusTypes",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordStatusTypes_ModifiedUserId",
                schema: "RecordStatusType",
                table: "RecordStatusTypes",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionRecords_CreatedUserId",
                schema: "Region",
                table: "RegionRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionRecords_ModifiedUserId",
                schema: "Region",
                table: "RegionRecords",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionRecords_PeriodId",
                schema: "Region",
                table: "RegionRecords",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionRecords_ReasonCodeId",
                schema: "Region",
                table: "RegionRecords",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionRecords_RecordStatusTypeId",
                schema: "Region",
                table: "RegionRecords",
                column: "RecordStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionRecords_RegionId",
                schema: "Region",
                table: "RegionRecords",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_Code",
                schema: "Region",
                table: "Regions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CompanyDetailId",
                schema: "Region",
                table: "Regions",
                column: "CompanyDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CreatedUserId",
                schema: "Region",
                table: "Regions",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ModifiedUserId",
                schema: "Region",
                table: "Regions",
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
                name: "IX_WorkingRecord_CreatedUserId",
                table: "WorkingRecord",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingRecord_ModifiedUserId",
                table: "WorkingRecord",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingType_CreatedUserId",
                table: "WorkingType",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingType_ModifiedUserId",
                table: "WorkingType",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTypeRecord_CreatedUserId",
                table: "WorkingTypeRecord",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTypeRecord_ModifiedUserId",
                table: "WorkingTypeRecord",
                column: "ModifiedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " AdvanceLeaveRecord",
                schema: "AdvanceLeave");

            migrationBuilder.DropTable(
                name: " MemberActualLeaveRecord",
                schema: "ActualLeave");

            migrationBuilder.DropTable(
                name: " MemberAdvanceLeaveRecord",
                schema: "AdvanceLeave");

            migrationBuilder.DropTable(
                name: " RecordStatusTypeMember",
                schema: "RecordStatusType");

            migrationBuilder.DropTable(
                name: "ActualLeaveRecord",
                schema: "ActualLeave");

            migrationBuilder.DropTable(
                name: "BranchRecords",
                schema: "Branch");

            migrationBuilder.DropTable(
                name: "CompanyDepartermentRecords",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "CompanyMemberRecord",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "CompanyPositionRecord",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "CompanyRecords",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "ContactRecords",
                schema: "Contact");

            migrationBuilder.DropTable(
                name: "DepartermentMemberRecords",
                schema: "Departerment");

            migrationBuilder.DropTable(
                name: "DepartermentRecords",
                schema: "Departerment");

            migrationBuilder.DropTable(
                name: "Leave",
                schema: "LeaveRecord");

            migrationBuilder.DropTable(
                name: "LeaveTypeRecords",
                schema: "Leave");

            migrationBuilder.DropTable(
                name: "MemberRecords",
                schema: "Member");

            migrationBuilder.DropTable(
                name: "MemberTypeRecords",
                schema: "Member");

            migrationBuilder.DropTable(
                name: "PositionMemberRecord");

            migrationBuilder.DropTable(
                name: "PositionRecords",
                schema: "Position");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectRecord");

            migrationBuilder.DropTable(
                name: "ReasonCodeRecords",
                schema: "ReasonCode");

            migrationBuilder.DropTable(
                name: "RegionRecords",
                schema: "Region");

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
                name: "WorkingRecord");

            migrationBuilder.DropTable(
                name: "WorkingType");

            migrationBuilder.DropTable(
                name: "WorkingTypeRecord");

            migrationBuilder.DropTable(
                name: " MemberActualLeave",
                schema: "ActualLeave");

            migrationBuilder.DropTable(
                name: " MemberAdvanceLeave",
                schema: "AdvanceLeave");

            migrationBuilder.DropTable(
                name: "Branchs",
                schema: "Branch");

            migrationBuilder.DropTable(
                name: "CompanyDeparterments",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "CompanyMembers",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "CompanyPositions",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "Contact");

            migrationBuilder.DropTable(
                name: "DepartermentMembers",
                schema: "Departerment");

            migrationBuilder.DropTable(
                name: "Leaves",
                schema: "Leave");

            migrationBuilder.DropTable(
                name: "MemberTypes",
                schema: "Member");

            migrationBuilder.DropTable(
                name: "PositionMember");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "RecordStatusTypes",
                schema: "RecordStatusType");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "Region");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "db");

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
                name: "CompanyDetails",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "LeaveTypes",
                schema: "Leave");

            migrationBuilder.DropTable(
                name: "ReasonCodes",
                schema: "ReasonCode");

            migrationBuilder.DropTable(
                name: "Departerments",
                schema: "Departerment");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "Position");

            migrationBuilder.DropTable(
                name: "Companys",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "db");
        }
    }
}
