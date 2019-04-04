using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class Todosloscambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "caracteristicas",
                columns: table => new
                {
                    CaracteristicaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CarNombre = table.Column<string>(nullable: true),
                    CarDescripcion = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caracteristicas", x => x.CaracteristicaID);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstadoNombre = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleNombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "servicios",
                columns: table => new
                {
                    ServicioID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreServicio = table.Column<string>(nullable: true),
                    DescripcionServicio = table.Column<string>(nullable: true),
                    ImgURL = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicios", x => x.ServicioID);
                });

            migrationBuilder.CreateTable(
                name: "temas_foros",
                columns: table => new
                {
                    TemaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTema = table.Column<string>(nullable: true),
                    DescripcionTema = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temas_foros", x => x.TemaID);
                });

            migrationBuilder.CreateTable(
                name: "ubicaciones",
                columns: table => new
                {
                    UbicacionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreUbicacion = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ubicaciones", x => x.UbicacionID);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(nullable: true),
                    ApellidosUsuario = table.Column<string>(nullable: true),
                    CorreoUsuario = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Contraseña = table.Column<string>(nullable: true),
                    FirebaseCode = table.Column<string>(nullable: true),
                    AuthToken = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "proyectos",
                columns: table => new
                {
                    ProyectoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreProyecto = table.Column<string>(nullable: true),
                    FechaTerminacion = table.Column<DateTime>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    ImgURL = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    UbicacionID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyectos", x => x.ProyectoID);
                    table.ForeignKey(
                        name: "FK_proyectos_ubicaciones_UbicacionID",
                        column: x => x.UbicacionID,
                        principalTable: "ubicaciones",
                        principalColumn: "UbicacionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blogs",
                columns: table => new
                {
                    BlogID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TituloEntrada = table.Column<string>(nullable: true),
                    TextoEntrada = table.Column<string>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: false),
                    TimeStampBlog = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_blogs_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "solicitudes",
                columns: table => new
                {
                    SolicitudID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaSol = table.Column<DateTime>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false),
                    FechaServSol = table.Column<DateTime>(nullable: false),
                    Comentario = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitudes", x => x.SolicitudID);
                    table.ForeignKey(
                        name: "FK_solicitudes_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inmuebles",
                columns: table => new
                {
                    InmuebleID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Precio = table.Column<int>(nullable: false),
                    NombreInmueble = table.Column<string>(nullable: true),
                    DescripcionInmueble = table.Column<string>(nullable: true),
                    ProyectoID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inmuebles", x => x.InmuebleID);
                    table.ForeignKey(
                        name: "FK_inmuebles_proyectos_ProyectoID",
                        column: x => x.ProyectoID,
                        principalTable: "proyectos",
                        principalColumn: "ProyectoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comentarios",
                columns: table => new
                {
                    ComentarioID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PublicacionID = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false),
                    TextoComentario = table.Column<string>(nullable: true),
                    TimeStampComment = table.Column<DateTime>(nullable: false),
                    URLImagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentarios", x => x.ComentarioID);
                    table.ForeignKey(
                        name: "FK_comentarios_publicaciones_PublicacionID",
                        column: x => x.PublicacionID,
                        principalTable: "publicaciones",
                        principalColumn: "PublicacionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comentarios_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    LikeID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PublicacionID = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => x.LikeID);
                    table.ForeignKey(
                        name: "FK_likes_publicaciones_PublicacionID",
                        column: x => x.PublicacionID,
                        principalTable: "publicaciones",
                        principalColumn: "PublicacionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_likes_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "solicitudes_servicios",
                columns: table => new
                {
                    SolicitudID = table.Column<int>(nullable: false),
                    ServicioID = table.Column<int>(nullable: false),
                    EstadoID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitudes_servicios", x => new { x.ServicioID, x.SolicitudID });
                    table.ForeignKey(
                        name: "FK_solicitudes_servicios_estados_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_solicitudes_servicios_servicios_ServicioID",
                        column: x => x.ServicioID,
                        principalTable: "servicios",
                        principalColumn: "ServicioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_solicitudes_servicios_solicitudes_SolicitudID",
                        column: x => x.SolicitudID,
                        principalTable: "solicitudes",
                        principalColumn: "SolicitudID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "visitas_agendadas",
                columns: table => new
                {
                    VisitaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HorarioProgramado = table.Column<DateTime>(nullable: false),
                    ProyectoID = table.Column<int>(nullable: true),
                    SolicitudID = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_visitas_agendadas_solicitudes_SolicitudID",
                        column: x => x.SolicitudID,
                        principalTable: "solicitudes",
                        principalColumn: "SolicitudID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "caracteristicas_inmuebles",
                columns: table => new
                {
                    InmuebleID = table.Column<int>(nullable: false),
                    CaracteristicaID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caracteristicas_inmuebles", x => new { x.CaracteristicaID, x.InmuebleID });
                    table.ForeignKey(
                        name: "FK_caracteristicas_inmuebles_caracteristicas_CaracteristicaID",
                        column: x => x.CaracteristicaID,
                        principalTable: "caracteristicas",
                        principalColumn: "CaracteristicaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_caracteristicas_inmuebles_inmuebles_InmuebleID",
                        column: x => x.InmuebleID,
                        principalTable: "inmuebles",
                        principalColumn: "InmuebleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "EstadoId", "EstadoNombre" },
                values: new object[] { 1, "Activo" });

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "EstadoId", "EstadoNombre" },
                values: new object[] { 2, "Pendiente" });

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "EstadoId", "EstadoNombre" },
                values: new object[] { 3, "Finalizado" });

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "EstadoId", "EstadoNombre" },
                values: new object[] { 4, "Inactivo" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "RoleId", "Descripcion", "RoleNombre" },
                values: new object[,]
                {
                    { 1, null, "Admin" },
                    { 2, null, "Usuarios" }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "UsuarioID", "ApellidosUsuario", "AuthToken", "Contraseña", "CorreoUsuario", "FechaNacimiento", "FirebaseCode", "NombreUsuario", "RoleId" },
                values: new object[] { 1, "Admin", null, "1234567", "admin@admin.com", new DateTime(2019, 3, 31, 0, 0, 0, 0, DateTimeKind.Local), null, "Admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_blogs_UsuarioID",
                table: "blogs",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_caracteristicas_inmuebles_InmuebleID",
                table: "caracteristicas_inmuebles",
                column: "InmuebleID");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_PublicacionID",
                table: "comentarios",
                column: "PublicacionID");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_UsuarioID",
                table: "comentarios",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_ProyectoID",
                table: "inmuebles",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_likes_PublicacionID",
                table: "likes",
                column: "PublicacionID");

            migrationBuilder.CreateIndex(
                name: "IX_likes_UsuarioID",
                table: "likes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_proyectos_UbicacionID",
                table: "proyectos",
                column: "UbicacionID");

            migrationBuilder.CreateIndex(
                name: "IX_publicaciones_TemaID",
                table: "publicaciones",
                column: "TemaID");

            migrationBuilder.CreateIndex(
                name: "IX_publicaciones_UsuarioID",
                table: "publicaciones",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudes_UsuarioID",
                table: "solicitudes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudes_servicios_EstadoID",
                table: "solicitudes_servicios",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudes_servicios_SolicitudID",
                table: "solicitudes_servicios",
                column: "SolicitudID");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_RoleId",
                table: "usuarios",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_agendadas_ProyectoID",
                table: "visitas_agendadas",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_agendadas_SolicitudID",
                table: "visitas_agendadas",
                column: "SolicitudID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blogs");

            migrationBuilder.DropTable(
                name: "caracteristicas_inmuebles");

            migrationBuilder.DropTable(
                name: "comentarios");

            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.DropTable(
                name: "solicitudes_servicios");

            migrationBuilder.DropTable(
                name: "visitas_agendadas");

            migrationBuilder.DropTable(
                name: "caracteristicas");

            migrationBuilder.DropTable(
                name: "inmuebles");

            migrationBuilder.DropTable(
                name: "publicaciones");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "servicios");

            migrationBuilder.DropTable(
                name: "solicitudes");

            migrationBuilder.DropTable(
                name: "proyectos");

            migrationBuilder.DropTable(
                name: "temas_foros");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "ubicaciones");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
