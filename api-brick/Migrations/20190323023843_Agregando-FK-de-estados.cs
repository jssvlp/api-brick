using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class AgregandoFKdeestados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_ServicioSolicituds_EstadoID",
                table: "ServicioSolicituds",
                column: "EstadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioSolicituds_Estado_EstadoID",
                table: "ServicioSolicituds",
                column: "EstadoID",
                principalTable: "Estado",
                principalColumn: "EstadoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicioSolicituds_Estado_EstadoID",
                table: "ServicioSolicituds");

            migrationBuilder.DropIndex(
                name: "IX_ServicioSolicituds_EstadoID",
                table: "ServicioSolicituds");

            migrationBuilder.DropColumn(
                name: "EstadoID",
                table: "ServicioSolicituds");

            migrationBuilder.DropColumn(
                name: "NombreInmueble",
                table: "Inmueble");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 3, 16, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
