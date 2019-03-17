using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class SeedsAndFirebaseUserCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirebaseCode",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstadoNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "EstadoId", "EstadoNombre" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Pendiente" },
                    { 3, "Finalizado" },
                    { 4, "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Descripcion", "RoleNombre" },
                values: new object[,]
                {
                    { 1, null, "Admin" },
                    { 2, null, "Usuarios" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioID", "AdminAccess", "ApellidosUsuario", "Contraseña", "CorreoUsuario", "FechaNacimiento", "FirebaseCode", "NombreUsuario", "RoleId" },
                values: new object[] { 1, false, "Admin", "1234567", "admin@admin.com", new DateTime(2019, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), null, "Admin", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "FirebaseCode",
                table: "Usuarios");
        }
    }
}
