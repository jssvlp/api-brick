using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class documentoresumenpdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentoResumenPdf",
                table: "proyectos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentoResumenPdf",
                table: "proyectos");
        }
    }
}
