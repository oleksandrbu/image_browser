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

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Width = table.Column<long>(nullable: false),
                    Height = table.Column<long>(nullable: false),
                    FiletypeId = table.Column<decimal>(nullable: true),
                    TitleId = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Filetypes_FiletypeId",
                        column: x => x.FiletypeId,
                        principalTable: "Filetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TitleCharacter",
                columns: table => new
                {
                    TitleId = table.Column<decimal>(nullable: false),
                    CharacterId = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleCharacter", x => new { x.TitleId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_TitleCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleCharacter_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageCharacter",
                columns: table => new
                {
                    ImageId = table.Column<decimal>(nullable: false),
                    CharacterId = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCharacter", x => new { x.ImageId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_ImageCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageCharacter_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageCharacter_CharacterId",
                table: "ImageCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_FiletypeId",
                table: "Images",
                column: "FiletypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TitleId",
                table: "Images",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleCharacter_CharacterId",
                table: "TitleCharacter",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageCharacter");

            migrationBuilder.DropTable(
                name: "TitleCharacter");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Filetypes");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
