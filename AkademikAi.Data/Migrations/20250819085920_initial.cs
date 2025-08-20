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
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "dummy-conc-1", new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(4781), "ali@example.com", true, false, null, "Ali", "ALI@EXAMPLE.COM", "ALI", "AQAAAAEAACcQAAAAEDummyHash1==", "5551111111", false, "dummy-stamp-1", "Veli", false, "ali", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "dummy-conc-2", new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(4794), "ayse@example.com", true, false, null, "Ayşe", "AYSE@EXAMPLE.COM", "AYSE", "AQAAAAEAACcQAAAAEDummyHash2==", "5552222222", false, "dummy-stamp-2", "Yılmaz", false, "ayse", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "dummy-conc-3", new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(4801), "mehmet@example.com", true, false, null, "Mehmet", "MEHMET@EXAMPLE.COM", "MEHMET", "AQAAAAEAACcQAAAAEDummyHash3==", "5553333333", false, "dummy-stamp-3", "Demir", false, "mehmet", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevel", "GeneratedForUserId", "IsActive", "QuestionText", "SolutionText", "Source" },
                values: new object[,]
                {
                    { new Guid("01123da1-d2a1-4415-ba58-f6004e605332"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("031d2734-9661-424d-bfba-c0ca3b7e064a"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("037190d4-8e1a-42b2-9323-61ef42e28e4d"), 1, null, true, "Kalıtım konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("049fee8f-68f6-43f5-894b-c33ec2e9dc5b"), 2, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("05fb4089-4e55-493a-9c60-c4d2b14abadd"), 1, null, true, "Kalıtım konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("06b5144b-beee-4416-9803-ba361525a802"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0fca0e45-4bdb-46a3-9758-247a6bd4b6f6"), 0, null, true, "Hücre konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("132395ce-a4ba-4b02-94c7-09430852659d"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("149b55cf-cb5f-4db4-84bd-b8323c0c5b02"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1506f0f8-c63b-448d-a755-f8fad6fe5178"), 2, null, true, "Elektrostatik konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1f1b61b6-fe91-47b4-ae5e-fe67c5572022"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("20d1bc7e-b726-4b4c-a457-b360bf13d0bb"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("219201fa-2193-4eec-9841-ce0630ba21e2"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2242ba31-2f36-45fd-9654-cd4a0ad06cfe"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("24086491-98e9-4ba8-98d7-29c1772273f4"), 2, null, true, "Sayı Basamakları konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2859ea6d-d9d3-4f1c-8056-7281a90d2c6d"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("30492025-193b-4e13-ac3e-9bafce3ff399"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("30e786d5-ff9d-466f-8e18-4e335781a400"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("31ab5fbc-ec35-4bde-a51a-33ffa49cf93a"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("34602e3e-874e-413f-a93b-6e74b404c7e9"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("359e29af-c30b-4a02-925f-d32515b399e2"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3d390e96-1db4-48d2-bcfa-9c65fb629bbe"), 2, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3ebb6445-472e-4d22-8ddf-5ee2c25f6093"), 2, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3f07b615-69f2-400e-ad98-d21393361e6d"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("40a17080-ad1c-4a74-8ba6-6e30ab9b7a2d"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4381c1f8-659b-4246-9fdd-4d86a75b6526"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("477c2e65-6cbf-4e49-98ef-0bfb3827577b"), 2, null, true, "Maddenin Halleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4799765c-95d2-4a71-adff-56a08e603796"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("485929f8-f73a-4bff-b877-9c9545a9926a"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("49907401-e696-42f3-b17b-491dc0adc0f8"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4caf9e43-f9ff-4924-ba8a-313192b17dfc"), 2, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("51731461-0c7c-433b-a156-f505bf54bbb8"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("553e4fec-f32c-4d0c-8a52-205912200563"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("55bd7d36-5f77-414a-b64d-9dc5d392922d"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("55ce4a0d-2d09-4efc-89be-db8636a01d5f"), 2, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5773dd6b-ad1b-44df-b182-3ecd5cacb444"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5abfc962-8876-4e49-83a0-7905b02eb2c3"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5e1e83e9-c678-43cc-9443-6995ebf5ebd4"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("62fdda1a-3f38-49c5-b64e-dca5b4c334e4"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("63db7bf2-8ef2-45e3-a891-458195868be3"), 2, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("65ca2093-15cc-427c-b990-d3fae47b7486"), 2, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("68f5cc43-4148-4a88-8e60-5cda2afe615f"), 0, null, true, "Kalıtım konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6a1f508e-558d-405f-8baa-ae5bef645920"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6ab00d47-7f4c-4bce-b57f-b8139f883308"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6e8b6912-713e-4f14-98a6-f802e1861b9a"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("70178320-869e-4944-b84c-33497ece5178"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("72b0b34f-010c-4c75-9e76-fbb979744991"), 2, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("76102e35-e5fd-4588-8252-e60146709d36"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("76964227-a124-48bf-9fa1-174c9248c52b"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("78424a8f-b95a-4d18-95bd-de73fd421eba"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7c927095-3270-43a6-b868-3afcae0c150a"), 2, null, true, "Problemler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("810d08b4-d0a1-4105-9f01-bb8751e9fcf5"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("845a716f-b70e-4842-a030-65f4a1c6a7a3"), 2, null, true, "Temel Kavramlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("889efa09-2b47-4f39-9d21-d5898a380bfc"), 0, null, true, "Hücre konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8b380dfc-9b7a-4069-95e4-b845887f2cfe"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8f9e62df-a97d-4b90-8bfa-0bb06396c733"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("925a894c-7b90-4057-9cdf-b0b694ab5441"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("95853a83-dfb6-445d-a9a4-5ab39441bebe"), 2, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("98297a09-075e-4888-aaa6-0737f6c2499a"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("99cc214c-8751-47f6-88eb-d105e9a585cf"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("99dafde6-2e94-4ed8-935d-5c21f62e781b"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a0ffefa6-89e0-46e2-a60e-7f0e93f75981"), 2, null, true, "Hücre konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a347f4cb-cf7c-4799-8e1c-da9222b7ad1a"), 1, null, true, "Problemler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a5346945-1e85-4ae2-83b1-feda6b9d0e44"), 0, null, true, "Kalıtım konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a53cd8f3-5a8f-41dc-8a14-38abc7655d16"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a8f934a8-bbb8-4b5b-86ee-1b4c0c923656"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ac056556-d749-4bbb-981c-1f339716762e"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b3cd5556-fb76-4d4d-8f35-f1ea44be02d7"), 1, null, true, "Hücre konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b5b0cf44-d158-4a91-a846-49f17e0b8ca9"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b8940e45-03fa-4a08-b9b7-a688f0d897ad"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("be71008a-2407-42a1-98f8-104f73006d58"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c008746c-1a35-487a-bffd-a79b313c71b5"), 2, null, true, "Kimya Bilimi konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c137ae71-10d9-4e6b-a64e-3005d37e6f23"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c8ef1250-040d-4442-a076-2202397740b4"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ced0c70b-bd0a-45a7-be9f-c416124c9b50"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("cfeb1231-c1b4-47dd-818a-97d2b4325428"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d0c9e410-0714-4b36-8fa9-cffa4b5044e0"), 0, null, true, "Problemler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d3e12b0a-2b5f-469f-8800-93ca078ab35d"), 2, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d4aa6c35-8637-4f4d-b541-53ee168913be"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d52b6387-3d3a-48d7-babd-1fdf131688a7"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("dab13ee4-cf71-4fe1-aedd-2822d80b2800"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("de98f8e2-e685-4492-8415-e1386fc212f1"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e1c693f7-6696-4296-9f2a-7924bbc7b5fb"), 0, null, true, "Problemler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e5807c07-fc86-4b46-8393-41214feb611b"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e7103035-5a6a-477a-9922-2e1bc58d94e3"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("eadc9125-0258-4b99-8659-01624cddbef0"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ee047b65-10e9-4c16-8c24-852b7f44b393"), 2, null, true, "Kalıtım konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ee068479-44ba-4c1d-a1e9-99c4c69b5308"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ee7e3d02-834a-4d37-9e7f-d0e3fd93790d"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ef3ef81e-0e60-43ad-8b49-a476fd451a00"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f2011f73-d59d-4829-a7ca-a538141c0420"), 1, null, true, "Hücre konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f30f7b45-25e1-4955-9226-c6b19cebfa7a"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f3167102-e1d5-406a-9ca9-b11a34970e15"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f37137fb-2c6c-4a6d-b160-bca270272d91"), 2, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f793b399-ac36-4f32-b056-021f0c81a4e8"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f9260246-da57-464b-9410-5963492b6db1"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fb54a481-abd8-431c-9e35-92bfd42ca67d"), 2, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fbd1c616-0823-45e9-a9fe-db86ccc55d09"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fee7f011-9c89-48b6-977d-887348bcbefa"), 1, null, true, "Problemler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ff184568-3c81-4e62-87ce-8a88b966c3e6"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5017), "Temel kimya konuları", true, "Kimya" },
                    { new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5013), "Temel fizik konuları", true, "Fizik" },
                    { new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5020), "Temel biyoloji konuları", true, "Biyoloji" },
                    { new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5007), "Temel matematik konuları", true, "Matematik" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "IsCorrect", "Label", "OptionOrder", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("00d853e2-37c5-4c0d-8112-24ad413ccb07"), true, "A", 1, "Temel Kavramlar - Soru 2 için Seçenek A", new Guid("be71008a-2407-42a1-98f8-104f73006d58") },
                    { new Guid("01312d99-7d1e-46ad-b148-8d9ada563045"), false, "D", 4, "Maddenin Halleri - Soru 5 için Seçenek D", new Guid("477c2e65-6cbf-4e49-98ef-0bfb3827577b") },
                    { new Guid("03931297-d53d-40be-a700-401482c64dc7"), false, "A", 1, "Kimya Bilimi - Soru 2 için Seçenek A", new Guid("4381c1f8-659b-4246-9fdd-4d86a75b6526") },
                    { new Guid("0409402b-6d5f-4d5c-9a5b-57920b63eaab"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek C", new Guid("55ce4a0d-2d09-4efc-89be-db8636a01d5f") },
                    { new Guid("04e47359-b7cd-481f-8ca5-ffefd8a8d320"), false, "A", 1, "Madde ve Özellikleri - Soru 1 için Seçenek A", new Guid("49907401-e696-42f3-b17b-491dc0adc0f8") },
                    { new Guid("0580e18a-1446-46d5-87e3-c78582895124"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek D", new Guid("a53cd8f3-5a8f-41dc-8a14-38abc7655d16") },
                    { new Guid("05a30f83-b334-4adf-b35b-1b91575f08eb"), false, "B", 2, "Kuvvet ve Hareket - Soru 5 için Seçenek B", new Guid("65ca2093-15cc-427c-b990-d3fae47b7486") },
                    { new Guid("0642dcd4-80b1-4eed-879b-db314f36de47"), false, "D", 4, "Hücre Bölünmeleri - Soru 2 için Seçenek D", new Guid("ee068479-44ba-4c1d-a1e9-99c4c69b5308") },
                    { new Guid("0762084e-38cf-4cfe-86a3-888ade7a2d1c"), false, "D", 4, "Hücre - Soru 4 için Seçenek D", new Guid("b3cd5556-fb76-4d4d-8f35-f1ea44be02d7") },
                    { new Guid("076e1abb-917a-46ec-9c7e-315d359aa19c"), true, "B", 2, "Elektrostatik - Soru 4 için Seçenek B", new Guid("76102e35-e5fd-4588-8252-e60146709d36") },
                    { new Guid("084911f2-c5dd-4faf-ac29-435893ad9965"), false, "D", 4, "Temel Kavramlar - Soru 2 için Seçenek D", new Guid("be71008a-2407-42a1-98f8-104f73006d58") },
                    { new Guid("0886ca4c-c824-4105-8171-842223340ad6"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek D", new Guid("55ce4a0d-2d09-4efc-89be-db8636a01d5f") },
                    { new Guid("08bbbe60-df81-4eeb-a824-433e9d5313a6"), false, "A", 1, "Bölme ve Bölünebilme - Soru 4 için Seçenek A", new Guid("01123da1-d2a1-4415-ba58-f6004e605332") },
                    { new Guid("0a17cb2d-bf32-4838-b536-0f3ef53fb0f0"), false, "C", 3, "Kimya Bilimi - Soru 1 için Seçenek C", new Guid("a8f934a8-bbb8-4b5b-86ee-1b4c0c923656") },
                    { new Guid("0aa212e8-2023-4da6-af91-93aac4bf915a"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek A", new Guid("63db7bf2-8ef2-45e3-a891-458195868be3") },
                    { new Guid("0adff4d7-c0de-4872-bfa2-58879de20d79"), true, "B", 2, "Madde ve Özellikleri - Soru 2 için Seçenek B", new Guid("62fdda1a-3f38-49c5-b64e-dca5b4c334e4") },
                    { new Guid("0c547483-57b7-4d5c-b8e0-9531dd865d1d"), false, "A", 1, "Maddenin Halleri - Soru 4 için Seçenek A", new Guid("925a894c-7b90-4057-9cdf-b0b694ab5441") },
                    { new Guid("0cda5a2a-a561-4a6b-bbce-d14c183224a3"), true, "D", 4, "Kalıtım - Soru 2 için Seçenek D", new Guid("037190d4-8e1a-42b2-9323-61ef42e28e4d") },
                    { new Guid("0e119515-b4da-4545-bb45-e42499c3bad8"), false, "A", 1, "Sayı Basamakları - Soru 4 için Seçenek A", new Guid("c137ae71-10d9-4e6b-a64e-3005d37e6f23") },
                    { new Guid("0e9c8e43-ff27-42a7-93eb-083f8e3b2561"), false, "B", 2, "Temel Kavramlar - Soru 2 için Seçenek B", new Guid("be71008a-2407-42a1-98f8-104f73006d58") },
                    { new Guid("0ef14935-0076-4fde-bf94-0fbd0a09cff9"), false, "C", 3, "Hücre - Soru 5 için Seçenek C", new Guid("a0ffefa6-89e0-46e2-a60e-7f0e93f75981") },
                    { new Guid("0ef1cbb1-4b7a-4aa0-9163-c06518602e22"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 3 için Seçenek C", new Guid("f793b399-ac36-4f32-b056-021f0c81a4e8") },
                    { new Guid("0fd2d847-ce3b-41f8-9283-cad0e22dce9b"), true, "A", 1, "Fizik Bilimine Giriş - Soru 2 için Seçenek A", new Guid("ef3ef81e-0e60-43ad-8b49-a476fd451a00") },
                    { new Guid("111bb204-a17b-482a-8ac3-587799b11471"), false, "B", 2, "Maddenin Halleri - Soru 4 için Seçenek B", new Guid("925a894c-7b90-4057-9cdf-b0b694ab5441") },
                    { new Guid("120a5073-aa9b-46f9-b383-2526a2a7cbbd"), true, "D", 4, "Madde ve Özellikleri - Soru 4 için Seçenek D", new Guid("70178320-869e-4944-b84c-33497ece5178") },
                    { new Guid("12bc2619-4631-4b0f-ab94-84bc6223bd4f"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek B", new Guid("6a1f508e-558d-405f-8baa-ae5bef645920") },
                    { new Guid("1558702e-58ca-4db0-bb00-446ab576c05c"), false, "A", 1, "Kuvvet ve Hareket - Soru 1 için Seçenek A", new Guid("76964227-a124-48bf-9fa1-174c9248c52b") },
                    { new Guid("1567c269-2450-49a3-b26f-1057e828c3a1"), true, "D", 4, "Kuvvet ve Hareket - Soru 3 için Seçenek D", new Guid("5773dd6b-ad1b-44df-b182-3ecd5cacb444") },
                    { new Guid("16681be6-9ed7-4093-a5d4-87e11039d811"), true, "B", 2, "Problemler - Soru 1 için Seçenek B", new Guid("e1c693f7-6696-4296-9f2a-7924bbc7b5fb") },
                    { new Guid("175be97e-301f-4bba-8435-b31e37b728fb"), false, "B", 2, "Sayı Basamakları - Soru 1 için Seçenek B", new Guid("2859ea6d-d9d3-4f1c-8056-7281a90d2c6d") },
                    { new Guid("17dfaa88-cbe5-43d8-ba73-c129a616eed2"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 1 için Seçenek D", new Guid("40a17080-ad1c-4a74-8ba6-6e30ab9b7a2d") },
                    { new Guid("184a537d-4831-4517-888a-2416f04f3216"), false, "B", 2, "Rasyonel Sayılar - Soru 4 için Seçenek B", new Guid("34602e3e-874e-413f-a93b-6e74b404c7e9") },
                    { new Guid("18cca507-20e4-4b47-9d3b-f767ef275f1e"), false, "A", 1, "Kuvvet ve Hareket - Soru 4 için Seçenek A", new Guid("553e4fec-f32c-4d0c-8a52-205912200563") },
                    { new Guid("18f78b27-f7cf-4dff-8027-1b7a878d4ba1"), false, "C", 3, "Hücre - Soru 3 için Seçenek C", new Guid("889efa09-2b47-4f39-9d21-d5898a380bfc") },
                    { new Guid("19a8fefc-c1bd-4b6d-a6f6-7def180f1136"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek B", new Guid("55ce4a0d-2d09-4efc-89be-db8636a01d5f") },
                    { new Guid("1a49d20d-d790-49d4-bef2-95f58c2108ea"), false, "A", 1, "Rasyonel Sayılar - Soru 2 için Seçenek A", new Guid("5abfc962-8876-4e49-83a0-7905b02eb2c3") },
                    { new Guid("1a9abfb7-f120-4555-a29a-ce72e73dc178"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 5 için Seçenek A", new Guid("f37137fb-2c6c-4a6d-b160-bca270272d91") },
                    { new Guid("1abc2682-1428-4483-b0dd-8461d4547ffe"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek D", new Guid("4caf9e43-f9ff-4924-ba8a-313192b17dfc") },
                    { new Guid("1af9ce01-2cc8-483b-8567-9684780ba79b"), false, "B", 2, "İş, Güç ve Enerji - Soru 4 için Seçenek B", new Guid("e7103035-5a6a-477a-9922-2e1bc58d94e3") },
                    { new Guid("1b62207e-0bac-4998-82bd-fa03e6712116"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 1 için Seçenek A", new Guid("40a17080-ad1c-4a74-8ba6-6e30ab9b7a2d") },
                    { new Guid("1b7ef5d5-f288-419c-a1fd-918bcb364782"), false, "B", 2, "Elektrostatik - Soru 3 için Seçenek B", new Guid("30492025-193b-4e13-ac3e-9bafce3ff399") },
                    { new Guid("1bdd4fa1-07fc-4f3d-96fb-23384523c66c"), true, "A", 1, "Maddenin Halleri - Soru 2 için Seçenek A", new Guid("031d2734-9661-424d-bfba-c0ca3b7e064a") },
                    { new Guid("1cbf366b-a1ad-44dc-aa96-da7496ea9f1f"), true, "A", 1, "Elektrostatik - Soru 5 için Seçenek A", new Guid("1506f0f8-c63b-448d-a755-f8fad6fe5178") },
                    { new Guid("1cc4119f-f75c-4a2c-9654-6a4995574a96"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek C", new Guid("a53cd8f3-5a8f-41dc-8a14-38abc7655d16") },
                    { new Guid("1cebe32e-76ab-4c80-9625-fbdee5ac00e6"), false, "B", 2, "Hücre Bölünmeleri - Soru 3 için Seçenek B", new Guid("ff184568-3c81-4e62-87ce-8a88b966c3e6") },
                    { new Guid("1deff749-2053-4b88-a36d-50aea09e4fe0"), false, "C", 3, "Temel Kavramlar - Soru 1 için Seçenek C", new Guid("20d1bc7e-b726-4b4c-a457-b360bf13d0bb") },
                    { new Guid("1edc264d-cd40-4849-9f1a-b44009c2a93b"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek D", new Guid("f9260246-da57-464b-9410-5963492b6db1") },
                    { new Guid("1fe70bb5-e7b3-4e89-a2e0-93d8cf9ca72c"), true, "B", 2, "Sayı Basamakları - Soru 3 için Seçenek B", new Guid("c8ef1250-040d-4442-a076-2202397740b4") },
                    { new Guid("2056416d-0ceb-4633-896c-a2fc906ee2da"), false, "B", 2, "Bölme ve Bölünebilme - Soru 4 için Seçenek B", new Guid("01123da1-d2a1-4415-ba58-f6004e605332") },
                    { new Guid("20acbe5d-f4b7-4235-9a2c-b60efba727bb"), false, "B", 2, "İş, Güç ve Enerji - Soru 5 için Seçenek B", new Guid("3ebb6445-472e-4d22-8ddf-5ee2c25f6093") },
                    { new Guid("21117c11-8e33-4014-ac34-ca5c0c3d5e52"), false, "D", 4, "Elektrostatik - Soru 5 için Seçenek D", new Guid("1506f0f8-c63b-448d-a755-f8fad6fe5178") },
                    { new Guid("214bef0c-4ed0-4391-b510-f51ccb8e8fb3"), true, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek B", new Guid("a53cd8f3-5a8f-41dc-8a14-38abc7655d16") },
                    { new Guid("22692b55-d687-4a9d-b32e-7aa5bca739ed"), true, "B", 2, "İş, Güç ve Enerji - Soru 3 için Seçenek B", new Guid("359e29af-c30b-4a02-925f-d32515b399e2") },
                    { new Guid("23575486-e1ed-44e6-83cc-2f5237f6f085"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek B", new Guid("4caf9e43-f9ff-4924-ba8a-313192b17dfc") },
                    { new Guid("23afff7e-1ba7-486f-8a1d-1cc02b9a7fd1"), false, "D", 4, "Problemler - Soru 4 için Seçenek D", new Guid("fee7f011-9c89-48b6-977d-887348bcbefa") },
                    { new Guid("245b04cc-a856-41d3-830a-b22dcca929dd"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek D", new Guid("1f1b61b6-fe91-47b4-ae5e-fe67c5572022") },
                    { new Guid("24dc3ff5-ebc8-44e1-a769-1b404012f146"), true, "C", 3, "Hücre Bölünmeleri - Soru 2 için Seçenek C", new Guid("ee068479-44ba-4c1d-a1e9-99c4c69b5308") },
                    { new Guid("25aeafbc-f87a-4d75-8215-ba2e92380181"), false, "D", 4, "Rasyonel Sayılar - Soru 4 için Seçenek D", new Guid("34602e3e-874e-413f-a93b-6e74b404c7e9") },
                    { new Guid("2686db7d-52b4-4bbb-9788-fed000b17054"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek A", new Guid("5e1e83e9-c678-43cc-9443-6995ebf5ebd4") },
                    { new Guid("2810ab66-b185-419e-9f38-cc4518882297"), false, "B", 2, "Kuvvet ve Hareket - Soru 3 için Seçenek B", new Guid("5773dd6b-ad1b-44df-b182-3ecd5cacb444") },
                    { new Guid("283d88a4-f2c1-4a4e-86b1-12033b212d96"), false, "C", 3, "Kuvvet ve Hareket - Soru 5 için Seçenek C", new Guid("65ca2093-15cc-427c-b990-d3fae47b7486") },
                    { new Guid("286e4393-d430-4c7b-a6a9-4450aa728017"), false, "A", 1, "Temel Kavramlar - Soru 1 için Seçenek A", new Guid("20d1bc7e-b726-4b4c-a457-b360bf13d0bb") },
                    { new Guid("28b2e505-3c7c-4154-ba40-4f61a144f577"), false, "B", 2, "Hücre - Soru 2 için Seçenek B", new Guid("f2011f73-d59d-4829-a7ca-a538141c0420") },
                    { new Guid("2935cf1e-9ad6-4a1b-8e21-b76123bd2cc3"), true, "C", 3, "Bölme ve Bölünebilme - Soru 1 için Seçenek C", new Guid("98297a09-075e-4888-aaa6-0737f6c2499a") },
                    { new Guid("29df955d-2a9d-4293-a40d-aff1d261070d"), true, "C", 3, "Kimya Bilimi - Soru 5 için Seçenek C", new Guid("c008746c-1a35-487a-bffd-a79b313c71b5") },
                    { new Guid("2a2f69a3-dd3f-487a-9b0d-03a53c18c2e1"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek A", new Guid("78424a8f-b95a-4d18-95bd-de73fd421eba") },
                    { new Guid("2b8c8ed0-e3b9-4aaa-a8e6-b3e8491cfc72"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek B", new Guid("6e8b6912-713e-4f14-98a6-f802e1861b9a") },
                    { new Guid("2f0fe919-f4b3-4f73-a465-e87d6e28e881"), false, "A", 1, "Kuvvet ve Hareket - Soru 3 için Seçenek A", new Guid("5773dd6b-ad1b-44df-b182-3ecd5cacb444") },
                    { new Guid("2f7a0cb5-d268-425d-adfb-7875f5653821"), false, "C", 3, "Kimya Bilimi - Soru 2 için Seçenek C", new Guid("4381c1f8-659b-4246-9fdd-4d86a75b6526") },
                    { new Guid("30cca50f-62cb-48c8-b953-3574f3224fab"), true, "D", 4, "Fizik Bilimine Giriş - Soru 1 için Seçenek D", new Guid("51731461-0c7c-433b-a156-f505bf54bbb8") },
                    { new Guid("315acfc1-ec05-42df-a51d-59339741fe3b"), false, "D", 4, "Kuvvet ve Hareket - Soru 2 için Seçenek D", new Guid("e5807c07-fc86-4b46-8393-41214feb611b") },
                    { new Guid("3236bd0c-a330-40f1-ade0-3a1d0572a71b"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek C", new Guid("06b5144b-beee-4416-9803-ba361525a802") },
                    { new Guid("3261bba4-ae31-476c-96d4-300271cac4eb"), true, "B", 2, "Rasyonel Sayılar - Soru 3 için Seçenek B", new Guid("810d08b4-d0a1-4105-9f01-bb8751e9fcf5") },
                    { new Guid("32f6793f-7af5-44b4-8730-fd947dc245cd"), false, "A", 1, "Kalıtım - Soru 2 için Seçenek A", new Guid("037190d4-8e1a-42b2-9323-61ef42e28e4d") },
                    { new Guid("337aae84-bff9-4417-a245-4a135b87cfc0"), false, "C", 3, "Hücre - Soru 1 için Seçenek C", new Guid("0fca0e45-4bdb-46a3-9758-247a6bd4b6f6") },
                    { new Guid("34268020-ce04-4cae-ae0a-74de1d3fbc34"), true, "B", 2, "Temel Kavramlar - Soru 4 için Seçenek B", new Guid("31ab5fbc-ec35-4bde-a51a-33ffa49cf93a") },
                    { new Guid("343ff591-f1ce-4bc2-9de6-a3fc0ced527a"), false, "B", 2, "Elektrostatik - Soru 2 için Seçenek B", new Guid("dab13ee4-cf71-4fe1-aedd-2822d80b2800") },
                    { new Guid("34d7dd4a-23cb-4c76-838d-aef0be51a4aa"), true, "A", 1, "Kuvvet ve Hareket - Soru 2 için Seçenek A", new Guid("e5807c07-fc86-4b46-8393-41214feb611b") },
                    { new Guid("350b1bd8-3a87-41c3-8b05-be547bb731b8"), false, "A", 1, "Bölme ve Bölünebilme - Soru 3 için Seçenek A", new Guid("fbd1c616-0823-45e9-a9fe-db86ccc55d09") },
                    { new Guid("36a213ac-5450-4ba0-aec2-cbb57c48f938"), false, "B", 2, "Problemler - Soru 2 için Seçenek B", new Guid("a347f4cb-cf7c-4799-8e1c-da9222b7ad1a") },
                    { new Guid("375be0ba-b427-4e54-85ae-ebc4a3f649a2"), true, "B", 2, "Hücre - Soru 5 için Seçenek B", new Guid("a0ffefa6-89e0-46e2-a60e-7f0e93f75981") },
                    { new Guid("375ce2ab-1b29-4719-914b-445462fdf0f4"), true, "B", 2, "Sayı Basamakları - Soru 4 için Seçenek B", new Guid("c137ae71-10d9-4e6b-a64e-3005d37e6f23") },
                    { new Guid("37f1f78e-4158-4df4-9d12-1d64833aa198"), false, "D", 4, "İş, Güç ve Enerji - Soru 1 için Seçenek D", new Guid("ee7e3d02-834a-4d37-9e7f-d0e3fd93790d") },
                    { new Guid("38c05211-0d02-4cce-b0d5-2178760ca38f"), false, "B", 2, "Bölme ve Bölünebilme - Soru 3 için Seçenek B", new Guid("fbd1c616-0823-45e9-a9fe-db86ccc55d09") },
                    { new Guid("3be9a0dd-b291-4477-a4e0-b2c4e5264d46"), false, "B", 2, "Bölme ve Bölünebilme - Soru 5 için Seçenek B", new Guid("95853a83-dfb6-445d-a9a4-5ab39441bebe") },
                    { new Guid("3c98d371-7be8-4dce-a5c8-1f4b3c257b56"), true, "B", 2, "Madde ve Özellikleri - Soru 3 için Seçenek B", new Guid("4799765c-95d2-4a71-adff-56a08e603796") },
                    { new Guid("3d04c039-ca16-4610-b98e-0ebec45499b4"), true, "D", 4, "İş, Güç ve Enerji - Soru 5 için Seçenek D", new Guid("3ebb6445-472e-4d22-8ddf-5ee2c25f6093") },
                    { new Guid("3fd5c01d-a98e-4475-aaae-a8d378a06298"), false, "B", 2, "Sayı Basamakları - Soru 5 için Seçenek B", new Guid("24086491-98e9-4ba8-98d7-29c1772273f4") },
                    { new Guid("3fed9db8-b0e5-4895-8aa6-3a2f2a1bdc2b"), true, "C", 3, "Elektrostatik - Soru 2 için Seçenek C", new Guid("dab13ee4-cf71-4fe1-aedd-2822d80b2800") },
                    { new Guid("40ee512a-f59b-4fa5-9386-69fa23897cd8"), false, "B", 2, "Fizik Bilimine Giriş - Soru 1 için Seçenek B", new Guid("51731461-0c7c-433b-a156-f505bf54bbb8") },
                    { new Guid("41eb7201-11c3-4ca4-adfe-5dd7137181dd"), true, "B", 2, "Fizik Bilimine Giriş - Soru 3 için Seçenek B", new Guid("f3167102-e1d5-406a-9ca9-b11a34970e15") },
                    { new Guid("42636314-f336-4371-abe4-9f8ce7852416"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 3 için Seçenek A", new Guid("f793b399-ac36-4f32-b056-021f0c81a4e8") },
                    { new Guid("42f4dc52-d0d1-41f8-a5da-3236506f81a4"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 2 için Seçenek D", new Guid("485929f8-f73a-4bff-b877-9c9545a9926a") },
                    { new Guid("43a5c753-f750-4cd6-b695-0d7f55de6113"), true, "C", 3, "Kalıtım - Soru 1 için Seçenek C", new Guid("a5346945-1e85-4ae2-83b1-feda6b9d0e44") },
                    { new Guid("445cbaf7-8547-4df5-ab58-3ce1d6cafa42"), false, "B", 2, "Temel Kavramlar - Soru 5 için Seçenek B", new Guid("845a716f-b70e-4842-a030-65f4a1c6a7a3") },
                    { new Guid("450f21d1-914b-44d7-8757-7e360e60526a"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 1 için Seçenek C", new Guid("30e786d5-ff9d-466f-8e18-4e335781a400") },
                    { new Guid("4540772b-f174-48c4-9260-05ff5726476d"), false, "B", 2, "Kalıtım - Soru 5 için Seçenek B", new Guid("ee047b65-10e9-4c16-8c24-852b7f44b393") },
                    { new Guid("459cb68f-f8cb-4ce9-973f-4af34a7e46f7"), false, "B", 2, "Kimya Bilimi - Soru 4 için Seçenek B", new Guid("d4aa6c35-8637-4f4d-b541-53ee168913be") },
                    { new Guid("46202095-75e5-4392-9f05-c68d9b339460"), true, "A", 1, "Sayı Basamakları - Soru 5 için Seçenek A", new Guid("24086491-98e9-4ba8-98d7-29c1772273f4") },
                    { new Guid("468d9646-06a7-41da-baa8-8f9e6645ed34"), true, "B", 2, "Madde ve Özellikleri - Soru 1 için Seçenek B", new Guid("49907401-e696-42f3-b17b-491dc0adc0f8") },
                    { new Guid("47121de4-b553-443d-9b91-c80942485262"), true, "B", 2, "Madde ve Özellikleri - Soru 5 için Seçenek B", new Guid("72b0b34f-010c-4c75-9e76-fbb979744991") },
                    { new Guid("47ae61be-8816-4284-9b7b-8ea9b2ad70f3"), false, "D", 4, "Maddenin Halleri - Soru 4 için Seçenek D", new Guid("925a894c-7b90-4057-9cdf-b0b694ab5441") },
                    { new Guid("4817762b-80c8-43f9-82ac-809383d25ce4"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek A", new Guid("1f1b61b6-fe91-47b4-ae5e-fe67c5572022") },
                    { new Guid("4863a0a1-553d-45af-930d-d31814ba9e71"), false, "D", 4, "Kimya Bilimi - Soru 4 için Seçenek D", new Guid("d4aa6c35-8637-4f4d-b541-53ee168913be") },
                    { new Guid("4879c65c-ea29-45e2-a559-afa87ae3ed18"), true, "C", 3, "Kalıtım - Soru 5 için Seçenek C", new Guid("ee047b65-10e9-4c16-8c24-852b7f44b393") },
                    { new Guid("48ed7811-ba76-4773-ad47-aa781e1d182c"), false, "C", 3, "Elektrostatik - Soru 1 için Seçenek C", new Guid("ac056556-d749-4bbb-981c-1f339716762e") },
                    { new Guid("499b57a3-61a6-4039-b104-e46912578638"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 3 için Seçenek A", new Guid("99dafde6-2e94-4ed8-935d-5c21f62e781b") },
                    { new Guid("4a5be662-4b87-482e-99b3-3f487003d03f"), false, "D", 4, "İş, Güç ve Enerji - Soru 3 için Seçenek D", new Guid("359e29af-c30b-4a02-925f-d32515b399e2") },
                    { new Guid("4aa78000-210b-4e42-9e71-7b92afda13fc"), false, "C", 3, "Hücre Bölünmeleri - Soru 1 için Seçenek C", new Guid("55bd7d36-5f77-414a-b64d-9dc5d392922d") },
                    { new Guid("4aab004d-6d10-49b7-ba8f-2a4ba4ab4123"), false, "A", 1, "Hücre - Soru 4 için Seçenek A", new Guid("b3cd5556-fb76-4d4d-8f35-f1ea44be02d7") },
                    { new Guid("4d2869ea-fce7-4b66-a363-b938a14c6c9e"), false, "D", 4, "Sayı Basamakları - Soru 2 için Seçenek D", new Guid("8b380dfc-9b7a-4069-95e4-b845887f2cfe") },
                    { new Guid("4def4289-4176-4d6d-a9c2-9f687389a7ef"), false, "D", 4, "Bölme ve Bölünebilme - Soru 5 için Seçenek D", new Guid("95853a83-dfb6-445d-a9a4-5ab39441bebe") },
                    { new Guid("4e75cda7-63de-4f5f-b36c-925b92a51db9"), true, "C", 3, "Rasyonel Sayılar - Soru 4 için Seçenek C", new Guid("34602e3e-874e-413f-a93b-6e74b404c7e9") },
                    { new Guid("4f855212-ff08-4a32-8417-14f09ea7f50e"), true, "B", 2, "Canlıların Sınıflandırılması - Soru 4 için Seçenek B", new Guid("219201fa-2193-4eec-9841-ce0630ba21e2") },
                    { new Guid("505547b0-0f50-4d1f-818d-be93f4cd0ce4"), true, "B", 2, "Kimya Bilimi - Soru 1 için Seçenek B", new Guid("a8f934a8-bbb8-4b5b-86ee-1b4c0c923656") },
                    { new Guid("50b35bc9-c91e-48ee-a814-7a7d4e2cabcd"), true, "D", 4, "Problemler - Soru 5 için Seçenek D", new Guid("7c927095-3270-43a6-b868-3afcae0c150a") },
                    { new Guid("511c7dba-7186-4ab7-86c6-2bec682af4f7"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek A", new Guid("8f9e62df-a97d-4b90-8bfa-0bb06396c733") },
                    { new Guid("51d10754-0997-4d62-bbde-0734d2ed3a04"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 4 için Seçenek D", new Guid("219201fa-2193-4eec-9841-ce0630ba21e2") },
                    { new Guid("5221a166-e807-40eb-b0da-87654c296a93"), false, "A", 1, "Fizik Bilimine Giriş - Soru 5 için Seçenek A", new Guid("3d390e96-1db4-48d2-bcfa-9c65fb629bbe") },
                    { new Guid("522805a3-10fa-463c-853e-479346cf5562"), false, "B", 2, "Problemler - Soru 3 için Seçenek B", new Guid("d0c9e410-0714-4b36-8fa9-cffa4b5044e0") },
                    { new Guid("5285c070-b8f3-4d67-a6e0-6f657f26d93a"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek B", new Guid("f9260246-da57-464b-9410-5963492b6db1") },
                    { new Guid("52cc56b1-97b0-4359-bb47-be54b5c4d7d5"), false, "C", 3, "Elektrostatik - Soru 5 için Seçenek C", new Guid("1506f0f8-c63b-448d-a755-f8fad6fe5178") },
                    { new Guid("52fdc477-de58-42eb-a513-37830b9f3c2b"), true, "C", 3, "Bölme ve Bölünebilme - Soru 5 için Seçenek C", new Guid("95853a83-dfb6-445d-a9a4-5ab39441bebe") },
                    { new Guid("53dec875-8c8e-4e2e-aaf2-d1968d8a0db0"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 5 için Seçenek D", new Guid("f37137fb-2c6c-4a6d-b160-bca270272d91") },
                    { new Guid("54700d71-b297-4297-8288-7318e2af0207"), false, "A", 1, "Madde ve Özellikleri - Soru 4 için Seçenek A", new Guid("70178320-869e-4944-b84c-33497ece5178") },
                    { new Guid("54cf6bdb-8e20-4959-89c2-8107f0fd8369"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek D", new Guid("ced0c70b-bd0a-45a7-be9f-c416124c9b50") },
                    { new Guid("564e0b57-db9e-42c8-9271-1bf9415c2eec"), false, "A", 1, "Sayı Basamakları - Soru 3 için Seçenek A", new Guid("c8ef1250-040d-4442-a076-2202397740b4") },
                    { new Guid("5852aaf5-d077-4813-9aa4-804725718d03"), false, "A", 1, "Bölme ve Bölünebilme - Soru 1 için Seçenek A", new Guid("98297a09-075e-4888-aaa6-0737f6c2499a") },
                    { new Guid("59480d91-8299-4e45-b545-6ef8646fc803"), true, "A", 1, "İş, Güç ve Enerji - Soru 4 için Seçenek A", new Guid("e7103035-5a6a-477a-9922-2e1bc58d94e3") },
                    { new Guid("5b3b7e3e-26fd-4751-bf8c-3ce9804b596d"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 1 için Seçenek B", new Guid("30e786d5-ff9d-466f-8e18-4e335781a400") },
                    { new Guid("5baec66a-e19b-4f6d-8f63-621b1f04eef7"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 2 için Seçenek C", new Guid("485929f8-f73a-4bff-b877-9c9545a9926a") },
                    { new Guid("5bd28175-1b2f-4d98-b27e-4cce06286074"), false, "A", 1, "Madde ve Özellikleri - Soru 5 için Seçenek A", new Guid("72b0b34f-010c-4c75-9e76-fbb979744991") },
                    { new Guid("5d7e81d5-92b5-443e-a532-8bb3e77dc8ed"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 4 için Seçenek B", new Guid("99cc214c-8751-47f6-88eb-d105e9a585cf") },
                    { new Guid("5fc29630-bd41-41f9-863d-344eb6ab8d78"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek A", new Guid("a53cd8f3-5a8f-41dc-8a14-38abc7655d16") },
                    { new Guid("61537f21-21c5-4171-8dfa-b9c91cee3885"), false, "B", 2, "Hücre Bölünmeleri - Soru 1 için Seçenek B", new Guid("55bd7d36-5f77-414a-b64d-9dc5d392922d") },
                    { new Guid("616503c3-5ff4-46f3-be53-50423045a870"), false, "A", 1, "Problemler - Soru 5 için Seçenek A", new Guid("7c927095-3270-43a6-b868-3afcae0c150a") },
                    { new Guid("61fb71db-f973-4adb-b5e1-3ca3e9e4c886"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 4 için Seçenek C", new Guid("99cc214c-8751-47f6-88eb-d105e9a585cf") },
                    { new Guid("626c75e0-b046-4202-96bd-762f2efa0933"), false, "A", 1, "Hücre Bölünmeleri - Soru 3 için Seçenek A", new Guid("ff184568-3c81-4e62-87ce-8a88b966c3e6") },
                    { new Guid("62d39dc3-ca0a-46f2-8345-aac6c8337bf5"), false, "D", 4, "Bölme ve Bölünebilme - Soru 2 için Seçenek D", new Guid("f30f7b45-25e1-4955-9226-c6b19cebfa7a") },
                    { new Guid("640654ab-dfa7-4852-8457-5f47f9572b91"), false, "C", 3, "Hücre Bölünmeleri - Soru 4 için Seçenek C", new Guid("eadc9125-0258-4b99-8659-01624cddbef0") },
                    { new Guid("663d426c-a8b3-4c9b-9cfc-bb491be27fc0"), false, "B", 2, "Fizik Bilimine Giriş - Soru 4 için Seçenek B", new Guid("132395ce-a4ba-4b02-94c7-09430852659d") },
                    { new Guid("6640edff-4346-4e4a-a3ef-b8eb92d0873d"), true, "D", 4, "Bölme ve Bölünebilme - Soru 3 için Seçenek D", new Guid("fbd1c616-0823-45e9-a9fe-db86ccc55d09") },
                    { new Guid("66bb5bc6-a1f3-4341-8fc1-8b1cc71b2fb0"), false, "C", 3, "İş, Güç ve Enerji - Soru 4 için Seçenek C", new Guid("e7103035-5a6a-477a-9922-2e1bc58d94e3") },
                    { new Guid("67a733ba-7336-41ee-88b9-a86c01b28bc5"), false, "D", 4, "Hücre Bölünmeleri - Soru 5 için Seçenek D", new Guid("fb54a481-abd8-431c-9e35-92bfd42ca67d") },
                    { new Guid("688f18bb-97c9-4f77-a4c1-0161392f3199"), false, "D", 4, "Temel Kavramlar - Soru 4 için Seçenek D", new Guid("31ab5fbc-ec35-4bde-a51a-33ffa49cf93a") },
                    { new Guid("68ea292c-1bb1-480f-ba5b-f99706d29c62"), false, "C", 3, "İş, Güç ve Enerji - Soru 3 için Seçenek C", new Guid("359e29af-c30b-4a02-925f-d32515b399e2") },
                    { new Guid("691572e6-d4c4-4865-abdd-222d5fa0aec4"), false, "D", 4, "İş, Güç ve Enerji - Soru 4 için Seçenek D", new Guid("e7103035-5a6a-477a-9922-2e1bc58d94e3") },
                    { new Guid("69ce7b49-45ed-4a05-b838-3dc9baab2f13"), false, "C", 3, "İş, Güç ve Enerji - Soru 5 için Seçenek C", new Guid("3ebb6445-472e-4d22-8ddf-5ee2c25f6093") },
                    { new Guid("69f7d034-496f-474f-84a6-f572fb042703"), false, "A", 1, "Sayı Basamakları - Soru 1 için Seçenek A", new Guid("2859ea6d-d9d3-4f1c-8056-7281a90d2c6d") },
                    { new Guid("6a5ed828-bd30-4f6e-9ece-10847682f6b7"), false, "D", 4, "Hücre Bölünmeleri - Soru 4 için Seçenek D", new Guid("eadc9125-0258-4b99-8659-01624cddbef0") },
                    { new Guid("6b968da5-ee60-42be-b617-74a58ad7b40a"), true, "B", 2, "Kimya Bilimi - Soru 2 için Seçenek B", new Guid("4381c1f8-659b-4246-9fdd-4d86a75b6526") },
                    { new Guid("6cdea0bc-4ed7-4a6c-9bb6-a9fd58e57736"), false, "D", 4, "Temel Kavramlar - Soru 3 için Seçenek D", new Guid("b8940e45-03fa-4a08-b9b7-a688f0d897ad") },
                    { new Guid("6cfb7295-ff89-4aaa-ac7c-45ae01b5f36c"), false, "C", 3, "Fizik Bilimine Giriş - Soru 5 için Seçenek C", new Guid("3d390e96-1db4-48d2-bcfa-9c65fb629bbe") },
                    { new Guid("6d3710e6-5f9e-41c8-bb0d-6d2f65fe7401"), false, "A", 1, "Kimya Bilimi - Soru 4 için Seçenek A", new Guid("d4aa6c35-8637-4f4d-b541-53ee168913be") },
                    { new Guid("6d9df725-7de1-4a0a-bd14-1879174b6694"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 5 için Seçenek B", new Guid("f37137fb-2c6c-4a6d-b160-bca270272d91") },
                    { new Guid("6e17296c-3052-4e3a-8ac7-ecd9dd669bbc"), false, "B", 2, "Kalıtım - Soru 3 için Seçenek B", new Guid("68f5cc43-4148-4a88-8e60-5cda2afe615f") },
                    { new Guid("6ec39d10-9bf8-4971-b1b2-d3fee4dbe006"), false, "C", 3, "Rasyonel Sayılar - Soru 1 için Seçenek C", new Guid("b5b0cf44-d158-4a91-a846-49f17e0b8ca9") },
                    { new Guid("6f2409db-e97c-4cd2-b7d5-af8e3636f02f"), false, "C", 3, "Madde ve Özellikleri - Soru 2 için Seçenek C", new Guid("62fdda1a-3f38-49c5-b64e-dca5b4c334e4") },
                    { new Guid("71502211-85b2-4c78-b8f4-5b0178b7aa98"), false, "A", 1, "Hücre Bölünmeleri - Soru 2 için Seçenek A", new Guid("ee068479-44ba-4c1d-a1e9-99c4c69b5308") },
                    { new Guid("718871af-a93e-48f6-ae01-d1be5acdfe71"), false, "D", 4, "Madde ve Özellikleri - Soru 3 için Seçenek D", new Guid("4799765c-95d2-4a71-adff-56a08e603796") },
                    { new Guid("71a802e6-bbe3-443f-b6c7-5b0f8e844b70"), false, "D", 4, "Hücre - Soru 3 için Seçenek D", new Guid("889efa09-2b47-4f39-9d21-d5898a380bfc") },
                    { new Guid("727e26eb-531c-4b6e-b7ae-3743fd7e536d"), false, "D", 4, "Kalıtım - Soru 5 için Seçenek D", new Guid("ee047b65-10e9-4c16-8c24-852b7f44b393") },
                    { new Guid("74526be1-3865-4507-80e0-2472aef1fe68"), true, "D", 4, "Kalıtım - Soru 3 için Seçenek D", new Guid("68f5cc43-4148-4a88-8e60-5cda2afe615f") },
                    { new Guid("7453c86f-8e95-43ed-86b2-8669df302b21"), false, "D", 4, "Madde ve Özellikleri - Soru 5 için Seçenek D", new Guid("72b0b34f-010c-4c75-9e76-fbb979744991") },
                    { new Guid("74624ba4-7675-4a94-8558-12c172553568"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek D", new Guid("63db7bf2-8ef2-45e3-a891-458195868be3") },
                    { new Guid("74dfef02-2ff0-4cfe-b2b8-5630a6724b3f"), true, "A", 1, "Hücre - Soru 3 için Seçenek A", new Guid("889efa09-2b47-4f39-9d21-d5898a380bfc") },
                    { new Guid("754da45c-11bb-479f-b254-a3213003feaa"), false, "A", 1, "Kalıtım - Soru 1 için Seçenek A", new Guid("a5346945-1e85-4ae2-83b1-feda6b9d0e44") },
                    { new Guid("75b08ed2-cec1-4572-b474-041f8a11244d"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek C", new Guid("de98f8e2-e685-4492-8415-e1386fc212f1") },
                    { new Guid("75b0ea57-2c0b-4445-9d6b-659b8f72d86e"), false, "B", 2, "İş, Güç ve Enerji - Soru 1 için Seçenek B", new Guid("ee7e3d02-834a-4d37-9e7f-d0e3fd93790d") },
                    { new Guid("75c722e4-73cf-4107-894f-e254d8c9798d"), false, "C", 3, "Problemler - Soru 2 için Seçenek C", new Guid("a347f4cb-cf7c-4799-8e1c-da9222b7ad1a") },
                    { new Guid("780621f4-c886-4561-b101-4abd6f6df2fe"), true, "C", 3, "Kimya Bilimi - Soru 4 için Seçenek C", new Guid("d4aa6c35-8637-4f4d-b541-53ee168913be") },
                    { new Guid("78161399-3d9b-4e45-8cd2-2d7d7cf16618"), false, "A", 1, "Kimya Bilimi - Soru 1 için Seçenek A", new Guid("a8f934a8-bbb8-4b5b-86ee-1b4c0c923656") },
                    { new Guid("796aab89-fd64-4646-8b69-c086e3a308c1"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek C", new Guid("6e8b6912-713e-4f14-98a6-f802e1861b9a") },
                    { new Guid("79859774-af4e-4b1d-b1a4-bb59fa22045a"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek D", new Guid("5e1e83e9-c678-43cc-9443-6995ebf5ebd4") },
                    { new Guid("7aecbd0b-e882-4a51-b127-1130595f1166"), true, "C", 3, "Kimya Bilimi - Soru 3 için Seçenek C", new Guid("149b55cf-cb5f-4db4-84bd-b8323c0c5b02") },
                    { new Guid("7b3fe379-71ac-46f9-b91f-5f03abab6b0c"), false, "A", 1, "Madde ve Özellikleri - Soru 2 için Seçenek A", new Guid("62fdda1a-3f38-49c5-b64e-dca5b4c334e4") },
                    { new Guid("7b4655dc-d64b-4a13-b208-4a7c1c32563b"), false, "B", 2, "Fizik Bilimine Giriş - Soru 2 için Seçenek B", new Guid("ef3ef81e-0e60-43ad-8b49-a476fd451a00") },
                    { new Guid("7c3a67e5-daae-4da9-9dae-3a723e2fb6c8"), false, "A", 1, "Temel Kavramlar - Soru 5 için Seçenek A", new Guid("845a716f-b70e-4842-a030-65f4a1c6a7a3") },
                    { new Guid("7c78c4bd-0ca9-4c0b-8add-f3e7024863ad"), true, "D", 4, "Kuvvet ve Hareket - Soru 5 için Seçenek D", new Guid("65ca2093-15cc-427c-b990-d3fae47b7486") },
                    { new Guid("7d7bc821-a107-45b0-ac3e-d6be40e7873a"), false, "A", 1, "Bölme ve Bölünebilme - Soru 5 için Seçenek A", new Guid("95853a83-dfb6-445d-a9a4-5ab39441bebe") },
                    { new Guid("7e469d61-b3ff-4473-b276-7fd4c234352f"), false, "B", 2, "Sayı Basamakları - Soru 2 için Seçenek B", new Guid("8b380dfc-9b7a-4069-95e4-b845887f2cfe") },
                    { new Guid("7ec903b5-4481-43e3-a340-ca2fc4618e7f"), false, "D", 4, "Kimya Bilimi - Soru 3 için Seçenek D", new Guid("149b55cf-cb5f-4db4-84bd-b8323c0c5b02") },
                    { new Guid("7fd8ab48-4982-46b8-9363-45539d26e55b"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 1 için Seçenek C", new Guid("40a17080-ad1c-4a74-8ba6-6e30ab9b7a2d") },
                    { new Guid("800269d1-3525-4df1-9c23-9ef1cc35d4c2"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek B", new Guid("3f07b615-69f2-400e-ad98-d21393361e6d") },
                    { new Guid("836cabde-9c5a-41bc-b1ca-1db458b6e6d6"), false, "C", 3, "Hücre Bölünmeleri - Soru 3 için Seçenek C", new Guid("ff184568-3c81-4e62-87ce-8a88b966c3e6") },
                    { new Guid("83cfa6a4-91f7-4341-bf7b-36712b2b8b59"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek D", new Guid("3f07b615-69f2-400e-ad98-d21393361e6d") },
                    { new Guid("846cb8f4-bc55-4d99-9c9a-4550c217c41a"), false, "B", 2, "Kalıtım - Soru 4 için Seçenek B", new Guid("05fb4089-4e55-493a-9c60-c4d2b14abadd") },
                    { new Guid("85f7048a-f3d3-40cb-9310-7003fb0109ac"), false, "D", 4, "Maddenin Halleri - Soru 3 için Seçenek D", new Guid("d52b6387-3d3a-48d7-babd-1fdf131688a7") },
                    { new Guid("86691678-e23c-40f0-af59-3cd0f79cc4a1"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek D", new Guid("78424a8f-b95a-4d18-95bd-de73fd421eba") },
                    { new Guid("86c01643-4cd6-4859-a491-189a3e329ff6"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek C", new Guid("63db7bf2-8ef2-45e3-a891-458195868be3") },
                    { new Guid("8a0c5746-b0c0-487d-a244-855168142602"), false, "C", 3, "İş, Güç ve Enerji - Soru 2 için Seçenek C", new Guid("2242ba31-2f36-45fd-9654-cd4a0ad06cfe") },
                    { new Guid("8aa54e20-8afd-416c-bed3-3b14610a81f3"), true, "D", 4, "Kalıtım - Soru 4 için Seçenek D", new Guid("05fb4089-4e55-493a-9c60-c4d2b14abadd") },
                    { new Guid("8acb6867-bf45-49b9-aa69-206cb2fac788"), false, "C", 3, "Problemler - Soru 3 için Seçenek C", new Guid("d0c9e410-0714-4b36-8fa9-cffa4b5044e0") },
                    { new Guid("8bccca82-493b-4ddf-8735-de7721fa439b"), false, "D", 4, "Temel Kavramlar - Soru 5 için Seçenek D", new Guid("845a716f-b70e-4842-a030-65f4a1c6a7a3") },
                    { new Guid("8c3fbb98-6a44-4bb5-9594-c8e5a947b2ec"), true, "A", 1, "Canlıların Sınıflandırılması - Soru 2 için Seçenek A", new Guid("6ab00d47-7f4c-4bce-b57f-b8139f883308") },
                    { new Guid("8cca3df4-aa1e-4655-a448-428530f8ed1f"), false, "D", 4, "Madde ve Özellikleri - Soru 1 için Seçenek D", new Guid("49907401-e696-42f3-b17b-491dc0adc0f8") },
                    { new Guid("8d5189aa-50c7-47d7-a37c-183cc32b3c52"), false, "C", 3, "Maddenin Halleri - Soru 3 için Seçenek C", new Guid("d52b6387-3d3a-48d7-babd-1fdf131688a7") },
                    { new Guid("8e1ef8af-e833-4ef1-82c1-948f33e48eb5"), false, "D", 4, "Kimya Bilimi - Soru 5 için Seçenek D", new Guid("c008746c-1a35-487a-bffd-a79b313c71b5") },
                    { new Guid("8e576775-3b72-468f-8d9f-188b22869fae"), false, "D", 4, "Maddenin Halleri - Soru 2 için Seçenek D", new Guid("031d2734-9661-424d-bfba-c0ca3b7e064a") },
                    { new Guid("8eb02ec4-90fb-4b19-959c-51e763bf2476"), true, "B", 2, "Hücre Bölünmeleri - Soru 4 için Seçenek B", new Guid("eadc9125-0258-4b99-8659-01624cddbef0") },
                    { new Guid("8ec6a9ec-3182-4790-ad46-5d0c7975fe4c"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek A", new Guid("3f07b615-69f2-400e-ad98-d21393361e6d") },
                    { new Guid("8f84d921-3494-442a-b04b-638ba8cac6c7"), true, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek C", new Guid("1f1b61b6-fe91-47b4-ae5e-fe67c5572022") },
                    { new Guid("8fdc9b28-13b8-4120-8507-964df25cbff4"), true, "C", 3, "Maddenin Halleri - Soru 4 için Seçenek C", new Guid("925a894c-7b90-4057-9cdf-b0b694ab5441") },
                    { new Guid("8fffa500-7102-42b1-b66c-eab6412f0d58"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek C", new Guid("4caf9e43-f9ff-4924-ba8a-313192b17dfc") },
                    { new Guid("90a38dba-4bc4-4bd5-a06c-b248ab95dab8"), true, "B", 2, "Hücre - Soru 1 için Seçenek B", new Guid("0fca0e45-4bdb-46a3-9758-247a6bd4b6f6") },
                    { new Guid("90fbaace-7d32-476b-83fc-c124cef8c2ec"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 2 için Seçenek D", new Guid("6ab00d47-7f4c-4bce-b57f-b8139f883308") },
                    { new Guid("91ace2be-7c94-47d7-922f-01d0be7d4065"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek A", new Guid("06b5144b-beee-4416-9803-ba361525a802") },
                    { new Guid("9364e069-c706-4b53-8fdc-c5588e6405bf"), false, "B", 2, "İş, Güç ve Enerji - Soru 2 için Seçenek B", new Guid("2242ba31-2f36-45fd-9654-cd4a0ad06cfe") },
                    { new Guid("93fce687-f311-4d4d-8e29-8af28bd99475"), false, "D", 4, "Fizik Bilimine Giriş - Soru 3 için Seçenek D", new Guid("f3167102-e1d5-406a-9ca9-b11a34970e15") },
                    { new Guid("9585888a-2e49-4408-906c-47eebdf853a8"), false, "D", 4, "Maddenin Halleri - Soru 1 için Seçenek D", new Guid("cfeb1231-c1b4-47dd-818a-97d2b4325428") },
                    { new Guid("95d0d27e-d3ba-4e83-a7f3-18f8e5eb7d28"), false, "A", 1, "İş, Güç ve Enerji - Soru 3 için Seçenek A", new Guid("359e29af-c30b-4a02-925f-d32515b399e2") },
                    { new Guid("9638d238-59a5-4b72-bc27-66ebf17f24d6"), false, "D", 4, "Rasyonel Sayılar - Soru 3 için Seçenek D", new Guid("810d08b4-d0a1-4105-9f01-bb8751e9fcf5") },
                    { new Guid("9649f2a9-b70b-4786-bd37-bd100358b029"), false, "B", 2, "Madde ve Özellikleri - Soru 4 için Seçenek B", new Guid("70178320-869e-4944-b84c-33497ece5178") },
                    { new Guid("965f91fe-f52a-4d5d-bd9b-3149e35456e8"), true, "A", 1, "Problemler - Soru 2 için Seçenek A", new Guid("a347f4cb-cf7c-4799-8e1c-da9222b7ad1a") },
                    { new Guid("9810626f-168a-40bc-9bf4-ec7f087b0e32"), false, "D", 4, "Bölme ve Bölünebilme - Soru 1 için Seçenek D", new Guid("98297a09-075e-4888-aaa6-0737f6c2499a") },
                    { new Guid("98aa01c6-acbc-42ca-b7f4-5a888b39df5b"), false, "B", 2, "Kuvvet ve Hareket - Soru 4 için Seçenek B", new Guid("553e4fec-f32c-4d0c-8a52-205912200563") },
                    { new Guid("98ccd756-d026-4585-a730-6fe791284936"), true, "C", 3, "Maddenin Halleri - Soru 5 için Seçenek C", new Guid("477c2e65-6cbf-4e49-98ef-0bfb3827577b") },
                    { new Guid("99d9476d-fd85-420a-80b9-4cd9d065e0a5"), false, "A", 1, "Kalıtım - Soru 3 için Seçenek A", new Guid("68f5cc43-4148-4a88-8e60-5cda2afe615f") },
                    { new Guid("9aa0b53f-d959-4416-a840-d0bd1be3eea9"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek A", new Guid("de98f8e2-e685-4492-8415-e1386fc212f1") },
                    { new Guid("9b27fe3f-215e-4128-861c-2e7921c10806"), false, "A", 1, "Fizik Bilimine Giriş - Soru 4 için Seçenek A", new Guid("132395ce-a4ba-4b02-94c7-09430852659d") },
                    { new Guid("9b940f78-8048-4bfe-b0f9-5944f3af104e"), false, "B", 2, "Rasyonel Sayılar - Soru 5 için Seçenek B", new Guid("049fee8f-68f6-43f5-894b-c33ec2e9dc5b") },
                    { new Guid("9ce97279-219d-4b93-843f-0e7029f12726"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 1 için Seçenek D", new Guid("30e786d5-ff9d-466f-8e18-4e335781a400") },
                    { new Guid("9fdb90d4-63d9-43a5-be81-e6b732e51420"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 1 için Seçenek B", new Guid("40a17080-ad1c-4a74-8ba6-6e30ab9b7a2d") },
                    { new Guid("a0392d6a-c174-420b-9a87-349ef58445b8"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek A", new Guid("f9260246-da57-464b-9410-5963492b6db1") },
                    { new Guid("a0c43219-a26d-45f0-b023-22993c773e1f"), false, "A", 1, "Hücre - Soru 2 için Seçenek A", new Guid("f2011f73-d59d-4829-a7ca-a538141c0420") },
                    { new Guid("a1857e8c-b3ce-4ad3-aa62-f139bc2230d9"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 2 için Seçenek B", new Guid("485929f8-f73a-4bff-b877-9c9545a9926a") },
                    { new Guid("a18a8e64-a38f-4c40-888b-cfad7d03ed36"), true, "C", 3, "Problemler - Soru 4 için Seçenek C", new Guid("fee7f011-9c89-48b6-977d-887348bcbefa") },
                    { new Guid("a227369c-b87c-434e-bb00-80faeb19f4aa"), false, "D", 4, "Kuvvet ve Hareket - Soru 1 için Seçenek D", new Guid("76964227-a124-48bf-9fa1-174c9248c52b") },
                    { new Guid("a3ef4b78-70af-4ef9-9ae8-75688d47a96e"), false, "D", 4, "Fizik Bilimine Giriş - Soru 2 için Seçenek D", new Guid("ef3ef81e-0e60-43ad-8b49-a476fd451a00") },
                    { new Guid("a4ed1b83-1f6d-4755-8132-c34beab8b75f"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 2 için Seçenek A", new Guid("485929f8-f73a-4bff-b877-9c9545a9926a") },
                    { new Guid("a567f3ee-712d-4b59-9de4-2e36de9a970f"), false, "A", 1, "Hücre - Soru 1 için Seçenek A", new Guid("0fca0e45-4bdb-46a3-9758-247a6bd4b6f6") },
                    { new Guid("a62682b2-849d-4c1e-9267-47f7b5d5a270"), false, "A", 1, "Kuvvet ve Hareket - Soru 5 için Seçenek A", new Guid("65ca2093-15cc-427c-b990-d3fae47b7486") },
                    { new Guid("a635cbbc-7f7b-4d41-9f78-64ad879e7c63"), false, "C", 3, "Kalıtım - Soru 3 için Seçenek C", new Guid("68f5cc43-4148-4a88-8e60-5cda2afe615f") },
                    { new Guid("a64a092b-f171-4389-ab91-d901ff6c139e"), true, "B", 2, "Temel Kavramlar - Soru 1 için Seçenek B", new Guid("20d1bc7e-b726-4b4c-a457-b360bf13d0bb") },
                    { new Guid("a64aa44d-89a2-4d8d-a928-fc5a28721df8"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek A", new Guid("6a1f508e-558d-405f-8baa-ae5bef645920") },
                    { new Guid("a6ae7f95-a50f-40a6-ace0-ff61a0ea181f"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 3 için Seçenek D", new Guid("99dafde6-2e94-4ed8-935d-5c21f62e781b") },
                    { new Guid("a6f5da52-fde8-4bc3-8057-7759384e222d"), false, "B", 2, "Bölme ve Bölünebilme - Soru 2 için Seçenek B", new Guid("f30f7b45-25e1-4955-9226-c6b19cebfa7a") },
                    { new Guid("a7729860-45bb-4305-a756-1d41d920deea"), true, "C", 3, "Rasyonel Sayılar - Soru 2 için Seçenek C", new Guid("5abfc962-8876-4e49-83a0-7905b02eb2c3") },
                    { new Guid("a7cd6da2-dc4a-4aee-942a-58bbf71e3847"), false, "C", 3, "Maddenin Halleri - Soru 1 için Seçenek C", new Guid("cfeb1231-c1b4-47dd-818a-97d2b4325428") },
                    { new Guid("a7f47af3-fd60-447c-a044-3eebf528b6d9"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek D", new Guid("6e8b6912-713e-4f14-98a6-f802e1861b9a") },
                    { new Guid("a853650b-d372-4aae-88a1-78a394f5f233"), false, "D", 4, "Rasyonel Sayılar - Soru 2 için Seçenek D", new Guid("5abfc962-8876-4e49-83a0-7905b02eb2c3") },
                    { new Guid("a8c13053-3293-4ed9-8e35-9b50942385a8"), false, "A", 1, "Kimya Bilimi - Soru 5 için Seçenek A", new Guid("c008746c-1a35-487a-bffd-a79b313c71b5") },
                    { new Guid("a8fdbfb2-a21e-4f5b-9f35-8f5de5c208e1"), false, "C", 3, "Sayı Basamakları - Soru 1 için Seçenek C", new Guid("2859ea6d-d9d3-4f1c-8056-7281a90d2c6d") },
                    { new Guid("a9286e23-0390-41bc-9256-383464444502"), false, "D", 4, "Fizik Bilimine Giriş - Soru 4 için Seçenek D", new Guid("132395ce-a4ba-4b02-94c7-09430852659d") },
                    { new Guid("a9b68974-aa1a-4d75-838b-ec4385652c38"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek B", new Guid("63db7bf2-8ef2-45e3-a891-458195868be3") },
                    { new Guid("aa1a8ea4-3941-4523-9726-fb8f2ec3e70e"), false, "C", 3, "Fizik Bilimine Giriş - Soru 1 için Seçenek C", new Guid("51731461-0c7c-433b-a156-f505bf54bbb8") },
                    { new Guid("ab0c9937-a5a9-4310-a826-b541243a2ddf"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 5 için Seçenek C", new Guid("d3e12b0a-2b5f-469f-8800-93ca078ab35d") },
                    { new Guid("abf32fc9-0277-4755-ba2e-9c1ea9534bd4"), true, "D", 4, "Hücre Bölünmeleri - Soru 3 için Seçenek D", new Guid("ff184568-3c81-4e62-87ce-8a88b966c3e6") },
                    { new Guid("abf5656d-04c9-4682-a8f1-aa315f032963"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 2 için Seçenek B", new Guid("6ab00d47-7f4c-4bce-b57f-b8139f883308") },
                    { new Guid("ac1f4988-eed5-4604-bc3c-925b300aed17"), true, "C", 3, "Temel Kavramlar - Soru 5 için Seçenek C", new Guid("845a716f-b70e-4842-a030-65f4a1c6a7a3") },
                    { new Guid("ac4acfe8-2a93-426b-b231-e8ac7da344c9"), false, "C", 3, "Sayı Basamakları - Soru 4 için Seçenek C", new Guid("c137ae71-10d9-4e6b-a64e-3005d37e6f23") },
                    { new Guid("ac528760-6a1b-4f68-abc9-e1fcbfbd9fa5"), false, "C", 3, "Sayı Basamakları - Soru 5 için Seçenek C", new Guid("24086491-98e9-4ba8-98d7-29c1772273f4") },
                    { new Guid("ac8017e5-113d-43e7-b14c-5033fd1a760f"), false, "A", 1, "Elektrostatik - Soru 2 için Seçenek A", new Guid("dab13ee4-cf71-4fe1-aedd-2822d80b2800") },
                    { new Guid("ace472b5-9de5-497e-935b-b34412c97e2d"), true, "C", 3, "Bölme ve Bölünebilme - Soru 2 için Seçenek C", new Guid("f30f7b45-25e1-4955-9226-c6b19cebfa7a") },
                    { new Guid("adfaff54-e9c6-4bc9-9794-1c5d4af296b2"), true, "D", 4, "Hücre Bölünmeleri - Soru 1 için Seçenek D", new Guid("55bd7d36-5f77-414a-b64d-9dc5d392922d") },
                    { new Guid("ae0bed26-c0b2-4f65-8a33-bdd36a7f05d0"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek B", new Guid("5e1e83e9-c678-43cc-9443-6995ebf5ebd4") },
                    { new Guid("ae4b1a76-1db1-4f6a-90f2-6a5cab2b6a0f"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 3 için Seçenek C", new Guid("99dafde6-2e94-4ed8-935d-5c21f62e781b") },
                    { new Guid("af5157b0-12ba-42e8-aafa-364806982f5f"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 4 için Seçenek A", new Guid("219201fa-2193-4eec-9841-ce0630ba21e2") },
                    { new Guid("b02d7947-3b1b-4ce7-9074-1ca005b32f8c"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 4 için Seçenek A", new Guid("99cc214c-8751-47f6-88eb-d105e9a585cf") },
                    { new Guid("b0599632-b5b4-43f7-a1d5-976ef80fb8a3"), false, "C", 3, "Kuvvet ve Hareket - Soru 2 için Seçenek C", new Guid("e5807c07-fc86-4b46-8393-41214feb611b") },
                    { new Guid("b130c8c8-3277-4e8b-b811-d522e7f07d82"), false, "D", 4, "Sayı Basamakları - Soru 4 için Seçenek D", new Guid("c137ae71-10d9-4e6b-a64e-3005d37e6f23") },
                    { new Guid("b19a8071-d69c-41dc-810b-b58cc37e7da9"), true, "C", 3, "Rasyonel Sayılar - Soru 5 için Seçenek C", new Guid("049fee8f-68f6-43f5-894b-c33ec2e9dc5b") },
                    { new Guid("b21c7f74-6dd1-4752-a8e9-1fdc9873fb1d"), false, "B", 2, "Hücre - Soru 4 için Seçenek B", new Guid("b3cd5556-fb76-4d4d-8f35-f1ea44be02d7") },
                    { new Guid("b21f3e17-3911-4d44-995d-351d42db1dea"), false, "D", 4, "Madde ve Özellikleri - Soru 2 için Seçenek D", new Guid("62fdda1a-3f38-49c5-b64e-dca5b4c334e4") },
                    { new Guid("b255ee69-ec8c-4bce-855c-faef5956105a"), false, "D", 4, "Rasyonel Sayılar - Soru 5 için Seçenek D", new Guid("049fee8f-68f6-43f5-894b-c33ec2e9dc5b") },
                    { new Guid("b25ce6bb-c026-4bf4-9d07-044d7aca4506"), false, "C", 3, "Hücre - Soru 2 için Seçenek C", new Guid("f2011f73-d59d-4829-a7ca-a538141c0420") },
                    { new Guid("b26087f2-b45a-4b28-8497-52af31b04cda"), false, "D", 4, "Elektrostatik - Soru 4 için Seçenek D", new Guid("76102e35-e5fd-4588-8252-e60146709d36") },
                    { new Guid("b4275add-dcbb-4ab8-94fb-4c2033b00020"), true, "C", 3, "Fizik Bilimine Giriş - Soru 4 için Seçenek C", new Guid("132395ce-a4ba-4b02-94c7-09430852659d") },
                    { new Guid("b4b81fb9-736e-4231-b9d3-adb9d0d5dea6"), false, "D", 4, "Problemler - Soru 1 için Seçenek D", new Guid("e1c693f7-6696-4296-9f2a-7924bbc7b5fb") },
                    { new Guid("b62f69fc-db54-4efc-aa5d-b56954c85feb"), false, "B", 2, "Bölme ve Bölünebilme - Soru 1 için Seçenek B", new Guid("98297a09-075e-4888-aaa6-0737f6c2499a") },
                    { new Guid("b68edb36-cd65-4361-91df-fee4a1934a1b"), false, "B", 2, "Hücre Bölünmeleri - Soru 2 için Seçenek B", new Guid("ee068479-44ba-4c1d-a1e9-99c4c69b5308") },
                    { new Guid("b6ef15fa-2fdd-4508-8660-df9e69059ead"), false, "A", 1, "Elektrostatik - Soru 1 için Seçenek A", new Guid("ac056556-d749-4bbb-981c-1f339716762e") },
                    { new Guid("b79ed5b7-2eff-4f33-8d2e-28f43ab502df"), false, "D", 4, "Rasyonel Sayılar - Soru 1 için Seçenek D", new Guid("b5b0cf44-d158-4a91-a846-49f17e0b8ca9") },
                    { new Guid("b7aeacbc-9785-4c37-9a26-aeb0f5b6191d"), false, "A", 1, "Problemler - Soru 4 için Seçenek A", new Guid("fee7f011-9c89-48b6-977d-887348bcbefa") },
                    { new Guid("b821b2c5-7c74-43a1-a781-63b99c913256"), false, "A", 1, "Rasyonel Sayılar - Soru 1 için Seçenek A", new Guid("b5b0cf44-d158-4a91-a846-49f17e0b8ca9") },
                    { new Guid("b8b1cb5a-70ab-4269-b25f-9c03a02eadb8"), false, "B", 2, "Hücre Bölünmeleri - Soru 5 için Seçenek B", new Guid("fb54a481-abd8-431c-9e35-92bfd42ca67d") },
                    { new Guid("b9ec5c2c-80d8-4476-bae9-3f98d65e1e9a"), false, "B", 2, "Maddenin Halleri - Soru 3 için Seçenek B", new Guid("d52b6387-3d3a-48d7-babd-1fdf131688a7") },
                    { new Guid("ba100447-84fb-4733-8fc5-f7256ee5ead5"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 4 için Seçenek D", new Guid("99cc214c-8751-47f6-88eb-d105e9a585cf") },
                    { new Guid("bb183e02-9972-4072-b8cb-2081005a2b99"), false, "B", 2, "Maddenin Halleri - Soru 1 için Seçenek B", new Guid("cfeb1231-c1b4-47dd-818a-97d2b4325428") },
                    { new Guid("bb25c513-d2ba-44ed-b7da-fe5e6efbf44b"), false, "A", 1, "Kalıtım - Soru 5 için Seçenek A", new Guid("ee047b65-10e9-4c16-8c24-852b7f44b393") },
                    { new Guid("bba370b2-88b8-43e6-b994-3812039e6a8a"), false, "A", 1, "Kimya Bilimi - Soru 3 için Seçenek A", new Guid("149b55cf-cb5f-4db4-84bd-b8323c0c5b02") },
                    { new Guid("bdc3e260-82e3-44f0-bd6b-7b0326e80dae"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 1 için Seçenek A", new Guid("30e786d5-ff9d-466f-8e18-4e335781a400") },
                    { new Guid("bde0d8a8-ffda-4226-a136-e7a2ff07ae3f"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek A", new Guid("4caf9e43-f9ff-4924-ba8a-313192b17dfc") },
                    { new Guid("bde3db00-0535-44fd-a1c8-dd942b2b85b0"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek D", new Guid("6a1f508e-558d-405f-8baa-ae5bef645920") },
                    { new Guid("be02bd65-9e5d-4e59-955c-4ba3ba5dcc2f"), false, "A", 1, "Problemler - Soru 1 için Seçenek A", new Guid("e1c693f7-6696-4296-9f2a-7924bbc7b5fb") },
                    { new Guid("be9e9f2f-c27c-4bc5-8743-be328cdacbb0"), false, "D", 4, "Hücre - Soru 5 için Seçenek D", new Guid("a0ffefa6-89e0-46e2-a60e-7f0e93f75981") },
                    { new Guid("c009a95e-0b1e-42c3-ac88-d1bf202a4159"), true, "D", 4, "Elektrostatik - Soru 1 için Seçenek D", new Guid("ac056556-d749-4bbb-981c-1f339716762e") },
                    { new Guid("c0193151-7689-426d-acf2-f9be2b1ed90d"), true, "D", 4, "Fizik Bilimine Giriş - Soru 5 için Seçenek D", new Guid("3d390e96-1db4-48d2-bcfa-9c65fb629bbe") },
                    { new Guid("c0c3725d-4b93-490f-8492-a4afcf06635d"), true, "D", 4, "Bölme ve Bölünebilme - Soru 4 için Seçenek D", new Guid("01123da1-d2a1-4415-ba58-f6004e605332") },
                    { new Guid("c2831f01-a02f-40a4-8001-60543cfeec83"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek D", new Guid("06b5144b-beee-4416-9803-ba361525a802") },
                    { new Guid("c2da7b11-794f-4548-aa1a-3b9a49650a92"), false, "B", 2, "Elektrostatik - Soru 5 için Seçenek B", new Guid("1506f0f8-c63b-448d-a755-f8fad6fe5178") },
                    { new Guid("c41c913e-fbd9-4e66-b44e-aa8ad4a6d8df"), false, "A", 1, "Problemler - Soru 3 için Seçenek A", new Guid("d0c9e410-0714-4b36-8fa9-cffa4b5044e0") },
                    { new Guid("c439dbd3-df0b-46b3-b836-70fd916580ad"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek D", new Guid("8f9e62df-a97d-4b90-8bfa-0bb06396c733") },
                    { new Guid("c5219148-0195-43cc-98fd-8a6947600144"), true, "B", 2, "Rasyonel Sayılar - Soru 1 için Seçenek B", new Guid("b5b0cf44-d158-4a91-a846-49f17e0b8ca9") },
                    { new Guid("c56903a2-bb68-4c01-bf57-2c4bbf4e6753"), false, "C", 3, "Temel Kavramlar - Soru 3 için Seçenek C", new Guid("b8940e45-03fa-4a08-b9b7-a688f0d897ad") },
                    { new Guid("c5f33710-50d9-42a5-813d-d557969559e2"), false, "C", 3, "Sayı Basamakları - Soru 3 için Seçenek C", new Guid("c8ef1250-040d-4442-a076-2202397740b4") },
                    { new Guid("c6d4005f-9826-42a5-a06f-a9b941e26d5e"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek A", new Guid("ced0c70b-bd0a-45a7-be9f-c416124c9b50") },
                    { new Guid("c74ea75c-102e-4970-89f1-48299f1d053a"), false, "A", 1, "Temel Kavramlar - Soru 3 için Seçenek A", new Guid("b8940e45-03fa-4a08-b9b7-a688f0d897ad") },
                    { new Guid("c8abbaf1-82e2-42f4-ba3c-44b7bfe09fe2"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek C", new Guid("5e1e83e9-c678-43cc-9443-6995ebf5ebd4") },
                    { new Guid("c961abd4-09d7-4394-8347-11de5ac00512"), false, "C", 3, "Madde ve Özellikleri - Soru 4 için Seçenek C", new Guid("70178320-869e-4944-b84c-33497ece5178") },
                    { new Guid("c99dddbf-c211-4a13-91eb-8b36ef4ee844"), false, "C", 3, "Madde ve Özellikleri - Soru 1 için Seçenek C", new Guid("49907401-e696-42f3-b17b-491dc0adc0f8") },
                    { new Guid("ca598b3b-f40e-4661-b18d-e4b03a408b13"), false, "B", 2, "Rasyonel Sayılar - Soru 2 için Seçenek B", new Guid("5abfc962-8876-4e49-83a0-7905b02eb2c3") },
                    { new Guid("cab798cf-f072-497b-9af8-cfbed2fd94a2"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek C", new Guid("8f9e62df-a97d-4b90-8bfa-0bb06396c733") },
                    { new Guid("cb88c53c-f836-4210-ade7-c0b55e49a6ff"), false, "A", 1, "Temel Kavramlar - Soru 4 için Seçenek A", new Guid("31ab5fbc-ec35-4bde-a51a-33ffa49cf93a") },
                    { new Guid("cc22b4a8-8e3f-4934-8b87-818ececd72e6"), false, "A", 1, "Madde ve Özellikleri - Soru 3 için Seçenek A", new Guid("4799765c-95d2-4a71-adff-56a08e603796") },
                    { new Guid("cdedfcfc-ea2d-486d-8a65-4274ffc65e1c"), false, "C", 3, "Kuvvet ve Hareket - Soru 4 için Seçenek C", new Guid("553e4fec-f32c-4d0c-8a52-205912200563") },
                    { new Guid("ce19a5e6-2b5b-4a99-a179-3123b0e5d272"), false, "A", 1, "Hücre - Soru 5 için Seçenek A", new Guid("a0ffefa6-89e0-46e2-a60e-7f0e93f75981") },
                    { new Guid("ce57506c-618b-446d-90d8-6c2e23ced0ca"), false, "A", 1, "Hücre Bölünmeleri - Soru 1 için Seçenek A", new Guid("55bd7d36-5f77-414a-b64d-9dc5d392922d") },
                    { new Guid("ce9df95f-517b-48a1-85fb-76717e3527a7"), false, "A", 1, "İş, Güç ve Enerji - Soru 5 için Seçenek A", new Guid("3ebb6445-472e-4d22-8ddf-5ee2c25f6093") },
                    { new Guid("ced91c4f-1b0f-4bd2-83f9-934f1ef1e936"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek A", new Guid("55ce4a0d-2d09-4efc-89be-db8636a01d5f") },
                    { new Guid("cf5c2617-0177-4978-b573-b4f07588d9b5"), false, "C", 3, "Bölme ve Bölünebilme - Soru 4 için Seçenek C", new Guid("01123da1-d2a1-4415-ba58-f6004e605332") },
                    { new Guid("d00fc963-a060-4605-80c6-f647cd126e0c"), false, "D", 4, "Elektrostatik - Soru 2 için Seçenek D", new Guid("dab13ee4-cf71-4fe1-aedd-2822d80b2800") },
                    { new Guid("d026ed1c-662c-4a04-979f-b2f3b49a15d1"), true, "A", 1, "Sayı Basamakları - Soru 2 için Seçenek A", new Guid("8b380dfc-9b7a-4069-95e4-b845887f2cfe") },
                    { new Guid("d0728815-0d30-47a6-92ad-bc40933f4ba7"), false, "B", 2, "Maddenin Halleri - Soru 2 için Seçenek B", new Guid("031d2734-9661-424d-bfba-c0ca3b7e064a") },
                    { new Guid("d077be71-607b-4153-928a-b2aa2b921e06"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek B", new Guid("1f1b61b6-fe91-47b4-ae5e-fe67c5572022") },
                    { new Guid("d0b9e9d2-d5bb-4ad5-bf4a-0e3753041424"), true, "D", 4, "Elektrostatik - Soru 3 için Seçenek D", new Guid("30492025-193b-4e13-ac3e-9bafce3ff399") },
                    { new Guid("d0d4933c-8656-4de4-9e8f-3d7874c1c6c4"), false, "A", 1, "Maddenin Halleri - Soru 5 için Seçenek A", new Guid("477c2e65-6cbf-4e49-98ef-0bfb3827577b") },
                    { new Guid("d0ea824f-04e0-4613-9904-d0ba16584f1e"), false, "C", 3, "Maddenin Halleri - Soru 2 için Seçenek C", new Guid("031d2734-9661-424d-bfba-c0ca3b7e064a") },
                    { new Guid("d1559c5b-5ed5-47f3-821b-d64c12d6d918"), true, "B", 2, "Temel Kavramlar - Soru 3 için Seçenek B", new Guid("b8940e45-03fa-4a08-b9b7-a688f0d897ad") },
                    { new Guid("d1cb4b8f-be26-4857-8e3a-8bcac3c2ea76"), false, "D", 4, "Hücre - Soru 1 için Seçenek D", new Guid("0fca0e45-4bdb-46a3-9758-247a6bd4b6f6") },
                    { new Guid("d238efa4-b866-45d9-b4a2-7069a3381c16"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 5 için Seçenek C", new Guid("f37137fb-2c6c-4a6d-b160-bca270272d91") },
                    { new Guid("d285dad4-1a13-4971-8896-fdd1b4a807b8"), false, "B", 2, "Fizik Bilimine Giriş - Soru 5 için Seçenek B", new Guid("3d390e96-1db4-48d2-bcfa-9c65fb629bbe") },
                    { new Guid("d2925f7c-2ace-420a-b697-350f5786b618"), true, "D", 4, "Sayı Basamakları - Soru 1 için Seçenek D", new Guid("2859ea6d-d9d3-4f1c-8056-7281a90d2c6d") },
                    { new Guid("d314080c-1a7e-40dd-b98b-0561767c02e6"), false, "B", 2, "Kalıtım - Soru 2 için Seçenek B", new Guid("037190d4-8e1a-42b2-9323-61ef42e28e4d") },
                    { new Guid("d3582a7e-efbf-4328-8a0c-e19ad837899c"), false, "C", 3, "Problemler - Soru 1 için Seçenek C", new Guid("e1c693f7-6696-4296-9f2a-7924bbc7b5fb") },
                    { new Guid("d62a143d-be5e-4ba6-9084-e856dcf03fce"), true, "D", 4, "Hücre - Soru 2 için Seçenek D", new Guid("f2011f73-d59d-4829-a7ca-a538141c0420") },
                    { new Guid("d75345fe-8a32-4880-bf2b-f96e18d17ef1"), false, "B", 2, "Kimya Bilimi - Soru 5 için Seçenek B", new Guid("c008746c-1a35-487a-bffd-a79b313c71b5") },
                    { new Guid("d89bff5c-de04-4d36-95af-ce4d629224c2"), false, "C", 3, "Fizik Bilimine Giriş - Soru 3 için Seçenek C", new Guid("f3167102-e1d5-406a-9ca9-b11a34970e15") },
                    { new Guid("daca1ac1-1239-4e27-a9c3-30c27e554e71"), false, "B", 2, "Hücre - Soru 3 için Seçenek B", new Guid("889efa09-2b47-4f39-9d21-d5898a380bfc") },
                    { new Guid("daf1f8bd-3d15-4fc2-854a-058d4023b21a"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 5 için Seçenek A", new Guid("d3e12b0a-2b5f-469f-8800-93ca078ab35d") },
                    { new Guid("db46b8ff-3f2a-4207-899e-b92e37609fbe"), false, "B", 2, "Maddenin Halleri - Soru 5 için Seçenek B", new Guid("477c2e65-6cbf-4e49-98ef-0bfb3827577b") },
                    { new Guid("dcc8b1df-641a-488c-aa9d-ab67c5afb198"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek C", new Guid("ced0c70b-bd0a-45a7-be9f-c416124c9b50") },
                    { new Guid("ded7bbee-e54e-4bd8-b7e9-13d21e390e75"), false, "A", 1, "Rasyonel Sayılar - Soru 4 için Seçenek A", new Guid("34602e3e-874e-413f-a93b-6e74b404c7e9") },
                    { new Guid("e12633a7-7b4a-46dd-9835-1fe74f787cf9"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek C", new Guid("6a1f508e-558d-405f-8baa-ae5bef645920") },
                    { new Guid("e13b5311-6dc8-469e-800c-9719c0fc1692"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 3 için Seçenek D", new Guid("f793b399-ac36-4f32-b056-021f0c81a4e8") },
                    { new Guid("e1c3ffca-4d2f-43ba-9f59-cb237ce70dd6"), false, "D", 4, "Kalıtım - Soru 1 için Seçenek D", new Guid("a5346945-1e85-4ae2-83b1-feda6b9d0e44") },
                    { new Guid("e1de372d-8b7c-45e1-9e78-3507856cc69e"), true, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek C", new Guid("78424a8f-b95a-4d18-95bd-de73fd421eba") },
                    { new Guid("e204f2e1-769f-4451-8552-1da706902b74"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 3 için Seçenek B", new Guid("99dafde6-2e94-4ed8-935d-5c21f62e781b") },
                    { new Guid("e22f4837-2172-4324-9e8e-8f9e9bbfae93"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek B", new Guid("ced0c70b-bd0a-45a7-be9f-c416124c9b50") },
                    { new Guid("e27077d4-4f9b-4ecf-a7ce-048618005ed4"), false, "D", 4, "Kimya Bilimi - Soru 2 için Seçenek D", new Guid("4381c1f8-659b-4246-9fdd-4d86a75b6526") },
                    { new Guid("e2df2c4f-3189-4673-8d84-b0a8c7c5c7d8"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek A", new Guid("6e8b6912-713e-4f14-98a6-f802e1861b9a") },
                    { new Guid("e3059543-da02-4ab5-a05c-1040d435a250"), false, "C", 3, "Kuvvet ve Hareket - Soru 1 için Seçenek C", new Guid("76964227-a124-48bf-9fa1-174c9248c52b") },
                    { new Guid("e38b60b2-1888-4578-9e3b-23d036b4ec5c"), false, "A", 1, "İş, Güç ve Enerji - Soru 1 için Seçenek A", new Guid("ee7e3d02-834a-4d37-9e7f-d0e3fd93790d") },
                    { new Guid("e3ae31d5-2b98-40c4-b13d-02d71174aecb"), true, "C", 3, "Hücre - Soru 4 için Seçenek C", new Guid("b3cd5556-fb76-4d4d-8f35-f1ea44be02d7") },
                    { new Guid("e5bc5466-b712-48c9-af16-c70fda180be5"), false, "C", 3, "Rasyonel Sayılar - Soru 3 için Seçenek C", new Guid("810d08b4-d0a1-4105-9f01-bb8751e9fcf5") },
                    { new Guid("e61d38e3-b97f-4c1a-883c-643154059fb8"), false, "A", 1, "Fizik Bilimine Giriş - Soru 3 için Seçenek A", new Guid("f3167102-e1d5-406a-9ca9-b11a34970e15") },
                    { new Guid("e6efc654-3ec9-4c2d-8250-9fc456f185b4"), false, "C", 3, "Bölme ve Bölünebilme - Soru 3 için Seçenek C", new Guid("fbd1c616-0823-45e9-a9fe-db86ccc55d09") },
                    { new Guid("e724cca3-9c1a-40dc-995d-32c2a6fd426f"), false, "C", 3, "Elektrostatik - Soru 3 için Seçenek C", new Guid("30492025-193b-4e13-ac3e-9bafce3ff399") },
                    { new Guid("e846e0e6-eef8-4559-95fe-8856a748fa2a"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek B", new Guid("8f9e62df-a97d-4b90-8bfa-0bb06396c733") },
                    { new Guid("e8522504-aadb-43ed-b62d-42781e582ae9"), false, "C", 3, "Madde ve Özellikleri - Soru 3 için Seçenek C", new Guid("4799765c-95d2-4a71-adff-56a08e603796") },
                    { new Guid("e8a99638-a8b4-4527-9cc0-27e88c5957cd"), false, "A", 1, "Hücre Bölünmeleri - Soru 4 için Seçenek A", new Guid("eadc9125-0258-4b99-8659-01624cddbef0") },
                    { new Guid("ea034549-5839-49e6-a2b0-0499f747faab"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 4 için Seçenek C", new Guid("219201fa-2193-4eec-9841-ce0630ba21e2") },
                    { new Guid("ea96f2df-84f4-4c04-9a1a-fe2f6e7ac635"), false, "B", 2, "Elektrostatik - Soru 1 için Seçenek B", new Guid("ac056556-d749-4bbb-981c-1f339716762e") },
                    { new Guid("eb095983-49f9-4a52-aaff-a04f4f5bba64"), true, "A", 1, "Maddenin Halleri - Soru 1 için Seçenek A", new Guid("cfeb1231-c1b4-47dd-818a-97d2b4325428") },
                    { new Guid("eb496ee9-b8ef-40cd-aa5a-dd39a9efa429"), false, "A", 1, "Rasyonel Sayılar - Soru 3 için Seçenek A", new Guid("810d08b4-d0a1-4105-9f01-bb8751e9fcf5") },
                    { new Guid("ed4c2233-b3dd-4f33-b349-7c388468db16"), false, "B", 2, "Problemler - Soru 4 için Seçenek B", new Guid("fee7f011-9c89-48b6-977d-887348bcbefa") },
                    { new Guid("edb8b61b-79e6-4212-87ae-e6cb0ae800d6"), false, "C", 3, "Elektrostatik - Soru 4 için Seçenek C", new Guid("76102e35-e5fd-4588-8252-e60146709d36") },
                    { new Guid("edcaf381-a912-499c-b7c7-37d49459323c"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek B", new Guid("78424a8f-b95a-4d18-95bd-de73fd421eba") },
                    { new Guid("eddf27a9-004f-4dff-88c3-a9315613a1d5"), false, "D", 4, "Sayı Basamakları - Soru 5 için Seçenek D", new Guid("24086491-98e9-4ba8-98d7-29c1772273f4") },
                    { new Guid("eed5e371-5134-41ea-ac56-0bdd3c811a99"), false, "C", 3, "Temel Kavramlar - Soru 2 için Seçenek C", new Guid("be71008a-2407-42a1-98f8-104f73006d58") },
                    { new Guid("ef3bc4c6-a775-41e3-b502-16aa0b5a95d1"), false, "B", 2, "Kuvvet ve Hareket - Soru 2 için Seçenek B", new Guid("e5807c07-fc86-4b46-8393-41214feb611b") },
                    { new Guid("ef5b505c-b898-475c-80cc-319b300a2df0"), false, "A", 1, "Rasyonel Sayılar - Soru 5 için Seçenek A", new Guid("049fee8f-68f6-43f5-894b-c33ec2e9dc5b") },
                    { new Guid("ef76d9ac-47a0-4048-97f7-9290da39c7cd"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek B", new Guid("de98f8e2-e685-4492-8415-e1386fc212f1") },
                    { new Guid("f0907e60-0029-4664-8a62-1b5065442488"), false, "B", 2, "Problemler - Soru 5 için Seçenek B", new Guid("7c927095-3270-43a6-b868-3afcae0c150a") },
                    { new Guid("f136c5c4-1bd6-4f16-a9be-4f48959d82c3"), false, "C", 3, "Kuvvet ve Hareket - Soru 3 için Seçenek C", new Guid("5773dd6b-ad1b-44df-b182-3ecd5cacb444") },
                    { new Guid("f269098a-cc63-4427-a240-d9d813bc9954"), false, "B", 2, "Kimya Bilimi - Soru 3 için Seçenek B", new Guid("149b55cf-cb5f-4db4-84bd-b8323c0c5b02") },
                    { new Guid("f2701a32-230e-470b-a7e0-96634e8a7628"), true, "C", 3, "İş, Güç ve Enerji - Soru 1 için Seçenek C", new Guid("ee7e3d02-834a-4d37-9e7f-d0e3fd93790d") },
                    { new Guid("f3297494-fb05-41cf-8b59-b7122c0e663a"), false, "C", 3, "Hücre Bölünmeleri - Soru 5 için Seçenek C", new Guid("fb54a481-abd8-431c-9e35-92bfd42ca67d") },
                    { new Guid("f3f3c429-098d-4546-ae4b-a786c47a5851"), false, "C", 3, "Kalıtım - Soru 4 için Seçenek C", new Guid("05fb4089-4e55-493a-9c60-c4d2b14abadd") },
                    { new Guid("f4068701-6946-4e44-b26d-950d4d8bb384"), false, "C", 3, "Madde ve Özellikleri - Soru 5 için Seçenek C", new Guid("72b0b34f-010c-4c75-9e76-fbb979744991") },
                    { new Guid("f4358257-cc3e-4cb9-af4a-03bec0264d2e"), false, "D", 4, "İş, Güç ve Enerji - Soru 2 için Seçenek D", new Guid("2242ba31-2f36-45fd-9654-cd4a0ad06cfe") },
                    { new Guid("f446bb94-e0e7-4b83-a0a8-5e8de86d4df1"), true, "B", 2, "Canlıların Sınıflandırılması - Soru 5 için Seçenek B", new Guid("d3e12b0a-2b5f-469f-8800-93ca078ab35d") },
                    { new Guid("f4eaa933-e459-4060-b094-be8ca192ccb3"), true, "A", 1, "İş, Güç ve Enerji - Soru 2 için Seçenek A", new Guid("2242ba31-2f36-45fd-9654-cd4a0ad06cfe") },
                    { new Guid("f5ba5ab6-491e-4406-930a-4a882c1525a0"), false, "C", 3, "Fizik Bilimine Giriş - Soru 2 için Seçenek C", new Guid("ef3ef81e-0e60-43ad-8b49-a476fd451a00") },
                    { new Guid("f5d18034-4e8f-4b4d-bbc0-e1cc01f2d2dd"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek C", new Guid("3f07b615-69f2-400e-ad98-d21393361e6d") },
                    { new Guid("f605ddf5-95e8-472b-ac84-4df884ee385d"), true, "D", 4, "Kuvvet ve Hareket - Soru 4 için Seçenek D", new Guid("553e4fec-f32c-4d0c-8a52-205912200563") },
                    { new Guid("f694731e-888f-4d51-b59f-db85fee1a075"), false, "A", 1, "Kalıtım - Soru 4 için Seçenek A", new Guid("05fb4089-4e55-493a-9c60-c4d2b14abadd") },
                    { new Guid("f6fe7088-1e1d-4d46-bae3-6d773da7f503"), false, "D", 4, "Problemler - Soru 2 için Seçenek D", new Guid("a347f4cb-cf7c-4799-8e1c-da9222b7ad1a") },
                    { new Guid("f752a2bb-2257-42fc-9333-6981d82c4595"), false, "A", 1, "Fizik Bilimine Giriş - Soru 1 için Seçenek A", new Guid("51731461-0c7c-433b-a156-f505bf54bbb8") },
                    { new Guid("f8046651-7b9e-458a-96f8-aec9b85eb3aa"), false, "A", 1, "Elektrostatik - Soru 4 için Seçenek A", new Guid("76102e35-e5fd-4588-8252-e60146709d36") },
                    { new Guid("f8270185-a272-44e5-a0b4-a97a69568c5f"), true, "C", 3, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek C", new Guid("f9260246-da57-464b-9410-5963492b6db1") },
                    { new Guid("f82dd6bd-486b-4665-a251-aa182e44f29e"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek D", new Guid("de98f8e2-e685-4492-8415-e1386fc212f1") },
                    { new Guid("f882d05c-b83e-4229-9f10-afa01d1bca60"), false, "C", 3, "Sayı Basamakları - Soru 2 için Seçenek C", new Guid("8b380dfc-9b7a-4069-95e4-b845887f2cfe") },
                    { new Guid("f8b7b56a-5587-4af5-9e08-9bdfb6d2b3c6"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek B", new Guid("06b5144b-beee-4416-9803-ba361525a802") },
                    { new Guid("f98011ba-a08b-40f8-bcbb-5967b449513e"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 3 için Seçenek B", new Guid("f793b399-ac36-4f32-b056-021f0c81a4e8") },
                    { new Guid("faab791c-cb40-4e45-b810-c4ec242ad505"), true, "A", 1, "Maddenin Halleri - Soru 3 için Seçenek A", new Guid("d52b6387-3d3a-48d7-babd-1fdf131688a7") },
                    { new Guid("faafac8c-71f5-44fe-9680-28c331cecbb1"), false, "D", 4, "Kimya Bilimi - Soru 1 için Seçenek D", new Guid("a8f934a8-bbb8-4b5b-86ee-1b4c0c923656") },
                    { new Guid("fab25b9b-c60a-4abe-876c-54d693bf31f3"), false, "A", 1, "Elektrostatik - Soru 3 için Seçenek A", new Guid("30492025-193b-4e13-ac3e-9bafce3ff399") },
                    { new Guid("fb2cbae3-3f31-4b53-a54d-9fb018cbf7cc"), false, "C", 3, "Problemler - Soru 5 için Seçenek C", new Guid("7c927095-3270-43a6-b868-3afcae0c150a") },
                    { new Guid("fbdec647-0d94-4cdd-8dd7-5f71f6c9516e"), true, "B", 2, "Kuvvet ve Hareket - Soru 1 için Seçenek B", new Guid("76964227-a124-48bf-9fa1-174c9248c52b") },
                    { new Guid("fc03f17e-87ec-4093-975d-903ae5ab039d"), false, "C", 3, "Temel Kavramlar - Soru 4 için Seçenek C", new Guid("31ab5fbc-ec35-4bde-a51a-33ffa49cf93a") },
                    { new Guid("fc37d912-a07c-4135-bd09-574121bc1c87"), false, "D", 4, "Temel Kavramlar - Soru 1 için Seçenek D", new Guid("20d1bc7e-b726-4b4c-a457-b360bf13d0bb") },
                    { new Guid("fc64130c-101f-418e-9db0-5c87a773b5ac"), false, "B", 2, "Kalıtım - Soru 1 için Seçenek B", new Guid("a5346945-1e85-4ae2-83b1-feda6b9d0e44") },
                    { new Guid("fc7e18f7-7f0c-48b3-b893-a0ceaec03c42"), true, "D", 4, "Problemler - Soru 3 için Seçenek D", new Guid("d0c9e410-0714-4b36-8fa9-cffa4b5044e0") },
                    { new Guid("fcc7a6cc-7970-48bb-80ad-fe6264c3f5d8"), true, "A", 1, "Hücre Bölünmeleri - Soru 5 için Seçenek A", new Guid("fb54a481-abd8-431c-9e35-92bfd42ca67d") },
                    { new Guid("fe491a01-37f4-4dce-8b20-6fb8fddef752"), false, "A", 1, "Bölme ve Bölünebilme - Soru 2 için Seçenek A", new Guid("f30f7b45-25e1-4955-9226-c6b19cebfa7a") },
                    { new Guid("fe65f01f-1ba0-4334-ab8f-0a1badaadc01"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 2 için Seçenek C", new Guid("6ab00d47-7f4c-4bce-b57f-b8139f883308") },
                    { new Guid("febb2b68-48c2-480f-9419-4d3e55dbf2b3"), false, "D", 4, "Sayı Basamakları - Soru 3 için Seçenek D", new Guid("c8ef1250-040d-4442-a076-2202397740b4") },
                    { new Guid("ffa35762-d8cd-4b9b-8a0d-b8f836105e90"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 5 için Seçenek D", new Guid("d3e12b0a-2b5f-469f-8800-93ca078ab35d") },
                    { new Guid("ffbf2a1b-e1fe-473d-8068-101e1450389b"), false, "C", 3, "Kalıtım - Soru 2 için Seçenek C", new Guid("037190d4-8e1a-42b2-9323-61ef42e28e4d") }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ParentTopicId", "SubjectId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("3b329406-0608-43fc-8964-b2d82d69c26a"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5182), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Maddenin Halleri" },
                    { new Guid("3cfafc94-2758-46f1-9ecd-8a5157a7db1d"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5197), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre" },
                    { new Guid("56cab740-14fb-409b-8aaf-cb02ca9e096a"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5207), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Kalıtım" },
                    { new Guid("6e871c9a-508d-4fd6-98c6-fac9db4f1673"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5163), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "İş, Güç ve Enerji" },
                    { new Guid("83dbc18a-d74e-4739-9381-e053df055e62"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5126), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Sayı Basamakları" },
                    { new Guid("86624914-6e4d-4f83-9738-acf3f512bf11"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5160), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Kuvvet ve Hareket" },
                    { new Guid("902cba99-1f15-4af3-bb1c-ced5a7dd5bc9"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5142), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Rasyonel Sayılar" },
                    { new Guid("92d01afe-4916-4f43-955c-ac1be3bd5c8c"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5154), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Fizik Bilimine Giriş" },
                    { new Guid("937e758d-d7a5-4b38-94d7-4656f07b90c5"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5177), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Atom ve Periyodik Sistem" },
                    { new Guid("a65f7a50-2e1e-465c-b610-868675e8784f"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5139), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Bölme ve Bölünebilme" },
                    { new Guid("aae243ad-32bf-4bec-bdb8-cc446ed5bc58"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5157), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Madde ve Özellikleri" },
                    { new Guid("baaf359a-3b46-4bcf-9910-80dc47624aa2"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5190), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Yaşam Bilimi Biyoloji" },
                    { new Guid("c1ff47ee-a930-4de6-be94-c31a587c851d"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5165), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Elektrostatik" },
                    { new Guid("c9775b84-0e18-49b7-a848-d2d0f44caa9b"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5199), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Canlıların Sınıflandırılması" },
                    { new Guid("ca24227e-4190-4e1e-bff3-143a7ab9a390"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5185), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Asitler, Bazlar ve Tuzlar" },
                    { new Guid("ccf09849-27c4-4621-856c-c4e11910de5e"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5174), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimya Bilimi" },
                    { new Guid("d02822fc-1df7-408a-9270-de9abc9557e8"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5180), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimyasal Türler Arası Etkileşimler" },
                    { new Guid("e761a14d-22b0-4945-b744-f3a39e1a0d6c"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5146), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Problemler" },
                    { new Guid("eb95fee1-b6e4-4cfe-bd00-15ceff3a55b1"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5205), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre Bölünmeleri" },
                    { new Guid("f0ba3089-1edf-4ce0-8d72-010d4844ae30"), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(5122), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Temel Kavramlar" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsTopics",
                columns: new[] { "QuestionId", "TopicId", "Id" },
                values: new object[,]
                {
                    { new Guid("01123da1-d2a1-4415-ba58-f6004e605332"), new Guid("a65f7a50-2e1e-465c-b610-868675e8784f"), new Guid("3c710593-ea73-4982-a878-21400cb1c49e") },
                    { new Guid("031d2734-9661-424d-bfba-c0ca3b7e064a"), new Guid("3b329406-0608-43fc-8964-b2d82d69c26a"), new Guid("ee615b92-8fa5-482a-a2f8-5970881acf1f") },
                    { new Guid("037190d4-8e1a-42b2-9323-61ef42e28e4d"), new Guid("56cab740-14fb-409b-8aaf-cb02ca9e096a"), new Guid("eb709efc-f5f3-4095-a656-8c9bc3ce89ad") },
                    { new Guid("049fee8f-68f6-43f5-894b-c33ec2e9dc5b"), new Guid("902cba99-1f15-4af3-bb1c-ced5a7dd5bc9"), new Guid("add9667d-2600-47c4-bb95-20222cf95034") },
                    { new Guid("05fb4089-4e55-493a-9c60-c4d2b14abadd"), new Guid("56cab740-14fb-409b-8aaf-cb02ca9e096a"), new Guid("132c38d8-3a71-4735-89a0-1d6c9ba10b6b") },
                    { new Guid("06b5144b-beee-4416-9803-ba361525a802"), new Guid("baaf359a-3b46-4bcf-9910-80dc47624aa2"), new Guid("ee112f6c-4bf1-4283-aae4-8e6915d2c868") },
                    { new Guid("0fca0e45-4bdb-46a3-9758-247a6bd4b6f6"), new Guid("3cfafc94-2758-46f1-9ecd-8a5157a7db1d"), new Guid("2ed965f5-0bba-4b08-916d-529852744399") },
                    { new Guid("132395ce-a4ba-4b02-94c7-09430852659d"), new Guid("92d01afe-4916-4f43-955c-ac1be3bd5c8c"), new Guid("cf1eb55a-e89a-45ad-94d4-bbe565510827") },
                    { new Guid("149b55cf-cb5f-4db4-84bd-b8323c0c5b02"), new Guid("ccf09849-27c4-4621-856c-c4e11910de5e"), new Guid("e76f4626-606f-426e-ba27-9a828b73bbb9") },
                    { new Guid("1506f0f8-c63b-448d-a755-f8fad6fe5178"), new Guid("c1ff47ee-a930-4de6-be94-c31a587c851d"), new Guid("4b9ad8ce-2356-49aa-a7d2-896491f1e002") },
                    { new Guid("1f1b61b6-fe91-47b4-ae5e-fe67c5572022"), new Guid("d02822fc-1df7-408a-9270-de9abc9557e8"), new Guid("95d8a8ad-b89e-4b51-84a2-951b90a41d57") },
                    { new Guid("20d1bc7e-b726-4b4c-a457-b360bf13d0bb"), new Guid("f0ba3089-1edf-4ce0-8d72-010d4844ae30"), new Guid("95632caf-c0e1-487b-9999-5cd1223221a6") },
                    { new Guid("219201fa-2193-4eec-9841-ce0630ba21e2"), new Guid("c9775b84-0e18-49b7-a848-d2d0f44caa9b"), new Guid("4bd2d2b9-c82a-48fa-be53-63ed57cefa45") },
                    { new Guid("2242ba31-2f36-45fd-9654-cd4a0ad06cfe"), new Guid("6e871c9a-508d-4fd6-98c6-fac9db4f1673"), new Guid("b8186720-764f-4720-bd9d-b6ea5ad9c4e7") },
                    { new Guid("24086491-98e9-4ba8-98d7-29c1772273f4"), new Guid("83dbc18a-d74e-4739-9381-e053df055e62"), new Guid("d15e9d93-7515-4dc7-b0c8-c85f6fe91ad6") },
                    { new Guid("2859ea6d-d9d3-4f1c-8056-7281a90d2c6d"), new Guid("83dbc18a-d74e-4739-9381-e053df055e62"), new Guid("c6394e22-a005-4728-a818-509b0a654faa") },
                    { new Guid("30492025-193b-4e13-ac3e-9bafce3ff399"), new Guid("c1ff47ee-a930-4de6-be94-c31a587c851d"), new Guid("ac274ea8-0e77-41ee-b444-d596b02f789f") },
                    { new Guid("30e786d5-ff9d-466f-8e18-4e335781a400"), new Guid("c9775b84-0e18-49b7-a848-d2d0f44caa9b"), new Guid("4fed7817-fcd6-478a-b996-65f19e7f88f8") },
                    { new Guid("31ab5fbc-ec35-4bde-a51a-33ffa49cf93a"), new Guid("f0ba3089-1edf-4ce0-8d72-010d4844ae30"), new Guid("48fd5938-8da9-4675-a671-885b030c044a") },
                    { new Guid("34602e3e-874e-413f-a93b-6e74b404c7e9"), new Guid("902cba99-1f15-4af3-bb1c-ced5a7dd5bc9"), new Guid("28ed985b-2fbb-4e0b-827f-9ad28920325f") },
                    { new Guid("359e29af-c30b-4a02-925f-d32515b399e2"), new Guid("6e871c9a-508d-4fd6-98c6-fac9db4f1673"), new Guid("776e1696-d0a2-4c5f-953c-98b22dc3ca5d") },
                    { new Guid("3d390e96-1db4-48d2-bcfa-9c65fb629bbe"), new Guid("92d01afe-4916-4f43-955c-ac1be3bd5c8c"), new Guid("9b3f5979-12a5-41c8-a4c9-3f148d2a4552") },
                    { new Guid("3ebb6445-472e-4d22-8ddf-5ee2c25f6093"), new Guid("6e871c9a-508d-4fd6-98c6-fac9db4f1673"), new Guid("715a15a8-4a72-42a8-a867-ef4638d0db8e") },
                    { new Guid("3f07b615-69f2-400e-ad98-d21393361e6d"), new Guid("ca24227e-4190-4e1e-bff3-143a7ab9a390"), new Guid("5b9d02ff-57b5-49b5-aa33-cdbc3e2558ad") },
                    { new Guid("40a17080-ad1c-4a74-8ba6-6e30ab9b7a2d"), new Guid("937e758d-d7a5-4b38-94d7-4656f07b90c5"), new Guid("2d120bd5-f85c-4493-8c02-4ac0a0ca37aa") },
                    { new Guid("4381c1f8-659b-4246-9fdd-4d86a75b6526"), new Guid("ccf09849-27c4-4621-856c-c4e11910de5e"), new Guid("b6e685d4-fef7-4024-8057-52c2013f9779") },
                    { new Guid("477c2e65-6cbf-4e49-98ef-0bfb3827577b"), new Guid("3b329406-0608-43fc-8964-b2d82d69c26a"), new Guid("161c9803-c66b-4704-b8f9-cb30ea2e361b") },
                    { new Guid("4799765c-95d2-4a71-adff-56a08e603796"), new Guid("aae243ad-32bf-4bec-bdb8-cc446ed5bc58"), new Guid("a22d8f2b-5d45-4d92-adf3-66f84c6d149d") },
                    { new Guid("485929f8-f73a-4bff-b877-9c9545a9926a"), new Guid("937e758d-d7a5-4b38-94d7-4656f07b90c5"), new Guid("41d3e6b0-c3e4-419b-a858-36fcf7d77572") },
                    { new Guid("49907401-e696-42f3-b17b-491dc0adc0f8"), new Guid("aae243ad-32bf-4bec-bdb8-cc446ed5bc58"), new Guid("c7e98ee3-e2fe-4a73-b7b7-81a0a812a64b") },
                    { new Guid("4caf9e43-f9ff-4924-ba8a-313192b17dfc"), new Guid("d02822fc-1df7-408a-9270-de9abc9557e8"), new Guid("ebd163d4-f84f-4f78-81ba-405a06e5426d") },
                    { new Guid("51731461-0c7c-433b-a156-f505bf54bbb8"), new Guid("92d01afe-4916-4f43-955c-ac1be3bd5c8c"), new Guid("1c783d27-8466-4010-8ccb-d2bf4e6c5f0c") },
                    { new Guid("553e4fec-f32c-4d0c-8a52-205912200563"), new Guid("86624914-6e4d-4f83-9738-acf3f512bf11"), new Guid("d44f51c6-524f-4690-abd0-a1bbb16abaa4") },
                    { new Guid("55bd7d36-5f77-414a-b64d-9dc5d392922d"), new Guid("eb95fee1-b6e4-4cfe-bd00-15ceff3a55b1"), new Guid("c2f92449-a947-4d04-8fc8-b1886122ccdc") },
                    { new Guid("55ce4a0d-2d09-4efc-89be-db8636a01d5f"), new Guid("baaf359a-3b46-4bcf-9910-80dc47624aa2"), new Guid("bd8c6c97-55ee-42e2-83b3-772c25ec436a") },
                    { new Guid("5773dd6b-ad1b-44df-b182-3ecd5cacb444"), new Guid("86624914-6e4d-4f83-9738-acf3f512bf11"), new Guid("33945932-cf9f-4f3a-ad28-b47dbcfffe7f") },
                    { new Guid("5abfc962-8876-4e49-83a0-7905b02eb2c3"), new Guid("902cba99-1f15-4af3-bb1c-ced5a7dd5bc9"), new Guid("a89ad835-8bf3-4cd4-9cce-b0e5d1cc7ebf") },
                    { new Guid("5e1e83e9-c678-43cc-9443-6995ebf5ebd4"), new Guid("ca24227e-4190-4e1e-bff3-143a7ab9a390"), new Guid("9f7746a7-674e-4c38-bb68-212a52aedb67") },
                    { new Guid("62fdda1a-3f38-49c5-b64e-dca5b4c334e4"), new Guid("aae243ad-32bf-4bec-bdb8-cc446ed5bc58"), new Guid("75d440b4-5a97-4f70-8e6f-067029a5bfae") },
                    { new Guid("63db7bf2-8ef2-45e3-a891-458195868be3"), new Guid("ca24227e-4190-4e1e-bff3-143a7ab9a390"), new Guid("08b140b1-2166-42fa-abfb-70fb90458d06") },
                    { new Guid("65ca2093-15cc-427c-b990-d3fae47b7486"), new Guid("86624914-6e4d-4f83-9738-acf3f512bf11"), new Guid("1eb0567d-f3a4-4d8d-876e-60cb66d7e88c") },
                    { new Guid("68f5cc43-4148-4a88-8e60-5cda2afe615f"), new Guid("56cab740-14fb-409b-8aaf-cb02ca9e096a"), new Guid("a418ca06-db6f-46bf-82aa-3cb1e6c48232") },
                    { new Guid("6a1f508e-558d-405f-8baa-ae5bef645920"), new Guid("d02822fc-1df7-408a-9270-de9abc9557e8"), new Guid("c62b1f25-3457-4992-894c-76451d8b834c") },
                    { new Guid("6ab00d47-7f4c-4bce-b57f-b8139f883308"), new Guid("c9775b84-0e18-49b7-a848-d2d0f44caa9b"), new Guid("5d8bc7bf-add8-41c5-b9aa-96a5b07223c5") },
                    { new Guid("6e8b6912-713e-4f14-98a6-f802e1861b9a"), new Guid("baaf359a-3b46-4bcf-9910-80dc47624aa2"), new Guid("92e0d675-11d5-4e57-aea3-1e4600d12b0f") },
                    { new Guid("70178320-869e-4944-b84c-33497ece5178"), new Guid("aae243ad-32bf-4bec-bdb8-cc446ed5bc58"), new Guid("e2db393f-a185-4111-92bf-1721317687ff") },
                    { new Guid("72b0b34f-010c-4c75-9e76-fbb979744991"), new Guid("aae243ad-32bf-4bec-bdb8-cc446ed5bc58"), new Guid("e8b7c082-1016-4fd4-b15d-be531a85a15c") },
                    { new Guid("76102e35-e5fd-4588-8252-e60146709d36"), new Guid("c1ff47ee-a930-4de6-be94-c31a587c851d"), new Guid("2dfd29f1-67c7-422c-abe6-39f50189ee36") },
                    { new Guid("76964227-a124-48bf-9fa1-174c9248c52b"), new Guid("86624914-6e4d-4f83-9738-acf3f512bf11"), new Guid("9b21ab0f-206e-44d5-8b6e-798ace8a3aa7") },
                    { new Guid("78424a8f-b95a-4d18-95bd-de73fd421eba"), new Guid("d02822fc-1df7-408a-9270-de9abc9557e8"), new Guid("a67c91f2-1040-4bad-b0e6-be9bc6d2745e") },
                    { new Guid("7c927095-3270-43a6-b868-3afcae0c150a"), new Guid("e761a14d-22b0-4945-b744-f3a39e1a0d6c"), new Guid("1865f820-3469-4f44-ae57-a1391b62d178") },
                    { new Guid("810d08b4-d0a1-4105-9f01-bb8751e9fcf5"), new Guid("902cba99-1f15-4af3-bb1c-ced5a7dd5bc9"), new Guid("c10ff198-6ed2-44b8-a168-f83ce83a6f9e") },
                    { new Guid("845a716f-b70e-4842-a030-65f4a1c6a7a3"), new Guid("f0ba3089-1edf-4ce0-8d72-010d4844ae30"), new Guid("a68304a2-de00-4d14-99af-774595c671fd") },
                    { new Guid("889efa09-2b47-4f39-9d21-d5898a380bfc"), new Guid("3cfafc94-2758-46f1-9ecd-8a5157a7db1d"), new Guid("741dcfe4-07a8-4b6c-94e5-090b11f6aaab") },
                    { new Guid("8b380dfc-9b7a-4069-95e4-b845887f2cfe"), new Guid("83dbc18a-d74e-4739-9381-e053df055e62"), new Guid("82ef3580-d6ea-4625-9e6b-21123c131373") },
                    { new Guid("8f9e62df-a97d-4b90-8bfa-0bb06396c733"), new Guid("d02822fc-1df7-408a-9270-de9abc9557e8"), new Guid("71898b22-c9d6-4d09-a4ef-7012b306498c") },
                    { new Guid("925a894c-7b90-4057-9cdf-b0b694ab5441"), new Guid("3b329406-0608-43fc-8964-b2d82d69c26a"), new Guid("80e5f61f-a2bb-4251-8e7e-8354cb51ae4e") },
                    { new Guid("95853a83-dfb6-445d-a9a4-5ab39441bebe"), new Guid("a65f7a50-2e1e-465c-b610-868675e8784f"), new Guid("f3a4a78f-f856-4615-9fda-2ce642e23ef8") },
                    { new Guid("98297a09-075e-4888-aaa6-0737f6c2499a"), new Guid("a65f7a50-2e1e-465c-b610-868675e8784f"), new Guid("049c791d-0ab2-4abb-a489-8c90e570361f") },
                    { new Guid("99cc214c-8751-47f6-88eb-d105e9a585cf"), new Guid("937e758d-d7a5-4b38-94d7-4656f07b90c5"), new Guid("28c45d3d-8d1c-4fd2-896a-d64fb04e4050") },
                    { new Guid("99dafde6-2e94-4ed8-935d-5c21f62e781b"), new Guid("c9775b84-0e18-49b7-a848-d2d0f44caa9b"), new Guid("8c45cda1-20dc-4d08-bf51-063b9ff207cd") },
                    { new Guid("a0ffefa6-89e0-46e2-a60e-7f0e93f75981"), new Guid("3cfafc94-2758-46f1-9ecd-8a5157a7db1d"), new Guid("27665555-cd21-4a50-807d-d062583e371d") },
                    { new Guid("a347f4cb-cf7c-4799-8e1c-da9222b7ad1a"), new Guid("e761a14d-22b0-4945-b744-f3a39e1a0d6c"), new Guid("72e662a2-97ab-4f3e-94e5-a60bd2539058") },
                    { new Guid("a5346945-1e85-4ae2-83b1-feda6b9d0e44"), new Guid("56cab740-14fb-409b-8aaf-cb02ca9e096a"), new Guid("cacb2c2a-1144-4513-8d0f-e71b23bbf82d") },
                    { new Guid("a53cd8f3-5a8f-41dc-8a14-38abc7655d16"), new Guid("ca24227e-4190-4e1e-bff3-143a7ab9a390"), new Guid("b8dcdff8-e9b9-48dc-98f6-434de4950263") },
                    { new Guid("a8f934a8-bbb8-4b5b-86ee-1b4c0c923656"), new Guid("ccf09849-27c4-4621-856c-c4e11910de5e"), new Guid("0979d915-9a24-46d2-bc9c-df7431111af1") },
                    { new Guid("ac056556-d749-4bbb-981c-1f339716762e"), new Guid("c1ff47ee-a930-4de6-be94-c31a587c851d"), new Guid("1fa7cf4a-c79c-4bf5-8dbc-74a5563383f6") },
                    { new Guid("b3cd5556-fb76-4d4d-8f35-f1ea44be02d7"), new Guid("3cfafc94-2758-46f1-9ecd-8a5157a7db1d"), new Guid("2c802bc6-b459-451e-9d03-72b08c72decd") },
                    { new Guid("b5b0cf44-d158-4a91-a846-49f17e0b8ca9"), new Guid("902cba99-1f15-4af3-bb1c-ced5a7dd5bc9"), new Guid("3a45c00e-9b91-4874-9623-7e62c44651c9") },
                    { new Guid("b8940e45-03fa-4a08-b9b7-a688f0d897ad"), new Guid("f0ba3089-1edf-4ce0-8d72-010d4844ae30"), new Guid("5beec184-9913-44c5-a2c3-3dd55375450e") },
                    { new Guid("be71008a-2407-42a1-98f8-104f73006d58"), new Guid("f0ba3089-1edf-4ce0-8d72-010d4844ae30"), new Guid("73c1479c-ac03-49db-92f6-112b7fcef7b7") },
                    { new Guid("c008746c-1a35-487a-bffd-a79b313c71b5"), new Guid("ccf09849-27c4-4621-856c-c4e11910de5e"), new Guid("aaf44246-f767-4641-930e-3140d3a8728f") },
                    { new Guid("c137ae71-10d9-4e6b-a64e-3005d37e6f23"), new Guid("83dbc18a-d74e-4739-9381-e053df055e62"), new Guid("fbe1a1ac-f93c-477f-84fb-548b03eded66") },
                    { new Guid("c8ef1250-040d-4442-a076-2202397740b4"), new Guid("83dbc18a-d74e-4739-9381-e053df055e62"), new Guid("24ad1bca-de93-45fc-a5f7-1c414c49981e") },
                    { new Guid("ced0c70b-bd0a-45a7-be9f-c416124c9b50"), new Guid("ca24227e-4190-4e1e-bff3-143a7ab9a390"), new Guid("869b05d2-c2d9-4517-b78c-140e99cdb8d8") },
                    { new Guid("cfeb1231-c1b4-47dd-818a-97d2b4325428"), new Guid("3b329406-0608-43fc-8964-b2d82d69c26a"), new Guid("c94ab4a8-43bc-46db-b878-91045fd0afca") },
                    { new Guid("d0c9e410-0714-4b36-8fa9-cffa4b5044e0"), new Guid("e761a14d-22b0-4945-b744-f3a39e1a0d6c"), new Guid("c46f8178-1f5f-485d-a00d-b89d89e074e2") },
                    { new Guid("d3e12b0a-2b5f-469f-8800-93ca078ab35d"), new Guid("c9775b84-0e18-49b7-a848-d2d0f44caa9b"), new Guid("fe5114a1-a15a-438e-a595-bc0defb060bb") },
                    { new Guid("d4aa6c35-8637-4f4d-b541-53ee168913be"), new Guid("ccf09849-27c4-4621-856c-c4e11910de5e"), new Guid("1e0845ee-6c0a-4193-baf4-4b8ce58483a7") },
                    { new Guid("d52b6387-3d3a-48d7-babd-1fdf131688a7"), new Guid("3b329406-0608-43fc-8964-b2d82d69c26a"), new Guid("be1fedb0-fb3f-46b9-8f5e-0d94bf330aac") },
                    { new Guid("dab13ee4-cf71-4fe1-aedd-2822d80b2800"), new Guid("c1ff47ee-a930-4de6-be94-c31a587c851d"), new Guid("1f174371-5f64-4daa-8e83-d1ab122b701f") },
                    { new Guid("de98f8e2-e685-4492-8415-e1386fc212f1"), new Guid("baaf359a-3b46-4bcf-9910-80dc47624aa2"), new Guid("adaaffc5-2305-4bc9-b780-4e8734d3d109") },
                    { new Guid("e1c693f7-6696-4296-9f2a-7924bbc7b5fb"), new Guid("e761a14d-22b0-4945-b744-f3a39e1a0d6c"), new Guid("11e0c0e5-ea6a-4fe0-9809-e9bac0c5bf4c") },
                    { new Guid("e5807c07-fc86-4b46-8393-41214feb611b"), new Guid("86624914-6e4d-4f83-9738-acf3f512bf11"), new Guid("a86eb6fd-fa8f-4e4e-984d-75024e86b755") },
                    { new Guid("e7103035-5a6a-477a-9922-2e1bc58d94e3"), new Guid("6e871c9a-508d-4fd6-98c6-fac9db4f1673"), new Guid("aa64552c-5135-48fe-a0de-c7ae1ce91432") },
                    { new Guid("eadc9125-0258-4b99-8659-01624cddbef0"), new Guid("eb95fee1-b6e4-4cfe-bd00-15ceff3a55b1"), new Guid("60c16860-0f14-43a2-965c-f87499df7ff4") },
                    { new Guid("ee047b65-10e9-4c16-8c24-852b7f44b393"), new Guid("56cab740-14fb-409b-8aaf-cb02ca9e096a"), new Guid("0cc4ae58-44c5-4e45-9dc5-21468031dc9b") },
                    { new Guid("ee068479-44ba-4c1d-a1e9-99c4c69b5308"), new Guid("eb95fee1-b6e4-4cfe-bd00-15ceff3a55b1"), new Guid("a08ee877-4cf4-403b-9678-e2f1b23d8878") },
                    { new Guid("ee7e3d02-834a-4d37-9e7f-d0e3fd93790d"), new Guid("6e871c9a-508d-4fd6-98c6-fac9db4f1673"), new Guid("08e75384-8ef9-4da6-9fb9-648172732e75") },
                    { new Guid("ef3ef81e-0e60-43ad-8b49-a476fd451a00"), new Guid("92d01afe-4916-4f43-955c-ac1be3bd5c8c"), new Guid("eab8925c-390d-47e5-a75a-1a5439468c7a") },
                    { new Guid("f2011f73-d59d-4829-a7ca-a538141c0420"), new Guid("3cfafc94-2758-46f1-9ecd-8a5157a7db1d"), new Guid("8e0bae39-e098-490b-9a10-6ddbef3fe167") },
                    { new Guid("f30f7b45-25e1-4955-9226-c6b19cebfa7a"), new Guid("a65f7a50-2e1e-465c-b610-868675e8784f"), new Guid("8977ecb5-4ca4-4fa8-bc0c-27d836e83856") },
                    { new Guid("f3167102-e1d5-406a-9ca9-b11a34970e15"), new Guid("92d01afe-4916-4f43-955c-ac1be3bd5c8c"), new Guid("711ab67c-8741-4716-bde3-b909968154c9") },
                    { new Guid("f37137fb-2c6c-4a6d-b160-bca270272d91"), new Guid("937e758d-d7a5-4b38-94d7-4656f07b90c5"), new Guid("93e89f1e-9c4b-4e65-a783-2eb8e2f8a881") },
                    { new Guid("f793b399-ac36-4f32-b056-021f0c81a4e8"), new Guid("937e758d-d7a5-4b38-94d7-4656f07b90c5"), new Guid("199b19b4-9805-48a7-b4f0-82aff0b860a3") },
                    { new Guid("f9260246-da57-464b-9410-5963492b6db1"), new Guid("baaf359a-3b46-4bcf-9910-80dc47624aa2"), new Guid("26a33598-8ac4-4034-8aa5-3fb93b0b735e") },
                    { new Guid("fb54a481-abd8-431c-9e35-92bfd42ca67d"), new Guid("eb95fee1-b6e4-4cfe-bd00-15ceff3a55b1"), new Guid("5c3f84f4-892f-4467-9062-04b4a8efb98c") },
                    { new Guid("fbd1c616-0823-45e9-a9fe-db86ccc55d09"), new Guid("a65f7a50-2e1e-465c-b610-868675e8784f"), new Guid("ed0e1ffa-eab5-4a7d-96eb-c6b190263f3f") },
                    { new Guid("fee7f011-9c89-48b6-977d-887348bcbefa"), new Guid("e761a14d-22b0-4945-b744-f3a39e1a0d6c"), new Guid("06336b79-9656-4488-b966-8557799d6915") },
                    { new Guid("ff184568-3c81-4e62-87ce-8a88b966c3e6"), new Guid("eb95fee1-b6e4-4cfe-bd00-15ceff3a55b1"), new Guid("2ca1c61c-74a6-4d49-a8b6-e0a5609026a9") }
                });

            migrationBuilder.InsertData(
                table: "UserPerformanceSummaries",
                columns: new[] { "Id", "CorrectAnswers", "CreatedAt", "LastUpdatedAt", "SuccessRate", "TopicId", "TotalQuestionsAnswered", "UserId" },
                values: new object[,]
                {
                    { new Guid("04202e64-fe0e-4d6f-89c3-1ad20ca21493"), 65, new DateTime(2025, 7, 25, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8851), new DateTime(2025, 8, 15, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8852), 94.200000000000003, new Guid("a65f7a50-2e1e-465c-b610-868675e8784f"), 69, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("16b8e346-aa9a-4f05-93e1-53fbff8afb5b"), 32, new DateTime(2025, 8, 7, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8930), new DateTime(2025, 8, 16, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8930), 57.140000000000001, new Guid("83dbc18a-d74e-4739-9381-e053df055e62"), 56, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("26b0986a-f25f-40bb-b0c8-48f572d0c59d"), 7, new DateTime(2025, 8, 8, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8924), new DateTime(2025, 8, 18, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8925), 46.670000000000002, new Guid("e761a14d-22b0-4945-b744-f3a39e1a0d6c"), 15, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("30a23a55-b2a1-42d2-85af-ca45c2dec6ac"), 43, new DateTime(2025, 7, 31, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8928), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8928), 57.329999999999998, new Guid("f0ba3089-1edf-4ce0-8d72-010d4844ae30"), 75, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("3871f63c-3097-4064-893f-5200cc819b74"), 86, new DateTime(2025, 8, 14, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8939), new DateTime(2025, 8, 17, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8939), 98.849999999999994, new Guid("e761a14d-22b0-4945-b744-f3a39e1a0d6c"), 87, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("39c8fe32-5bb0-4324-8c00-4e228eceff42"), 15, new DateTime(2025, 8, 17, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8934), new DateTime(2025, 8, 15, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8935), 34.880000000000003, new Guid("a65f7a50-2e1e-465c-b610-868675e8784f"), 43, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("414aa3b1-4311-43e0-a40c-ec27d528d6b8"), 18, new DateTime(2025, 8, 7, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8937), new DateTime(2025, 8, 16, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8937), 66.670000000000002, new Guid("902cba99-1f15-4af3-bb1c-ced5a7dd5bc9"), 27, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("5fe1c53e-2c37-4693-832f-2f7e7275de4a"), 19, new DateTime(2025, 8, 7, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8834), new DateTime(2025, 8, 13, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8841), 76.0, new Guid("f0ba3089-1edf-4ce0-8d72-010d4844ae30"), 25, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("98ee28da-1603-43c1-a3e5-fb85752d14c8"), 35, new DateTime(2025, 8, 5, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8907), new DateTime(2025, 8, 18, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8907), 46.049999999999997, new Guid("e761a14d-22b0-4945-b744-f3a39e1a0d6c"), 76, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("b787ac6e-141d-4e8b-acf7-ff525702f7cb"), 11, new DateTime(2025, 8, 17, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8921), new DateTime(2025, 8, 17, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8921), 91.670000000000002, new Guid("902cba99-1f15-4af3-bb1c-ced5a7dd5bc9"), 12, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("c33c88e6-6cfa-4963-862f-8c22a50ac190"), 8, new DateTime(2025, 8, 16, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8849), new DateTime(2025, 8, 18, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8849), 29.629999999999999, new Guid("83dbc18a-d74e-4739-9381-e053df055e62"), 27, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c40cf366-ed36-4190-b1e4-2ecd792ad553"), 26, new DateTime(2025, 8, 13, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8914), new DateTime(2025, 8, 18, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8915), 96.299999999999997, new Guid("f0ba3089-1edf-4ce0-8d72-010d4844ae30"), 27, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("c9eb5fc0-7261-4731-a607-0641797ff6b3"), 25, new DateTime(2025, 8, 16, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8854), new DateTime(2025, 8, 18, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8854), 54.350000000000001, new Guid("902cba99-1f15-4af3-bb1c-ced5a7dd5bc9"), 46, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("ea01dc8c-0acb-4b99-997a-ff3d15e4aca3"), 38, new DateTime(2025, 7, 31, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8917), new DateTime(2025, 8, 16, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8917), 52.049999999999997, new Guid("83dbc18a-d74e-4739-9381-e053df055e62"), 73, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("f6b0c756-fd8b-4df9-8763-3600d4245c21"), 10, new DateTime(2025, 8, 7, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8919), new DateTime(2025, 8, 19, 8, 59, 19, 606, DateTimeKind.Utc).AddTicks(8919), 76.920000000000002, new Guid("a65f7a50-2e1e-465c-b610-868675e8784f"), 13, new Guid("22222222-2222-2222-2222-222222222222") }
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
