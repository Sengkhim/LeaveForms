using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistance.Migrations
{
    public partial class Type1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ MemberAdvanceLeaveRequest_AdvanceLeaveId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRequest");

            migrationBuilder.DropIndex(
                name: "IX_ MemberAdvanceLeaveRequest_MemberId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRequest");

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 6, 27, 16, 16, 6, 676, DateTimeKind.Unspecified).AddTicks(5287), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRequest_AdvanceLeaveId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRequest",
                column: "AdvanceLeaveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeaveRequest_MemberId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRequest",
                column: "MemberId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ MemberAdvanceLeaveRequest_AdvanceLeaveId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRequest");

            migrationBuilder.DropIndex(
                name: "IX_ MemberAdvanceLeaveRequest_MemberId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRequest");

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
                name: "IX_ MemberAdvanceLeaveRequest_MemberId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeaveRequest",
                column: "MemberId");
        }
    }
}
