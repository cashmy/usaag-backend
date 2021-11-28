using Microsoft.EntityFrameworkCore.Migrations;

namespace UsaagBackend.Migrations
{
    public partial class curriculumType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurriculumTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ChipColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CurriculumTypes",
                columns: new[] { "Id", "Abbreviation", "Archived", "ChipColor", "Name", "TextColor" },
                values: new object[,]
                {
                    { 1, "Note", false, "gray", "Note", "white" },
                    { 2, "Lect", false, "yellow", "Lecture", "black" },
                    { 3, "Demo", false, "orange", "Demo", "black" },
                    { 4, "WS", false, "cyan", "Worksheet", "black" },
                    { 5, "MLab", false, "blue", "Mini-Lab", "white" },
                    { 6, "Lab", false, "darkblue", "Lab", "white" },
                    { 7, "Proj", false, "purple", "Project", "white" },
                    { 8, "GCap", false, "lime", "Group Capstone", "black" },
                    { 9, "ICap", false, "green", "Individual Capstone", "white" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurriculumTypes");
        }
    }
}
