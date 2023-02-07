using Microsoft.EntityFrameworkCore.Migrations;

namespace BackProject.Migrations
{
    public partial class SlidTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderContents");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Sliders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Sliders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Sliders");

            migrationBuilder.CreateTable(
                name: "SliderContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderContents", x => x.Id);
                });
        }
    }
}
