using Microsoft.EntityFrameworkCore.Migrations;

namespace BackProject.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "SocialPage");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
              name: "SocialPages",
              table: "Teachers",
              nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Whatsapp",
                table: "Teachers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Teachers");

            migrationBuilder.DropColumn(
               name: "SocialPages",
               table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Whatsapp",
                table: "Teachers");

            //migrationBuilder.CreateTable(
            //    name: "SocialPage",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        TeacherId = table.Column<int>(type: "int", nullable: false),
            //        Whatsapp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SocialPage", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_SocialPage_Teachers_TeacherId",
            //            column: x => x.TeacherId,
            //            principalTable: "Teachers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_SocialPage_TeacherId",
            //    table: "SocialPage",
            //    column: "TeacherId");
        }
    }
}
