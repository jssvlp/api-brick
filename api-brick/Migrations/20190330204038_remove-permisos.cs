using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class removepermisos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visitas_agendadas_proyectos_ProyectoID",
                table: "visitas_agendadas");

            migrationBuilder.DropForeignKey(
                name: "FK_visitas_agendadas_solicitudes_SolicitudID",
                table: "visitas_agendadas");

            migrationBuilder.DropTable(
                name: "permisos_roles");

            migrationBuilder.DropTable(
                name: "permisos");

            migrationBuilder.AlterColumn<int>(
                name: "SolicitudID",
                table: "visitas_agendadas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoID",
                table: "visitas_agendadas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_visitas_agendadas_proyectos_ProyectoID",
                table: "visitas_agendadas",
                column: "ProyectoID",
                principalTable: "proyectos",
                principalColumn: "ProyectoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_visitas_agendadas_solicitudes_SolicitudID",
                table: "visitas_agendadas",
                column: "SolicitudID",
                principalTable: "solicitudes",
                principalColumn: "SolicitudID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visitas_agendadas_proyectos_ProyectoID",
                table: "visitas_agendadas");

            migrationBuilder.DropForeignKey(
                name: "FK_visitas_agendadas_solicitudes_SolicitudID",
                table: "visitas_agendadas");

            migrationBuilder.AlterColumn<int>(
                name: "SolicitudID",
                table: "visitas_agendadas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoID",
                table: "visitas_agendadas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "permisos",
                columns: table => new
                {
                    PermisoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Modulo = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permisos", x => x.PermisoId);
                });

            migrationBuilder.CreateTable(
                name: "permisos_roles",
                columns: table => new
                {
                    PermisoId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permisos_roles", x => new { x.PermisoId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_permisos_roles_permisos_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "permisos",
                        principalColumn: "PermisoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_permisos_roles_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_permisos_roles_RoleId",
                table: "permisos_roles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_visitas_agendadas_proyectos_ProyectoID",
                table: "visitas_agendadas",
                column: "ProyectoID",
                principalTable: "proyectos",
                principalColumn: "ProyectoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visitas_agendadas_solicitudes_SolicitudID",
                table: "visitas_agendadas",
                column: "SolicitudID",
                principalTable: "solicitudes",
                principalColumn: "SolicitudID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
