using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace api_brick.Migrations
{
    public partial class RESETPASSWORDS_CREATE_TABLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "passwords_resets",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                   UserId = table.Column<string>(nullable: false),
                   RecoveryToken = table.Column<string>(nullable: false),
                   UserRecoveryToken = table.Column<string>(nullable: false),
                   RequestDateTime = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_passwords_resets", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
