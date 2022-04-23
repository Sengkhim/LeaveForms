using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistance.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "db",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                schema: "db",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                schema: "db",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "db",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                schema: "db",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "db",
                table: "UserRoles");

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 4, 18, 15, 3, 20, 104, DateTimeKind.Unspecified).AddTicks(2762), new TimeSpan(0, 7, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "db",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedUserId",
                schema: "db",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                schema: "db",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                schema: "db",
                table: "UserRoles",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUser",
                schema: "db",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                schema: "db",
                table: "UserRoles",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "db",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("434c71ce-64fe-4a71-83ea-d61cb7b1f571"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2022, 4, 12, 16, 57, 2, 816, DateTimeKind.Unspecified).AddTicks(6971), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
