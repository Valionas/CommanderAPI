using Microsoft.EntityFrameworkCore.Migrations;

namespace CommandHelper.Migrations
{
    public partial class bla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Lecturer_LecturerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Tutorial_TutorialId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerPlatform_Lecturer_LecturerId",
                table: "LecturerPlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerPlatform_Platform_PlatformId",
                table: "LecturerPlatform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tutorial",
                table: "Tutorial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LecturerPlatform",
                table: "LecturerPlatform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecturer",
                table: "Lecturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Tutorial",
                newName: "Tutorials");

            migrationBuilder.RenameTable(
                name: "LecturerPlatform",
                newName: "LecturerPlatforms");

            migrationBuilder.RenameTable(
                name: "Lecturer",
                newName: "Lecturers");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerPlatform_PlatformId",
                table: "LecturerPlatforms",
                newName: "IX_LecturerPlatforms_PlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerPlatform_LecturerId",
                table: "LecturerPlatforms",
                newName: "IX_LecturerPlatforms_LecturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_TutorialId",
                table: "Events",
                newName: "IX_Events_TutorialId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_LecturerId",
                table: "Events",
                newName: "IX_Events_LecturerId");

            migrationBuilder.AddColumn<string>(
                name: "TutorialName",
                table: "Tutorials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tutorials",
                table: "Tutorials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LecturerPlatforms",
                table: "LecturerPlatforms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecturers",
                table: "Lecturers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Lecturers_LecturerId",
                table: "Events",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Tutorials_TutorialId",
                table: "Events",
                column: "TutorialId",
                principalTable: "Tutorials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerPlatforms_Lecturers_LecturerId",
                table: "LecturerPlatforms",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerPlatforms_Platform_PlatformId",
                table: "LecturerPlatforms",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Lecturers_LecturerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Tutorials_TutorialId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerPlatforms_Lecturers_LecturerId",
                table: "LecturerPlatforms");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerPlatforms_Platform_PlatformId",
                table: "LecturerPlatforms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tutorials",
                table: "Tutorials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecturers",
                table: "Lecturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LecturerPlatforms",
                table: "LecturerPlatforms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TutorialName",
                table: "Tutorials");

            migrationBuilder.RenameTable(
                name: "Tutorials",
                newName: "Tutorial");

            migrationBuilder.RenameTable(
                name: "Lecturers",
                newName: "Lecturer");

            migrationBuilder.RenameTable(
                name: "LecturerPlatforms",
                newName: "LecturerPlatform");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerPlatforms_PlatformId",
                table: "LecturerPlatform",
                newName: "IX_LecturerPlatform_PlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerPlatforms_LecturerId",
                table: "LecturerPlatform",
                newName: "IX_LecturerPlatform_LecturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_TutorialId",
                table: "Event",
                newName: "IX_Event_TutorialId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_LecturerId",
                table: "Event",
                newName: "IX_Event_LecturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tutorial",
                table: "Tutorial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecturer",
                table: "Lecturer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LecturerPlatform",
                table: "LecturerPlatform",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Lecturer_LecturerId",
                table: "Event",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Tutorial_TutorialId",
                table: "Event",
                column: "TutorialId",
                principalTable: "Tutorial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerPlatform_Lecturer_LecturerId",
                table: "LecturerPlatform",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerPlatform_Platform_PlatformId",
                table: "LecturerPlatform",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
