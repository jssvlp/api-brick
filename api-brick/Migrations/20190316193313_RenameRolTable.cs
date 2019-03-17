using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class RenameRolTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermisosRoles_Role_RoleId",
                table: "PermisosRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Role_RoleId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleNombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RoleId);
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "RoleId", "Descripcion", "RoleNombre" },
                values: new object[] { 1, null, "Admin" });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "RoleId", "Descripcion", "RoleNombre" },
                values: new object[] { 2, null, "Usuarios" });

            migrationBuilder.AddForeignKey(
                name: "FK_PermisosRoles_Rol_RoleId",
                table: "PermisosRoles",
                column: "RoleId",
                principalTable: "Rol",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Rol_RoleId",
                table: "Usuarios",
                column: "RoleId",
                principalTable: "Rol",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermisosRoles_Rol_RoleId",
                table: "PermisosRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Rol_RoleId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    RoleNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Descripcion", "RoleNombre" },
                values: new object[] { 1, null, "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Descripcion", "RoleNombre" },
                values: new object[] { 2, null, "Usuarios" });

            migrationBuilder.AddForeignKey(
                name: "FK_PermisosRoles_Role_RoleId",
                table: "PermisosRoles",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Role_RoleId",
                table: "Usuarios",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
