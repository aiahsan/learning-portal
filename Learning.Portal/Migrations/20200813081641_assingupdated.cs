using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning.Portal.Migrations
{
    public partial class assingupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assigns_AspNetUsers_assignUserId",
                table: "Assigns");

            migrationBuilder.DropIndex(
                name: "IX_Assigns_assignUserId",
                table: "Assigns");

            migrationBuilder.DropColumn(
                name: "assignUserId",
                table: "Assigns");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "classId",
                table: "Assigns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "parrentId",
                table: "Assigns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "teacherId",
                table: "Assigns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assigns_classId",
                table: "Assigns",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_Assigns_parrentId",
                table: "Assigns",
                column: "parrentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assigns_teacherId",
                table: "Assigns",
                column: "teacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assigns_AspNetUsers_classId",
                table: "Assigns",
                column: "classId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assigns_AspNetUsers_parrentId",
                table: "Assigns",
                column: "parrentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assigns_AspNetUsers_teacherId",
                table: "Assigns",
                column: "teacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assigns_AspNetUsers_classId",
                table: "Assigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Assigns_AspNetUsers_parrentId",
                table: "Assigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Assigns_AspNetUsers_teacherId",
                table: "Assigns");

            migrationBuilder.DropIndex(
                name: "IX_Assigns_classId",
                table: "Assigns");

            migrationBuilder.DropIndex(
                name: "IX_Assigns_parrentId",
                table: "Assigns");

            migrationBuilder.DropIndex(
                name: "IX_Assigns_teacherId",
                table: "Assigns");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "classId",
                table: "Assigns");

            migrationBuilder.DropColumn(
                name: "parrentId",
                table: "Assigns");

            migrationBuilder.DropColumn(
                name: "teacherId",
                table: "Assigns");

            migrationBuilder.AddColumn<int>(
                name: "assignUserId",
                table: "Assigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assigns_assignUserId",
                table: "Assigns",
                column: "assignUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assigns_AspNetUsers_assignUserId",
                table: "Assigns",
                column: "assignUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
