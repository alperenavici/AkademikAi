using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AkademikAi.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SolutionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneratedForUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_GeneratedForUserId",
                        column: x => x.GeneratedForUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Topics_Topics_ParentTopicId",
                        column: x => x.ParentTopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamParticipants",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TimeStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimFinished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: true),
                    TimeFinished = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamParticipants", x => new { x.UserId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_ExamParticipants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamParticipants_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestions",
                columns: table => new
                {
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestions", x => new { x.ExamId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    OptionOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectedOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    AnsweredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAnswer = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAnswers_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsTopics",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsTopics", x => new { x.QuestionId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_QuestionsTopics_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionsTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPerformanceSummaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalQuestionsAnswered = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    SuccessRate = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPerformanceSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPerformanceSummaries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPerformanceSummaries_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRecommendations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecommendationType = table.Column<int>(type: "int", nullable: false),
                    RecommendationText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsApplied = table.Column<bool>(type: "bit", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppliedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelatedTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRecommendations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRecommendations_Topics_RelatedTopicId",
                        column: x => x.RelatedTopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "dummy-conc-1", new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(7932), "ali@example.com", true, false, null, "Ali", "ALI@EXAMPLE.COM", "ALI", "AQAAAAEAACcQAAAAEDummyHash1==", "5551111111", false, "dummy-stamp-1", "Veli", false, "ali", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "dummy-conc-2", new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(7940), "ayse@example.com", true, false, null, "Ayşe", "AYSE@EXAMPLE.COM", "AYSE", "AQAAAAEAACcQAAAAEDummyHash2==", "5552222222", false, "dummy-stamp-2", "Yılmaz", false, "ayse", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "dummy-conc-3", new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(7957), "mehmet@example.com", true, false, null, "Mehmet", "MEHMET@EXAMPLE.COM", "MEHMET", "AQAAAAEAACcQAAAAEDummyHash3==", "5553333333", false, "dummy-stamp-3", "Demir", false, "mehmet", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevel", "GeneratedForUserId", "IsActive", "QuestionText", "SolutionText", "Source" },
                values: new object[,]
                {
                    { new Guid("00522113-efda-4ad8-a678-08e46ed8f908"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("00a5a7cc-d700-4047-a001-0715c59efce6"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("01d0fae6-988b-4ab4-b871-a3a1f2bf0026"), 2, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("05018417-44d9-4d88-8b6c-b13107139d80"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0537b1a5-7843-4b15-b2fd-063f548e758a"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("061e5584-20d9-4b6f-8e80-22d13aeff091"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0cade99a-4b3b-456a-93f0-4803611a4fee"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0f6add61-f758-47f4-a849-ae37b945f078"), 2, null, true, "Hücre konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0fe84234-f8ec-4d7d-afed-aebb63c44b75"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("115f50c2-a0a2-4b77-a0e0-fecd916e4082"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1343e84a-8f1c-4c84-96fa-84645993c916"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("14298159-2798-4934-ae15-7dc3bf8a6628"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("23e14845-44fd-4ea9-90bb-12a3225d26f6"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2a1aaaf7-504e-4fe7-b7d1-2afcc528cffe"), 1, null, true, "Hücre konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2b682a58-cfe2-479f-903e-a83a83998673"), 2, null, true, "Kalıtım konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2c99bf4b-4b86-407f-ac8c-ef67b91acb6c"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2cc1e90e-9dcf-4919-8019-e94c4f1b078a"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("31f33055-9623-4955-85ad-cc8e5f4edfed"), 0, null, true, "Kalıtım konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("38260470-5cbf-4743-ab69-765dc40de4a0"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("391ba056-81fb-4b36-972c-3de42c6433d2"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3bc71377-aa32-4956-a911-b2b2c43ed1d1"), 2, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3fc78ff9-4225-46b0-8da4-79259b24ae3d"), 2, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4206fdd8-ce7f-4212-b638-081dbdfb1cc1"), 2, null, true, "Kimya Bilimi konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4476a0f3-6ae8-4aae-82e6-35ebed0ad652"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4ae9ed05-362b-49bb-a543-5a1a0ed937f0"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4b215ac5-d1f1-43ad-9bf2-868c3a641d3a"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4bdecb09-add9-4066-be2e-9315cfeaa2e9"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("52781163-57f9-497c-9f9e-7b00b4df3296"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("527d0531-b642-4376-ba4e-288465146472"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("54a0b13d-c08f-442a-935d-e708980543a3"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("59f10719-6377-4c5c-a5be-c464d7105b97"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5bb3e550-af73-4905-843f-6251b4e87035"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5bc2a13b-cdf8-4cdf-9eac-088951c30eab"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5d5e63e2-3266-4368-86fd-5b096871a95e"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5dea75e3-7347-4e09-b37a-3d34961aa81f"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6000bb5b-92cb-4ef1-bce9-caa2f0f3883b"), 2, null, true, "Elektrostatik konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("61bf1fcf-a3ed-4877-8fa7-64b7740b6f60"), 2, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("62150815-5cbb-4073-a390-7e7107ffffa6"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("67273a1e-a542-47b9-9af4-4d7b0a6c13e6"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("698c5f36-fa6c-4112-852d-736894a0094c"), 2, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6e3508db-77a4-402b-8a73-8e3c5987c6b4"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6eaa8010-fc30-4cff-ba48-b450cabdd49d"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("700dbf77-fb4f-4ec5-9ff4-cf1fc67eb748"), 2, null, true, "Maddenin Halleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("71162cf4-c4ce-49b3-9fb9-dd1976a17780"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7120f24a-7c2d-433c-ac25-bfc54adb5c09"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7326d5de-10ee-40e8-8175-de72762ef3b5"), 2, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("73aec0f7-fe81-436d-9119-67095fdd771d"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("73fade28-7a91-4fd4-97fe-eddc318a82b1"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7a479a6d-2b76-4829-b36c-e8ddc6d01274"), 2, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7d61908c-658f-4c5e-a415-0df92d34a1f5"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("81193809-21ec-46b6-95a8-a8b6f5821ce7"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("855e1d1a-cf09-4d42-a15c-145d6e4e49a6"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8676e448-8f4b-4278-a012-9625ae7ae2d9"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("86d145d9-6295-4d8e-b83d-177dc4595a11"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("88655708-41a1-40e3-ac99-4a15bdc16e58"), 0, null, true, "Hücre konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("89052a55-0088-42b5-b731-eb402aee8177"), 1, null, true, "Hücre konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8d4a4dd0-8cc8-4341-abe8-c4ba807ce865"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9057160d-daaf-48ce-9c87-0e1e3a36d1dc"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9517041e-597e-4060-9183-e3b19c9e7dd4"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("965087d6-1156-4db7-8d1e-2b427c66b61b"), 2, null, true, "Temel Kavramlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("991b6364-49f0-4c87-9a3f-6b3de4c4fd0a"), 1, null, true, "Kalıtım konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9982a47a-de37-4c29-961b-99e20475bb4d"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a55fb445-12b7-4795-a194-c320813b75c9"), 0, null, true, "Problemler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a5ed8b8e-49b4-48d4-8b6a-97acf5cf433e"), 0, null, true, "Kalıtım konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ac0e6084-d528-40a0-b86f-54ef587cdf37"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("acb167b0-10ca-44c0-a813-5d8d95c9118e"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ae0a17af-ec8b-4d22-a6fd-2530357645ab"), 2, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("af8ec252-68a1-4d7a-a20f-f26c9d51c288"), 2, null, true, "Sayı Basamakları konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b1208c45-ccce-4d19-afde-55830af7e038"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b48a2a2f-cdaf-4bb3-9375-2d45b8765d95"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c0369b0b-eb45-4a3f-a5c1-2198fcea7210"), 0, null, true, "Hücre konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c257e924-7359-4323-9ac6-c0d2e73104d9"), 2, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c360b67e-86a8-415a-9392-7647c98d9a1d"), 1, null, true, "Problemler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c3a89410-228c-46a9-a554-ef369a58a423"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c5008799-6143-4c13-b9e3-0293f3f966d7"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c8409986-58b9-4ea7-bdd4-1146d8efff6f"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("cdaaf8b7-fa81-43f6-919d-077b1cee8fb7"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d09d77db-52b4-402d-adf8-a4af998b7fcb"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d0cd527a-4750-4d93-b5fb-e16a44cdcdbd"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d0d1eb8c-c0ea-44f6-bef8-a8a91581c88f"), 1, null, true, "Kalıtım konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d2cb69e2-ff30-41aa-9542-458c7d31ac77"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d3b6b741-1cec-4aaf-953e-ce043dcf8534"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d63ca04f-3510-40be-8dc1-56e391ca5d37"), 2, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d7480b02-62be-4240-b715-a66fe7779f34"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d7de5162-b1d3-41cf-885c-ee05446e92b8"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d91c6a3a-8352-4524-8fe5-66d430868086"), 2, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("de51d4fa-7451-4cc7-8857-194ceee47790"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("deb532ae-b0d5-4128-92b6-683c472602a0"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("dee65a24-d761-4aa6-b22b-45631891858a"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("def81b2f-e674-4094-bc93-b07149939186"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e70e2454-38e8-4fe1-b6de-1d296395e315"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e95cc1b1-3397-4962-a6f4-38c56e9c6533"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ebb6b7a8-b11a-408a-aa72-922593f9f918"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("edef1b0e-a044-4e86-961d-290fb1a6f019"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("eebeb93e-fdf3-4bb1-914f-9852c5c083a3"), 2, null, true, "Problemler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f1f41c31-bc43-4efc-91c2-c913a7cffd29"), 1, null, true, "Problemler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f251e56e-29ea-4910-bcbe-1e9c87b396f9"), 2, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fa58b629-38de-436a-b520-ec17a7ed47b0"), 0, null, true, "Problemler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("faf94cf2-b292-4483-8a63-53b2f3073ab4"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fe40dcf9-a746-488d-a0be-ae09e3b61eb5"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8056), "Temel kimya konuları", true, "Kimya" },
                    { new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8054), "Temel fizik konuları", true, "Fizik" },
                    { new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8058), "Temel biyoloji konuları", true, "Biyoloji" },
                    { new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8050), "Temel matematik konuları", true, "Matematik" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "IsCorrect", "Label", "OptionOrder", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("0131b9bf-5586-45a6-bae0-fe9ae056a088"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek B", new Guid("def81b2f-e674-4094-bc93-b07149939186") },
                    { new Guid("0201cd01-d4eb-4b67-81a8-3c7c76cb5bf9"), true, "B", 2, "Canlıların Sınıflandırılması - Soru 1 için Seçenek B", new Guid("c3a89410-228c-46a9-a554-ef369a58a423") },
                    { new Guid("02206d75-1cf9-4e1b-9137-c5cc48154397"), false, "D", 4, "Kuvvet ve Hareket - Soru 3 için Seçenek D", new Guid("38260470-5cbf-4743-ab69-765dc40de4a0") },
                    { new Guid("022ccbb7-4364-465a-80b7-bab44d1033e1"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek D", new Guid("3fc78ff9-4225-46b0-8da4-79259b24ae3d") },
                    { new Guid("044caf0f-ee2e-4b74-8928-e30f51900fa1"), false, "B", 2, "Madde ve Özellikleri - Soru 3 için Seçenek B", new Guid("527d0531-b642-4376-ba4e-288465146472") },
                    { new Guid("0479ee9d-3e12-4d0a-862f-308604c0cf92"), true, "A", 1, "Hücre - Soru 5 için Seçenek A", new Guid("0f6add61-f758-47f4-a849-ae37b945f078") },
                    { new Guid("05402d36-42da-469d-b35e-828b88e87133"), false, "C", 3, "İş, Güç ve Enerji - Soru 4 için Seçenek C", new Guid("4ae9ed05-362b-49bb-a543-5a1a0ed937f0") },
                    { new Guid("0573f0a7-5f45-494a-a268-e4848f7b7573"), false, "A", 1, "Sayı Basamakları - Soru 4 için Seçenek A", new Guid("0537b1a5-7843-4b15-b2fd-063f548e758a") },
                    { new Guid("05984ca6-47da-46c0-abc2-6280095f37aa"), true, "A", 1, "Kuvvet ve Hareket - Soru 4 için Seçenek A", new Guid("ebb6b7a8-b11a-408a-aa72-922593f9f918") },
                    { new Guid("07ea5add-8c51-4f81-9b9e-93484df7b359"), true, "A", 1, "Rasyonel Sayılar - Soru 4 için Seçenek A", new Guid("d2cb69e2-ff30-41aa-9542-458c7d31ac77") },
                    { new Guid("09100484-9fd1-438b-82fe-660a3dcc449e"), true, "D", 4, "Elektrostatik - Soru 5 için Seçenek D", new Guid("6000bb5b-92cb-4ef1-bce9-caa2f0f3883b") },
                    { new Guid("091ec471-b6ca-466d-a11f-e28ab675e155"), false, "B", 2, "Kuvvet ve Hareket - Soru 4 için Seçenek B", new Guid("ebb6b7a8-b11a-408a-aa72-922593f9f918") },
                    { new Guid("0938e66e-455a-482f-8b34-4c1f87c1cae6"), false, "B", 2, "İş, Güç ve Enerji - Soru 3 için Seçenek B", new Guid("8676e448-8f4b-4278-a012-9625ae7ae2d9") },
                    { new Guid("0990d94f-6ea9-4148-8101-67c4e5549636"), true, "D", 4, "Sayı Basamakları - Soru 1 için Seçenek D", new Guid("6e3508db-77a4-402b-8a73-8e3c5987c6b4") },
                    { new Guid("0a3e9dfc-340b-40ab-afcb-5244cdbbb768"), false, "D", 4, "Kalıtım - Soru 1 için Seçenek D", new Guid("a5ed8b8e-49b4-48d4-8b6a-97acf5cf433e") },
                    { new Guid("0b244bb7-ca20-459a-8a6f-d0e7eeafcb27"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 1 için Seçenek B", new Guid("4bdecb09-add9-4066-be2e-9315cfeaa2e9") },
                    { new Guid("0b6bb2b0-4895-40a8-8b7f-c81933235b11"), false, "A", 1, "Maddenin Halleri - Soru 3 için Seçenek A", new Guid("d7de5162-b1d3-41cf-885c-ee05446e92b8") },
                    { new Guid("0d78755b-fc38-4ef2-a73c-b5a47dc9587d"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 4 için Seçenek C", new Guid("ac0e6084-d528-40a0-b86f-54ef587cdf37") },
                    { new Guid("0d921a40-9871-4031-9cd6-9327d73a58e7"), false, "B", 2, "Sayı Basamakları - Soru 1 için Seçenek B", new Guid("6e3508db-77a4-402b-8a73-8e3c5987c6b4") },
                    { new Guid("0de861b7-5567-4646-8853-0f2e7cdfce91"), false, "D", 4, "Hücre - Soru 3 için Seçenek D", new Guid("c0369b0b-eb45-4a3f-a5c1-2198fcea7210") },
                    { new Guid("0e0f1ccb-9309-4416-bfa4-f8e974d336ba"), false, "C", 3, "Temel Kavramlar - Soru 2 için Seçenek C", new Guid("faf94cf2-b292-4483-8a63-53b2f3073ab4") },
                    { new Guid("0f2386d0-c5bf-4e40-b139-02ea71ca53e8"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek B", new Guid("b48a2a2f-cdaf-4bb3-9375-2d45b8765d95") },
                    { new Guid("10223960-15b1-4cc9-8591-59ccb23eea5d"), false, "C", 3, "Problemler - Soru 1 için Seçenek C", new Guid("fa58b629-38de-436a-b520-ec17a7ed47b0") },
                    { new Guid("107445d6-6d2a-458b-8097-77845adec885"), true, "A", 1, "Bölme ve Bölünebilme - Soru 4 için Seçenek A", new Guid("dee65a24-d761-4aa6-b22b-45631891858a") },
                    { new Guid("10d9987c-3d97-4d9c-b740-c65f6236efd2"), false, "D", 4, "Elektrostatik - Soru 1 için Seçenek D", new Guid("d3b6b741-1cec-4aaf-953e-ce043dcf8534") },
                    { new Guid("11914736-1de9-4143-ad0b-ccc3b5a5dd9f"), false, "A", 1, "Kuvvet ve Hareket - Soru 1 için Seçenek A", new Guid("00522113-efda-4ad8-a678-08e46ed8f908") },
                    { new Guid("12034974-c5fa-4a6c-8c6a-e3bb259d18c7"), false, "A", 1, "Sayı Basamakları - Soru 3 için Seçenek A", new Guid("23e14845-44fd-4ea9-90bb-12a3225d26f6") },
                    { new Guid("12514442-a449-4db6-9015-2d253072c63f"), true, "D", 4, "Hücre - Soru 4 için Seçenek D", new Guid("89052a55-0088-42b5-b731-eb402aee8177") },
                    { new Guid("139b308a-0012-48a4-b1e3-cad36be9ce6c"), true, "D", 4, "Sayı Basamakları - Soru 5 için Seçenek D", new Guid("af8ec252-68a1-4d7a-a20f-f26c9d51c288") },
                    { new Guid("14851f95-d7ee-4762-aaf4-1686c72bce21"), false, "D", 4, "Kuvvet ve Hareket - Soru 4 için Seçenek D", new Guid("ebb6b7a8-b11a-408a-aa72-922593f9f918") },
                    { new Guid("14edfee8-9953-4914-9ac0-5ec5606c71f1"), false, "A", 1, "Hücre Bölünmeleri - Soru 1 için Seçenek A", new Guid("00a5a7cc-d700-4047-a001-0715c59efce6") },
                    { new Guid("1529200e-e094-426f-932e-e6b7f799962e"), false, "B", 2, "Rasyonel Sayılar - Soru 5 için Seçenek B", new Guid("c257e924-7359-4323-9ac6-c0d2e73104d9") },
                    { new Guid("15dade37-978f-4ccc-8d65-6083633ccebe"), false, "C", 3, "Sayı Basamakları - Soru 5 için Seçenek C", new Guid("af8ec252-68a1-4d7a-a20f-f26c9d51c288") },
                    { new Guid("1686eda4-d427-4960-9801-92bfa75c54fb"), false, "C", 3, "Elektrostatik - Soru 1 için Seçenek C", new Guid("d3b6b741-1cec-4aaf-953e-ce043dcf8534") },
                    { new Guid("17bb5bc2-8336-4cdc-9c82-6d0c2267244b"), false, "B", 2, "Elektrostatik - Soru 4 için Seçenek B", new Guid("4476a0f3-6ae8-4aae-82e6-35ebed0ad652") },
                    { new Guid("182e53f9-61af-45e8-bac5-421c0282d410"), false, "B", 2, "Hücre Bölünmeleri - Soru 3 için Seçenek B", new Guid("c5008799-6143-4c13-b9e3-0293f3f966d7") },
                    { new Guid("18a78e4f-0fee-47ca-b592-355041c8fd07"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek C", new Guid("67273a1e-a542-47b9-9af4-4d7b0a6c13e6") },
                    { new Guid("191ad879-e31e-4a4c-adc7-6f0781164bf4"), true, "A", 1, "Rasyonel Sayılar - Soru 1 için Seçenek A", new Guid("115f50c2-a0a2-4b77-a0e0-fecd916e4082") },
                    { new Guid("19f6b169-24ad-4ed3-bbcb-5d5d057cde35"), false, "B", 2, "Kuvvet ve Hareket - Soru 5 için Seçenek B", new Guid("3bc71377-aa32-4956-a911-b2b2c43ed1d1") },
                    { new Guid("1a4551e2-d7f2-4afb-abab-21195c33523b"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 2 için Seçenek D", new Guid("391ba056-81fb-4b36-972c-3de42c6433d2") },
                    { new Guid("1a965ef5-dad6-4886-9eaa-254f6b90dfb7"), false, "A", 1, "Madde ve Özellikleri - Soru 1 için Seçenek A", new Guid("73aec0f7-fe81-436d-9119-67095fdd771d") },
                    { new Guid("1aaaa042-983d-4b04-8293-cf820be8edfb"), false, "D", 4, "Bölme ve Bölünebilme - Soru 4 için Seçenek D", new Guid("dee65a24-d761-4aa6-b22b-45631891858a") },
                    { new Guid("1b525344-e12d-4682-a2e1-c453114fc7ac"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek B", new Guid("3fc78ff9-4225-46b0-8da4-79259b24ae3d") },
                    { new Guid("1c58f041-99a7-4b6c-b6a3-d2cda13a6804"), false, "B", 2, "Problemler - Soru 2 için Seçenek B", new Guid("f1f41c31-bc43-4efc-91c2-c913a7cffd29") },
                    { new Guid("1d173989-326f-4f5d-8761-f4dafcd738c3"), false, "B", 2, "Temel Kavramlar - Soru 5 için Seçenek B", new Guid("965087d6-1156-4db7-8d1e-2b427c66b61b") },
                    { new Guid("1d29e0ba-69d4-4a26-8bfc-e6c9fa6983bd"), true, "B", 2, "Hücre Bölünmeleri - Soru 2 için Seçenek B", new Guid("05018417-44d9-4d88-8b6c-b13107139d80") },
                    { new Guid("1d359acc-8a66-4c64-9d94-3d85be1224f2"), false, "B", 2, "Problemler - Soru 1 için Seçenek B", new Guid("fa58b629-38de-436a-b520-ec17a7ed47b0") },
                    { new Guid("1d58fe24-e8bc-40e2-a83f-c97ef6a067c3"), true, "D", 4, "Kuvvet ve Hareket - Soru 5 için Seçenek D", new Guid("3bc71377-aa32-4956-a911-b2b2c43ed1d1") },
                    { new Guid("1d5cb5ac-3584-4afa-b02f-d1010402a1e0"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 4 için Seçenek B", new Guid("ac0e6084-d528-40a0-b86f-54ef587cdf37") },
                    { new Guid("1d68dc9c-0c00-4278-99f2-0d2d20a2d0cf"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek D", new Guid("9517041e-597e-4060-9183-e3b19c9e7dd4") },
                    { new Guid("1e30285c-eff3-4095-8d9e-59fdf7b26279"), true, "D", 4, "Kuvvet ve Hareket - Soru 2 için Seçenek D", new Guid("7120f24a-7c2d-433c-ac25-bfc54adb5c09") },
                    { new Guid("1eb8473e-af86-4c39-a7b4-6838c87f4add"), false, "A", 1, "Problemler - Soru 3 için Seçenek A", new Guid("a55fb445-12b7-4795-a194-c320813b75c9") },
                    { new Guid("1f11db21-a304-45c1-9b6c-a4c2e61910c3"), true, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek B", new Guid("9517041e-597e-4060-9183-e3b19c9e7dd4") },
                    { new Guid("20095458-8a13-4eeb-a2df-34824cbc6204"), true, "C", 3, "İş, Güç ve Enerji - Soru 5 için Seçenek C", new Guid("ae0a17af-ec8b-4d22-a6fd-2530357645ab") },
                    { new Guid("21417361-9f9e-4fdd-ae46-0d38df895f40"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek A", new Guid("52781163-57f9-497c-9f9e-7b00b4df3296") },
                    { new Guid("221a05d7-acf9-4f23-a7fa-fb6cc42d080d"), true, "A", 1, "Canlıların Sınıflandırılması - Soru 2 için Seçenek A", new Guid("391ba056-81fb-4b36-972c-3de42c6433d2") },
                    { new Guid("22a575ad-95ff-4df6-b2f7-cbee37d4271b"), true, "A", 1, "Kalıtım - Soru 5 için Seçenek A", new Guid("2b682a58-cfe2-479f-903e-a83a83998673") },
                    { new Guid("22ac180f-f9a6-4bc7-b861-995370d834cb"), false, "B", 2, "Kalıtım - Soru 5 için Seçenek B", new Guid("2b682a58-cfe2-479f-903e-a83a83998673") },
                    { new Guid("23bfe9eb-c9fa-46c3-a363-a94c98a681d9"), false, "A", 1, "Temel Kavramlar - Soru 4 için Seçenek A", new Guid("62150815-5cbb-4073-a390-7e7107ffffa6") },
                    { new Guid("259c62a2-6f6f-49a0-80eb-891605ed023a"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek C", new Guid("def81b2f-e674-4094-bc93-b07149939186") },
                    { new Guid("265e0a63-1da8-4048-82ea-9283f3a8b9d4"), true, "C", 3, "Hücre Bölünmeleri - Soru 1 için Seçenek C", new Guid("00a5a7cc-d700-4047-a001-0715c59efce6") },
                    { new Guid("2755f778-1da7-422c-9962-7254293ee75f"), false, "C", 3, "Hücre - Soru 4 için Seçenek C", new Guid("89052a55-0088-42b5-b731-eb402aee8177") },
                    { new Guid("27e3f4c7-c80d-4ca8-b5a7-618b7baa9d02"), false, "B", 2, "İş, Güç ve Enerji - Soru 2 için Seçenek B", new Guid("86d145d9-6295-4d8e-b83d-177dc4595a11") },
                    { new Guid("28b1d64a-8037-47b5-9089-26533ac2ce35"), false, "C", 3, "Temel Kavramlar - Soru 5 için Seçenek C", new Guid("965087d6-1156-4db7-8d1e-2b427c66b61b") },
                    { new Guid("2be56766-3381-4154-8815-db0e1d255330"), false, "C", 3, "Kalıtım - Soru 3 için Seçenek C", new Guid("31f33055-9623-4955-85ad-cc8e5f4edfed") },
                    { new Guid("2c0f7aaa-42b6-430d-a9fa-a08b385c2142"), true, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek C", new Guid("f251e56e-29ea-4910-bcbe-1e9c87b396f9") },
                    { new Guid("2d438b73-f604-41c7-886f-79237854ffde"), false, "B", 2, "Madde ve Özellikleri - Soru 1 için Seçenek B", new Guid("73aec0f7-fe81-436d-9119-67095fdd771d") },
                    { new Guid("2f6174b2-a87d-41e0-9a73-3a487cc024aa"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 2 için Seçenek D", new Guid("fe40dcf9-a746-488d-a0be-ae09e3b61eb5") },
                    { new Guid("3000b6ef-1fc6-4c59-970b-f4e1fe63910b"), false, "B", 2, "Kuvvet ve Hareket - Soru 3 için Seçenek B", new Guid("38260470-5cbf-4743-ab69-765dc40de4a0") },
                    { new Guid("314b0eb9-8980-49e5-a609-1cefbecbccfb"), true, "B", 2, "Sayı Basamakları - Soru 3 için Seçenek B", new Guid("23e14845-44fd-4ea9-90bb-12a3225d26f6") },
                    { new Guid("320e12d7-91e3-4ccd-a2fc-1d4f8d8b777f"), false, "C", 3, "Madde ve Özellikleri - Soru 5 için Seçenek C", new Guid("7326d5de-10ee-40e8-8175-de72762ef3b5") },
                    { new Guid("32809692-e9c4-45b9-b049-421047261490"), false, "C", 3, "Madde ve Özellikleri - Soru 2 için Seçenek C", new Guid("de51d4fa-7451-4cc7-8857-194ceee47790") },
                    { new Guid("33583bf9-8996-4f1c-a0ab-4e11a9299221"), false, "D", 4, "Hücre Bölünmeleri - Soru 3 için Seçenek D", new Guid("c5008799-6143-4c13-b9e3-0293f3f966d7") },
                    { new Guid("336c99fc-d6cd-40e9-9d17-a9395ea5b247"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek B", new Guid("acb167b0-10ca-44c0-a813-5d8d95c9118e") },
                    { new Guid("34753f96-dcda-4c6b-99b1-81317568c9ae"), true, "D", 4, "Kimya Bilimi - Soru 3 için Seçenek D", new Guid("5bc2a13b-cdf8-4cdf-9eac-088951c30eab") },
                    { new Guid("347e38c8-e820-4e8c-b513-9c2a76abfbd3"), false, "B", 2, "Kimya Bilimi - Soru 2 için Seçenek B", new Guid("edef1b0e-a044-4e86-961d-290fb1a6f019") },
                    { new Guid("349b201e-7d84-4bee-b4d5-0a6d6a3c6d25"), true, "B", 2, "İş, Güç ve Enerji - Soru 4 için Seçenek B", new Guid("4ae9ed05-362b-49bb-a543-5a1a0ed937f0") },
                    { new Guid("34a477bf-cf68-4a92-a3e9-206ce7934482"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek A", new Guid("73fade28-7a91-4fd4-97fe-eddc318a82b1") },
                    { new Guid("34be7edd-71a3-4f03-a47d-04fcd9ba462d"), false, "D", 4, "Rasyonel Sayılar - Soru 5 için Seçenek D", new Guid("c257e924-7359-4323-9ac6-c0d2e73104d9") },
                    { new Guid("36335160-0994-49b9-a72b-852dbcb74c4e"), true, "C", 3, "Kimya Bilimi - Soru 4 için Seçenek C", new Guid("1343e84a-8f1c-4c84-96fa-84645993c916") },
                    { new Guid("36e7514d-beb0-40cb-a10c-1a2bcf501422"), false, "C", 3, "Kalıtım - Soru 5 için Seçenek C", new Guid("2b682a58-cfe2-479f-903e-a83a83998673") },
                    { new Guid("37c77a01-41df-4174-b67a-72806444d825"), true, "A", 1, "Kimya Bilimi - Soru 5 için Seçenek A", new Guid("4206fdd8-ce7f-4212-b638-081dbdfb1cc1") },
                    { new Guid("387808cc-afac-4f1b-b5b9-dbd2040eafdf"), true, "B", 2, "Fizik Bilimine Giriş - Soru 3 için Seçenek B", new Guid("b1208c45-ccce-4d19-afde-55830af7e038") },
                    { new Guid("38f2f542-8e7f-4aa1-9be6-eae6b5d300ad"), false, "C", 3, "Kuvvet ve Hareket - Soru 3 için Seçenek C", new Guid("38260470-5cbf-4743-ab69-765dc40de4a0") },
                    { new Guid("3a1e998c-3a9c-4f3c-8778-03d26cd71b97"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek C", new Guid("52781163-57f9-497c-9f9e-7b00b4df3296") },
                    { new Guid("3a3c17df-5b4d-4f66-a24f-12fc261dc773"), true, "C", 3, "Maddenin Halleri - Soru 1 için Seçenek C", new Guid("5bb3e550-af73-4905-843f-6251b4e87035") },
                    { new Guid("3bb279e9-5444-4dbf-8e85-54d985d6630e"), true, "D", 4, "Madde ve Özellikleri - Soru 5 için Seçenek D", new Guid("7326d5de-10ee-40e8-8175-de72762ef3b5") },
                    { new Guid("3c3212fd-9973-459e-828c-a5390fb57e84"), false, "C", 3, "Kimya Bilimi - Soru 1 için Seçenek C", new Guid("d0cd527a-4750-4d93-b5fb-e16a44cdcdbd") },
                    { new Guid("3d46ad34-623e-4b5e-b2a1-32a054217be5"), true, "D", 4, "Problemler - Soru 3 için Seçenek D", new Guid("a55fb445-12b7-4795-a194-c320813b75c9") },
                    { new Guid("3e50a443-38e6-4ba0-baec-dc9ba117cda7"), true, "A", 1, "Madde ve Özellikleri - Soru 3 için Seçenek A", new Guid("527d0531-b642-4376-ba4e-288465146472") },
                    { new Guid("3e9b3c26-01bb-4336-a583-1f7d1aee4077"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 2 için Seçenek B", new Guid("391ba056-81fb-4b36-972c-3de42c6433d2") },
                    { new Guid("3eb5da4f-afcf-432b-afa0-1ce745cd36f4"), false, "A", 1, "Rasyonel Sayılar - Soru 3 için Seçenek A", new Guid("061e5584-20d9-4b6f-8e80-22d13aeff091") },
                    { new Guid("3edc7c3b-55fb-47fe-9ba5-b69e8a360616"), false, "B", 2, "Hücre - Soru 1 için Seçenek B", new Guid("88655708-41a1-40e3-ac99-4a15bdc16e58") },
                    { new Guid("3f531651-736e-4c07-9ec0-23b7d0ce0cb9"), false, "D", 4, "Kalıtım - Soru 5 için Seçenek D", new Guid("2b682a58-cfe2-479f-903e-a83a83998673") },
                    { new Guid("3f9b8b7d-313a-4a6d-beab-3047ac907258"), false, "B", 2, "Bölme ve Bölünebilme - Soru 2 için Seçenek B", new Guid("2c99bf4b-4b86-407f-ac8c-ef67b91acb6c") },
                    { new Guid("4038ed2a-42db-482c-975e-e9dfac43f9d3"), false, "B", 2, "Kalıtım - Soru 4 için Seçenek B", new Guid("d0d1eb8c-c0ea-44f6-bef8-a8a91581c88f") },
                    { new Guid("404b4506-c9f5-4d0f-9ee0-eeb7c614a38f"), true, "B", 2, "Problemler - Soru 5 için Seçenek B", new Guid("eebeb93e-fdf3-4bb1-914f-9852c5c083a3") },
                    { new Guid("410f1d29-3eb1-4d92-bfb7-226e0c99b1e6"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 5 için Seçenek D", new Guid("d91c6a3a-8352-4524-8fe5-66d430868086") },
                    { new Guid("411e7510-43bb-4ec1-b37a-7e6241578951"), true, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek B", new Guid("67273a1e-a542-47b9-9af4-4d7b0a6c13e6") },
                    { new Guid("41368d3b-5677-4d8e-9a42-00c975f1ff09"), false, "B", 2, "Problemler - Soru 3 için Seçenek B", new Guid("a55fb445-12b7-4795-a194-c320813b75c9") },
                    { new Guid("41595720-61cc-497a-ae9d-b672c1fe3af4"), true, "A", 1, "Canlıların Sınıflandırılması - Soru 4 için Seçenek A", new Guid("ac0e6084-d528-40a0-b86f-54ef587cdf37") },
                    { new Guid("4168f80e-497d-4c2a-9348-14e0a3f4e7c4"), false, "B", 2, "Bölme ve Bölünebilme - Soru 1 için Seçenek B", new Guid("14298159-2798-4934-ae15-7dc3bf8a6628") },
                    { new Guid("41dfce65-8716-4544-aa78-121f169fefd9"), false, "D", 4, "Bölme ve Bölünebilme - Soru 3 için Seçenek D", new Guid("2cc1e90e-9dcf-4919-8019-e94c4f1b078a") },
                    { new Guid("4283fd41-5b11-42ac-b669-ed0a6e2ea8d5"), false, "D", 4, "Elektrostatik - Soru 3 için Seçenek D", new Guid("5dea75e3-7347-4e09-b37a-3d34961aa81f") },
                    { new Guid("44b62e02-4444-4264-a603-c187e7ec0d40"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek B", new Guid("7a479a6d-2b76-4829-b36c-e8ddc6d01274") },
                    { new Guid("44fa06ba-5698-452a-8964-a86d7d2006d9"), false, "A", 1, "Hücre Bölünmeleri - Soru 4 için Seçenek A", new Guid("54a0b13d-c08f-442a-935d-e708980543a3") },
                    { new Guid("45df4f7d-a687-46d3-b144-8ee2a4be2418"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek D", new Guid("73fade28-7a91-4fd4-97fe-eddc318a82b1") },
                    { new Guid("46ce6073-63b4-4405-a65b-b21228e7d305"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek A", new Guid("f251e56e-29ea-4910-bcbe-1e9c87b396f9") },
                    { new Guid("46ff8688-928c-493e-824a-16934b83b8df"), true, "B", 2, "Elektrostatik - Soru 2 için Seçenek B", new Guid("9982a47a-de37-4c29-961b-99e20475bb4d") },
                    { new Guid("478016f0-f769-4dfa-8c81-3a6fa6b7a34d"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek A", new Guid("c8409986-58b9-4ea7-bdd4-1146d8efff6f") },
                    { new Guid("49b62bd2-9982-434d-8205-e30cd6126043"), false, "C", 3, "Hücre - Soru 2 için Seçenek C", new Guid("2a1aaaf7-504e-4fe7-b7d1-2afcc528cffe") },
                    { new Guid("4abd609f-c2f1-4c8f-8377-8cdbfb93a956"), false, "A", 1, "Sayı Basamakları - Soru 1 için Seçenek A", new Guid("6e3508db-77a4-402b-8a73-8e3c5987c6b4") },
                    { new Guid("4adf74d8-51bd-4dcc-a47c-02c07687f5b4"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 1 için Seçenek C", new Guid("c3a89410-228c-46a9-a554-ef369a58a423") },
                    { new Guid("4b1dcebc-92b7-45d8-8505-1194c2f79967"), false, "D", 4, "Kimya Bilimi - Soru 4 için Seçenek D", new Guid("1343e84a-8f1c-4c84-96fa-84645993c916") },
                    { new Guid("4c3b2fa3-1b2d-4464-92be-06ceb5dacb12"), false, "D", 4, "Rasyonel Sayılar - Soru 2 için Seçenek D", new Guid("6eaa8010-fc30-4cff-ba48-b450cabdd49d") },
                    { new Guid("4cacadb3-02bb-46b9-bfbf-c4bb1671c90e"), false, "B", 2, "Sayı Basamakları - Soru 2 için Seçenek B", new Guid("d09d77db-52b4-402d-adf8-a4af998b7fcb") },
                    { new Guid("4cc3101a-0311-4c9a-880f-425d0488fbae"), false, "A", 1, "Problemler - Soru 5 için Seçenek A", new Guid("eebeb93e-fdf3-4bb1-914f-9852c5c083a3") },
                    { new Guid("4d0b29c0-1053-4038-9861-cb0a66c5a9e5"), false, "A", 1, "Hücre - Soru 1 için Seçenek A", new Guid("88655708-41a1-40e3-ac99-4a15bdc16e58") },
                    { new Guid("4d4c25b8-d992-455a-8cc4-df0be8f7c1b5"), false, "C", 3, "Bölme ve Bölünebilme - Soru 2 için Seçenek C", new Guid("2c99bf4b-4b86-407f-ac8c-ef67b91acb6c") },
                    { new Guid("4da2e9a3-f511-4268-9072-202515795d6f"), true, "C", 3, "Problemler - Soru 2 için Seçenek C", new Guid("f1f41c31-bc43-4efc-91c2-c913a7cffd29") },
                    { new Guid("4e980570-47db-4a1e-9f7d-abcf6cc1b06e"), false, "C", 3, "Sayı Basamakları - Soru 2 için Seçenek C", new Guid("d09d77db-52b4-402d-adf8-a4af998b7fcb") },
                    { new Guid("4f092605-ed54-4136-9bf7-9d48f33f5f2a"), false, "A", 1, "Kimya Bilimi - Soru 1 için Seçenek A", new Guid("d0cd527a-4750-4d93-b5fb-e16a44cdcdbd") },
                    { new Guid("4f6f0734-2115-4352-838d-e9615fce98fc"), false, "C", 3, "Kimya Bilimi - Soru 3 için Seçenek C", new Guid("5bc2a13b-cdf8-4cdf-9eac-088951c30eab") },
                    { new Guid("50be17cd-e420-4369-a4ad-8f7d5b85be16"), false, "D", 4, "Hücre Bölünmeleri - Soru 4 için Seçenek D", new Guid("54a0b13d-c08f-442a-935d-e708980543a3") },
                    { new Guid("50e421a6-4830-405f-8d85-eeb44637e56c"), false, "C", 3, "Rasyonel Sayılar - Soru 4 için Seçenek C", new Guid("d2cb69e2-ff30-41aa-9542-458c7d31ac77") },
                    { new Guid("52330d80-9256-42b7-9413-63754024e020"), false, "C", 3, "Rasyonel Sayılar - Soru 1 için Seçenek C", new Guid("115f50c2-a0a2-4b77-a0e0-fecd916e4082") },
                    { new Guid("52f9ba45-ed11-4464-9529-79d73d6b64cc"), false, "B", 2, "Maddenin Halleri - Soru 3 için Seçenek B", new Guid("d7de5162-b1d3-41cf-885c-ee05446e92b8") },
                    { new Guid("537516c6-35a6-417c-af6c-ae496e3bca6b"), false, "D", 4, "Temel Kavramlar - Soru 4 için Seçenek D", new Guid("62150815-5cbb-4073-a390-7e7107ffffa6") },
                    { new Guid("5390fdb4-d0b1-44a4-b47c-d0df65b7ef35"), true, "C", 3, "Maddenin Halleri - Soru 4 için Seçenek C", new Guid("d7480b02-62be-4240-b715-a66fe7779f34") },
                    { new Guid("53d70f19-3692-4ef0-b353-d9fcf9cb2b4e"), false, "C", 3, "Problemler - Soru 4 için Seçenek C", new Guid("c360b67e-86a8-415a-9392-7647c98d9a1d") },
                    { new Guid("53fefa72-5e79-45d7-924c-df1ad7163b1d"), true, "A", 1, "Problemler - Soru 1 için Seçenek A", new Guid("fa58b629-38de-436a-b520-ec17a7ed47b0") },
                    { new Guid("5424c2b5-3410-4279-a8cd-6ad6cdb18608"), true, "D", 4, "Sayı Basamakları - Soru 4 için Seçenek D", new Guid("0537b1a5-7843-4b15-b2fd-063f548e758a") },
                    { new Guid("54d746e3-693e-4891-8dae-3be79dc7c7ae"), true, "D", 4, "Maddenin Halleri - Soru 2 için Seçenek D", new Guid("855e1d1a-cf09-4d42-a15c-145d6e4e49a6") },
                    { new Guid("553e439f-f7ed-4fde-8241-1a6c7e9e195a"), false, "A", 1, "Hücre Bölünmeleri - Soru 2 için Seçenek A", new Guid("05018417-44d9-4d88-8b6c-b13107139d80") },
                    { new Guid("555cfecf-84fe-41c9-8882-86d8d5df7f5b"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek A", new Guid("67273a1e-a542-47b9-9af4-4d7b0a6c13e6") },
                    { new Guid("55c8466f-3430-4823-9ff3-46efe62ebb3c"), false, "B", 2, "Rasyonel Sayılar - Soru 4 için Seçenek B", new Guid("d2cb69e2-ff30-41aa-9542-458c7d31ac77") },
                    { new Guid("55f08704-3bf7-40a7-84ec-06abb9e60007"), false, "D", 4, "Fizik Bilimine Giriş - Soru 5 için Seçenek D", new Guid("61bf1fcf-a3ed-4877-8fa7-64b7740b6f60") },
                    { new Guid("562aa461-4b38-4bc7-a85b-d623f971167b"), false, "B", 2, "Temel Kavramlar - Soru 3 için Seçenek B", new Guid("e95cc1b1-3397-4962-a6f4-38c56e9c6533") },
                    { new Guid("59f0eeee-fd9f-4905-ba06-5cfaf1642c9e"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 1 için Seçenek D", new Guid("c3a89410-228c-46a9-a554-ef369a58a423") },
                    { new Guid("5b79bc4e-0aec-4b3d-8d1f-f5ddff6ad0d9"), false, "B", 2, "Kalıtım - Soru 3 için Seçenek B", new Guid("31f33055-9623-4955-85ad-cc8e5f4edfed") },
                    { new Guid("5b7b8daf-0f12-478c-9e2c-49aeb54d526a"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 3 için Seçenek C", new Guid("8d4a4dd0-8cc8-4341-abe8-c4ba807ce865") },
                    { new Guid("5d63d516-4ed4-45b2-be41-4102fd84b959"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 4 için Seçenek A", new Guid("cdaaf8b7-fa81-43f6-919d-077b1cee8fb7") },
                    { new Guid("5dd0820a-9a51-41e4-9ef5-4de6fa42470f"), false, "C", 3, "Elektrostatik - Soru 2 için Seçenek C", new Guid("9982a47a-de37-4c29-961b-99e20475bb4d") },
                    { new Guid("5e039c33-7d21-4109-91b9-3339abcfcf6f"), false, "A", 1, "Elektrostatik - Soru 2 için Seçenek A", new Guid("9982a47a-de37-4c29-961b-99e20475bb4d") },
                    { new Guid("5e2bba98-9175-46ad-b4e9-ee915dd5fe3d"), false, "D", 4, "Kalıtım - Soru 3 için Seçenek D", new Guid("31f33055-9623-4955-85ad-cc8e5f4edfed") },
                    { new Guid("5e956947-9dd2-4e44-a228-c45f67147dd2"), false, "A", 1, "İş, Güç ve Enerji - Soru 1 için Seçenek A", new Guid("71162cf4-c4ce-49b3-9fb9-dd1976a17780") },
                    { new Guid("5edc9a2c-769d-4fc0-91e3-85eb728a4331"), false, "D", 4, "Fizik Bilimine Giriş - Soru 1 için Seçenek D", new Guid("e70e2454-38e8-4fe1-b6de-1d296395e315") },
                    { new Guid("60827a8a-d889-4118-81d7-3ef86eee4341"), false, "D", 4, "Madde ve Özellikleri - Soru 1 için Seçenek D", new Guid("73aec0f7-fe81-436d-9119-67095fdd771d") },
                    { new Guid("60a1b8c2-adfb-4da9-a875-4d7a5d5074ca"), false, "B", 2, "Kuvvet ve Hareket - Soru 2 için Seçenek B", new Guid("7120f24a-7c2d-433c-ac25-bfc54adb5c09") },
                    { new Guid("60ad3453-5aad-4d42-b1b7-2892328ee528"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek D", new Guid("b48a2a2f-cdaf-4bb3-9375-2d45b8765d95") },
                    { new Guid("60eaf8a1-c560-4ddb-b2d2-bf9d734c264d"), true, "D", 4, "Temel Kavramlar - Soru 2 için Seçenek D", new Guid("faf94cf2-b292-4483-8a63-53b2f3073ab4") },
                    { new Guid("6102b5f6-ca6e-4582-936a-7fff85bcf8f8"), true, "B", 2, "Fizik Bilimine Giriş - Soru 5 için Seçenek B", new Guid("61bf1fcf-a3ed-4877-8fa7-64b7740b6f60") },
                    { new Guid("61286aca-1e54-4f65-bc79-82bcafc9ead3"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek D", new Guid("0fe84234-f8ec-4d7d-afed-aebb63c44b75") },
                    { new Guid("625dcf10-6ee5-4cdb-8bb8-340d07d0f51d"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 1 için Seçenek D", new Guid("4bdecb09-add9-4066-be2e-9315cfeaa2e9") },
                    { new Guid("6360c35a-95d4-400e-8665-c560293eece9"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek D", new Guid("7a479a6d-2b76-4829-b36c-e8ddc6d01274") },
                    { new Guid("643e838b-7321-4aad-9b13-f20b9efffd2f"), false, "D", 4, "Madde ve Özellikleri - Soru 3 için Seçenek D", new Guid("527d0531-b642-4376-ba4e-288465146472") },
                    { new Guid("657e5c7d-541b-4e43-b918-60b0a79f3c00"), false, "C", 3, "Kimya Bilimi - Soru 5 için Seçenek C", new Guid("4206fdd8-ce7f-4212-b638-081dbdfb1cc1") },
                    { new Guid("658dcb7d-391f-4f2a-b2a1-60f776e52ec2"), false, "B", 2, "Madde ve Özellikleri - Soru 4 için Seçenek B", new Guid("deb532ae-b0d5-4128-92b6-683c472602a0") },
                    { new Guid("661589d0-d9e1-44d7-acab-5dc7a545c185"), false, "D", 4, "Bölme ve Bölünebilme - Soru 1 için Seçenek D", new Guid("14298159-2798-4934-ae15-7dc3bf8a6628") },
                    { new Guid("671501b1-9a40-4727-af9b-3391da926d7c"), false, "B", 2, "Elektrostatik - Soru 3 için Seçenek B", new Guid("5dea75e3-7347-4e09-b37a-3d34961aa81f") },
                    { new Guid("677991b6-1dab-4a89-9d40-9fedefc8d05c"), true, "D", 4, "İş, Güç ve Enerji - Soru 1 için Seçenek D", new Guid("71162cf4-c4ce-49b3-9fb9-dd1976a17780") },
                    { new Guid("6823c8cd-0e20-409b-a099-cea821cd5061"), false, "C", 3, "Bölme ve Bölünebilme - Soru 1 için Seçenek C", new Guid("14298159-2798-4934-ae15-7dc3bf8a6628") },
                    { new Guid("6893d702-16ca-4114-9a9c-323690829816"), true, "C", 3, "Hücre Bölünmeleri - Soru 4 için Seçenek C", new Guid("54a0b13d-c08f-442a-935d-e708980543a3") },
                    { new Guid("68f14b96-c9d3-485a-a758-3d907481b83f"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 2 için Seçenek B", new Guid("fe40dcf9-a746-488d-a0be-ae09e3b61eb5") },
                    { new Guid("6966fd15-42a8-4ab6-bd89-dfeb28a34dbe"), false, "C", 3, "Kalıtım - Soru 1 için Seçenek C", new Guid("a5ed8b8e-49b4-48d4-8b6a-97acf5cf433e") },
                    { new Guid("6b4db511-c3f4-479b-8b68-8114326a9364"), true, "B", 2, "Problemler - Soru 4 için Seçenek B", new Guid("c360b67e-86a8-415a-9392-7647c98d9a1d") },
                    { new Guid("6c554aec-a6d6-4d5f-b724-5b272bbec61e"), true, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek B", new Guid("52781163-57f9-497c-9f9e-7b00b4df3296") },
                    { new Guid("6d4c9cd4-5a1e-4a9f-a903-39279b2b2334"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 3 için Seçenek B", new Guid("4b215ac5-d1f1-43ad-9bf2-868c3a641d3a") },
                    { new Guid("6e15a701-6d09-439c-89f3-dc63b87c4239"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 3 için Seçenek C", new Guid("4b215ac5-d1f1-43ad-9bf2-868c3a641d3a") },
                    { new Guid("6ec59e3c-9155-41b7-8111-078031776d93"), false, "D", 4, "Madde ve Özellikleri - Soru 2 için Seçenek D", new Guid("de51d4fa-7451-4cc7-8857-194ceee47790") },
                    { new Guid("6ef93ed2-9adf-4fd4-877b-1ea743e693bb"), false, "B", 2, "Bölme ve Bölünebilme - Soru 3 için Seçenek B", new Guid("2cc1e90e-9dcf-4919-8019-e94c4f1b078a") },
                    { new Guid("6f07c9e8-fc73-496e-8db2-39edb349224a"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek C", new Guid("3fc78ff9-4225-46b0-8da4-79259b24ae3d") },
                    { new Guid("70175a86-878d-426b-9f40-498dbdcded42"), false, "C", 3, "Hücre - Soru 3 için Seçenek C", new Guid("c0369b0b-eb45-4a3f-a5c1-2198fcea7210") },
                    { new Guid("70813c0a-23a3-4138-8953-c56f59ddb522"), false, "B", 2, "Sayı Basamakları - Soru 4 için Seçenek B", new Guid("0537b1a5-7843-4b15-b2fd-063f548e758a") },
                    { new Guid("709cf863-f84f-4fe5-a9c0-b3688e781f28"), false, "C", 3, "Hücre Bölünmeleri - Soru 2 için Seçenek C", new Guid("05018417-44d9-4d88-8b6c-b13107139d80") },
                    { new Guid("70c42602-6f52-45f5-bcd4-55026224f79b"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek B", new Guid("f251e56e-29ea-4910-bcbe-1e9c87b396f9") },
                    { new Guid("710be26f-95e2-46f5-9a96-ea05805ee6af"), false, "A", 1, "Problemler - Soru 2 için Seçenek A", new Guid("f1f41c31-bc43-4efc-91c2-c913a7cffd29") },
                    { new Guid("711a229a-5c6c-4f40-97f6-02091b57a290"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek D", new Guid("f251e56e-29ea-4910-bcbe-1e9c87b396f9") },
                    { new Guid("7192a4b5-e3d0-4840-bb07-32449f384229"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek C", new Guid("acb167b0-10ca-44c0-a813-5d8d95c9118e") },
                    { new Guid("736b1d08-d7ac-4486-b491-72c856668db4"), true, "A", 1, "Elektrostatik - Soru 3 için Seçenek A", new Guid("5dea75e3-7347-4e09-b37a-3d34961aa81f") },
                    { new Guid("74552cee-1f46-4491-9032-6c41bdcf7bea"), false, "A", 1, "İş, Güç ve Enerji - Soru 4 için Seçenek A", new Guid("4ae9ed05-362b-49bb-a543-5a1a0ed937f0") },
                    { new Guid("74d1f335-876e-4500-b471-69257718b84c"), false, "B", 2, "Madde ve Özellikleri - Soru 2 için Seçenek B", new Guid("de51d4fa-7451-4cc7-8857-194ceee47790") },
                    { new Guid("759519ef-2beb-4c11-bc35-7a5e566e17a7"), false, "A", 1, "Hücre Bölünmeleri - Soru 5 için Seçenek A", new Guid("698c5f36-fa6c-4112-852d-736894a0094c") },
                    { new Guid("75ad08dd-4a96-4de0-ba1f-4ca034a8594d"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 2 için Seçenek C", new Guid("fe40dcf9-a746-488d-a0be-ae09e3b61eb5") },
                    { new Guid("763e0629-86c9-46d6-88b9-3ed382d90cf7"), false, "B", 2, "Fizik Bilimine Giriş - Soru 4 için Seçenek B", new Guid("7d61908c-658f-4c5e-a415-0df92d34a1f5") },
                    { new Guid("77bcb904-e8e5-4e91-bef0-b6343d76ad98"), true, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek C", new Guid("59f10719-6377-4c5c-a5be-c464d7105b97") },
                    { new Guid("785cb114-dca7-42a8-b86a-6f47d361fb9f"), false, "D", 4, "İş, Güç ve Enerji - Soru 5 için Seçenek D", new Guid("ae0a17af-ec8b-4d22-a6fd-2530357645ab") },
                    { new Guid("78d1ced8-e25c-49c4-9ca8-3b3c13629bcb"), false, "C", 3, "Kuvvet ve Hareket - Soru 5 için Seçenek C", new Guid("3bc71377-aa32-4956-a911-b2b2c43ed1d1") },
                    { new Guid("7a2e28a7-c2d4-423f-ba23-d749aedc708e"), false, "C", 3, "Problemler - Soru 5 için Seçenek C", new Guid("eebeb93e-fdf3-4bb1-914f-9852c5c083a3") },
                    { new Guid("7a9acae9-bdf9-45ec-83da-843f15568e3c"), false, "D", 4, "Kalıtım - Soru 2 için Seçenek D", new Guid("991b6364-49f0-4c87-9a3f-6b3de4c4fd0a") },
                    { new Guid("7ac3baf2-ae43-4348-b2af-6e1ff19b37bd"), true, "C", 3, "Hücre Bölünmeleri - Soru 5 için Seçenek C", new Guid("698c5f36-fa6c-4112-852d-736894a0094c") },
                    { new Guid("7ca23d2e-a022-41f9-8190-ceb38dcad387"), false, "A", 1, "Temel Kavramlar - Soru 2 için Seçenek A", new Guid("faf94cf2-b292-4483-8a63-53b2f3073ab4") },
                    { new Guid("7cb963f3-89e3-4fe7-8cdd-173c766f7f4f"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 5 için Seçenek D", new Guid("01d0fae6-988b-4ab4-b871-a3a1f2bf0026") },
                    { new Guid("7df34cbd-5f9d-4e80-b50c-7f4dcda08774"), false, "B", 2, "Maddenin Halleri - Soru 2 için Seçenek B", new Guid("855e1d1a-cf09-4d42-a15c-145d6e4e49a6") },
                    { new Guid("7e30c928-306b-405c-88f1-35ffed7c8d4d"), true, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek B", new Guid("9057160d-daaf-48ce-9c87-0e1e3a36d1dc") },
                    { new Guid("7e41cf29-9411-439f-8a72-51818ccd287c"), true, "D", 4, "Bölme ve Bölünebilme - Soru 2 için Seçenek D", new Guid("2c99bf4b-4b86-407f-ac8c-ef67b91acb6c") },
                    { new Guid("7e5ffbdd-1c8c-41c3-aab8-10fb8b083622"), false, "D", 4, "Maddenin Halleri - Soru 4 için Seçenek D", new Guid("d7480b02-62be-4240-b715-a66fe7779f34") },
                    { new Guid("7fd557b9-8a2b-4780-a58b-961bdd9e1dc7"), false, "A", 1, "Maddenin Halleri - Soru 1 için Seçenek A", new Guid("5bb3e550-af73-4905-843f-6251b4e87035") },
                    { new Guid("813ba70d-6b10-434c-8498-da7a04389f8f"), true, "D", 4, "Madde ve Özellikleri - Soru 4 için Seçenek D", new Guid("deb532ae-b0d5-4128-92b6-683c472602a0") },
                    { new Guid("814b53c9-a6a9-42c0-9b7e-df664c7c236e"), false, "B", 2, "Hücre Bölünmeleri - Soru 1 için Seçenek B", new Guid("00a5a7cc-d700-4047-a001-0715c59efce6") },
                    { new Guid("816b5495-4da0-4f25-a3a7-119a24670100"), false, "A", 1, "Elektrostatik - Soru 4 için Seçenek A", new Guid("4476a0f3-6ae8-4aae-82e6-35ebed0ad652") },
                    { new Guid("81f82d85-e743-44dc-91a5-a40d8fdc1b77"), false, "C", 3, "Fizik Bilimine Giriş - Soru 4 için Seçenek C", new Guid("7d61908c-658f-4c5e-a415-0df92d34a1f5") },
                    { new Guid("82fda2fc-d3c7-45dd-912c-062ae1590e4c"), false, "B", 2, "Rasyonel Sayılar - Soru 1 için Seçenek B", new Guid("115f50c2-a0a2-4b77-a0e0-fecd916e4082") },
                    { new Guid("830b21ea-9e62-4b25-aa1b-e888dddd3eb0"), false, "A", 1, "İş, Güç ve Enerji - Soru 2 için Seçenek A", new Guid("86d145d9-6295-4d8e-b83d-177dc4595a11") },
                    { new Guid("837e9d06-0752-4f5a-9f84-067041e17ac3"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek B", new Guid("73fade28-7a91-4fd4-97fe-eddc318a82b1") },
                    { new Guid("83ad6b04-f44c-4cf3-9b93-9575c9c0c2bc"), false, "D", 4, "Hücre Bölünmeleri - Soru 2 için Seçenek D", new Guid("05018417-44d9-4d88-8b6c-b13107139d80") },
                    { new Guid("852ff2c5-c50c-4f88-98ce-82b2b447350d"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 1 için Seçenek C", new Guid("4bdecb09-add9-4066-be2e-9315cfeaa2e9") },
                    { new Guid("863cd21c-6135-43bb-b39a-ef5e3e5a0a1e"), true, "B", 2, "Rasyonel Sayılar - Soru 3 için Seçenek B", new Guid("061e5584-20d9-4b6f-8e80-22d13aeff091") },
                    { new Guid("867278d0-25b3-42ae-ab42-edbccc9c9183"), false, "C", 3, "Problemler - Soru 3 için Seçenek C", new Guid("a55fb445-12b7-4795-a194-c320813b75c9") },
                    { new Guid("86c65a19-ac08-471d-a342-65e7ad91ca37"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek A", new Guid("acb167b0-10ca-44c0-a813-5d8d95c9118e") },
                    { new Guid("880d959e-95c0-4361-8558-0a15dd664d40"), false, "A", 1, "Kimya Bilimi - Soru 2 için Seçenek A", new Guid("edef1b0e-a044-4e86-961d-290fb1a6f019") },
                    { new Guid("88945f5e-0ea5-44b0-b54a-04820c5be7b4"), false, "D", 4, "Problemler - Soru 5 için Seçenek D", new Guid("eebeb93e-fdf3-4bb1-914f-9852c5c083a3") },
                    { new Guid("88fc51b0-8daa-448b-813c-5e74bbdd509c"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek A", new Guid("59f10719-6377-4c5c-a5be-c464d7105b97") },
                    { new Guid("89bb3953-5277-4773-97b8-0f1f72932129"), false, "C", 3, "Bölme ve Bölünebilme - Soru 4 için Seçenek C", new Guid("dee65a24-d761-4aa6-b22b-45631891858a") },
                    { new Guid("8b33578e-3d80-4db7-92c1-93a0134a1390"), true, "A", 1, "Kuvvet ve Hareket - Soru 3 için Seçenek A", new Guid("38260470-5cbf-4743-ab69-765dc40de4a0") },
                    { new Guid("8ba8687d-ea1a-4a16-b564-f434c9f81d6f"), false, "D", 4, "Rasyonel Sayılar - Soru 1 için Seçenek D", new Guid("115f50c2-a0a2-4b77-a0e0-fecd916e4082") },
                    { new Guid("8bbf7932-3f42-46e9-ad57-1b0f654ddb94"), false, "D", 4, "Fizik Bilimine Giriş - Soru 4 için Seçenek D", new Guid("7d61908c-658f-4c5e-a415-0df92d34a1f5") },
                    { new Guid("8d355c86-4606-4a75-9b5d-15790b5cd2a9"), true, "A", 1, "Elektrostatik - Soru 1 için Seçenek A", new Guid("d3b6b741-1cec-4aaf-953e-ce043dcf8534") },
                    { new Guid("8d3d941a-b586-4bbf-9867-a02d0c65d0e8"), true, "C", 3, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek C", new Guid("b48a2a2f-cdaf-4bb3-9375-2d45b8765d95") },
                    { new Guid("8d400089-ae47-44f4-9aba-c26ea4297d06"), true, "A", 1, "Kalıtım - Soru 2 için Seçenek A", new Guid("991b6364-49f0-4c87-9a3f-6b3de4c4fd0a") },
                    { new Guid("8d4b40c3-88ff-4570-b8b1-62fb6d05458c"), false, "D", 4, "Temel Kavramlar - Soru 3 için Seçenek D", new Guid("e95cc1b1-3397-4962-a6f4-38c56e9c6533") },
                    { new Guid("8efe0c78-f767-480d-941b-47396bc328b0"), false, "A", 1, "Kuvvet ve Hareket - Soru 5 için Seçenek A", new Guid("3bc71377-aa32-4956-a911-b2b2c43ed1d1") },
                    { new Guid("90b17c8e-f28d-4961-803d-88c0263dd42d"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 5 için Seçenek A", new Guid("d91c6a3a-8352-4524-8fe5-66d430868086") },
                    { new Guid("932cfde5-6958-4e3d-936a-730db2735615"), false, "D", 4, "Problemler - Soru 1 için Seçenek D", new Guid("fa58b629-38de-436a-b520-ec17a7ed47b0") },
                    { new Guid("93bd1600-ed5a-4905-a7ba-aba4cba830c1"), false, "D", 4, "Hücre - Soru 5 için Seçenek D", new Guid("0f6add61-f758-47f4-a849-ae37b945f078") },
                    { new Guid("967b10da-a17b-433a-a8c1-d8eae8a288b7"), false, "D", 4, "Hücre - Soru 1 için Seçenek D", new Guid("88655708-41a1-40e3-ac99-4a15bdc16e58") },
                    { new Guid("96c4e5bf-6b17-4f94-96d3-0f9b64472646"), false, "B", 2, "Sayı Basamakları - Soru 5 için Seçenek B", new Guid("af8ec252-68a1-4d7a-a20f-f26c9d51c288") },
                    { new Guid("971a5534-2d8d-4ce3-8400-9351a777ecbb"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek A", new Guid("def81b2f-e674-4094-bc93-b07149939186") },
                    { new Guid("98ca27e0-c840-423b-b4df-69d3e8056f7e"), false, "B", 2, "Hücre - Soru 4 için Seçenek B", new Guid("89052a55-0088-42b5-b731-eb402aee8177") },
                    { new Guid("98e639a0-4a91-48cb-8c14-3561b23a5c1e"), true, "B", 2, "Kalıtım - Soru 1 için Seçenek B", new Guid("a5ed8b8e-49b4-48d4-8b6a-97acf5cf433e") },
                    { new Guid("99a7fdfb-6a8a-4523-8520-b8eb3b24307e"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek D", new Guid("59f10719-6377-4c5c-a5be-c464d7105b97") },
                    { new Guid("9b835151-d1de-48eb-b0d3-8104f46f4ccd"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek D", new Guid("67273a1e-a542-47b9-9af4-4d7b0a6c13e6") },
                    { new Guid("9bb8e5ff-f9ad-4efe-b235-687933aedb1e"), false, "D", 4, "Sayı Basamakları - Soru 3 için Seçenek D", new Guid("23e14845-44fd-4ea9-90bb-12a3225d26f6") },
                    { new Guid("9c234122-2c1d-4357-9b38-d0e2fdb5c9df"), false, "B", 2, "Maddenin Halleri - Soru 4 için Seçenek B", new Guid("d7480b02-62be-4240-b715-a66fe7779f34") },
                    { new Guid("9d862409-34e3-4dcd-9a60-0e903b998894"), false, "A", 1, "Madde ve Özellikleri - Soru 5 için Seçenek A", new Guid("7326d5de-10ee-40e8-8175-de72762ef3b5") },
                    { new Guid("9dd8a97d-77b1-42d6-a892-2a9e5db358ae"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 2 için Seçenek A", new Guid("fe40dcf9-a746-488d-a0be-ae09e3b61eb5") },
                    { new Guid("9ddb19ef-a211-4180-8839-385f09e5ad4d"), true, "C", 3, "Temel Kavramlar - Soru 1 için Seçenek C", new Guid("5d5e63e2-3266-4368-86fd-5b096871a95e") },
                    { new Guid("9e2ff46a-6813-4646-8e34-f437b8bba45b"), true, "C", 3, "Fizik Bilimine Giriş - Soru 1 için Seçenek C", new Guid("e70e2454-38e8-4fe1-b6de-1d296395e315") },
                    { new Guid("9e71af46-260f-460b-95b5-8e4c7fe67943"), false, "C", 3, "Hücre - Soru 5 için Seçenek C", new Guid("0f6add61-f758-47f4-a849-ae37b945f078") },
                    { new Guid("9f4981ed-f45c-4801-bd28-b62665941305"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek A", new Guid("7a479a6d-2b76-4829-b36c-e8ddc6d01274") },
                    { new Guid("9fc4cee7-7837-4b74-8817-cc0c681f3e4f"), false, "C", 3, "Maddenin Halleri - Soru 2 için Seçenek C", new Guid("855e1d1a-cf09-4d42-a15c-145d6e4e49a6") },
                    { new Guid("a04a52d1-3d9e-4e52-a031-52a05aaf65bd"), true, "A", 1, "Kalıtım - Soru 4 için Seçenek A", new Guid("d0d1eb8c-c0ea-44f6-bef8-a8a91581c88f") },
                    { new Guid("a061e64d-3642-4542-bcc4-e1d74bce384e"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 4 için Seçenek D", new Guid("ac0e6084-d528-40a0-b86f-54ef587cdf37") },
                    { new Guid("a0ea08ca-52e7-48cd-b489-03901d35dcc6"), true, "A", 1, "Temel Kavramlar - Soru 5 için Seçenek A", new Guid("965087d6-1156-4db7-8d1e-2b427c66b61b") },
                    { new Guid("a13aa6d6-2759-4246-9e58-6f3f3040c091"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek D", new Guid("c8409986-58b9-4ea7-bdd4-1146d8efff6f") },
                    { new Guid("a1b21830-d637-4193-b7aa-49e77976c843"), false, "D", 4, "Maddenin Halleri - Soru 1 için Seçenek D", new Guid("5bb3e550-af73-4905-843f-6251b4e87035") },
                    { new Guid("a2c7483e-09fd-4410-8b3d-2c72b98838c0"), false, "B", 2, "Kalıtım - Soru 2 için Seçenek B", new Guid("991b6364-49f0-4c87-9a3f-6b3de4c4fd0a") },
                    { new Guid("a336c2de-54e1-4d2a-9109-9069b987b79e"), true, "B", 2, "Hücre - Soru 2 için Seçenek B", new Guid("2a1aaaf7-504e-4fe7-b7d1-2afcc528cffe") },
                    { new Guid("a3ddbd25-0d7d-49ff-bc86-0937e51edd0b"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek B", new Guid("59f10719-6377-4c5c-a5be-c464d7105b97") },
                    { new Guid("a414edf4-2b3d-46b9-ae25-7cf01e0ac6e4"), true, "A", 1, "Bölme ve Bölünebilme - Soru 1 için Seçenek A", new Guid("14298159-2798-4934-ae15-7dc3bf8a6628") },
                    { new Guid("a495124f-a9b5-4b52-9987-a0d8ff645c1b"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 4 için Seçenek C", new Guid("cdaaf8b7-fa81-43f6-919d-077b1cee8fb7") },
                    { new Guid("a4c6650a-7239-4b12-bfa3-2c7d57da1d66"), false, "C", 3, "Fizik Bilimine Giriş - Soru 5 için Seçenek C", new Guid("61bf1fcf-a3ed-4877-8fa7-64b7740b6f60") },
                    { new Guid("a6091a2b-349a-437e-bd51-ba9cfd1b9682"), false, "D", 4, "Kalıtım - Soru 4 için Seçenek D", new Guid("d0d1eb8c-c0ea-44f6-bef8-a8a91581c88f") },
                    { new Guid("a7d0db17-c184-443f-9dba-3167b5f120dd"), false, "B", 2, "Hücre - Soru 3 için Seçenek B", new Guid("c0369b0b-eb45-4a3f-a5c1-2198fcea7210") },
                    { new Guid("a8614da6-02bd-4092-baff-6187d25f18f0"), true, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek A", new Guid("3fc78ff9-4225-46b0-8da4-79259b24ae3d") },
                    { new Guid("a874509f-1d9e-4869-95a2-382f13853837"), true, "A", 1, "Atom ve Periyodik Sistem - Soru 3 için Seçenek A", new Guid("4b215ac5-d1f1-43ad-9bf2-868c3a641d3a") },
                    { new Guid("a8ab5afd-5113-4378-952a-fc40c2caa6ed"), false, "B", 2, "Kuvvet ve Hareket - Soru 1 için Seçenek B", new Guid("00522113-efda-4ad8-a678-08e46ed8f908") },
                    { new Guid("a9c80ee2-4510-4916-8816-e891bf2688c0"), false, "C", 3, "Elektrostatik - Soru 3 için Seçenek C", new Guid("5dea75e3-7347-4e09-b37a-3d34961aa81f") },
                    { new Guid("aa65993b-650b-4980-be7d-fd1110b56728"), false, "D", 4, "Hücre - Soru 2 için Seçenek D", new Guid("2a1aaaf7-504e-4fe7-b7d1-2afcc528cffe") },
                    { new Guid("aaade226-9dff-4d2f-8023-425b961e4f98"), false, "C", 3, "Kimya Bilimi - Soru 2 için Seçenek C", new Guid("edef1b0e-a044-4e86-961d-290fb1a6f019") },
                    { new Guid("ab063a68-3fef-4b2c-ba22-acf228dd6582"), false, "B", 2, "Fizik Bilimine Giriş - Soru 1 için Seçenek B", new Guid("e70e2454-38e8-4fe1-b6de-1d296395e315") },
                    { new Guid("ab1c3605-e39f-4765-a598-a38b2e588247"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek A", new Guid("81193809-21ec-46b6-95a8-a8b6f5821ce7") },
                    { new Guid("ac9bc22e-943e-4a81-b3a5-1352a999b911"), true, "A", 1, "Hücre - Soru 3 için Seçenek A", new Guid("c0369b0b-eb45-4a3f-a5c1-2198fcea7210") },
                    { new Guid("acc7941e-c90d-4f62-ab93-c94b86dac99f"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek A", new Guid("0fe84234-f8ec-4d7d-afed-aebb63c44b75") },
                    { new Guid("acca2eb9-39a9-42de-adcd-1648ca24479a"), false, "C", 3, "Rasyonel Sayılar - Soru 5 için Seçenek C", new Guid("c257e924-7359-4323-9ac6-c0d2e73104d9") },
                    { new Guid("ae6d4004-be43-4c6f-8270-b97a74edd648"), false, "A", 1, "Temel Kavramlar - Soru 1 için Seçenek A", new Guid("5d5e63e2-3266-4368-86fd-5b096871a95e") },
                    { new Guid("ae86e782-ef0d-4575-a4c6-65f8e8fa1f4a"), false, "C", 3, "Madde ve Özellikleri - Soru 3 için Seçenek C", new Guid("527d0531-b642-4376-ba4e-288465146472") },
                    { new Guid("af588141-0fc5-4ec9-9479-9f66070859ac"), false, "C", 3, "Bölme ve Bölünebilme - Soru 3 için Seçenek C", new Guid("2cc1e90e-9dcf-4919-8019-e94c4f1b078a") },
                    { new Guid("affc5cc3-101f-4875-a8d9-37df1ea75140"), false, "A", 1, "Kuvvet ve Hareket - Soru 2 için Seçenek A", new Guid("7120f24a-7c2d-433c-ac25-bfc54adb5c09") },
                    { new Guid("b0527e32-595c-4ffd-914e-fd099b50f510"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 3 için Seçenek A", new Guid("8d4a4dd0-8cc8-4341-abe8-c4ba807ce865") },
                    { new Guid("b0deab05-03ab-4e09-a586-e9bb82c7416f"), false, "B", 2, "Elektrostatik - Soru 5 için Seçenek B", new Guid("6000bb5b-92cb-4ef1-bce9-caa2f0f3883b") },
                    { new Guid("b0feaca3-21f7-4d63-82e7-0f2732f85c92"), false, "D", 4, "İş, Güç ve Enerji - Soru 4 için Seçenek D", new Guid("4ae9ed05-362b-49bb-a543-5a1a0ed937f0") },
                    { new Guid("b1adbc3f-e6ce-4689-a869-11c4f7e40993"), true, "A", 1, "Temel Kavramlar - Soru 3 için Seçenek A", new Guid("e95cc1b1-3397-4962-a6f4-38c56e9c6533") },
                    { new Guid("b2a35b36-7595-4924-b29f-be7464baac3c"), false, "B", 2, "Elektrostatik - Soru 1 için Seçenek B", new Guid("d3b6b741-1cec-4aaf-953e-ce043dcf8534") },
                    { new Guid("b2f09931-6521-45dc-a3c8-063ac5822371"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek D", new Guid("52781163-57f9-497c-9f9e-7b00b4df3296") },
                    { new Guid("b417da28-58df-49e1-8c5e-f6c5eda84a30"), false, "D", 4, "Rasyonel Sayılar - Soru 3 için Seçenek D", new Guid("061e5584-20d9-4b6f-8e80-22d13aeff091") },
                    { new Guid("b4dc356a-7bf3-4a02-a452-c6ba02c3369f"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek C", new Guid("7a479a6d-2b76-4829-b36c-e8ddc6d01274") },
                    { new Guid("b60bf19f-0285-431c-a398-e9b9f68e8a4a"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek A", new Guid("b48a2a2f-cdaf-4bb3-9375-2d45b8765d95") },
                    { new Guid("b61437c0-6b61-4518-bfe1-ca10f9ddba15"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek D", new Guid("81193809-21ec-46b6-95a8-a8b6f5821ce7") },
                    { new Guid("b69eed48-b9d3-444a-a9de-c9d7bbc86cd6"), false, "C", 3, "Temel Kavramlar - Soru 4 için Seçenek C", new Guid("62150815-5cbb-4073-a390-7e7107ffffa6") },
                    { new Guid("b7b4a35f-97d4-41f3-bcbf-711bec17c2fc"), true, "C", 3, "Kuvvet ve Hareket - Soru 1 için Seçenek C", new Guid("00522113-efda-4ad8-a678-08e46ed8f908") },
                    { new Guid("b81f66cf-7b40-4322-8538-07b2762d7de1"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek C", new Guid("73fade28-7a91-4fd4-97fe-eddc318a82b1") },
                    { new Guid("b82ddc2b-25e9-4630-9e44-8f028cca10b9"), true, "C", 3, "Madde ve Özellikleri - Soru 1 için Seçenek C", new Guid("73aec0f7-fe81-436d-9119-67095fdd771d") },
                    { new Guid("b8bfc3d1-7fd7-4538-aeaa-9e828eb11de4"), true, "C", 3, "Maddenin Halleri - Soru 3 için Seçenek C", new Guid("d7de5162-b1d3-41cf-885c-ee05446e92b8") },
                    { new Guid("b8cf53a0-b0f0-4b87-8ed5-2fa94f8c3d2e"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek C", new Guid("81193809-21ec-46b6-95a8-a8b6f5821ce7") },
                    { new Guid("ba0dec04-d657-4866-a209-c1f935f57bf5"), false, "A", 1, "Fizik Bilimine Giriş - Soru 2 için Seçenek A", new Guid("0cade99a-4b3b-456a-93f0-4803611a4fee") },
                    { new Guid("baf17ecb-6a04-496f-aa76-e8d4945cb3f3"), true, "A", 1, "Madde ve Özellikleri - Soru 2 için Seçenek A", new Guid("de51d4fa-7451-4cc7-8857-194ceee47790") },
                    { new Guid("baf71bdf-8bd4-497c-a44d-b902a61cc019"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 5 için Seçenek B", new Guid("d91c6a3a-8352-4524-8fe5-66d430868086") },
                    { new Guid("baf8043a-e700-496f-b835-c19f8aaf5c4e"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 5 için Seçenek B", new Guid("01d0fae6-988b-4ab4-b871-a3a1f2bf0026") },
                    { new Guid("bb0863d6-8a8e-47c9-b379-37871e479101"), false, "D", 4, "Hücre Bölünmeleri - Soru 1 için Seçenek D", new Guid("00a5a7cc-d700-4047-a001-0715c59efce6") },
                    { new Guid("bb390f09-671f-48b3-b6ac-77199ef04b16"), false, "C", 3, "Fizik Bilimine Giriş - Soru 3 için Seçenek C", new Guid("b1208c45-ccce-4d19-afde-55830af7e038") },
                    { new Guid("bb636b81-9ab1-42e2-9cd8-2fa99a554c6e"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek B", new Guid("81193809-21ec-46b6-95a8-a8b6f5821ce7") },
                    { new Guid("bbc708b4-817a-4b55-8494-7ec48cb1d0df"), false, "A", 1, "İş, Güç ve Enerji - Soru 3 için Seçenek A", new Guid("8676e448-8f4b-4278-a012-9625ae7ae2d9") },
                    { new Guid("bc10a734-b0ab-49d0-a09a-8b5036463f6c"), false, "C", 3, "Bölme ve Bölünebilme - Soru 5 için Seçenek C", new Guid("d63ca04f-3510-40be-8dc1-56e391ca5d37") },
                    { new Guid("bc7303b6-dc41-4c51-9570-bd56ad6181ee"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 5 için Seçenek C", new Guid("d91c6a3a-8352-4524-8fe5-66d430868086") },
                    { new Guid("bcadb815-2dbc-47f7-83db-a85373c69982"), false, "C", 3, "İş, Güç ve Enerji - Soru 1 için Seçenek C", new Guid("71162cf4-c4ce-49b3-9fb9-dd1976a17780") },
                    { new Guid("bd1ff118-6cde-41e2-b45c-b40b4ec178a7"), false, "A", 1, "Fizik Bilimine Giriş - Soru 5 için Seçenek A", new Guid("61bf1fcf-a3ed-4877-8fa7-64b7740b6f60") },
                    { new Guid("bdad805a-d9b2-4850-8711-550c4564e326"), false, "A", 1, "Rasyonel Sayılar - Soru 2 için Seçenek A", new Guid("6eaa8010-fc30-4cff-ba48-b450cabdd49d") },
                    { new Guid("beb65088-c0fb-4cc8-b68c-1d6c0bda86ce"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 5 için Seçenek C", new Guid("01d0fae6-988b-4ab4-b871-a3a1f2bf0026") },
                    { new Guid("bf950370-c116-4bc9-ae48-2bd7becfd53e"), true, "D", 4, "Bölme ve Bölünebilme - Soru 5 için Seçenek D", new Guid("d63ca04f-3510-40be-8dc1-56e391ca5d37") },
                    { new Guid("bfa34b12-ceb7-4052-9938-5a4c2a4911ef"), true, "A", 1, "Fizik Bilimine Giriş - Soru 4 için Seçenek A", new Guid("7d61908c-658f-4c5e-a415-0df92d34a1f5") },
                    { new Guid("c018b260-2ecf-4c8f-8d32-42f797b27a91"), false, "D", 4, "Elektrostatik - Soru 4 için Seçenek D", new Guid("4476a0f3-6ae8-4aae-82e6-35ebed0ad652") },
                    { new Guid("c0694cba-559b-41ab-bbbf-64c232d0782f"), false, "C", 3, "İş, Güç ve Enerji - Soru 2 için Seçenek C", new Guid("86d145d9-6295-4d8e-b83d-177dc4595a11") },
                    { new Guid("c0eb32fc-a775-435b-89c9-6faae51964a3"), false, "C", 3, "Temel Kavramlar - Soru 3 için Seçenek C", new Guid("e95cc1b1-3397-4962-a6f4-38c56e9c6533") },
                    { new Guid("c1c28977-7af1-469e-8a3d-eb6d49df9f31"), false, "A", 1, "Maddenin Halleri - Soru 4 için Seçenek A", new Guid("d7480b02-62be-4240-b715-a66fe7779f34") },
                    { new Guid("c1de99bd-518b-4762-b29d-710525e2ae47"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 2 için Seçenek C", new Guid("391ba056-81fb-4b36-972c-3de42c6433d2") },
                    { new Guid("c56d436f-4ed0-4b51-a45b-0078adaf361d"), false, "B", 2, "Hücre Bölünmeleri - Soru 4 için Seçenek B", new Guid("54a0b13d-c08f-442a-935d-e708980543a3") },
                    { new Guid("c5797411-ed7a-4f24-9d28-eb602aed37c6"), false, "D", 4, "İş, Güç ve Enerji - Soru 3 için Seçenek D", new Guid("8676e448-8f4b-4278-a012-9625ae7ae2d9") },
                    { new Guid("c66cb6d0-fe7f-470a-9cc8-08bc4ffe2ad9"), false, "A", 1, "Kimya Bilimi - Soru 4 için Seçenek A", new Guid("1343e84a-8f1c-4c84-96fa-84645993c916") },
                    { new Guid("c6fcc83c-0927-42ac-acad-89358230cffe"), true, "D", 4, "İş, Güç ve Enerji - Soru 2 için Seçenek D", new Guid("86d145d9-6295-4d8e-b83d-177dc4595a11") },
                    { new Guid("c80e98a3-e478-4cd1-818a-7d67f9cd6b47"), false, "C", 3, "Hücre Bölünmeleri - Soru 3 için Seçenek C", new Guid("c5008799-6143-4c13-b9e3-0293f3f966d7") },
                    { new Guid("c81c5033-b26d-4e39-894a-4eba8e12e92a"), true, "D", 4, "Kimya Bilimi - Soru 1 için Seçenek D", new Guid("d0cd527a-4750-4d93-b5fb-e16a44cdcdbd") },
                    { new Guid("c8650d54-68cf-419b-ae42-aeb32f35ab1b"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek D", new Guid("9057160d-daaf-48ce-9c87-0e1e3a36d1dc") },
                    { new Guid("c88d43b5-2b09-4dfc-bbdd-f4b72ded71b4"), false, "A", 1, "Bölme ve Bölünebilme - Soru 2 için Seçenek A", new Guid("2c99bf4b-4b86-407f-ac8c-ef67b91acb6c") },
                    { new Guid("c90f1972-a8e6-4b99-83d7-8e0bb70ef444"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 1 için Seçenek A", new Guid("4bdecb09-add9-4066-be2e-9315cfeaa2e9") },
                    { new Guid("c921e7a5-41b2-4588-a881-55015c344b12"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 5 için Seçenek A", new Guid("01d0fae6-988b-4ab4-b871-a3a1f2bf0026") },
                    { new Guid("c96e58f6-a91b-4ad6-b11f-03adadc5098c"), true, "D", 4, "Kimya Bilimi - Soru 2 için Seçenek D", new Guid("edef1b0e-a044-4e86-961d-290fb1a6f019") },
                    { new Guid("cae7eafe-6d37-45ac-a77f-d6974c2616fc"), false, "A", 1, "Kalıtım - Soru 1 için Seçenek A", new Guid("a5ed8b8e-49b4-48d4-8b6a-97acf5cf433e") },
                    { new Guid("cba677eb-13a7-4e77-a249-d939ebd64e3b"), true, "C", 3, "İş, Güç ve Enerji - Soru 3 için Seçenek C", new Guid("8676e448-8f4b-4278-a012-9625ae7ae2d9") },
                    { new Guid("cc20703d-13f2-409b-98b0-3f93bae6934b"), false, "B", 2, "Kimya Bilimi - Soru 5 için Seçenek B", new Guid("4206fdd8-ce7f-4212-b638-081dbdfb1cc1") },
                    { new Guid("cc5169c6-8e6d-45a8-82ad-eb63515aec4f"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek C", new Guid("0fe84234-f8ec-4d7d-afed-aebb63c44b75") },
                    { new Guid("cc60ce87-d7ac-44e7-85b2-c58f1beaebda"), false, "B", 2, "Madde ve Özellikleri - Soru 5 için Seçenek B", new Guid("7326d5de-10ee-40e8-8175-de72762ef3b5") },
                    { new Guid("ccb57934-cb0e-4e47-b522-7cd0da0ddef7"), false, "A", 1, "Elektrostatik - Soru 5 için Seçenek A", new Guid("6000bb5b-92cb-4ef1-bce9-caa2f0f3883b") },
                    { new Guid("cd3d396d-5607-4f5d-8939-9433c39bb64d"), false, "D", 4, "Rasyonel Sayılar - Soru 4 için Seçenek D", new Guid("d2cb69e2-ff30-41aa-9542-458c7d31ac77") },
                    { new Guid("cd666dd1-4777-4b3f-a051-c953265c6b65"), false, "B", 2, "Kimya Bilimi - Soru 3 için Seçenek B", new Guid("5bc2a13b-cdf8-4cdf-9eac-088951c30eab") },
                    { new Guid("cde9f872-6855-427c-ae8c-a153e6ac2daa"), false, "D", 4, "Maddenin Halleri - Soru 3 için Seçenek D", new Guid("d7de5162-b1d3-41cf-885c-ee05446e92b8") },
                    { new Guid("cf168f20-632c-4882-ba30-581773c9a270"), false, "D", 4, "Problemler - Soru 4 için Seçenek D", new Guid("c360b67e-86a8-415a-9392-7647c98d9a1d") },
                    { new Guid("cfafaaf9-bc12-43c1-8644-47f6422efb19"), false, "C", 3, "Kuvvet ve Hareket - Soru 2 için Seçenek C", new Guid("7120f24a-7c2d-433c-ac25-bfc54adb5c09") },
                    { new Guid("cfc9fbf6-9594-442d-8ca7-c60aba108fcb"), false, "B", 2, "Kimya Bilimi - Soru 1 için Seçenek B", new Guid("d0cd527a-4750-4d93-b5fb-e16a44cdcdbd") },
                    { new Guid("cfd07d29-4579-4ba2-b901-60163eb3aeae"), true, "A", 1, "Rasyonel Sayılar - Soru 5 için Seçenek A", new Guid("c257e924-7359-4323-9ac6-c0d2e73104d9") },
                    { new Guid("d012886a-11aa-4c98-b9c9-42520b3d2531"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek C", new Guid("9057160d-daaf-48ce-9c87-0e1e3a36d1dc") },
                    { new Guid("d1572afb-5e76-43f6-9601-410bc56c02ca"), false, "C", 3, "Madde ve Özellikleri - Soru 4 için Seçenek C", new Guid("deb532ae-b0d5-4128-92b6-683c472602a0") },
                    { new Guid("d1cc3164-0c1b-4d19-9539-7c6c7b98b48c"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek A", new Guid("9517041e-597e-4060-9183-e3b19c9e7dd4") },
                    { new Guid("d1e74edb-d41f-4a4a-a219-a3afcdae2159"), false, "C", 3, "Sayı Basamakları - Soru 4 için Seçenek C", new Guid("0537b1a5-7843-4b15-b2fd-063f548e758a") },
                    { new Guid("d30f65a2-7909-4518-a92c-0568a3de5cd7"), true, "A", 1, "Sayı Basamakları - Soru 2 için Seçenek A", new Guid("d09d77db-52b4-402d-adf8-a4af998b7fcb") },
                    { new Guid("d37dc6fd-4e6c-49c0-9c54-a7e269a187e6"), false, "A", 1, "Sayı Basamakları - Soru 5 için Seçenek A", new Guid("af8ec252-68a1-4d7a-a20f-f26c9d51c288") },
                    { new Guid("d408d7a9-e5f6-4d6d-83e8-8f3f1704fa4b"), false, "B", 2, "Hücre - Soru 5 için Seçenek B", new Guid("0f6add61-f758-47f4-a849-ae37b945f078") },
                    { new Guid("d4d14100-30ca-4087-aec4-f1bf48d0cbd4"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek C", new Guid("c8409986-58b9-4ea7-bdd4-1146d8efff6f") },
                    { new Guid("d5ffbd12-3551-471d-8a61-dd0e46ebdbbb"), false, "A", 1, "Fizik Bilimine Giriş - Soru 3 için Seçenek A", new Guid("b1208c45-ccce-4d19-afde-55830af7e038") },
                    { new Guid("d66ad6eb-44b9-403d-8688-86fb2712d3cd"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek B", new Guid("0fe84234-f8ec-4d7d-afed-aebb63c44b75") },
                    { new Guid("d6b8e118-c59c-4a20-ae52-5e3ab0c9606a"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 3 için Seçenek D", new Guid("8d4a4dd0-8cc8-4341-abe8-c4ba807ce865") },
                    { new Guid("d6ff863c-ac42-4ded-a215-a71d483af5e4"), false, "A", 1, "Fizik Bilimine Giriş - Soru 1 için Seçenek A", new Guid("e70e2454-38e8-4fe1-b6de-1d296395e315") },
                    { new Guid("d81a2538-d0e1-4bff-8d0b-15e048f356a2"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 3 için Seçenek B", new Guid("8d4a4dd0-8cc8-4341-abe8-c4ba807ce865") },
                    { new Guid("d89e7164-5243-443e-a058-00b420ce196f"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 1 için Seçenek A", new Guid("c3a89410-228c-46a9-a554-ef369a58a423") },
                    { new Guid("da638a54-b933-48ad-89d3-90ad53a6ce49"), true, "A", 1, "Kalıtım - Soru 3 için Seçenek A", new Guid("31f33055-9623-4955-85ad-cc8e5f4edfed") },
                    { new Guid("da68fe16-7b92-439a-9d06-e84550e19fcb"), false, "D", 4, "Kimya Bilimi - Soru 5 için Seçenek D", new Guid("4206fdd8-ce7f-4212-b638-081dbdfb1cc1") },
                    { new Guid("da6dcb6f-a8d7-432a-a0b3-1e504cb9f3f5"), false, "D", 4, "Problemler - Soru 2 için Seçenek D", new Guid("f1f41c31-bc43-4efc-91c2-c913a7cffd29") },
                    { new Guid("db968f0d-3c21-4a4c-b4a6-2b0b3b20cad7"), false, "D", 4, "Sayı Basamakları - Soru 2 için Seçenek D", new Guid("d09d77db-52b4-402d-adf8-a4af998b7fcb") },
                    { new Guid("dc5c7aa7-c0b9-401a-9e70-86ba1f9e0612"), false, "D", 4, "Fizik Bilimine Giriş - Soru 3 için Seçenek D", new Guid("b1208c45-ccce-4d19-afde-55830af7e038") },
                    { new Guid("dc6108de-9f34-44bd-8c9c-c36fdbae141c"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek D", new Guid("def81b2f-e674-4094-bc93-b07149939186") },
                    { new Guid("dd55c8b1-7ca3-4956-b348-47ab189aa22a"), false, "C", 3, "Sayı Basamakları - Soru 3 için Seçenek C", new Guid("23e14845-44fd-4ea9-90bb-12a3225d26f6") },
                    { new Guid("de787c06-9043-44ff-a04a-10ffadc450b1"), true, "B", 2, "Fizik Bilimine Giriş - Soru 2 için Seçenek B", new Guid("0cade99a-4b3b-456a-93f0-4803611a4fee") },
                    { new Guid("dec0dafc-43f6-4171-9095-d4afbb2d0cc7"), false, "B", 2, "Temel Kavramlar - Soru 2 için Seçenek B", new Guid("faf94cf2-b292-4483-8a63-53b2f3073ab4") },
                    { new Guid("def92afb-a7b0-44d3-bc3a-972b62131eb8"), true, "B", 2, "Temel Kavramlar - Soru 4 için Seçenek B", new Guid("62150815-5cbb-4073-a390-7e7107ffffa6") },
                    { new Guid("df9b00da-0542-44ce-b043-597e3b60c4ee"), false, "A", 1, "Problemler - Soru 4 için Seçenek A", new Guid("c360b67e-86a8-415a-9392-7647c98d9a1d") },
                    { new Guid("e0cfe243-46f0-4959-9cd5-31fb91825f3c"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek C", new Guid("9517041e-597e-4060-9183-e3b19c9e7dd4") },
                    { new Guid("e16de96e-9209-4917-98e8-121c6080f6c8"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek A", new Guid("9057160d-daaf-48ce-9c87-0e1e3a36d1dc") },
                    { new Guid("e1995b2f-3561-49c1-ae69-82fc30313b1c"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 3 için Seçenek D", new Guid("4b215ac5-d1f1-43ad-9bf2-868c3a641d3a") },
                    { new Guid("e2779871-f8f2-4ad1-b203-21d4b31a0dac"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek B", new Guid("c8409986-58b9-4ea7-bdd4-1146d8efff6f") },
                    { new Guid("e27ab6c1-7429-4b2e-babd-720093b33c68"), false, "A", 1, "İş, Güç ve Enerji - Soru 5 için Seçenek A", new Guid("ae0a17af-ec8b-4d22-a6fd-2530357645ab") },
                    { new Guid("e2e0ce97-703a-4890-9718-2722f1eaaf22"), false, "C", 3, "Kalıtım - Soru 2 için Seçenek C", new Guid("991b6364-49f0-4c87-9a3f-6b3de4c4fd0a") },
                    { new Guid("e361282a-3853-4b04-b4c0-8599e1f609b9"), true, "A", 1, "Hücre Bölünmeleri - Soru 3 için Seçenek A", new Guid("c5008799-6143-4c13-b9e3-0293f3f966d7") },
                    { new Guid("e36187f5-7e9b-4353-8272-1891e19eb484"), true, "B", 2, "Rasyonel Sayılar - Soru 2 için Seçenek B", new Guid("6eaa8010-fc30-4cff-ba48-b450cabdd49d") },
                    { new Guid("e373439b-5d3b-46d5-b004-2873ae4a2c2a"), true, "A", 1, "Maddenin Halleri - Soru 5 için Seçenek A", new Guid("700dbf77-fb4f-4ec5-9ff4-cf1fc67eb748") },
                    { new Guid("e484fb87-cb42-496a-9f9f-dcb226c47084"), false, "B", 2, "Bölme ve Bölünebilme - Soru 4 için Seçenek B", new Guid("dee65a24-d761-4aa6-b22b-45631891858a") },
                    { new Guid("e53d65cc-1474-4f9c-97ab-345aae563fee"), true, "A", 1, "Bölme ve Bölünebilme - Soru 3 için Seçenek A", new Guid("2cc1e90e-9dcf-4919-8019-e94c4f1b078a") },
                    { new Guid("e5b81460-0ce1-4e7f-929f-a6010ade4019"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek D", new Guid("acb167b0-10ca-44c0-a813-5d8d95c9118e") },
                    { new Guid("e6934240-cfbf-421c-bf51-141abe74baf7"), false, "C", 3, "Fizik Bilimine Giriş - Soru 2 için Seçenek C", new Guid("0cade99a-4b3b-456a-93f0-4803611a4fee") },
                    { new Guid("e7645db8-7646-4dc7-85a9-4e1af992be3f"), false, "B", 2, "Temel Kavramlar - Soru 1 için Seçenek B", new Guid("5d5e63e2-3266-4368-86fd-5b096871a95e") },
                    { new Guid("e76f2b54-5a84-4fed-a92d-ca13981e56c2"), false, "B", 2, "İş, Güç ve Enerji - Soru 5 için Seçenek B", new Guid("ae0a17af-ec8b-4d22-a6fd-2530357645ab") },
                    { new Guid("ea2180c3-e4aa-4d67-8862-53bbf2bc63f4"), false, "D", 4, "Temel Kavramlar - Soru 1 için Seçenek D", new Guid("5d5e63e2-3266-4368-86fd-5b096871a95e") },
                    { new Guid("eb310474-19dc-4852-9667-b37bb4a85a34"), false, "C", 3, "Elektrostatik - Soru 5 için Seçenek C", new Guid("6000bb5b-92cb-4ef1-bce9-caa2f0f3883b") },
                    { new Guid("ec751586-7023-4db5-8332-b7d33a908c1f"), true, "C", 3, "Hücre - Soru 1 için Seçenek C", new Guid("88655708-41a1-40e3-ac99-4a15bdc16e58") },
                    { new Guid("ecbcdeaf-aa27-47c5-8c37-2115ef1af788"), false, "B", 2, "Maddenin Halleri - Soru 1 için Seçenek B", new Guid("5bb3e550-af73-4905-843f-6251b4e87035") },
                    { new Guid("ed399cd4-fe46-4633-8b4f-77f5f4e0ea0b"), false, "B", 2, "İş, Güç ve Enerji - Soru 1 için Seçenek B", new Guid("71162cf4-c4ce-49b3-9fb9-dd1976a17780") },
                    { new Guid("eda673d6-31b2-44b1-8d73-7cc36f88c7ae"), false, "A", 1, "Hücre - Soru 2 için Seçenek A", new Guid("2a1aaaf7-504e-4fe7-b7d1-2afcc528cffe") },
                    { new Guid("ef4d1db6-94d5-4025-b331-2618ca3dfe69"), false, "C", 3, "Kalıtım - Soru 4 için Seçenek C", new Guid("d0d1eb8c-c0ea-44f6-bef8-a8a91581c88f") },
                    { new Guid("f0d70227-621a-45a6-b1d0-4f2f25bddbeb"), false, "C", 3, "Rasyonel Sayılar - Soru 3 için Seçenek C", new Guid("061e5584-20d9-4b6f-8e80-22d13aeff091") },
                    { new Guid("f269e0c2-0dda-4b30-aa15-ec25b7dab651"), false, "B", 2, "Hücre Bölünmeleri - Soru 5 için Seçenek B", new Guid("698c5f36-fa6c-4112-852d-736894a0094c") },
                    { new Guid("f2956c6d-c136-4b0a-b42d-e9fc969a2dee"), false, "D", 4, "Fizik Bilimine Giriş - Soru 2 için Seçenek D", new Guid("0cade99a-4b3b-456a-93f0-4803611a4fee") },
                    { new Guid("f3809a41-7f4e-4e8d-ac89-5805875fa3ac"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 4 için Seçenek D", new Guid("cdaaf8b7-fa81-43f6-919d-077b1cee8fb7") },
                    { new Guid("f39ac1c5-2c67-4770-ab03-93fd7c2a15ab"), false, "D", 4, "Kuvvet ve Hareket - Soru 1 için Seçenek D", new Guid("00522113-efda-4ad8-a678-08e46ed8f908") },
                    { new Guid("f47b3e10-c405-42bc-bbf5-aa663e164636"), false, "D", 4, "Hücre Bölünmeleri - Soru 5 için Seçenek D", new Guid("698c5f36-fa6c-4112-852d-736894a0094c") },
                    { new Guid("f4bc22e9-31e9-4170-aaa0-fc7ef51ff9d7"), false, "C", 3, "Rasyonel Sayılar - Soru 2 için Seçenek C", new Guid("6eaa8010-fc30-4cff-ba48-b450cabdd49d") },
                    { new Guid("f53d672c-5648-41ff-b8b6-da2051e68b7e"), true, "C", 3, "Elektrostatik - Soru 4 için Seçenek C", new Guid("4476a0f3-6ae8-4aae-82e6-35ebed0ad652") },
                    { new Guid("f5e67b55-e467-408e-aee4-9adde957a665"), false, "C", 3, "Kuvvet ve Hareket - Soru 4 için Seçenek C", new Guid("ebb6b7a8-b11a-408a-aa72-922593f9f918") },
                    { new Guid("f61c2f43-b3ad-4aca-bf67-0b7e332f30df"), false, "D", 4, "Maddenin Halleri - Soru 5 için Seçenek D", new Guid("700dbf77-fb4f-4ec5-9ff4-cf1fc67eb748") },
                    { new Guid("f6449f0b-fdfe-4c6b-9b20-667aa1227630"), false, "A", 1, "Hücre - Soru 4 için Seçenek A", new Guid("89052a55-0088-42b5-b731-eb402aee8177") },
                    { new Guid("f6a4e38c-e239-4d49-b6dc-2f1f35d2a8eb"), false, "A", 1, "Maddenin Halleri - Soru 2 için Seçenek A", new Guid("855e1d1a-cf09-4d42-a15c-145d6e4e49a6") },
                    { new Guid("f835b1ea-8e32-4d17-91ae-6b74306fe7f0"), false, "B", 2, "Bölme ve Bölünebilme - Soru 5 için Seçenek B", new Guid("d63ca04f-3510-40be-8dc1-56e391ca5d37") },
                    { new Guid("f851ed7c-57f7-48e7-9417-3a3b81d274b0"), false, "C", 3, "Maddenin Halleri - Soru 5 için Seçenek C", new Guid("700dbf77-fb4f-4ec5-9ff4-cf1fc67eb748") },
                    { new Guid("f9154639-a85f-462b-a27f-267fa81bf60b"), false, "A", 1, "Madde ve Özellikleri - Soru 4 için Seçenek A", new Guid("deb532ae-b0d5-4128-92b6-683c472602a0") },
                    { new Guid("fa1a22c5-21c2-48c9-9655-2d02cdebe6f5"), false, "C", 3, "Sayı Basamakları - Soru 1 için Seçenek C", new Guid("6e3508db-77a4-402b-8a73-8e3c5987c6b4") },
                    { new Guid("faf35046-70bd-4d01-9adc-3578b3a6ddd7"), false, "B", 2, "Maddenin Halleri - Soru 5 için Seçenek B", new Guid("700dbf77-fb4f-4ec5-9ff4-cf1fc67eb748") },
                    { new Guid("fb5dd6b7-0a69-416b-9c6d-0f7500f3ee4f"), false, "D", 4, "Temel Kavramlar - Soru 5 için Seçenek D", new Guid("965087d6-1156-4db7-8d1e-2b427c66b61b") },
                    { new Guid("fbb8ea14-6144-46e9-82d0-d5140b63d3b5"), false, "A", 1, "Kimya Bilimi - Soru 3 için Seçenek A", new Guid("5bc2a13b-cdf8-4cdf-9eac-088951c30eab") },
                    { new Guid("fbd5b8f5-5a49-4d4e-a0eb-ede3b0752b1f"), false, "B", 2, "Kimya Bilimi - Soru 4 için Seçenek B", new Guid("1343e84a-8f1c-4c84-96fa-84645993c916") },
                    { new Guid("fc1b0663-1577-497e-ad05-98513d4503e0"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 4 için Seçenek B", new Guid("cdaaf8b7-fa81-43f6-919d-077b1cee8fb7") },
                    { new Guid("fd82688f-86db-41a5-93e9-edac0b76c050"), false, "D", 4, "Elektrostatik - Soru 2 için Seçenek D", new Guid("9982a47a-de37-4c29-961b-99e20475bb4d") },
                    { new Guid("fe7ac85e-a553-4d43-bb0f-789a11225c42"), false, "A", 1, "Bölme ve Bölünebilme - Soru 5 için Seçenek A", new Guid("d63ca04f-3510-40be-8dc1-56e391ca5d37") }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ParentTopicId", "SubjectId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("02907035-d160-4a24-b9ff-211097001331"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8143), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimya Bilimi" },
                    { new Guid("15c12f1c-e065-4cf1-b01f-3afb0b8a13bb"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8119), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Rasyonel Sayılar" },
                    { new Guid("16237d0f-7b2d-4778-bf29-7bb635aa7fee"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8140), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Elektrostatik" },
                    { new Guid("247bf261-f901-431d-9055-cc4c2ffdfe0c"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8129), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Fizik Bilimine Giriş" },
                    { new Guid("2892e4f7-042c-4838-8d2a-bbf10a350bf7"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8187), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Kalıtım" },
                    { new Guid("5e69856a-54c2-4cd6-b911-3a3d5e6083c6"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8135), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Kuvvet ve Hareket" },
                    { new Guid("68f6675e-4e4f-49d3-af80-81094c2d126e"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8131), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Madde ve Özellikleri" },
                    { new Guid("6903c3de-098e-4c91-9298-a679c2f19066"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8185), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre Bölünmeleri" },
                    { new Guid("77083a8d-850f-43db-8ebc-a0e675c948dd"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8150), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Maddenin Halleri" },
                    { new Guid("7948d603-ab38-4e96-8b25-9a9c4d7fd9e7"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8152), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Asitler, Bazlar ve Tuzlar" },
                    { new Guid("79b0193d-fb85-4cd5-a0bb-805a6afcfbc7"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8179), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Yaşam Bilimi Biyoloji" },
                    { new Guid("832e409b-a161-4ba2-861a-4fdfe3508d81"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8181), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre" },
                    { new Guid("83d9810b-9978-478b-9a07-0b82b6664219"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8183), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Canlıların Sınıflandırılması" },
                    { new Guid("8fb58995-131b-4994-b90b-d9e002f31348"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8148), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimyasal Türler Arası Etkileşimler" },
                    { new Guid("96b2dfd0-6c48-48e0-8c35-c4785e9c1792"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8117), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Bölme ve Bölünebilme" },
                    { new Guid("ac0ac1d9-1f91-4e93-abad-fa9abe251a7b"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8145), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Atom ve Periyodik Sistem" },
                    { new Guid("bfd52a64-1985-4390-89d9-9659b8b093aa"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8112), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Temel Kavramlar" },
                    { new Guid("c1cb6d94-6a3c-42d0-b2b8-7f48063fdabc"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8115), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Sayı Basamakları" },
                    { new Guid("cf1640e3-68e0-4ffe-9ddd-8327f22fc61b"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8138), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "İş, Güç ve Enerji" },
                    { new Guid("fc6f81e4-fd05-44c5-b5b8-b48773375881"), new DateTime(2025, 8, 21, 8, 4, 4, 942, DateTimeKind.Utc).AddTicks(8121), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Problemler" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsTopics",
                columns: new[] { "QuestionId", "TopicId", "Id" },
                values: new object[,]
                {
                    { new Guid("00522113-efda-4ad8-a678-08e46ed8f908"), new Guid("5e69856a-54c2-4cd6-b911-3a3d5e6083c6"), new Guid("2c0d06cc-b67c-41d5-a734-b5a295a745c6") },
                    { new Guid("00a5a7cc-d700-4047-a001-0715c59efce6"), new Guid("6903c3de-098e-4c91-9298-a679c2f19066"), new Guid("1e7b14eb-0c46-433d-9188-4eef727e1d7f") },
                    { new Guid("01d0fae6-988b-4ab4-b871-a3a1f2bf0026"), new Guid("ac0ac1d9-1f91-4e93-abad-fa9abe251a7b"), new Guid("2cdb372e-8fdb-4b91-95a6-a914f194f138") },
                    { new Guid("05018417-44d9-4d88-8b6c-b13107139d80"), new Guid("6903c3de-098e-4c91-9298-a679c2f19066"), new Guid("70133161-d223-4779-9110-8b624b65b272") },
                    { new Guid("0537b1a5-7843-4b15-b2fd-063f548e758a"), new Guid("c1cb6d94-6a3c-42d0-b2b8-7f48063fdabc"), new Guid("231430b0-f9c8-4fc0-a5a0-e40cbb71315a") },
                    { new Guid("061e5584-20d9-4b6f-8e80-22d13aeff091"), new Guid("15c12f1c-e065-4cf1-b01f-3afb0b8a13bb"), new Guid("5d81bece-8f8d-4efb-94b1-0d1460748265") },
                    { new Guid("0cade99a-4b3b-456a-93f0-4803611a4fee"), new Guid("247bf261-f901-431d-9055-cc4c2ffdfe0c"), new Guid("8a5e9d5d-7bd9-438c-9e19-bbe98af00087") },
                    { new Guid("0f6add61-f758-47f4-a849-ae37b945f078"), new Guid("832e409b-a161-4ba2-861a-4fdfe3508d81"), new Guid("5e82bc05-c8f0-41d2-b8dc-311f7b0b6199") },
                    { new Guid("0fe84234-f8ec-4d7d-afed-aebb63c44b75"), new Guid("79b0193d-fb85-4cd5-a0bb-805a6afcfbc7"), new Guid("814ff0bc-4886-4a41-baac-4e81fd512afa") },
                    { new Guid("115f50c2-a0a2-4b77-a0e0-fecd916e4082"), new Guid("15c12f1c-e065-4cf1-b01f-3afb0b8a13bb"), new Guid("864aa19f-164a-4cfa-8138-7747fefd2aff") },
                    { new Guid("1343e84a-8f1c-4c84-96fa-84645993c916"), new Guid("02907035-d160-4a24-b9ff-211097001331"), new Guid("d8830d32-3dd6-4e31-840e-ef3ad6c28947") },
                    { new Guid("14298159-2798-4934-ae15-7dc3bf8a6628"), new Guid("96b2dfd0-6c48-48e0-8c35-c4785e9c1792"), new Guid("b2a5b047-6800-464d-b5e1-f48bc97284f6") },
                    { new Guid("23e14845-44fd-4ea9-90bb-12a3225d26f6"), new Guid("c1cb6d94-6a3c-42d0-b2b8-7f48063fdabc"), new Guid("09905de5-9623-4b48-b153-412fa66de78d") },
                    { new Guid("2a1aaaf7-504e-4fe7-b7d1-2afcc528cffe"), new Guid("832e409b-a161-4ba2-861a-4fdfe3508d81"), new Guid("97b6a3a0-d11e-4f2f-9190-0eb3bbbf9b6a") },
                    { new Guid("2b682a58-cfe2-479f-903e-a83a83998673"), new Guid("2892e4f7-042c-4838-8d2a-bbf10a350bf7"), new Guid("d3acb1d6-8eae-44db-9fe0-960f545b2267") },
                    { new Guid("2c99bf4b-4b86-407f-ac8c-ef67b91acb6c"), new Guid("96b2dfd0-6c48-48e0-8c35-c4785e9c1792"), new Guid("7923905e-4ace-4066-a0c8-f01d25d7c36f") },
                    { new Guid("2cc1e90e-9dcf-4919-8019-e94c4f1b078a"), new Guid("96b2dfd0-6c48-48e0-8c35-c4785e9c1792"), new Guid("c2fd4d04-ff0e-449b-836e-82effd96657a") },
                    { new Guid("31f33055-9623-4955-85ad-cc8e5f4edfed"), new Guid("2892e4f7-042c-4838-8d2a-bbf10a350bf7"), new Guid("da148cc6-361e-44f2-8cb4-5e274ac51996") },
                    { new Guid("38260470-5cbf-4743-ab69-765dc40de4a0"), new Guid("5e69856a-54c2-4cd6-b911-3a3d5e6083c6"), new Guid("ecb8e5b1-cf50-410d-b9c9-9fb839e56e21") },
                    { new Guid("391ba056-81fb-4b36-972c-3de42c6433d2"), new Guid("83d9810b-9978-478b-9a07-0b82b6664219"), new Guid("4bb12e08-9a25-4699-96dd-ad0a109f950d") },
                    { new Guid("3bc71377-aa32-4956-a911-b2b2c43ed1d1"), new Guid("5e69856a-54c2-4cd6-b911-3a3d5e6083c6"), new Guid("676c1df5-a7fb-47ce-98ea-42b9cc0f732f") },
                    { new Guid("3fc78ff9-4225-46b0-8da4-79259b24ae3d"), new Guid("7948d603-ab38-4e96-8b25-9a9c4d7fd9e7"), new Guid("99248300-976a-423c-9ee4-846833ff79ee") },
                    { new Guid("4206fdd8-ce7f-4212-b638-081dbdfb1cc1"), new Guid("02907035-d160-4a24-b9ff-211097001331"), new Guid("f0d07083-8e31-4f9a-90dc-617d55c7e166") },
                    { new Guid("4476a0f3-6ae8-4aae-82e6-35ebed0ad652"), new Guid("16237d0f-7b2d-4778-bf29-7bb635aa7fee"), new Guid("8d379960-9f1b-4d33-95ee-e7380c5dc314") },
                    { new Guid("4ae9ed05-362b-49bb-a543-5a1a0ed937f0"), new Guid("cf1640e3-68e0-4ffe-9ddd-8327f22fc61b"), new Guid("3e864deb-56d1-44ed-b1f6-32d6be136704") },
                    { new Guid("4b215ac5-d1f1-43ad-9bf2-868c3a641d3a"), new Guid("ac0ac1d9-1f91-4e93-abad-fa9abe251a7b"), new Guid("4755e318-472c-4d0b-b699-146586879099") },
                    { new Guid("4bdecb09-add9-4066-be2e-9315cfeaa2e9"), new Guid("ac0ac1d9-1f91-4e93-abad-fa9abe251a7b"), new Guid("6b08484c-8850-4784-8b75-1070744d2f27") },
                    { new Guid("52781163-57f9-497c-9f9e-7b00b4df3296"), new Guid("8fb58995-131b-4994-b90b-d9e002f31348"), new Guid("0b39beba-9664-4708-a1eb-9cc79e49da37") },
                    { new Guid("527d0531-b642-4376-ba4e-288465146472"), new Guid("68f6675e-4e4f-49d3-af80-81094c2d126e"), new Guid("bdbda254-e3c4-4507-8990-089ac6f5de97") },
                    { new Guid("54a0b13d-c08f-442a-935d-e708980543a3"), new Guid("6903c3de-098e-4c91-9298-a679c2f19066"), new Guid("f1ef9db6-9bdb-4b2c-aa5b-36479f5ddf99") },
                    { new Guid("59f10719-6377-4c5c-a5be-c464d7105b97"), new Guid("8fb58995-131b-4994-b90b-d9e002f31348"), new Guid("e9f2ebee-f6e8-4ac3-a87d-54236db6f694") },
                    { new Guid("5bb3e550-af73-4905-843f-6251b4e87035"), new Guid("77083a8d-850f-43db-8ebc-a0e675c948dd"), new Guid("5154d90c-c183-4d9d-9ded-412e92c90601") },
                    { new Guid("5bc2a13b-cdf8-4cdf-9eac-088951c30eab"), new Guid("02907035-d160-4a24-b9ff-211097001331"), new Guid("5009dd25-a185-42d1-8291-bbe9b7bf92c4") },
                    { new Guid("5d5e63e2-3266-4368-86fd-5b096871a95e"), new Guid("bfd52a64-1985-4390-89d9-9659b8b093aa"), new Guid("e0a0305d-b650-4f2a-a907-414c1c5cd11b") },
                    { new Guid("5dea75e3-7347-4e09-b37a-3d34961aa81f"), new Guid("16237d0f-7b2d-4778-bf29-7bb635aa7fee"), new Guid("15e1e9ef-4d34-4cb1-8707-9c62b2a6c941") },
                    { new Guid("6000bb5b-92cb-4ef1-bce9-caa2f0f3883b"), new Guid("16237d0f-7b2d-4778-bf29-7bb635aa7fee"), new Guid("2561942c-92d6-4f81-9261-bc50f766d5fa") },
                    { new Guid("61bf1fcf-a3ed-4877-8fa7-64b7740b6f60"), new Guid("247bf261-f901-431d-9055-cc4c2ffdfe0c"), new Guid("f425d3c5-5126-44d1-8e90-4790f3b4b8b3") },
                    { new Guid("62150815-5cbb-4073-a390-7e7107ffffa6"), new Guid("bfd52a64-1985-4390-89d9-9659b8b093aa"), new Guid("0cc4aa69-10b3-4921-b399-d552536906a0") },
                    { new Guid("67273a1e-a542-47b9-9af4-4d7b0a6c13e6"), new Guid("8fb58995-131b-4994-b90b-d9e002f31348"), new Guid("12724f0a-d440-4177-8643-fee0f4ba6435") },
                    { new Guid("698c5f36-fa6c-4112-852d-736894a0094c"), new Guid("6903c3de-098e-4c91-9298-a679c2f19066"), new Guid("3d9f0fca-66fe-4c83-bd62-c0f1be862edc") },
                    { new Guid("6e3508db-77a4-402b-8a73-8e3c5987c6b4"), new Guid("c1cb6d94-6a3c-42d0-b2b8-7f48063fdabc"), new Guid("7f4609dc-eebb-4b2d-8e71-9dc74cee9084") },
                    { new Guid("6eaa8010-fc30-4cff-ba48-b450cabdd49d"), new Guid("15c12f1c-e065-4cf1-b01f-3afb0b8a13bb"), new Guid("501954d4-46b7-4cbb-a224-ae2580d24f46") },
                    { new Guid("700dbf77-fb4f-4ec5-9ff4-cf1fc67eb748"), new Guid("77083a8d-850f-43db-8ebc-a0e675c948dd"), new Guid("072e3ec4-8ed5-4e4a-ae55-b2505688bc49") },
                    { new Guid("71162cf4-c4ce-49b3-9fb9-dd1976a17780"), new Guid("cf1640e3-68e0-4ffe-9ddd-8327f22fc61b"), new Guid("bc9b4417-cf6b-46e5-b12c-f4c6ad012ec1") },
                    { new Guid("7120f24a-7c2d-433c-ac25-bfc54adb5c09"), new Guid("5e69856a-54c2-4cd6-b911-3a3d5e6083c6"), new Guid("3eb1bb34-b8c7-4b3d-89e4-6bb303f9d672") },
                    { new Guid("7326d5de-10ee-40e8-8175-de72762ef3b5"), new Guid("68f6675e-4e4f-49d3-af80-81094c2d126e"), new Guid("cf96e275-ac28-46bc-930c-08926334e80b") },
                    { new Guid("73aec0f7-fe81-436d-9119-67095fdd771d"), new Guid("68f6675e-4e4f-49d3-af80-81094c2d126e"), new Guid("b6eb2bde-2360-4399-bbd5-74f881f47e58") },
                    { new Guid("73fade28-7a91-4fd4-97fe-eddc318a82b1"), new Guid("7948d603-ab38-4e96-8b25-9a9c4d7fd9e7"), new Guid("134d2c60-d500-4da1-83d6-3fd95e5c5bbc") },
                    { new Guid("7a479a6d-2b76-4829-b36c-e8ddc6d01274"), new Guid("79b0193d-fb85-4cd5-a0bb-805a6afcfbc7"), new Guid("6c02abae-7da5-4e70-9a3b-9babd8a89e85") },
                    { new Guid("7d61908c-658f-4c5e-a415-0df92d34a1f5"), new Guid("247bf261-f901-431d-9055-cc4c2ffdfe0c"), new Guid("b9ac5bbd-b22a-4ebe-8945-c8ddb8ef19b7") },
                    { new Guid("81193809-21ec-46b6-95a8-a8b6f5821ce7"), new Guid("7948d603-ab38-4e96-8b25-9a9c4d7fd9e7"), new Guid("f1c2d3d1-4f24-496b-98e6-e9ae19cf2d84") },
                    { new Guid("855e1d1a-cf09-4d42-a15c-145d6e4e49a6"), new Guid("77083a8d-850f-43db-8ebc-a0e675c948dd"), new Guid("9c18963a-da48-4dd2-a341-a208ad5d1ea0") },
                    { new Guid("8676e448-8f4b-4278-a012-9625ae7ae2d9"), new Guid("cf1640e3-68e0-4ffe-9ddd-8327f22fc61b"), new Guid("96fb32c4-2a1f-49d8-8f52-9eeb0a949504") },
                    { new Guid("86d145d9-6295-4d8e-b83d-177dc4595a11"), new Guid("cf1640e3-68e0-4ffe-9ddd-8327f22fc61b"), new Guid("c6b44518-2aaf-4e65-9d66-84efc150fe7b") },
                    { new Guid("88655708-41a1-40e3-ac99-4a15bdc16e58"), new Guid("832e409b-a161-4ba2-861a-4fdfe3508d81"), new Guid("77607e95-8750-4c9b-bd12-c08003622b29") },
                    { new Guid("89052a55-0088-42b5-b731-eb402aee8177"), new Guid("832e409b-a161-4ba2-861a-4fdfe3508d81"), new Guid("733838c7-5f4f-401d-9703-7f3a030849b6") },
                    { new Guid("8d4a4dd0-8cc8-4341-abe8-c4ba807ce865"), new Guid("83d9810b-9978-478b-9a07-0b82b6664219"), new Guid("3d5ba8c1-fa27-4494-bd85-096a42785a4e") },
                    { new Guid("9057160d-daaf-48ce-9c87-0e1e3a36d1dc"), new Guid("7948d603-ab38-4e96-8b25-9a9c4d7fd9e7"), new Guid("d0d12183-a945-4bd5-9bf2-2942876fe50d") },
                    { new Guid("9517041e-597e-4060-9183-e3b19c9e7dd4"), new Guid("8fb58995-131b-4994-b90b-d9e002f31348"), new Guid("738e9b6d-f460-43be-81e3-c1596ca60d96") },
                    { new Guid("965087d6-1156-4db7-8d1e-2b427c66b61b"), new Guid("bfd52a64-1985-4390-89d9-9659b8b093aa"), new Guid("093ed1d8-83a2-4760-afed-a2e73f0eefea") },
                    { new Guid("991b6364-49f0-4c87-9a3f-6b3de4c4fd0a"), new Guid("2892e4f7-042c-4838-8d2a-bbf10a350bf7"), new Guid("4e9fae9f-0bbb-49fd-9bb9-9d2bedf947ae") },
                    { new Guid("9982a47a-de37-4c29-961b-99e20475bb4d"), new Guid("16237d0f-7b2d-4778-bf29-7bb635aa7fee"), new Guid("b2313fcf-8e62-4a1b-a353-22d2feff2e25") },
                    { new Guid("a55fb445-12b7-4795-a194-c320813b75c9"), new Guid("fc6f81e4-fd05-44c5-b5b8-b48773375881"), new Guid("53a1b4e3-e618-4291-aa80-a15ff9870b17") },
                    { new Guid("a5ed8b8e-49b4-48d4-8b6a-97acf5cf433e"), new Guid("2892e4f7-042c-4838-8d2a-bbf10a350bf7"), new Guid("f9c40c9a-48ae-40fc-9f0c-f8736183f15f") },
                    { new Guid("ac0e6084-d528-40a0-b86f-54ef587cdf37"), new Guid("83d9810b-9978-478b-9a07-0b82b6664219"), new Guid("d6f2ffe8-1807-4573-a92f-d2fd8e9f6754") },
                    { new Guid("acb167b0-10ca-44c0-a813-5d8d95c9118e"), new Guid("7948d603-ab38-4e96-8b25-9a9c4d7fd9e7"), new Guid("9590c9a4-49ef-4203-86bb-b6202adb460a") },
                    { new Guid("ae0a17af-ec8b-4d22-a6fd-2530357645ab"), new Guid("cf1640e3-68e0-4ffe-9ddd-8327f22fc61b"), new Guid("0d75044f-7b3c-4551-99c9-745290f885af") },
                    { new Guid("af8ec252-68a1-4d7a-a20f-f26c9d51c288"), new Guid("c1cb6d94-6a3c-42d0-b2b8-7f48063fdabc"), new Guid("a50c573f-0fe3-4b73-83d7-af3d1ccaa940") },
                    { new Guid("b1208c45-ccce-4d19-afde-55830af7e038"), new Guid("247bf261-f901-431d-9055-cc4c2ffdfe0c"), new Guid("fef3a23f-e8f2-4259-b72e-714dc5d8d66f") },
                    { new Guid("b48a2a2f-cdaf-4bb3-9375-2d45b8765d95"), new Guid("79b0193d-fb85-4cd5-a0bb-805a6afcfbc7"), new Guid("fe20e719-8994-43e4-b6a5-7877f43dd71f") },
                    { new Guid("c0369b0b-eb45-4a3f-a5c1-2198fcea7210"), new Guid("832e409b-a161-4ba2-861a-4fdfe3508d81"), new Guid("5bcb9bb2-705d-449f-ada2-094ce4640b19") },
                    { new Guid("c257e924-7359-4323-9ac6-c0d2e73104d9"), new Guid("15c12f1c-e065-4cf1-b01f-3afb0b8a13bb"), new Guid("51efa263-e7cd-421b-a0d2-4ae6ca01181f") },
                    { new Guid("c360b67e-86a8-415a-9392-7647c98d9a1d"), new Guid("fc6f81e4-fd05-44c5-b5b8-b48773375881"), new Guid("13e57d85-d559-42c2-baef-4eca0b470063") },
                    { new Guid("c3a89410-228c-46a9-a554-ef369a58a423"), new Guid("83d9810b-9978-478b-9a07-0b82b6664219"), new Guid("4ee26f97-69da-4f32-9791-c7de51cde71b") },
                    { new Guid("c5008799-6143-4c13-b9e3-0293f3f966d7"), new Guid("6903c3de-098e-4c91-9298-a679c2f19066"), new Guid("3874da02-9a72-4cb4-891f-f87395e044ec") },
                    { new Guid("c8409986-58b9-4ea7-bdd4-1146d8efff6f"), new Guid("79b0193d-fb85-4cd5-a0bb-805a6afcfbc7"), new Guid("171dde7e-ed6e-4760-97db-87f51f71ce45") },
                    { new Guid("cdaaf8b7-fa81-43f6-919d-077b1cee8fb7"), new Guid("ac0ac1d9-1f91-4e93-abad-fa9abe251a7b"), new Guid("bf11f6ff-559c-4cfa-b2fe-0c0f47cc6d32") },
                    { new Guid("d09d77db-52b4-402d-adf8-a4af998b7fcb"), new Guid("c1cb6d94-6a3c-42d0-b2b8-7f48063fdabc"), new Guid("d5d531f6-189e-4325-871c-61206a5b9783") },
                    { new Guid("d0cd527a-4750-4d93-b5fb-e16a44cdcdbd"), new Guid("02907035-d160-4a24-b9ff-211097001331"), new Guid("08927965-1260-43a6-bb62-aa264c9b2333") },
                    { new Guid("d0d1eb8c-c0ea-44f6-bef8-a8a91581c88f"), new Guid("2892e4f7-042c-4838-8d2a-bbf10a350bf7"), new Guid("0f696d08-3ad1-4d37-ad2f-a2e8411e36e9") },
                    { new Guid("d2cb69e2-ff30-41aa-9542-458c7d31ac77"), new Guid("15c12f1c-e065-4cf1-b01f-3afb0b8a13bb"), new Guid("92064190-d0f0-416b-8370-39f83444a8d8") },
                    { new Guid("d3b6b741-1cec-4aaf-953e-ce043dcf8534"), new Guid("16237d0f-7b2d-4778-bf29-7bb635aa7fee"), new Guid("a0284a9d-612d-48e0-89f5-e266a8e8ddae") },
                    { new Guid("d63ca04f-3510-40be-8dc1-56e391ca5d37"), new Guid("96b2dfd0-6c48-48e0-8c35-c4785e9c1792"), new Guid("16d3df79-dc6d-4821-87ac-9b181a766da3") },
                    { new Guid("d7480b02-62be-4240-b715-a66fe7779f34"), new Guid("77083a8d-850f-43db-8ebc-a0e675c948dd"), new Guid("ea7ccdc0-d770-46cd-bda4-3d398701b3eb") },
                    { new Guid("d7de5162-b1d3-41cf-885c-ee05446e92b8"), new Guid("77083a8d-850f-43db-8ebc-a0e675c948dd"), new Guid("852d12d6-d851-4b1e-8812-48b656406c18") },
                    { new Guid("d91c6a3a-8352-4524-8fe5-66d430868086"), new Guid("83d9810b-9978-478b-9a07-0b82b6664219"), new Guid("84965bc6-3382-41ad-893b-e235fefcc58a") },
                    { new Guid("de51d4fa-7451-4cc7-8857-194ceee47790"), new Guid("68f6675e-4e4f-49d3-af80-81094c2d126e"), new Guid("3659546a-05ec-432b-bbf3-c1f52dca374f") },
                    { new Guid("deb532ae-b0d5-4128-92b6-683c472602a0"), new Guid("68f6675e-4e4f-49d3-af80-81094c2d126e"), new Guid("f5d8281b-22c9-4f58-ac1f-76264f9baee7") },
                    { new Guid("dee65a24-d761-4aa6-b22b-45631891858a"), new Guid("96b2dfd0-6c48-48e0-8c35-c4785e9c1792"), new Guid("4898ee70-607c-4984-ab0b-65172bcc6a3f") },
                    { new Guid("def81b2f-e674-4094-bc93-b07149939186"), new Guid("79b0193d-fb85-4cd5-a0bb-805a6afcfbc7"), new Guid("52d40b22-874e-4acb-9680-23a30836d6a7") },
                    { new Guid("e70e2454-38e8-4fe1-b6de-1d296395e315"), new Guid("247bf261-f901-431d-9055-cc4c2ffdfe0c"), new Guid("482b3744-a62c-4d3a-a5fd-976519e407a5") },
                    { new Guid("e95cc1b1-3397-4962-a6f4-38c56e9c6533"), new Guid("bfd52a64-1985-4390-89d9-9659b8b093aa"), new Guid("0dc4743e-67f1-4e5c-9e0b-175e12ae53e5") },
                    { new Guid("ebb6b7a8-b11a-408a-aa72-922593f9f918"), new Guid("5e69856a-54c2-4cd6-b911-3a3d5e6083c6"), new Guid("c22feba7-672f-4f4b-b4d0-fe24f2616a73") },
                    { new Guid("edef1b0e-a044-4e86-961d-290fb1a6f019"), new Guid("02907035-d160-4a24-b9ff-211097001331"), new Guid("c50758b2-3cac-4385-9b42-d4a8f69f396b") },
                    { new Guid("eebeb93e-fdf3-4bb1-914f-9852c5c083a3"), new Guid("fc6f81e4-fd05-44c5-b5b8-b48773375881"), new Guid("f604c25c-792d-4d1f-99f2-c161ee1fcc26") },
                    { new Guid("f1f41c31-bc43-4efc-91c2-c913a7cffd29"), new Guid("fc6f81e4-fd05-44c5-b5b8-b48773375881"), new Guid("4fb95a1b-9f7c-4210-8864-0626eed93c2d") },
                    { new Guid("f251e56e-29ea-4910-bcbe-1e9c87b396f9"), new Guid("8fb58995-131b-4994-b90b-d9e002f31348"), new Guid("86216d14-310f-4d24-a6b3-14462c2f6f14") },
                    { new Guid("fa58b629-38de-436a-b520-ec17a7ed47b0"), new Guid("fc6f81e4-fd05-44c5-b5b8-b48773375881"), new Guid("486b4792-c75c-404a-bc07-98f4b92ba78d") },
                    { new Guid("faf94cf2-b292-4483-8a63-53b2f3073ab4"), new Guid("bfd52a64-1985-4390-89d9-9659b8b093aa"), new Guid("10b7b7d5-f51c-467c-8102-b7671e74c13f") },
                    { new Guid("fe40dcf9-a746-488d-a0be-ae09e3b61eb5"), new Guid("ac0ac1d9-1f91-4e93-abad-fa9abe251a7b"), new Guid("1f589c3b-a86d-4c2e-9632-02fe631f436e") }
                });

            migrationBuilder.InsertData(
                table: "UserPerformanceSummaries",
                columns: new[] { "Id", "CorrectAnswers", "CreatedAt", "LastUpdatedAt", "SuccessRate", "TopicId", "TotalQuestionsAnswered", "UserId" },
                values: new object[,]
                {
                    { new Guid("0c1cefc9-f7e3-4202-9580-493e14ef60c5"), 22, new DateTime(2025, 8, 11, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(589), new DateTime(2025, 8, 19, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(590), 30.989999999999998, new Guid("15c12f1c-e065-4cf1-b01f-3afb0b8a13bb"), 71, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("0f529d4f-d7b3-4f8b-b341-c939722f7409"), 26, new DateTime(2025, 8, 11, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(585), new DateTime(2025, 8, 20, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(586), 39.390000000000001, new Guid("bfd52a64-1985-4390-89d9-9659b8b093aa"), 66, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("207c39fe-f87e-4aea-9726-53be2f90a54a"), 6, new DateTime(2025, 8, 14, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(564), new DateTime(2025, 8, 20, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(570), 27.27, new Guid("bfd52a64-1985-4390-89d9-9659b8b093aa"), 22, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("6b57d144-69aa-4b76-9569-ba17cb24960b"), 64, new DateTime(2025, 8, 10, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(587), new DateTime(2025, 8, 16, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(587), 83.120000000000005, new Guid("c1cb6d94-6a3c-42d0-b2b8-7f48063fdabc"), 77, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("6cc5e82a-6561-49b8-98e9-9a7db0071e12"), 9, new DateTime(2025, 8, 16, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(593), new DateTime(2025, 8, 19, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(594), 19.57, new Guid("fc6f81e4-fd05-44c5-b5b8-b48773375881"), 46, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("78358a61-609f-4200-8b67-97211ce73b53"), 8, new DateTime(2025, 8, 3, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(579), new DateTime(2025, 8, 20, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(579), 38.100000000000001, new Guid("96b2dfd0-6c48-48e0-8c35-c4785e9c1792"), 21, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("7f00655d-b7c1-45be-b024-2ad348b2660d"), 26, new DateTime(2025, 7, 28, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(597), new DateTime(2025, 8, 18, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(597), 61.899999999999999, new Guid("c1cb6d94-6a3c-42d0-b2b8-7f48063fdabc"), 42, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("8d6bb885-ac6a-4489-81bf-cbcd572134d0"), 38, new DateTime(2025, 7, 25, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(601), new DateTime(2025, 8, 18, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(601), 90.480000000000004, new Guid("fc6f81e4-fd05-44c5-b5b8-b48773375881"), 42, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("a66042ad-3c72-42d1-9468-ebaeeb168209"), 79, new DateTime(2025, 7, 23, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(595), new DateTime(2025, 8, 15, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(596), 95.180000000000007, new Guid("bfd52a64-1985-4390-89d9-9659b8b093aa"), 83, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("b53b6f32-cbf8-44cb-b85a-8b97ec4d3044"), 12, new DateTime(2025, 8, 3, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(580), new DateTime(2025, 8, 21, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(581), 34.289999999999999, new Guid("15c12f1c-e065-4cf1-b01f-3afb0b8a13bb"), 35, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("b7da6d25-676e-46ce-9519-f1efbe2fed1c"), 13, new DateTime(2025, 8, 14, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(588), new DateTime(2025, 8, 21, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(588), 19.120000000000001, new Guid("96b2dfd0-6c48-48e0-8c35-c4785e9c1792"), 68, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("d79d5a01-c142-4890-9c70-ac9370f48f08"), 11, new DateTime(2025, 8, 16, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(577), new DateTime(2025, 8, 19, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(577), 14.67, new Guid("c1cb6d94-6a3c-42d0-b2b8-7f48063fdabc"), 75, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("e84dfbcc-7f35-4d59-8d23-2a22761d39df"), 26, new DateTime(2025, 7, 31, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(582), new DateTime(2025, 8, 19, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(582), 34.210000000000001, new Guid("fc6f81e4-fd05-44c5-b5b8-b48773375881"), 76, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("ea03a94d-d948-4ef8-b5ca-bd3c9bf42196"), 33, new DateTime(2025, 8, 7, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(598), new DateTime(2025, 8, 20, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(598), 40.240000000000002, new Guid("96b2dfd0-6c48-48e0-8c35-c4785e9c1792"), 82, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("f0b7ebfb-f2ab-40ba-a78f-b1a1b7bc7978"), 10, new DateTime(2025, 8, 9, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(599), new DateTime(2025, 8, 18, 8, 4, 4, 943, DateTimeKind.Utc).AddTicks(600), 62.5, new Guid("15c12f1c-e065-4cf1-b01f-3afb0b8a13bb"), 16, new Guid("33333333-3333-3333-3333-333333333333") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExamParticipants_ExamId",
                table: "ExamParticipants",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CreatedByUserId",
                table: "Exams",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GeneratedForUserId",
                table: "Questions",
                column: "GeneratedForUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsOptions_QuestionId",
                table: "QuestionsOptions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsTopics_TopicId",
                table: "QuestionsTopics",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ParentTopicId",
                table: "Topics",
                column: "ParentTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_SubjectId",
                table: "Topics",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_ExamId",
                table: "UserAnswers",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_UserId",
                table: "UserAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId",
                table: "UserNotifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPerformanceSummaries_TopicId",
                table: "UserPerformanceSummaries",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPerformanceSummaries_UserId_TopicId",
                table: "UserPerformanceSummaries",
                columns: new[] { "UserId", "TopicId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRecommendations_RelatedTopicId",
                table: "UserRecommendations",
                column: "RelatedTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecommendations_UserId",
                table: "UserRecommendations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ExamParticipants");

            migrationBuilder.DropTable(
                name: "ExamQuestions");

            migrationBuilder.DropTable(
                name: "QuestionsOptions");

            migrationBuilder.DropTable(
                name: "QuestionsTopics");

            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "UserPerformanceSummaries");

            migrationBuilder.DropTable(
                name: "UserRecommendations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
