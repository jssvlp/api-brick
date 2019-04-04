using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class Actualizacion_Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorarioProgramado",
                table: "visitas_agendadas",
                newName: "Hora_Inicio");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "visitas_agendadas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Visita",
                table: "visitas_agendadas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Hora_Fin",
                table: "visitas_agendadas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Motivo",
                table: "visitas_agendadas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "visitas_agendadas");

            migrationBuilder.DropColumn(
                name: "Fecha_Visita",
                table: "visitas_agendadas");

            migrationBuilder.DropColumn(
                name: "Hora_Fin",
                table: "visitas_agendadas");

            migrationBuilder.DropColumn(
                name: "Motivo",
                table: "visitas_agendadas");

            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "Hora_Inicio",
                table: "visitas_agendadas",
                newName: "HorarioProgramado");
        }
    }
}
