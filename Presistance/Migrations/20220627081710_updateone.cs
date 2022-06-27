using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistance.Migrations
{
    public partial class updateone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_Code",
                schema: "Member",
                table: "Members");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Member",
                table: "Members",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 6, 27, 15, 17, 7, 328, DateTimeKind.Unspecified).AddTicks(5859), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Members_Code",
                schema: "Member",
                table: "Members",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_Code",
                schema: "Member",
                table: "Members");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Member",
                table: "Members",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 6, 27, 11, 4, 29, 742, DateTimeKind.Unspecified).AddTicks(7333), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Members_Code",
                schema: "Member",
                table: "Members",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
