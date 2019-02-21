using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class CarateristicasModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Caracteristica_InmuebleID",
                table: "Inmueble",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Caracteristica_Inmuebles",
                columns: table => new
                {
                    Caracteristica_InmuebleID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristica_Inmuebles", x => x.Caracteristica_InmuebleID);
                });

            migrationBuilder.CreateTable(
                name: "CaracteristicaInmuebles",
                columns: table => new
                {
                    CaracteristicaInmuebleID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CarNombre = table.Column<string>(nullable: true),
                    CarDescripcion = table.Column<string>(nullable: true),
                    Caracteristica_InmuebleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicaInmuebles", x => x.CaracteristicaInmuebleID);
                    table.ForeignKey(
                        name: "FK_CaracteristicaInmuebles_Caracteristica_Inmuebles_Caracterist~",
                        column: x => x.Caracteristica_InmuebleID,
                        principalTable: "Caracteristica_Inmuebles",
                        principalColumn: "Caracteristica_InmuebleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_Caracteristica_InmuebleID",
                table: "Inmueble",
                column: "Caracteristica_InmuebleID");

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicaInmuebles_Caracteristica_InmuebleID",
                table: "CaracteristicaInmuebles",
                column: "Caracteristica_InmuebleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inmueble_Caracteristica_Inmuebles_Caracteristica_InmuebleID",
                table: "Inmueble",
                column: "Caracteristica_InmuebleID",
                principalTable: "Caracteristica_Inmuebles",
                principalColumn: "Caracteristica_InmuebleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inmueble_Caracteristica_Inmuebles_Caracteristica_InmuebleID",
                table: "Inmueble");

            migrationBuilder.DropTable(
                name: "CaracteristicaInmuebles");

            migrationBuilder.DropTable(
                name: "Caracteristica_Inmuebles");

            migrationBuilder.DropIndex(
                name: "IX_Inmueble_Caracteristica_InmuebleID",
                table: "Inmueble");

            migrationBuilder.DropColumn(
                name: "Caracteristica_InmuebleID",
                table: "Inmueble");
        }
    }
}
