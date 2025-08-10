using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AkademikAi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
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
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "dummy-conc-1", new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3483), "ali@example.com", true, false, null, "Ali", "ALI@EXAMPLE.COM", "ALI", "AQAAAAEAACcQAAAAEDummyHash1==", "5551111111", false, "dummy-stamp-1", "Veli", false, "ali", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "dummy-conc-2", new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3490), "ayse@example.com", true, false, null, "Ayşe", "AYSE@EXAMPLE.COM", "AYSE", "AQAAAAEAACcQAAAAEDummyHash2==", "5552222222", false, "dummy-stamp-2", "Yılmaz", false, "ayse", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "dummy-conc-3", new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3501), "mehmet@example.com", true, false, null, "Mehmet", "MEHMET@EXAMPLE.COM", "MEHMET", "AQAAAAEAACcQAAAAEDummyHash3==", "5553333333", false, "dummy-stamp-3", "Demir", false, "mehmet", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevel", "GeneratedForUserId", "IsActive", "QuestionText", "SolutionText", "Source" },
                values: new object[,]
                {
                    { new Guid("0923e78e-dd64-4a04-852f-b584f805955a"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0b1dffb9-5249-4061-96e0-9123d73b4f2d"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0ebcf967-c56f-44fc-81d6-6b7ac8caabe7"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("10b4ab12-6b09-4beb-a746-75b995012ce2"), 2, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("111e2df0-41f5-4333-87db-fcef64f296df"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("12712761-80a7-49ad-88ee-d34b7fd7905a"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("12a60e09-fafa-4b18-8fbc-710b63e4635c"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1833a3b0-acfc-49ad-a0a1-20c6b9131936"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1850bfe5-ab6c-4b68-86f0-cc682b3e3314"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("19bf3cb1-5dfd-42aa-aa23-c844dc10b5fc"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1aea283e-c697-471c-b66f-999505c7a5ba"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1bd4563d-fc43-461f-864b-6f03ab948f40"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1c941f8d-e706-41fe-9006-94848ffa1bdd"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1ea17762-47be-4e6a-944a-9e1b4919d3fa"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("272cd872-2855-453a-b83d-fa6a19746551"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2a798d7f-98f8-42f7-bb54-3bcadda4c9a9"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2bb9e157-de48-43d5-85aa-591d5ee6b06d"), 2, null, true, "Elektrostatik konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2bca2c45-8d41-4026-855e-296f3233e926"), 1, null, true, "Problemler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2d13d538-0378-486c-9a45-dd51de764f40"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("30245ea2-1640-48a5-aaf4-0b92aa95ab8d"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("33e27efe-9709-49b6-8513-8f5d26b39e2b"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3682b943-54bd-466f-b2ca-8c6ca0917b15"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3745bdb8-22e6-4779-a0c8-dd5bdbb054cd"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3d6d8dfd-398e-4c80-b3e5-d9cbabc6ac58"), 1, null, true, "Kalıtım konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3f0f6a73-f1de-4455-9aec-3d19cb1b5556"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("49525d08-2e08-44d6-99fb-e92f7f112a28"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4bba942f-cddc-4e44-af3c-a18fe464e61d"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4fc6d20a-c87f-46d1-b7f4-ca6528eedc7e"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("50cfd01f-4fbb-4321-9c81-fe5ebd6e6aa1"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("54d7f16c-cefb-447b-9145-cb69831e416f"), 0, null, true, "Hücre konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("564b00e8-e0a0-4a6d-926f-f4f2049b44b5"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5683a9bb-caf6-4987-bb89-994081b8cf25"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("56a2e950-7f57-4a0d-92e8-1fd534fcb849"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5d347e47-044f-4374-85ce-6418cff5d776"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5e8bc480-927f-436e-86d4-59cc9d8e35df"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5ef1dabf-749e-4adb-a496-12f3b7b873fb"), 2, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6012e350-d7ac-40c2-baad-7b62cd8c74d2"), 2, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("60e69b57-3a09-4c44-ad4e-631a19e5fae8"), 2, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6291bbca-372e-4d2a-b882-6209da83eee2"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("62bdc1aa-777b-48b9-b2f3-25d6ae8c0a90"), 2, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("63a6462d-6a4a-4ec8-93ed-1460d0d0e033"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("668cbdfb-7d41-4167-838c-44f772a79544"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("670f083d-c8b5-4e08-8cee-9b74d21b57da"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("68166f19-c9af-445f-93e2-517db463cd9c"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6d5c434a-9f4e-4474-bef5-376404305829"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6de0cbfb-1143-46af-9fbb-3646bba0dd1a"), 0, null, true, "Kalıtım konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6f59e3e8-733c-4a8d-ba63-d387d21de047"), 2, null, true, "Maddenin Halleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("70429a32-1a49-4e38-914a-cd90c052e877"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("710c4853-713e-42e4-8c9f-5f57cdd0d12c"), 0, null, true, "Problemler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("750169ef-b563-4728-8148-f1eacc4b55ca"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("79505962-817f-4e44-9a9b-9cc47ea15e08"), 0, null, true, "Hücre konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7962ee2c-1e38-4a0e-8115-0513bfb3a9fa"), 1, null, true, "Hücre konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("79653cf9-5e61-49f9-967f-9f8e43f3e825"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7fc23d4e-0206-42c9-b5eb-da8afad36d3f"), 1, null, true, "Problemler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8042bdd9-76e1-4650-8036-758b438c1a47"), 2, null, true, "Problemler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8d3a1978-3fda-46af-ab3e-a2436778503d"), 2, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("94e3594e-acf5-4e31-97d1-721d2f5f33c1"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("97459954-555a-4bbd-98ec-79758393ec5c"), 2, null, true, "Temel Kavramlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("98a17f7a-7b57-476e-94a8-0e954be33448"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9d4e6ea4-5aa3-46d5-a1dc-f6ebab4ab3f9"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9ea389a2-a8d3-48d1-81f3-286a0b94bf5a"), 2, null, true, "Sayı Basamakları konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9fd8e2c4-c2d1-4288-a4c3-73bbff56a41c"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a0d0e01a-6611-4be7-9e7f-16bb90db2aa8"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a2093370-bf69-454f-87f3-3fcab98a64aa"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a2b19c3d-bf9e-4d2c-8efc-aaab45c8aa2a"), 1, null, true, "Kalıtım konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a2dfd7da-88bb-4857-b28d-fab1117579d8"), 2, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a3a0ca6b-0b81-4a2a-9727-3c3795ad8ac2"), 2, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("abe12dd3-83da-4f9a-acfb-0d0fbdf444b0"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b0115b2a-1b83-4569-8589-09f1a93ef3bf"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b0e0c6c6-3ad5-4d45-b44d-c5162208bb31"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b14f8f39-a9ac-4336-9202-e8400545dffb"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b1e58b1e-2062-4650-800d-0e4c676582fb"), 1, null, true, "Hücre konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b2969742-7a87-499a-9963-13092055afe2"), 2, null, true, "Hücre konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c00b19f0-d671-426a-b179-96bf1ad403e8"), 2, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c1a38e98-3787-4551-8569-2010d5ff61e8"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c29858a6-8bfa-4934-a5dc-cd203b47e5b5"), 2, null, true, "Kimya Bilimi konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c2c1dab2-08ec-49b3-a9de-e83057920864"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c40af7c1-d0d1-47c6-90ec-40e23fa66eab"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c7653c3f-0479-48a8-b511-a96c57d950fb"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c7ed1a4a-0345-4f00-93d1-bd5b808b6348"), 2, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c9fe6527-0b56-4384-80fb-bdf1affea992"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d7b8f9eb-96f3-43f3-8790-fb9823aeb66e"), 0, null, true, "Problemler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d9323b94-9cc2-42d4-ab2d-04229adf7a12"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("da393945-d792-40a1-9f60-8b370de5f8e0"), 2, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("dcc9b02f-2375-4ca7-bc3c-cc0ebea391d8"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("dd961e5e-fa2c-492f-838a-34555569d151"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("de582186-208a-4968-9c29-5821e90f6b3a"), 2, null, true, "Kalıtım konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("de5a80c6-b26c-4aab-86c7-0d2c5065b444"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("df4e67d5-28ae-4fa0-a3c9-06d9677a9642"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e82c0d52-24a7-4081-b742-f21421758182"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e9d7959b-ea2b-4e02-bdbe-a6f82dffbfea"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ec8a69b0-be13-45f3-9f24-a4d57d5e3461"), 0, null, true, "Kalıtım konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("eeb9ff3e-ff4b-4b86-b3b5-e168ba8dbca4"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ef395918-4257-4105-843f-516a9c4e255f"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f035c3ec-dab4-4699-a92e-d6fad72c3fd9"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f70f0e4c-c6f0-4996-9b14-63fba55009c8"), 2, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fab166d3-493b-4ddd-8234-bc443f0e61e7"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fb79a2f8-3db4-4244-9b55-2dd710baf3b8"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fb7df210-f7fb-4277-adf3-ae8feb89d8eb"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fc85032b-3b13-492c-adc2-3b1d6ca784de"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3583), "Temel kimya konuları", true, "Kimya" },
                    { new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3582), "Temel fizik konuları", true, "Fizik" },
                    { new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3586), "Temel biyoloji konuları", true, "Biyoloji" },
                    { new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3578), "Temel matematik konuları", true, "Matematik" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "IsCorrect", "Label", "OptionOrder", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("013a709a-876d-4219-9d35-57a4bb166868"), true, "B", 2, "Kimya Bilimi - Soru 3 için Seçenek B", new Guid("c40af7c1-d0d1-47c6-90ec-40e23fa66eab") },
                    { new Guid("01b771c6-71cb-4399-b0e2-e7f6b642d8b5"), false, "A", 1, "Fizik Bilimine Giriş - Soru 4 için Seçenek A", new Guid("4bba942f-cddc-4e44-af3c-a18fe464e61d") },
                    { new Guid("02521d42-af92-4bfb-baee-5deb1ed8b072"), false, "C", 3, "Kimya Bilimi - Soru 5 için Seçenek C", new Guid("c29858a6-8bfa-4934-a5dc-cd203b47e5b5") },
                    { new Guid("02913ec6-d76f-4a2f-99dd-38031d8c3c28"), false, "B", 2, "Sayı Basamakları - Soru 5 için Seçenek B", new Guid("9ea389a2-a8d3-48d1-81f3-286a0b94bf5a") },
                    { new Guid("035cf8c0-c8c7-4364-af0a-635ca99bb893"), false, "B", 2, "Fizik Bilimine Giriş - Soru 5 için Seçenek B", new Guid("62bdc1aa-777b-48b9-b2f3-25d6ae8c0a90") },
                    { new Guid("042df398-c776-4b7b-81f4-d6105077cdcb"), false, "A", 1, "Kimya Bilimi - Soru 4 için Seçenek A", new Guid("1ea17762-47be-4e6a-944a-9e1b4919d3fa") },
                    { new Guid("06008010-5472-46a1-bbba-7a253b97ec0a"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek D", new Guid("1c941f8d-e706-41fe-9006-94848ffa1bdd") },
                    { new Guid("0601234a-9959-4825-8e1f-b01ee9dad266"), false, "C", 3, "Hücre Bölünmeleri - Soru 3 için Seçenek C", new Guid("2d13d538-0378-486c-9a45-dd51de764f40") },
                    { new Guid("07e41d72-2da1-49fb-b682-783b0661c50c"), false, "D", 4, "Hücre - Soru 5 için Seçenek D", new Guid("b2969742-7a87-499a-9963-13092055afe2") },
                    { new Guid("083720c8-189c-4982-af09-a253e9989259"), false, "B", 2, "Madde ve Özellikleri - Soru 4 için Seçenek B", new Guid("e82c0d52-24a7-4081-b742-f21421758182") },
                    { new Guid("083af497-b4ed-4472-9fd7-10a01044d667"), false, "A", 1, "Hücre - Soru 5 için Seçenek A", new Guid("b2969742-7a87-499a-9963-13092055afe2") },
                    { new Guid("09e82896-3ad6-49dd-85ff-649a8bdb2c8d"), false, "B", 2, "Hücre - Soru 2 için Seçenek B", new Guid("b1e58b1e-2062-4650-800d-0e4c676582fb") },
                    { new Guid("09fa5da0-5b51-4830-a78e-88927317fe67"), false, "A", 1, "Fizik Bilimine Giriş - Soru 5 için Seçenek A", new Guid("62bdc1aa-777b-48b9-b2f3-25d6ae8c0a90") },
                    { new Guid("09fe5615-bac1-41ba-aeee-b8f010831751"), true, "D", 4, "İş, Güç ve Enerji - Soru 1 için Seçenek D", new Guid("670f083d-c8b5-4e08-8cee-9b74d21b57da") },
                    { new Guid("0a073bba-cd30-4414-9c43-78f8abdb65dc"), false, "C", 3, "Fizik Bilimine Giriş - Soru 3 için Seçenek C", new Guid("668cbdfb-7d41-4167-838c-44f772a79544") },
                    { new Guid("0acb146e-8a05-43af-8dba-c6858f1cbcc0"), false, "A", 1, "Maddenin Halleri - Soru 2 için Seçenek A", new Guid("63a6462d-6a4a-4ec8-93ed-1460d0d0e033") },
                    { new Guid("0af5d04f-efa0-4907-8eaa-1b9d236a671c"), false, "A", 1, "Bölme ve Bölünebilme - Soru 4 için Seçenek A", new Guid("70429a32-1a49-4e38-914a-cd90c052e877") },
                    { new Guid("0b039fe3-72e4-4af5-b5e7-1fc9d48a8215"), false, "B", 2, "Fizik Bilimine Giriş - Soru 3 için Seçenek B", new Guid("668cbdfb-7d41-4167-838c-44f772a79544") },
                    { new Guid("0b4447cf-6e1c-41ae-9df2-3ffb9f8d3f1e"), false, "D", 4, "Rasyonel Sayılar - Soru 2 için Seçenek D", new Guid("49525d08-2e08-44d6-99fb-e92f7f112a28") },
                    { new Guid("0be161bb-da67-441e-9376-5e8e58673fb1"), false, "A", 1, "Sayı Basamakları - Soru 2 için Seçenek A", new Guid("2a798d7f-98f8-42f7-bb54-3bcadda4c9a9") },
                    { new Guid("0c8e5461-cce2-40ae-8e5a-10f56eb477db"), false, "B", 2, "Kuvvet ve Hareket - Soru 3 için Seçenek B", new Guid("dd961e5e-fa2c-492f-838a-34555569d151") },
                    { new Guid("0cd28edc-cb2d-48cd-9ec1-f6dde889a1b1"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 1 için Seçenek C", new Guid("79653cf9-5e61-49f9-967f-9f8e43f3e825") },
                    { new Guid("0cd5dfe7-0bf9-48cd-8ccf-8b0483e09c39"), false, "C", 3, "Kimya Bilimi - Soru 4 için Seçenek C", new Guid("1ea17762-47be-4e6a-944a-9e1b4919d3fa") },
                    { new Guid("0d33ab80-25e6-4046-83db-201f4a3cb118"), true, "B", 2, "Madde ve Özellikleri - Soru 5 için Seçenek B", new Guid("c7ed1a4a-0345-4f00-93d1-bd5b808b6348") },
                    { new Guid("0d4ab435-1a59-40e1-816f-04d2bf84af92"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 2 için Seçenek C", new Guid("fc85032b-3b13-492c-adc2-3b1d6ca784de") },
                    { new Guid("0efbb3bf-626d-4e00-9041-11c0ed3d00dc"), true, "B", 2, "Temel Kavramlar - Soru 2 için Seçenek B", new Guid("4fc6d20a-c87f-46d1-b7f4-ca6528eedc7e") },
                    { new Guid("0f59f090-9f05-4871-aa87-722704e31b87"), true, "D", 4, "Fizik Bilimine Giriş - Soru 2 için Seçenek D", new Guid("0ebcf967-c56f-44fc-81d6-6b7ac8caabe7") },
                    { new Guid("0f637916-bbdd-4749-bef2-3362ba73de5f"), false, "A", 1, "Rasyonel Sayılar - Soru 5 için Seçenek A", new Guid("10b4ab12-6b09-4beb-a746-75b995012ce2") },
                    { new Guid("0fe2060b-86b3-4017-9ba2-792b9f7901eb"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 3 için Seçenek C", new Guid("50cfd01f-4fbb-4321-9c81-fe5ebd6e6aa1") },
                    { new Guid("10b6266b-c072-48be-923f-47a24a7d4ad6"), false, "A", 1, "Maddenin Halleri - Soru 4 için Seçenek A", new Guid("fb7df210-f7fb-4277-adf3-ae8feb89d8eb") },
                    { new Guid("10cb9375-d887-4f0f-8f61-f6f65dc8aae0"), true, "C", 3, "Madde ve Özellikleri - Soru 3 için Seçenek C", new Guid("5683a9bb-caf6-4987-bb89-994081b8cf25") },
                    { new Guid("11cbf357-1d98-4da7-8ca3-1436a3ee3a28"), false, "D", 4, "Maddenin Halleri - Soru 1 için Seçenek D", new Guid("19bf3cb1-5dfd-42aa-aa23-c844dc10b5fc") },
                    { new Guid("12532df1-7fc1-4c3a-973b-71cb52e7cbcc"), true, "D", 4, "Hücre Bölünmeleri - Soru 2 için Seçenek D", new Guid("98a17f7a-7b57-476e-94a8-0e954be33448") },
                    { new Guid("1254ffea-d1f1-4bfe-aade-740900b0622a"), false, "D", 4, "Hücre - Soru 4 için Seçenek D", new Guid("7962ee2c-1e38-4a0e-8115-0513bfb3a9fa") },
                    { new Guid("12b3afa7-dbea-463c-9e3e-8e00fe9fec9f"), false, "C", 3, "Sayı Basamakları - Soru 4 için Seçenek C", new Guid("ef395918-4257-4105-843f-516a9c4e255f") },
                    { new Guid("13815911-bd3b-4da9-8c50-73fa6b2ca1cf"), true, "D", 4, "Kalıtım - Soru 2 için Seçenek D", new Guid("3d6d8dfd-398e-4c80-b3e5-d9cbabc6ac58") },
                    { new Guid("14d41f79-507b-45c9-9855-a957888aed17"), false, "C", 3, "Hücre - Soru 2 için Seçenek C", new Guid("b1e58b1e-2062-4650-800d-0e4c676582fb") },
                    { new Guid("157e2fa1-048a-4a44-a374-d11986a91ba3"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek B", new Guid("750169ef-b563-4728-8148-f1eacc4b55ca") },
                    { new Guid("15ebd766-737e-434d-ad51-ca2fa9b6d2dd"), false, "A", 1, "Hücre - Soru 2 için Seçenek A", new Guid("b1e58b1e-2062-4650-800d-0e4c676582fb") },
                    { new Guid("173a60c8-1a0e-4131-9d88-8ac7bc7512cb"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 4 için Seçenek B", new Guid("94e3594e-acf5-4e31-97d1-721d2f5f33c1") },
                    { new Guid("17648a29-4dad-4516-880b-24fdd81fcaa5"), false, "C", 3, "Problemler - Soru 1 için Seçenek C", new Guid("d7b8f9eb-96f3-43f3-8790-fb9823aeb66e") },
                    { new Guid("18022145-5f1f-4cea-bbf6-db30e2acf467"), false, "C", 3, "Rasyonel Sayılar - Soru 4 için Seçenek C", new Guid("1aea283e-c697-471c-b66f-999505c7a5ba") },
                    { new Guid("189e13cb-0927-42ed-ba98-19267ea1d611"), false, "B", 2, "Kuvvet ve Hareket - Soru 4 için Seçenek B", new Guid("5e8bc480-927f-436e-86d4-59cc9d8e35df") },
                    { new Guid("1b35e45e-b3dc-4add-8965-d6baf750d7f1"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek C", new Guid("d9323b94-9cc2-42d4-ab2d-04229adf7a12") },
                    { new Guid("1b77c960-ea92-4857-be9c-f4335bcef981"), false, "D", 4, "İş, Güç ve Enerji - Soru 4 için Seçenek D", new Guid("5d347e47-044f-4374-85ce-6418cff5d776") },
                    { new Guid("1cdbb75f-e15d-431e-8644-4a3e61fac60f"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek B", new Guid("da393945-d792-40a1-9f60-8b370de5f8e0") },
                    { new Guid("1dcfc051-1841-49fe-b0ae-8380d4aea274"), false, "C", 3, "Madde ve Özellikleri - Soru 2 için Seçenek C", new Guid("b0e0c6c6-3ad5-4d45-b44d-c5162208bb31") },
                    { new Guid("1faf070b-ff23-4299-a895-35e75fc52c53"), true, "A", 1, "Canlıların Sınıflandırılması - Soru 2 için Seçenek A", new Guid("3745bdb8-22e6-4779-a0c8-dd5bdbb054cd") },
                    { new Guid("205a7d79-5810-4345-8333-e067ad06d812"), false, "D", 4, "Maddenin Halleri - Soru 2 için Seçenek D", new Guid("63a6462d-6a4a-4ec8-93ed-1460d0d0e033") },
                    { new Guid("21240246-38af-4eaa-811d-5adb60917310"), false, "D", 4, "Bölme ve Bölünebilme - Soru 2 için Seçenek D", new Guid("a2093370-bf69-454f-87f3-3fcab98a64aa") },
                    { new Guid("21b132c0-5287-4b92-aee4-cf68da596d85"), false, "B", 2, "Bölme ve Bölünebilme - Soru 1 için Seçenek B", new Guid("1850bfe5-ab6c-4b68-86f0-cc682b3e3314") },
                    { new Guid("22b92348-c9d4-4ae2-a189-f93bea5fa72a"), false, "C", 3, "Elektrostatik - Soru 1 için Seçenek C", new Guid("fb79a2f8-3db4-4244-9b55-2dd710baf3b8") },
                    { new Guid("22be930e-7d92-4f7d-8f72-9e61a82d2238"), true, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek B", new Guid("9fd8e2c4-c2d1-4288-a4c3-73bbff56a41c") },
                    { new Guid("241f2625-add5-44e7-a45b-35c56c5a3e0d"), false, "C", 3, "Elektrostatik - Soru 2 için Seçenek C", new Guid("df4e67d5-28ae-4fa0-a3c9-06d9677a9642") },
                    { new Guid("2432c5a3-da09-4649-83a9-4a269e943145"), false, "C", 3, "Bölme ve Bölünebilme - Soru 5 için Seçenek C", new Guid("a2dfd7da-88bb-4857-b28d-fab1117579d8") },
                    { new Guid("259cdda3-60ba-4c6e-aa29-13fe836319fa"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 3 için Seçenek B", new Guid("50cfd01f-4fbb-4321-9c81-fe5ebd6e6aa1") },
                    { new Guid("26da810c-cc72-49ca-8664-17d745632b07"), true, "D", 4, "Kuvvet ve Hareket - Soru 1 için Seçenek D", new Guid("3682b943-54bd-466f-b2ca-8c6ca0917b15") },
                    { new Guid("272b7575-59bd-4085-895b-ebc5772e9f85"), false, "D", 4, "Madde ve Özellikleri - Soru 3 için Seçenek D", new Guid("5683a9bb-caf6-4987-bb89-994081b8cf25") },
                    { new Guid("2731ece6-050d-415a-bd35-46f3a8f4cd18"), true, "C", 3, "Sayı Basamakları - Soru 1 için Seçenek C", new Guid("a0d0e01a-6611-4be7-9e7f-16bb90db2aa8") },
                    { new Guid("2787470e-33ee-487e-821b-bdabe9ef49e5"), true, "C", 3, "Bölme ve Bölünebilme - Soru 1 için Seçenek C", new Guid("1850bfe5-ab6c-4b68-86f0-cc682b3e3314") },
                    { new Guid("27a2e37e-0ed9-4876-ab6b-16c8c473ec69"), false, "C", 3, "Kuvvet ve Hareket - Soru 3 için Seçenek C", new Guid("dd961e5e-fa2c-492f-838a-34555569d151") },
                    { new Guid("2963c0e0-5ebf-48cd-8f61-1649c6c40e26"), false, "C", 3, "Temel Kavramlar - Soru 3 için Seçenek C", new Guid("3f0f6a73-f1de-4455-9aec-3d19cb1b5556") },
                    { new Guid("2afb779b-b385-4073-a257-b9e2c6c28d49"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek A", new Guid("d9323b94-9cc2-42d4-ab2d-04229adf7a12") },
                    { new Guid("2b795752-9fbd-43a9-8b2e-d739b32c6d25"), false, "A", 1, "Kuvvet ve Hareket - Soru 3 için Seçenek A", new Guid("dd961e5e-fa2c-492f-838a-34555569d151") },
                    { new Guid("2c04c945-178c-4eca-9bb5-61985e5c1104"), true, "D", 4, "Rasyonel Sayılar - Soru 3 için Seçenek D", new Guid("68166f19-c9af-445f-93e2-517db463cd9c") },
                    { new Guid("2d46225e-e104-4415-95f6-fa49b5d8fe95"), false, "D", 4, "Kalıtım - Soru 1 için Seçenek D", new Guid("6de0cbfb-1143-46af-9fbb-3646bba0dd1a") },
                    { new Guid("2dc0a63b-13bf-40e1-bea2-3823954cc713"), true, "B", 2, "Problemler - Soru 2 için Seçenek B", new Guid("2bca2c45-8d41-4026-855e-296f3233e926") },
                    { new Guid("3095da73-844d-4f0b-8aca-61817d29097f"), true, "D", 4, "Fizik Bilimine Giriş - Soru 3 için Seçenek D", new Guid("668cbdfb-7d41-4167-838c-44f772a79544") },
                    { new Guid("30d84fc7-43bf-43fc-a8bc-fc600f1afe48"), false, "D", 4, "Bölme ve Bölünebilme - Soru 5 için Seçenek D", new Guid("a2dfd7da-88bb-4857-b28d-fab1117579d8") },
                    { new Guid("32b7732e-f0a0-481b-9c57-92d8b28a6e79"), true, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek C", new Guid("1c941f8d-e706-41fe-9006-94848ffa1bdd") },
                    { new Guid("33532e00-b776-43e3-b452-7d693c6652a6"), false, "D", 4, "Madde ve Özellikleri - Soru 2 için Seçenek D", new Guid("b0e0c6c6-3ad5-4d45-b44d-c5162208bb31") },
                    { new Guid("335732ec-64fa-4afa-8cea-7626b53ea471"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek C", new Guid("0b1dffb9-5249-4061-96e0-9123d73b4f2d") },
                    { new Guid("335b470f-48ae-4bd7-824d-09c307b48479"), false, "B", 2, "Problemler - Soru 4 için Seçenek B", new Guid("7fc23d4e-0206-42c9-b5eb-da8afad36d3f") },
                    { new Guid("33877dbc-069e-4f4f-9668-4f5041fa435d"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek A", new Guid("c9fe6527-0b56-4384-80fb-bdf1affea992") },
                    { new Guid("34418486-d2d2-4b01-be0f-a00f425c096d"), false, "A", 1, "Kuvvet ve Hareket - Soru 1 için Seçenek A", new Guid("3682b943-54bd-466f-b2ca-8c6ca0917b15") },
                    { new Guid("346cd287-ddd9-4224-bebf-a31afb1e4c9f"), false, "C", 3, "Fizik Bilimine Giriş - Soru 2 için Seçenek C", new Guid("0ebcf967-c56f-44fc-81d6-6b7ac8caabe7") },
                    { new Guid("34adabbf-31b6-43ff-9c88-612d235637a5"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek D", new Guid("da393945-d792-40a1-9f60-8b370de5f8e0") },
                    { new Guid("34f7f135-e05a-4fc5-8832-a2a64a1b858d"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 4 için Seçenek A", new Guid("111e2df0-41f5-4333-87db-fcef64f296df") },
                    { new Guid("35251f7f-9d6a-4b37-8a80-02f204160ce0"), false, "A", 1, "Rasyonel Sayılar - Soru 2 için Seçenek A", new Guid("49525d08-2e08-44d6-99fb-e92f7f112a28") },
                    { new Guid("38ddc0de-04a5-4adf-899f-85407451fb5e"), false, "D", 4, "Temel Kavramlar - Soru 2 için Seçenek D", new Guid("4fc6d20a-c87f-46d1-b7f4-ca6528eedc7e") },
                    { new Guid("39192b07-8815-46c7-a5ea-352e0759296e"), false, "C", 3, "Bölme ve Bölünebilme - Soru 2 için Seçenek C", new Guid("a2093370-bf69-454f-87f3-3fcab98a64aa") },
                    { new Guid("3a0ae370-8337-4c7b-a8b6-fcbd1348e287"), true, "C", 3, "Hücre - Soru 5 için Seçenek C", new Guid("b2969742-7a87-499a-9963-13092055afe2") },
                    { new Guid("3a8186a0-1127-4748-b97c-9e4274f5ea98"), false, "B", 2, "Rasyonel Sayılar - Soru 3 için Seçenek B", new Guid("68166f19-c9af-445f-93e2-517db463cd9c") },
                    { new Guid("3affdfae-9cac-4fa0-9b33-daebdbaf547a"), false, "A", 1, "Fizik Bilimine Giriş - Soru 2 için Seçenek A", new Guid("0ebcf967-c56f-44fc-81d6-6b7ac8caabe7") },
                    { new Guid("3b0153f6-cfd8-44e9-9bd3-8d7ecffc5003"), true, "B", 2, "Hücre Bölünmeleri - Soru 1 için Seçenek B", new Guid("eeb9ff3e-ff4b-4b86-b3b5-e168ba8dbca4") },
                    { new Guid("3c559ef5-8f08-4a7d-9dc8-b5252dad88bf"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 1 için Seçenek C", new Guid("c2c1dab2-08ec-49b3-a9de-e83057920864") },
                    { new Guid("3c9d549f-21cc-4b7b-af5e-ceb88b911feb"), false, "D", 4, "Hücre - Soru 1 için Seçenek D", new Guid("54d7f16c-cefb-447b-9145-cb69831e416f") },
                    { new Guid("3dac151a-5c40-4483-a437-83d72668ff9c"), false, "B", 2, "Sayı Basamakları - Soru 2 için Seçenek B", new Guid("2a798d7f-98f8-42f7-bb54-3bcadda4c9a9") },
                    { new Guid("3dadf9b1-eadc-4b95-8c00-8b2b5baccdfe"), true, "A", 1, "Kimya Bilimi - Soru 5 için Seçenek A", new Guid("c29858a6-8bfa-4934-a5dc-cd203b47e5b5") },
                    { new Guid("3e4105f7-3293-4f35-aa96-589d84ef03d9"), false, "D", 4, "Fizik Bilimine Giriş - Soru 5 için Seçenek D", new Guid("62bdc1aa-777b-48b9-b2f3-25d6ae8c0a90") },
                    { new Guid("3e9f8aea-99c2-43fb-80c8-220c18e69d6c"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 3 için Seçenek D", new Guid("50cfd01f-4fbb-4321-9c81-fe5ebd6e6aa1") },
                    { new Guid("3f2c429a-67ae-4c24-a67c-d95715964e42"), false, "C", 3, "Sayı Basamakları - Soru 3 için Seçenek C", new Guid("9d4e6ea4-5aa3-46d5-a1dc-f6ebab4ab3f9") },
                    { new Guid("3f608cd0-a040-4617-883b-30be29f70e28"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek A", new Guid("1c941f8d-e706-41fe-9006-94848ffa1bdd") },
                    { new Guid("3fe1a515-f292-4563-a6dd-a1c20418261f"), false, "C", 3, "Hücre - Soru 1 için Seçenek C", new Guid("54d7f16c-cefb-447b-9145-cb69831e416f") },
                    { new Guid("40d3d096-b2dd-4c14-af33-ad01e8fb978c"), false, "A", 1, "Fizik Bilimine Giriş - Soru 3 için Seçenek A", new Guid("668cbdfb-7d41-4167-838c-44f772a79544") },
                    { new Guid("41980545-da69-4ed2-84fa-310d1c215768"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek B", new Guid("dcc9b02f-2375-4ca7-bc3c-cc0ebea391d8") },
                    { new Guid("42122443-d53e-452e-a8f9-0912f3a2bf19"), false, "C", 3, "Rasyonel Sayılar - Soru 3 için Seçenek C", new Guid("68166f19-c9af-445f-93e2-517db463cd9c") },
                    { new Guid("43c10e06-2336-446c-b214-c95abc267e83"), false, "B", 2, "Madde ve Özellikleri - Soru 2 için Seçenek B", new Guid("b0e0c6c6-3ad5-4d45-b44d-c5162208bb31") },
                    { new Guid("45372e2e-3379-4909-bdcc-8a61ee29e138"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek C", new Guid("56a2e950-7f57-4a0d-92e8-1fd534fcb849") },
                    { new Guid("4678f27b-496e-4850-8fed-6b0f9080c136"), false, "A", 1, "Sayı Basamakları - Soru 4 için Seçenek A", new Guid("ef395918-4257-4105-843f-516a9c4e255f") },
                    { new Guid("47c3a4f6-28ee-4f96-a6f7-d1cd1cd32d18"), false, "A", 1, "Kalıtım - Soru 5 için Seçenek A", new Guid("de582186-208a-4968-9c29-5821e90f6b3a") },
                    { new Guid("47cce8ea-f984-462f-b207-b97546d28ef7"), true, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek A", new Guid("12a60e09-fafa-4b18-8fbc-710b63e4635c") },
                    { new Guid("47f3f922-a18a-42e9-b951-5b5d6b0aff00"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek D", new Guid("9fd8e2c4-c2d1-4288-a4c3-73bbff56a41c") },
                    { new Guid("48191b41-a947-4873-b5ff-e6593067d0dc"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 4 için Seçenek D", new Guid("111e2df0-41f5-4333-87db-fcef64f296df") },
                    { new Guid("48d43e96-5c99-48d5-9fdb-057741355557"), false, "D", 4, "Rasyonel Sayılar - Soru 1 için Seçenek D", new Guid("e9d7959b-ea2b-4e02-bdbe-a6f82dffbfea") },
                    { new Guid("49040592-3dfc-4577-ac7f-367754f3e1b7"), false, "D", 4, "Elektrostatik - Soru 3 için Seçenek D", new Guid("272cd872-2855-453a-b83d-fa6a19746551") },
                    { new Guid("491dc69b-0011-43c3-afd6-8eacd447241d"), true, "C", 3, "Hücre Bölünmeleri - Soru 5 için Seçenek C", new Guid("60e69b57-3a09-4c44-ad4e-631a19e5fae8") },
                    { new Guid("4996f65b-a731-4f3d-87c8-c033ad0ed81a"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek C", new Guid("b0115b2a-1b83-4569-8589-09f1a93ef3bf") },
                    { new Guid("49a70c57-efd8-47f0-82a4-cd8ed2ab7cca"), false, "A", 1, "Kalıtım - Soru 4 için Seçenek A", new Guid("a2b19c3d-bf9e-4d2c-8efc-aaab45c8aa2a") },
                    { new Guid("49f96567-b87b-43bc-ae28-11d934d94455"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek D", new Guid("1bd4563d-fc43-461f-864b-6f03ab948f40") },
                    { new Guid("4a500597-771c-4af5-a88f-e8018db7438c"), false, "D", 4, "Madde ve Özellikleri - Soru 1 için Seçenek D", new Guid("1833a3b0-acfc-49ad-a0a1-20c6b9131936") },
                    { new Guid("4b4c0bda-ed32-40f1-a65f-e3e5b9dc59b2"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek B", new Guid("5ef1dabf-749e-4adb-a496-12f3b7b873fb") },
                    { new Guid("4b6a3f12-2ad7-4f0b-98c4-e75876872c4e"), true, "B", 2, "Maddenin Halleri - Soru 5 için Seçenek B", new Guid("6f59e3e8-733c-4a8d-ba63-d387d21de047") },
                    { new Guid("4c097598-b2f0-4e09-ac1b-3e2f45ed5e1d"), false, "C", 3, "Kuvvet ve Hareket - Soru 5 için Seçenek C", new Guid("6012e350-d7ac-40c2-baad-7b62cd8c74d2") },
                    { new Guid("4c82f2a5-a289-4bce-850d-c3163c9ac7c8"), true, "B", 2, "Hücre - Soru 3 için Seçenek B", new Guid("79505962-817f-4e44-9a9b-9cc47ea15e08") },
                    { new Guid("4c9227eb-83a8-4a9e-9573-f197bb534a57"), false, "B", 2, "Hücre - Soru 4 için Seçenek B", new Guid("7962ee2c-1e38-4a0e-8115-0513bfb3a9fa") },
                    { new Guid("4e301359-c3f1-41e4-9e01-bd60d386f951"), true, "A", 1, "Bölme ve Bölünebilme - Soru 5 için Seçenek A", new Guid("a2dfd7da-88bb-4857-b28d-fab1117579d8") },
                    { new Guid("4e76bb07-b305-42b2-86da-910b20bd1399"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek D", new Guid("c9fe6527-0b56-4384-80fb-bdf1affea992") },
                    { new Guid("4f640b3a-55d9-4629-a6e3-78e42de00deb"), false, "D", 4, "Kuvvet ve Hareket - Soru 2 için Seçenek D", new Guid("6291bbca-372e-4d2a-b882-6209da83eee2") },
                    { new Guid("4f9eb4de-fb6f-41c2-9eb1-3eebdf525f78"), false, "D", 4, "Hücre Bölünmeleri - Soru 5 için Seçenek D", new Guid("60e69b57-3a09-4c44-ad4e-631a19e5fae8") },
                    { new Guid("518e8d6b-969c-4f10-8b7e-dc9ed38057c4"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 2 için Seçenek A", new Guid("fc85032b-3b13-492c-adc2-3b1d6ca784de") },
                    { new Guid("51be4c62-1433-4a8a-92ff-465380913b6b"), false, "C", 3, "Problemler - Soru 4 için Seçenek C", new Guid("7fc23d4e-0206-42c9-b5eb-da8afad36d3f") },
                    { new Guid("524ea549-2811-490e-8774-cf717b669a02"), false, "B", 2, "Elektrostatik - Soru 4 için Seçenek B", new Guid("12712761-80a7-49ad-88ee-d34b7fd7905a") },
                    { new Guid("52eba2cf-adf7-47ac-a3a1-1a10994ae0db"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek D", new Guid("56a2e950-7f57-4a0d-92e8-1fd534fcb849") },
                    { new Guid("531ce8ad-0322-436c-a5e2-a5aa0928e07f"), false, "C", 3, "Hücre Bölünmeleri - Soru 2 için Seçenek C", new Guid("98a17f7a-7b57-476e-94a8-0e954be33448") },
                    { new Guid("53fec0f7-6fd7-4aa2-8b44-f046c00663a6"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek A", new Guid("b0115b2a-1b83-4569-8589-09f1a93ef3bf") },
                    { new Guid("554fb445-d90a-49d9-bd1c-01674bfd17d5"), false, "D", 4, "Kuvvet ve Hareket - Soru 5 için Seçenek D", new Guid("6012e350-d7ac-40c2-baad-7b62cd8c74d2") },
                    { new Guid("5552575a-34bb-4188-aaa9-22420039fa97"), false, "A", 1, "Kuvvet ve Hareket - Soru 2 için Seçenek A", new Guid("6291bbca-372e-4d2a-b882-6209da83eee2") },
                    { new Guid("56a7a59f-e691-416e-979d-06e675bee938"), false, "C", 3, "Maddenin Halleri - Soru 1 için Seçenek C", new Guid("19bf3cb1-5dfd-42aa-aa23-c844dc10b5fc") },
                    { new Guid("5799d58b-a690-41d2-9b19-c99ade7b1122"), true, "C", 3, "İş, Güç ve Enerji - Soru 2 için Seçenek C", new Guid("33e27efe-9709-49b6-8513-8f5d26b39e2b") },
                    { new Guid("59612ff0-de37-4830-8957-4d4a95373013"), false, "B", 2, "Maddenin Halleri - Soru 1 için Seçenek B", new Guid("19bf3cb1-5dfd-42aa-aa23-c844dc10b5fc") },
                    { new Guid("596ff526-174b-4c29-9898-d0a4a6861849"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek D", new Guid("c00b19f0-d671-426a-b179-96bf1ad403e8") },
                    { new Guid("59bdffdc-4073-48cb-9f5e-09136db9db13"), false, "A", 1, "Temel Kavramlar - Soru 2 için Seçenek A", new Guid("4fc6d20a-c87f-46d1-b7f4-ca6528eedc7e") },
                    { new Guid("59c40b02-1285-455f-af43-c2da97ce9d6c"), false, "B", 2, "Kalıtım - Soru 5 için Seçenek B", new Guid("de582186-208a-4968-9c29-5821e90f6b3a") },
                    { new Guid("5a76d980-6ade-451b-a44e-b72f9b155b89"), true, "D", 4, "Hücre - Soru 2 için Seçenek D", new Guid("b1e58b1e-2062-4650-800d-0e4c676582fb") },
                    { new Guid("5b0a3e19-23b2-4acd-a988-4dba72f63e9d"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 2 için Seçenek B", new Guid("3745bdb8-22e6-4779-a0c8-dd5bdbb054cd") },
                    { new Guid("5bb29303-650b-4812-8be6-dabef9dd2b08"), false, "C", 3, "Temel Kavramlar - Soru 2 için Seçenek C", new Guid("4fc6d20a-c87f-46d1-b7f4-ca6528eedc7e") },
                    { new Guid("5c0dc9f1-cea6-4fda-8f8c-b4ced581257f"), true, "B", 2, "Kimya Bilimi - Soru 1 için Seçenek B", new Guid("c7653c3f-0479-48a8-b511-a96c57d950fb") },
                    { new Guid("5cd113c1-fc36-4718-b467-fd7c15b2cf83"), false, "A", 1, "Kimya Bilimi - Soru 3 için Seçenek A", new Guid("c40af7c1-d0d1-47c6-90ec-40e23fa66eab") },
                    { new Guid("5d10a0ec-0aad-4773-8261-c3265f56aaf1"), true, "A", 1, "Madde ve Özellikleri - Soru 1 için Seçenek A", new Guid("1833a3b0-acfc-49ad-a0a1-20c6b9131936") },
                    { new Guid("5d42dd41-f220-4804-a872-40aa636235dc"), true, "C", 3, "Bölme ve Bölünebilme - Soru 3 için Seçenek C", new Guid("b14f8f39-a9ac-4336-9202-e8400545dffb") },
                    { new Guid("5e5d7fda-9c2c-4b70-ba17-0876a2c4e37f"), false, "A", 1, "Sayı Basamakları - Soru 3 için Seçenek A", new Guid("9d4e6ea4-5aa3-46d5-a1dc-f6ebab4ab3f9") },
                    { new Guid("5ece5f5d-eaad-480e-93aa-02334fb333d9"), false, "D", 4, "Fizik Bilimine Giriş - Soru 1 için Seçenek D", new Guid("abe12dd3-83da-4f9a-acfb-0d0fbdf444b0") },
                    { new Guid("61852493-4766-4d96-b6ad-caff5863e1d9"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek D", new Guid("dcc9b02f-2375-4ca7-bc3c-cc0ebea391d8") },
                    { new Guid("61ec3db2-acf1-43e0-a617-cc71844c2660"), false, "C", 3, "Bölme ve Bölünebilme - Soru 4 için Seçenek C", new Guid("70429a32-1a49-4e38-914a-cd90c052e877") },
                    { new Guid("62c17c0a-dd0a-4cb9-88c4-531c654463d2"), false, "C", 3, "Sayı Basamakları - Soru 2 için Seçenek C", new Guid("2a798d7f-98f8-42f7-bb54-3bcadda4c9a9") },
                    { new Guid("6345960b-7e6f-42d9-8fa1-c745cdc8746f"), false, "C", 3, "Problemler - Soru 5 için Seçenek C", new Guid("8042bdd9-76e1-4650-8036-758b438c1a47") },
                    { new Guid("645e8001-dda4-48c3-a5be-07edf671bc01"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 5 için Seçenek B", new Guid("8d3a1978-3fda-46af-ab3e-a2436778503d") },
                    { new Guid("64643b4f-1fa4-48e8-91f3-a3393d8d23f8"), true, "D", 4, "Temel Kavramlar - Soru 1 için Seçenek D", new Guid("fab166d3-493b-4ddd-8234-bc443f0e61e7") },
                    { new Guid("649664f0-4057-409a-9690-2cb9d4b60fbf"), true, "C", 3, "Kalıtım - Soru 3 için Seçenek C", new Guid("ec8a69b0-be13-45f3-9f24-a4d57d5e3461") },
                    { new Guid("65ddabb6-7067-4db0-acae-4a18c15d3a02"), false, "C", 3, "İş, Güç ve Enerji - Soru 5 için Seçenek C", new Guid("f70f0e4c-c6f0-4996-9b14-63fba55009c8") },
                    { new Guid("661dcb07-80c0-49b0-9440-71b8c771a226"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 3 için Seçenek D", new Guid("6d5c434a-9f4e-4474-bef5-376404305829") },
                    { new Guid("66417a24-7783-4970-8d37-bcd22c571a09"), false, "A", 1, "Elektrostatik - Soru 3 için Seçenek A", new Guid("272cd872-2855-453a-b83d-fa6a19746551") },
                    { new Guid("680eef17-958c-41f8-898a-2f6f9ceee029"), false, "A", 1, "Problemler - Soru 3 için Seçenek A", new Guid("710c4853-713e-42e4-8c9f-5f57cdd0d12c") },
                    { new Guid("68925101-b378-496e-8e26-bed9a60fa4e7"), false, "B", 2, "Kimya Bilimi - Soru 5 için Seçenek B", new Guid("c29858a6-8bfa-4934-a5dc-cd203b47e5b5") },
                    { new Guid("692daedd-3c5c-460f-986f-6f5febd08ab7"), false, "A", 1, "Temel Kavramlar - Soru 4 için Seçenek A", new Guid("de5a80c6-b26c-4aab-86c7-0d2c5065b444") },
                    { new Guid("6a959c20-01a1-4d5d-8a6a-3908ff852e9b"), true, "C", 3, "İş, Güç ve Enerji - Soru 4 için Seçenek C", new Guid("5d347e47-044f-4374-85ce-6418cff5d776") },
                    { new Guid("6ac178d4-d675-4333-8486-e969ebb7491f"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek A", new Guid("dcc9b02f-2375-4ca7-bc3c-cc0ebea391d8") },
                    { new Guid("6aed38d0-6290-4396-af46-af7f75a148c6"), false, "C", 3, "Maddenin Halleri - Soru 5 için Seçenek C", new Guid("6f59e3e8-733c-4a8d-ba63-d387d21de047") },
                    { new Guid("6c157cc5-ad3f-4510-bc54-367a768510ab"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek C", new Guid("1bd4563d-fc43-461f-864b-6f03ab948f40") },
                    { new Guid("6cbfbaf2-0985-40d9-8e2c-1929e55c37e9"), true, "B", 2, "Kalıtım - Soru 1 için Seçenek B", new Guid("6de0cbfb-1143-46af-9fbb-3646bba0dd1a") },
                    { new Guid("6cea2738-5a5b-4ff3-b589-19cabec492ba"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 4 için Seçenek D", new Guid("94e3594e-acf5-4e31-97d1-721d2f5f33c1") },
                    { new Guid("6dee413c-d424-43e7-b5c6-63b76e21b538"), false, "D", 4, "Maddenin Halleri - Soru 5 için Seçenek D", new Guid("6f59e3e8-733c-4a8d-ba63-d387d21de047") },
                    { new Guid("6e13cc4f-53d1-40c2-a677-3d831e564801"), false, "B", 2, "Madde ve Özellikleri - Soru 3 için Seçenek B", new Guid("5683a9bb-caf6-4987-bb89-994081b8cf25") },
                    { new Guid("6e5304a3-6952-416b-831b-15edd593b608"), false, "D", 4, "Kimya Bilimi - Soru 3 için Seçenek D", new Guid("c40af7c1-d0d1-47c6-90ec-40e23fa66eab") },
                    { new Guid("6e7368bd-332b-40d6-bc22-ce71e166a6ad"), false, "A", 1, "Hücre Bölünmeleri - Soru 5 için Seçenek A", new Guid("60e69b57-3a09-4c44-ad4e-631a19e5fae8") },
                    { new Guid("6eed1693-5c85-4fe6-94bd-ba5a04616279"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek D", new Guid("d9323b94-9cc2-42d4-ab2d-04229adf7a12") },
                    { new Guid("6f91e1cc-d2cb-4186-8d60-bc2159984597"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 5 için Seçenek D", new Guid("8d3a1978-3fda-46af-ab3e-a2436778503d") },
                    { new Guid("702707c6-1fab-423f-a79d-a336c6413895"), false, "C", 3, "İş, Güç ve Enerji - Soru 1 için Seçenek C", new Guid("670f083d-c8b5-4e08-8cee-9b74d21b57da") },
                    { new Guid("714e3bcd-39f1-4ce9-951a-b46c79014067"), false, "B", 2, "Hücre Bölünmeleri - Soru 5 için Seçenek B", new Guid("60e69b57-3a09-4c44-ad4e-631a19e5fae8") },
                    { new Guid("715045c2-6b05-4123-a9ef-0527b9f27160"), false, "A", 1, "Elektrostatik - Soru 1 için Seçenek A", new Guid("fb79a2f8-3db4-4244-9b55-2dd710baf3b8") },
                    { new Guid("72c8b98f-1281-466f-9017-320693e1f28f"), false, "B", 2, "Bölme ve Bölünebilme - Soru 5 için Seçenek B", new Guid("a2dfd7da-88bb-4857-b28d-fab1117579d8") },
                    { new Guid("73bd5e8c-665e-4774-86bf-835dbb17f323"), false, "D", 4, "Madde ve Özellikleri - Soru 5 için Seçenek D", new Guid("c7ed1a4a-0345-4f00-93d1-bd5b808b6348") },
                    { new Guid("7442a565-eebf-4cde-84e5-35cedd4a6415"), false, "D", 4, "Rasyonel Sayılar - Soru 4 için Seçenek D", new Guid("1aea283e-c697-471c-b66f-999505c7a5ba") },
                    { new Guid("752ed924-2e0a-41ea-bb01-bae18750e7b8"), false, "A", 1, "Maddenin Halleri - Soru 5 için Seçenek A", new Guid("6f59e3e8-733c-4a8d-ba63-d387d21de047") },
                    { new Guid("773c5833-1ea1-4b11-9e7d-65f20c6fdf89"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 3 için Seçenek C", new Guid("6d5c434a-9f4e-4474-bef5-376404305829") },
                    { new Guid("77405fde-49d2-4322-a6dd-98526e06927f"), false, "D", 4, "Bölme ve Bölünebilme - Soru 3 için Seçenek D", new Guid("b14f8f39-a9ac-4336-9202-e8400545dffb") },
                    { new Guid("77b1e1f0-1e91-40e3-b630-355f3439c35f"), true, "D", 4, "Kalıtım - Soru 4 için Seçenek D", new Guid("a2b19c3d-bf9e-4d2c-8efc-aaab45c8aa2a") },
                    { new Guid("782a5ce0-dba5-4dc8-8078-ba53a4dbe0e8"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek D", new Guid("0b1dffb9-5249-4061-96e0-9123d73b4f2d") },
                    { new Guid("79b16e6c-e99d-48e6-895c-a130c5dc6536"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek C", new Guid("f035c3ec-dab4-4699-a92e-d6fad72c3fd9") },
                    { new Guid("7a598651-9e3b-4f18-a91a-346d18e9ae4f"), true, "B", 2, "Bölme ve Bölünebilme - Soru 4 için Seçenek B", new Guid("70429a32-1a49-4e38-914a-cd90c052e877") },
                    { new Guid("7a85b63a-5e58-4c28-9226-c1df43578023"), true, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek B", new Guid("f035c3ec-dab4-4699-a92e-d6fad72c3fd9") },
                    { new Guid("7aa24fb1-cdc9-4bf4-a58d-115f189a60e3"), false, "C", 3, "Kalıtım - Soru 1 için Seçenek C", new Guid("6de0cbfb-1143-46af-9fbb-3646bba0dd1a") },
                    { new Guid("7b068b35-22b8-4f15-beef-24f4beff45a1"), false, "C", 3, "Kalıtım - Soru 2 için Seçenek C", new Guid("3d6d8dfd-398e-4c80-b3e5-d9cbabc6ac58") },
                    { new Guid("7b5d4d66-3a32-4564-bcb4-249602b720d9"), false, "D", 4, "Hücre Bölünmeleri - Soru 1 için Seçenek D", new Guid("eeb9ff3e-ff4b-4b86-b3b5-e168ba8dbca4") },
                    { new Guid("7c808037-3afb-4c1d-b764-324f76c199fa"), true, "D", 4, "İş, Güç ve Enerji - Soru 5 için Seçenek D", new Guid("f70f0e4c-c6f0-4996-9b14-63fba55009c8") },
                    { new Guid("7c99240f-a049-4009-8aff-00ba332ae821"), false, "C", 3, "Kuvvet ve Hareket - Soru 2 için Seçenek C", new Guid("6291bbca-372e-4d2a-b882-6209da83eee2") },
                    { new Guid("7df9b5d2-8bba-4385-ab25-6d5452299599"), false, "D", 4, "Elektrostatik - Soru 4 için Seçenek D", new Guid("12712761-80a7-49ad-88ee-d34b7fd7905a") },
                    { new Guid("7f62dbe1-0079-4cd7-956c-0fd9b3b49d4e"), false, "C", 3, "Hücre Bölünmeleri - Soru 1 için Seçenek C", new Guid("eeb9ff3e-ff4b-4b86-b3b5-e168ba8dbca4") },
                    { new Guid("7fb22a6c-16b6-4b5a-981d-651b9c8483c5"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek B", new Guid("c9fe6527-0b56-4384-80fb-bdf1affea992") },
                    { new Guid("80cf9c3e-271d-4e98-82c0-0f0fa0a32a9d"), false, "A", 1, "İş, Güç ve Enerji - Soru 3 için Seçenek A", new Guid("c1a38e98-3787-4551-8569-2010d5ff61e8") },
                    { new Guid("813b3894-7b01-4b0c-9f5d-225bc1604eb6"), false, "C", 3, "Maddenin Halleri - Soru 3 için Seçenek C", new Guid("0923e78e-dd64-4a04-852f-b584f805955a") },
                    { new Guid("8160d2f6-635e-4f7f-a384-100d1db1d6d0"), false, "B", 2, "Problemler - Soru 3 için Seçenek B", new Guid("710c4853-713e-42e4-8c9f-5f57cdd0d12c") },
                    { new Guid("82e593d9-52a4-484d-95ec-f7ba75ffe8b2"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek B", new Guid("56a2e950-7f57-4a0d-92e8-1fd534fcb849") },
                    { new Guid("83280fa4-560a-427b-af60-99ad122ced62"), true, "A", 1, "Canlıların Sınıflandırılması - Soru 4 için Seçenek A", new Guid("94e3594e-acf5-4e31-97d1-721d2f5f33c1") },
                    { new Guid("83ac153e-e37a-47db-8621-831e2bfaa9db"), true, "D", 4, "Elektrostatik - Soru 5 için Seçenek D", new Guid("2bb9e157-de48-43d5-85aa-591d5ee6b06d") },
                    { new Guid("83db383c-d7f8-44b1-afc2-37251db89538"), false, "B", 2, "Problemler - Soru 1 için Seçenek B", new Guid("d7b8f9eb-96f3-43f3-8790-fb9823aeb66e") },
                    { new Guid("8443b8dd-b5c7-4877-b011-ec10ae8c4fd6"), false, "D", 4, "Bölme ve Bölünebilme - Soru 1 için Seçenek D", new Guid("1850bfe5-ab6c-4b68-86f0-cc682b3e3314") },
                    { new Guid("855d049b-2332-4416-a3f2-3317d663972e"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek D", new Guid("5ef1dabf-749e-4adb-a496-12f3b7b873fb") },
                    { new Guid("86a76a67-0aed-4b9e-a80d-ae9b9c7df035"), true, "B", 2, "Kuvvet ve Hareket - Soru 5 için Seçenek B", new Guid("6012e350-d7ac-40c2-baad-7b62cd8c74d2") },
                    { new Guid("8716f3fc-012f-4f5d-a0d5-3589fd0ccee4"), false, "B", 2, "Elektrostatik - Soru 5 için Seçenek B", new Guid("2bb9e157-de48-43d5-85aa-591d5ee6b06d") },
                    { new Guid("8778d55b-e2c4-45b0-aeaa-b091046ddfd0"), false, "D", 4, "Kalıtım - Soru 3 için Seçenek D", new Guid("ec8a69b0-be13-45f3-9f24-a4d57d5e3461") },
                    { new Guid("881426f1-3ee1-4f8f-9a90-2c0b11bf1607"), false, "D", 4, "İş, Güç ve Enerji - Soru 3 için Seçenek D", new Guid("c1a38e98-3787-4551-8569-2010d5ff61e8") },
                    { new Guid("88c0bcdb-b768-4c08-8121-c6dbeb4e12e6"), false, "D", 4, "Temel Kavramlar - Soru 3 için Seçenek D", new Guid("3f0f6a73-f1de-4455-9aec-3d19cb1b5556") },
                    { new Guid("89054095-51c3-4132-8fe2-4373d8c27c59"), false, "C", 3, "Hücre Bölünmeleri - Soru 4 için Seçenek C", new Guid("564b00e8-e0a0-4a6d-926f-f4f2049b44b5") },
                    { new Guid("899c8ff8-ab48-4b67-a91a-8a11f1fc314e"), true, "B", 2, "Maddenin Halleri - Soru 2 için Seçenek B", new Guid("63a6462d-6a4a-4ec8-93ed-1460d0d0e033") },
                    { new Guid("8a341310-a8b2-46af-a678-b8a2759e1aa6"), true, "C", 3, "Fizik Bilimine Giriş - Soru 4 için Seçenek C", new Guid("4bba942f-cddc-4e44-af3c-a18fe464e61d") },
                    { new Guid("8bc4666c-9244-495f-8ada-e1b9947ef4a6"), false, "B", 2, "Kimya Bilimi - Soru 2 için Seçenek B", new Guid("30245ea2-1640-48a5-aaf4-0b92aa95ab8d") },
                    { new Guid("8bcc093c-793c-402f-b1f4-03ed6c72ddf9"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 1 için Seçenek A", new Guid("c2c1dab2-08ec-49b3-a9de-e83057920864") },
                    { new Guid("8bdc2330-734b-47a7-9d67-979d4a959d48"), false, "A", 1, "Elektrostatik - Soru 5 için Seçenek A", new Guid("2bb9e157-de48-43d5-85aa-591d5ee6b06d") },
                    { new Guid("8be01144-358c-4184-80f8-f266427b13e8"), false, "D", 4, "Hücre - Soru 3 için Seçenek D", new Guid("79505962-817f-4e44-9a9b-9cc47ea15e08") },
                    { new Guid("8cb0d4ad-77c8-475b-a826-30c7812531a3"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek A", new Guid("1bd4563d-fc43-461f-864b-6f03ab948f40") },
                    { new Guid("8cb43274-18ef-4620-aed4-679d4502d48b"), false, "D", 4, "Problemler - Soru 1 için Seçenek D", new Guid("d7b8f9eb-96f3-43f3-8790-fb9823aeb66e") },
                    { new Guid("8d27537e-657f-4cba-820b-1901af7e1c7d"), false, "A", 1, "Problemler - Soru 2 için Seçenek A", new Guid("2bca2c45-8d41-4026-855e-296f3233e926") },
                    { new Guid("8d875f7f-56df-4c55-938a-408db164b060"), false, "C", 3, "Maddenin Halleri - Soru 4 için Seçenek C", new Guid("fb7df210-f7fb-4277-adf3-ae8feb89d8eb") },
                    { new Guid("8de526db-4980-4ae9-8ef3-cf71ab72649d"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek A", new Guid("f035c3ec-dab4-4699-a92e-d6fad72c3fd9") },
                    { new Guid("8de56699-80a4-494d-a54a-cf22bf913845"), true, "A", 1, "Kimya Bilimi - Soru 2 için Seçenek A", new Guid("30245ea2-1640-48a5-aaf4-0b92aa95ab8d") },
                    { new Guid("8df0f547-83e8-441e-a7b3-c5920aa5bce5"), false, "B", 2, "Temel Kavramlar - Soru 3 için Seçenek B", new Guid("3f0f6a73-f1de-4455-9aec-3d19cb1b5556") },
                    { new Guid("8df6699e-2816-45ea-958f-c92f878dc285"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek D", new Guid("b0115b2a-1b83-4569-8589-09f1a93ef3bf") },
                    { new Guid("8e92481d-7505-454b-ac43-4c9ac7cb4c20"), true, "B", 2, "Hücre - Soru 1 için Seçenek B", new Guid("54d7f16c-cefb-447b-9145-cb69831e416f") },
                    { new Guid("8ed4a1cf-2169-4aed-9b39-bfc5b7d0fa50"), false, "B", 2, "Bölme ve Bölünebilme - Soru 2 için Seçenek B", new Guid("a2093370-bf69-454f-87f3-3fcab98a64aa") },
                    { new Guid("8f0538ac-df94-4123-8531-43fa8782e26a"), false, "C", 3, "Maddenin Halleri - Soru 2 için Seçenek C", new Guid("63a6462d-6a4a-4ec8-93ed-1460d0d0e033") },
                    { new Guid("8fa9228a-e3e3-448b-afed-8fd4fafedf1e"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek B", new Guid("d9323b94-9cc2-42d4-ab2d-04229adf7a12") },
                    { new Guid("9056a9e4-de75-4895-8fc5-7b3901810126"), false, "B", 2, "Rasyonel Sayılar - Soru 1 için Seçenek B", new Guid("e9d7959b-ea2b-4e02-bdbe-a6f82dffbfea") },
                    { new Guid("905842cc-d560-48c4-98b3-a5654f7c0dc1"), false, "D", 4, "Kimya Bilimi - Soru 1 için Seçenek D", new Guid("c7653c3f-0479-48a8-b511-a96c57d950fb") },
                    { new Guid("905bff50-4e83-4520-b48e-1820f3cd04e9"), false, "C", 3, "Madde ve Özellikleri - Soru 1 için Seçenek C", new Guid("1833a3b0-acfc-49ad-a0a1-20c6b9131936") },
                    { new Guid("90c111a2-48f7-4b04-a59b-d62c384494cc"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek C", new Guid("c9fe6527-0b56-4384-80fb-bdf1affea992") },
                    { new Guid("91495d53-917d-4317-b35c-35458746146b"), true, "C", 3, "Rasyonel Sayılar - Soru 5 için Seçenek C", new Guid("10b4ab12-6b09-4beb-a746-75b995012ce2") },
                    { new Guid("928b5b24-1ae8-4309-bbe2-d6ce915051a6"), false, "C", 3, "Madde ve Özellikleri - Soru 4 için Seçenek C", new Guid("e82c0d52-24a7-4081-b742-f21421758182") },
                    { new Guid("92a8c5df-e87f-421c-bfeb-2b2deb979166"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek C", new Guid("750169ef-b563-4728-8148-f1eacc4b55ca") },
                    { new Guid("940f624d-8094-4745-a32f-a27b032d6653"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek B", new Guid("1c941f8d-e706-41fe-9006-94848ffa1bdd") },
                    { new Guid("94489adf-35b0-44db-8e33-11aa7a15c932"), true, "B", 2, "Kimya Bilimi - Soru 4 için Seçenek B", new Guid("1ea17762-47be-4e6a-944a-9e1b4919d3fa") },
                    { new Guid("947245e2-88d7-49a4-a162-2c750a5e1762"), false, "C", 3, "Elektrostatik - Soru 5 için Seçenek C", new Guid("2bb9e157-de48-43d5-85aa-591d5ee6b06d") },
                    { new Guid("94c4efab-67f6-47b4-8673-94f6474e5386"), true, "D", 4, "Sayı Basamakları - Soru 2 için Seçenek D", new Guid("2a798d7f-98f8-42f7-bb54-3bcadda4c9a9") },
                    { new Guid("95bcd2d9-13eb-428d-80c8-e5ba768cfe7f"), false, "A", 1, "Elektrostatik - Soru 4 için Seçenek A", new Guid("12712761-80a7-49ad-88ee-d34b7fd7905a") },
                    { new Guid("95d3b648-f64f-4136-bca2-a1c4faa76036"), false, "C", 3, "Temel Kavramlar - Soru 1 için Seçenek C", new Guid("fab166d3-493b-4ddd-8234-bc443f0e61e7") },
                    { new Guid("9635d7a3-a2ed-4e22-a6c6-75345853292a"), true, "B", 2, "Rasyonel Sayılar - Soru 4 için Seçenek B", new Guid("1aea283e-c697-471c-b66f-999505c7a5ba") },
                    { new Guid("97bc40a0-a2f7-4c9c-8a72-438652edf4ba"), false, "A", 1, "Temel Kavramlar - Soru 5 için Seçenek A", new Guid("97459954-555a-4bbd-98ec-79758393ec5c") },
                    { new Guid("98197d88-0d7d-4fa5-90f0-66ce2f3ca840"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 4 için Seçenek B", new Guid("111e2df0-41f5-4333-87db-fcef64f296df") },
                    { new Guid("9901e919-01f8-410a-a7f5-4cb956572738"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek D", new Guid("f035c3ec-dab4-4699-a92e-d6fad72c3fd9") },
                    { new Guid("99a54dc4-7f13-44b4-8a54-b4e7cebd8e34"), false, "D", 4, "Hücre Bölünmeleri - Soru 3 için Seçenek D", new Guid("2d13d538-0378-486c-9a45-dd51de764f40") },
                    { new Guid("99c3eee2-609f-4509-ad94-d98eb1500d47"), false, "D", 4, "Sayı Basamakları - Soru 1 için Seçenek D", new Guid("a0d0e01a-6611-4be7-9e7f-16bb90db2aa8") },
                    { new Guid("9a004899-1621-49f3-86be-59f01c4a9e42"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek C", new Guid("5ef1dabf-749e-4adb-a496-12f3b7b873fb") },
                    { new Guid("9a48186d-c401-49f5-a560-8d8611359851"), false, "A", 1, "Kuvvet ve Hareket - Soru 4 için Seçenek A", new Guid("5e8bc480-927f-436e-86d4-59cc9d8e35df") },
                    { new Guid("9a8b02c3-c0dc-4c99-a25f-e0da421b2df8"), true, "C", 3, "Kalıtım - Soru 5 için Seçenek C", new Guid("de582186-208a-4968-9c29-5821e90f6b3a") },
                    { new Guid("9a95e6f3-b40f-4b10-9e96-0a4ba9fdb5b4"), false, "B", 2, "Sayı Basamakları - Soru 1 için Seçenek B", new Guid("a0d0e01a-6611-4be7-9e7f-16bb90db2aa8") },
                    { new Guid("9ac9cc16-0d9d-4587-af68-48f501fa91c0"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek A", new Guid("9fd8e2c4-c2d1-4288-a4c3-73bbff56a41c") },
                    { new Guid("9b501446-0daa-485c-bc9f-d54fd7df884a"), false, "D", 4, "İş, Güç ve Enerji - Soru 2 için Seçenek D", new Guid("33e27efe-9709-49b6-8513-8f5d26b39e2b") },
                    { new Guid("9d5afdfc-4c18-453b-9443-e2a82f0458dd"), false, "B", 2, "Maddenin Halleri - Soru 3 için Seçenek B", new Guid("0923e78e-dd64-4a04-852f-b584f805955a") },
                    { new Guid("9d761919-a3c4-41cf-a30e-054c2a8294d0"), false, "C", 3, "Kimya Bilimi - Soru 1 için Seçenek C", new Guid("c7653c3f-0479-48a8-b511-a96c57d950fb") },
                    { new Guid("9de6a92e-d695-4f79-b6fc-0aa2a7c51fa3"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek A", new Guid("c00b19f0-d671-426a-b179-96bf1ad403e8") },
                    { new Guid("9e9beb17-8d25-442b-b445-3a5779886643"), false, "A", 1, "Bölme ve Bölünebilme - Soru 1 için Seçenek A", new Guid("1850bfe5-ab6c-4b68-86f0-cc682b3e3314") },
                    { new Guid("9ead4fe0-9b65-4b69-8a72-8052a7537f9f"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek C", new Guid("12a60e09-fafa-4b18-8fbc-710b63e4635c") },
                    { new Guid("9ec8c66e-bf6a-47de-8f2f-96606b573579"), false, "B", 2, "İş, Güç ve Enerji - Soru 2 için Seçenek B", new Guid("33e27efe-9709-49b6-8513-8f5d26b39e2b") },
                    { new Guid("9f415eff-2bd1-43ee-b511-fe4c0d7dd927"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 5 için Seçenek C", new Guid("a3a0ca6b-0b81-4a2a-9727-3c3795ad8ac2") },
                    { new Guid("9fa19659-4f65-4791-8f53-a7fc209446ba"), true, "A", 1, "Madde ve Özellikleri - Soru 2 için Seçenek A", new Guid("b0e0c6c6-3ad5-4d45-b44d-c5162208bb31") },
                    { new Guid("9ff4244c-8b2b-48bc-bbaf-d9990c767822"), false, "B", 2, "Fizik Bilimine Giriş - Soru 2 için Seçenek B", new Guid("0ebcf967-c56f-44fc-81d6-6b7ac8caabe7") },
                    { new Guid("a044bac4-638a-47b8-9cb6-604908aa4a0d"), false, "A", 1, "Bölme ve Bölünebilme - Soru 3 için Seçenek A", new Guid("b14f8f39-a9ac-4336-9202-e8400545dffb") },
                    { new Guid("a09b920f-0aa5-4baf-be3f-8dfefe46901b"), false, "A", 1, "Kimya Bilimi - Soru 1 için Seçenek A", new Guid("c7653c3f-0479-48a8-b511-a96c57d950fb") },
                    { new Guid("a0e6bcfa-65d5-4b2e-b401-c562ce8557be"), true, "D", 4, "Maddenin Halleri - Soru 4 için Seçenek D", new Guid("fb7df210-f7fb-4277-adf3-ae8feb89d8eb") },
                    { new Guid("a255bd66-89f3-4bf9-b2a8-1e21c0d73ef8"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 5 için Seçenek A", new Guid("8d3a1978-3fda-46af-ab3e-a2436778503d") },
                    { new Guid("a27a45c8-99e1-463d-9c92-14627f2a4a77"), true, "A", 1, "Maddenin Halleri - Soru 1 için Seçenek A", new Guid("19bf3cb1-5dfd-42aa-aa23-c844dc10b5fc") },
                    { new Guid("a2a11cd0-7c61-4d57-9afa-52f6d61dfe19"), false, "C", 3, "Hücre - Soru 3 için Seçenek C", new Guid("79505962-817f-4e44-9a9b-9cc47ea15e08") },
                    { new Guid("a2bdc4fc-d578-40b4-bb73-baf2cc70d5be"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 2 için Seçenek B", new Guid("fc85032b-3b13-492c-adc2-3b1d6ca784de") },
                    { new Guid("a2ca1a07-729f-4d6d-acee-1a5e13aa41dd"), false, "A", 1, "Hücre - Soru 4 için Seçenek A", new Guid("7962ee2c-1e38-4a0e-8115-0513bfb3a9fa") },
                    { new Guid("a33bc4a2-8521-4a31-97f1-bb5b0bf0210e"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek C", new Guid("da393945-d792-40a1-9f60-8b370de5f8e0") },
                    { new Guid("a4593f3c-8cb7-4ede-9b38-deea3c587e38"), false, "A", 1, "Hücre - Soru 1 için Seçenek A", new Guid("54d7f16c-cefb-447b-9145-cb69831e416f") },
                    { new Guid("a4b98796-23e0-4087-8215-896d2b964213"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 3 için Seçenek A", new Guid("50cfd01f-4fbb-4321-9c81-fe5ebd6e6aa1") },
                    { new Guid("a4d74429-5457-4f81-9856-67c459795997"), false, "A", 1, "Kuvvet ve Hareket - Soru 5 için Seçenek A", new Guid("6012e350-d7ac-40c2-baad-7b62cd8c74d2") },
                    { new Guid("a59e46fd-445a-4a47-98eb-93c92dc8f898"), false, "B", 2, "Bölme ve Bölünebilme - Soru 3 için Seçenek B", new Guid("b14f8f39-a9ac-4336-9202-e8400545dffb") },
                    { new Guid("a5dae962-f42e-4156-a412-edbdf3932550"), false, "B", 2, "Kuvvet ve Hareket - Soru 1 için Seçenek B", new Guid("3682b943-54bd-466f-b2ca-8c6ca0917b15") },
                    { new Guid("a65afd69-fbe1-4ab5-9445-60375b8842f8"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 2 için Seçenek D", new Guid("fc85032b-3b13-492c-adc2-3b1d6ca784de") },
                    { new Guid("a6d9c462-3d3b-4614-89ee-170f763bc6fe"), false, "B", 2, "İş, Güç ve Enerji - Soru 5 için Seçenek B", new Guid("f70f0e4c-c6f0-4996-9b14-63fba55009c8") },
                    { new Guid("a7094f99-ec6a-4ec0-a4ae-9120049923bd"), false, "A", 1, "Sayı Basamakları - Soru 1 için Seçenek A", new Guid("a0d0e01a-6611-4be7-9e7f-16bb90db2aa8") },
                    { new Guid("a7696794-80ac-437d-bc54-3fa9c82ef991"), true, "A", 1, "Temel Kavramlar - Soru 3 için Seçenek A", new Guid("3f0f6a73-f1de-4455-9aec-3d19cb1b5556") },
                    { new Guid("a8aa7eff-5441-49b6-9cf4-10130f53a5fe"), false, "D", 4, "Kimya Bilimi - Soru 2 için Seçenek D", new Guid("30245ea2-1640-48a5-aaf4-0b92aa95ab8d") },
                    { new Guid("a8d8e40c-79e0-4a08-a636-552fe6fec05d"), false, "D", 4, "Hücre Bölünmeleri - Soru 4 için Seçenek D", new Guid("564b00e8-e0a0-4a6d-926f-f4f2049b44b5") },
                    { new Guid("a8f0abd1-e2d6-44dd-96bc-b18bea1494ee"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek C", new Guid("dcc9b02f-2375-4ca7-bc3c-cc0ebea391d8") },
                    { new Guid("a94c5cdc-f125-4f59-8c4d-c51ea4f08443"), false, "D", 4, "Kimya Bilimi - Soru 4 için Seçenek D", new Guid("1ea17762-47be-4e6a-944a-9e1b4919d3fa") },
                    { new Guid("ab8e962f-ca74-4dd3-ac26-a89b736fc265"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek A", new Guid("0b1dffb9-5249-4061-96e0-9123d73b4f2d") },
                    { new Guid("ac4dc49a-7020-498e-9d93-50673a3a3b46"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek C", new Guid("9fd8e2c4-c2d1-4288-a4c3-73bbff56a41c") },
                    { new Guid("adc211dd-c444-4a41-acf9-c04ddba0e023"), false, "B", 2, "Maddenin Halleri - Soru 4 için Seçenek B", new Guid("fb7df210-f7fb-4277-adf3-ae8feb89d8eb") },
                    { new Guid("ae637d01-a924-430b-9ba7-54f0bffe199f"), false, "A", 1, "Hücre Bölünmeleri - Soru 1 için Seçenek A", new Guid("eeb9ff3e-ff4b-4b86-b3b5-e168ba8dbca4") },
                    { new Guid("af28a4b9-3e62-4c23-a32c-1e07a89c181c"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek B", new Guid("1bd4563d-fc43-461f-864b-6f03ab948f40") },
                    { new Guid("b0586735-2292-4a15-afdb-d3f3f781c529"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 4 için Seçenek C", new Guid("111e2df0-41f5-4333-87db-fcef64f296df") },
                    { new Guid("b1dd502d-7477-4ea2-ace7-334fc4a30ae2"), true, "A", 1, "Bölme ve Bölünebilme - Soru 2 için Seçenek A", new Guid("a2093370-bf69-454f-87f3-3fcab98a64aa") },
                    { new Guid("b44278c6-b4f8-4c11-8507-447e3e215f8e"), false, "D", 4, "Fizik Bilimine Giriş - Soru 4 için Seçenek D", new Guid("4bba942f-cddc-4e44-af3c-a18fe464e61d") },
                    { new Guid("b5e89ab3-12c1-4652-a343-51ccc9ad0361"), false, "A", 1, "Kalıtım - Soru 3 için Seçenek A", new Guid("ec8a69b0-be13-45f3-9f24-a4d57d5e3461") },
                    { new Guid("b694372d-4911-4860-b406-176f0964c3b0"), false, "B", 2, "Temel Kavramlar - Soru 1 için Seçenek B", new Guid("fab166d3-493b-4ddd-8234-bc443f0e61e7") },
                    { new Guid("b80d728d-c421-4534-9df8-7ee470baafb9"), false, "B", 2, "İş, Güç ve Enerji - Soru 1 için Seçenek B", new Guid("670f083d-c8b5-4e08-8cee-9b74d21b57da") },
                    { new Guid("b845a41b-1bfe-447c-9343-3431083b28d8"), false, "C", 3, "Rasyonel Sayılar - Soru 1 için Seçenek C", new Guid("e9d7959b-ea2b-4e02-bdbe-a6f82dffbfea") },
                    { new Guid("b86b856e-13bd-4e5d-96bc-a20c2746a38f"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek B", new Guid("b0115b2a-1b83-4569-8589-09f1a93ef3bf") },
                    { new Guid("b89e45fc-4f78-4bcc-8ca7-e17779c12da0"), false, "B", 2, "Elektrostatik - Soru 3 için Seçenek B", new Guid("272cd872-2855-453a-b83d-fa6a19746551") },
                    { new Guid("b9015d2d-c9b1-43a4-b5db-a0edef6a04f8"), false, "D", 4, "Kimya Bilimi - Soru 5 için Seçenek D", new Guid("c29858a6-8bfa-4934-a5dc-cd203b47e5b5") },
                    { new Guid("b9e86a52-2bb8-415c-9951-6bc0d1673b7b"), false, "C", 3, "Kalıtım - Soru 4 için Seçenek C", new Guid("a2b19c3d-bf9e-4d2c-8efc-aaab45c8aa2a") },
                    { new Guid("ba2d0989-bb38-46b8-b7e9-3f3f7d653001"), false, "D", 4, "Problemler - Soru 2 için Seçenek D", new Guid("2bca2c45-8d41-4026-855e-296f3233e926") },
                    { new Guid("bb08d337-0882-4ed0-b257-17dd28470f92"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 5 için Seçenek D", new Guid("a3a0ca6b-0b81-4a2a-9727-3c3795ad8ac2") },
                    { new Guid("bc952e8c-1b63-405b-9b0d-1fd759be08a5"), false, "A", 1, "Rasyonel Sayılar - Soru 4 için Seçenek A", new Guid("1aea283e-c697-471c-b66f-999505c7a5ba") },
                    { new Guid("bcf10b07-9982-4c00-aa67-b9f817cbc936"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 1 için Seçenek D", new Guid("79653cf9-5e61-49f9-967f-9f8e43f3e825") },
                    { new Guid("bef3efe1-aa7c-4360-9b48-2c0b62e4dbb6"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek D", new Guid("750169ef-b563-4728-8148-f1eacc4b55ca") },
                    { new Guid("bef77e5d-bf09-4d73-998d-1382578f9758"), false, "C", 3, "Sayı Basamakları - Soru 5 için Seçenek C", new Guid("9ea389a2-a8d3-48d1-81f3-286a0b94bf5a") },
                    { new Guid("bf9f3004-ea72-40d7-96cf-375cda788b36"), false, "B", 2, "Madde ve Özellikleri - Soru 1 için Seçenek B", new Guid("1833a3b0-acfc-49ad-a0a1-20c6b9131936") },
                    { new Guid("c0955528-b52e-4af1-b297-d827feee774e"), true, "B", 2, "İş, Güç ve Enerji - Soru 3 için Seçenek B", new Guid("c1a38e98-3787-4551-8569-2010d5ff61e8") },
                    { new Guid("c0b01f4a-d74d-4a78-9e94-6dddb7d0b0c1"), true, "C", 3, "Rasyonel Sayılar - Soru 2 için Seçenek C", new Guid("49525d08-2e08-44d6-99fb-e92f7f112a28") },
                    { new Guid("c1d64e5d-4204-4f90-be8b-ebb3639f9252"), false, "C", 3, "İş, Güç ve Enerji - Soru 3 için Seçenek C", new Guid("c1a38e98-3787-4551-8569-2010d5ff61e8") },
                    { new Guid("c3aa6592-180b-4ab1-8f05-e3188638c65a"), true, "C", 3, "Fizik Bilimine Giriş - Soru 5 için Seçenek C", new Guid("62bdc1aa-777b-48b9-b2f3-25d6ae8c0a90") },
                    { new Guid("c3fc57ed-5873-45d1-8214-b4fd0d739f64"), true, "D", 4, "Kuvvet ve Hareket - Soru 3 için Seçenek D", new Guid("dd961e5e-fa2c-492f-838a-34555569d151") },
                    { new Guid("c4652483-1033-4437-8072-1f5f0a466f14"), false, "A", 1, "İş, Güç ve Enerji - Soru 2 için Seçenek A", new Guid("33e27efe-9709-49b6-8513-8f5d26b39e2b") },
                    { new Guid("c62199a3-3e41-467a-990c-b06954dc4516"), true, "B", 2, "Kuvvet ve Hareket - Soru 2 için Seçenek B", new Guid("6291bbca-372e-4d2a-b882-6209da83eee2") },
                    { new Guid("c675bbdf-74e6-408a-96a4-4e4d54261afa"), false, "C", 3, "Problemler - Soru 3 için Seçenek C", new Guid("710c4853-713e-42e4-8c9f-5f57cdd0d12c") },
                    { new Guid("ca1ac58e-6abe-48e0-ad19-c0386ed2e09c"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek A", new Guid("da393945-d792-40a1-9f60-8b370de5f8e0") },
                    { new Guid("ca496884-1a87-484c-ba4e-a5ad2013c3c6"), true, "D", 4, "Sayı Basamakları - Soru 4 için Seçenek D", new Guid("ef395918-4257-4105-843f-516a9c4e255f") },
                    { new Guid("ca5e1f1d-a5eb-4412-8358-39496fcf6381"), true, "A", 1, "Maddenin Halleri - Soru 3 için Seçenek A", new Guid("0923e78e-dd64-4a04-852f-b584f805955a") },
                    { new Guid("cba16957-d0cd-4655-8911-5c38ace5a05d"), false, "D", 4, "Elektrostatik - Soru 1 için Seçenek D", new Guid("fb79a2f8-3db4-4244-9b55-2dd710baf3b8") },
                    { new Guid("cbeeba92-2bb9-403b-ba7c-7c5772e0a4ba"), true, "C", 3, "Elektrostatik - Soru 3 için Seçenek C", new Guid("272cd872-2855-453a-b83d-fa6a19746551") },
                    { new Guid("cca5f04c-2eb9-49d7-bace-68a642f96552"), false, "A", 1, "İş, Güç ve Enerji - Soru 1 için Seçenek A", new Guid("670f083d-c8b5-4e08-8cee-9b74d21b57da") },
                    { new Guid("cd1ad9e5-83c9-4ec0-845b-600b28be4e36"), true, "C", 3, "Hücre - Soru 4 için Seçenek C", new Guid("7962ee2c-1e38-4a0e-8115-0513bfb3a9fa") },
                    { new Guid("ce9eea82-21d2-4fa3-9047-fe29ef31dea4"), false, "A", 1, "Hücre Bölünmeleri - Soru 4 için Seçenek A", new Guid("564b00e8-e0a0-4a6d-926f-f4f2049b44b5") },
                    { new Guid("cea830d7-db7d-45c1-a810-3e95352734a7"), false, "A", 1, "Kalıtım - Soru 2 için Seçenek A", new Guid("3d6d8dfd-398e-4c80-b3e5-d9cbabc6ac58") },
                    { new Guid("cfe6226d-04e9-4a9d-b4bf-08d66051969b"), false, "B", 2, "Hücre Bölünmeleri - Soru 3 için Seçenek B", new Guid("2d13d538-0378-486c-9a45-dd51de764f40") },
                    { new Guid("d0583f56-7bab-436d-abee-ac5a7ca502b3"), true, "A", 1, "Rasyonel Sayılar - Soru 1 için Seçenek A", new Guid("e9d7959b-ea2b-4e02-bdbe-a6f82dffbfea") },
                    { new Guid("d0814e38-b84f-48cb-bab2-4b222075bf45"), false, "D", 4, "Madde ve Özellikleri - Soru 4 için Seçenek D", new Guid("e82c0d52-24a7-4081-b742-f21421758182") },
                    { new Guid("d0f269ba-7c48-4aea-85eb-a1329433e11c"), false, "C", 3, "Temel Kavramlar - Soru 4 için Seçenek C", new Guid("de5a80c6-b26c-4aab-86c7-0d2c5065b444") },
                    { new Guid("d15cc26b-97b3-44eb-a5fd-66e8f58500d9"), false, "A", 1, "Madde ve Özellikleri - Soru 5 için Seçenek A", new Guid("c7ed1a4a-0345-4f00-93d1-bd5b808b6348") },
                    { new Guid("d25bc179-687f-45d6-9bfb-bee584116041"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 5 için Seçenek C", new Guid("8d3a1978-3fda-46af-ab3e-a2436778503d") },
                    { new Guid("d2d70371-835a-4ecc-91a2-9d844a8ebca5"), false, "C", 3, "Kuvvet ve Hareket - Soru 1 için Seçenek C", new Guid("3682b943-54bd-466f-b2ca-8c6ca0917b15") },
                    { new Guid("d31b3d04-0fde-4403-b944-0d81d252fe85"), false, "C", 3, "Problemler - Soru 2 için Seçenek C", new Guid("2bca2c45-8d41-4026-855e-296f3233e926") },
                    { new Guid("d37b9581-92c7-45f7-a4d4-10b8155a6ec3"), false, "B", 2, "Kalıtım - Soru 4 için Seçenek B", new Guid("a2b19c3d-bf9e-4d2c-8efc-aaab45c8aa2a") },
                    { new Guid("d3b0e748-0caa-446d-ab32-040420b2566b"), false, "D", 4, "Temel Kavramlar - Soru 5 için Seçenek D", new Guid("97459954-555a-4bbd-98ec-79758393ec5c") },
                    { new Guid("d40acf38-1171-4d2d-9946-04752efe095b"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 1 için Seçenek A", new Guid("79653cf9-5e61-49f9-967f-9f8e43f3e825") },
                    { new Guid("d603ad5e-f901-4630-a32d-14f8059f9cd6"), true, "A", 1, "Madde ve Özellikleri - Soru 4 için Seçenek A", new Guid("e82c0d52-24a7-4081-b742-f21421758182") },
                    { new Guid("d673d2b8-ed53-43ef-b516-51f4c3b74a58"), false, "B", 2, "Kalıtım - Soru 3 için Seçenek B", new Guid("ec8a69b0-be13-45f3-9f24-a4d57d5e3461") },
                    { new Guid("d9fd1853-1a86-42eb-993e-65df18eb7882"), false, "B", 2, "Problemler - Soru 5 için Seçenek B", new Guid("8042bdd9-76e1-4650-8036-758b438c1a47") },
                    { new Guid("da895beb-17b6-49e8-8770-ca1a52a31832"), false, "B", 2, "Rasyonel Sayılar - Soru 2 için Seçenek B", new Guid("49525d08-2e08-44d6-99fb-e92f7f112a28") },
                    { new Guid("dabd9e96-e235-4e19-8e85-604065dd510f"), false, "D", 4, "Temel Kavramlar - Soru 4 için Seçenek D", new Guid("de5a80c6-b26c-4aab-86c7-0d2c5065b444") },
                    { new Guid("db5d4426-a36f-41b7-8ac2-f9a7a46ab2f0"), true, "D", 4, "Problemler - Soru 4 için Seçenek D", new Guid("7fc23d4e-0206-42c9-b5eb-da8afad36d3f") },
                    { new Guid("dc8ea03e-477e-4b8f-81fc-9b1e40f28916"), true, "B", 2, "Hücre Bölünmeleri - Soru 4 için Seçenek B", new Guid("564b00e8-e0a0-4a6d-926f-f4f2049b44b5") },
                    { new Guid("dd2cda33-353a-49c1-8aab-0abb5a2ab517"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek C", new Guid("c00b19f0-d671-426a-b179-96bf1ad403e8") },
                    { new Guid("dd6aacda-d372-4061-998c-e868c45acf8e"), true, "A", 1, "Hücre Bölünmeleri - Soru 3 için Seçenek A", new Guid("2d13d538-0378-486c-9a45-dd51de764f40") },
                    { new Guid("de13000d-b9e8-472b-81c7-feabeb673809"), false, "D", 4, "Sayı Basamakları - Soru 5 için Seçenek D", new Guid("9ea389a2-a8d3-48d1-81f3-286a0b94bf5a") },
                    { new Guid("dea90c0e-dabc-48bc-8ff8-8bac93d7bfc6"), false, "C", 3, "Madde ve Özellikleri - Soru 5 için Seçenek C", new Guid("c7ed1a4a-0345-4f00-93d1-bd5b808b6348") },
                    { new Guid("deaf6c3d-b6f5-4b24-8c7d-dc3c59b28c9b"), true, "B", 2, "Elektrostatik - Soru 2 için Seçenek B", new Guid("df4e67d5-28ae-4fa0-a3c9-06d9677a9642") },
                    { new Guid("df1e535e-c392-4c4a-9b79-768c994cc276"), false, "A", 1, "Elektrostatik - Soru 2 için Seçenek A", new Guid("df4e67d5-28ae-4fa0-a3c9-06d9677a9642") },
                    { new Guid("df2fddf8-f77c-456d-b271-15b63559a62e"), true, "D", 4, "Sayı Basamakları - Soru 3 için Seçenek D", new Guid("9d4e6ea4-5aa3-46d5-a1dc-f6ebab4ab3f9") },
                    { new Guid("e029ae9e-b16d-4037-83f3-c2349bd3cdd2"), false, "B", 2, "Rasyonel Sayılar - Soru 5 için Seçenek B", new Guid("10b4ab12-6b09-4beb-a746-75b995012ce2") },
                    { new Guid("e0e2b300-d689-4e8a-b016-ef72e4cc4ac3"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 3 için Seçenek A", new Guid("6d5c434a-9f4e-4474-bef5-376404305829") },
                    { new Guid("e0e63c84-0bb8-4f7c-9a02-87b1cab05bd8"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 4 için Seçenek C", new Guid("94e3594e-acf5-4e31-97d1-721d2f5f33c1") },
                    { new Guid("e1355e49-69bc-41fe-8ad8-fd0ef2540a0c"), false, "B", 2, "Kalıtım - Soru 2 için Seçenek B", new Guid("3d6d8dfd-398e-4c80-b3e5-d9cbabc6ac58") },
                    { new Guid("e13fe5be-93c8-4cac-ab6b-96fe43b95aa0"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek A", new Guid("56a2e950-7f57-4a0d-92e8-1fd534fcb849") },
                    { new Guid("e2046f43-6a60-405c-ac5e-592101a07f4a"), true, "B", 2, "Temel Kavramlar - Soru 4 için Seçenek B", new Guid("de5a80c6-b26c-4aab-86c7-0d2c5065b444") },
                    { new Guid("e2e9cc2f-ff87-4868-ae32-c663fb4b82e9"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek B", new Guid("12a60e09-fafa-4b18-8fbc-710b63e4635c") },
                    { new Guid("e33dca52-66f5-4efd-aa61-868ccad9e2f6"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek A", new Guid("750169ef-b563-4728-8148-f1eacc4b55ca") },
                    { new Guid("e3f9c30f-e9cf-4f45-9e5e-6e545724866d"), false, "A", 1, "Temel Kavramlar - Soru 1 için Seçenek A", new Guid("fab166d3-493b-4ddd-8234-bc443f0e61e7") },
                    { new Guid("e4255acd-8346-4747-9bb3-fbbc575a7720"), false, "C", 3, "Kimya Bilimi - Soru 3 için Seçenek C", new Guid("c40af7c1-d0d1-47c6-90ec-40e23fa66eab") },
                    { new Guid("e4261d48-9a62-4b9c-8876-126a1f79dfca"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek D", new Guid("12a60e09-fafa-4b18-8fbc-710b63e4635c") },
                    { new Guid("e42a4efc-5c4f-4762-9bca-5c7ad4a673f4"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek B", new Guid("0b1dffb9-5249-4061-96e0-9123d73b4f2d") },
                    { new Guid("e443599f-ad58-474f-98eb-34cd2995e8fc"), true, "A", 1, "Sayı Basamakları - Soru 5 için Seçenek A", new Guid("9ea389a2-a8d3-48d1-81f3-286a0b94bf5a") },
                    { new Guid("e47a6dba-e8c5-4da1-9163-175a4116a322"), false, "A", 1, "Madde ve Özellikleri - Soru 3 için Seçenek A", new Guid("5683a9bb-caf6-4987-bb89-994081b8cf25") },
                    { new Guid("e4cc040e-0943-4ed0-8433-55e9840b81fd"), false, "B", 2, "Hücre Bölünmeleri - Soru 2 için Seçenek B", new Guid("98a17f7a-7b57-476e-94a8-0e954be33448") },
                    { new Guid("e507669f-6a4b-4bf0-8483-f7aed76946fd"), false, "C", 3, "Fizik Bilimine Giriş - Soru 1 için Seçenek C", new Guid("abe12dd3-83da-4f9a-acfb-0d0fbdf444b0") },
                    { new Guid("e537db2b-9f48-4d89-9e1c-2813742d74d7"), false, "A", 1, "Problemler - Soru 5 için Seçenek A", new Guid("8042bdd9-76e1-4650-8036-758b438c1a47") },
                    { new Guid("e5b5c44d-48db-4f04-a2da-531f1f40018a"), true, "B", 2, "Canlıların Sınıflandırılması - Soru 1 için Seçenek B", new Guid("c2c1dab2-08ec-49b3-a9de-e83057920864") },
                    { new Guid("e5ca3933-224a-40dc-935f-a78bd2e0b68c"), false, "C", 3, "Temel Kavramlar - Soru 5 için Seçenek C", new Guid("97459954-555a-4bbd-98ec-79758393ec5c") },
                    { new Guid("e63dc173-4e4f-4abe-af8e-dbcda8faeb5d"), false, "B", 2, "Fizik Bilimine Giriş - Soru 1 için Seçenek B", new Guid("abe12dd3-83da-4f9a-acfb-0d0fbdf444b0") },
                    { new Guid("e6aca951-e73b-4f10-95c5-c868e751adf6"), true, "A", 1, "Fizik Bilimine Giriş - Soru 1 için Seçenek A", new Guid("abe12dd3-83da-4f9a-acfb-0d0fbdf444b0") },
                    { new Guid("e7b21e4f-74f6-4abf-b5b4-4ff26b274634"), true, "C", 3, "Elektrostatik - Soru 4 için Seçenek C", new Guid("12712761-80a7-49ad-88ee-d34b7fd7905a") },
                    { new Guid("e9066f74-bd94-4a68-ac26-46eabd4f8676"), true, "B", 2, "Canlıların Sınıflandırılması - Soru 3 için Seçenek B", new Guid("6d5c434a-9f4e-4474-bef5-376404305829") },
                    { new Guid("eb615aa3-948b-4595-9612-da81a16dbd5e"), false, "D", 4, "Maddenin Halleri - Soru 3 için Seçenek D", new Guid("0923e78e-dd64-4a04-852f-b584f805955a") },
                    { new Guid("ec4703a2-c350-4999-9ec9-03cc2bf01e19"), false, "B", 2, "Sayı Basamakları - Soru 4 için Seçenek B", new Guid("ef395918-4257-4105-843f-516a9c4e255f") },
                    { new Guid("ed601e2e-c6a4-4ee8-8720-444a0031f27a"), false, "D", 4, "Rasyonel Sayılar - Soru 5 için Seçenek D", new Guid("10b4ab12-6b09-4beb-a746-75b995012ce2") },
                    { new Guid("ed87e4ef-3be5-46ab-a1c2-3491aa7f015e"), false, "C", 3, "Kuvvet ve Hareket - Soru 4 için Seçenek C", new Guid("5e8bc480-927f-436e-86d4-59cc9d8e35df") },
                    { new Guid("ee1b547c-4cf3-4602-a2ff-5c8450c96258"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 1 için Seçenek B", new Guid("79653cf9-5e61-49f9-967f-9f8e43f3e825") },
                    { new Guid("eea4e66f-cbc7-43de-98c9-121f677dffab"), true, "D", 4, "Kuvvet ve Hareket - Soru 4 için Seçenek D", new Guid("5e8bc480-927f-436e-86d4-59cc9d8e35df") },
                    { new Guid("eeb6818f-baa5-4782-b9e9-fa830a7259ab"), false, "A", 1, "Rasyonel Sayılar - Soru 3 için Seçenek A", new Guid("68166f19-c9af-445f-93e2-517db463cd9c") },
                    { new Guid("ef1b7fae-13a8-4455-b12c-2b0da70477a7"), false, "A", 1, "İş, Güç ve Enerji - Soru 5 için Seçenek A", new Guid("f70f0e4c-c6f0-4996-9b14-63fba55009c8") },
                    { new Guid("ef89dcff-282e-4c9e-83e8-fc2db8cfd463"), false, "B", 2, "Sayı Basamakları - Soru 3 için Seçenek B", new Guid("9d4e6ea4-5aa3-46d5-a1dc-f6ebab4ab3f9") },
                    { new Guid("f0b9ac18-3da3-4426-afd5-fe179a13c743"), false, "B", 2, "Fizik Bilimine Giriş - Soru 4 için Seçenek B", new Guid("4bba942f-cddc-4e44-af3c-a18fe464e61d") },
                    { new Guid("f10dc444-6ae0-46e4-ac23-0aaca07d88f8"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 2 için Seçenek C", new Guid("3745bdb8-22e6-4779-a0c8-dd5bdbb054cd") },
                    { new Guid("f13bee02-7477-4a7d-962d-70b1f8a868ae"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 2 için Seçenek D", new Guid("3745bdb8-22e6-4779-a0c8-dd5bdbb054cd") },
                    { new Guid("f16fb930-8bc5-411f-9c46-1e4d72223c36"), true, "B", 2, "Temel Kavramlar - Soru 5 için Seçenek B", new Guid("97459954-555a-4bbd-98ec-79758393ec5c") },
                    { new Guid("f289e074-f6bf-43f4-bb6d-f2cc3bc8a15d"), false, "A", 1, "Hücre - Soru 3 için Seçenek A", new Guid("79505962-817f-4e44-9a9b-9cc47ea15e08") },
                    { new Guid("f2e493ee-6add-40ba-a647-a6e45d357a83"), true, "B", 2, "Elektrostatik - Soru 1 için Seçenek B", new Guid("fb79a2f8-3db4-4244-9b55-2dd710baf3b8") },
                    { new Guid("f378b65b-cbaf-4f98-b4b9-895faa136e4c"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 5 için Seçenek A", new Guid("a3a0ca6b-0b81-4a2a-9727-3c3795ad8ac2") },
                    { new Guid("f3e21cc0-398c-4ade-b2ca-a73f3d30b6cc"), false, "C", 3, "Kimya Bilimi - Soru 2 için Seçenek C", new Guid("30245ea2-1640-48a5-aaf4-0b92aa95ab8d") },
                    { new Guid("f564a5fc-8852-4169-918b-6045daf84d7a"), true, "A", 1, "Problemler - Soru 1 için Seçenek A", new Guid("d7b8f9eb-96f3-43f3-8790-fb9823aeb66e") },
                    { new Guid("f582ae29-3277-479f-87ca-30e8cdbc52c3"), false, "A", 1, "İş, Güç ve Enerji - Soru 4 için Seçenek A", new Guid("5d347e47-044f-4374-85ce-6418cff5d776") },
                    { new Guid("f798e426-9f06-4c58-89e0-58c9313fc773"), false, "D", 4, "Kalıtım - Soru 5 için Seçenek D", new Guid("de582186-208a-4968-9c29-5821e90f6b3a") },
                    { new Guid("f7a2423b-0f7f-4f8a-99a4-680700d241ae"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 5 için Seçenek B", new Guid("a3a0ca6b-0b81-4a2a-9727-3c3795ad8ac2") },
                    { new Guid("f9e63ea3-a3d0-4dcc-b3e8-ff04021e9c95"), true, "D", 4, "Problemler - Soru 5 için Seçenek D", new Guid("8042bdd9-76e1-4650-8036-758b438c1a47") },
                    { new Guid("fa4c7247-af38-4ae6-926f-e4eb0fbe30ac"), false, "B", 2, "Hücre - Soru 5 için Seçenek B", new Guid("b2969742-7a87-499a-9963-13092055afe2") },
                    { new Guid("fa6e472b-f820-4ac3-9873-2f0350a5cb9a"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 1 için Seçenek D", new Guid("c2c1dab2-08ec-49b3-a9de-e83057920864") },
                    { new Guid("fb2c9b6d-ec6e-4f94-9bc0-c9e21ae30a88"), false, "A", 1, "Problemler - Soru 4 için Seçenek A", new Guid("7fc23d4e-0206-42c9-b5eb-da8afad36d3f") },
                    { new Guid("fb86e1b7-1c6d-49c2-ad3f-f3953fbeb64d"), false, "A", 1, "Hücre Bölünmeleri - Soru 2 için Seçenek A", new Guid("98a17f7a-7b57-476e-94a8-0e954be33448") },
                    { new Guid("fbcf85a6-2d83-4ea3-8245-1b92bbaa8cd0"), false, "B", 2, "İş, Güç ve Enerji - Soru 4 için Seçenek B", new Guid("5d347e47-044f-4374-85ce-6418cff5d776") },
                    { new Guid("fc30fa3b-97be-43e6-a500-c32cb95cf6e2"), false, "D", 4, "Bölme ve Bölünebilme - Soru 4 için Seçenek D", new Guid("70429a32-1a49-4e38-914a-cd90c052e877") },
                    { new Guid("fd3b27c3-6d53-4f05-83b1-22745b112dd9"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek B", new Guid("c00b19f0-d671-426a-b179-96bf1ad403e8") },
                    { new Guid("fef1daed-7518-48eb-a8b4-6bf2df62aa94"), false, "A", 1, "Kalıtım - Soru 1 için Seçenek A", new Guid("6de0cbfb-1143-46af-9fbb-3646bba0dd1a") },
                    { new Guid("ff197505-56d2-466c-a8df-582c90d0bbc0"), false, "D", 4, "Elektrostatik - Soru 2 için Seçenek D", new Guid("df4e67d5-28ae-4fa0-a3c9-06d9677a9642") },
                    { new Guid("ff3a3d8f-ee3d-47a9-a2bf-8a4ba407d304"), true, "D", 4, "Problemler - Soru 3 için Seçenek D", new Guid("710c4853-713e-42e4-8c9f-5f57cdd0d12c") },
                    { new Guid("ff99a061-9fb6-42d5-a91a-0e7e310773d1"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek A", new Guid("5ef1dabf-749e-4adb-a496-12f3b7b873fb") }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ParentTopicId", "SubjectId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("11630a15-b1a6-4c88-af3b-790bcf067d1a"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3637), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Temel Kavramlar" },
                    { new Guid("1611be1d-4fd2-4f49-95e3-f51c9953e1de"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3723), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Canlıların Sınıflandırılması" },
                    { new Guid("1bf8fb7e-98c3-4f7a-9362-aff5a4e52b89"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3720), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Yaşam Bilimi Biyoloji" },
                    { new Guid("24fa8590-d028-438a-849f-a5a284506f02"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3650), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Fizik Bilimine Giriş" },
                    { new Guid("25a01d84-25f4-4446-b9ee-f99150e5c83f"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3721), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre" },
                    { new Guid("280c0aaf-109a-43fb-9963-340435e2a9ed"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3725), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre Bölünmeleri" },
                    { new Guid("282c0873-b614-446c-af49-0533f4e87250"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3710), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Atom ve Periyodik Sistem" },
                    { new Guid("2e166c1c-0d1a-449a-ba0a-0bfcd1f053a8"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3661), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimya Bilimi" },
                    { new Guid("54abef42-7b5c-4f38-b5a7-7c364c48ebd6"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3713), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Maddenin Halleri" },
                    { new Guid("6ce1703e-9fb5-43de-aad3-14ade52422e6"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3641), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Bölme ve Bölünebilme" },
                    { new Guid("755a5941-e79e-464a-a039-636676e95501"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3656), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "İş, Güç ve Enerji" },
                    { new Guid("7d5321fc-68e5-4fa3-ada0-ef9a253ad07c"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3711), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimyasal Türler Arası Etkileşimler" },
                    { new Guid("9ca10874-46c7-4844-b809-7363a2aefc41"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3640), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Sayı Basamakları" },
                    { new Guid("a1b49ba7-e466-4e36-9d49-f0ea159cdea6"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3715), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Asitler, Bazlar ve Tuzlar" },
                    { new Guid("d1dfb589-afe3-4bb7-941c-485d5da9cab7"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3654), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Kuvvet ve Hareket" },
                    { new Guid("d94c6416-7e6b-4443-8774-f5493c62a5ab"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3651), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Madde ve Özellikleri" },
                    { new Guid("de216739-d6b5-4ab7-b853-6ef09d0a46e7"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3658), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Elektrostatik" },
                    { new Guid("df22021f-7905-4399-a9fb-4f15511ddc51"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3643), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Rasyonel Sayılar" },
                    { new Guid("dfcecf39-4461-4bb6-8694-97159a281379"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3726), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Kalıtım" },
                    { new Guid("e35c8f98-de4b-41ec-b972-87581897b868"), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(3645), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Problemler" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsTopics",
                columns: new[] { "QuestionId", "TopicId", "Id" },
                values: new object[,]
                {
                    { new Guid("0923e78e-dd64-4a04-852f-b584f805955a"), new Guid("54abef42-7b5c-4f38-b5a7-7c364c48ebd6"), new Guid("5d9858c7-f0ef-468d-afe3-a53709dd4ed2") },
                    { new Guid("0b1dffb9-5249-4061-96e0-9123d73b4f2d"), new Guid("1bf8fb7e-98c3-4f7a-9362-aff5a4e52b89"), new Guid("94bb8571-6f54-4b72-a868-e2cb27121c1f") },
                    { new Guid("0ebcf967-c56f-44fc-81d6-6b7ac8caabe7"), new Guid("24fa8590-d028-438a-849f-a5a284506f02"), new Guid("4eb5bd5f-95ee-4194-abdd-175c35d13106") },
                    { new Guid("10b4ab12-6b09-4beb-a746-75b995012ce2"), new Guid("df22021f-7905-4399-a9fb-4f15511ddc51"), new Guid("36ea92c4-30b6-4fdf-a82a-878e0c3e8a86") },
                    { new Guid("111e2df0-41f5-4333-87db-fcef64f296df"), new Guid("282c0873-b614-446c-af49-0533f4e87250"), new Guid("abc6b4ad-3aaa-4302-bdf1-35baed17fffe") },
                    { new Guid("12712761-80a7-49ad-88ee-d34b7fd7905a"), new Guid("de216739-d6b5-4ab7-b853-6ef09d0a46e7"), new Guid("0b0fd760-bdda-417e-afc5-8e745eee72f1") },
                    { new Guid("12a60e09-fafa-4b18-8fbc-710b63e4635c"), new Guid("a1b49ba7-e466-4e36-9d49-f0ea159cdea6"), new Guid("397c806f-e9ff-437d-a873-27e8368072bc") },
                    { new Guid("1833a3b0-acfc-49ad-a0a1-20c6b9131936"), new Guid("d94c6416-7e6b-4443-8774-f5493c62a5ab"), new Guid("c4ce0c82-58ba-4d40-8e66-1bd58c9e4d15") },
                    { new Guid("1850bfe5-ab6c-4b68-86f0-cc682b3e3314"), new Guid("6ce1703e-9fb5-43de-aad3-14ade52422e6"), new Guid("2f1449d7-3052-46a9-946a-d3e00c1eab98") },
                    { new Guid("19bf3cb1-5dfd-42aa-aa23-c844dc10b5fc"), new Guid("54abef42-7b5c-4f38-b5a7-7c364c48ebd6"), new Guid("f3ad0831-c061-45e0-9616-2db89e8fdf73") },
                    { new Guid("1aea283e-c697-471c-b66f-999505c7a5ba"), new Guid("df22021f-7905-4399-a9fb-4f15511ddc51"), new Guid("2357bfa1-8950-47dc-94e6-f718231b5e35") },
                    { new Guid("1bd4563d-fc43-461f-864b-6f03ab948f40"), new Guid("7d5321fc-68e5-4fa3-ada0-ef9a253ad07c"), new Guid("4db798d2-1288-4dc0-bf31-30be576a03b0") },
                    { new Guid("1c941f8d-e706-41fe-9006-94848ffa1bdd"), new Guid("7d5321fc-68e5-4fa3-ada0-ef9a253ad07c"), new Guid("6dbc1445-bc4b-439f-8696-c3b862fdc946") },
                    { new Guid("1ea17762-47be-4e6a-944a-9e1b4919d3fa"), new Guid("2e166c1c-0d1a-449a-ba0a-0bfcd1f053a8"), new Guid("494092eb-a262-4c0c-a699-263c6b7545b4") },
                    { new Guid("272cd872-2855-453a-b83d-fa6a19746551"), new Guid("de216739-d6b5-4ab7-b853-6ef09d0a46e7"), new Guid("d50ddd44-83f3-4ec0-bd34-39d90502588f") },
                    { new Guid("2a798d7f-98f8-42f7-bb54-3bcadda4c9a9"), new Guid("9ca10874-46c7-4844-b809-7363a2aefc41"), new Guid("d4ad7ec6-3fce-4a3d-87e6-374e003dce90") },
                    { new Guid("2bb9e157-de48-43d5-85aa-591d5ee6b06d"), new Guid("de216739-d6b5-4ab7-b853-6ef09d0a46e7"), new Guid("f5298791-1494-4690-9bb0-bbf45e99b7e2") },
                    { new Guid("2bca2c45-8d41-4026-855e-296f3233e926"), new Guid("e35c8f98-de4b-41ec-b972-87581897b868"), new Guid("defb3d81-a826-42ab-8d5d-1ad331ce950e") },
                    { new Guid("2d13d538-0378-486c-9a45-dd51de764f40"), new Guid("280c0aaf-109a-43fb-9963-340435e2a9ed"), new Guid("be46a54b-a96f-47ca-b1d4-1f0d752809ce") },
                    { new Guid("30245ea2-1640-48a5-aaf4-0b92aa95ab8d"), new Guid("2e166c1c-0d1a-449a-ba0a-0bfcd1f053a8"), new Guid("3ca7914f-87a1-42a8-a2b3-1690131eb975") },
                    { new Guid("33e27efe-9709-49b6-8513-8f5d26b39e2b"), new Guid("755a5941-e79e-464a-a039-636676e95501"), new Guid("098066da-1dee-4664-8882-3bcda987fa47") },
                    { new Guid("3682b943-54bd-466f-b2ca-8c6ca0917b15"), new Guid("d1dfb589-afe3-4bb7-941c-485d5da9cab7"), new Guid("455b175b-875d-4893-b91c-a9542de4c3b2") },
                    { new Guid("3745bdb8-22e6-4779-a0c8-dd5bdbb054cd"), new Guid("1611be1d-4fd2-4f49-95e3-f51c9953e1de"), new Guid("3b306661-b3ea-406f-be51-3bf82814930c") },
                    { new Guid("3d6d8dfd-398e-4c80-b3e5-d9cbabc6ac58"), new Guid("dfcecf39-4461-4bb6-8694-97159a281379"), new Guid("4514c330-739c-4072-95ce-aca3e3daad9f") },
                    { new Guid("3f0f6a73-f1de-4455-9aec-3d19cb1b5556"), new Guid("11630a15-b1a6-4c88-af3b-790bcf067d1a"), new Guid("d7ff3779-6424-4782-a850-fa29f7326e76") },
                    { new Guid("49525d08-2e08-44d6-99fb-e92f7f112a28"), new Guid("df22021f-7905-4399-a9fb-4f15511ddc51"), new Guid("01746da6-df33-4bba-b748-c1cae7143148") },
                    { new Guid("4bba942f-cddc-4e44-af3c-a18fe464e61d"), new Guid("24fa8590-d028-438a-849f-a5a284506f02"), new Guid("4c934c86-9f09-47f0-9d50-8810e31efeac") },
                    { new Guid("4fc6d20a-c87f-46d1-b7f4-ca6528eedc7e"), new Guid("11630a15-b1a6-4c88-af3b-790bcf067d1a"), new Guid("707a51b8-3f17-473a-8ed6-42b0d2bd183f") },
                    { new Guid("50cfd01f-4fbb-4321-9c81-fe5ebd6e6aa1"), new Guid("282c0873-b614-446c-af49-0533f4e87250"), new Guid("f58b0a8c-d702-44b2-889b-1232bed1a177") },
                    { new Guid("54d7f16c-cefb-447b-9145-cb69831e416f"), new Guid("25a01d84-25f4-4446-b9ee-f99150e5c83f"), new Guid("96594225-2a62-46dd-9900-5a1e33cd648b") },
                    { new Guid("564b00e8-e0a0-4a6d-926f-f4f2049b44b5"), new Guid("280c0aaf-109a-43fb-9963-340435e2a9ed"), new Guid("37e38846-678c-4587-b5e0-1d088eeb142c") },
                    { new Guid("5683a9bb-caf6-4987-bb89-994081b8cf25"), new Guid("d94c6416-7e6b-4443-8774-f5493c62a5ab"), new Guid("948ba8c6-ca92-4fe5-abee-873dbe9aa127") },
                    { new Guid("56a2e950-7f57-4a0d-92e8-1fd534fcb849"), new Guid("1bf8fb7e-98c3-4f7a-9362-aff5a4e52b89"), new Guid("5cca2ec7-b8c4-4d73-a9b7-791fa1f3069e") },
                    { new Guid("5d347e47-044f-4374-85ce-6418cff5d776"), new Guid("755a5941-e79e-464a-a039-636676e95501"), new Guid("30a13c66-c3ae-4437-9ba2-f8957560458f") },
                    { new Guid("5e8bc480-927f-436e-86d4-59cc9d8e35df"), new Guid("d1dfb589-afe3-4bb7-941c-485d5da9cab7"), new Guid("7831ef2b-1849-4b30-b72c-2cf494b4753a") },
                    { new Guid("5ef1dabf-749e-4adb-a496-12f3b7b873fb"), new Guid("1bf8fb7e-98c3-4f7a-9362-aff5a4e52b89"), new Guid("e8143dc3-e815-46ae-8ff8-99b5ec692593") },
                    { new Guid("6012e350-d7ac-40c2-baad-7b62cd8c74d2"), new Guid("d1dfb589-afe3-4bb7-941c-485d5da9cab7"), new Guid("7fe82dcb-8490-4cb4-99cd-728405fd403e") },
                    { new Guid("60e69b57-3a09-4c44-ad4e-631a19e5fae8"), new Guid("280c0aaf-109a-43fb-9963-340435e2a9ed"), new Guid("a7f07afb-1f1d-431b-9696-e8034c98ef7b") },
                    { new Guid("6291bbca-372e-4d2a-b882-6209da83eee2"), new Guid("d1dfb589-afe3-4bb7-941c-485d5da9cab7"), new Guid("fbbce082-3293-4aaf-857e-4b09b14340ec") },
                    { new Guid("62bdc1aa-777b-48b9-b2f3-25d6ae8c0a90"), new Guid("24fa8590-d028-438a-849f-a5a284506f02"), new Guid("05698b65-8361-4554-880e-fc70030ec820") },
                    { new Guid("63a6462d-6a4a-4ec8-93ed-1460d0d0e033"), new Guid("54abef42-7b5c-4f38-b5a7-7c364c48ebd6"), new Guid("70f7f625-342f-4e1a-a1dc-e9a8956e8602") },
                    { new Guid("668cbdfb-7d41-4167-838c-44f772a79544"), new Guid("24fa8590-d028-438a-849f-a5a284506f02"), new Guid("e36dc90b-547a-48c9-b857-103066e025ae") },
                    { new Guid("670f083d-c8b5-4e08-8cee-9b74d21b57da"), new Guid("755a5941-e79e-464a-a039-636676e95501"), new Guid("f856ca47-db0a-4f63-ab68-5821f6aafc05") },
                    { new Guid("68166f19-c9af-445f-93e2-517db463cd9c"), new Guid("df22021f-7905-4399-a9fb-4f15511ddc51"), new Guid("fe53dd43-fe03-456b-85c9-6da07afaa62c") },
                    { new Guid("6d5c434a-9f4e-4474-bef5-376404305829"), new Guid("1611be1d-4fd2-4f49-95e3-f51c9953e1de"), new Guid("7990d6e3-e61f-4bad-ac0f-ec1cd7fb1d50") },
                    { new Guid("6de0cbfb-1143-46af-9fbb-3646bba0dd1a"), new Guid("dfcecf39-4461-4bb6-8694-97159a281379"), new Guid("bf9fcb30-8dc6-49ff-b8a1-4508bbe44042") },
                    { new Guid("6f59e3e8-733c-4a8d-ba63-d387d21de047"), new Guid("54abef42-7b5c-4f38-b5a7-7c364c48ebd6"), new Guid("5fa8937e-a7a2-4f98-9d2a-df2b9cdce866") },
                    { new Guid("70429a32-1a49-4e38-914a-cd90c052e877"), new Guid("6ce1703e-9fb5-43de-aad3-14ade52422e6"), new Guid("60a2dc6e-c2ba-4c80-941d-475d1a2e3e91") },
                    { new Guid("710c4853-713e-42e4-8c9f-5f57cdd0d12c"), new Guid("e35c8f98-de4b-41ec-b972-87581897b868"), new Guid("8f7a99a2-c667-4bed-9612-4a18cefbe5c8") },
                    { new Guid("750169ef-b563-4728-8148-f1eacc4b55ca"), new Guid("a1b49ba7-e466-4e36-9d49-f0ea159cdea6"), new Guid("1c62e23e-6476-4027-8a89-368645cd497a") },
                    { new Guid("79505962-817f-4e44-9a9b-9cc47ea15e08"), new Guid("25a01d84-25f4-4446-b9ee-f99150e5c83f"), new Guid("d5680bf5-6447-4d15-98b0-cfe85f405ec5") },
                    { new Guid("7962ee2c-1e38-4a0e-8115-0513bfb3a9fa"), new Guid("25a01d84-25f4-4446-b9ee-f99150e5c83f"), new Guid("b8c88f00-4cc3-42df-a8d4-163c495fd8d8") },
                    { new Guid("79653cf9-5e61-49f9-967f-9f8e43f3e825"), new Guid("282c0873-b614-446c-af49-0533f4e87250"), new Guid("745861b4-3cfd-4a07-a358-1f5442be1b45") },
                    { new Guid("7fc23d4e-0206-42c9-b5eb-da8afad36d3f"), new Guid("e35c8f98-de4b-41ec-b972-87581897b868"), new Guid("7c044f08-a239-494f-8070-82cd7ef3b19b") },
                    { new Guid("8042bdd9-76e1-4650-8036-758b438c1a47"), new Guid("e35c8f98-de4b-41ec-b972-87581897b868"), new Guid("4d5b5c9d-9953-4088-834a-d92774ace442") },
                    { new Guid("8d3a1978-3fda-46af-ab3e-a2436778503d"), new Guid("282c0873-b614-446c-af49-0533f4e87250"), new Guid("8e95038e-a83d-433f-a6c9-f9698875e46f") },
                    { new Guid("94e3594e-acf5-4e31-97d1-721d2f5f33c1"), new Guid("1611be1d-4fd2-4f49-95e3-f51c9953e1de"), new Guid("b2bcc6fb-4abf-4ffc-b9f4-900ddebd4503") },
                    { new Guid("97459954-555a-4bbd-98ec-79758393ec5c"), new Guid("11630a15-b1a6-4c88-af3b-790bcf067d1a"), new Guid("52bc50b3-e871-4aea-b5ff-440b2e5b0375") },
                    { new Guid("98a17f7a-7b57-476e-94a8-0e954be33448"), new Guid("280c0aaf-109a-43fb-9963-340435e2a9ed"), new Guid("2ad47a8a-9d03-443a-aa84-8710f34ccf7e") },
                    { new Guid("9d4e6ea4-5aa3-46d5-a1dc-f6ebab4ab3f9"), new Guid("9ca10874-46c7-4844-b809-7363a2aefc41"), new Guid("ce8f7e1c-9cea-43f7-9627-e98aa29770c6") },
                    { new Guid("9ea389a2-a8d3-48d1-81f3-286a0b94bf5a"), new Guid("9ca10874-46c7-4844-b809-7363a2aefc41"), new Guid("26b72c4b-c853-4f04-9991-debd47623b5f") },
                    { new Guid("9fd8e2c4-c2d1-4288-a4c3-73bbff56a41c"), new Guid("a1b49ba7-e466-4e36-9d49-f0ea159cdea6"), new Guid("22e06593-2ad0-4866-9a62-36cef6364aaf") },
                    { new Guid("a0d0e01a-6611-4be7-9e7f-16bb90db2aa8"), new Guid("9ca10874-46c7-4844-b809-7363a2aefc41"), new Guid("2007d829-1e50-48ef-b60e-863ce2acbf21") },
                    { new Guid("a2093370-bf69-454f-87f3-3fcab98a64aa"), new Guid("6ce1703e-9fb5-43de-aad3-14ade52422e6"), new Guid("efdd2e9b-1a0c-481c-8e40-f14e1b408e6e") },
                    { new Guid("a2b19c3d-bf9e-4d2c-8efc-aaab45c8aa2a"), new Guid("dfcecf39-4461-4bb6-8694-97159a281379"), new Guid("f5b8e680-14fb-4d7d-9098-50afc3a46c4e") },
                    { new Guid("a2dfd7da-88bb-4857-b28d-fab1117579d8"), new Guid("6ce1703e-9fb5-43de-aad3-14ade52422e6"), new Guid("56381c02-65c5-4508-a67f-84882e8db5ad") },
                    { new Guid("a3a0ca6b-0b81-4a2a-9727-3c3795ad8ac2"), new Guid("1611be1d-4fd2-4f49-95e3-f51c9953e1de"), new Guid("9b5a8c13-269f-465d-87b0-86f1c48de497") },
                    { new Guid("abe12dd3-83da-4f9a-acfb-0d0fbdf444b0"), new Guid("24fa8590-d028-438a-849f-a5a284506f02"), new Guid("2a0a7e6e-ac5b-4ad9-9f76-ff7865906c08") },
                    { new Guid("b0115b2a-1b83-4569-8589-09f1a93ef3bf"), new Guid("7d5321fc-68e5-4fa3-ada0-ef9a253ad07c"), new Guid("610f58ce-b1ee-41b3-b49d-83c576304ee6") },
                    { new Guid("b0e0c6c6-3ad5-4d45-b44d-c5162208bb31"), new Guid("d94c6416-7e6b-4443-8774-f5493c62a5ab"), new Guid("8816859b-ab52-4041-929c-4720fff5fc9d") },
                    { new Guid("b14f8f39-a9ac-4336-9202-e8400545dffb"), new Guid("6ce1703e-9fb5-43de-aad3-14ade52422e6"), new Guid("1b75c582-ddb6-4230-a229-16d2b5119b44") },
                    { new Guid("b1e58b1e-2062-4650-800d-0e4c676582fb"), new Guid("25a01d84-25f4-4446-b9ee-f99150e5c83f"), new Guid("57d9281c-c7fe-4128-b2f7-5a96c06ec953") },
                    { new Guid("b2969742-7a87-499a-9963-13092055afe2"), new Guid("25a01d84-25f4-4446-b9ee-f99150e5c83f"), new Guid("50399d7d-fbba-4e8e-8fd7-3b35e1f63f88") },
                    { new Guid("c00b19f0-d671-426a-b179-96bf1ad403e8"), new Guid("a1b49ba7-e466-4e36-9d49-f0ea159cdea6"), new Guid("1c4ce9a9-8531-459e-a853-b056a9ab69d0") },
                    { new Guid("c1a38e98-3787-4551-8569-2010d5ff61e8"), new Guid("755a5941-e79e-464a-a039-636676e95501"), new Guid("e6ab5d10-bc18-463b-be75-c61b27f18154") },
                    { new Guid("c29858a6-8bfa-4934-a5dc-cd203b47e5b5"), new Guid("2e166c1c-0d1a-449a-ba0a-0bfcd1f053a8"), new Guid("1150bbd2-f36c-40ce-8287-3bf3b0b56c19") },
                    { new Guid("c2c1dab2-08ec-49b3-a9de-e83057920864"), new Guid("1611be1d-4fd2-4f49-95e3-f51c9953e1de"), new Guid("8b2c128c-e214-40dd-b6b6-54bdaed63d2a") },
                    { new Guid("c40af7c1-d0d1-47c6-90ec-40e23fa66eab"), new Guid("2e166c1c-0d1a-449a-ba0a-0bfcd1f053a8"), new Guid("b2d5ad95-4f81-4ff1-8691-a83e34a8d25b") },
                    { new Guid("c7653c3f-0479-48a8-b511-a96c57d950fb"), new Guid("2e166c1c-0d1a-449a-ba0a-0bfcd1f053a8"), new Guid("9de491aa-400d-426b-ae6e-52f31cd4a14c") },
                    { new Guid("c7ed1a4a-0345-4f00-93d1-bd5b808b6348"), new Guid("d94c6416-7e6b-4443-8774-f5493c62a5ab"), new Guid("881804ae-39d6-4ac1-aa90-c580e8d59066") },
                    { new Guid("c9fe6527-0b56-4384-80fb-bdf1affea992"), new Guid("a1b49ba7-e466-4e36-9d49-f0ea159cdea6"), new Guid("958690b2-fa53-4e54-beda-22f0a674177c") },
                    { new Guid("d7b8f9eb-96f3-43f3-8790-fb9823aeb66e"), new Guid("e35c8f98-de4b-41ec-b972-87581897b868"), new Guid("b5af15a3-750a-4f71-a8f1-6a740906e4b7") },
                    { new Guid("d9323b94-9cc2-42d4-ab2d-04229adf7a12"), new Guid("1bf8fb7e-98c3-4f7a-9362-aff5a4e52b89"), new Guid("e30a23c4-483f-465d-9aae-7ece9672529a") },
                    { new Guid("da393945-d792-40a1-9f60-8b370de5f8e0"), new Guid("7d5321fc-68e5-4fa3-ada0-ef9a253ad07c"), new Guid("88ade2e2-887f-4fd4-b9c9-b4d51e417a1d") },
                    { new Guid("dcc9b02f-2375-4ca7-bc3c-cc0ebea391d8"), new Guid("1bf8fb7e-98c3-4f7a-9362-aff5a4e52b89"), new Guid("3c7057a2-8aa1-4cfd-9602-5b694074b3a2") },
                    { new Guid("dd961e5e-fa2c-492f-838a-34555569d151"), new Guid("d1dfb589-afe3-4bb7-941c-485d5da9cab7"), new Guid("b61f2013-148c-4499-b809-e3f288372cee") },
                    { new Guid("de582186-208a-4968-9c29-5821e90f6b3a"), new Guid("dfcecf39-4461-4bb6-8694-97159a281379"), new Guid("67b8f824-7d46-4468-8d07-d6e014e52696") },
                    { new Guid("de5a80c6-b26c-4aab-86c7-0d2c5065b444"), new Guid("11630a15-b1a6-4c88-af3b-790bcf067d1a"), new Guid("c399d85b-658b-4a55-8337-c854d25962d0") },
                    { new Guid("df4e67d5-28ae-4fa0-a3c9-06d9677a9642"), new Guid("de216739-d6b5-4ab7-b853-6ef09d0a46e7"), new Guid("eb9a2c07-5952-4a63-be29-8a8fbac08208") },
                    { new Guid("e82c0d52-24a7-4081-b742-f21421758182"), new Guid("d94c6416-7e6b-4443-8774-f5493c62a5ab"), new Guid("2b0fdef8-18af-4e79-8006-184e4d0b1a54") },
                    { new Guid("e9d7959b-ea2b-4e02-bdbe-a6f82dffbfea"), new Guid("df22021f-7905-4399-a9fb-4f15511ddc51"), new Guid("8b8fb97a-d6de-43a1-b58e-e31d7dd1568f") },
                    { new Guid("ec8a69b0-be13-45f3-9f24-a4d57d5e3461"), new Guid("dfcecf39-4461-4bb6-8694-97159a281379"), new Guid("b4d82179-af2a-451a-9d9d-b6a6bf9774c0") },
                    { new Guid("eeb9ff3e-ff4b-4b86-b3b5-e168ba8dbca4"), new Guid("280c0aaf-109a-43fb-9963-340435e2a9ed"), new Guid("d45436d0-c6dd-4aec-b1e4-279f34af87ae") },
                    { new Guid("ef395918-4257-4105-843f-516a9c4e255f"), new Guid("9ca10874-46c7-4844-b809-7363a2aefc41"), new Guid("cb2392b6-8244-42b2-a504-a92ff5f04ac6") },
                    { new Guid("f035c3ec-dab4-4699-a92e-d6fad72c3fd9"), new Guid("7d5321fc-68e5-4fa3-ada0-ef9a253ad07c"), new Guid("7673a4f9-32ac-475c-a26f-b0569c163355") },
                    { new Guid("f70f0e4c-c6f0-4996-9b14-63fba55009c8"), new Guid("755a5941-e79e-464a-a039-636676e95501"), new Guid("290c569a-8e50-4a62-8551-a1fbff0b87f6") },
                    { new Guid("fab166d3-493b-4ddd-8234-bc443f0e61e7"), new Guid("11630a15-b1a6-4c88-af3b-790bcf067d1a"), new Guid("ee4a6cac-78c6-40f3-8a55-091609e658b9") },
                    { new Guid("fb79a2f8-3db4-4244-9b55-2dd710baf3b8"), new Guid("de216739-d6b5-4ab7-b853-6ef09d0a46e7"), new Guid("d2dad663-2c7b-4103-9ba0-a82a5248874e") },
                    { new Guid("fb7df210-f7fb-4277-adf3-ae8feb89d8eb"), new Guid("54abef42-7b5c-4f38-b5a7-7c364c48ebd6"), new Guid("823711fe-8907-4c92-a7fd-725b1f25e9e6") },
                    { new Guid("fc85032b-3b13-492c-adc2-3b1d6ca784de"), new Guid("282c0873-b614-446c-af49-0533f4e87250"), new Guid("5130611e-a97f-4ec3-9f41-c74b2894306e") }
                });

            migrationBuilder.InsertData(
                table: "UserPerformanceSummaries",
                columns: new[] { "Id", "CorrectAnswers", "CreatedAt", "LastUpdatedAt", "SuccessRate", "TopicId", "TotalQuestionsAnswered", "UserId" },
                values: new object[,]
                {
                    { new Guid("01faafd3-761c-411a-bd6e-0dde1d93bf79"), 14, new DateTime(2025, 7, 15, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5971), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5972), 66.670000000000002, new Guid("df22021f-7905-4399-a9fb-4f15511ddc51"), 21, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("022860b4-5abe-43a3-9c45-ab303b309096"), 20, new DateTime(2025, 7, 18, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5972), new DateTime(2025, 8, 8, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5973), 40.82, new Guid("e35c8f98-de4b-41ec-b972-87581897b868"), 49, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("05e2257b-c829-46e6-8579-7fe2c2e69381"), 16, new DateTime(2025, 7, 19, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5953), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5953), 45.710000000000001, new Guid("df22021f-7905-4399-a9fb-4f15511ddc51"), 35, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("1ca074ec-1e55-47ef-9670-f427227985cd"), 45, new DateTime(2025, 7, 31, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5966), new DateTime(2025, 8, 9, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5966), 63.380000000000003, new Guid("e35c8f98-de4b-41ec-b972-87581897b868"), 71, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("24d35cc1-b824-4c4f-b232-8e09275dbd79"), 47, new DateTime(2025, 8, 8, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5952), new DateTime(2025, 8, 9, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5952), 52.219999999999999, new Guid("6ce1703e-9fb5-43de-aad3-14ade52422e6"), 90, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("38f1edee-3794-47bc-bbba-59d023d1ac38"), 20, new DateTime(2025, 7, 22, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5950), new DateTime(2025, 8, 5, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5951), 51.280000000000001, new Guid("9ca10874-46c7-4844-b809-7363a2aefc41"), 39, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("55638aee-b01f-4a9f-86dd-6389490f1d6f"), 23, new DateTime(2025, 8, 5, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5970), new DateTime(2025, 8, 7, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5970), 30.670000000000002, new Guid("6ce1703e-9fb5-43de-aad3-14ade52422e6"), 75, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("5de83c7f-6063-4dea-8994-bf40e0ffbf29"), 13, new DateTime(2025, 7, 19, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5954), new DateTime(2025, 8, 4, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5955), 38.240000000000002, new Guid("e35c8f98-de4b-41ec-b972-87581897b868"), 34, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("61627f75-e0b5-4340-a1e2-30d9ee7655f4"), 19, new DateTime(2025, 7, 19, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5969), new DateTime(2025, 8, 5, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5969), 43.18, new Guid("9ca10874-46c7-4844-b809-7363a2aefc41"), 44, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("6eef6c59-6f3d-4852-a61e-82361bf5c683"), 8, new DateTime(2025, 7, 23, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5961), new DateTime(2025, 8, 10, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5961), 10.0, new Guid("6ce1703e-9fb5-43de-aad3-14ade52422e6"), 80, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("929af4bd-f4a5-4f04-a732-2695da406e7d"), 11, new DateTime(2025, 8, 1, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5962), new DateTime(2025, 8, 8, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5962), 68.75, new Guid("df22021f-7905-4399-a9fb-4f15511ddc51"), 16, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("cf9923af-fd52-45df-ae71-fe57dffc65e9"), 21, new DateTime(2025, 7, 14, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5960), new DateTime(2025, 8, 6, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5960), 63.640000000000001, new Guid("9ca10874-46c7-4844-b809-7363a2aefc41"), 33, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("e2eee3e0-3ff9-4e73-8bd3-0b59b3e10a11"), 43, new DateTime(2025, 8, 1, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5958), new DateTime(2025, 8, 5, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5959), 51.810000000000002, new Guid("11630a15-b1a6-4c88-af3b-790bcf067d1a"), 83, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("ed11169d-feb4-4383-97c0-9da4a2930447"), 59, new DateTime(2025, 7, 16, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5968), new DateTime(2025, 8, 5, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5968), 72.840000000000003, new Guid("11630a15-b1a6-4c88-af3b-790bcf067d1a"), 81, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("f6549edb-7626-48f5-9581-1c4bdbf286bb"), 7, new DateTime(2025, 7, 23, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5932), new DateTime(2025, 8, 6, 13, 3, 7, 211, DateTimeKind.Utc).AddTicks(5945), 63.640000000000001, new Guid("11630a15-b1a6-4c88-af3b-790bcf067d1a"), 11, new Guid("11111111-1111-1111-1111-111111111111") }
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
