using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class remove_ubicacion_20190506 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_proyectos_ubicaciones_UbicacionID",
                table: "proyectos");

            migrationBuilder.DropTable(
                name: "ubicaciones");

            migrationBuilder.DropIndex(
                name: "IX_proyectos_UbicacionID",
                table: "proyectos");

            migrationBuilder.DropColumn(
                name: "UbicacionID",
                table: "proyectos");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "proyectos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "proyectos",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 5, 6, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "proyectos");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "proyectos");

            migrationBuilder.AddColumn<int>(
                name: "UbicacionID",
                table: "proyectos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ubicaciones",
                columns: table => new
                {
                    UbicacionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ciudad = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    NombreUbicacion = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ubicaciones", x => x.UbicacionID);
                });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_proyectos_UbicacionID",
                table: "proyectos",
                column: "UbicacionID");

            migrationBuilder.AddForeignKey(
                name: "FK_proyectos_ubicaciones_UbicacionID",
                table: "proyectos",
                column: "UbicacionID",
                principalTable: "ubicaciones",
                principalColumn: "UbicacionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
