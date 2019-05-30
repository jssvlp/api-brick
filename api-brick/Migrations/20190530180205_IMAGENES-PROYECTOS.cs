using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class IMAGENESPROYECTOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "imagenes_proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    ProyectoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagenes_proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagenes_proyectos_proyectos_ProyectoID",
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
                value: new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_imagenes_proyectos_ProyectoID",
                table: "imagenes_proyectos",
                column: "ProyectoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imagenes_proyectos");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
