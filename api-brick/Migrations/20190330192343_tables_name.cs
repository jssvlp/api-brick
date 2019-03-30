using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class tables_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Usuarios_UsuarioID",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CaracteristicaInmuebles_Caracteristica_CaracteristicaID",
                table: "CaracteristicaInmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_CaracteristicaInmuebles_Inmueble_InmuebleID",
                table: "CaracteristicaInmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_CometarioForos_PublicacionDelForos_PublicacionID",
                table: "CometarioForos");

            migrationBuilder.DropForeignKey(
                name: "FK_CometarioForos_Usuarios_UsuarioID",
                table: "CometarioForos");

            migrationBuilder.DropForeignKey(
                name: "FK_Inmueble_Proyecto_ProyectoID",
                table: "Inmueble");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_PublicacionDelForos_PublicacionID",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Usuarios_UsuarioID",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_PermisosRoles_Permiso_PermisoId",
                table: "PermisosRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermisosRoles_Roles_RoleId",
                table: "PermisosRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyecto_Ubicacion_UbicacionID",
                table: "Proyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicioSolicituds_Estado_EstadoID",
                table: "ServicioSolicituds");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicioSolicituds_Servicios_ServicioID",
                table: "ServicioSolicituds");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicioSolicituds_SolicitudServicios_SolicitudID",
                table: "ServicioSolicituds");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudServicios_Usuarios_UsuarioID",
                table: "SolicitudServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RoleId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "PublicacionDelForos");

            migrationBuilder.DropTable(
                name: "VisitasAgendadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servicios",
                table: "Servicios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ubicacion",
                table: "Ubicacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemasForos",
                table: "TemasForos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitudServicios",
                table: "SolicitudServicios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicioSolicituds",
                table: "ServicioSolicituds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proyecto",
                table: "Proyecto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermisosRoles",
                table: "PermisosRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permiso",
                table: "Permiso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inmueble",
                table: "Inmueble");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estado",
                table: "Estado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CometarioForos",
                table: "CometarioForos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaracteristicaInmuebles",
                table: "CaracteristicaInmuebles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caracteristica",
                table: "Caracteristica");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Servicios",
                newName: "servicios");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "likes");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "blogs");

            migrationBuilder.RenameTable(
                name: "Ubicacion",
                newName: "ubicaciones");

            migrationBuilder.RenameTable(
                name: "TemasForos",
                newName: "temas_foros");

            migrationBuilder.RenameTable(
                name: "SolicitudServicios",
                newName: "solicitudes");

            migrationBuilder.RenameTable(
                name: "ServicioSolicituds",
                newName: "solicitudes_servicios");

            migrationBuilder.RenameTable(
                name: "Proyecto",
                newName: "proyectos");

            migrationBuilder.RenameTable(
                name: "PermisosRoles",
                newName: "permisos_roles");

            migrationBuilder.RenameTable(
                name: "Permiso",
                newName: "permisos");

            migrationBuilder.RenameTable(
                name: "Inmueble",
                newName: "inmuebles");

            migrationBuilder.RenameTable(
                name: "Estado",
                newName: "estados");

            migrationBuilder.RenameTable(
                name: "CometarioForos",
                newName: "comentarios");

            migrationBuilder.RenameTable(
                name: "CaracteristicaInmuebles",
                newName: "caracteristicas_inmuebles");

            migrationBuilder.RenameTable(
                name: "Caracteristica",
                newName: "caracteristicas");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_RoleId",
                table: "usuarios",
                newName: "IX_usuarios_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UsuarioID",
                table: "likes",
                newName: "IX_likes_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PublicacionID",
                table: "likes",
                newName: "IX_likes_PublicacionID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_UsuarioID",
                table: "blogs",
                newName: "IX_blogs_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudServicios_UsuarioID",
                table: "solicitudes",
                newName: "IX_solicitudes_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_ServicioSolicituds_SolicitudID",
                table: "solicitudes_servicios",
                newName: "IX_solicitudes_servicios_SolicitudID");

            migrationBuilder.RenameIndex(
                name: "IX_ServicioSolicituds_EstadoID",
                table: "solicitudes_servicios",
                newName: "IX_solicitudes_servicios_EstadoID");

            migrationBuilder.RenameIndex(
                name: "IX_Proyecto_UbicacionID",
                table: "proyectos",
                newName: "IX_proyectos_UbicacionID");

            migrationBuilder.RenameIndex(
                name: "IX_PermisosRoles_RoleId",
                table: "permisos_roles",
                newName: "IX_permisos_roles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Inmueble_ProyectoID",
                table: "inmuebles",
                newName: "IX_inmuebles_ProyectoID");

            migrationBuilder.RenameIndex(
                name: "IX_CometarioForos_UsuarioID",
                table: "comentarios",
                newName: "IX_comentarios_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_CometarioForos_PublicacionID",
                table: "comentarios",
                newName: "IX_comentarios_PublicacionID");

            migrationBuilder.RenameIndex(
                name: "IX_CaracteristicaInmuebles_InmuebleID",
                table: "caracteristicas_inmuebles",
                newName: "IX_caracteristicas_inmuebles_InmuebleID");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "usuarios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "usuarios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "servicios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "servicios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "likes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "likes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "blogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ubicaciones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "ubicaciones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "temas_foros",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "temas_foros",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "solicitudes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "solicitudes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "solicitudes_servicios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "solicitudes_servicios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "proyectos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "proyectos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "proyectos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "permisos_roles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "permisos_roles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "permisos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "permisos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "inmuebles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "inmuebles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "estados",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "estados",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "caracteristicas_inmuebles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "caracteristicas_inmuebles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "caracteristicas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "caracteristicas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "UsuarioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_servicios",
                table: "servicios",
                column: "ServicioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_likes",
                table: "likes",
                column: "LikeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogs",
                table: "blogs",
                column: "BlogID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ubicaciones",
                table: "ubicaciones",
                column: "UbicacionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_temas_foros",
                table: "temas_foros",
                column: "TemaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_solicitudes",
                table: "solicitudes",
                column: "SolicitudID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_solicitudes_servicios",
                table: "solicitudes_servicios",
                columns: new[] { "ServicioID", "SolicitudID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_proyectos",
                table: "proyectos",
                column: "ProyectoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_permisos_roles",
                table: "permisos_roles",
                columns: new[] { "PermisoId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_permisos",
                table: "permisos",
                column: "PermisoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inmuebles",
                table: "inmuebles",
                column: "InmuebleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estados",
                table: "estados",
                column: "EstadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comentarios",
                table: "comentarios",
                column: "ComentarioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_caracteristicas_inmuebles",
                table: "caracteristicas_inmuebles",
                columns: new[] { "CaracteristicaID", "InmuebleID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_caracteristicas",
                table: "caracteristicas",
                column: "CaracteristicaID");

            migrationBuilder.CreateTable(
                name: "publicaciones",
                columns: table => new
                {
                    PublicacionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TituloPublicacion = table.Column<string>(nullable: true),
                    TextoPublicacion = table.Column<string>(nullable: true),
                    TimeStampForo = table.Column<DateTime>(nullable: false),
                    Archivado = table.Column<bool>(nullable: false),
                    URLImagen = table.Column<string>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: false),
                    TemaID = table.Column<int>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publicaciones", x => x.PublicacionID);
                    table.ForeignKey(
                        name: "FK_publicaciones_temas_foros_TemaID",
                        column: x => x.TemaID,
                        principalTable: "temas_foros",
                        principalColumn: "TemaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_publicaciones_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "visitas_agendadas",
                columns: table => new
                {
                    VisitaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HorarioProgramado = table.Column<DateTime>(nullable: false),
                    ProyectoID = table.Column<int>(nullable: false),
                    SolicitudID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitas_agendadas", x => x.VisitaID);
                    table.ForeignKey(
                        name: "FK_visitas_agendadas_proyectos_ProyectoID",
                        column: x => x.ProyectoID,
                        principalTable: "proyectos",
                        principalColumn: "ProyectoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_visitas_agendadas_solicitudes_SolicitudID",
                        column: x => x.SolicitudID,
                        principalTable: "solicitudes",
                        principalColumn: "SolicitudID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_publicaciones_TemaID",
                table: "publicaciones",
                column: "TemaID");

            migrationBuilder.CreateIndex(
                name: "IX_publicaciones_UsuarioID",
                table: "publicaciones",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_agendadas_ProyectoID",
                table: "visitas_agendadas",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_agendadas_SolicitudID",
                table: "visitas_agendadas",
                column: "SolicitudID");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_usuarios_UsuarioID",
                table: "blogs",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_caracteristicas_inmuebles_caracteristicas_CaracteristicaID",
                table: "caracteristicas_inmuebles",
                column: "CaracteristicaID",
                principalTable: "caracteristicas",
                principalColumn: "CaracteristicaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_caracteristicas_inmuebles_inmuebles_InmuebleID",
                table: "caracteristicas_inmuebles",
                column: "InmuebleID",
                principalTable: "inmuebles",
                principalColumn: "InmuebleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_publicaciones_PublicacionID",
                table: "comentarios",
                column: "PublicacionID",
                principalTable: "publicaciones",
                principalColumn: "PublicacionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_usuarios_UsuarioID",
                table: "comentarios",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inmuebles_proyectos_ProyectoID",
                table: "inmuebles",
                column: "ProyectoID",
                principalTable: "proyectos",
                principalColumn: "ProyectoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_likes_publicaciones_PublicacionID",
                table: "likes",
                column: "PublicacionID",
                principalTable: "publicaciones",
                principalColumn: "PublicacionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_likes_usuarios_UsuarioID",
                table: "likes",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_permisos_roles_permisos_PermisoId",
                table: "permisos_roles",
                column: "PermisoId",
                principalTable: "permisos",
                principalColumn: "PermisoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_permisos_roles_roles_RoleId",
                table: "permisos_roles",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_proyectos_ubicaciones_UbicacionID",
                table: "proyectos",
                column: "UbicacionID",
                principalTable: "ubicaciones",
                principalColumn: "UbicacionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_solicitudes_usuarios_UsuarioID",
                table: "solicitudes",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_solicitudes_servicios_estados_EstadoID",
                table: "solicitudes_servicios",
                column: "EstadoID",
                principalTable: "estados",
                principalColumn: "EstadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_solicitudes_servicios_servicios_ServicioID",
                table: "solicitudes_servicios",
                column: "ServicioID",
                principalTable: "servicios",
                principalColumn: "ServicioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_solicitudes_servicios_solicitudes_SolicitudID",
                table: "solicitudes_servicios",
                column: "SolicitudID",
                principalTable: "solicitudes",
                principalColumn: "SolicitudID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_RoleId",
                table: "usuarios",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_usuarios_UsuarioID",
                table: "blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_caracteristicas_inmuebles_caracteristicas_CaracteristicaID",
                table: "caracteristicas_inmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_caracteristicas_inmuebles_inmuebles_InmuebleID",
                table: "caracteristicas_inmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_publicaciones_PublicacionID",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_usuarios_UsuarioID",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_inmuebles_proyectos_ProyectoID",
                table: "inmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_publicaciones_PublicacionID",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_usuarios_UsuarioID",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_permisos_roles_permisos_PermisoId",
                table: "permisos_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_permisos_roles_roles_RoleId",
                table: "permisos_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_proyectos_ubicaciones_UbicacionID",
                table: "proyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_solicitudes_usuarios_UsuarioID",
                table: "solicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_solicitudes_servicios_estados_EstadoID",
                table: "solicitudes_servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_solicitudes_servicios_servicios_ServicioID",
                table: "solicitudes_servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_solicitudes_servicios_solicitudes_SolicitudID",
                table: "solicitudes_servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_RoleId",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "publicaciones");

            migrationBuilder.DropTable(
                name: "visitas_agendadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_servicios",
                table: "servicios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_likes",
                table: "likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogs",
                table: "blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ubicaciones",
                table: "ubicaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_temas_foros",
                table: "temas_foros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_solicitudes_servicios",
                table: "solicitudes_servicios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_solicitudes",
                table: "solicitudes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_proyectos",
                table: "proyectos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_permisos_roles",
                table: "permisos_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_permisos",
                table: "permisos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inmuebles",
                table: "inmuebles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estados",
                table: "estados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comentarios",
                table: "comentarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_caracteristicas_inmuebles",
                table: "caracteristicas_inmuebles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_caracteristicas",
                table: "caracteristicas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "servicios");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "servicios");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "likes");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "likes");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ubicaciones");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "ubicaciones");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "temas_foros");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "temas_foros");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "solicitudes_servicios");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "solicitudes_servicios");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "solicitudes");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "solicitudes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "proyectos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "proyectos");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "proyectos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "permisos_roles");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "permisos_roles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "permisos");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "permisos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "inmuebles");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "inmuebles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "estados");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "estados");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "caracteristicas_inmuebles");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "caracteristicas_inmuebles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "caracteristicas");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "caracteristicas");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "servicios",
                newName: "Servicios");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "likes",
                newName: "Likes");

            migrationBuilder.RenameTable(
                name: "blogs",
                newName: "Blogs");

            migrationBuilder.RenameTable(
                name: "ubicaciones",
                newName: "Ubicacion");

            migrationBuilder.RenameTable(
                name: "temas_foros",
                newName: "TemasForos");

            migrationBuilder.RenameTable(
                name: "solicitudes_servicios",
                newName: "ServicioSolicituds");

            migrationBuilder.RenameTable(
                name: "solicitudes",
                newName: "SolicitudServicios");

            migrationBuilder.RenameTable(
                name: "proyectos",
                newName: "Proyecto");

            migrationBuilder.RenameTable(
                name: "permisos_roles",
                newName: "PermisosRoles");

            migrationBuilder.RenameTable(
                name: "permisos",
                newName: "Permiso");

            migrationBuilder.RenameTable(
                name: "inmuebles",
                newName: "Inmueble");

            migrationBuilder.RenameTable(
                name: "estados",
                newName: "Estado");

            migrationBuilder.RenameTable(
                name: "comentarios",
                newName: "CometarioForos");

            migrationBuilder.RenameTable(
                name: "caracteristicas_inmuebles",
                newName: "CaracteristicaInmuebles");

            migrationBuilder.RenameTable(
                name: "caracteristicas",
                newName: "Caracteristica");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_RoleId",
                table: "Usuarios",
                newName: "IX_Usuarios_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_likes_UsuarioID",
                table: "Likes",
                newName: "IX_Likes_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_likes_PublicacionID",
                table: "Likes",
                newName: "IX_Likes_PublicacionID");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_UsuarioID",
                table: "Blogs",
                newName: "IX_Blogs_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_solicitudes_servicios_SolicitudID",
                table: "ServicioSolicituds",
                newName: "IX_ServicioSolicituds_SolicitudID");

            migrationBuilder.RenameIndex(
                name: "IX_solicitudes_servicios_EstadoID",
                table: "ServicioSolicituds",
                newName: "IX_ServicioSolicituds_EstadoID");

            migrationBuilder.RenameIndex(
                name: "IX_solicitudes_UsuarioID",
                table: "SolicitudServicios",
                newName: "IX_SolicitudServicios_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_proyectos_UbicacionID",
                table: "Proyecto",
                newName: "IX_Proyecto_UbicacionID");

            migrationBuilder.RenameIndex(
                name: "IX_permisos_roles_RoleId",
                table: "PermisosRoles",
                newName: "IX_PermisosRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_inmuebles_ProyectoID",
                table: "Inmueble",
                newName: "IX_Inmueble_ProyectoID");

            migrationBuilder.RenameIndex(
                name: "IX_comentarios_UsuarioID",
                table: "CometarioForos",
                newName: "IX_CometarioForos_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_comentarios_PublicacionID",
                table: "CometarioForos",
                newName: "IX_CometarioForos_PublicacionID");

            migrationBuilder.RenameIndex(
                name: "IX_caracteristicas_inmuebles_InmuebleID",
                table: "CaracteristicaInmuebles",
                newName: "IX_CaracteristicaInmuebles_InmuebleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "UsuarioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servicios",
                table: "Servicios",
                column: "ServicioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "LikeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "BlogID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ubicacion",
                table: "Ubicacion",
                column: "UbicacionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemasForos",
                table: "TemasForos",
                column: "TemaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicioSolicituds",
                table: "ServicioSolicituds",
                columns: new[] { "ServicioID", "SolicitudID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitudServicios",
                table: "SolicitudServicios",
                column: "SolicitudID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proyecto",
                table: "Proyecto",
                column: "ProyectoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermisosRoles",
                table: "PermisosRoles",
                columns: new[] { "PermisoId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permiso",
                table: "Permiso",
                column: "PermisoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inmueble",
                table: "Inmueble",
                column: "InmuebleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estado",
                table: "Estado",
                column: "EstadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CometarioForos",
                table: "CometarioForos",
                column: "ComentarioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaracteristicaInmuebles",
                table: "CaracteristicaInmuebles",
                columns: new[] { "CaracteristicaID", "InmuebleID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caracteristica",
                table: "Caracteristica",
                column: "CaracteristicaID");

            migrationBuilder.CreateTable(
                name: "PublicacionDelForos",
                columns: table => new
                {
                    PublicacionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Archivado = table.Column<bool>(nullable: false),
                    TemaID = table.Column<int>(nullable: false),
                    TextoPublicacion = table.Column<string>(nullable: true),
                    TimeStampForo = table.Column<DateTime>(nullable: false),
                    TituloPublicacion = table.Column<string>(nullable: true),
                    URLImagen = table.Column<string>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionDelForos", x => x.PublicacionID);
                    table.ForeignKey(
                        name: "FK_PublicacionDelForos_TemasForos_TemaID",
                        column: x => x.TemaID,
                        principalTable: "TemasForos",
                        principalColumn: "TemaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicacionDelForos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitasAgendadas",
                columns: table => new
                {
                    VisitaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HorarioProgramado = table.Column<DateTime>(nullable: false),
                    ProyectoID = table.Column<int>(nullable: false),
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

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionDelForos_TemaID",
                table: "PublicacionDelForos",
                column: "TemaID");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionDelForos_UsuarioID",
                table: "PublicacionDelForos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasAgendadas_ProyectoID",
                table: "VisitasAgendadas",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasAgendadas_SolicitudID",
                table: "VisitasAgendadas",
                column: "SolicitudID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Usuarios_UsuarioID",
                table: "Blogs",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaracteristicaInmuebles_Caracteristica_CaracteristicaID",
                table: "CaracteristicaInmuebles",
                column: "CaracteristicaID",
                principalTable: "Caracteristica",
                principalColumn: "CaracteristicaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaracteristicaInmuebles_Inmueble_InmuebleID",
                table: "CaracteristicaInmuebles",
                column: "InmuebleID",
                principalTable: "Inmueble",
                principalColumn: "InmuebleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CometarioForos_PublicacionDelForos_PublicacionID",
                table: "CometarioForos",
                column: "PublicacionID",
                principalTable: "PublicacionDelForos",
                principalColumn: "PublicacionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CometarioForos_Usuarios_UsuarioID",
                table: "CometarioForos",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inmueble_Proyecto_ProyectoID",
                table: "Inmueble",
                column: "ProyectoID",
                principalTable: "Proyecto",
                principalColumn: "ProyectoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_PublicacionDelForos_PublicacionID",
                table: "Likes",
                column: "PublicacionID",
                principalTable: "PublicacionDelForos",
                principalColumn: "PublicacionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Usuarios_UsuarioID",
                table: "Likes",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermisosRoles_Permiso_PermisoId",
                table: "PermisosRoles",
                column: "PermisoId",
                principalTable: "Permiso",
                principalColumn: "PermisoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermisosRoles_Roles_RoleId",
                table: "PermisosRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyecto_Ubicacion_UbicacionID",
                table: "Proyecto",
                column: "UbicacionID",
                principalTable: "Ubicacion",
                principalColumn: "UbicacionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioSolicituds_Estado_EstadoID",
                table: "ServicioSolicituds",
                column: "EstadoID",
                principalTable: "Estado",
                principalColumn: "EstadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioSolicituds_Servicios_ServicioID",
                table: "ServicioSolicituds",
                column: "ServicioID",
                principalTable: "Servicios",
                principalColumn: "ServicioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicioSolicituds_SolicitudServicios_SolicitudID",
                table: "ServicioSolicituds",
                column: "SolicitudID",
                principalTable: "SolicitudServicios",
                principalColumn: "SolicitudID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudServicios_Usuarios_UsuarioID",
                table: "SolicitudServicios",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RoleId",
                table: "Usuarios",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
