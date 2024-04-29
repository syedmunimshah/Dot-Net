using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeCodeFirstApproachCrudOperation.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationCodeFirstApproch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(name: "Student ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(name: "Student Name", type: "Varchar(100)", nullable: false),
                    StudentAge = table.Column<string>(name: "Student Age", type: "varchar(100)", nullable: false),
                    StudentNumer = table.Column<string>(name: "Student Numer", type: "Varchar(100)", nullable: false),
                    StudentEmail = table.Column<string>(name: "Student Email", type: "Varchar(100)", nullable: false),
                    StudentPassword = table.Column<string>(name: "Student Password", type: "Varchar(100)", nullable: false),
                    StudentConfirmPassword = table.Column<string>(name: "Student Confirm Password", type: "Varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
