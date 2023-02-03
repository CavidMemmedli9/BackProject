using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackProject.Migrations
{
    public partial class Upcomming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Upcomming_Events");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Upcomming_Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Upcomming_Events");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Upcomming_Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
