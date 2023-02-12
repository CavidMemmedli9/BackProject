using Microsoft.EntityFrameworkCore.Migrations;

namespace BackProject.Migrations
{
    public partial class AddTeacherTAble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hobby",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Hobby",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Teachers");
        }
    }
}
