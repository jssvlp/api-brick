using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class nuevoEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "EstadoId", "EstadoNombre" },
                values: new object[] { 5, "Aprobada" });

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "EstadoId", "EstadoNombre" },
                values: new object[] { 6, "Rechazada" });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 4, 7, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "EstadoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "EstadoId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
