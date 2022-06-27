using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistance.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Users_UserId",
                schema: "Member",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_UserId",
                schema: "Member",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Member",
                table: "Members");

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 6, 25, 9, 39, 6, 216, DateTimeKind.Unspecified).AddTicks(1094), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberId",
                schema: "Member",
                table: "Members",
                column: "MemberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Users_MemberId",
                schema: "Member",
                table: "Members",
                column: "MemberId",
                principalSchema: "db",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Users_MemberId",
                schema: "Member",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_MemberId",
                schema: "Member",
                table: "Members");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "Member",
                table: "Members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 6, 25, 9, 28, 41, 927, DateTimeKind.Unspecified).AddTicks(8911), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserId",
                schema: "Member",
                table: "Members",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Users_UserId",
                schema: "Member",
                table: "Members",
                column: "UserId",
                principalSchema: "db",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
