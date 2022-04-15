using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBook.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mood",
                columns: table => new
                {
                    MoodPic = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mood", x => x.MoodPic);
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
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.TemplateId);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    WeatherPic = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.WeatherPic);
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
                    Template = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoDiary", x => x.PhotoDiaryId);
                    table.ForeignKey(
                        name: "FK_PhotoDiary_Template_Template",
                        column: x => x.Template,
                        principalTable: "Template",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    JournalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotebookId = table.Column<int>(type: "int", nullable: false),
                    Notebook = table.Column<int>(type: "int", nullable: true),
                    weather = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    mood = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.JournalId);
                    table.ForeignKey(
                        name: "FK_Journal_Mood_mood",
                        column: x => x.mood,
                        principalTable: "Mood",
                        principalColumn: "MoodPic",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Journal_Notebook_Notebook",
                        column: x => x.Notebook,
                        principalTable: "Notebook",
                        principalColumn: "NotebookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Journal_Weather_weather",
                        column: x => x.weather,
                        principalTable: "Weather",
                        principalColumn: "WeatherPic",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journal_mood",
                table: "Journal",
                column: "mood");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_Notebook",
                table: "Journal",
                column: "Notebook");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_weather",
                table: "Journal",
                column: "weather");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoDiary_Template",
                table: "PhotoDiary",
                column: "Template");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "PhotoDiary");

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
