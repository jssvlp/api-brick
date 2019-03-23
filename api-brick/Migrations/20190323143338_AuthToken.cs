using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class AuthToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthToken",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusSolicitud",
                table: "ServicioSolicituds",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 3, 23, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthToken",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "StatusSolicitud",
                table: "ServicioSolicituds");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 3, 16, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
