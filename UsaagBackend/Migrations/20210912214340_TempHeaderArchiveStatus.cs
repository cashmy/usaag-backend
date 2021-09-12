using Microsoft.EntityFrameworkCore.Migrations;

namespace UsaagBackend.Migrations
{
    public partial class TempHeaderArchiveStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "TemplateHeader",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "CurriculumThemes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPKColor",
                table: "Cohorts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "TemplateHeader");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "CurriculumThemes");

            migrationBuilder.DropColumn(
                name: "CPKColor",
                table: "Cohorts");
        }
    }
}
