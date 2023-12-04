using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class OpenTriviaDBCategory_Log : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OpenTriviaDBCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "OpenTriviaDBCategory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "OpenTriviaDBCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "OpenTriviaDBCategory",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OpenTriviaDBCategory");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "OpenTriviaDBCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "OpenTriviaDBCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "OpenTriviaDBCategory");
        }
    }
}
