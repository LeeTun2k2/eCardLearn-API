using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Test",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Test_CourseId",
                table: "Test",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Course_CourseId",
                table: "Test",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Course_CourseId",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_CourseId",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Test");
        }
    }
}
