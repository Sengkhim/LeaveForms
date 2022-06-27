using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistance.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ MemberAdvanceLeave_Users_UserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave");

            migrationBuilder.DropIndex(
                name: "IX_ MemberAdvanceLeave_UserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 6, 25, 9, 41, 34, 129, DateTimeKind.Unspecified).AddTicks(27), new TimeSpan(0, 7, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 6, 25, 9, 39, 6, 216, DateTimeKind.Unspecified).AddTicks(1094), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_ MemberAdvanceLeave_UserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ MemberAdvanceLeave_Users_UserId",
                schema: "AdvanceLeave",
                table: " MemberAdvanceLeave",
                column: "UserId",
                principalSchema: "db",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
