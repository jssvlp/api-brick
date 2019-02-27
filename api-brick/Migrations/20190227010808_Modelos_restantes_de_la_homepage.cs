using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class Modelos_restantes_de_la_homepage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServicioID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreServicio = table.Column<string>(nullable: true),
                    DescripcionServicio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(nullable: true),
                    CorreoUsuario = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Contraseña = table.Column<string>(nullable: true),
                    AdminAccess = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudServicios",
                columns: table => new
                {
                    SolicitudID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaSol = table.Column<DateTime>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false),
                    FechaServSol = table.Column<DateTime>(nullable: false),
                    Comentario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudServicios", x => x.SolicitudID);
                    table.ForeignKey(
                        name: "FK_SolicitudServicios_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicioSolicituds",
                columns: table => new
                {
                    SolicitudID = table.Column<int>(nullable: false),
                    ServicioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioSolicituds", x => new { x.ServicioID, x.SolicitudID });
                    table.ForeignKey(
                        name: "FK_ServicioSolicituds_Servicios_ServicioID",
                        column: x => x.ServicioID,
                        principalTable: "Servicios",
                        principalColumn: "ServicioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioSolicituds_SolicitudServicios_SolicitudID",
                        column: x => x.SolicitudID,
                        principalTable: "SolicitudServicios",
                        principalColumn: "SolicitudID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitasAgendadas",
                columns: table => new
                {
                    VisitaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProyectoID = table.Column<int>(nullable: false),
                    HorarioProgramado = table.Column<DateTime>(nullable: false),
                    SolicitudID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitasAgendadas", x => x.VisitaID);
                    table.ForeignKey(
                        name: "FK_VisitasAgendadas_Proyecto_ProyectoID",
                        column: x => x.ProyectoID,
                        principalTable: "Proyecto",
                        principalColumn: "ProyectoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitasAgendadas_SolicitudServicios_SolicitudID",
                        column: x => x.SolicitudID,
                        principalTable: "SolicitudServicios",
                        principalColumn: "SolicitudID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicioSolicituds_SolicitudID",
                table: "ServicioSolicituds",
                column: "SolicitudID");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudServicios_UsuarioID",
                table: "SolicitudServicios",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasAgendadas_ProyectoID",
                table: "VisitasAgendadas",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasAgendadas_SolicitudID",
                table: "VisitasAgendadas",
                column: "SolicitudID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicioSolicituds");

            migrationBuilder.DropTable(
                name: "VisitasAgendadas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "SolicitudServicios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
