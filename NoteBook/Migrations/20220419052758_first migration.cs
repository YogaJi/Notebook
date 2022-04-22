using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBook.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "Mood",
                columns: table => new
                {
                    MoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoodPic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mood", x => x.MoodId);
                });

            migrationBuilder.CreateTable(
                name: "Notebook",
                columns: table => new
                {
                    NotebookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebook", x => x.NotebookId);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Templates = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.TemplateId);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    WeatherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherPic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.WeatherId);
                });

            migrationBuilder.CreateTable(
                name: "PhotoDiary",
                columns: table => new
                {
                    PhotoDiaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    secondContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoDiary", x => x.PhotoDiaryId);
                    table.ForeignKey(
                        name: "FK_PhotoDiary_Template_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Template",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    JournalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotebookId = table.Column<int>(type: "int", nullable: false),
                    WeatherId = table.Column<int>(type: "int", nullable: false),
                    MoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.JournalId);
                    table.ForeignKey(
                        name: "FK_Journal_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Journal_Mood_MoodId",
                        column: x => x.MoodId,
                        principalTable: "Mood",
                        principalColumn: "MoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Journal_Notebook_NotebookId",
                        column: x => x.NotebookId,
                        principalTable: "Notebook",
                        principalColumn: "NotebookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Journal_Weather_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weather",
                        principalColumn: "WeatherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journal_ColorId",
                table: "Journal",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_MoodId",
                table: "Journal",
                column: "MoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_NotebookId",
                table: "Journal",
                column: "NotebookId");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_WeatherId",
                table: "Journal",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoDiary_TemplateId",
                table: "PhotoDiary",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "PhotoDiary");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Mood");

            migrationBuilder.DropTable(
                name: "Notebook");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Template");
        }
    }
}
