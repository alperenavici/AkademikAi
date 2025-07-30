using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkademikAi.Data.Migrations
{
    /// <inheritdoc />
    public partial class dataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_GeneratedForUserId1",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Users_UserId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPerformanceSummaries_Topics_TopicId",
                table: "UserPerformanceSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPerformanceSummaries_Users_UserId",
                table: "UserPerformanceSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecommendations_Topics_RelatedTopicId",
                table: "UserRecommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecommendations_Users_UserId",
                table: "UserRecommendations");

            migrationBuilder.DropIndex(
                name: "IX_Questions_GeneratedForUserId1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "GeneratedForUserId1",
                table: "Questions");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Users_UserId",
                table: "UserNotifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPerformanceSummaries_Topics_TopicId",
                table: "UserPerformanceSummaries",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPerformanceSummaries_Users_UserId",
                table: "UserPerformanceSummaries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecommendations_Topics_RelatedTopicId",
                table: "UserRecommendations",
                column: "RelatedTopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecommendations_Users_UserId",
                table: "UserRecommendations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Users_UserId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPerformanceSummaries_Topics_TopicId",
                table: "UserPerformanceSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPerformanceSummaries_Users_UserId",
                table: "UserPerformanceSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecommendations_Topics_RelatedTopicId",
                table: "UserRecommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecommendations_Users_UserId",
                table: "UserRecommendations");

            migrationBuilder.AddColumn<Guid>(
                name: "GeneratedForUserId1",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GeneratedForUserId1",
                table: "Questions",
                column: "GeneratedForUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_GeneratedForUserId1",
                table: "Questions",
                column: "GeneratedForUserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Users_UserId",
                table: "UserNotifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPerformanceSummaries_Topics_TopicId",
                table: "UserPerformanceSummaries",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPerformanceSummaries_Users_UserId",
                table: "UserPerformanceSummaries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecommendations_Topics_RelatedTopicId",
                table: "UserRecommendations",
                column: "RelatedTopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecommendations_Users_UserId",
                table: "UserRecommendations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
