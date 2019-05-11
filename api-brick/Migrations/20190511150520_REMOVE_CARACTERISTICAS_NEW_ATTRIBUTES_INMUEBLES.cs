using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class REMOVE_CARACTERISTICAS_NEW_ATTRIBUTES_INMUEBLES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "caracteristicas_inmuebles");

            migrationBuilder.AddColumn<string>(
                name: "Moneda",
                table: "inmuebles",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "mts",
                table: "inmuebles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 5, 11, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Moneda",
                table: "inmuebles");

            migrationBuilder.DropColumn(
                name: "mts",
                table: "inmuebles");

            migrationBuilder.CreateTable(
                name: "caracteristicas_inmuebles",
                columns: table => new
                {
                    CaracteristicaID = table.Column<int>(nullable: false),
                    InmuebleID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caracteristicas_inmuebles", x => new { x.CaracteristicaID, x.InmuebleID });
                    table.ForeignKey(
                        name: "FK_caracteristicas_inmuebles_caracteristicas_CaracteristicaID",
                        column: x => x.CaracteristicaID,
                        principalTable: "caracteristicas",
                        principalColumn: "CaracteristicaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_caracteristicas_inmuebles_inmuebles_InmuebleID",
                        column: x => x.InmuebleID,
                        principalTable: "inmuebles",
                        principalColumn: "InmuebleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_caracteristicas_inmuebles_InmuebleID",
                table: "caracteristicas_inmuebles",
                column: "InmuebleID");
        }
    }
}
