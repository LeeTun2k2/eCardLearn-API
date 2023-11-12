using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Loggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Topic",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Topic",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Topic",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "Topic",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TestAnswer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "TestAnswer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TestAnswer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "TestAnswer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Test",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Test",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Test",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "Test",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "StudentJoinTest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "StudentJoinTest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "StudentJoinTest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "StudentJoinTest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "StudentJoinClass",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "StudentJoinClass",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "StudentJoinClass",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "StudentJoinClass",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Question",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Question",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Question",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "Question",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Notification",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Notification",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Feedback",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Feedback",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Course",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Course",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Course",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "Course",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Class",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Class",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Class",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "Class",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Answer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Answer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Answer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "Answer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Achievement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Achievement",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Achievement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "Achievement",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TestAnswer");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "TestAnswer");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TestAnswer");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "TestAnswer");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "StudentJoinTest");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "StudentJoinTest");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "StudentJoinTest");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "StudentJoinTest");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "StudentJoinClass");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "StudentJoinClass");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "StudentJoinClass");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "StudentJoinClass");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Achievement");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Achievement");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Achievement");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Achievement");
        }
    }
}
