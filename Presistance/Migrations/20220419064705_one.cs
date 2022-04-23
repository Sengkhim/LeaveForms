using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistance.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                schema: "db",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "db",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                schema: "db",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "db",
                table: "UserClaims");

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 4, 19, 13, 47, 4, 549, DateTimeKind.Unspecified).AddTicks(4201), new TimeSpan(0, 7, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                schema: "db",
                table: "UserClaims",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                schema: "db",
                table: "UserClaims",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUser",
                schema: "db",
                table: "UserClaims",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                schema: "db",
                table: "UserClaims",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 4, 18, 15, 22, 49, 218, DateTimeKind.Unspecified).AddTicks(2630), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
