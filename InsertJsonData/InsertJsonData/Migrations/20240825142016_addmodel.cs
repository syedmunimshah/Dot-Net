using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsertJsonData.Migrations
{
    /// <inheritdoc />
    public partial class addmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cake",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CakeId = table.Column<int>(type: "int", nullable: false),
                    CakeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CakeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CakePpu = table.Column<double>(type: "float", nullable: false),
                    BatterID = table.Column<int>(type: "int", nullable: false),
                    BatterType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToppingId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToppingType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cake", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cake");
        }
    }
}
