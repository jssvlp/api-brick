using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class RenameRolTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermisosRoles_Rol_RoleId",
                table: "PermisosRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Rol_RoleId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermisosRoles_Roles_RoleId",
                table: "PermisosRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RoleId",
                table: "Usuarios",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermisosRoles_Roles_RoleId",
                table: "PermisosRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RoleId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Rol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "RoleId");

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
    }
}
