using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class ajuste_del_modelo_inmueble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApellidosUsuario",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreInmueble",
                table: "Inmueble",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidosUsuario",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NombreInmueble",
                table: "Inmueble");
        }
    }
}
