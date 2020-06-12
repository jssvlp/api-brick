using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class FAMILIA_PROYECTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "FamiliaID",
                table: "proyectos",
                nullable: true);



            migrationBuilder.AddColumn<int>(
                name: "NumeroProyectoFamilia",
                table: "proyectos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "familias_proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_familias_proyectos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "passwords_resets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    RecoveryToken = table.Column<string>(nullable: true),
                    UserRecoveryToken = table.Column<string>(nullable: true),
                    RequestDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passwords_resets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_proyectos_FamiliaID",
                table: "proyectos",
                column: "FamiliaID");

            migrationBuilder.AddForeignKey(
                name: "FK_proyectos_familias_proyectos_FamiliaID",
                table: "proyectos",
                column: "FamiliaID",
                principalTable: "familias_proyectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_proyectos_familias_proyectos_FamiliaID",
                table: "proyectos");

            migrationBuilder.DropTable(
                name: "familias_proyectos");

            migrationBuilder.DropTable(
                name: "passwords_resets");

            migrationBuilder.DropIndex(
                name: "IX_proyectos_FamiliaID",
                table: "proyectos");


            migrationBuilder.DropColumn(
                name: "FamiliaID",
                table: "proyectos");

            migrationBuilder.DropColumn(
                name: "NumeroProyectoFamilia",
                table: "proyectos");
        }
    }
}
