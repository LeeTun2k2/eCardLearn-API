using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Notifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Course_FeedbackId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentJoinClass_Class_StudentId",
                table: "StudentJoinClass");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentJoinTest_AspNetUsers_StudentId",
                table: "StudentJoinTest");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswer_Question_TestAnswerId",
                table: "TestAnswer");

            migrationBuilder.DropColumn(
                name: "DateEarned",
                table: "Achievement");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId1",
                table: "StudentJoinTest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswer_QuestionId",
                table: "TestAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentJoinTest_StudentId1",
                table: "StudentJoinTest",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentJoinClass_ClassId",
                table: "StudentJoinClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ClassId",
                table: "Notification",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_TeacherId",
                table: "Notification",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CourseId",
                table: "Feedback",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Course_CourseId",
                table: "Feedback",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_TeacherId",
                table: "Notification",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Class_ClassId",
                table: "Notification",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentJoinClass_Class_ClassId",
                table: "StudentJoinClass",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentJoinTest_AspNetUsers_StudentId1",
                table: "StudentJoinTest",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswer_Question_QuestionId",
                table: "TestAnswer",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Course_CourseId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_TeacherId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Class_ClassId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentJoinClass_Class_ClassId",
                table: "StudentJoinClass");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentJoinTest_AspNetUsers_StudentId1",
                table: "StudentJoinTest");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswer_Question_QuestionId",
                table: "TestAnswer");

            migrationBuilder.DropIndex(
                name: "IX_TestAnswer_QuestionId",
                table: "TestAnswer");

            migrationBuilder.DropIndex(
                name: "IX_StudentJoinTest_StudentId1",
                table: "StudentJoinTest");

            migrationBuilder.DropIndex(
                name: "IX_StudentJoinClass_ClassId",
                table: "StudentJoinClass");

            migrationBuilder.DropIndex(
                name: "IX_Notification_ClassId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_TeacherId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_CourseId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "StudentJoinTest");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Notification");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEarned",
                table: "Achievement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Course_FeedbackId",
                table: "Feedback",
                column: "FeedbackId",
                principalTable: "Course",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentJoinClass_Class_StudentId",
                table: "StudentJoinClass",
                column: "StudentId",
                principalTable: "Class",
                principalColumn: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentJoinTest_AspNetUsers_StudentId",
                table: "StudentJoinTest",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswer_Question_TestAnswerId",
                table: "TestAnswer",
                column: "TestAnswerId",
                principalTable: "Question",
                principalColumn: "QuestionId");
        }
    }
}
