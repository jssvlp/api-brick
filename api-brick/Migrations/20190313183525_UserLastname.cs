using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class UserLastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApellidosUsuario",
                table: "Usuarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidosUsuario",
                table: "Usuarios");
        }
    }
}
