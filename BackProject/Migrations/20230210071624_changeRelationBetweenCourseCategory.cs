using Microsoft.EntityFrameworkCore.Migrations;

namespace BackProject.Migrations
{
    public partial class changeRelationBetweenCourseCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Courses_CourseId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_CourseId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Category_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Category_CategoryId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Category_CourseId",
                table: "Category",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Courses_CourseId",
                table: "Category",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
