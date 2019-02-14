using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    UbicacionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreUbicacion = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.UbicacionID);
                });

            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    ProyectoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreProyecto = table.Column<string>(nullable: true),
                    FechaTerminacion = table.Column<DateTime>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    ImgURL = table.Column<string>(nullable: true),
                    UbicacionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.ProyectoID);
                    table.ForeignKey(
                        name: "FK_Proyecto_Ubicacion_UbicacionID",
                        column: x => x.UbicacionID,
                        principalTable: "Ubicacion",
                        principalColumn: "UbicacionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inmueble",
                columns: table => new
                {
                    InmuebleID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Precio = table.Column<int>(nullable: false),
                    DescripcionInmueble = table.Column<string>(nullable: true),
                    ProyectoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmueble", x => x.InmuebleID);
                    table.ForeignKey(
                        name: "FK_Inmueble_Proyecto_ProyectoID",
                        column: x => x.ProyectoID,
                        principalTable: "Proyecto",
                        principalColumn: "ProyectoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_ProyectoID",
                table: "Inmueble",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_UbicacionID",
                table: "Proyecto",
                column: "UbicacionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inmueble");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "Ubicacion");
        }
    }
}
