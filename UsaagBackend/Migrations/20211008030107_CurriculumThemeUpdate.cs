using Microsoft.EntityFrameworkCore.Migrations;

namespace UsaagBackend.Migrations
{
    public partial class CurriculumThemeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaysInWeek",
                table: "CurriculumThemes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LectureTopics",
                table: "CurriculumTemplateList",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysInWeek",
                table: "CurriculumThemes");

            migrationBuilder.DropColumn(
                name: "LectureTopics",
                table: "CurriculumTemplateList");
        }
    }
}
