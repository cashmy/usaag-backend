using Microsoft.EntityFrameworkCore.Migrations;

namespace UsaagBackend.Migrations
{
    public partial class modifiedStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Archived",
                table: "TemplateHeader",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Students",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CohortId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPKColor",
                table: "Cohorts",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "#bdbdbd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CohortId",
                table: "Students",
                column: "CohortId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Cohorts_CohortId",
                table: "Students",
                column: "CohortId",
                principalTable: "Cohorts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Cohorts_CohortId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CohortId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CohortId",
                table: "Students");

            migrationBuilder.AlterColumn<bool>(
                name: "Archived",
                table: "TemplateHeader",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CPKColor",
                table: "Cohorts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "#bdbdbd");
        }
    }
}
