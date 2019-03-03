using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class Todos_Los_Modelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TituloEntrada = table.Column<string>(nullable: true),
                    TextoEntrada = table.Column<string>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: false),
                    TimeStampBlog = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_Blogs_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemasForos",
                columns: table => new
                {
                    TemaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTema = table.Column<string>(nullable: true),
                    DescripcionTema = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemasForos", x => x.TemaID);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionDelForos",
                columns: table => new
                {
                    PublicacionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TituloPublicacion = table.Column<string>(nullable: true),
                    TemaID = table.Column<int>(nullable: false),
                    TextoPublicacion = table.Column<string>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: false),
                    TimeStampForo = table.Column<DateTime>(nullable: false),
                    Archivado = table.Column<bool>(nullable: false),
                    URLImagen = table.Column<string>(nullable: true)
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
                name: "CometarioForos",
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
                    table.PrimaryKey("PK_CometarioForos", x => x.ComentarioID);
                    table.ForeignKey(
                        name: "FK_CometarioForos_PublicacionDelForos_PublicacionID",
                        column: x => x.PublicacionID,
                        principalTable: "PublicacionDelForos",
                        principalColumn: "PublicacionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CometarioForos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    LikeID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PublicacionID = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.LikeID);
                    table.ForeignKey(
                        name: "FK_Likes_PublicacionDelForos_PublicacionID",
                        column: x => x.PublicacionID,
                        principalTable: "PublicacionDelForos",
                        principalColumn: "PublicacionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UsuarioID",
                table: "Blogs",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_CometarioForos_PublicacionID",
                table: "CometarioForos",
                column: "PublicacionID");

            migrationBuilder.CreateIndex(
                name: "IX_CometarioForos_UsuarioID",
                table: "CometarioForos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PublicacionID",
                table: "Likes",
                column: "PublicacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UsuarioID",
                table: "Likes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionDelForos_TemaID",
                table: "PublicacionDelForos",
                column: "TemaID");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionDelForos_UsuarioID",
                table: "PublicacionDelForos",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "CometarioForos");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "PublicacionDelForos");

            migrationBuilder.DropTable(
                name: "TemasForos");
        }
    }
}
