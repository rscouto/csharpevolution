using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsharpEvolution.Migrations
{
    public partial class Operations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MathOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumOne = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumTwo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");
        }
    }
}
