using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace University_Student.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "scholar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_Name = table.Column<string>(nullable: true),
                    student_Email = table.Column<string>(nullable: true),
                    student_Mobile = table.Column<string>(nullable: true),
                    course_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholar", x => x.Id);
                });
            var sqlFile = Path.Combine(".\\DatabaseScript", @"script.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scholar");
        }
    }
}
