using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_usuarios_UsuarioID",
                table: "blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_usuarios_UsuarioID",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_usuarios_UsuarioID",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_publicaciones_usuarios_UsuarioID",
                table: "publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_solicitudes_usuarios_UsuarioID",
                table: "solicitudes");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.ClienteID);
                    table.ForeignKey(
                        name: "FK_clientes_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clientes_RoleId",
                table: "clientes",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_clientes_UsuarioID",
                table: "blogs",
                column: "UsuarioID",
                principalTable: "clientes",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_clientes_UsuarioID",
                table: "comentarios",
                column: "UsuarioID",
                principalTable: "clientes",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_likes_clientes_UsuarioID",
                table: "likes",
                column: "UsuarioID",
                principalTable: "clientes",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_publicaciones_clientes_UsuarioID",
                table: "publicaciones",
                column: "UsuarioID",
                principalTable: "clientes",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_solicitudes_clientes_UsuarioID",
                table: "solicitudes",
                column: "UsuarioID",
                principalTable: "clientes",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_clientes_UsuarioID",
                table: "blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_clientes_UsuarioID",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_clientes_UsuarioID",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_publicaciones_clientes_UsuarioID",
                table: "publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_solicitudes_clientes_UsuarioID",
                table: "solicitudes");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApellidosUsuario = table.Column<string>(nullable: true),
                    AuthToken = table.Column<string>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true),
                    CorreoUsuario = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    FirebaseCode = table.Column<string>(nullable: true),
                    NombreUsuario = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
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

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "RoleId", "Descripcion", "RoleNombre" },
                values: new object[] { 1, null, "Admin" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "RoleId", "Descripcion", "RoleNombre" },
                values: new object[] { 2, null, "Usuarios" });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "UsuarioID", "ApellidosUsuario", "AuthToken", "Contraseña", "CorreoUsuario", "FechaNacimiento", "FirebaseCode", "NombreUsuario", "RoleId" },
                values: new object[] { 1, "Admin", null, "1234567", "admin@admin.com", new DateTime(2019, 6, 20, 0, 0, 0, 0, DateTimeKind.Local), null, "Admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_RoleId",
                table: "usuarios",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_usuarios_UsuarioID",
                table: "blogs",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_usuarios_UsuarioID",
                table: "comentarios",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_likes_usuarios_UsuarioID",
                table: "likes",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_publicaciones_usuarios_UsuarioID",
                table: "publicaciones",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_solicitudes_usuarios_UsuarioID",
                table: "solicitudes",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
