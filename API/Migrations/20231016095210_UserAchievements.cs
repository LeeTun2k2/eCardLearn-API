using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UserAchievements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievement_AspNetUsers_UserEarnId",
                table: "Achievement");

            migrationBuilder.DropIndex(
                name: "IX_Achievement_UserEarnId",
                table: "Achievement");

            migrationBuilder.DropColumn(
                name: "UserEarnId",
                table: "Achievement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserEarnId",
                table: "Achievement",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Achievement_UserEarnId",
                table: "Achievement",
                column: "UserEarnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievement_AspNetUsers_UserEarnId",
                table: "Achievement",
                column: "UserEarnId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
