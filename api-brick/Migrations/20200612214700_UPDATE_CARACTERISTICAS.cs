using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class UPDATE_CARACTERISTICAS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "caracteristicas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "caracteristicas");
        }
    }
}
