using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AkademikAi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
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
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "dummy-conc-1", new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(2872), "ali@example.com", true, false, null, "Ali", "ALI@EXAMPLE.COM", "ALI", "AQAAAAEAACcQAAAAEDummyHash1==", "5551111111", false, "dummy-stamp-1", "Veli", false, "ali", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "dummy-conc-2", new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(2879), "ayse@example.com", true, false, null, "Ayşe", "AYSE@EXAMPLE.COM", "AYSE", "AQAAAAEAACcQAAAAEDummyHash2==", "5552222222", false, "dummy-stamp-2", "Yılmaz", false, "ayse", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "dummy-conc-3", new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(2883), "mehmet@example.com", true, false, null, "Mehmet", "MEHMET@EXAMPLE.COM", "MEHMET", "AQAAAAEAACcQAAAAEDummyHash3==", "5553333333", false, "dummy-stamp-3", "Demir", false, "mehmet", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevel", "GeneratedForUserId", "IsActive", "QuestionText", "SolutionText", "Source" },
                values: new object[,]
                {
                    { new Guid("05cacb1f-fb81-4ef8-ade9-a874bdd639b5"), 0, null, true, "Problemler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("068e881b-54af-432c-b8c1-20e3f09cf083"), 1, null, true, "Problemler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1140c297-2770-48b1-b266-1e0dbed7e62d"), 2, null, true, "Problemler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("12a954a7-c2aa-4bf6-b452-67585cef0308"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("135d40e2-967f-4896-92e8-af10868fdfb2"), 2, null, true, "Elektrostatik konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1717ac60-c688-4ec7-82f4-8f0aadcb5823"), 2, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1c2fc5cb-9438-4f04-a529-a86be3dff1de"), 2, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1d479b3a-50a0-407a-bcea-425d201612c5"), 1, null, true, "Hücre konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1ebfb32c-2edb-4a49-88d5-50ef274f2cb3"), 2, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("21605f70-e3cc-4f72-af51-001813b26885"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("21ccfaef-bbaf-4c42-84ba-f2ea3176c851"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("231a4a33-9ad0-4ac9-be0c-fab65da7620c"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("256f276b-3bfb-4bdb-b26b-971217a3539b"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2571ddf7-a9aa-424b-8303-3b933f4e13c1"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("269a3a0d-b3fe-43e4-a399-4b5f54111559"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("39a76a14-1745-43da-afc9-8d9fefc07249"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3c83a7f7-76d3-45aa-b925-e45c3e2e0d28"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3d70c48e-9665-426f-8622-77c8c26599f1"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3e342df6-2378-4db0-b563-9679f1e27479"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3fc6e5a4-e9a4-4344-ab1f-21d58c0a4ebd"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("40d891e2-f9bc-4ad6-aa08-5701c94b215c"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("41306a07-62cb-4155-9e7f-0590d389f5c6"), 1, null, true, "Problemler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("42dc8912-bf6e-4a31-9a56-cd122bc90126"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4f37ac55-ee01-43fe-9ff4-ef65b30272c9"), 1, null, true, "Kalıtım konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4ff50c8b-d779-41e3-963f-ec48efc7b638"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("54c92303-5f97-485e-9bd0-adeb075b6028"), 2, null, true, "Hücre konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("55afd203-0321-4a0a-9096-5f40ff8be409"), 2, null, true, "Temel Kavramlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("58fa1b40-7952-4831-99ff-aceb425554f7"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5c27fd8c-8b7a-4017-963e-432e28dd2482"), 1, null, true, "Kalıtım konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5fc8bc87-7087-4406-90cf-65a9569a0e50"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("61e309ef-e263-48ba-b2db-1244a36d256d"), 2, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("63023acc-1d43-44e4-9292-7b8437a2614b"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("63148dcd-7d67-49d3-8a53-55b01b43b7b7"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("657e2277-51a3-4de7-8174-9e26ce9cdfd4"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("684b3740-3af7-473b-8113-57de37cc9ca5"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6a7f4540-8d85-4728-b838-951cebf15cc9"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6ac51ce1-d7ce-4f69-b0b6-7425a7c3b824"), 2, null, true, "Sayı Basamakları konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6b8d3e40-d0af-43b9-8b9b-bca113c43e63"), 2, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6eecc7d6-e704-47a1-8889-78c3b0f17f07"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6fe13201-d642-4e16-a6bf-77d0f15fbb11"), 2, null, true, "Maddenin Halleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("723da3a2-6253-49fc-a7f6-771e2a47f44a"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("733744d1-0f11-41e6-b034-f2dc0ea9922c"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("78c507d7-00a0-4d5c-b47f-c5ab450b677c"), 0, null, true, "Kalıtım konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7a947aec-6426-414b-bead-7b6e8e6c0cad"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7b5f377b-a9c3-423c-94cb-05dadd6205b9"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7cda3d24-133b-4de8-80d2-42a53bf38cff"), 2, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8bc26171-537a-433d-b315-7c47470b7064"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8dd5ac5f-d21d-462e-b716-e55860de1b2b"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("90c6a6dd-384b-4f0d-9255-aaa2704a519a"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("90d93f04-c893-4e38-bbde-ad14a7f299e3"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("94be52e0-61f0-4381-9f7f-9b89f670e0ed"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("94cff220-3586-4222-9c94-2dd3178ef575"), 0, null, true, "Hücre konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("966e483e-8aac-430c-8f1e-9215c8892420"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9bb2992e-d761-46f5-ba7f-43b16753a0da"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9da39309-e1ef-4bd2-b159-de905237573e"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9dabb6ff-80e2-4017-b09b-d735e6c2d1a8"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9ead5ebb-6b09-41fd-a709-b610695070cb"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9ec27680-1943-4820-ae0b-a1e14e3c72b3"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9ef617f8-1901-48d4-a8cc-14a187049a03"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a02d6e3b-64b6-4610-b617-c527643f0a17"), 2, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a248f17a-d780-49cf-8a16-c872aa686c8b"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a26e377a-7357-47f7-a6ae-0fb1e3d662b2"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a4184c9f-1f6e-4b54-8b29-9b94820bcd1c"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("abdbd19f-1353-4c60-9eee-81ccabfe3099"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b01219d4-b8c8-45a6-b1c5-bf6404d877c5"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b56170da-0aab-45ed-b542-966021b74cda"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b58e9d1f-c68f-428f-8200-0dc5f5f9ae4e"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b73820c6-3fbf-4e73-8a43-e976bca64293"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b749b575-022f-4e30-b061-e09290ec6a35"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b78290f6-f7f8-4b63-9664-98d7d55b0cb0"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("bd71c431-0cfc-416b-a6c8-a81b6a13b489"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c16f43e0-6a32-4654-9271-61eb4e1f311a"), 2, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c17f891c-cd4d-430c-ab3b-1ef8ba3b13e0"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c2ea199f-1c40-4655-b345-1b0c38483830"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c4782e88-ceff-4e4e-9d11-8b08abf71767"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c67f7246-8cc1-47e6-8ad6-d6fda56b096e"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c77f4908-d6e6-4108-bf4e-38bc65e427a9"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c7cce731-c470-4ef2-a03e-22e592a99858"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c99a65f5-cdcb-4d8c-af93-211cc0e6fbc8"), 2, null, true, "Kalıtım konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c9fa7708-e4e4-4df0-8e37-d6e6c92dd4d6"), 0, null, true, "Hücre konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("cb79ee79-946a-49df-b127-c9bd67fc33f3"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ce47c25d-323c-45f7-96fd-1f4acf3737e9"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d2f672b2-2871-4c2f-8e63-ef9548a6b09a"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d3854e2b-2397-4fc9-b1d2-c6b91ca1bd87"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d3db32bc-ddb0-4bb4-a41d-cded9026d334"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d4758d8d-8eee-4264-825a-e82b7807ec45"), 0, null, true, "Kalıtım konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("db5f67e6-29f0-4c0e-aae0-b976dd71f21d"), 2, null, true, "Kimya Bilimi konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ded940c8-673b-4281-b6a1-688f2ea95296"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("df250e8b-79ad-4bd0-8d82-284d7b08464c"), 2, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("dfeedca3-bd62-45c9-a4e7-39013c6c32d3"), 2, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e1b872c7-7368-4af8-b0a0-e8abf2bb3fa5"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e5e91d0d-16f7-4748-9f8b-37981fbe715d"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e7646b17-006a-40d5-9b92-93241b8eea17"), 0, null, true, "Problemler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e95e604c-a75a-4958-96cd-ac3414914c26"), 2, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ea5c9a88-fd74-4228-b22e-6907dbbc9b1f"), 2, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f2e506c4-534a-4458-9283-be550f780a29"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f3083308-1307-42ed-9619-bc5e54b2a62d"), 1, null, true, "Hücre konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f5449f09-9b12-4f97-8094-d1268b96b21a"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fcbd13b4-9309-4d3e-a12d-d4ee7d37b6ed"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ff3654f8-2965-4b28-9392-ab121290cc58"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(2969), "Temel kimya konuları", true, "Kimya" },
                    { new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(2967), "Temel fizik konuları", true, "Fizik" },
                    { new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(2971), "Temel biyoloji konuları", true, "Biyoloji" },
                    { new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(2963), "Temel matematik konuları", true, "Matematik" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "IsCorrect", "Label", "OptionOrder", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("0101fe59-b142-4191-a410-173d19cf4293"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek A", new Guid("21605f70-e3cc-4f72-af51-001813b26885") },
                    { new Guid("0134e376-bd87-4895-b066-6b57378aaad3"), true, "B", 2, "İş, Güç ve Enerji - Soru 4 için Seçenek B", new Guid("3fc6e5a4-e9a4-4344-ab1f-21d58c0a4ebd") },
                    { new Guid("02592af7-cd8a-46f3-a413-bfe750425873"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek B", new Guid("657e2277-51a3-4de7-8174-9e26ce9cdfd4") },
                    { new Guid("02aa054f-264b-4456-8dc4-5ea86614df78"), false, "D", 4, "Temel Kavramlar - Soru 1 için Seçenek D", new Guid("abdbd19f-1353-4c60-9eee-81ccabfe3099") },
                    { new Guid("049de8d0-73da-4df5-b7b1-7a99b3f89998"), false, "C", 3, "İş, Güç ve Enerji - Soru 4 için Seçenek C", new Guid("3fc6e5a4-e9a4-4344-ab1f-21d58c0a4ebd") },
                    { new Guid("04e91d09-f52b-4809-a442-337c92f035f5"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek A", new Guid("21ccfaef-bbaf-4c42-84ba-f2ea3176c851") },
                    { new Guid("058dfb30-63e6-452d-ae8d-1644136fb17c"), false, "B", 2, "Fizik Bilimine Giriş - Soru 2 için Seçenek B", new Guid("256f276b-3bfb-4bdb-b26b-971217a3539b") },
                    { new Guid("078f1b2e-972a-4f4e-a1dc-0a4c841001eb"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek A", new Guid("df250e8b-79ad-4bd0-8d82-284d7b08464c") },
                    { new Guid("08127659-63f5-4eda-b057-63ff933121eb"), false, "B", 2, "Rasyonel Sayılar - Soru 1 için Seçenek B", new Guid("b01219d4-b8c8-45a6-b1c5-bf6404d877c5") },
                    { new Guid("091ac1f0-a8f0-43a9-98da-3630fb0eb946"), false, "C", 3, "Rasyonel Sayılar - Soru 5 için Seçenek C", new Guid("1ebfb32c-2edb-4a49-88d5-50ef274f2cb3") },
                    { new Guid("0a04874f-3fef-449d-af49-71eb428907a9"), false, "B", 2, "Kimya Bilimi - Soru 4 için Seçenek B", new Guid("42dc8912-bf6e-4a31-9a56-cd122bc90126") },
                    { new Guid("0a456569-4793-488d-a80b-c0904475198b"), true, "B", 2, "Madde ve Özellikleri - Soru 2 için Seçenek B", new Guid("9da39309-e1ef-4bd2-b159-de905237573e") },
                    { new Guid("0bdbea6e-da72-4e57-b287-c93386b3bbd2"), false, "A", 1, "Madde ve Özellikleri - Soru 1 için Seçenek A", new Guid("c77f4908-d6e6-4108-bf4e-38bc65e427a9") },
                    { new Guid("0c02f118-01c2-4a6c-b879-07dc44b30ee5"), false, "B", 2, "Maddenin Halleri - Soru 5 için Seçenek B", new Guid("6fe13201-d642-4e16-a6bf-77d0f15fbb11") },
                    { new Guid("0c3d114c-2709-4581-911a-dd81faecfa73"), false, "D", 4, "Temel Kavramlar - Soru 5 için Seçenek D", new Guid("55afd203-0321-4a0a-9096-5f40ff8be409") },
                    { new Guid("0d05ae1b-da9b-4268-980e-0ad9484094c4"), false, "C", 3, "Hücre - Soru 3 için Seçenek C", new Guid("94cff220-3586-4222-9c94-2dd3178ef575") },
                    { new Guid("0e18c680-1a17-40c4-93a2-ff93dcf461a7"), false, "A", 1, "Kalıtım - Soru 1 için Seçenek A", new Guid("d4758d8d-8eee-4264-825a-e82b7807ec45") },
                    { new Guid("0e739754-5224-4bbe-a263-fc4d14e510be"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 2 için Seçenek D", new Guid("e5e91d0d-16f7-4748-9f8b-37981fbe715d") },
                    { new Guid("0f86f367-0920-4adb-b607-a09c82984b66"), false, "D", 4, "İş, Güç ve Enerji - Soru 3 için Seçenek D", new Guid("d3db32bc-ddb0-4bb4-a41d-cded9026d334") },
                    { new Guid("1109c9a5-ca4c-4768-8126-dd4da69c8a74"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek B", new Guid("8bc26171-537a-433d-b315-7c47470b7064") },
                    { new Guid("115538d2-2878-4946-a6aa-908402c643cc"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek A", new Guid("9ead5ebb-6b09-41fd-a709-b610695070cb") },
                    { new Guid("11b2fd69-3bc4-4602-b725-f08306d5ee89"), false, "B", 2, "Sayı Basamakları - Soru 2 için Seçenek B", new Guid("b749b575-022f-4e30-b061-e09290ec6a35") },
                    { new Guid("12199f7e-2544-4bfc-bba3-92354c0ec46c"), true, "B", 2, "Sayı Basamakları - Soru 5 için Seçenek B", new Guid("6ac51ce1-d7ce-4f69-b0b6-7425a7c3b824") },
                    { new Guid("144c26b6-2120-4ee8-bcda-ee4910a18ca5"), false, "C", 3, "Kuvvet ve Hareket - Soru 5 için Seçenek C", new Guid("1717ac60-c688-4ec7-82f4-8f0aadcb5823") },
                    { new Guid("1522629a-4392-493d-a3a3-631789effa09"), true, "B", 2, "Madde ve Özellikleri - Soru 5 için Seçenek B", new Guid("e95e604c-a75a-4958-96cd-ac3414914c26") },
                    { new Guid("152f0b90-158f-408a-8c2e-e6fcc0cd47fc"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 4 için Seçenek B", new Guid("b56170da-0aab-45ed-b542-966021b74cda") },
                    { new Guid("15ad9e17-81fb-420a-9027-ad0a14a889cd"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek B", new Guid("21ccfaef-bbaf-4c42-84ba-f2ea3176c851") },
                    { new Guid("15c7d3af-d72e-495c-a0cb-4d0efcc25c1f"), true, "B", 2, "Temel Kavramlar - Soru 3 için Seçenek B", new Guid("c17f891c-cd4d-430c-ab3b-1ef8ba3b13e0") },
                    { new Guid("15da0d0a-0b95-41e2-a03e-83dff50dcd9d"), false, "C", 3, "Kalıtım - Soru 5 için Seçenek C", new Guid("c99a65f5-cdcb-4d8c-af93-211cc0e6fbc8") },
                    { new Guid("180b9639-91a2-4664-8fb1-a948e8fe2314"), false, "D", 4, "Maddenin Halleri - Soru 3 için Seçenek D", new Guid("269a3a0d-b3fe-43e4-a399-4b5f54111559") },
                    { new Guid("18430215-ba16-4b9d-8c56-ea542027ae28"), false, "C", 3, "Maddenin Halleri - Soru 4 için Seçenek C", new Guid("ff3654f8-2965-4b28-9392-ab121290cc58") },
                    { new Guid("184e0988-b9bd-42dc-8121-f9d0f51a0214"), true, "D", 4, "İş, Güç ve Enerji - Soru 2 için Seçenek D", new Guid("9dabb6ff-80e2-4017-b09b-d735e6c2d1a8") },
                    { new Guid("18648fd0-e7a8-431c-8aee-e83e164985ab"), true, "B", 2, "Maddenin Halleri - Soru 1 için Seçenek B", new Guid("9bb2992e-d761-46f5-ba7f-43b16753a0da") },
                    { new Guid("187dd79b-116d-4165-bf9c-54721434846c"), true, "A", 1, "Temel Kavramlar - Soru 5 için Seçenek A", new Guid("55afd203-0321-4a0a-9096-5f40ff8be409") },
                    { new Guid("1a0c3b91-f9fe-4266-a042-3c669489c6e6"), true, "A", 1, "Kalıtım - Soru 2 için Seçenek A", new Guid("5c27fd8c-8b7a-4017-963e-432e28dd2482") },
                    { new Guid("1a60a0f0-aeba-423c-ba93-ac888f58b80f"), true, "C", 3, "Elektrostatik - Soru 4 için Seçenek C", new Guid("d3854e2b-2397-4fc9-b1d2-c6b91ca1bd87") },
                    { new Guid("1bb165fd-8402-46ba-bd9d-88930eabf156"), true, "D", 4, "Maddenin Halleri - Soru 4 için Seçenek D", new Guid("ff3654f8-2965-4b28-9392-ab121290cc58") },
                    { new Guid("1bbc6c21-a62d-403d-ab79-9dda47a2515b"), true, "A", 1, "Kalıtım - Soru 3 için Seçenek A", new Guid("78c507d7-00a0-4d5c-b47f-c5ab450b677c") },
                    { new Guid("1c2530e9-cacc-4b1f-8585-47cb3e19f7e9"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 3 için Seçenek D", new Guid("9ef617f8-1901-48d4-a8cc-14a187049a03") },
                    { new Guid("1c5f0d3b-2792-4bc3-867e-0d19891ac168"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek C", new Guid("9ead5ebb-6b09-41fd-a709-b610695070cb") },
                    { new Guid("1cbfeb6e-7c4a-4ee8-b3c7-4b23b5fcfd2e"), false, "D", 4, "Rasyonel Sayılar - Soru 4 için Seçenek D", new Guid("6a7f4540-8d85-4728-b838-951cebf15cc9") },
                    { new Guid("1dee9fcc-005d-459b-8a58-cb93e5f4c73d"), false, "B", 2, "Elektrostatik - Soru 3 için Seçenek B", new Guid("fcbd13b4-9309-4d3e-a12d-d4ee7d37b6ed") },
                    { new Guid("1eb4b2ac-fb06-427a-8f10-622d300e59c0"), true, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek B", new Guid("7b5f377b-a9c3-423c-94cb-05dadd6205b9") },
                    { new Guid("1ecf2941-51fe-46cd-a351-2517e9b7ffdc"), false, "C", 3, "Fizik Bilimine Giriş - Soru 5 için Seçenek C", new Guid("61e309ef-e263-48ba-b2db-1244a36d256d") },
                    { new Guid("21942148-3513-43a1-8117-e984190ba201"), false, "C", 3, "Temel Kavramlar - Soru 2 için Seçenek C", new Guid("e1b872c7-7368-4af8-b0a0-e8abf2bb3fa5") },
                    { new Guid("21fed414-5a18-48b6-aca2-d83152be1bfe"), true, "A", 1, "Canlıların Sınıflandırılması - Soru 5 için Seçenek A", new Guid("6b8d3e40-d0af-43b9-8b9b-bca113c43e63") },
                    { new Guid("2262c0c2-3516-4c8d-a578-027dedd236c1"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek B", new Guid("684b3740-3af7-473b-8113-57de37cc9ca5") },
                    { new Guid("227107c1-b750-4b9f-beea-9fb66cefd301"), false, "A", 1, "Hücre Bölünmeleri - Soru 3 için Seçenek A", new Guid("966e483e-8aac-430c-8f1e-9215c8892420") },
                    { new Guid("2323e25c-5178-47a2-8fff-a82f97014062"), false, "A", 1, "Kimya Bilimi - Soru 4 için Seçenek A", new Guid("42dc8912-bf6e-4a31-9a56-cd122bc90126") },
                    { new Guid("23abab21-dfab-484f-937d-675355e32729"), false, "D", 4, "Hücre - Soru 3 için Seçenek D", new Guid("94cff220-3586-4222-9c94-2dd3178ef575") },
                    { new Guid("24087170-43b2-4518-affc-4c48704e2050"), true, "C", 3, "Maddenin Halleri - Soru 5 için Seçenek C", new Guid("6fe13201-d642-4e16-a6bf-77d0f15fbb11") },
                    { new Guid("2408f296-a473-4d53-b113-3ce105ee6d85"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek A", new Guid("a02d6e3b-64b6-4610-b617-c527643f0a17") },
                    { new Guid("2413136d-8f7e-4143-9b4e-7d9923429a9b"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 3 için Seçenek B", new Guid("90d93f04-c893-4e38-bbde-ad14a7f299e3") },
                    { new Guid("24c2a6bd-6608-4cb5-abdd-fb3d9fe53113"), false, "A", 1, "Hücre - Soru 4 için Seçenek A", new Guid("1d479b3a-50a0-407a-bcea-425d201612c5") },
                    { new Guid("2747fed2-33fa-4a59-a7b2-38d378d68948"), false, "D", 4, "Bölme ve Bölünebilme - Soru 2 için Seçenek D", new Guid("f5449f09-9b12-4f97-8094-d1268b96b21a") },
                    { new Guid("2788289c-37c7-4206-9042-a419eb3f1789"), true, "D", 4, "Hücre Bölünmeleri - Soru 5 için Seçenek D", new Guid("ea5c9a88-fd74-4228-b22e-6907dbbc9b1f") },
                    { new Guid("278fa059-4991-4923-a481-afb6c00a7462"), false, "C", 3, "Hücre - Soru 5 için Seçenek C", new Guid("54c92303-5f97-485e-9bd0-adeb075b6028") },
                    { new Guid("28030ce9-994b-4601-9444-ddd988c73de4"), false, "A", 1, "Rasyonel Sayılar - Soru 1 için Seçenek A", new Guid("b01219d4-b8c8-45a6-b1c5-bf6404d877c5") },
                    { new Guid("28f6f5ca-c109-45a4-a44a-bdebb9e46999"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 4 için Seçenek A", new Guid("9ec27680-1943-4820-ae0b-a1e14e3c72b3") },
                    { new Guid("2a4d49f8-b4a1-4c32-a3d3-10c81dcb79ed"), true, "C", 3, "Sayı Basamakları - Soru 1 için Seçenek C", new Guid("94be52e0-61f0-4381-9f7f-9b89f670e0ed") },
                    { new Guid("2c09408d-bdf7-4c1b-ba23-37182fbabb7a"), false, "A", 1, "Madde ve Özellikleri - Soru 5 için Seçenek A", new Guid("e95e604c-a75a-4958-96cd-ac3414914c26") },
                    { new Guid("2cc64697-a471-4878-aa90-3c4bf9c12376"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 1 için Seçenek D", new Guid("6eecc7d6-e704-47a1-8889-78c3b0f17f07") },
                    { new Guid("2db649ae-fb9a-473f-88a2-03d45fd582a4"), false, "A", 1, "Problemler - Soru 1 için Seçenek A", new Guid("e7646b17-006a-40d5-9b92-93241b8eea17") },
                    { new Guid("2e379316-1870-462c-8174-19e2d97dfc98"), false, "D", 4, "Problemler - Soru 2 için Seçenek D", new Guid("068e881b-54af-432c-b8c1-20e3f09cf083") },
                    { new Guid("2f2dd211-abd0-41b2-a1b2-2f8ca5931004"), false, "B", 2, "Rasyonel Sayılar - Soru 2 için Seçenek B", new Guid("40d891e2-f9bc-4ad6-aa08-5701c94b215c") },
                    { new Guid("3079a046-6705-41db-88b3-86795ac7ed4b"), false, "A", 1, "Fizik Bilimine Giriş - Soru 1 için Seçenek A", new Guid("a248f17a-d780-49cf-8a16-c872aa686c8b") },
                    { new Guid("309421e8-0d76-466b-927e-de04ce4f7f3e"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 3 için Seçenek A", new Guid("90d93f04-c893-4e38-bbde-ad14a7f299e3") },
                    { new Guid("31795bff-31f1-4dbb-8dfc-0edaa19e5654"), true, "B", 2, "Fizik Bilimine Giriş - Soru 4 için Seçenek B", new Guid("12a954a7-c2aa-4bf6-b452-67585cef0308") },
                    { new Guid("31825710-4403-4e91-95ae-4aca1cc2aacb"), false, "D", 4, "Madde ve Özellikleri - Soru 1 için Seçenek D", new Guid("c77f4908-d6e6-4108-bf4e-38bc65e427a9") },
                    { new Guid("328e552e-a224-4b17-a225-5eea8e6d7ac5"), false, "B", 2, "İş, Güç ve Enerji - Soru 3 için Seçenek B", new Guid("d3db32bc-ddb0-4bb4-a41d-cded9026d334") },
                    { new Guid("32b90617-33dd-4b68-bd35-241063c625e1"), false, "C", 3, "Problemler - Soru 4 için Seçenek C", new Guid("41306a07-62cb-4155-9e7f-0590d389f5c6") },
                    { new Guid("33089eb2-71e0-42f0-810e-d5093bb35d94"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek C", new Guid("a02d6e3b-64b6-4610-b617-c527643f0a17") },
                    { new Guid("33127094-934b-45b6-bca5-1490fbf32687"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek D", new Guid("657e2277-51a3-4de7-8174-9e26ce9cdfd4") },
                    { new Guid("3399b1f9-774c-4ce4-9f8d-3236917ddf83"), false, "D", 4, "Rasyonel Sayılar - Soru 5 için Seçenek D", new Guid("1ebfb32c-2edb-4a49-88d5-50ef274f2cb3") },
                    { new Guid("33a6aba7-008b-40e8-95f0-cf9be586e6b4"), true, "A", 1, "Bölme ve Bölünebilme - Soru 1 için Seçenek A", new Guid("3c83a7f7-76d3-45aa-b925-e45c3e2e0d28") },
                    { new Guid("33d54e1c-43b0-41fb-b0a1-0787d0f8dff9"), false, "D", 4, "Temel Kavramlar - Soru 3 için Seçenek D", new Guid("c17f891c-cd4d-430c-ab3b-1ef8ba3b13e0") },
                    { new Guid("344235d1-f186-4281-b56a-7a96f0b67e9a"), false, "D", 4, "Temel Kavramlar - Soru 4 için Seçenek D", new Guid("c7cce731-c470-4ef2-a03e-22e592a99858") },
                    { new Guid("3462f804-e8bd-4db5-ba9d-a4190a91306d"), true, "C", 3, "Temel Kavramlar - Soru 4 için Seçenek C", new Guid("c7cce731-c470-4ef2-a03e-22e592a99858") },
                    { new Guid("34e1f000-6fd6-4a0d-8b67-aac5ed74da2e"), false, "D", 4, "Kalıtım - Soru 1 için Seçenek D", new Guid("d4758d8d-8eee-4264-825a-e82b7807ec45") },
                    { new Guid("3519ac32-29e7-4e3c-8084-442dcf17e425"), false, "A", 1, "Hücre Bölünmeleri - Soru 4 için Seçenek A", new Guid("b73820c6-3fbf-4e73-8a43-e976bca64293") },
                    { new Guid("35bf7764-daef-4210-a541-94f2f4c088d3"), false, "A", 1, "Sayı Basamakları - Soru 3 için Seçenek A", new Guid("d2f672b2-2871-4c2f-8e63-ef9548a6b09a") },
                    { new Guid("364556ea-1f3e-47f2-868a-74cbc4a069a9"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek A", new Guid("231a4a33-9ad0-4ac9-be0c-fab65da7620c") },
                    { new Guid("3664e646-08ea-41cc-af1c-7fb9655fcaa6"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 2 için Seçenek D", new Guid("3d70c48e-9665-426f-8622-77c8c26599f1") },
                    { new Guid("3678d665-ea44-45b8-a8ca-d7008b8bf92c"), false, "C", 3, "Bölme ve Bölünebilme - Soru 1 için Seçenek C", new Guid("3c83a7f7-76d3-45aa-b925-e45c3e2e0d28") },
                    { new Guid("3694edf5-90cd-4b0a-9c42-956ff8b6fe2a"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek B", new Guid("bd71c431-0cfc-416b-a6c8-a81b6a13b489") },
                    { new Guid("37825dda-2e75-401e-91d9-592ae872b6a1"), false, "A", 1, "Maddenin Halleri - Soru 3 için Seçenek A", new Guid("269a3a0d-b3fe-43e4-a399-4b5f54111559") },
                    { new Guid("378264be-d543-4907-b3d7-7207442f6d1c"), true, "B", 2, "Rasyonel Sayılar - Soru 4 için Seçenek B", new Guid("6a7f4540-8d85-4728-b838-951cebf15cc9") },
                    { new Guid("3843a133-1566-408e-a920-a1f538ed5fe8"), true, "C", 3, "Elektrostatik - Soru 3 için Seçenek C", new Guid("fcbd13b4-9309-4d3e-a12d-d4ee7d37b6ed") },
                    { new Guid("38b5d27b-0289-43bf-bcb5-a212ac7b89c0"), true, "D", 4, "Hücre Bölünmeleri - Soru 2 için Seçenek D", new Guid("b78290f6-f7f8-4b63-9664-98d7d55b0cb0") },
                    { new Guid("393ca43e-c239-458b-b363-3cb03f8bb0db"), false, "D", 4, "Sayı Basamakları - Soru 3 için Seçenek D", new Guid("d2f672b2-2871-4c2f-8e63-ef9548a6b09a") },
                    { new Guid("395303b0-bfd2-492d-8718-e27442f0aeca"), false, "A", 1, "Hücre Bölünmeleri - Soru 5 için Seçenek A", new Guid("ea5c9a88-fd74-4228-b22e-6907dbbc9b1f") },
                    { new Guid("39ac06d4-4a99-4c0d-a470-db1db594b096"), true, "D", 4, "Kuvvet ve Hareket - Soru 2 için Seçenek D", new Guid("5fc8bc87-7087-4406-90cf-65a9569a0e50") },
                    { new Guid("39c97084-7ca4-42c2-8173-55da7ad23d9d"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek A", new Guid("684b3740-3af7-473b-8113-57de37cc9ca5") },
                    { new Guid("3a2a05e0-8b55-4f3a-a18a-afaabfbfafb5"), false, "B", 2, "Fizik Bilimine Giriş - Soru 1 için Seçenek B", new Guid("a248f17a-d780-49cf-8a16-c872aa686c8b") },
                    { new Guid("3a682f8f-d75f-493c-8156-fd7a78551388"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 5 için Seçenek B", new Guid("dfeedca3-bd62-45c9-a4e7-39013c6c32d3") },
                    { new Guid("3a6dbec2-c073-4349-8099-e4d3abcdd5b9"), false, "D", 4, "Kalıtım - Soru 4 için Seçenek D", new Guid("4f37ac55-ee01-43fe-9ff4-ef65b30272c9") },
                    { new Guid("3cead765-6da0-40c4-b5ea-066e39125fdb"), false, "B", 2, "Problemler - Soru 2 için Seçenek B", new Guid("068e881b-54af-432c-b8c1-20e3f09cf083") },
                    { new Guid("3da1aa13-63fd-4865-8d91-29f655d6d12d"), true, "C", 3, "İş, Güç ve Enerji - Soru 3 için Seçenek C", new Guid("d3db32bc-ddb0-4bb4-a41d-cded9026d334") },
                    { new Guid("3f331d2f-e395-4f17-aad6-a13cd45cce23"), false, "D", 4, "Kalıtım - Soru 2 için Seçenek D", new Guid("5c27fd8c-8b7a-4017-963e-432e28dd2482") },
                    { new Guid("3feafd3f-3645-401c-b559-1de0e95641bc"), false, "D", 4, "Hücre - Soru 5 için Seçenek D", new Guid("54c92303-5f97-485e-9bd0-adeb075b6028") },
                    { new Guid("40508089-24e6-426f-bfd1-701a27e9ae0e"), false, "B", 2, "Elektrostatik - Soru 1 için Seçenek B", new Guid("58fa1b40-7952-4831-99ff-aceb425554f7") },
                    { new Guid("409ba2fc-8ddd-4bd0-a95d-55f43d58e752"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek A", new Guid("1c2fc5cb-9438-4f04-a529-a86be3dff1de") },
                    { new Guid("40bc317a-93d6-4a8c-a9eb-897f9a0e6f0a"), false, "C", 3, "Hücre Bölünmeleri - Soru 3 için Seçenek C", new Guid("966e483e-8aac-430c-8f1e-9215c8892420") },
                    { new Guid("4107bfc3-4f90-47bf-a566-8f893fed5e54"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek D", new Guid("21605f70-e3cc-4f72-af51-001813b26885") },
                    { new Guid("42d3c10b-fef0-4d17-9674-a38a60afbb05"), false, "A", 1, "Elektrostatik - Soru 3 için Seçenek A", new Guid("fcbd13b4-9309-4d3e-a12d-d4ee7d37b6ed") },
                    { new Guid("434ed17c-92a5-4ba4-858a-362932764306"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 4 için Seçenek A", new Guid("b56170da-0aab-45ed-b542-966021b74cda") },
                    { new Guid("4373d98c-afb3-4b1b-a70b-f610796a920a"), false, "A", 1, "Kuvvet ve Hareket - Soru 2 için Seçenek A", new Guid("5fc8bc87-7087-4406-90cf-65a9569a0e50") },
                    { new Guid("43a0b51e-2f67-4d6d-9355-44e598630ff4"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 2 için Seçenek B", new Guid("3d70c48e-9665-426f-8622-77c8c26599f1") },
                    { new Guid("453facdc-d6a9-4bad-96ca-074b6b297c11"), false, "D", 4, "Kalıtım - Soru 3 için Seçenek D", new Guid("78c507d7-00a0-4d5c-b47f-c5ab450b677c") },
                    { new Guid("46837135-8a1c-4a02-b84f-753eba362bc3"), false, "A", 1, "Rasyonel Sayılar - Soru 3 için Seçenek A", new Guid("7a947aec-6426-414b-bead-7b6e8e6c0cad") },
                    { new Guid("4742abf4-07b6-4381-aaf2-8a61f83dfd04"), false, "B", 2, "Hücre - Soru 3 için Seçenek B", new Guid("94cff220-3586-4222-9c94-2dd3178ef575") },
                    { new Guid("476ec1e7-9bce-4ef3-8f1c-76d020006ffb"), false, "C", 3, "Problemler - Soru 1 için Seçenek C", new Guid("e7646b17-006a-40d5-9b92-93241b8eea17") },
                    { new Guid("4774928b-485d-4075-a06d-5f5dd4a62816"), false, "A", 1, "İş, Güç ve Enerji - Soru 3 için Seçenek A", new Guid("d3db32bc-ddb0-4bb4-a41d-cded9026d334") },
                    { new Guid("4a129a2d-a5a0-4723-bd88-02dcdeb5922d"), false, "D", 4, "Sayı Basamakları - Soru 4 için Seçenek D", new Guid("90c6a6dd-384b-4f0d-9255-aaa2704a519a") },
                    { new Guid("4a18f618-5675-4219-bffb-3634dd5af7b6"), false, "A", 1, "Elektrostatik - Soru 4 için Seçenek A", new Guid("d3854e2b-2397-4fc9-b1d2-c6b91ca1bd87") },
                    { new Guid("4dcaa889-cdca-4dba-9990-9a149f8f0304"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 1 için Seçenek A", new Guid("4ff50c8b-d779-41e3-963f-ec48efc7b638") },
                    { new Guid("4e9c0cd3-3bab-4484-9e01-c728d4c7fc92"), false, "A", 1, "Hücre Bölünmeleri - Soru 1 için Seçenek A", new Guid("39a76a14-1745-43da-afc9-8d9fefc07249") },
                    { new Guid("4f11dde8-d3bc-48b4-af62-15328f18406a"), false, "A", 1, "Temel Kavramlar - Soru 1 için Seçenek A", new Guid("abdbd19f-1353-4c60-9eee-81ccabfe3099") },
                    { new Guid("4fc41a65-d20a-4f91-bd13-28fc1cd49482"), false, "A", 1, "Sayı Basamakları - Soru 5 için Seçenek A", new Guid("6ac51ce1-d7ce-4f69-b0b6-7425a7c3b824") },
                    { new Guid("4fc58e84-e8d5-428a-86a5-34ce865d8121"), true, "A", 1, "Elektrostatik - Soru 5 için Seçenek A", new Guid("135d40e2-967f-4896-92e8-af10868fdfb2") },
                    { new Guid("4fdab68a-6382-4c0d-8a46-1ca2b3ab57a8"), false, "D", 4, "Kimya Bilimi - Soru 4 için Seçenek D", new Guid("42dc8912-bf6e-4a31-9a56-cd122bc90126") },
                    { new Guid("517f6c6c-fe76-45fc-8898-70a3189f12ce"), false, "B", 2, "Kuvvet ve Hareket - Soru 3 için Seçenek B", new Guid("3e342df6-2378-4db0-b563-9679f1e27479") },
                    { new Guid("51f40a53-7e61-467f-919b-3c7433404b71"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek A", new Guid("c67f7246-8cc1-47e6-8ad6-d6fda56b096e") },
                    { new Guid("54cf8ccc-1656-4f0c-a517-19fc7dc5a89a"), false, "B", 2, "Hücre - Soru 2 için Seçenek B", new Guid("f3083308-1307-42ed-9619-bc5e54b2a62d") },
                    { new Guid("551367aa-90a5-40ff-a96f-9b0b7ce73a57"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 5 için Seçenek B", new Guid("6b8d3e40-d0af-43b9-8b9b-bca113c43e63") },
                    { new Guid("5521ab1e-42e7-4b64-9dad-665f6dcdedf4"), false, "D", 4, "Maddenin Halleri - Soru 1 için Seçenek D", new Guid("9bb2992e-d761-46f5-ba7f-43b16753a0da") },
                    { new Guid("559b4f1d-f3a8-496a-9a02-e49b2be771a9"), true, "B", 2, "Kimya Bilimi - Soru 2 için Seçenek B", new Guid("8dd5ac5f-d21d-462e-b716-e55860de1b2b") },
                    { new Guid("55b70428-73a1-425c-9f29-1e799cc03177"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek D", new Guid("9ead5ebb-6b09-41fd-a709-b610695070cb") },
                    { new Guid("5656d270-b945-43f5-862b-56af1b698fe5"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 3 için Seçenek B", new Guid("9ef617f8-1901-48d4-a8cc-14a187049a03") },
                    { new Guid("56c0d30f-8e8c-4372-b27c-98208b04cd01"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek D", new Guid("bd71c431-0cfc-416b-a6c8-a81b6a13b489") },
                    { new Guid("57416d79-01b1-4ae9-b681-54ce57d1fb9e"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek C", new Guid("df250e8b-79ad-4bd0-8d82-284d7b08464c") },
                    { new Guid("57fcba94-996d-4292-9145-9c6592ff7d71"), false, "C", 3, "Kalıtım - Soru 1 için Seçenek C", new Guid("d4758d8d-8eee-4264-825a-e82b7807ec45") },
                    { new Guid("585bed59-914a-4f5f-ab14-400ef1eb2ea3"), false, "A", 1, "İş, Güç ve Enerji - Soru 2 için Seçenek A", new Guid("9dabb6ff-80e2-4017-b09b-d735e6c2d1a8") },
                    { new Guid("5865e5d4-a6cd-4178-b62a-1b73bb82f008"), true, "D", 4, "Bölme ve Bölünebilme - Soru 5 için Seçenek D", new Guid("7cda3d24-133b-4de8-80d2-42a53bf38cff") },
                    { new Guid("58d038ca-ddb6-4ef4-ad95-b41dc258cd3e"), false, "C", 3, "Madde ve Özellikleri - Soru 5 için Seçenek C", new Guid("e95e604c-a75a-4958-96cd-ac3414914c26") },
                    { new Guid("58d4794a-c9e9-4b45-9ce6-9179c8adcf9c"), false, "B", 2, "Kalıtım - Soru 5 için Seçenek B", new Guid("c99a65f5-cdcb-4d8c-af93-211cc0e6fbc8") },
                    { new Guid("58f47762-0c84-4b0e-8786-56ff36b6da90"), false, "C", 3, "Hücre Bölünmeleri - Soru 4 için Seçenek C", new Guid("b73820c6-3fbf-4e73-8a43-e976bca64293") },
                    { new Guid("597286b0-baad-4af5-81dc-f53a0e8836ab"), false, "D", 4, "Kalıtım - Soru 5 için Seçenek D", new Guid("c99a65f5-cdcb-4d8c-af93-211cc0e6fbc8") },
                    { new Guid("597e948d-a3ed-4efd-aadf-514ddb8d0288"), false, "D", 4, "Problemler - Soru 1 için Seçenek D", new Guid("e7646b17-006a-40d5-9b92-93241b8eea17") },
                    { new Guid("59959ca6-8b2d-4128-a02c-8bdf793d920b"), false, "C", 3, "Sayı Basamakları - Soru 5 için Seçenek C", new Guid("6ac51ce1-d7ce-4f69-b0b6-7425a7c3b824") },
                    { new Guid("5c34c897-6608-4562-8712-eec83b56db9f"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 3 için Seçenek C", new Guid("90d93f04-c893-4e38-bbde-ad14a7f299e3") },
                    { new Guid("5d9982c5-31c4-447e-9b63-ace9184fa0f0"), false, "B", 2, "Problemler - Soru 3 için Seçenek B", new Guid("05cacb1f-fb81-4ef8-ade9-a874bdd639b5") },
                    { new Guid("5e5ca9a7-9082-4100-975b-ebf8470b0b79"), true, "B", 2, "Hücre - Soru 5 için Seçenek B", new Guid("54c92303-5f97-485e-9bd0-adeb075b6028") },
                    { new Guid("5f717dfb-d632-493e-89ab-a21a669e10e8"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 4 için Seçenek C", new Guid("9ec27680-1943-4820-ae0b-a1e14e3c72b3") },
                    { new Guid("5ff96c20-565f-4d8e-97ae-4dc010eda5cc"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek C", new Guid("231a4a33-9ad0-4ac9-be0c-fab65da7620c") },
                    { new Guid("6020d68f-7d04-4083-8542-d6fb88806773"), false, "B", 2, "Bölme ve Bölünebilme - Soru 2 için Seçenek B", new Guid("f5449f09-9b12-4f97-8094-d1268b96b21a") },
                    { new Guid("608fb8c1-a903-4b32-a6dd-26d726cb3fba"), true, "D", 4, "Hücre Bölünmeleri - Soru 4 için Seçenek D", new Guid("b73820c6-3fbf-4e73-8a43-e976bca64293") },
                    { new Guid("61d42c3d-dd37-4000-8b7f-75217b365148"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek A", new Guid("8bc26171-537a-433d-b315-7c47470b7064") },
                    { new Guid("6411fee8-7dc7-4ee1-80ed-d21137dc465d"), true, "C", 3, "Hücre - Soru 1 için Seçenek C", new Guid("c9fa7708-e4e4-4df0-8e37-d6e6c92dd4d6") },
                    { new Guid("646b76ae-71b9-47ef-929a-efb7ea8cca21"), false, "B", 2, "İş, Güç ve Enerji - Soru 1 için Seçenek B", new Guid("ded940c8-673b-4281-b6a1-688f2ea95296") },
                    { new Guid("653a08b3-494b-4c4f-ad9c-1d2691bf529d"), false, "C", 3, "Bölme ve Bölünebilme - Soru 5 için Seçenek C", new Guid("7cda3d24-133b-4de8-80d2-42a53bf38cff") },
                    { new Guid("653a9eee-bafc-4e33-a32f-98e0ed1ef8fb"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 1 için Seçenek C", new Guid("6eecc7d6-e704-47a1-8889-78c3b0f17f07") },
                    { new Guid("65f7cc3e-ed8c-4294-b7e6-f76960279c47"), false, "A", 1, "Temel Kavramlar - Soru 3 için Seçenek A", new Guid("c17f891c-cd4d-430c-ab3b-1ef8ba3b13e0") },
                    { new Guid("678e7eda-0b8c-4a47-9af0-809473b19366"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek C", new Guid("21ccfaef-bbaf-4c42-84ba-f2ea3176c851") },
                    { new Guid("6a8ac338-48f3-4777-8ab4-ed5095da517b"), false, "C", 3, "Kuvvet ve Hareket - Soru 1 için Seçenek C", new Guid("c4782e88-ceff-4e4e-9d11-8b08abf71767") },
                    { new Guid("6adc36b6-0e34-48ee-95fb-2cb3fc0f92af"), false, "A", 1, "Madde ve Özellikleri - Soru 3 için Seçenek A", new Guid("a4184c9f-1f6e-4b54-8b29-9b94820bcd1c") },
                    { new Guid("6ae27592-3034-4e8a-959a-32b65beabe4a"), false, "C", 3, "Problemler - Soru 5 için Seçenek C", new Guid("1140c297-2770-48b1-b266-1e0dbed7e62d") },
                    { new Guid("6b803036-14cd-4373-bff6-3e63676a086a"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 4 için Seçenek D", new Guid("9ec27680-1943-4820-ae0b-a1e14e3c72b3") },
                    { new Guid("6b995c93-1a3c-48b8-95d2-ce36ffeb6022"), false, "A", 1, "Maddenin Halleri - Soru 4 için Seçenek A", new Guid("ff3654f8-2965-4b28-9392-ab121290cc58") },
                    { new Guid("6bfafda3-8c79-4178-81ac-68e5e5d286cc"), false, "C", 3, "Hücre - Soru 2 için Seçenek C", new Guid("f3083308-1307-42ed-9619-bc5e54b2a62d") },
                    { new Guid("6db3c8ed-de39-4ea8-94c8-143b29ccaac2"), false, "B", 2, "Kimya Bilimi - Soru 5 için Seçenek B", new Guid("db5f67e6-29f0-4c0e-aae0-b976dd71f21d") },
                    { new Guid("6fe3d499-13b3-402a-a554-be9c140d4d1d"), false, "B", 2, "Elektrostatik - Soru 2 için Seçenek B", new Guid("f2e506c4-534a-4458-9283-be550f780a29") },
                    { new Guid("7081e2b9-45b4-4d95-a7b3-80852765efb0"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek D", new Guid("df250e8b-79ad-4bd0-8d82-284d7b08464c") },
                    { new Guid("7119877c-af50-40a9-ac5f-09d40f405113"), false, "A", 1, "İş, Güç ve Enerji - Soru 5 için Seçenek A", new Guid("c16f43e0-6a32-4654-9271-61eb4e1f311a") },
                    { new Guid("7126cc3f-06d9-4037-ad40-e66fee476810"), false, "D", 4, "Fizik Bilimine Giriş - Soru 5 için Seçenek D", new Guid("61e309ef-e263-48ba-b2db-1244a36d256d") },
                    { new Guid("72ccdf5a-0df5-4a8f-91eb-e144a2912cb4"), true, "A", 1, "Problemler - Soru 2 için Seçenek A", new Guid("068e881b-54af-432c-b8c1-20e3f09cf083") },
                    { new Guid("73cb7e64-1bf1-41c9-bdf8-11b61cd67de5"), true, "D", 4, "Rasyonel Sayılar - Soru 2 için Seçenek D", new Guid("40d891e2-f9bc-4ad6-aa08-5701c94b215c") },
                    { new Guid("744dc34e-9bb3-4004-82f1-73b4cf713534"), false, "D", 4, "Bölme ve Bölünebilme - Soru 3 için Seçenek D", new Guid("c2ea199f-1c40-4655-b345-1b0c38483830") },
                    { new Guid("746e6a50-6fb1-4851-a628-18d93a12f834"), false, "C", 3, "Hücre - Soru 4 için Seçenek C", new Guid("1d479b3a-50a0-407a-bcea-425d201612c5") },
                    { new Guid("74cdaeac-eaeb-494c-a084-46cbbf04217f"), false, "B", 2, "Madde ve Özellikleri - Soru 4 için Seçenek B", new Guid("b58e9d1f-c68f-428f-8200-0dc5f5f9ae4e") },
                    { new Guid("753defe6-e225-47ad-82f1-9e5f30caf503"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 4 için Seçenek D", new Guid("b56170da-0aab-45ed-b542-966021b74cda") },
                    { new Guid("75ab3034-1a5b-4e86-b525-39b46fba5e4a"), true, "D", 4, "Fizik Bilimine Giriş - Soru 1 için Seçenek D", new Guid("a248f17a-d780-49cf-8a16-c872aa686c8b") },
                    { new Guid("76497d0e-0cba-48d5-8520-826013ba859f"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 5 için Seçenek D", new Guid("6b8d3e40-d0af-43b9-8b9b-bca113c43e63") },
                    { new Guid("764f4cc9-3405-41b4-9d39-13a6acb5429f"), false, "C", 3, "Kalıtım - Soru 3 için Seçenek C", new Guid("78c507d7-00a0-4d5c-b47f-c5ab450b677c") },
                    { new Guid("78daa525-e2be-4ac3-8fe6-7597ffc606ce"), false, "D", 4, "Kimya Bilimi - Soru 5 için Seçenek D", new Guid("db5f67e6-29f0-4c0e-aae0-b976dd71f21d") },
                    { new Guid("7a51f63c-2a10-462e-b2e7-0a0d59134cf4"), false, "D", 4, "İş, Güç ve Enerji - Soru 5 için Seçenek D", new Guid("c16f43e0-6a32-4654-9271-61eb4e1f311a") },
                    { new Guid("7a5caf83-d262-49a7-b5d3-993616b37bde"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 1 için Seçenek B", new Guid("6eecc7d6-e704-47a1-8889-78c3b0f17f07") },
                    { new Guid("7ac759cd-3d37-4134-b482-8d44137f563c"), false, "D", 4, "Kimya Bilimi - Soru 1 için Seçenek D", new Guid("ce47c25d-323c-45f7-96fd-1f4acf3737e9") },
                    { new Guid("7adfba4b-80e1-4107-b5d6-eda2d9643949"), false, "C", 3, "Fizik Bilimine Giriş - Soru 1 için Seçenek C", new Guid("a248f17a-d780-49cf-8a16-c872aa686c8b") },
                    { new Guid("7b5e3a24-fec3-428a-8fcc-0a19190b1338"), false, "D", 4, "Madde ve Özellikleri - Soru 4 için Seçenek D", new Guid("b58e9d1f-c68f-428f-8200-0dc5f5f9ae4e") },
                    { new Guid("7ba42bf5-19f8-4e83-8ed1-57714f053721"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek B", new Guid("c67f7246-8cc1-47e6-8ad6-d6fda56b096e") },
                    { new Guid("7bae7195-4ce0-4cea-920a-95658d5dc84c"), false, "C", 3, "Temel Kavramlar - Soru 3 için Seçenek C", new Guid("c17f891c-cd4d-430c-ab3b-1ef8ba3b13e0") },
                    { new Guid("7bc72b5c-074f-46ae-9c76-cd74d2a58191"), false, "D", 4, "Kuvvet ve Hareket - Soru 3 için Seçenek D", new Guid("3e342df6-2378-4db0-b563-9679f1e27479") },
                    { new Guid("7c32e53c-849d-4f88-9518-83e185c7d088"), false, "B", 2, "Kimya Bilimi - Soru 1 için Seçenek B", new Guid("ce47c25d-323c-45f7-96fd-1f4acf3737e9") },
                    { new Guid("7ca091dc-8f94-4bd1-b1ab-14ba6548803b"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek C", new Guid("684b3740-3af7-473b-8113-57de37cc9ca5") },
                    { new Guid("7d3faa19-389c-4c35-b3a0-0dd510bbf968"), false, "B", 2, "Kalıtım - Soru 3 için Seçenek B", new Guid("78c507d7-00a0-4d5c-b47f-c5ab450b677c") },
                    { new Guid("7d46dac4-535e-4b8a-bfbf-98ac2e526b71"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek B", new Guid("733744d1-0f11-41e6-b034-f2dc0ea9922c") },
                    { new Guid("7ee5b2ca-c238-4c7e-bb4c-5317b59e8ab7"), false, "D", 4, "Problemler - Soru 5 için Seçenek D", new Guid("1140c297-2770-48b1-b266-1e0dbed7e62d") },
                    { new Guid("7f6c858c-c92d-4e4b-bfee-102be41a1406"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek C", new Guid("8bc26171-537a-433d-b315-7c47470b7064") },
                    { new Guid("7fdeb462-3e49-481d-b317-66a8629747b0"), false, "A", 1, "Hücre Bölünmeleri - Soru 2 için Seçenek A", new Guid("b78290f6-f7f8-4b63-9664-98d7d55b0cb0") },
                    { new Guid("8064c234-ae5a-47a4-8b7a-24e04605a919"), false, "B", 2, "Madde ve Özellikleri - Soru 1 için Seçenek B", new Guid("c77f4908-d6e6-4108-bf4e-38bc65e427a9") },
                    { new Guid("80d4c808-95fe-4299-b0e3-91957f6dbf5e"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek C", new Guid("bd71c431-0cfc-416b-a6c8-a81b6a13b489") },
                    { new Guid("8138f089-c8aa-4a0d-ac2d-da1152aed409"), false, "D", 4, "Madde ve Özellikleri - Soru 5 için Seçenek D", new Guid("e95e604c-a75a-4958-96cd-ac3414914c26") },
                    { new Guid("818578d7-40b0-45b8-8ebb-d7c1b512fe36"), false, "D", 4, "Maddenin Halleri - Soru 2 için Seçenek D", new Guid("2571ddf7-a9aa-424b-8303-3b933f4e13c1") },
                    { new Guid("821a3b2e-965e-4a2e-b68c-659f7aa2f097"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 1 için Seçenek C", new Guid("4ff50c8b-d779-41e3-963f-ec48efc7b638") },
                    { new Guid("8247c309-1453-4c36-8939-fef7344d2482"), false, "B", 2, "Kuvvet ve Hareket - Soru 2 için Seçenek B", new Guid("5fc8bc87-7087-4406-90cf-65a9569a0e50") },
                    { new Guid("83b86c7c-904d-4bb4-a511-a4f59f5017c8"), false, "D", 4, "Elektrostatik - Soru 3 için Seçenek D", new Guid("fcbd13b4-9309-4d3e-a12d-d4ee7d37b6ed") },
                    { new Guid("83e58263-3547-4f31-96f3-c6a69581da71"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 3 için Seçenek D", new Guid("90d93f04-c893-4e38-bbde-ad14a7f299e3") },
                    { new Guid("863484d2-ed7c-4c81-ad19-1b70ee39649f"), false, "B", 2, "Hücre Bölünmeleri - Soru 1 için Seçenek B", new Guid("39a76a14-1745-43da-afc9-8d9fefc07249") },
                    { new Guid("870e00ee-56f5-4bb3-a985-ff94de45657b"), true, "B", 2, "Kimya Bilimi - Soru 3 için Seçenek B", new Guid("63023acc-1d43-44e4-9292-7b8437a2614b") },
                    { new Guid("8801b104-9b2c-4f5e-b61c-bf2ae1fe0767"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek D", new Guid("733744d1-0f11-41e6-b034-f2dc0ea9922c") },
                    { new Guid("880ad0d9-055a-4c3f-b2e1-46e6a2fea100"), false, "D", 4, "Elektrostatik - Soru 1 için Seçenek D", new Guid("58fa1b40-7952-4831-99ff-aceb425554f7") },
                    { new Guid("88feb3f4-55c3-4c14-9549-94381e33a4f0"), true, "A", 1, "Kuvvet ve Hareket - Soru 1 için Seçenek A", new Guid("c4782e88-ceff-4e4e-9d11-8b08abf71767") },
                    { new Guid("89599b06-e57f-421d-ba98-63a23ade14e9"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 5 için Seçenek A", new Guid("dfeedca3-bd62-45c9-a4e7-39013c6c32d3") },
                    { new Guid("8a3490ae-71a6-4de1-9482-ed2c39db5707"), false, "A", 1, "Bölme ve Bölünebilme - Soru 2 için Seçenek A", new Guid("f5449f09-9b12-4f97-8094-d1268b96b21a") },
                    { new Guid("8bd7c8ff-6df0-4505-bf7f-f509a47b6e9d"), true, "A", 1, "Fizik Bilimine Giriş - Soru 5 için Seçenek A", new Guid("61e309ef-e263-48ba-b2db-1244a36d256d") },
                    { new Guid("8bd8b140-f171-4591-af92-ff1c304ce694"), true, "A", 1, "Problemler - Soru 3 için Seçenek A", new Guid("05cacb1f-fb81-4ef8-ade9-a874bdd639b5") },
                    { new Guid("8bfb8d46-6680-4e17-bd46-7dbe25a1aec4"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 5 için Seçenek D", new Guid("dfeedca3-bd62-45c9-a4e7-39013c6c32d3") },
                    { new Guid("8c19162f-9c3c-43e9-a3cb-d536ae710571"), false, "B", 2, "Bölme ve Bölünebilme - Soru 4 için Seçenek B", new Guid("cb79ee79-946a-49df-b127-c9bd67fc33f3") },
                    { new Guid("8c82b476-ac89-4cce-a488-89887e276564"), true, "C", 3, "Madde ve Özellikleri - Soru 4 için Seçenek C", new Guid("b58e9d1f-c68f-428f-8200-0dc5f5f9ae4e") },
                    { new Guid("8cb74ab6-f64d-477d-9b69-cfd61b5de192"), false, "A", 1, "Temel Kavramlar - Soru 4 için Seçenek A", new Guid("c7cce731-c470-4ef2-a03e-22e592a99858") },
                    { new Guid("8d3cbdae-2f62-473b-9e61-884c567ba42d"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 3 için Seçenek C", new Guid("9ef617f8-1901-48d4-a8cc-14a187049a03") },
                    { new Guid("8e58478c-0bac-41e7-a765-15931f49fdd4"), false, "B", 2, "Hücre - Soru 4 için Seçenek B", new Guid("1d479b3a-50a0-407a-bcea-425d201612c5") },
                    { new Guid("8e8a18a8-5e92-41c3-af30-56dc745c179d"), true, "C", 3, "Sayı Basamakları - Soru 4 için Seçenek C", new Guid("90c6a6dd-384b-4f0d-9255-aaa2704a519a") },
                    { new Guid("903571df-61dc-4649-ab09-612232bc0aa7"), false, "A", 1, "Kimya Bilimi - Soru 2 için Seçenek A", new Guid("8dd5ac5f-d21d-462e-b716-e55860de1b2b") },
                    { new Guid("90389182-ded2-447d-9d06-36db45e3cac1"), false, "B", 2, "Maddenin Halleri - Soru 2 için Seçenek B", new Guid("2571ddf7-a9aa-424b-8303-3b933f4e13c1") },
                    { new Guid("920b54c9-e705-4cc0-81ae-2387ff74627a"), false, "A", 1, "Bölme ve Bölünebilme - Soru 5 için Seçenek A", new Guid("7cda3d24-133b-4de8-80d2-42a53bf38cff") },
                    { new Guid("9251ac3c-2874-4fcc-95d6-aa61e0355440"), false, "A", 1, "Maddenin Halleri - Soru 1 için Seçenek A", new Guid("9bb2992e-d761-46f5-ba7f-43b16753a0da") },
                    { new Guid("92b11ee2-4c11-4023-9ff7-4cc8bba28116"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek D", new Guid("723da3a2-6253-49fc-a7f6-771e2a47f44a") },
                    { new Guid("94072f13-6368-4a6a-9acf-8e870cc6d9df"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 2 için Seçenek A", new Guid("3d70c48e-9665-426f-8622-77c8c26599f1") },
                    { new Guid("9503b373-6413-419f-b371-ad2f7792dd33"), false, "D", 4, "Madde ve Özellikleri - Soru 3 için Seçenek D", new Guid("a4184c9f-1f6e-4b54-8b29-9b94820bcd1c") },
                    { new Guid("96986c49-7f91-4262-b1e4-63146741a30f"), false, "B", 2, "Bölme ve Bölünebilme - Soru 1 için Seçenek B", new Guid("3c83a7f7-76d3-45aa-b925-e45c3e2e0d28") },
                    { new Guid("9731e729-ccc9-4d16-8f52-cfa46f59b982"), true, "D", 4, "Hücre - Soru 2 için Seçenek D", new Guid("f3083308-1307-42ed-9619-bc5e54b2a62d") },
                    { new Guid("977fc900-cd66-43a0-bb95-ae56fdc06594"), true, "A", 1, "Hücre - Soru 3 için Seçenek A", new Guid("94cff220-3586-4222-9c94-2dd3178ef575") },
                    { new Guid("97bbf03a-f236-4d63-a0a2-aa6d7617ff1c"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek A", new Guid("723da3a2-6253-49fc-a7f6-771e2a47f44a") },
                    { new Guid("9801d9d4-d1e5-4964-8520-650a47e762fe"), false, "C", 3, "Bölme ve Bölünebilme - Soru 4 için Seçenek C", new Guid("cb79ee79-946a-49df-b127-c9bd67fc33f3") },
                    { new Guid("9843f833-1a99-4cc2-983d-746f973381a6"), false, "D", 4, "Kuvvet ve Hareket - Soru 5 için Seçenek D", new Guid("1717ac60-c688-4ec7-82f4-8f0aadcb5823") },
                    { new Guid("986ed6fa-052f-4bd1-8208-8f6d080740a6"), true, "C", 3, "İş, Güç ve Enerji - Soru 5 için Seçenek C", new Guid("c16f43e0-6a32-4654-9271-61eb4e1f311a") },
                    { new Guid("98ca00a4-ecee-49c3-856c-2ec62ab7c6dd"), false, "B", 2, "Problemler - Soru 4 için Seçenek B", new Guid("41306a07-62cb-4155-9e7f-0590d389f5c6") },
                    { new Guid("99afdb0f-a135-4e8b-a0ac-1e4281909727"), true, "C", 3, "Rasyonel Sayılar - Soru 3 için Seçenek C", new Guid("7a947aec-6426-414b-bead-7b6e8e6c0cad") },
                    { new Guid("99f6a828-12da-4bfc-ab4b-c49d7b74fe23"), false, "D", 4, "Kuvvet ve Hareket - Soru 1 için Seçenek D", new Guid("c4782e88-ceff-4e4e-9d11-8b08abf71767") },
                    { new Guid("9a0d4c6b-9929-4b84-8617-cb42c36dc3a7"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 2 için Seçenek C", new Guid("3d70c48e-9665-426f-8622-77c8c26599f1") },
                    { new Guid("9bb7c1fd-7903-4580-9018-ba7567eaeb8f"), false, "A", 1, "Bölme ve Bölünebilme - Soru 3 için Seçenek A", new Guid("c2ea199f-1c40-4655-b345-1b0c38483830") },
                    { new Guid("9e53a46e-5580-46ce-8792-ffe404bbccac"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 5 için Seçenek C", new Guid("6b8d3e40-d0af-43b9-8b9b-bca113c43e63") },
                    { new Guid("9e866274-1c30-41fa-990d-0cbc1b936fe4"), false, "C", 3, "Problemler - Soru 2 için Seçenek C", new Guid("068e881b-54af-432c-b8c1-20e3f09cf083") },
                    { new Guid("9f203875-1a43-4207-8be2-ea0f221de0d8"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek D", new Guid("231a4a33-9ad0-4ac9-be0c-fab65da7620c") },
                    { new Guid("9fd02718-7241-40d1-a1db-8714afd375a7"), false, "C", 3, "Rasyonel Sayılar - Soru 2 için Seçenek C", new Guid("40d891e2-f9bc-4ad6-aa08-5701c94b215c") },
                    { new Guid("a088c275-4ccc-4e3c-b2af-3d4d4ff1232e"), false, "A", 1, "Maddenin Halleri - Soru 5 için Seçenek A", new Guid("6fe13201-d642-4e16-a6bf-77d0f15fbb11") },
                    { new Guid("a08f6968-7f5e-435e-b0fa-39f0a19a633d"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek B", new Guid("231a4a33-9ad0-4ac9-be0c-fab65da7620c") },
                    { new Guid("a0905be7-0b26-4115-bceb-7a2d43c460ed"), true, "C", 3, "Madde ve Özellikleri - Soru 1 için Seçenek C", new Guid("c77f4908-d6e6-4108-bf4e-38bc65e427a9") },
                    { new Guid("a16600ab-6189-4100-a43a-f5eb30aa61ea"), false, "B", 2, "Madde ve Özellikleri - Soru 3 için Seçenek B", new Guid("a4184c9f-1f6e-4b54-8b29-9b94820bcd1c") },
                    { new Guid("a2213d93-e5fa-4496-9b86-6689edc0d3c8"), false, "D", 4, "Elektrostatik - Soru 4 için Seçenek D", new Guid("d3854e2b-2397-4fc9-b1d2-c6b91ca1bd87") },
                    { new Guid("a23111e7-5f56-4530-83f7-240a0751b169"), false, "B", 2, "Hücre Bölünmeleri - Soru 5 için Seçenek B", new Guid("ea5c9a88-fd74-4228-b22e-6907dbbc9b1f") },
                    { new Guid("a2a09d44-cba3-4fea-8838-7138ab929af3"), false, "C", 3, "Kalıtım - Soru 2 için Seçenek C", new Guid("5c27fd8c-8b7a-4017-963e-432e28dd2482") },
                    { new Guid("a2cfb964-280d-4db3-a834-f49b789da34a"), false, "C", 3, "İş, Güç ve Enerji - Soru 2 için Seçenek C", new Guid("9dabb6ff-80e2-4017-b09b-d735e6c2d1a8") },
                    { new Guid("a2ec7d8d-5f27-4f52-99a7-37fe82ad81e0"), false, "B", 2, "İş, Güç ve Enerji - Soru 5 için Seçenek B", new Guid("c16f43e0-6a32-4654-9271-61eb4e1f311a") },
                    { new Guid("a3a78517-2422-4f83-afd0-2d67b9cea220"), false, "D", 4, "Problemler - Soru 3 için Seçenek D", new Guid("05cacb1f-fb81-4ef8-ade9-a874bdd639b5") },
                    { new Guid("a65ed504-7f4b-47cb-98a7-d797ed7300b4"), false, "B", 2, "Bölme ve Bölünebilme - Soru 5 için Seçenek B", new Guid("7cda3d24-133b-4de8-80d2-42a53bf38cff") },
                    { new Guid("a7c95b4c-0625-4aa8-a584-8f8efc8b1aa2"), false, "A", 1, "Fizik Bilimine Giriş - Soru 3 için Seçenek A", new Guid("63148dcd-7d67-49d3-8a53-55b01b43b7b7") },
                    { new Guid("a86816b1-0b0f-4725-bb40-ad6f5c1e41ea"), true, "D", 4, "Hücre Bölünmeleri - Soru 1 için Seçenek D", new Guid("39a76a14-1745-43da-afc9-8d9fefc07249") },
                    { new Guid("a9c55c71-4583-40bd-ab3b-4a62c208bdc8"), false, "A", 1, "Maddenin Halleri - Soru 2 için Seçenek A", new Guid("2571ddf7-a9aa-424b-8303-3b933f4e13c1") },
                    { new Guid("aa46c619-2fab-43bb-87b0-a7a593a7c9d7"), false, "A", 1, "Kalıtım - Soru 4 için Seçenek A", new Guid("4f37ac55-ee01-43fe-9ff4-ef65b30272c9") },
                    { new Guid("aa6c90ab-07f0-4ca9-ac13-0ddcdea6485f"), false, "D", 4, "Rasyonel Sayılar - Soru 3 için Seçenek D", new Guid("7a947aec-6426-414b-bead-7b6e8e6c0cad") },
                    { new Guid("aa7ef63e-fc9d-462e-9553-eeb3d03a56f0"), false, "A", 1, "Kimya Bilimi - Soru 3 için Seçenek A", new Guid("63023acc-1d43-44e4-9292-7b8437a2614b") },
                    { new Guid("aaa37b78-0357-415c-9777-9e6183613f2a"), false, "B", 2, "Elektrostatik - Soru 4 için Seçenek B", new Guid("d3854e2b-2397-4fc9-b1d2-c6b91ca1bd87") },
                    { new Guid("ab3b817f-26db-4cb2-b620-efd319f908cd"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 1 için Seçenek B", new Guid("4ff50c8b-d779-41e3-963f-ec48efc7b638") },
                    { new Guid("ac089986-f739-4933-97c4-dfbd7f2d4250"), false, "C", 3, "Kimya Bilimi - Soru 2 için Seçenek C", new Guid("8dd5ac5f-d21d-462e-b716-e55860de1b2b") },
                    { new Guid("ad82f2bf-a0a1-44bb-82bd-f8b4ba633012"), false, "D", 4, "Sayı Basamakları - Soru 5 için Seçenek D", new Guid("6ac51ce1-d7ce-4f69-b0b6-7425a7c3b824") },
                    { new Guid("ad9b7a74-f409-4b65-b7fb-89ac017449db"), true, "A", 1, "Kimya Bilimi - Soru 1 için Seçenek A", new Guid("ce47c25d-323c-45f7-96fd-1f4acf3737e9") },
                    { new Guid("adcb6714-3a48-4ca7-a51f-4cc16960b6fc"), false, "B", 2, "Kuvvet ve Hareket - Soru 4 için Seçenek B", new Guid("a26e377a-7357-47f7-a6ae-0fb1e3d662b2") },
                    { new Guid("af09ac4b-443a-4598-92b8-cf6c99d7c638"), false, "D", 4, "Madde ve Özellikleri - Soru 2 için Seçenek D", new Guid("9da39309-e1ef-4bd2-b159-de905237573e") },
                    { new Guid("afb2d002-6f69-4162-9dac-82e24ef329f6"), false, "C", 3, "Madde ve Özellikleri - Soru 2 için Seçenek C", new Guid("9da39309-e1ef-4bd2-b159-de905237573e") },
                    { new Guid("afbeee7f-cf54-4f21-8928-3290ba9c0fef"), true, "C", 3, "Maddenin Halleri - Soru 2 için Seçenek C", new Guid("2571ddf7-a9aa-424b-8303-3b933f4e13c1") },
                    { new Guid("aff501d3-2694-4bdd-815a-cbb09f0ba44c"), false, "A", 1, "Madde ve Özellikleri - Soru 4 için Seçenek A", new Guid("b58e9d1f-c68f-428f-8200-0dc5f5f9ae4e") },
                    { new Guid("affa12c6-3bdd-4d39-8032-b498982a5f67"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek C", new Guid("21605f70-e3cc-4f72-af51-001813b26885") },
                    { new Guid("b0e15261-f696-4a78-98a1-8e205db2fe31"), true, "C", 3, "Sayı Basamakları - Soru 3 için Seçenek C", new Guid("d2f672b2-2871-4c2f-8e63-ef9548a6b09a") },
                    { new Guid("b2be84dd-819d-4b1f-8b0e-8f902bc821d5"), true, "A", 1, "Rasyonel Sayılar - Soru 5 için Seçenek A", new Guid("1ebfb32c-2edb-4a49-88d5-50ef274f2cb3") },
                    { new Guid("b3991b5d-0eba-4321-912b-b02be582755f"), false, "D", 4, "Elektrostatik - Soru 2 için Seçenek D", new Guid("f2e506c4-534a-4458-9283-be550f780a29") },
                    { new Guid("b3e3f370-6280-4836-83c3-9f6cc8b49412"), true, "C", 3, "Elektrostatik - Soru 1 için Seçenek C", new Guid("58fa1b40-7952-4831-99ff-aceb425554f7") },
                    { new Guid("b4073300-54fd-44fb-89e1-6c15aa486221"), true, "B", 2, "Kalıtım - Soru 4 için Seçenek B", new Guid("4f37ac55-ee01-43fe-9ff4-ef65b30272c9") },
                    { new Guid("b4c278d0-2b5c-4c70-ac41-75a544b8bf2a"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek B", new Guid("9ead5ebb-6b09-41fd-a709-b610695070cb") },
                    { new Guid("b50c203e-24b5-41f8-ad1e-17dde264211a"), false, "C", 3, "Elektrostatik - Soru 5 için Seçenek C", new Guid("135d40e2-967f-4896-92e8-af10868fdfb2") },
                    { new Guid("b58a700b-dec5-430f-803d-6bc92846f218"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 4 için Seçenek B", new Guid("9ec27680-1943-4820-ae0b-a1e14e3c72b3") },
                    { new Guid("b5ae62df-712c-4949-85a3-fc9f98ca707c"), true, "C", 3, "Temel Kavramlar - Soru 1 için Seçenek C", new Guid("abdbd19f-1353-4c60-9eee-81ccabfe3099") },
                    { new Guid("b6449e7b-b8d7-4e40-befa-e4f688269ce3"), false, "A", 1, "Rasyonel Sayılar - Soru 4 için Seçenek A", new Guid("6a7f4540-8d85-4728-b838-951cebf15cc9") },
                    { new Guid("b7554814-242c-4d59-9c28-1db1daa651d6"), false, "B", 2, "Problemler - Soru 5 için Seçenek B", new Guid("1140c297-2770-48b1-b266-1e0dbed7e62d") },
                    { new Guid("b9d0cd18-1a4b-4c02-868f-7d7497d14a41"), false, "B", 2, "Hücre Bölünmeleri - Soru 2 için Seçenek B", new Guid("b78290f6-f7f8-4b63-9664-98d7d55b0cb0") },
                    { new Guid("ba7ce29f-0c87-4521-8b04-3f11c06b8718"), false, "C", 3, "Problemler - Soru 3 için Seçenek C", new Guid("05cacb1f-fb81-4ef8-ade9-a874bdd639b5") },
                    { new Guid("baadba6f-0fed-466b-8349-f654591823ce"), false, "C", 3, "Kuvvet ve Hareket - Soru 4 için Seçenek C", new Guid("a26e377a-7357-47f7-a6ae-0fb1e3d662b2") },
                    { new Guid("bc4622d2-8399-4e19-8e1d-70f7bdda0a0a"), false, "D", 4, "Kimya Bilimi - Soru 3 için Seçenek D", new Guid("63023acc-1d43-44e4-9292-7b8437a2614b") },
                    { new Guid("bd0a26e0-339e-439d-b8e3-87d0b4d30501"), true, "B", 2, "Temel Kavramlar - Soru 2 için Seçenek B", new Guid("e1b872c7-7368-4af8-b0a0-e8abf2bb3fa5") },
                    { new Guid("bd5e5540-71e6-42c2-a615-35c5f2b2d420"), false, "B", 2, "Kalıtım - Soru 2 için Seçenek B", new Guid("5c27fd8c-8b7a-4017-963e-432e28dd2482") },
                    { new Guid("bdccd7c0-ee9a-4da5-aee1-766aa14b10b4"), false, "A", 1, "Temel Kavramlar - Soru 2 için Seçenek A", new Guid("e1b872c7-7368-4af8-b0a0-e8abf2bb3fa5") },
                    { new Guid("be045cdb-bd6c-4363-8d73-39638e0f8fff"), true, "B", 2, "Problemler - Soru 1 için Seçenek B", new Guid("e7646b17-006a-40d5-9b92-93241b8eea17") },
                    { new Guid("be2abf66-9c82-4326-a16d-96297467f901"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek C", new Guid("7b5f377b-a9c3-423c-94cb-05dadd6205b9") },
                    { new Guid("be396f73-d245-480c-96ee-eb4e3bb76600"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 4 için Seçenek C", new Guid("b56170da-0aab-45ed-b542-966021b74cda") },
                    { new Guid("bff3869d-c8e1-4eb5-8cbf-32090fb016f9"), false, "A", 1, "İş, Güç ve Enerji - Soru 4 için Seçenek A", new Guid("3fc6e5a4-e9a4-4344-ab1f-21d58c0a4ebd") },
                    { new Guid("c014ffc0-c57f-447a-be79-f1f3b7301f99"), false, "C", 3, "Kimya Bilimi - Soru 3 için Seçenek C", new Guid("63023acc-1d43-44e4-9292-7b8437a2614b") },
                    { new Guid("c08ed328-5b05-430d-8e56-a2074b50ce01"), false, "C", 3, "Elektrostatik - Soru 2 için Seçenek C", new Guid("f2e506c4-534a-4458-9283-be550f780a29") },
                    { new Guid("c13f17b0-ae8f-438b-8e22-3cef311d37cd"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek D", new Guid("1c2fc5cb-9438-4f04-a529-a86be3dff1de") },
                    { new Guid("c1c37ea2-8a26-476d-9dea-c42924c91b50"), true, "B", 2, "Kalıtım - Soru 1 için Seçenek B", new Guid("d4758d8d-8eee-4264-825a-e82b7807ec45") },
                    { new Guid("c24069bb-d513-4b2d-9eaa-5c9a0e402827"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek D", new Guid("a02d6e3b-64b6-4610-b617-c527643f0a17") },
                    { new Guid("c25e8ba7-2da0-4c71-80ff-dc4e58dfff8b"), false, "D", 4, "Elektrostatik - Soru 5 için Seçenek D", new Guid("135d40e2-967f-4896-92e8-af10868fdfb2") },
                    { new Guid("c27f13c0-f7b0-4814-b166-7d8ce6b210cb"), true, "C", 3, "Kimya Bilimi - Soru 4 için Seçenek C", new Guid("42dc8912-bf6e-4a31-9a56-cd122bc90126") },
                    { new Guid("c358e5a6-51a2-47d6-aec5-528b49c52d40"), true, "A", 1, "Fizik Bilimine Giriş - Soru 2 için Seçenek A", new Guid("256f276b-3bfb-4bdb-b26b-971217a3539b") },
                    { new Guid("c366cb75-a7a3-44e2-9243-fa348abbe826"), false, "A", 1, "Fizik Bilimine Giriş - Soru 4 için Seçenek A", new Guid("12a954a7-c2aa-4bf6-b452-67585cef0308") },
                    { new Guid("c65e83cd-7443-4634-a847-68a4d8ea5d31"), false, "B", 2, "Sayı Basamakları - Soru 3 için Seçenek B", new Guid("d2f672b2-2871-4c2f-8e63-ef9548a6b09a") },
                    { new Guid("c66fad80-ef99-4234-95e5-cc564a6e6356"), false, "D", 4, "Bölme ve Bölünebilme - Soru 4 için Seçenek D", new Guid("cb79ee79-946a-49df-b127-c9bd67fc33f3") },
                    { new Guid("c7696a77-fa2b-48cd-9de6-2fa300fba6ad"), false, "A", 1, "Kuvvet ve Hareket - Soru 3 için Seçenek A", new Guid("3e342df6-2378-4db0-b563-9679f1e27479") },
                    { new Guid("c7bd269c-18dc-4e71-ac50-74c944b83820"), false, "B", 2, "Hücre - Soru 1 için Seçenek B", new Guid("c9fa7708-e4e4-4df0-8e37-d6e6c92dd4d6") },
                    { new Guid("c87f1893-9cf3-437a-ab25-3492edb60736"), false, "C", 3, "Kalıtım - Soru 4 için Seçenek C", new Guid("4f37ac55-ee01-43fe-9ff4-ef65b30272c9") },
                    { new Guid("c98ad25f-2ba1-4332-a0d9-d19fd9e9b3b3"), false, "C", 3, "Fizik Bilimine Giriş - Soru 4 için Seçenek C", new Guid("12a954a7-c2aa-4bf6-b452-67585cef0308") },
                    { new Guid("c9d4d8ca-51bf-4acc-ba55-3795632692fb"), false, "C", 3, "Rasyonel Sayılar - Soru 1 için Seçenek C", new Guid("b01219d4-b8c8-45a6-b1c5-bf6404d877c5") },
                    { new Guid("ca930065-b25a-4d88-89cb-a4781451932e"), false, "D", 4, "İş, Güç ve Enerji - Soru 4 için Seçenek D", new Guid("3fc6e5a4-e9a4-4344-ab1f-21d58c0a4ebd") },
                    { new Guid("cb491bdb-7f95-41e0-aa6f-a9e602ee5532"), false, "D", 4, "Temel Kavramlar - Soru 2 için Seçenek D", new Guid("e1b872c7-7368-4af8-b0a0-e8abf2bb3fa5") },
                    { new Guid("cbee4c99-209b-4a74-8141-6328125062eb"), true, "B", 2, "Fizik Bilimine Giriş - Soru 3 için Seçenek B", new Guid("63148dcd-7d67-49d3-8a53-55b01b43b7b7") },
                    { new Guid("cc352812-da4b-4aa9-9836-1d841491a206"), true, "C", 3, "Bölme ve Bölünebilme - Soru 2 için Seçenek C", new Guid("f5449f09-9b12-4f97-8094-d1268b96b21a") },
                    { new Guid("cd3ccc49-06d3-4c57-bbce-ac4febc7d3be"), false, "B", 2, "İş, Güç ve Enerji - Soru 2 için Seçenek B", new Guid("9dabb6ff-80e2-4017-b09b-d735e6c2d1a8") },
                    { new Guid("ce34232d-a762-4543-a5fa-e3d74e14dd62"), true, "C", 3, "Kimya Bilimi - Soru 5 için Seçenek C", new Guid("db5f67e6-29f0-4c0e-aae0-b976dd71f21d") },
                    { new Guid("cf192bd6-66ef-48b3-b8d5-117357a7d283"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek C", new Guid("c67f7246-8cc1-47e6-8ad6-d6fda56b096e") },
                    { new Guid("d0000030-6497-4743-be45-3e12ea768e36"), false, "B", 2, "Elektrostatik - Soru 5 için Seçenek B", new Guid("135d40e2-967f-4896-92e8-af10868fdfb2") },
                    { new Guid("d0de6121-03ac-45ec-b0db-28064e5bb30f"), true, "A", 1, "Elektrostatik - Soru 2 için Seçenek A", new Guid("f2e506c4-534a-4458-9283-be550f780a29") },
                    { new Guid("d0e48f21-91f8-4ad5-ab31-22cbae0a8758"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek B", new Guid("1c2fc5cb-9438-4f04-a529-a86be3dff1de") },
                    { new Guid("d109c36d-8043-45d6-b928-491e31b247d4"), false, "A", 1, "Problemler - Soru 4 için Seçenek A", new Guid("41306a07-62cb-4155-9e7f-0590d389f5c6") },
                    { new Guid("d13de066-7d5a-4563-a19f-82f2444a2d20"), true, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek B", new Guid("21605f70-e3cc-4f72-af51-001813b26885") },
                    { new Guid("d16d1020-3032-4955-a820-765bc39b92e9"), false, "C", 3, "Hücre Bölünmeleri - Soru 1 için Seçenek C", new Guid("39a76a14-1745-43da-afc9-8d9fefc07249") },
                    { new Guid("d46efe9a-6ec2-4628-ad14-1fa716eeb632"), true, "A", 1, "İş, Güç ve Enerji - Soru 1 için Seçenek A", new Guid("ded940c8-673b-4281-b6a1-688f2ea95296") },
                    { new Guid("d54efbf4-b70a-470c-af1c-cf536f570079"), false, "D", 4, "Fizik Bilimine Giriş - Soru 3 için Seçenek D", new Guid("63148dcd-7d67-49d3-8a53-55b01b43b7b7") },
                    { new Guid("d5c08043-5de9-4bc3-a962-45cc368e81aa"), true, "C", 3, "Kuvvet ve Hareket - Soru 3 için Seçenek C", new Guid("3e342df6-2378-4db0-b563-9679f1e27479") },
                    { new Guid("d5dd06a8-3d57-41a6-a024-1a974e4be9a0"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 1 için Seçenek A", new Guid("6eecc7d6-e704-47a1-8889-78c3b0f17f07") },
                    { new Guid("d5de368f-2cad-4918-9e9a-51428e5f0965"), false, "A", 1, "Hücre - Soru 1 için Seçenek A", new Guid("c9fa7708-e4e4-4df0-8e37-d6e6c92dd4d6") },
                    { new Guid("d62b0e07-044e-460d-80cf-128c3d92553a"), false, "D", 4, "Bölme ve Bölünebilme - Soru 1 için Seçenek D", new Guid("3c83a7f7-76d3-45aa-b925-e45c3e2e0d28") },
                    { new Guid("d6512faa-8d67-47ef-942d-8676b410458b"), false, "D", 4, "Kuvvet ve Hareket - Soru 4 için Seçenek D", new Guid("a26e377a-7357-47f7-a6ae-0fb1e3d662b2") },
                    { new Guid("d80a07bc-fbb2-4017-b6eb-b79470b92d28"), false, "D", 4, "Kimya Bilimi - Soru 2 için Seçenek D", new Guid("8dd5ac5f-d21d-462e-b716-e55860de1b2b") },
                    { new Guid("d897b3c9-928c-4e06-871e-aafdea657d85"), false, "C", 3, "Rasyonel Sayılar - Soru 4 için Seçenek C", new Guid("6a7f4540-8d85-4728-b838-951cebf15cc9") },
                    { new Guid("d92803aa-0a92-40c7-b8d9-8fb8fce56def"), false, "D", 4, "Sayı Basamakları - Soru 1 için Seçenek D", new Guid("94be52e0-61f0-4381-9f7f-9b89f670e0ed") },
                    { new Guid("d9639f98-906c-46a7-bbf4-3432b54d9947"), false, "C", 3, "Kuvvet ve Hareket - Soru 2 için Seçenek C", new Guid("5fc8bc87-7087-4406-90cf-65a9569a0e50") },
                    { new Guid("db18d3bf-dd16-4aab-a2bf-492d7fd746a4"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek D", new Guid("21ccfaef-bbaf-4c42-84ba-f2ea3176c851") },
                    { new Guid("db6e76c0-caf3-453a-9966-289e820aa761"), false, "B", 2, "Kuvvet ve Hareket - Soru 1 için Seçenek B", new Guid("c4782e88-ceff-4e4e-9d11-8b08abf71767") },
                    { new Guid("dc66b9df-20f9-41ca-ab33-bd355141d210"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek B", new Guid("df250e8b-79ad-4bd0-8d82-284d7b08464c") },
                    { new Guid("dc92500d-6df2-40f2-82e8-fd1173a3752e"), false, "C", 3, "Maddenin Halleri - Soru 1 için Seçenek C", new Guid("9bb2992e-d761-46f5-ba7f-43b16753a0da") },
                    { new Guid("ddaaedca-5ce6-423c-831b-febfb6d52500"), false, "B", 2, "Maddenin Halleri - Soru 3 için Seçenek B", new Guid("269a3a0d-b3fe-43e4-a399-4b5f54111559") },
                    { new Guid("de4557c7-d304-43ce-a642-691694ff02b8"), true, "B", 2, "Kuvvet ve Hareket - Soru 5 için Seçenek B", new Guid("1717ac60-c688-4ec7-82f4-8f0aadcb5823") },
                    { new Guid("debbcbad-9e1c-4831-8908-5229e2f09376"), false, "C", 3, "Kimya Bilimi - Soru 1 için Seçenek C", new Guid("ce47c25d-323c-45f7-96fd-1f4acf3737e9") },
                    { new Guid("df98a7b6-dc1a-42ba-8577-173a2db178e8"), false, "C", 3, "Hücre Bölünmeleri - Soru 2 için Seçenek C", new Guid("b78290f6-f7f8-4b63-9664-98d7d55b0cb0") },
                    { new Guid("e050735d-f5fa-466a-8d59-a2915a6213ec"), false, "B", 2, "Rasyonel Sayılar - Soru 5 için Seçenek B", new Guid("1ebfb32c-2edb-4a49-88d5-50ef274f2cb3") },
                    { new Guid("e0ea3b2a-e694-4a6c-80d2-a922b14fd5a4"), true, "D", 4, "Hücre - Soru 4 için Seçenek D", new Guid("1d479b3a-50a0-407a-bcea-425d201612c5") },
                    { new Guid("e1afe68b-5af9-4f29-b15c-1d5781970dc5"), false, "B", 2, "Temel Kavramlar - Soru 4 için Seçenek B", new Guid("c7cce731-c470-4ef2-a03e-22e592a99858") },
                    { new Guid("e27112f8-eec5-4372-abfd-977f465a94b7"), false, "A", 1, "Kuvvet ve Hareket - Soru 5 için Seçenek A", new Guid("1717ac60-c688-4ec7-82f4-8f0aadcb5823") },
                    { new Guid("e310b400-2611-462d-a024-fbb5af7b75bd"), false, "B", 2, "Temel Kavramlar - Soru 1 için Seçenek B", new Guid("abdbd19f-1353-4c60-9eee-81ccabfe3099") },
                    { new Guid("e34eeb53-020e-44f0-9c79-fbfff3cdf164"), false, "A", 1, "Rasyonel Sayılar - Soru 2 için Seçenek A", new Guid("40d891e2-f9bc-4ad6-aa08-5701c94b215c") },
                    { new Guid("e357d7eb-c3ef-45fe-97fe-a096936ce8ca"), false, "B", 2, "Rasyonel Sayılar - Soru 3 için Seçenek B", new Guid("7a947aec-6426-414b-bead-7b6e8e6c0cad") },
                    { new Guid("e3932c15-2c67-45dd-b079-6e6019545f73"), true, "D", 4, "Problemler - Soru 4 için Seçenek D", new Guid("41306a07-62cb-4155-9e7f-0590d389f5c6") },
                    { new Guid("e3c86cef-01bb-4c07-93a7-c1b31f6547e5"), false, "D", 4, "Fizik Bilimine Giriş - Soru 4 için Seçenek D", new Guid("12a954a7-c2aa-4bf6-b452-67585cef0308") },
                    { new Guid("e3f66ab5-4814-4a58-a7be-dffeec0f3d68"), false, "D", 4, "Fizik Bilimine Giriş - Soru 2 için Seçenek D", new Guid("256f276b-3bfb-4bdb-b26b-971217a3539b") },
                    { new Guid("e40d9f55-d823-44ab-9520-fc9657dbc2d3"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek D", new Guid("684b3740-3af7-473b-8113-57de37cc9ca5") },
                    { new Guid("e465d40b-7188-47f3-939e-2593f52bcbb6"), false, "D", 4, "Hücre - Soru 1 için Seçenek D", new Guid("c9fa7708-e4e4-4df0-8e37-d6e6c92dd4d6") },
                    { new Guid("e4b15361-bba7-4793-8ba6-5213a2219e94"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek C", new Guid("1c2fc5cb-9438-4f04-a529-a86be3dff1de") },
                    { new Guid("e639de9a-7d5a-4a09-be97-dc044867a209"), false, "B", 2, "Fizik Bilimine Giriş - Soru 5 için Seçenek B", new Guid("61e309ef-e263-48ba-b2db-1244a36d256d") },
                    { new Guid("e6481d69-a934-4a19-92f6-ef5e2b811ac8"), true, "C", 3, "Madde ve Özellikleri - Soru 3 için Seçenek C", new Guid("a4184c9f-1f6e-4b54-8b29-9b94820bcd1c") },
                    { new Guid("e78583e7-b04f-4f81-91eb-8ba667e1e8c1"), false, "A", 1, "Madde ve Özellikleri - Soru 2 için Seçenek A", new Guid("9da39309-e1ef-4bd2-b159-de905237573e") },
                    { new Guid("e7c58068-3497-4f69-9267-30358c04c53c"), false, "A", 1, "Hücre - Soru 2 için Seçenek A", new Guid("f3083308-1307-42ed-9619-bc5e54b2a62d") },
                    { new Guid("ea80b064-4f66-4936-bc9b-67590201b7cd"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek C", new Guid("657e2277-51a3-4de7-8174-9e26ce9cdfd4") },
                    { new Guid("eac90224-0a10-47ec-909e-92d7b423d0b2"), true, "C", 3, "Maddenin Halleri - Soru 3 için Seçenek C", new Guid("269a3a0d-b3fe-43e4-a399-4b5f54111559") },
                    { new Guid("eb7b1e6f-4eb5-4bb9-810f-7d89f0c1779a"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek A", new Guid("657e2277-51a3-4de7-8174-9e26ce9cdfd4") },
                    { new Guid("ebc20cdd-4ace-4473-bd7a-eae0cd1af75f"), false, "A", 1, "Sayı Basamakları - Soru 4 için Seçenek A", new Guid("90c6a6dd-384b-4f0d-9255-aaa2704a519a") },
                    { new Guid("ec30375f-8b15-4bdd-a74b-1c7fe25e2a91"), false, "C", 3, "Temel Kavramlar - Soru 5 için Seçenek C", new Guid("55afd203-0321-4a0a-9096-5f40ff8be409") },
                    { new Guid("ec835af5-11cf-4424-b644-267e06a47b90"), false, "B", 2, "Bölme ve Bölünebilme - Soru 3 için Seçenek B", new Guid("c2ea199f-1c40-4655-b345-1b0c38483830") },
                    { new Guid("eced7ba8-34f9-4f1a-8d61-daf01fc5a28f"), true, "C", 3, "Bölme ve Bölünebilme - Soru 3 için Seçenek C", new Guid("c2ea199f-1c40-4655-b345-1b0c38483830") },
                    { new Guid("ecf567bc-1070-41d8-a6c7-526484c44ac1"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 2 için Seçenek C", new Guid("e5e91d0d-16f7-4748-9f8b-37981fbe715d") },
                    { new Guid("ed2174f1-ec78-4753-aa63-1a3c14b34c7c"), false, "A", 1, "Sayı Basamakları - Soru 1 için Seçenek A", new Guid("94be52e0-61f0-4381-9f7f-9b89f670e0ed") },
                    { new Guid("ede68dc2-e568-4dc5-9694-c727a08c58cb"), true, "B", 2, "Canlıların Sınıflandırılması - Soru 2 için Seçenek B", new Guid("e5e91d0d-16f7-4748-9f8b-37981fbe715d") },
                    { new Guid("ee7dda1a-fad7-4586-89d4-d60f96a17652"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek A", new Guid("733744d1-0f11-41e6-b034-f2dc0ea9922c") },
                    { new Guid("eedbe156-137e-4ef5-8df7-13cab0d6f47c"), true, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek B", new Guid("723da3a2-6253-49fc-a7f6-771e2a47f44a") },
                    { new Guid("ef76982d-e496-43d2-a605-ec6b487a098e"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek B", new Guid("a02d6e3b-64b6-4610-b617-c527643f0a17") },
                    { new Guid("f0326c0d-5a84-44ac-b0d6-b52df85ff18e"), true, "A", 1, "Kalıtım - Soru 5 için Seçenek A", new Guid("c99a65f5-cdcb-4d8c-af93-211cc0e6fbc8") },
                    { new Guid("f072a804-e372-467e-92bd-a99e7ef2fc08"), false, "C", 3, "İş, Güç ve Enerji - Soru 1 için Seçenek C", new Guid("ded940c8-673b-4281-b6a1-688f2ea95296") },
                    { new Guid("f0bc3af1-f660-431d-b52f-51db924629bf"), true, "D", 4, "Rasyonel Sayılar - Soru 1 için Seçenek D", new Guid("b01219d4-b8c8-45a6-b1c5-bf6404d877c5") },
                    { new Guid("f0db0490-d96b-48e4-a467-b0955f47929c"), false, "B", 2, "Temel Kavramlar - Soru 5 için Seçenek B", new Guid("55afd203-0321-4a0a-9096-5f40ff8be409") },
                    { new Guid("f1e1fa07-565e-41f1-810a-dd0f7929b04d"), false, "B", 2, "Maddenin Halleri - Soru 4 için Seçenek B", new Guid("ff3654f8-2965-4b28-9392-ab121290cc58") },
                    { new Guid("f2df1264-367b-41a0-bf24-224bc294d3b2"), false, "C", 3, "Fizik Bilimine Giriş - Soru 3 için Seçenek C", new Guid("63148dcd-7d67-49d3-8a53-55b01b43b7b7") },
                    { new Guid("f31effa7-d2fc-41dd-b18c-c5afa7d4c03b"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 1 için Seçenek D", new Guid("4ff50c8b-d779-41e3-963f-ec48efc7b638") },
                    { new Guid("f37e4563-ea78-4d9c-8b4d-d5ed27d2383d"), false, "A", 1, "Elektrostatik - Soru 1 için Seçenek A", new Guid("58fa1b40-7952-4831-99ff-aceb425554f7") },
                    { new Guid("f3af0f91-bb94-4d1a-b4fb-cc5651c264c5"), false, "B", 2, "Sayı Basamakları - Soru 1 için Seçenek B", new Guid("94be52e0-61f0-4381-9f7f-9b89f670e0ed") },
                    { new Guid("f3d7af0a-f909-4472-aae1-e2929b444f5b"), true, "A", 1, "Bölme ve Bölünebilme - Soru 4 için Seçenek A", new Guid("cb79ee79-946a-49df-b127-c9bd67fc33f3") },
                    { new Guid("f4a51405-c09d-4800-97e2-7b97d26b2543"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 2 için Seçenek A", new Guid("e5e91d0d-16f7-4748-9f8b-37981fbe715d") },
                    { new Guid("f4d1c53b-dd6f-49a1-ac2a-bf65019289b7"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek D", new Guid("c67f7246-8cc1-47e6-8ad6-d6fda56b096e") },
                    { new Guid("f50f2169-422d-4bf1-a729-28dc86662114"), false, "D", 4, "Sayı Basamakları - Soru 2 için Seçenek D", new Guid("b749b575-022f-4e30-b061-e09290ec6a35") },
                    { new Guid("f51ee257-b5a3-4a17-ace0-7144afa88913"), false, "C", 3, "Fizik Bilimine Giriş - Soru 2 için Seçenek C", new Guid("256f276b-3bfb-4bdb-b26b-971217a3539b") },
                    { new Guid("f67437d3-a5e4-46b0-b3e8-30d552471e67"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek D", new Guid("7b5f377b-a9c3-423c-94cb-05dadd6205b9") },
                    { new Guid("f7016231-ca34-4578-bc9a-75b472274d63"), false, "D", 4, "Maddenin Halleri - Soru 5 için Seçenek D", new Guid("6fe13201-d642-4e16-a6bf-77d0f15fbb11") },
                    { new Guid("f7645f99-5244-4f3e-946c-d6cf9b794c43"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek D", new Guid("8bc26171-537a-433d-b315-7c47470b7064") },
                    { new Guid("f7e5644d-7813-4e8d-a2c1-64a9e255c002"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek C", new Guid("733744d1-0f11-41e6-b034-f2dc0ea9922c") },
                    { new Guid("f91266dc-f2e5-4911-8247-0258c0b6a299"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 3 için Seçenek A", new Guid("9ef617f8-1901-48d4-a8cc-14a187049a03") },
                    { new Guid("f9347a9e-01db-42d5-971b-84e925236946"), false, "A", 1, "Hücre - Soru 5 için Seçenek A", new Guid("54c92303-5f97-485e-9bd0-adeb075b6028") },
                    { new Guid("f9b2cea6-c937-4085-9701-14f81ccde24d"), true, "A", 1, "Kuvvet ve Hareket - Soru 4 için Seçenek A", new Guid("a26e377a-7357-47f7-a6ae-0fb1e3d662b2") },
                    { new Guid("fa4b3569-2bbb-4349-97ca-c42797fa16cf"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek A", new Guid("bd71c431-0cfc-416b-a6c8-a81b6a13b489") },
                    { new Guid("fa910fb5-bfe9-4be3-b1ca-2596258e6217"), false, "B", 2, "Sayı Basamakları - Soru 4 için Seçenek B", new Guid("90c6a6dd-384b-4f0d-9255-aaa2704a519a") },
                    { new Guid("faf4db0f-0064-4950-9d18-4a01f17ce45d"), false, "A", 1, "Kimya Bilimi - Soru 5 için Seçenek A", new Guid("db5f67e6-29f0-4c0e-aae0-b976dd71f21d") },
                    { new Guid("fb377c0f-8bae-4150-99de-ec9c35d99d54"), false, "D", 4, "Hücre Bölünmeleri - Soru 3 için Seçenek D", new Guid("966e483e-8aac-430c-8f1e-9215c8892420") },
                    { new Guid("fce3510e-010e-448d-8ee0-98516675669c"), true, "B", 2, "Hücre Bölünmeleri - Soru 3 için Seçenek B", new Guid("966e483e-8aac-430c-8f1e-9215c8892420") },
                    { new Guid("fd26ad3d-464a-43b9-b193-63e0691432a8"), false, "B", 2, "Hücre Bölünmeleri - Soru 4 için Seçenek B", new Guid("b73820c6-3fbf-4e73-8a43-e976bca64293") },
                    { new Guid("fdf5d525-3c06-4b9b-ad41-c4801593e863"), false, "C", 3, "Sayı Basamakları - Soru 2 için Seçenek C", new Guid("b749b575-022f-4e30-b061-e09290ec6a35") },
                    { new Guid("fe0b528a-aa40-427f-b505-cddcd82022b4"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 5 için Seçenek C", new Guid("dfeedca3-bd62-45c9-a4e7-39013c6c32d3") },
                    { new Guid("fea19672-4580-40f7-b827-8c62e4367dea"), true, "A", 1, "Sayı Basamakları - Soru 2 için Seçenek A", new Guid("b749b575-022f-4e30-b061-e09290ec6a35") },
                    { new Guid("fea3b2b9-ccd8-4ba7-86a0-af5b0693e699"), false, "C", 3, "Hücre Bölünmeleri - Soru 5 için Seçenek C", new Guid("ea5c9a88-fd74-4228-b22e-6907dbbc9b1f") },
                    { new Guid("fec6e8c5-e6cf-4ca6-9f80-987b7ba5a5e3"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek A", new Guid("7b5f377b-a9c3-423c-94cb-05dadd6205b9") },
                    { new Guid("fedd431e-8d08-45dc-98d2-1a485473164f"), true, "A", 1, "Problemler - Soru 5 için Seçenek A", new Guid("1140c297-2770-48b1-b266-1e0dbed7e62d") },
                    { new Guid("ff2ba74e-e018-42b6-8628-525b7f096202"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek C", new Guid("723da3a2-6253-49fc-a7f6-771e2a47f44a") },
                    { new Guid("ff789a79-607b-413e-8c14-0d19b4fd8433"), false, "D", 4, "İş, Güç ve Enerji - Soru 1 için Seçenek D", new Guid("ded940c8-673b-4281-b6a1-688f2ea95296") }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ParentTopicId", "SubjectId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("09094021-1cfe-4608-8880-f968e7447457"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3062), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Maddenin Halleri" },
                    { new Guid("1095ef60-ce09-402c-ac15-d459ca4725ce"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3069), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre" },
                    { new Guid("1313c405-f8a2-4aef-b5bd-b4f4ebd8731f"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3060), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimyasal Türler Arası Etkileşimler" },
                    { new Guid("53304228-3e1b-4e4d-8148-e5ad9de55d7b"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3074), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre Bölünmeleri" },
                    { new Guid("5a0553d7-badd-4cd0-9040-1cf66e125db5"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3046), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Madde ve Özellikleri" },
                    { new Guid("5ea8fbd1-0677-4847-9567-5d78c7c66b41"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3050), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "İş, Güç ve Enerji" },
                    { new Guid("5f5a875d-3a39-4f15-80b3-6cd223f88e74"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3067), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Yaşam Bilimi Biyoloji" },
                    { new Guid("641afa0d-f192-4cd0-8875-9fb4afd8ec6a"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3037), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Rasyonel Sayılar" },
                    { new Guid("724755e2-fb14-4302-9327-0471717030a8"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3053), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Elektrostatik" },
                    { new Guid("7dbc14b1-f84d-4f51-a0f2-880ae3942d77"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3057), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimya Bilimi" },
                    { new Guid("7f6b4109-c898-4169-9f38-360d50c96c98"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3022), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Temel Kavramlar" },
                    { new Guid("865e3d41-056d-4955-848d-891095755cad"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3048), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Kuvvet ve Hareket" },
                    { new Guid("921ec33e-59bc-40ad-b38b-88458fa1b10d"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3035), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Bölme ve Bölünebilme" },
                    { new Guid("94913c7f-b818-4d10-a764-6148eb4cf683"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3032), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Sayı Basamakları" },
                    { new Guid("bc98ee65-c5c2-4ae7-9df1-b455bda888ce"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3064), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Asitler, Bazlar ve Tuzlar" },
                    { new Guid("d0f2ad0a-3010-49f8-b12e-84283229d212"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3039), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Problemler" },
                    { new Guid("dbc61688-251e-4fcb-aae9-f74ceca06242"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3058), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Atom ve Periyodik Sistem" },
                    { new Guid("e376d503-07a2-4f83-a2d7-3841e827048b"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3099), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Kalıtım" },
                    { new Guid("f2281e0c-d56e-4be5-9285-dc918b56345e"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3072), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Canlıların Sınıflandırılması" },
                    { new Guid("f28d8407-9365-465b-bafc-3feb494c2084"), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(3044), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Fizik Bilimine Giriş" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsTopics",
                columns: new[] { "QuestionId", "TopicId", "Id" },
                values: new object[,]
                {
                    { new Guid("05cacb1f-fb81-4ef8-ade9-a874bdd639b5"), new Guid("d0f2ad0a-3010-49f8-b12e-84283229d212"), new Guid("1683d773-55a5-43c2-81d0-d22994fb3cf1") },
                    { new Guid("068e881b-54af-432c-b8c1-20e3f09cf083"), new Guid("d0f2ad0a-3010-49f8-b12e-84283229d212"), new Guid("e553c5b5-7102-429f-aec2-03e3cf2515f2") },
                    { new Guid("1140c297-2770-48b1-b266-1e0dbed7e62d"), new Guid("d0f2ad0a-3010-49f8-b12e-84283229d212"), new Guid("63dedbb8-3484-4acb-aebf-3668866881f3") },
                    { new Guid("12a954a7-c2aa-4bf6-b452-67585cef0308"), new Guid("f28d8407-9365-465b-bafc-3feb494c2084"), new Guid("1ca8a04d-b1e5-4ede-8b11-a13e108e0627") },
                    { new Guid("135d40e2-967f-4896-92e8-af10868fdfb2"), new Guid("724755e2-fb14-4302-9327-0471717030a8"), new Guid("331dee72-2787-418a-9945-db539211397a") },
                    { new Guid("1717ac60-c688-4ec7-82f4-8f0aadcb5823"), new Guid("865e3d41-056d-4955-848d-891095755cad"), new Guid("9d9b289f-d091-49bf-9508-5daf6c4d84e4") },
                    { new Guid("1c2fc5cb-9438-4f04-a529-a86be3dff1de"), new Guid("bc98ee65-c5c2-4ae7-9df1-b455bda888ce"), new Guid("ff9f3ecf-d256-4e87-a67a-59343397e72f") },
                    { new Guid("1d479b3a-50a0-407a-bcea-425d201612c5"), new Guid("1095ef60-ce09-402c-ac15-d459ca4725ce"), new Guid("62651162-4684-4b7a-ad67-9258bd5803ce") },
                    { new Guid("1ebfb32c-2edb-4a49-88d5-50ef274f2cb3"), new Guid("641afa0d-f192-4cd0-8875-9fb4afd8ec6a"), new Guid("20245fe8-49fc-4224-bf48-92c8abff47c1") },
                    { new Guid("21605f70-e3cc-4f72-af51-001813b26885"), new Guid("bc98ee65-c5c2-4ae7-9df1-b455bda888ce"), new Guid("56c46999-55e9-4bcc-8b33-ad7ecca0e2ba") },
                    { new Guid("21ccfaef-bbaf-4c42-84ba-f2ea3176c851"), new Guid("bc98ee65-c5c2-4ae7-9df1-b455bda888ce"), new Guid("300785a6-946f-4452-b620-1e601f82176a") },
                    { new Guid("231a4a33-9ad0-4ac9-be0c-fab65da7620c"), new Guid("1313c405-f8a2-4aef-b5bd-b4f4ebd8731f"), new Guid("f40cb6e4-832b-4da6-a981-e53f619d926a") },
                    { new Guid("256f276b-3bfb-4bdb-b26b-971217a3539b"), new Guid("f28d8407-9365-465b-bafc-3feb494c2084"), new Guid("ea2fcc70-ca9c-43f5-b2e5-26fd24804344") },
                    { new Guid("2571ddf7-a9aa-424b-8303-3b933f4e13c1"), new Guid("09094021-1cfe-4608-8880-f968e7447457"), new Guid("89029481-1864-4f62-b4d9-0f694d05d422") },
                    { new Guid("269a3a0d-b3fe-43e4-a399-4b5f54111559"), new Guid("09094021-1cfe-4608-8880-f968e7447457"), new Guid("6a350a97-3544-4a85-a3c0-650b60aa1b64") },
                    { new Guid("39a76a14-1745-43da-afc9-8d9fefc07249"), new Guid("53304228-3e1b-4e4d-8148-e5ad9de55d7b"), new Guid("07a38ac5-988e-41f2-9ee9-391741c78637") },
                    { new Guid("3c83a7f7-76d3-45aa-b925-e45c3e2e0d28"), new Guid("921ec33e-59bc-40ad-b38b-88458fa1b10d"), new Guid("a6b5a127-46b8-41b5-b693-0a58697fc46b") },
                    { new Guid("3d70c48e-9665-426f-8622-77c8c26599f1"), new Guid("dbc61688-251e-4fcb-aae9-f74ceca06242"), new Guid("bdb70c24-5986-4fcb-8c51-c9c5be3c8f58") },
                    { new Guid("3e342df6-2378-4db0-b563-9679f1e27479"), new Guid("865e3d41-056d-4955-848d-891095755cad"), new Guid("da8f5ee3-e785-46df-8691-9f8bc14e457e") },
                    { new Guid("3fc6e5a4-e9a4-4344-ab1f-21d58c0a4ebd"), new Guid("5ea8fbd1-0677-4847-9567-5d78c7c66b41"), new Guid("accf7966-a748-4b2d-abc8-c664afc5538b") },
                    { new Guid("40d891e2-f9bc-4ad6-aa08-5701c94b215c"), new Guid("641afa0d-f192-4cd0-8875-9fb4afd8ec6a"), new Guid("14c10fec-010c-4df9-8afa-6d0d9b0885a9") },
                    { new Guid("41306a07-62cb-4155-9e7f-0590d389f5c6"), new Guid("d0f2ad0a-3010-49f8-b12e-84283229d212"), new Guid("730b560f-e5b1-4499-a82a-28d7aba1adf7") },
                    { new Guid("42dc8912-bf6e-4a31-9a56-cd122bc90126"), new Guid("7dbc14b1-f84d-4f51-a0f2-880ae3942d77"), new Guid("71f840b4-018a-48f1-9aba-2c5356161edd") },
                    { new Guid("4f37ac55-ee01-43fe-9ff4-ef65b30272c9"), new Guid("e376d503-07a2-4f83-a2d7-3841e827048b"), new Guid("d3158c45-6a83-4106-810d-75514342715d") },
                    { new Guid("4ff50c8b-d779-41e3-963f-ec48efc7b638"), new Guid("dbc61688-251e-4fcb-aae9-f74ceca06242"), new Guid("6280687a-0cf1-4e72-8c16-658442631ff4") },
                    { new Guid("54c92303-5f97-485e-9bd0-adeb075b6028"), new Guid("1095ef60-ce09-402c-ac15-d459ca4725ce"), new Guid("04f21ff5-0fe0-42ee-9286-4fa754c9f1ce") },
                    { new Guid("55afd203-0321-4a0a-9096-5f40ff8be409"), new Guid("7f6b4109-c898-4169-9f38-360d50c96c98"), new Guid("df2748b4-64d9-47ac-a733-399417732260") },
                    { new Guid("58fa1b40-7952-4831-99ff-aceb425554f7"), new Guid("724755e2-fb14-4302-9327-0471717030a8"), new Guid("a1cad2d7-1003-40ef-b93e-65b23de39b3c") },
                    { new Guid("5c27fd8c-8b7a-4017-963e-432e28dd2482"), new Guid("e376d503-07a2-4f83-a2d7-3841e827048b"), new Guid("7fb3ea9d-6019-44a3-bbdd-4cba82944ba0") },
                    { new Guid("5fc8bc87-7087-4406-90cf-65a9569a0e50"), new Guid("865e3d41-056d-4955-848d-891095755cad"), new Guid("b810d11d-a06b-4652-97e1-43b1586dfaf2") },
                    { new Guid("61e309ef-e263-48ba-b2db-1244a36d256d"), new Guid("f28d8407-9365-465b-bafc-3feb494c2084"), new Guid("a571ee9e-2e93-4fc8-bd56-a7fbb6c10830") },
                    { new Guid("63023acc-1d43-44e4-9292-7b8437a2614b"), new Guid("7dbc14b1-f84d-4f51-a0f2-880ae3942d77"), new Guid("fc215fe0-b5ab-4bc0-a1a9-11d0aa99b272") },
                    { new Guid("63148dcd-7d67-49d3-8a53-55b01b43b7b7"), new Guid("f28d8407-9365-465b-bafc-3feb494c2084"), new Guid("9ba82479-85b4-45a1-9d44-ab37d17101e3") },
                    { new Guid("657e2277-51a3-4de7-8174-9e26ce9cdfd4"), new Guid("1313c405-f8a2-4aef-b5bd-b4f4ebd8731f"), new Guid("48efe524-c5ca-4973-b65c-18f99cc17842") },
                    { new Guid("684b3740-3af7-473b-8113-57de37cc9ca5"), new Guid("1313c405-f8a2-4aef-b5bd-b4f4ebd8731f"), new Guid("f0e9c400-5386-4357-81f9-4e21809cb9f9") },
                    { new Guid("6a7f4540-8d85-4728-b838-951cebf15cc9"), new Guid("641afa0d-f192-4cd0-8875-9fb4afd8ec6a"), new Guid("5baf66b4-952a-4e00-a2a9-086105834fe9") },
                    { new Guid("6ac51ce1-d7ce-4f69-b0b6-7425a7c3b824"), new Guid("94913c7f-b818-4d10-a764-6148eb4cf683"), new Guid("3a26dae6-e1ac-482b-85e4-514e3df38ffb") },
                    { new Guid("6b8d3e40-d0af-43b9-8b9b-bca113c43e63"), new Guid("f2281e0c-d56e-4be5-9285-dc918b56345e"), new Guid("c9290511-3850-4e37-8407-3f9b2e8a2426") },
                    { new Guid("6eecc7d6-e704-47a1-8889-78c3b0f17f07"), new Guid("f2281e0c-d56e-4be5-9285-dc918b56345e"), new Guid("6c5c17ad-416d-4526-b26b-5c4da27fd1ea") },
                    { new Guid("6fe13201-d642-4e16-a6bf-77d0f15fbb11"), new Guid("09094021-1cfe-4608-8880-f968e7447457"), new Guid("f9e6d32c-7413-4c89-85a5-ac7df2111a6c") },
                    { new Guid("723da3a2-6253-49fc-a7f6-771e2a47f44a"), new Guid("1313c405-f8a2-4aef-b5bd-b4f4ebd8731f"), new Guid("40cae6df-1264-463f-8d0c-a95f86ae6e03") },
                    { new Guid("733744d1-0f11-41e6-b034-f2dc0ea9922c"), new Guid("5f5a875d-3a39-4f15-80b3-6cd223f88e74"), new Guid("ea9a4987-b814-47a3-ae67-989f7e64fe7f") },
                    { new Guid("78c507d7-00a0-4d5c-b47f-c5ab450b677c"), new Guid("e376d503-07a2-4f83-a2d7-3841e827048b"), new Guid("e4f3f280-cffe-416a-a12c-a49f22184509") },
                    { new Guid("7a947aec-6426-414b-bead-7b6e8e6c0cad"), new Guid("641afa0d-f192-4cd0-8875-9fb4afd8ec6a"), new Guid("cf19b3d2-42c6-4afb-b0b6-1816dc6531cc") },
                    { new Guid("7b5f377b-a9c3-423c-94cb-05dadd6205b9"), new Guid("bc98ee65-c5c2-4ae7-9df1-b455bda888ce"), new Guid("fe08ebb6-b1b8-4998-a91f-6d122b779205") },
                    { new Guid("7cda3d24-133b-4de8-80d2-42a53bf38cff"), new Guid("921ec33e-59bc-40ad-b38b-88458fa1b10d"), new Guid("abd29151-c2a5-4f81-a80c-097484281922") },
                    { new Guid("8bc26171-537a-433d-b315-7c47470b7064"), new Guid("5f5a875d-3a39-4f15-80b3-6cd223f88e74"), new Guid("8d9877af-4d99-4c78-941c-cc1bebe0a2b9") },
                    { new Guid("8dd5ac5f-d21d-462e-b716-e55860de1b2b"), new Guid("7dbc14b1-f84d-4f51-a0f2-880ae3942d77"), new Guid("e34a5229-e118-4a48-b244-9e7dc3932f64") },
                    { new Guid("90c6a6dd-384b-4f0d-9255-aaa2704a519a"), new Guid("94913c7f-b818-4d10-a764-6148eb4cf683"), new Guid("cdba31cb-80c7-4e81-8a85-c127ea98b220") },
                    { new Guid("90d93f04-c893-4e38-bbde-ad14a7f299e3"), new Guid("f2281e0c-d56e-4be5-9285-dc918b56345e"), new Guid("50a9ff49-f34d-4832-b9a4-176acdb66361") },
                    { new Guid("94be52e0-61f0-4381-9f7f-9b89f670e0ed"), new Guid("94913c7f-b818-4d10-a764-6148eb4cf683"), new Guid("58364857-4d11-43e9-b762-d50ae7eb82b6") },
                    { new Guid("94cff220-3586-4222-9c94-2dd3178ef575"), new Guid("1095ef60-ce09-402c-ac15-d459ca4725ce"), new Guid("510ba3c9-5d69-4118-bbe5-06d7f199ff76") },
                    { new Guid("966e483e-8aac-430c-8f1e-9215c8892420"), new Guid("53304228-3e1b-4e4d-8148-e5ad9de55d7b"), new Guid("c9525c80-a013-469c-8938-9bf1f7d5e738") },
                    { new Guid("9bb2992e-d761-46f5-ba7f-43b16753a0da"), new Guid("09094021-1cfe-4608-8880-f968e7447457"), new Guid("a92bc2cb-09e3-4e09-8e72-02f33b340bb2") },
                    { new Guid("9da39309-e1ef-4bd2-b159-de905237573e"), new Guid("5a0553d7-badd-4cd0-9040-1cf66e125db5"), new Guid("491f3ae5-37de-4078-a6e7-91ad61bfd100") },
                    { new Guid("9dabb6ff-80e2-4017-b09b-d735e6c2d1a8"), new Guid("5ea8fbd1-0677-4847-9567-5d78c7c66b41"), new Guid("7956f3c3-1039-4491-aafd-0f30fb8704fc") },
                    { new Guid("9ead5ebb-6b09-41fd-a709-b610695070cb"), new Guid("5f5a875d-3a39-4f15-80b3-6cd223f88e74"), new Guid("52601783-37ef-4a28-a9d2-4eaac4a552cb") },
                    { new Guid("9ec27680-1943-4820-ae0b-a1e14e3c72b3"), new Guid("dbc61688-251e-4fcb-aae9-f74ceca06242"), new Guid("8713c37b-d678-48b5-aa3e-0e8ead79c8fd") },
                    { new Guid("9ef617f8-1901-48d4-a8cc-14a187049a03"), new Guid("dbc61688-251e-4fcb-aae9-f74ceca06242"), new Guid("ab50e8e7-845e-425f-b40d-de3b713d766a") },
                    { new Guid("a02d6e3b-64b6-4610-b617-c527643f0a17"), new Guid("5f5a875d-3a39-4f15-80b3-6cd223f88e74"), new Guid("8124f3c9-47ec-411e-8a39-18a1ebff14ac") },
                    { new Guid("a248f17a-d780-49cf-8a16-c872aa686c8b"), new Guid("f28d8407-9365-465b-bafc-3feb494c2084"), new Guid("72b84a47-8cde-4e8d-ac47-14771b1e78ec") },
                    { new Guid("a26e377a-7357-47f7-a6ae-0fb1e3d662b2"), new Guid("865e3d41-056d-4955-848d-891095755cad"), new Guid("6edc59f8-8256-4ae3-93dd-393b9353ad3e") },
                    { new Guid("a4184c9f-1f6e-4b54-8b29-9b94820bcd1c"), new Guid("5a0553d7-badd-4cd0-9040-1cf66e125db5"), new Guid("17a2fed2-5101-41de-8f89-ab5b0a03627c") },
                    { new Guid("abdbd19f-1353-4c60-9eee-81ccabfe3099"), new Guid("7f6b4109-c898-4169-9f38-360d50c96c98"), new Guid("23554635-7306-477c-bdbc-3df00ec69906") },
                    { new Guid("b01219d4-b8c8-45a6-b1c5-bf6404d877c5"), new Guid("641afa0d-f192-4cd0-8875-9fb4afd8ec6a"), new Guid("e5bbadf6-e839-45fd-ba86-45cee6fae163") },
                    { new Guid("b56170da-0aab-45ed-b542-966021b74cda"), new Guid("f2281e0c-d56e-4be5-9285-dc918b56345e"), new Guid("9547357e-93fa-4712-9652-27d98b75c60f") },
                    { new Guid("b58e9d1f-c68f-428f-8200-0dc5f5f9ae4e"), new Guid("5a0553d7-badd-4cd0-9040-1cf66e125db5"), new Guid("a09ef615-d43c-42c0-82e8-2e728ae3fbc6") },
                    { new Guid("b73820c6-3fbf-4e73-8a43-e976bca64293"), new Guid("53304228-3e1b-4e4d-8148-e5ad9de55d7b"), new Guid("5b2c4651-b98b-4006-8b15-abb193eeb33e") },
                    { new Guid("b749b575-022f-4e30-b061-e09290ec6a35"), new Guid("94913c7f-b818-4d10-a764-6148eb4cf683"), new Guid("337f4e47-39f1-4f5b-93cf-3658a89111eb") },
                    { new Guid("b78290f6-f7f8-4b63-9664-98d7d55b0cb0"), new Guid("53304228-3e1b-4e4d-8148-e5ad9de55d7b"), new Guid("34c4da64-ee39-473c-b2b8-7808ba79299d") },
                    { new Guid("bd71c431-0cfc-416b-a6c8-a81b6a13b489"), new Guid("bc98ee65-c5c2-4ae7-9df1-b455bda888ce"), new Guid("75f6d6f3-be28-46f6-80e8-a37b6e02e6fb") },
                    { new Guid("c16f43e0-6a32-4654-9271-61eb4e1f311a"), new Guid("5ea8fbd1-0677-4847-9567-5d78c7c66b41"), new Guid("283dbeee-f740-4690-a225-b5bdc018e91f") },
                    { new Guid("c17f891c-cd4d-430c-ab3b-1ef8ba3b13e0"), new Guid("7f6b4109-c898-4169-9f38-360d50c96c98"), new Guid("4a7b6a1f-5377-4e03-a807-d64d1f681a22") },
                    { new Guid("c2ea199f-1c40-4655-b345-1b0c38483830"), new Guid("921ec33e-59bc-40ad-b38b-88458fa1b10d"), new Guid("ae9fb3db-1a85-475f-8622-40bddb3b1ff7") },
                    { new Guid("c4782e88-ceff-4e4e-9d11-8b08abf71767"), new Guid("865e3d41-056d-4955-848d-891095755cad"), new Guid("44c0b26c-3e99-461f-8ef5-3abf75f5480a") },
                    { new Guid("c67f7246-8cc1-47e6-8ad6-d6fda56b096e"), new Guid("5f5a875d-3a39-4f15-80b3-6cd223f88e74"), new Guid("3d9aa950-6542-4209-9693-35785b820a59") },
                    { new Guid("c77f4908-d6e6-4108-bf4e-38bc65e427a9"), new Guid("5a0553d7-badd-4cd0-9040-1cf66e125db5"), new Guid("9bd13460-f216-4f56-882a-1927ee62dbaa") },
                    { new Guid("c7cce731-c470-4ef2-a03e-22e592a99858"), new Guid("7f6b4109-c898-4169-9f38-360d50c96c98"), new Guid("a4867bd2-5980-40f9-9369-ce84fc5e977f") },
                    { new Guid("c99a65f5-cdcb-4d8c-af93-211cc0e6fbc8"), new Guid("e376d503-07a2-4f83-a2d7-3841e827048b"), new Guid("4c1dce10-e15c-41dc-999a-6624282c3335") },
                    { new Guid("c9fa7708-e4e4-4df0-8e37-d6e6c92dd4d6"), new Guid("1095ef60-ce09-402c-ac15-d459ca4725ce"), new Guid("8de2d4ee-1850-4017-ad67-93eddc61a3d1") },
                    { new Guid("cb79ee79-946a-49df-b127-c9bd67fc33f3"), new Guid("921ec33e-59bc-40ad-b38b-88458fa1b10d"), new Guid("f56269ea-3b2c-4d64-b2cc-5d4c03f28421") },
                    { new Guid("ce47c25d-323c-45f7-96fd-1f4acf3737e9"), new Guid("7dbc14b1-f84d-4f51-a0f2-880ae3942d77"), new Guid("1fab1e62-7288-47eb-a9e0-aee71412bd3c") },
                    { new Guid("d2f672b2-2871-4c2f-8e63-ef9548a6b09a"), new Guid("94913c7f-b818-4d10-a764-6148eb4cf683"), new Guid("7877a7d6-ccfe-40f0-a32a-cf2d3c334c5c") },
                    { new Guid("d3854e2b-2397-4fc9-b1d2-c6b91ca1bd87"), new Guid("724755e2-fb14-4302-9327-0471717030a8"), new Guid("57c4f6e5-40f0-472e-ab16-b71674000135") },
                    { new Guid("d3db32bc-ddb0-4bb4-a41d-cded9026d334"), new Guid("5ea8fbd1-0677-4847-9567-5d78c7c66b41"), new Guid("e528bfa0-755b-4264-924e-a85c49090964") },
                    { new Guid("d4758d8d-8eee-4264-825a-e82b7807ec45"), new Guid("e376d503-07a2-4f83-a2d7-3841e827048b"), new Guid("688ec8a8-278a-4541-94db-2817faa2ad8a") },
                    { new Guid("db5f67e6-29f0-4c0e-aae0-b976dd71f21d"), new Guid("7dbc14b1-f84d-4f51-a0f2-880ae3942d77"), new Guid("7a51eea7-2ceb-4508-b283-9affd85006e6") },
                    { new Guid("ded940c8-673b-4281-b6a1-688f2ea95296"), new Guid("5ea8fbd1-0677-4847-9567-5d78c7c66b41"), new Guid("9c6669cb-01a2-42bc-b6fe-bc5ade85167d") },
                    { new Guid("df250e8b-79ad-4bd0-8d82-284d7b08464c"), new Guid("1313c405-f8a2-4aef-b5bd-b4f4ebd8731f"), new Guid("2bd0e803-08ca-44b5-a4bb-06729d04dad1") },
                    { new Guid("dfeedca3-bd62-45c9-a4e7-39013c6c32d3"), new Guid("dbc61688-251e-4fcb-aae9-f74ceca06242"), new Guid("526028d9-6ee1-4ee3-9816-37fbc2e9043b") },
                    { new Guid("e1b872c7-7368-4af8-b0a0-e8abf2bb3fa5"), new Guid("7f6b4109-c898-4169-9f38-360d50c96c98"), new Guid("2b0ca509-c246-42aa-ae90-9877e266c8bc") },
                    { new Guid("e5e91d0d-16f7-4748-9f8b-37981fbe715d"), new Guid("f2281e0c-d56e-4be5-9285-dc918b56345e"), new Guid("83572f2a-c450-4cda-874e-f69ce8fdd7a6") },
                    { new Guid("e7646b17-006a-40d5-9b92-93241b8eea17"), new Guid("d0f2ad0a-3010-49f8-b12e-84283229d212"), new Guid("e3afd575-7418-4023-9e3e-93be63eb1ccf") },
                    { new Guid("e95e604c-a75a-4958-96cd-ac3414914c26"), new Guid("5a0553d7-badd-4cd0-9040-1cf66e125db5"), new Guid("894d05a2-4274-4e68-bdbb-865c38a5646f") },
                    { new Guid("ea5c9a88-fd74-4228-b22e-6907dbbc9b1f"), new Guid("53304228-3e1b-4e4d-8148-e5ad9de55d7b"), new Guid("5caea789-6f9d-4aba-9e2c-c8374f556e3d") },
                    { new Guid("f2e506c4-534a-4458-9283-be550f780a29"), new Guid("724755e2-fb14-4302-9327-0471717030a8"), new Guid("a533487c-b7eb-464d-9d53-7b4120d772dd") },
                    { new Guid("f3083308-1307-42ed-9619-bc5e54b2a62d"), new Guid("1095ef60-ce09-402c-ac15-d459ca4725ce"), new Guid("bed5977f-05d1-4003-98eb-d177df043338") },
                    { new Guid("f5449f09-9b12-4f97-8094-d1268b96b21a"), new Guid("921ec33e-59bc-40ad-b38b-88458fa1b10d"), new Guid("10cbd3db-8742-4dc3-931d-d14e1023cfff") },
                    { new Guid("fcbd13b4-9309-4d3e-a12d-d4ee7d37b6ed"), new Guid("724755e2-fb14-4302-9327-0471717030a8"), new Guid("37a8248e-6749-4baf-988b-d3fa8de8a574") },
                    { new Guid("ff3654f8-2965-4b28-9392-ab121290cc58"), new Guid("09094021-1cfe-4608-8880-f968e7447457"), new Guid("00a0b5d8-b36f-4422-ba45-a73fa91323c8") }
                });

            migrationBuilder.InsertData(
                table: "UserPerformanceSummaries",
                columns: new[] { "Id", "CorrectAnswers", "CreatedAt", "LastUpdatedAt", "SuccessRate", "TopicId", "TotalQuestionsAnswered", "UserId" },
                values: new object[,]
                {
                    { new Guid("02f4c6b0-6098-4f7d-a28a-563f60385a64"), 41, new DateTime(2025, 7, 24, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5132), new DateTime(2025, 8, 5, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5138), 42.270000000000003, new Guid("7f6b4109-c898-4169-9f38-360d50c96c98"), 97, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("0b918c2e-8b89-4014-b334-75bcedca1d77"), 48, new DateTime(2025, 8, 2, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5154), new DateTime(2025, 8, 7, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5154), 77.420000000000002, new Guid("921ec33e-59bc-40ad-b38b-88458fa1b10d"), 62, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("1afd4351-62c1-422e-bdd1-a9a7f1ad51c4"), 54, new DateTime(2025, 7, 27, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5159), new DateTime(2025, 8, 5, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5159), 75.0, new Guid("7f6b4109-c898-4169-9f38-360d50c96c98"), 72, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("2cf8fd8d-19c3-44e3-8f4e-76c2bcbfb30a"), 58, new DateTime(2025, 7, 19, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5144), new DateTime(2025, 8, 2, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5144), 81.689999999999998, new Guid("921ec33e-59bc-40ad-b38b-88458fa1b10d"), 71, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("3d07889f-fa7c-4f50-a5ba-052bcbf2033f"), 31, new DateTime(2025, 7, 31, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5142), new DateTime(2025, 8, 7, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5143), 39.740000000000002, new Guid("94913c7f-b818-4d10-a764-6148eb4cf683"), 78, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("406f9768-10a4-47e3-a96d-21c323a92658"), 5, new DateTime(2025, 7, 18, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5155), new DateTime(2025, 8, 6, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5156), 19.23, new Guid("641afa0d-f192-4cd0-8875-9fb4afd8ec6a"), 26, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("5e9377b8-9db0-44ff-bc1b-408950b7a5f4"), 16, new DateTime(2025, 7, 19, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5163), new DateTime(2025, 8, 5, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5164), 72.730000000000004, new Guid("921ec33e-59bc-40ad-b38b-88458fa1b10d"), 22, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("8d733d13-94b0-4d17-982b-546cbe6b35ac"), 22, new DateTime(2025, 7, 15, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5166), new DateTime(2025, 8, 3, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5166), 84.620000000000005, new Guid("d0f2ad0a-3010-49f8-b12e-84283229d212"), 26, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("94aaef52-dc61-4047-82f7-6dcedef25f4a"), 55, new DateTime(2025, 7, 16, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5148), new DateTime(2025, 8, 2, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5148), 85.939999999999998, new Guid("d0f2ad0a-3010-49f8-b12e-84283229d212"), 64, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("971cecd5-a409-4321-a4eb-909f9afaece0"), 21, new DateTime(2025, 7, 13, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5147), new DateTime(2025, 8, 2, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5147), 24.140000000000001, new Guid("641afa0d-f192-4cd0-8875-9fb4afd8ec6a"), 87, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("e8105b48-5dc1-4d04-ba25-9b617b19bea8"), 11, new DateTime(2025, 7, 29, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5157), new DateTime(2025, 8, 8, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5158), 50.0, new Guid("d0f2ad0a-3010-49f8-b12e-84283229d212"), 22, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("edf71c80-5d56-40da-b19a-e47ec47759a9"), 37, new DateTime(2025, 7, 28, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5162), new DateTime(2025, 8, 7, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5162), 48.68, new Guid("94913c7f-b818-4d10-a764-6148eb4cf683"), 76, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("f2c7ec72-98a1-4da5-8928-a23db2efd8cf"), 44, new DateTime(2025, 8, 1, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5152), new DateTime(2025, 8, 6, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5153), 83.019999999999996, new Guid("94913c7f-b818-4d10-a764-6148eb4cf683"), 53, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("fdcecf88-d9fa-4b19-8f7e-131bd1bf003d"), 37, new DateTime(2025, 7, 12, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5151), new DateTime(2025, 8, 5, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5151), 90.239999999999995, new Guid("7f6b4109-c898-4169-9f38-360d50c96c98"), 41, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("fe3d0403-a5b9-4cd6-a138-2d31360daef6"), 40, new DateTime(2025, 7, 15, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5165), new DateTime(2025, 8, 3, 11, 48, 43, 539, DateTimeKind.Utc).AddTicks(5165), 57.140000000000001, new Guid("641afa0d-f192-4cd0-8875-9fb4afd8ec6a"), 70, new Guid("33333333-3333-3333-3333-333333333333") }
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
