using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Test_Answer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswer_AspNetUsers_TestAnswerId",
                table: "TestAnswer");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswer_StudentId",
                table: "TestAnswer",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswer_AspNetUsers_StudentId",
                table: "TestAnswer",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswer_AspNetUsers_StudentId",
                table: "TestAnswer");

            migrationBuilder.DropIndex(
                name: "IX_TestAnswer_StudentId",
                table: "TestAnswer");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswer_AspNetUsers_TestAnswerId",
                table: "TestAnswer",
                column: "TestAnswerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
