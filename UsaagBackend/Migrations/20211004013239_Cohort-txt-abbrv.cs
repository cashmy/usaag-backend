using Microsoft.EntityFrameworkCore.Migrations;

namespace UsaagBackend.Migrations
{
    public partial class Cohorttxtabbrv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Archived",
                table: "Students",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "Cohorts",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextColor",
                table: "Cohorts",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "black");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "Cohorts");

            migrationBuilder.DropColumn(
                name: "TextColor",
                table: "Cohorts");

            migrationBuilder.AlterColumn<bool>(
                name: "Archived",
                table: "Students",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);
        }
    }
}
