using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning.Portal.Migrations
{
    public partial class testsubmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assigns_AspNetUsers_classId",
                table: "Assigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Assigns_AspNetUsers_teacherId",
                table: "Assigns");

            migrationBuilder.DropIndex(
                name: "IX_Assigns_classId",
                table: "Assigns");

            migrationBuilder.DropIndex(
                name: "IX_Assigns_teacherId",
                table: "Assigns");

            migrationBuilder.DropColumn(
                name: "classId",
                table: "Assigns");

            migrationBuilder.DropColumn(
                name: "teacherId",
                table: "Assigns");

            migrationBuilder.AddColumn<string>(
                name: "AssignType",
                table: "Assigns",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubmittedTest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    TestId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedTest_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittedTest_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubmittedTest_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false),
                    answer = table.Column<string>(nullable: true),
                    userId = table.Column<int>(nullable: false),
                    SubmittedTestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_SubmittedTest_SubmittedTestId",
                        column: x => x.SubmittedTestId,
                        principalTable: "SubmittedTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_CreatedById",
                table: "Answer",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_SubmittedTestId",
                table: "Answer",
                column: "SubmittedTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_userId",
                table: "Answer",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedTest_CreatedById",
                table: "SubmittedTest",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedTest_TestId",
                table: "SubmittedTest",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedTest_UserId",
                table: "SubmittedTest",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "SubmittedTest");

            migrationBuilder.DropColumn(
                name: "AssignType",
                table: "Assigns");

            migrationBuilder.AddColumn<int>(
                name: "classId",
                table: "Assigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "teacherId",
                table: "Assigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assigns_classId",
                table: "Assigns",
                column: "classId");

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
                name: "FK_Assigns_AspNetUsers_teacherId",
                table: "Assigns",
                column: "teacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
