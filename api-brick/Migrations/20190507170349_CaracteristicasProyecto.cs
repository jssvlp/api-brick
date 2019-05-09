using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class CaracteristicasProyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoCar",
                table: "caracteristicas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoCarProyecto",
                table: "caracteristicas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "caracteristicas_proyectos",
                columns: table => new
                {
                    ProyectoID = table.Column<int>(nullable: false),
                    CaracteristicaID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caracteristicas_proyectos", x => new { x.CaracteristicaID, x.ProyectoID });
                    table.ForeignKey(
                        name: "FK_caracteristicas_proyectos_caracteristicas_CaracteristicaID",
                        column: x => x.CaracteristicaID,
                        principalTable: "caracteristicas",
                        principalColumn: "CaracteristicaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_caracteristicas_proyectos_proyectos_ProyectoID",
                        column: x => x.ProyectoID,
                        principalTable: "proyectos",
                        principalColumn: "ProyectoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 5, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_caracteristicas_proyectos_ProyectoID",
                table: "caracteristicas_proyectos",
                column: "ProyectoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "caracteristicas_proyectos");

            migrationBuilder.DropColumn(
                name: "TipoCar",
                table: "caracteristicas");

            migrationBuilder.DropColumn(
                name: "TipoCarProyecto",
                table: "caracteristicas");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 4, 23, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
