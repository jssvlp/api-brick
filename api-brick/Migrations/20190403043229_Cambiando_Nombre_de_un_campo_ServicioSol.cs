﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class Cambiando_Nombre_de_un_campo_ServicioSol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}