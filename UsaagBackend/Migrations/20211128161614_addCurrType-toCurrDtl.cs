using Microsoft.EntityFrameworkCore.Migrations;

namespace UsaagBackend.Migrations
{
    public partial class addCurrTypetoCurrDtl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrTypeId",
                table: "CurriculumDetail",
                type: "int",
                nullable: false,
                defaultValue: 1);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumDetail_CurriculumTypes_CurriculumTypeId",
                table: "CurriculumDetail");

            migrationBuilder.DropIndex(
                name: "IX_CurriculumDetail_CurriculumTypeId",
                table: "CurriculumDetail");

            migrationBuilder.DropColumn(
                name: "CurrTypeId",
                table: "CurriculumDetail");

            migrationBuilder.DropColumn(
                name: "CurriculumTypeId",
                table: "CurriculumDetail");
        }
    }
}
