using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistance.Migrations
{
    public partial class updatetwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 6, 27, 15, 18, 58, 380, DateTimeKind.Unspecified).AddTicks(7886), new TimeSpan(0, 7, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 6, 27, 15, 17, 7, 328, DateTimeKind.Unspecified).AddTicks(5859), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
