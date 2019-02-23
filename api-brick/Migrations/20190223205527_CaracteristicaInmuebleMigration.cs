using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class CaracteristicaInmuebleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caracteristica",
                columns: table => new
                {
                    CaracteristicaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CarNombre = table.Column<string>(nullable: true),
                    CarDescripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristica", x => x.CaracteristicaID);
                });

            migrationBuilder.CreateTable(
                name: "CaracteristicaInmuebles",
                columns: table => new
                {
                    InmuebleID = table.Column<int>(nullable: false),
                    CaracteristicaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicaInmuebles", x => new { x.CaracteristicaID, x.InmuebleID });
                    table.ForeignKey(
                        name: "FK_CaracteristicaInmuebles_Caracteristica_CaracteristicaID",
                        column: x => x.CaracteristicaID,
                        principalTable: "Caracteristica",
                        principalColumn: "CaracteristicaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaracteristicaInmuebles_Inmueble_InmuebleID",
                        column: x => x.InmuebleID,
                        principalTable: "Inmueble",
                        principalColumn: "InmuebleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicaInmuebles_InmuebleID",
                table: "CaracteristicaInmuebles",
                column: "InmuebleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaracteristicaInmuebles");

            migrationBuilder.DropTable(
                name: "Caracteristica");
        }
    }
}
