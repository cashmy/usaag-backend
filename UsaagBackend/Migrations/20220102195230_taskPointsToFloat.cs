using Microsoft.EntityFrameworkCore.Migrations;

namespace UsaagBackend.Migrations
{
    public partial class taskPointsToFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumDetail_CurriculumTypes_CurriculumTypeId",
                table: "CurriculumDetail");

            migrationBuilder.DropIndex(
                name: "IX_CurriculumDetail_CurriculumTypeId",
                table: "CurriculumDetail");

            migrationBuilder.DropColumn(
                name: "CurriculumTypeId",
                table: "CurriculumDetail");

            migrationBuilder.AlterColumn<float>(
                name: "PointValue",
                table: "TemplateDetail",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumDetail_CurrTypeId",
                table: "CurriculumDetail",
                column: "CurrTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumDetail_CurriculumTypes_CurrTypeId",
                table: "CurriculumDetail",
                column: "CurrTypeId",
                principalTable: "CurriculumTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumDetail_CurriculumTypes_CurrTypeId",
                table: "CurriculumDetail");

            migrationBuilder.DropIndex(
                name: "IX_CurriculumDetail_CurrTypeId",
                table: "CurriculumDetail");

            migrationBuilder.AlterColumn<int>(
                name: "PointValue",
                table: "TemplateDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "CurriculumTypeId",
                table: "CurriculumDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumDetail_CurriculumTypeId",
                table: "CurriculumDetail",
                column: "CurriculumTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumDetail_CurriculumTypes_CurriculumTypeId",
                table: "CurriculumDetail",
                column: "CurriculumTypeId",
                principalTable: "CurriculumTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
