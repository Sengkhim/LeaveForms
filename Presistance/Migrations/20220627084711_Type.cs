using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistance.Migrations
{
    public partial class Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: " MemberAdvanceLeaveRequest",
                schema: "AdvanceLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvanceLeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ MemberAdvanceLeaveRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeaveRequest_AdvanceLeaves_AdvanceLeaveId",
                        column: x => x.AdvanceLeaveId,
                        principalSchema: "AdvanceLeave",
                        principalTable: "AdvanceLeaves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeaveRequest_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Member",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeaveRequest_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ MemberAdvanceLeaveRequest_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 6, 27, 15, 47, 9, 94, DateTimeKind.Unspecified).AddTicks(6112), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRequest_AdvanceLeaveId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRequest",
                column: "AdvanceLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRequest_CreatedUserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRequest",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRequest_MemberId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRequest",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRequest_ModifiedUserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRequest",
                column: "ModifiedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " MemberAdvanceLeaveRequest",
                schema: "AdvanceLeave");

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 6, 27, 15, 18, 58, 380, DateTimeKind.Unspecified).AddTicks(7886), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
