using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class NEW_PROPS_IN_UBICACION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CantidadBanos",
                table: "inmuebles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CantidadHabitaciones",
                table: "inmuebles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadParqueos",
                table: "inmuebles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadBanos",
                table: "inmuebles");

            migrationBuilder.DropColumn(
                name: "CantidadHabitaciones",
                table: "inmuebles");

            migrationBuilder.DropColumn(
                name: "CantidadParqueos",
                table: "inmuebles");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 5, 6, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
