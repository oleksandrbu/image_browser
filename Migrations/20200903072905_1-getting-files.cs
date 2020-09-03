using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace image_browser.Migrations
{
    public partial class _1gettingfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filetypes",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filetypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Width = table.Column<long>(nullable: false),
                    Height = table.Column<long>(nullable: false),
                    FiletypeId = table.Column<long>(nullable: false),
                    TitleId = table.Column<long>(nullable: false),
                    CharactersId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Release = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Filetypes");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
