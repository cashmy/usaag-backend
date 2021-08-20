using Microsoft.EntityFrameworkCore.Migrations;

namespace UsaagBackend.Migrations
{
    public partial class addCurrThemeTempList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurriculumTemplateList",
                columns: table => new
                {
                    ThemeId = table.Column<int>(type: "int", nullable: false),
                    HeaderId = table.Column<int>(type: "int", nullable: false),
                    AssignmentSequence = table.Column<int>(type: "int", nullable: false),
                    DayToAssign = table.Column<int>(type: "int", nullable: false),
                    ProjectDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumTemplateList", x => new { x.ThemeId, x.HeaderId });
                    table.ForeignKey(
                        name: "FK_CurriculumTemplateList_CurriculumThemes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "CurriculumThemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurriculumTemplateList_TemplateHeader_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "TemplateHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumTemplateList_HeaderId",
                table: "CurriculumTemplateList",
                column: "HeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurriculumTemplateList");
        }
    }
}
