using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UserLoginHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentJoinTest_AspNetUsers_StudentId1",
                table: "StudentJoinTest");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentJoinTest_Test_StudentId",
                table: "StudentJoinTest");

            migrationBuilder.DropIndex(
                name: "IX_StudentJoinTest_StudentId1",
                table: "StudentJoinTest");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "StudentJoinTest");

            migrationBuilder.CreateTable(
                name: "UserLoginHistory",
                columns: table => new
                {
                    UserLoginHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginHistory", x => x.UserLoginHistoryId);
                    table.ForeignKey(
                        name: "FK_UserLoginHistory_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentJoinTest_TestId",
                table: "StudentJoinTest",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginHistory_UserId",
                table: "UserLoginHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentJoinTest_AspNetUsers_StudentId",
                table: "StudentJoinTest",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentJoinTest_Test_TestId",
                table: "StudentJoinTest",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentJoinTest_AspNetUsers_StudentId",
                table: "StudentJoinTest");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentJoinTest_Test_TestId",
                table: "StudentJoinTest");

            migrationBuilder.DropTable(
                name: "UserLoginHistory");

            migrationBuilder.DropIndex(
                name: "IX_StudentJoinTest_TestId",
                table: "StudentJoinTest");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId1",
                table: "StudentJoinTest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StudentJoinTest_StudentId1",
                table: "StudentJoinTest",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentJoinTest_AspNetUsers_StudentId1",
                table: "StudentJoinTest",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentJoinTest_Test_StudentId",
                table: "StudentJoinTest",
                column: "StudentId",
                principalTable: "Test",
                principalColumn: "TestId");
        }
    }
}
