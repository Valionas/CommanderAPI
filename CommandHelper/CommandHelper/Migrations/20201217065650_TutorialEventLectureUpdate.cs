using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommandHelper.Migrations
{
    public partial class TutorialEventLectureUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Commands");

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "Commands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tutorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutorial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LecturerPlatform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerPlatform", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerPlatform_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerPlatform_Platform_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartLecture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndLecture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: true),
                    TutorialId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Event_Tutorial_TutorialId",
                        column: x => x.TutorialId,
                        principalTable: "Tutorial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commands_PlatformId",
                table: "Commands",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_LecturerId",
                table: "Event",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TutorialId",
                table: "Event",
                column: "TutorialId",
                unique: true,
                filter: "[TutorialId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerPlatform_LecturerId",
                table: "LecturerPlatform",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerPlatform_PlatformId",
                table: "LecturerPlatform",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commands_Platform_PlatformId",
                table: "Commands",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commands_Platform_PlatformId",
                table: "Commands");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "LecturerPlatform");

            migrationBuilder.DropTable(
                name: "Tutorial");

            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_Commands_PlatformId",
                table: "Commands");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Commands");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Commands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
