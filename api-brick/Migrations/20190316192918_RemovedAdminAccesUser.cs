using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class RemovedAdminAccesUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminAccess",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdminAccess",
                table: "Usuarios",
                nullable: false,
                defaultValue: false);
        }
    }
}
