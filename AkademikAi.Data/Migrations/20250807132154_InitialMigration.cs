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
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "dummy-conc-1", new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9758), "ali@example.com", true, false, null, "Ali", "ALI@EXAMPLE.COM", "ALI", "AQAAAAEAACcQAAAAEDummyHash1==", "5551111111", false, "dummy-stamp-1", "Veli", false, "ali", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "dummy-conc-2", new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9766), "ayse@example.com", true, false, null, "Ayşe", "AYSE@EXAMPLE.COM", "AYSE", "AQAAAAEAACcQAAAAEDummyHash2==", "5552222222", false, "dummy-stamp-2", "Yılmaz", false, "ayse", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "dummy-conc-3", new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9796), "mehmet@example.com", true, false, null, "Mehmet", "MEHMET@EXAMPLE.COM", "MEHMET", "AQAAAAEAACcQAAAAEDummyHash3==", "5553333333", false, "dummy-stamp-3", "Demir", false, "mehmet", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevel", "GeneratedForUserId", "IsActive", "QuestionText", "SolutionText", "Source" },
                values: new object[,]
                {
                    { new Guid("03bfa8a7-93c9-4cbe-b9e9-0c1ac77156d8"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("04c7f17a-78a5-42a0-b449-47824a1a2b4f"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0604f96e-8559-4a9f-bd2e-0b1841b8e57c"), 2, null, true, "Hücre konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("09acf546-5843-4004-80f9-50b874f052b0"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0ea05b44-952b-4dd1-bc36-299ba9498a1e"), 1, null, true, "Kalıtım konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0f427dcb-4184-465a-a576-ba04c797429c"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("10edea59-5fde-4ac7-8be2-9fe88f953ebd"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1172d678-348d-46c4-b83d-7c0309ce818a"), 1, null, true, "Kalıtım konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("15d2a829-ce0d-4053-9110-acc0fefec4ce"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("16e97036-90b0-4531-aa79-1356e62d7e0d"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1833398a-7439-49a1-9298-1c67ee9965c6"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("18c0168d-72d4-48dd-995b-7419519d213a"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2ce01653-bb0e-4dff-b914-b326422645bd"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2e1a6023-dd55-4731-bb12-036c52c2239f"), 2, null, true, "Elektrostatik konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2f3ffe58-76a0-4606-9556-8f33eb206256"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("35cba56a-9c1f-4c1b-8f9a-fea395e1ff99"), 2, null, true, "Sayı Basamakları konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("37d6f10e-c035-4779-98d4-38e99e2650a0"), 2, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3901fd77-e668-458a-bb9c-d5126c131bf9"), 1, null, true, "Hücre konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("396eba31-d145-4f20-8b4e-fbab042041af"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3b68d56e-0a7a-455c-a2b4-c46d7da1ad17"), 0, null, true, "Kalıtım konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3e0b2125-1137-4fae-a56d-7a73b625535d"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("40abdf7a-4c60-4aea-80c1-4fb0bcea6545"), 2, null, true, "Kalıtım konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4613e5e0-97dc-4a0c-a755-05a65b74376b"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4837789b-b171-4698-b5a2-23f90e1be593"), 2, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4d6df717-fbc0-4950-8104-c7f552977e77"), 2, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4e1a5fed-6a72-4e03-a2c9-0235d079b4c8"), 2, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4f5e358d-f82d-4c9d-ad75-e7ea88d58e6f"), 2, null, true, "Kimya Bilimi konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4fb4073c-ca6b-4a72-bdb5-1f79777701dd"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("53077c0e-1884-4d6a-a128-d8ee9b410822"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("556ceb04-7c37-4ee1-8b45-0c2388393495"), 1, null, true, "Hücre konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("577aee49-fde5-483b-81d8-d433c3ed578f"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("58218d2a-cf24-4f59-a3f2-044be6e62a4e"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("59b9584b-3741-4357-9321-0828919951ff"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5b658537-f30f-4e2c-890d-3c5c17514784"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("616002e8-a5c3-43e6-a934-e9341ef37268"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("62b69aaf-f178-4d91-bf9a-4a71e78d6963"), 2, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("687d5a60-e0a7-4837-9ca5-23dc1e923069"), 2, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6b988903-14c1-4408-b681-6b35c5435309"), 2, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6d6137f0-d451-4382-a466-e29f7007980d"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6dbfafa1-9246-425f-a9a9-a8fb675373db"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6fafb9e7-75ca-463a-ad30-72356e12fd43"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6fd242ee-7d79-4d17-aa10-cdc75b053644"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("76304573-b455-48c1-bda2-21632ba096fe"), 0, null, true, "Problemler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("77419c6a-2c89-45ae-b5c8-44cee62a8cb1"), 1, null, true, "Problemler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("77cc75de-44d5-4a51-beb2-a592b05966be"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("78bbc65e-a615-4705-a4ea-1b9dc552a82d"), 2, null, true, "Maddenin Halleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("78d4ea3b-9af6-40b1-8b70-0c8699b60e5d"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7e62a768-fb2c-4cd9-8d8b-2e107a5bedbf"), 2, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("805fe97e-0c5e-4d42-b6c9-1651f81a0975"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("822514d4-6b32-453e-ab6f-51519f540fda"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("83cea481-cf9d-4001-98f8-c2fe416bbce7"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8b42e08e-0b8d-4abb-adde-6f46fd3e9d8a"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("91dfc8bd-b7e2-4a67-be09-eee17cd91e61"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("97674af0-4afc-4631-932d-012e5ef5ada3"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9787b9c9-1ae8-48c1-8853-e60327ff2633"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9a39674d-58ac-4e51-b97b-4b1ada660c52"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9c1896ef-5d2a-4cd1-8080-b0f63eeb6488"), 0, null, true, "Hücre konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9dcf362b-cba4-4b9c-873e-d3bb1276d008"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a0f91289-e705-4772-b298-a5f81ebe5ad5"), 1, null, true, "Problemler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a23e372a-03b9-40bd-922b-c8c678651ce9"), 0, null, true, "Hücre konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a4292e06-0cb7-4b22-9b81-69a37cc7f538"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a67002b0-f652-40c3-a097-1e61847592a8"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a84ea548-c1e3-40e8-9bbd-dbe29d3784a7"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ab8f27c6-350d-484c-9a9e-f0ffdc9862bc"), 0, null, true, "Kalıtım konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("aee10aee-00c3-424f-b8ea-ecf661170258"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b1f52cc3-78a9-4132-a420-0f6ca34a7c18"), 2, null, true, "Problemler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b276f802-fc02-4795-adb1-25e51edbe0bb"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b7fddbc4-d0d9-4d11-b179-d54a3b8d5c29"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b81ca42d-db92-41e3-a38a-69a072344be7"), 2, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("baa8e93f-3bea-47cc-9027-a6091693ccfe"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c08f1dee-0678-4fa9-84a8-70efb13c6790"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c9f2259f-fc9c-43a7-b4fa-7caf7004d21d"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ca022ff0-2082-4994-ac28-c6fb111d024e"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("cdcadaa8-d89e-4885-a3e8-cadfcf15483c"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ce9701a4-91da-4eff-b9c7-fd5f94903df0"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d1b2184c-dc3c-4a5f-abc6-b3ee58d54a5a"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d53db1cd-4638-4559-b2b5-e547dec881ad"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d65a8559-407e-4ad0-9440-86a0b977462e"), 0, null, true, "Problemler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d6f82f30-79ab-4c4b-bc39-4041420e0ee5"), 2, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d91a3c6a-43be-4ed7-b96d-53f248c64ca3"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("da360ff9-8b66-48d4-86b0-85b4a375ce6d"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("dbbca985-9be3-4ff1-bee8-9ea34f5c6314"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("dbce2b19-465b-40c3-ada1-3c0c4ba53c56"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("dc653c71-734f-4075-986b-aad18545a81d"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e08dff57-8a65-48bd-95b7-435e8e8ec667"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e1ded32b-f943-48a4-82e5-5706d8cbd01a"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e22d4674-8953-4e4a-9b8e-4892d9b9006e"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e3cd3934-06d1-4da2-af6f-55a8b9a94a49"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e4e028a6-beba-48b9-b82e-94f7d01486cf"), 2, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e6190ebb-2fef-478f-af44-cfdba14440a5"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ed7977f0-75c1-4ee0-a035-bb6875818830"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("eed7f50e-be17-4fa6-9183-65697522351f"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f3da37c6-5f29-4e70-a63f-a8dc3a4f1421"), 2, null, true, "Temel Kavramlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f3e06e73-a04b-4b47-a255-ec2608778018"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f46a9bd5-6b08-4818-ad5f-df1deb0b326b"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f51ee193-8a7d-48cd-ab48-fe72bcd7f605"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f7548d51-822a-445a-8d1b-679e7dff2519"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fcceb9bf-9d39-46fd-81ec-6b7984a422f0"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fd1ef666-b343-430a-935c-e90658a3bb44"), 2, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ffa8b6a4-472c-491a-a802-6c9d4e50da05"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9886), "Temel kimya konuları", true, "Kimya" },
                    { new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9884), "Temel fizik konuları", true, "Fizik" },
                    { new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9888), "Temel biyoloji konuları", true, "Biyoloji" },
                    { new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9881), "Temel matematik konuları", true, "Matematik" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "IsCorrect", "Label", "OptionOrder", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("00d364d3-4a2a-4e17-ab9f-8dbaf77e447e"), false, "C", 3, "Madde ve Özellikleri - Soru 3 için Seçenek C", new Guid("9787b9c9-1ae8-48c1-8853-e60327ff2633") },
                    { new Guid("03426159-d2c9-4311-ba91-c2cc9ed1a25e"), false, "D", 4, "Sayı Basamakları - Soru 2 için Seçenek D", new Guid("ed7977f0-75c1-4ee0-a035-bb6875818830") },
                    { new Guid("035dcfba-90b5-4651-9b53-2634c01a28a0"), true, "B", 2, "Kimya Bilimi - Soru 5 için Seçenek B", new Guid("4f5e358d-f82d-4c9d-ad75-e7ea88d58e6f") },
                    { new Guid("03aadd6b-40bc-4f33-930e-ec186c6629cd"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 1 için Seçenek C", new Guid("aee10aee-00c3-424f-b8ea-ecf661170258") },
                    { new Guid("03cf5c87-fa50-4020-85f9-383ad5f8b0e9"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek D", new Guid("91dfc8bd-b7e2-4a67-be09-eee17cd91e61") },
                    { new Guid("0537dcd1-8d3a-4141-a9d6-2c19c81123e0"), false, "D", 4, "Hücre Bölünmeleri - Soru 3 için Seçenek D", new Guid("b276f802-fc02-4795-adb1-25e51edbe0bb") },
                    { new Guid("06a1dbd1-7154-471a-acd4-bac59c1cbe4e"), false, "C", 3, "Rasyonel Sayılar - Soru 4 için Seçenek C", new Guid("6fafb9e7-75ca-463a-ad30-72356e12fd43") },
                    { new Guid("07bd2c52-bd56-42a6-8799-3cb7ea207f8d"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 3 için Seçenek D", new Guid("15d2a829-ce0d-4053-9110-acc0fefec4ce") },
                    { new Guid("080684f8-0b57-4b0b-a853-04b9f61de8cb"), true, "A", 1, "Sayı Basamakları - Soru 2 için Seçenek A", new Guid("ed7977f0-75c1-4ee0-a035-bb6875818830") },
                    { new Guid("083ab6b1-70ad-4e66-865e-926dabdb2b2d"), false, "A", 1, "Sayı Basamakları - Soru 5 için Seçenek A", new Guid("35cba56a-9c1f-4c1b-8f9a-fea395e1ff99") },
                    { new Guid("08c09528-1bb3-4e6a-b233-8e34bd67d598"), false, "A", 1, "Hücre Bölünmeleri - Soru 1 için Seçenek A", new Guid("2ce01653-bb0e-4dff-b914-b326422645bd") },
                    { new Guid("08f28e00-82ed-4c99-b779-38a0549e8b0e"), true, "B", 2, "Madde ve Özellikleri - Soru 3 için Seçenek B", new Guid("9787b9c9-1ae8-48c1-8853-e60327ff2633") },
                    { new Guid("09838bf4-9845-4d5f-b84f-63ded6308628"), false, "D", 4, "Sayı Basamakları - Soru 1 için Seçenek D", new Guid("805fe97e-0c5e-4d42-b6c9-1651f81a0975") },
                    { new Guid("09a8a3a3-9f51-411c-a806-244dbd756770"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 5 için Seçenek C", new Guid("4e1a5fed-6a72-4e03-a2c9-0235d079b4c8") },
                    { new Guid("0a7e1c4e-b9bf-4500-8326-e0dd5e484d93"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 5 için Seçenek B", new Guid("4e1a5fed-6a72-4e03-a2c9-0235d079b4c8") },
                    { new Guid("0b0bfeac-e3a8-480f-b9ec-fbb097f5fa2b"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek A", new Guid("37d6f10e-c035-4779-98d4-38e99e2650a0") },
                    { new Guid("0b562c16-1955-4d07-9f6f-e621c9951092"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek B", new Guid("6d6137f0-d451-4382-a466-e29f7007980d") },
                    { new Guid("0bbde555-2943-43c3-a82e-07f1aaa45c6e"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 2 için Seçenek A", new Guid("822514d4-6b32-453e-ab6f-51519f540fda") },
                    { new Guid("0c66feff-93da-4e25-8733-5a4c1e03299b"), false, "B", 2, "Bölme ve Bölünebilme - Soru 1 için Seçenek B", new Guid("c9f2259f-fc9c-43a7-b4fa-7caf7004d21d") },
                    { new Guid("0c8643f4-d8ca-42ee-844f-5376970d4791"), false, "C", 3, "Fizik Bilimine Giriş - Soru 2 için Seçenek C", new Guid("09acf546-5843-4004-80f9-50b874f052b0") },
                    { new Guid("0cc0bb77-8e32-4a1f-b7c6-b01d11a731b4"), false, "B", 2, "Kuvvet ve Hareket - Soru 5 için Seçenek B", new Guid("7e62a768-fb2c-4cd9-8d8b-2e107a5bedbf") },
                    { new Guid("0db2463f-96da-4a86-b8c7-1989a3a88e76"), true, "C", 3, "Kuvvet ve Hareket - Soru 3 için Seçenek C", new Guid("5b658537-f30f-4e2c-890d-3c5c17514784") },
                    { new Guid("0dd6cb3f-784b-4570-9150-d6736d5389f2"), true, "D", 4, "İş, Güç ve Enerji - Soru 3 için Seçenek D", new Guid("1833398a-7439-49a1-9298-1c67ee9965c6") },
                    { new Guid("0e322d65-ae7d-43f0-8f44-e5506da234f8"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek A", new Guid("53077c0e-1884-4d6a-a128-d8ee9b410822") },
                    { new Guid("0fae367a-a843-4236-8057-294e6b7b96ec"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek A", new Guid("83cea481-cf9d-4001-98f8-c2fe416bbce7") },
                    { new Guid("10a92fab-844b-485f-b8b3-6a42a2491af5"), false, "B", 2, "Maddenin Halleri - Soru 1 için Seçenek B", new Guid("78d4ea3b-9af6-40b1-8b70-0c8699b60e5d") },
                    { new Guid("10e8a29a-bc1a-4620-841b-7589d25fe8ff"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek B", new Guid("f51ee193-8a7d-48cd-ab48-fe72bcd7f605") },
                    { new Guid("122f38cc-a0b4-46a7-8987-c8dea55d7be9"), false, "D", 4, "Kalıtım - Soru 1 için Seçenek D", new Guid("ab8f27c6-350d-484c-9a9e-f0ffdc9862bc") },
                    { new Guid("13830c92-b6f2-4287-91dd-23820a6f2d16"), false, "A", 1, "İş, Güç ve Enerji - Soru 2 için Seçenek A", new Guid("4613e5e0-97dc-4a0c-a755-05a65b74376b") },
                    { new Guid("13db68d0-5ba1-4b1e-9acd-fef487c3836e"), false, "A", 1, "Kimya Bilimi - Soru 4 için Seçenek A", new Guid("577aee49-fde5-483b-81d8-d433c3ed578f") },
                    { new Guid("1472130c-d9e8-4c38-a12e-d4316e79c36c"), false, "A", 1, "Sayı Basamakları - Soru 1 için Seçenek A", new Guid("805fe97e-0c5e-4d42-b6c9-1651f81a0975") },
                    { new Guid("149fa92a-d92e-4728-8a10-1e313e3bc3dd"), false, "B", 2, "Temel Kavramlar - Soru 2 için Seçenek B", new Guid("e22d4674-8953-4e4a-9b8e-4892d9b9006e") },
                    { new Guid("14aaa633-ceee-47b0-9431-e3dd84b9d886"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek B", new Guid("53077c0e-1884-4d6a-a128-d8ee9b410822") },
                    { new Guid("1535bb8c-ab7b-4cca-bb17-48a9309faa11"), false, "B", 2, "Temel Kavramlar - Soru 1 için Seçenek B", new Guid("f7548d51-822a-445a-8d1b-679e7dff2519") },
                    { new Guid("15a5486c-be95-4d92-b9dc-83bd16ce3ad5"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek C", new Guid("e3cd3934-06d1-4da2-af6f-55a8b9a94a49") },
                    { new Guid("162f49fe-8ba0-40b1-bb44-49260d624001"), false, "A", 1, "Temel Kavramlar - Soru 1 için Seçenek A", new Guid("f7548d51-822a-445a-8d1b-679e7dff2519") },
                    { new Guid("16b48a38-b070-4193-aa90-2a0453d94d31"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek B", new Guid("f46a9bd5-6b08-4818-ad5f-df1deb0b326b") },
                    { new Guid("1763b3cc-1159-4745-b62b-23094b08e847"), false, "D", 4, "Temel Kavramlar - Soru 5 için Seçenek D", new Guid("f3da37c6-5f29-4e70-a63f-a8dc3a4f1421") },
                    { new Guid("191dac88-94b3-4577-9b68-ecd83049a48b"), false, "D", 4, "Fizik Bilimine Giriş - Soru 5 için Seçenek D", new Guid("d6f82f30-79ab-4c4b-bc39-4041420e0ee5") },
                    { new Guid("1a41bae2-3558-4901-80f0-ddef37117bd9"), false, "C", 3, "Temel Kavramlar - Soru 3 için Seçenek C", new Guid("396eba31-d145-4f20-8b4e-fbab042041af") },
                    { new Guid("1afc2b94-bc63-4e5c-b40a-a0fbfa529a3b"), false, "A", 1, "Maddenin Halleri - Soru 2 için Seçenek A", new Guid("dc653c71-734f-4075-986b-aad18545a81d") },
                    { new Guid("1b5c5015-aebc-4fdd-bfdb-6187e369f58b"), true, "A", 1, "Kuvvet ve Hareket - Soru 1 için Seçenek A", new Guid("e6190ebb-2fef-478f-af44-cfdba14440a5") },
                    { new Guid("1b96385e-fd15-4c4f-a012-03a620416b15"), false, "C", 3, "Maddenin Halleri - Soru 5 için Seçenek C", new Guid("78bbc65e-a615-4705-a4ea-1b9dc552a82d") },
                    { new Guid("1bae9daa-1d3f-4149-ae49-92048ea56802"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek A", new Guid("4d6df717-fbc0-4950-8104-c7f552977e77") },
                    { new Guid("1c54b1b1-6998-4250-b1f3-d0aea49108ba"), false, "A", 1, "Maddenin Halleri - Soru 1 için Seçenek A", new Guid("78d4ea3b-9af6-40b1-8b70-0c8699b60e5d") },
                    { new Guid("1db187c4-65c9-4284-95b6-b1414a064ec5"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek D", new Guid("4837789b-b171-4698-b5a2-23f90e1be593") },
                    { new Guid("1ea8dbfc-5066-406f-9946-b9530975ea36"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek B", new Guid("fcceb9bf-9d39-46fd-81ec-6b7984a422f0") },
                    { new Guid("1efb9045-a06d-438a-8c6b-78cb22986edd"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 2 için Seçenek C", new Guid("822514d4-6b32-453e-ab6f-51519f540fda") },
                    { new Guid("1fc00071-2232-4df3-8c31-1759b7452d91"), false, "C", 3, "Bölme ve Bölünebilme - Soru 2 için Seçenek C", new Guid("a4292e06-0cb7-4b22-9b81-69a37cc7f538") },
                    { new Guid("2026794d-37c2-42db-8422-76024548cbd0"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek B", new Guid("c08f1dee-0678-4fa9-84a8-70efb13c6790") },
                    { new Guid("20bc96eb-d2c7-4dd9-8271-ab922216da24"), true, "A", 1, "Kalıtım - Soru 3 için Seçenek A", new Guid("3b68d56e-0a7a-455c-a2b4-c46d7da1ad17") },
                    { new Guid("2177dbdc-98a3-4a00-9a5c-fefcacd117e3"), true, "D", 4, "Temel Kavramlar - Soru 3 için Seçenek D", new Guid("396eba31-d145-4f20-8b4e-fbab042041af") },
                    { new Guid("221da3bc-41f4-475b-b567-143edfebf9e5"), true, "D", 4, "Maddenin Halleri - Soru 2 için Seçenek D", new Guid("dc653c71-734f-4075-986b-aad18545a81d") },
                    { new Guid("22a237f1-80aa-4a91-b50b-a5c44c0963d1"), true, "B", 2, "Rasyonel Sayılar - Soru 4 için Seçenek B", new Guid("6fafb9e7-75ca-463a-ad30-72356e12fd43") },
                    { new Guid("231b5d25-b497-4cfb-8f6e-49f02e48b490"), false, "D", 4, "Madde ve Özellikleri - Soru 1 için Seçenek D", new Guid("dbce2b19-465b-40c3-ada1-3c0c4ba53c56") },
                    { new Guid("233af581-76e1-4139-8187-b4004f187205"), false, "C", 3, "Rasyonel Sayılar - Soru 2 için Seçenek C", new Guid("0f427dcb-4184-465a-a576-ba04c797429c") },
                    { new Guid("244c503c-c4c5-4c11-b6b7-0932be84051a"), false, "C", 3, "Bölme ve Bölünebilme - Soru 4 için Seçenek C", new Guid("e08dff57-8a65-48bd-95b7-435e8e8ec667") },
                    { new Guid("24c3e763-c425-44f7-9007-b74d04718cbe"), true, "D", 4, "İş, Güç ve Enerji - Soru 1 için Seçenek D", new Guid("10edea59-5fde-4ac7-8be2-9fe88f953ebd") },
                    { new Guid("251df8de-7630-4efb-a01c-ac711f6249f5"), true, "A", 1, "Maddenin Halleri - Soru 5 için Seçenek A", new Guid("78bbc65e-a615-4705-a4ea-1b9dc552a82d") },
                    { new Guid("2532d639-03bb-4ee0-995c-40ace337741d"), true, "A", 1, "Atom ve Periyodik Sistem - Soru 2 için Seçenek A", new Guid("04c7f17a-78a5-42a0-b449-47824a1a2b4f") },
                    { new Guid("2536390e-c695-4c2c-9f4f-2b5089ae5bc8"), true, "C", 3, "Hücre Bölünmeleri - Soru 3 için Seçenek C", new Guid("b276f802-fc02-4795-adb1-25e51edbe0bb") },
                    { new Guid("263fb6f5-3f69-488c-b0df-348d2338b17b"), false, "C", 3, "Elektrostatik - Soru 4 için Seçenek C", new Guid("59b9584b-3741-4357-9321-0828919951ff") },
                    { new Guid("2650ade3-68cc-495d-ad94-4aed33b37c9d"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek D", new Guid("e3cd3934-06d1-4da2-af6f-55a8b9a94a49") },
                    { new Guid("2799d557-9cd4-4c49-bff9-183d877500d8"), true, "D", 4, "Bölme ve Bölünebilme - Soru 3 için Seçenek D", new Guid("9dcf362b-cba4-4b9c-873e-d3bb1276d008") },
                    { new Guid("27e339fe-5b17-4e18-9b02-709da1fda9c4"), false, "C", 3, "Bölme ve Bölünebilme - Soru 1 için Seçenek C", new Guid("c9f2259f-fc9c-43a7-b4fa-7caf7004d21d") },
                    { new Guid("281df144-03e2-4d7f-b27b-593e3d0bb200"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 5 için Seçenek A", new Guid("4e1a5fed-6a72-4e03-a2c9-0235d079b4c8") },
                    { new Guid("299ab1c7-fbf1-453e-b34d-1b59231d28fb"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 5 için Seçenek D", new Guid("4e1a5fed-6a72-4e03-a2c9-0235d079b4c8") },
                    { new Guid("29fb364c-2c39-44df-8fc8-ccc99c0b83ee"), false, "A", 1, "Maddenin Halleri - Soru 4 için Seçenek A", new Guid("3e0b2125-1137-4fae-a56d-7a73b625535d") },
                    { new Guid("2a3a6f93-6fb8-48c3-bd27-0ebc49a3e0b9"), true, "C", 3, "Kimya Bilimi - Soru 3 için Seçenek C", new Guid("a67002b0-f652-40c3-a097-1e61847592a8") },
                    { new Guid("2b75e15b-6182-4253-bd97-8c5c65d3ce7f"), false, "A", 1, "Kimya Bilimi - Soru 5 için Seçenek A", new Guid("4f5e358d-f82d-4c9d-ad75-e7ea88d58e6f") },
                    { new Guid("2d0983b5-2f1d-4644-a08b-551925190e90"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek C", new Guid("83cea481-cf9d-4001-98f8-c2fe416bbce7") },
                    { new Guid("2d7b4033-b49f-4c35-a9d7-a5b696ab0e9d"), false, "D", 4, "Kimya Bilimi - Soru 5 için Seçenek D", new Guid("4f5e358d-f82d-4c9d-ad75-e7ea88d58e6f") },
                    { new Guid("2f7387e0-efb2-4078-a13f-8138556f4616"), true, "D", 4, "Hücre Bölünmeleri - Soru 1 için Seçenek D", new Guid("2ce01653-bb0e-4dff-b914-b326422645bd") },
                    { new Guid("2fbf608b-cd4e-4ea6-84f8-f3eb291c0f57"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek D", new Guid("4d6df717-fbc0-4950-8104-c7f552977e77") },
                    { new Guid("312cfef3-17a0-4d71-a31a-6b3029925f8b"), true, "B", 2, "Fizik Bilimine Giriş - Soru 2 için Seçenek B", new Guid("09acf546-5843-4004-80f9-50b874f052b0") },
                    { new Guid("316dc44e-1e5c-4832-806d-42dbd142ba18"), true, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek C", new Guid("f3e06e73-a04b-4b47-a255-ec2608778018") },
                    { new Guid("337606eb-197d-48c6-973e-a1b17fddaabb"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek C", new Guid("4837789b-b171-4698-b5a2-23f90e1be593") },
                    { new Guid("34d03442-6445-4723-9138-12ccd2168382"), false, "A", 1, "Bölme ve Bölünebilme - Soru 4 için Seçenek A", new Guid("e08dff57-8a65-48bd-95b7-435e8e8ec667") },
                    { new Guid("35273557-6568-48e3-867e-906ed1afee8e"), true, "D", 4, "Maddenin Halleri - Soru 4 için Seçenek D", new Guid("3e0b2125-1137-4fae-a56d-7a73b625535d") },
                    { new Guid("36a3ccb3-1e9e-41ca-9bc1-2646b527c0be"), false, "B", 2, "Elektrostatik - Soru 3 için Seçenek B", new Guid("18c0168d-72d4-48dd-995b-7419519d213a") },
                    { new Guid("36d29473-62d7-4043-b384-c2c00aa059c0"), false, "A", 1, "Problemler - Soru 3 için Seçenek A", new Guid("76304573-b455-48c1-bda2-21632ba096fe") },
                    { new Guid("3724515a-6e3f-481d-bcc0-aad345e95332"), false, "D", 4, "Kimya Bilimi - Soru 4 için Seçenek D", new Guid("577aee49-fde5-483b-81d8-d433c3ed578f") },
                    { new Guid("3736406f-cdf6-413e-a155-97e0b833aa3b"), false, "A", 1, "Madde ve Özellikleri - Soru 3 için Seçenek A", new Guid("9787b9c9-1ae8-48c1-8853-e60327ff2633") },
                    { new Guid("39782800-6c19-4057-8211-41a6bd48b03d"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 3 için Seçenek A", new Guid("15d2a829-ce0d-4053-9110-acc0fefec4ce") },
                    { new Guid("397a2ffc-84e5-4a4c-921e-9a6e2c4582fb"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 1 için Seçenek D", new Guid("aee10aee-00c3-424f-b8ea-ecf661170258") },
                    { new Guid("3a224a37-38a4-40bb-850d-efd1cd621305"), false, "D", 4, "Temel Kavramlar - Soru 2 için Seçenek D", new Guid("e22d4674-8953-4e4a-9b8e-4892d9b9006e") },
                    { new Guid("3a831e4b-337e-4ac4-a011-b3d950ad804c"), false, "D", 4, "Fizik Bilimine Giriş - Soru 2 için Seçenek D", new Guid("09acf546-5843-4004-80f9-50b874f052b0") },
                    { new Guid("3ae34c64-478a-4337-b79e-ddab47889836"), false, "C", 3, "Madde ve Özellikleri - Soru 1 için Seçenek C", new Guid("dbce2b19-465b-40c3-ada1-3c0c4ba53c56") },
                    { new Guid("3b5c91cf-5aa7-47d5-b1ac-d407a6c118a5"), true, "C", 3, "Kimya Bilimi - Soru 1 için Seçenek C", new Guid("6dbfafa1-9246-425f-a9a9-a8fb675373db") },
                    { new Guid("3b7edbe7-8aff-4555-8ed8-e1bfdff89f40"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 4 için Seçenek B", new Guid("da360ff9-8b66-48d4-86b0-85b4a375ce6d") },
                    { new Guid("3b97e5b4-227b-4563-a206-bafc62aa8f00"), true, "B", 2, "Sayı Basamakları - Soru 4 için Seçenek B", new Guid("03bfa8a7-93c9-4cbe-b9e9-0c1ac77156d8") },
                    { new Guid("3c8b484e-ebd1-42d9-a20c-053877e7e459"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 1 için Seçenek D", new Guid("77cc75de-44d5-4a51-beb2-a592b05966be") },
                    { new Guid("3d025938-aafa-4529-9178-cbd5bb26b704"), false, "B", 2, "Maddenin Halleri - Soru 5 için Seçenek B", new Guid("78bbc65e-a615-4705-a4ea-1b9dc552a82d") },
                    { new Guid("3e3c7e97-2372-486c-935a-bc3ae9f99e48"), true, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek A", new Guid("4837789b-b171-4698-b5a2-23f90e1be593") },
                    { new Guid("3e8c0c39-f476-400c-b586-4bcea57de9dc"), false, "A", 1, "Bölme ve Bölünebilme - Soru 2 için Seçenek A", new Guid("a4292e06-0cb7-4b22-9b81-69a37cc7f538") },
                    { new Guid("3e94b4e3-12bc-40a1-b88d-fbcc28b45313"), true, "D", 4, "Problemler - Soru 4 için Seçenek D", new Guid("77419c6a-2c89-45ae-b5c8-44cee62a8cb1") },
                    { new Guid("3ed7200a-c37f-4aab-bed6-32355e7f5256"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek A", new Guid("f51ee193-8a7d-48cd-ab48-fe72bcd7f605") },
                    { new Guid("3f063ccd-8e64-4e9c-9846-5ac50ea7c16b"), false, "D", 4, "Madde ve Özellikleri - Soru 2 için Seçenek D", new Guid("d53db1cd-4638-4559-b2b5-e547dec881ad") },
                    { new Guid("3fb7cc33-b49d-4110-8204-d504605c7f30"), true, "C", 3, "Kalıtım - Soru 4 için Seçenek C", new Guid("0ea05b44-952b-4dd1-bc36-299ba9498a1e") },
                    { new Guid("3ffdd908-3d83-4865-bb74-6e334fb42d8c"), false, "D", 4, "Elektrostatik - Soru 5 için Seçenek D", new Guid("2e1a6023-dd55-4731-bb12-036c52c2239f") },
                    { new Guid("43bb34b7-f92d-4295-bd61-f0f89955a897"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek A", new Guid("fcceb9bf-9d39-46fd-81ec-6b7984a422f0") },
                    { new Guid("444165e0-59d3-4801-897e-cf35c734963d"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek A", new Guid("e1ded32b-f943-48a4-82e5-5706d8cbd01a") },
                    { new Guid("44a4417e-5eec-466b-9630-c701d6c98418"), true, "A", 1, "Hücre - Soru 2 için Seçenek A", new Guid("556ceb04-7c37-4ee1-8b45-0c2388393495") },
                    { new Guid("47acfc8c-c190-4a01-9ee6-e7e6011f0150"), true, "C", 3, "İş, Güç ve Enerji - Soru 5 için Seçenek C", new Guid("6b988903-14c1-4408-b681-6b35c5435309") },
                    { new Guid("48d85e6b-af44-489a-b3a6-b17dbc97c494"), false, "C", 3, "Problemler - Soru 4 için Seçenek C", new Guid("77419c6a-2c89-45ae-b5c8-44cee62a8cb1") },
                    { new Guid("49440b89-ff9f-4343-a5fe-85d10893e9ba"), true, "B", 2, "Canlıların Sınıflandırılması - Soru 5 için Seçenek B", new Guid("b81ca42d-db92-41e3-a38a-69a072344be7") },
                    { new Guid("4a291957-4f55-4ec0-9d97-d024a0571b60"), false, "C", 3, "Kimya Bilimi - Soru 5 için Seçenek C", new Guid("4f5e358d-f82d-4c9d-ad75-e7ea88d58e6f") },
                    { new Guid("4a3ffab9-75ee-4684-8582-42a7f7238cb1"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek B", new Guid("f3e06e73-a04b-4b47-a255-ec2608778018") },
                    { new Guid("4ba95425-8580-4c80-b59c-1a9551ab4e36"), false, "B", 2, "Hücre - Soru 5 için Seçenek B", new Guid("0604f96e-8559-4a9f-bd2e-0b1841b8e57c") },
                    { new Guid("4c85a9d6-0018-4850-a0c2-68555a66bb85"), false, "A", 1, "Hücre - Soru 3 için Seçenek A", new Guid("a23e372a-03b9-40bd-922b-c8c678651ce9") },
                    { new Guid("4c9870ce-601b-4f97-b940-98770b2d6d9a"), false, "B", 2, "Problemler - Soru 4 için Seçenek B", new Guid("77419c6a-2c89-45ae-b5c8-44cee62a8cb1") },
                    { new Guid("4ceb5c58-f683-4314-90ef-69bee95ec0a7"), true, "C", 3, "İş, Güç ve Enerji - Soru 4 için Seçenek C", new Guid("16e97036-90b0-4531-aa79-1356e62d7e0d") },
                    { new Guid("4d63bae0-4cf0-40cd-a424-b9725fa16185"), false, "D", 4, "Kalıtım - Soru 3 için Seçenek D", new Guid("3b68d56e-0a7a-455c-a2b4-c46d7da1ad17") },
                    { new Guid("4d7e245e-4ddd-4263-9bad-536c276587ea"), true, "D", 4, "Hücre Bölünmeleri - Soru 5 için Seçenek D", new Guid("e4e028a6-beba-48b9-b82e-94f7d01486cf") },
                    { new Guid("4da379a9-c64a-4296-be50-90a890ba04dd"), false, "D", 4, "Hücre - Soru 4 için Seçenek D", new Guid("3901fd77-e668-458a-bb9c-d5126c131bf9") },
                    { new Guid("4dce382d-9466-4936-a73d-ae90d8675eb8"), false, "C", 3, "Kalıtım - Soru 1 için Seçenek C", new Guid("ab8f27c6-350d-484c-9a9e-f0ffdc9862bc") },
                    { new Guid("4f265a65-b6a9-4a57-b094-e53af56b32bf"), false, "C", 3, "Fizik Bilimine Giriş - Soru 4 için Seçenek C", new Guid("eed7f50e-be17-4fa6-9183-65697522351f") },
                    { new Guid("4f31f4ca-6b0a-476c-92d2-93788885375d"), false, "D", 4, "Kimya Bilimi - Soru 3 için Seçenek D", new Guid("a67002b0-f652-40c3-a097-1e61847592a8") },
                    { new Guid("4ff9af25-32e7-442a-9add-6f57bdac88ce"), false, "C", 3, "Temel Kavramlar - Soru 4 için Seçenek C", new Guid("4fb4073c-ca6b-4a72-bdb5-1f79777701dd") },
                    { new Guid("506623bf-dfe4-431f-aeea-08ce67ec452a"), true, "A", 1, "Problemler - Soru 5 için Seçenek A", new Guid("b1f52cc3-78a9-4132-a420-0f6ca34a7c18") },
                    { new Guid("510e838f-308b-4858-9e59-ef85d9c6c8ae"), false, "C", 3, "Problemler - Soru 3 için Seçenek C", new Guid("76304573-b455-48c1-bda2-21632ba096fe") },
                    { new Guid("5159d928-197f-493a-940b-73332e6f0d42"), false, "C", 3, "Madde ve Özellikleri - Soru 2 için Seçenek C", new Guid("d53db1cd-4638-4559-b2b5-e547dec881ad") },
                    { new Guid("51a9add8-3f3e-4006-91b8-dd4cde3e5cb0"), false, "A", 1, "Bölme ve Bölünebilme - Soru 5 için Seçenek A", new Guid("fd1ef666-b343-430a-935c-e90658a3bb44") },
                    { new Guid("52e80771-3cab-4834-ad07-2cbf5c67a3e4"), false, "D", 4, "Fizik Bilimine Giriş - Soru 1 için Seçenek D", new Guid("97674af0-4afc-4631-932d-012e5ef5ada3") },
                    { new Guid("531f510b-4845-44f4-baff-909ee2aa44b3"), true, "D", 4, "Bölme ve Bölünebilme - Soru 2 için Seçenek D", new Guid("a4292e06-0cb7-4b22-9b81-69a37cc7f538") },
                    { new Guid("539175a3-0ba6-42b5-8979-c99626212c3d"), false, "B", 2, "Fizik Bilimine Giriş - Soru 5 için Seçenek B", new Guid("d6f82f30-79ab-4c4b-bc39-4041420e0ee5") },
                    { new Guid("5440a7b8-a600-45b4-b158-d5a1bc833bf5"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 5 için Seçenek A", new Guid("b81ca42d-db92-41e3-a38a-69a072344be7") },
                    { new Guid("558117a2-340f-4a00-a4ed-ec17cea6c436"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 4 için Seçenek B", new Guid("6fd242ee-7d79-4d17-aa10-cdc75b053644") },
                    { new Guid("5614325e-276e-4764-9057-81cee92bcb18"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek A", new Guid("e3cd3934-06d1-4da2-af6f-55a8b9a94a49") },
                    { new Guid("5654c092-e93f-4a39-b472-82bbcd8fde28"), false, "A", 1, "Temel Kavramlar - Soru 2 için Seçenek A", new Guid("e22d4674-8953-4e4a-9b8e-4892d9b9006e") },
                    { new Guid("56a46b37-7611-4ebb-b144-0b4a28aa06ce"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 3 için Seçenek B", new Guid("ce9701a4-91da-4eff-b9c7-fd5f94903df0") },
                    { new Guid("57dfc529-098a-40ca-a1c6-c812647507d7"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 2 için Seçenek D", new Guid("04c7f17a-78a5-42a0-b449-47824a1a2b4f") },
                    { new Guid("58118e74-e62a-4bdf-8169-b2849630e5a0"), false, "B", 2, "Rasyonel Sayılar - Soru 3 için Seçenek B", new Guid("ca022ff0-2082-4994-ac28-c6fb111d024e") },
                    { new Guid("5826e72b-ed17-4c1a-9b7b-fe52d4a613fa"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek C", new Guid("6d6137f0-d451-4382-a466-e29f7007980d") },
                    { new Guid("59ee6157-09d5-4f3a-a5d8-9c8c0c569de5"), false, "A", 1, "Rasyonel Sayılar - Soru 5 için Seçenek A", new Guid("687d5a60-e0a7-4837-9ca5-23dc1e923069") },
                    { new Guid("5a01f792-f1ef-4204-8afd-d85394cf3c7c"), true, "D", 4, "Rasyonel Sayılar - Soru 5 için Seçenek D", new Guid("687d5a60-e0a7-4837-9ca5-23dc1e923069") },
                    { new Guid("5a22deb3-7e5a-441c-a8be-cfec7a1c724d"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek B", new Guid("e1ded32b-f943-48a4-82e5-5706d8cbd01a") },
                    { new Guid("5ab79081-5780-40d1-b123-41a4f335721f"), false, "A", 1, "İş, Güç ve Enerji - Soru 3 için Seçenek A", new Guid("1833398a-7439-49a1-9298-1c67ee9965c6") },
                    { new Guid("5b62cf2a-0f0c-4805-b701-4ca98c59bca1"), false, "C", 3, "Kimya Bilimi - Soru 2 için Seçenek C", new Guid("d1b2184c-dc3c-4a5f-abc6-b3ee58d54a5a") },
                    { new Guid("5c2598ce-00ec-48ae-b3b5-0265642634e5"), false, "B", 2, "Hücre Bölünmeleri - Soru 1 için Seçenek B", new Guid("2ce01653-bb0e-4dff-b914-b326422645bd") },
                    { new Guid("5d3a2c2f-c2ef-4701-b3b3-07c6ac71567a"), false, "B", 2, "Kimya Bilimi - Soru 2 için Seçenek B", new Guid("d1b2184c-dc3c-4a5f-abc6-b3ee58d54a5a") },
                    { new Guid("5d70242c-f34a-4fad-8622-56cdb9207a6b"), false, "C", 3, "Madde ve Özellikleri - Soru 5 için Seçenek C", new Guid("62b69aaf-f178-4d91-bf9a-4a71e78d6963") },
                    { new Guid("5d992ccb-e7f5-4773-8d1d-8c448d787a9e"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek D", new Guid("dbbca985-9be3-4ff1-bee8-9ea34f5c6314") },
                    { new Guid("5dd89fd9-8d60-4abc-9639-c9e35b6a8ec2"), false, "D", 4, "Elektrostatik - Soru 2 için Seçenek D", new Guid("baa8e93f-3bea-47cc-9027-a6091693ccfe") },
                    { new Guid("5e67c8bf-04f7-4549-904f-b3c32e501e9a"), false, "B", 2, "Elektrostatik - Soru 4 için Seçenek B", new Guid("59b9584b-3741-4357-9321-0828919951ff") },
                    { new Guid("5eabdf0c-8a48-4ce4-be3d-2af28ea5d2a7"), true, "D", 4, "İş, Güç ve Enerji - Soru 2 için Seçenek D", new Guid("4613e5e0-97dc-4a0c-a755-05a65b74376b") },
                    { new Guid("5f1e483b-3d10-4461-a22c-74b627cf0cd3"), false, "B", 2, "İş, Güç ve Enerji - Soru 2 için Seçenek B", new Guid("4613e5e0-97dc-4a0c-a755-05a65b74376b") },
                    { new Guid("5f400c46-cf85-4959-bd75-116922efc130"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 3 için Seçenek B", new Guid("15d2a829-ce0d-4053-9110-acc0fefec4ce") },
                    { new Guid("6151a9e6-d285-403e-83f5-4f944ee00cdb"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 3 için Seçenek C", new Guid("ce9701a4-91da-4eff-b9c7-fd5f94903df0") },
                    { new Guid("618f8a37-076b-4dc3-9f92-bd7fb21f3171"), false, "C", 3, "Problemler - Soru 2 için Seçenek C", new Guid("a0f91289-e705-4772-b298-a5f81ebe5ad5") },
                    { new Guid("6236dd8e-cdab-47c0-bcc5-e8b9926e59b3"), false, "C", 3, "Maddenin Halleri - Soru 3 için Seçenek C", new Guid("cdcadaa8-d89e-4885-a3e8-cadfcf15483c") },
                    { new Guid("628a6b24-e26f-4fdc-ac20-f052a5a7288e"), false, "D", 4, "Sayı Basamakları - Soru 4 için Seçenek D", new Guid("03bfa8a7-93c9-4cbe-b9e9-0c1ac77156d8") },
                    { new Guid("62ddd241-10e2-4bb4-9fb0-4354df19c254"), false, "D", 4, "Kalıtım - Soru 2 için Seçenek D", new Guid("1172d678-348d-46c4-b83d-7c0309ce818a") },
                    { new Guid("63e5fd89-6190-417d-97e5-fef2be828052"), false, "B", 2, "Kimya Bilimi - Soru 1 için Seçenek B", new Guid("6dbfafa1-9246-425f-a9a9-a8fb675373db") },
                    { new Guid("6413960a-a95a-451a-baf8-7eb12cd6d1c4"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek C", new Guid("37d6f10e-c035-4779-98d4-38e99e2650a0") },
                    { new Guid("643b1dc4-83e7-4868-8de2-29d6a60172c5"), true, "A", 1, "Hücre - Soru 4 için Seçenek A", new Guid("3901fd77-e668-458a-bb9c-d5126c131bf9") },
                    { new Guid("6493d679-de6b-45bf-a6bf-3bfacd0afa9b"), false, "B", 2, "Hücre Bölünmeleri - Soru 5 için Seçenek B", new Guid("e4e028a6-beba-48b9-b82e-94f7d01486cf") },
                    { new Guid("65355539-8365-47ed-8e9d-69cdf6ce4fc8"), false, "A", 1, "Kimya Bilimi - Soru 1 için Seçenek A", new Guid("6dbfafa1-9246-425f-a9a9-a8fb675373db") },
                    { new Guid("65805514-b536-4ceb-95b3-f18695a194da"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 4 için Seçenek C", new Guid("da360ff9-8b66-48d4-86b0-85b4a375ce6d") },
                    { new Guid("6585f2fa-3aab-4a31-8574-0e1336932f87"), false, "B", 2, "Rasyonel Sayılar - Soru 1 için Seçenek B", new Guid("58218d2a-cf24-4f59-a3f2-044be6e62a4e") },
                    { new Guid("65987fa6-61eb-42b7-bd8f-d29147317cda"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 4 için Seçenek C", new Guid("6fd242ee-7d79-4d17-aa10-cdc75b053644") },
                    { new Guid("661cf8c0-a7cd-401c-88b8-ac02c25dcbab"), true, "B", 2, "Kalıtım - Soru 5 için Seçenek B", new Guid("40abdf7a-4c60-4aea-80c1-4fb0bcea6545") },
                    { new Guid("66386756-9064-44e3-85c7-5992698cc899"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 3 için Seçenek C", new Guid("15d2a829-ce0d-4053-9110-acc0fefec4ce") },
                    { new Guid("6a81434e-23f9-4032-ad5e-b64fd3011f70"), false, "B", 2, "Problemler - Soru 3 için Seçenek B", new Guid("76304573-b455-48c1-bda2-21632ba096fe") },
                    { new Guid("6ad85ef4-56c1-42b0-b010-8c4a02f0ae9b"), false, "B", 2, "Sayı Basamakları - Soru 2 için Seçenek B", new Guid("ed7977f0-75c1-4ee0-a035-bb6875818830") },
                    { new Guid("6d9d5322-eb06-4ce2-a999-5e4595dcf3e8"), false, "A", 1, "Sayı Basamakları - Soru 4 için Seçenek A", new Guid("03bfa8a7-93c9-4cbe-b9e9-0c1ac77156d8") },
                    { new Guid("6dc42372-fae0-4f1a-8600-68f6155945fb"), false, "C", 3, "Elektrostatik - Soru 2 için Seçenek C", new Guid("baa8e93f-3bea-47cc-9027-a6091693ccfe") },
                    { new Guid("6ef7a2e8-2e21-42fe-be5c-c93f17466c81"), true, "D", 4, "Temel Kavramlar - Soru 4 için Seçenek D", new Guid("4fb4073c-ca6b-4a72-bdb5-1f79777701dd") },
                    { new Guid("7176e7eb-6356-485c-a948-8265eab8218a"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 3 için Seçenek A", new Guid("ce9701a4-91da-4eff-b9c7-fd5f94903df0") },
                    { new Guid("722607a7-f3e1-45bd-bc70-07849cd1e7e9"), false, "B", 2, "Elektrostatik - Soru 1 için Seçenek B", new Guid("d91a3c6a-43be-4ed7-b96d-53f248c64ca3") },
                    { new Guid("727af4cd-4d86-46da-b0b1-3d0ddf144605"), false, "D", 4, "Rasyonel Sayılar - Soru 3 için Seçenek D", new Guid("ca022ff0-2082-4994-ac28-c6fb111d024e") },
                    { new Guid("72b83a8c-c50c-440f-b4e9-cad09e68dfed"), false, "A", 1, "Kuvvet ve Hareket - Soru 3 için Seçenek A", new Guid("5b658537-f30f-4e2c-890d-3c5c17514784") },
                    { new Guid("7340934c-4643-4fc2-bc8b-d2d0bc9bc653"), false, "B", 2, "İş, Güç ve Enerji - Soru 4 için Seçenek B", new Guid("16e97036-90b0-4531-aa79-1356e62d7e0d") },
                    { new Guid("73aa53b9-d1dd-40a5-b9c4-ecca0531fc60"), true, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek C", new Guid("f51ee193-8a7d-48cd-ab48-fe72bcd7f605") },
                    { new Guid("73e82fef-6963-4a55-bf35-e923271b86a1"), true, "A", 1, "Kalıtım - Soru 2 için Seçenek A", new Guid("1172d678-348d-46c4-b83d-7c0309ce818a") },
                    { new Guid("745399b8-c371-4219-9143-87704612b0e1"), true, "A", 1, "Hücre Bölünmeleri - Soru 2 için Seçenek A", new Guid("616002e8-a5c3-43e6-a934-e9341ef37268") },
                    { new Guid("74b0b795-99e6-4f38-bf1c-4b459321ab42"), false, "A", 1, "Madde ve Özellikleri - Soru 2 için Seçenek A", new Guid("d53db1cd-4638-4559-b2b5-e547dec881ad") },
                    { new Guid("74beb94f-9ed7-4ace-84ae-5cc373038c02"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek D", new Guid("6d6137f0-d451-4382-a466-e29f7007980d") },
                    { new Guid("74c43ef9-0469-4238-8479-543423beeca9"), false, "C", 3, "Hücre Bölünmeleri - Soru 1 için Seçenek C", new Guid("2ce01653-bb0e-4dff-b914-b326422645bd") },
                    { new Guid("75510888-7429-4b3c-8692-b62bc4cfe730"), false, "D", 4, "Problemler - Soru 5 için Seçenek D", new Guid("b1f52cc3-78a9-4132-a420-0f6ca34a7c18") },
                    { new Guid("7564a443-5a7c-416f-9892-5245b7b1e47d"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek B", new Guid("37d6f10e-c035-4779-98d4-38e99e2650a0") },
                    { new Guid("75d349a3-25b5-4771-98db-1e37a5dff543"), false, "B", 2, "Madde ve Özellikleri - Soru 1 için Seçenek B", new Guid("dbce2b19-465b-40c3-ada1-3c0c4ba53c56") },
                    { new Guid("75dc75a5-0a8c-426c-b63c-105589d6c5f2"), true, "B", 2, "Problemler - Soru 2 için Seçenek B", new Guid("a0f91289-e705-4772-b298-a5f81ebe5ad5") },
                    { new Guid("76128c03-498f-4bed-a133-1f4ed9d02aec"), false, "B", 2, "Hücre Bölünmeleri - Soru 2 için Seçenek B", new Guid("616002e8-a5c3-43e6-a934-e9341ef37268") },
                    { new Guid("7620f5e0-421a-48de-8ad5-b8ca21885ae2"), false, "A", 1, "Rasyonel Sayılar - Soru 4 için Seçenek A", new Guid("6fafb9e7-75ca-463a-ad30-72356e12fd43") },
                    { new Guid("76c7ccac-6d0c-4dfc-beaa-50403efb480e"), false, "A", 1, "Fizik Bilimine Giriş - Soru 5 için Seçenek A", new Guid("d6f82f30-79ab-4c4b-bc39-4041420e0ee5") },
                    { new Guid("76eefee5-6ce8-4b14-aa1d-bb3bba056f88"), true, "B", 2, "Kuvvet ve Hareket - Soru 4 için Seçenek B", new Guid("2f3ffe58-76a0-4606-9556-8f33eb206256") },
                    { new Guid("782a8c8e-5bb8-43b3-bc79-74c00fe20fd0"), false, "C", 3, "Kalıtım - Soru 2 için Seçenek C", new Guid("1172d678-348d-46c4-b83d-7c0309ce818a") },
                    { new Guid("786ae9d1-b244-4642-9e64-b7cc29c371eb"), false, "C", 3, "Hücre - Soru 3 için Seçenek C", new Guid("a23e372a-03b9-40bd-922b-c8c678651ce9") },
                    { new Guid("7938835b-0067-48b9-b2f5-1f2c49023d34"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek C", new Guid("53077c0e-1884-4d6a-a128-d8ee9b410822") },
                    { new Guid("7a362e88-94e3-4cd2-bb54-51677b40d967"), false, "C", 3, "Kuvvet ve Hareket - Soru 2 için Seçenek C", new Guid("9a39674d-58ac-4e51-b97b-4b1ada660c52") },
                    { new Guid("7a85aec5-f296-4507-a962-340832f886dc"), false, "C", 3, "Rasyonel Sayılar - Soru 5 için Seçenek C", new Guid("687d5a60-e0a7-4837-9ca5-23dc1e923069") },
                    { new Guid("7ac4dc66-a8a5-424b-8b05-5272a9fc7cdf"), false, "B", 2, "Maddenin Halleri - Soru 2 için Seçenek B", new Guid("dc653c71-734f-4075-986b-aad18545a81d") },
                    { new Guid("7c1534ee-06c3-4fd9-bd08-e24fd7923d02"), false, "C", 3, "Sayı Basamakları - Soru 5 için Seçenek C", new Guid("35cba56a-9c1f-4c1b-8f9a-fea395e1ff99") },
                    { new Guid("7d98b298-42ef-4db7-b859-8ec99fcbb801"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek C", new Guid("e1ded32b-f943-48a4-82e5-5706d8cbd01a") },
                    { new Guid("7dda6942-6508-4ad7-8315-dd612899dc32"), false, "B", 2, "Kalıtım - Soru 3 için Seçenek B", new Guid("3b68d56e-0a7a-455c-a2b4-c46d7da1ad17") },
                    { new Guid("7e258c20-7cc4-4d81-9190-51c5b5ea2e26"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek C", new Guid("dbbca985-9be3-4ff1-bee8-9ea34f5c6314") },
                    { new Guid("7f16d3e6-bda7-4ab1-ab77-29efa614d002"), true, "C", 3, "Temel Kavramlar - Soru 2 için Seçenek C", new Guid("e22d4674-8953-4e4a-9b8e-4892d9b9006e") },
                    { new Guid("7f3fe603-c7aa-4d75-b2fe-e87524822603"), false, "C", 3, "Maddenin Halleri - Soru 4 için Seçenek C", new Guid("3e0b2125-1137-4fae-a56d-7a73b625535d") },
                    { new Guid("7f75fa62-c299-4e13-b8e0-5a6dcff270c4"), false, "C", 3, "Problemler - Soru 5 için Seçenek C", new Guid("b1f52cc3-78a9-4132-a420-0f6ca34a7c18") },
                    { new Guid("7f7cca3f-b5d4-4a78-8c53-e57fde5831fa"), true, "B", 2, "Hücre - Soru 3 için Seçenek B", new Guid("a23e372a-03b9-40bd-922b-c8c678651ce9") },
                    { new Guid("7fd4d0bc-7125-464e-b1e1-1aac5a6c5029"), true, "A", 1, "Elektrostatik - Soru 1 için Seçenek A", new Guid("d91a3c6a-43be-4ed7-b96d-53f248c64ca3") },
                    { new Guid("802533a6-37b0-49b6-aef6-b7b8dc666ac7"), false, "C", 3, "Temel Kavramlar - Soru 1 için Seçenek C", new Guid("f7548d51-822a-445a-8d1b-679e7dff2519") },
                    { new Guid("80401a3d-f3f3-4718-8fbc-e885adf4bf84"), false, "D", 4, "Kuvvet ve Hareket - Soru 2 için Seçenek D", new Guid("9a39674d-58ac-4e51-b97b-4b1ada660c52") },
                    { new Guid("81ac8a3e-7f59-4d2f-9561-ed2805b1fed5"), false, "C", 3, "Kalıtım - Soru 5 için Seçenek C", new Guid("40abdf7a-4c60-4aea-80c1-4fb0bcea6545") },
                    { new Guid("825389fe-0ea6-4cd0-962e-cec3cf0322a1"), true, "A", 1, "Hücre - Soru 1 için Seçenek A", new Guid("9c1896ef-5d2a-4cd1-8080-b0f63eeb6488") },
                    { new Guid("86204aec-173a-4974-a818-00bd2a2afc46"), true, "C", 3, "Fizik Bilimine Giriş - Soru 1 için Seçenek C", new Guid("97674af0-4afc-4631-932d-012e5ef5ada3") },
                    { new Guid("865fbc71-84b9-40fc-a83f-c5db29e028c4"), true, "A", 1, "Kuvvet ve Hareket - Soru 2 için Seçenek A", new Guid("9a39674d-58ac-4e51-b97b-4b1ada660c52") },
                    { new Guid("889bc7e3-6618-4eae-8098-1c8540f5ec6d"), false, "A", 1, "Temel Kavramlar - Soru 5 için Seçenek A", new Guid("f3da37c6-5f29-4e70-a63f-a8dc3a4f1421") },
                    { new Guid("88b3ab41-2480-4b07-b845-e54a8dc22b2f"), false, "C", 3, "Kuvvet ve Hareket - Soru 1 için Seçenek C", new Guid("e6190ebb-2fef-478f-af44-cfdba14440a5") },
                    { new Guid("8902ed3a-d213-4e90-befe-8a57d2646e65"), true, "B", 2, "Fizik Bilimine Giriş - Soru 3 için Seçenek B", new Guid("a84ea548-c1e3-40e8-9bbd-dbe29d3784a7") },
                    { new Guid("896eaf49-9b35-44b5-b4e0-69d9745e4bc8"), false, "D", 4, "Kalıtım - Soru 5 için Seçenek D", new Guid("40abdf7a-4c60-4aea-80c1-4fb0bcea6545") },
                    { new Guid("8a5b170f-285b-4811-8eb7-ef7a9172a743"), false, "D", 4, "Bölme ve Bölünebilme - Soru 5 için Seçenek D", new Guid("fd1ef666-b343-430a-935c-e90658a3bb44") },
                    { new Guid("8b0c73a6-e7e2-495d-9d4e-731fe550723f"), false, "D", 4, "Madde ve Özellikleri - Soru 3 için Seçenek D", new Guid("9787b9c9-1ae8-48c1-8853-e60327ff2633") },
                    { new Guid("8b33ac9a-349a-479f-822c-d4aa173f0d4c"), false, "B", 2, "İş, Güç ve Enerji - Soru 1 için Seçenek B", new Guid("10edea59-5fde-4ac7-8be2-9fe88f953ebd") },
                    { new Guid("8b7b0cec-b2f0-4772-a8c1-7df4ba78367c"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek A", new Guid("c08f1dee-0678-4fa9-84a8-70efb13c6790") },
                    { new Guid("8d3a258f-ad17-4276-b168-9d07d11d76fc"), true, "C", 3, "Fizik Bilimine Giriş - Soru 5 için Seçenek C", new Guid("d6f82f30-79ab-4c4b-bc39-4041420e0ee5") },
                    { new Guid("8e3472f4-236e-44e0-954a-f240ca9e9386"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 5 için Seçenek C", new Guid("b81ca42d-db92-41e3-a38a-69a072344be7") },
                    { new Guid("8e510b4f-6ef1-4866-a952-6925245a7e28"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek B", new Guid("91dfc8bd-b7e2-4a67-be09-eee17cd91e61") },
                    { new Guid("8f492996-0ea1-4fe1-bb6e-ec1abc24643a"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek D", new Guid("f51ee193-8a7d-48cd-ab48-fe72bcd7f605") },
                    { new Guid("8f8a731f-f8f6-46e0-9dfb-839b0aca6e2d"), false, "C", 3, "İş, Güç ve Enerji - Soru 1 için Seçenek C", new Guid("10edea59-5fde-4ac7-8be2-9fe88f953ebd") },
                    { new Guid("909d8e52-a0ed-4654-bcd9-f12ea8c9a840"), false, "A", 1, "Fizik Bilimine Giriş - Soru 3 için Seçenek A", new Guid("a84ea548-c1e3-40e8-9bbd-dbe29d3784a7") },
                    { new Guid("909e7319-59c1-4e99-bd4b-7d59d8e3ed9d"), false, "B", 2, "Kuvvet ve Hareket - Soru 1 için Seçenek B", new Guid("e6190ebb-2fef-478f-af44-cfdba14440a5") },
                    { new Guid("90a728f3-618c-4014-b0e9-6f4d770f25c2"), false, "A", 1, "Rasyonel Sayılar - Soru 2 için Seçenek A", new Guid("0f427dcb-4184-465a-a576-ba04c797429c") },
                    { new Guid("914b24aa-8652-45ad-9ae4-8e6220fe4711"), false, "B", 2, "Hücre - Soru 1 için Seçenek B", new Guid("9c1896ef-5d2a-4cd1-8080-b0f63eeb6488") },
                    { new Guid("91a72a35-f02d-4d39-96c0-b2f9f14e0ae3"), false, "B", 2, "Hücre - Soru 4 için Seçenek B", new Guid("3901fd77-e668-458a-bb9c-d5126c131bf9") },
                    { new Guid("91e58977-dbc7-46d9-a50b-a81dbebff66f"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 2 için Seçenek B", new Guid("04c7f17a-78a5-42a0-b449-47824a1a2b4f") },
                    { new Guid("927d5cee-48e4-44b0-bb5e-0b4beca8bc41"), true, "C", 3, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek C", new Guid("fcceb9bf-9d39-46fd-81ec-6b7984a422f0") },
                    { new Guid("92b78b9d-ca1b-4315-8a47-d3efcee7cf4d"), false, "B", 2, "Bölme ve Bölünebilme - Soru 3 için Seçenek B", new Guid("9dcf362b-cba4-4b9c-873e-d3bb1276d008") },
                    { new Guid("9310be19-76ea-4712-be9a-8b148b094030"), false, "A", 1, "Problemler - Soru 4 için Seçenek A", new Guid("77419c6a-2c89-45ae-b5c8-44cee62a8cb1") },
                    { new Guid("9394d797-099f-478b-b11b-80e46ebc7392"), false, "A", 1, "Maddenin Halleri - Soru 3 için Seçenek A", new Guid("cdcadaa8-d89e-4885-a3e8-cadfcf15483c") },
                    { new Guid("941d9002-b6f7-49f1-a231-c3888e318ab7"), false, "D", 4, "Hücre Bölünmeleri - Soru 4 için Seçenek D", new Guid("8b42e08e-0b8d-4abb-adde-6f46fd3e9d8a") },
                    { new Guid("94626fa2-086b-486f-82cf-35e47dbbaba1"), false, "A", 1, "Hücre Bölünmeleri - Soru 5 için Seçenek A", new Guid("e4e028a6-beba-48b9-b82e-94f7d01486cf") },
                    { new Guid("947bc34f-f708-4689-a7ed-12992dab382e"), false, "A", 1, "Rasyonel Sayılar - Soru 3 için Seçenek A", new Guid("ca022ff0-2082-4994-ac28-c6fb111d024e") },
                    { new Guid("94d85442-fd8d-4abe-9137-33a52e2c91ca"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek D", new Guid("c08f1dee-0678-4fa9-84a8-70efb13c6790") },
                    { new Guid("95a7a203-8f65-4a34-a52e-255e5ee3c090"), false, "C", 3, "Sayı Basamakları - Soru 3 için Seçenek C", new Guid("b7fddbc4-d0d9-4d11-b179-d54a3b8d5c29") },
                    { new Guid("96ce4b1f-6c9c-4651-9360-46ac70d770ad"), false, "D", 4, "Hücre - Soru 5 için Seçenek D", new Guid("0604f96e-8559-4a9f-bd2e-0b1841b8e57c") },
                    { new Guid("96ff715b-3edf-44ab-ba99-78451ea25aec"), false, "A", 1, "Elektrostatik - Soru 3 için Seçenek A", new Guid("18c0168d-72d4-48dd-995b-7419519d213a") },
                    { new Guid("971a6d71-0e0a-4dbe-9e32-bbf5cc246e61"), false, "A", 1, "Kimya Bilimi - Soru 3 için Seçenek A", new Guid("a67002b0-f652-40c3-a097-1e61847592a8") },
                    { new Guid("9797e7d8-564b-4745-8eba-5fb934465cd4"), false, "D", 4, "Maddenin Halleri - Soru 5 için Seçenek D", new Guid("78bbc65e-a615-4705-a4ea-1b9dc552a82d") },
                    { new Guid("97ba51ab-614d-45a0-93bf-ae0940c92456"), false, "A", 1, "Elektrostatik - Soru 5 için Seçenek A", new Guid("2e1a6023-dd55-4731-bb12-036c52c2239f") },
                    { new Guid("983aa280-eee3-4bd6-a5a7-1104ba3b0989"), false, "B", 2, "Hücre Bölünmeleri - Soru 3 için Seçenek B", new Guid("b276f802-fc02-4795-adb1-25e51edbe0bb") },
                    { new Guid("986833d9-12f7-4f3c-9501-f3b56a25be81"), false, "C", 3, "Kuvvet ve Hareket - Soru 5 için Seçenek C", new Guid("7e62a768-fb2c-4cd9-8d8b-2e107a5bedbf") },
                    { new Guid("98efb2b7-8e99-4249-a2dd-77e389da3625"), false, "A", 1, "Bölme ve Bölünebilme - Soru 3 için Seçenek A", new Guid("9dcf362b-cba4-4b9c-873e-d3bb1276d008") },
                    { new Guid("9963e826-d4f9-43d3-a130-85731df31a55"), false, "C", 3, "Hücre - Soru 2 için Seçenek C", new Guid("556ceb04-7c37-4ee1-8b45-0c2388393495") },
                    { new Guid("998b1bf5-41d3-4768-b6a3-2c8dfb9407c2"), false, "D", 4, "Kimya Bilimi - Soru 1 için Seçenek D", new Guid("6dbfafa1-9246-425f-a9a9-a8fb675373db") },
                    { new Guid("9ab7bd62-5357-4e8f-9d03-511d14ac907e"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 2 için Seçenek C", new Guid("04c7f17a-78a5-42a0-b449-47824a1a2b4f") },
                    { new Guid("9b87d716-fd19-44a6-a307-77d9bebd2af7"), false, "A", 1, "İş, Güç ve Enerji - Soru 1 için Seçenek A", new Guid("10edea59-5fde-4ac7-8be2-9fe88f953ebd") },
                    { new Guid("9c2c38eb-d1ef-44f9-93ae-f8de5254f80d"), false, "D", 4, "İş, Güç ve Enerji - Soru 4 için Seçenek D", new Guid("16e97036-90b0-4531-aa79-1356e62d7e0d") },
                    { new Guid("9c9973be-55c3-4348-aa30-1ebdc60aa50e"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek C", new Guid("f46a9bd5-6b08-4818-ad5f-df1deb0b326b") },
                    { new Guid("9d34d764-5df9-4916-a734-282f8786ca34"), true, "C", 3, "Problemler - Soru 1 için Seçenek C", new Guid("d65a8559-407e-4ad0-9440-86a0b977462e") },
                    { new Guid("a1bdcafc-6644-4acd-a33c-d00c05699bbe"), true, "A", 1, "Kalıtım - Soru 1 için Seçenek A", new Guid("ab8f27c6-350d-484c-9a9e-f0ffdc9862bc") },
                    { new Guid("a34024ac-2d4a-43e0-a211-d53aa5e7db43"), false, "D", 4, "Kuvvet ve Hareket - Soru 4 için Seçenek D", new Guid("2f3ffe58-76a0-4606-9556-8f33eb206256") },
                    { new Guid("a3b4550c-2443-4526-9922-99a6a1a131ce"), false, "A", 1, "Kuvvet ve Hareket - Soru 4 için Seçenek A", new Guid("2f3ffe58-76a0-4606-9556-8f33eb206256") },
                    { new Guid("a3f1e3dc-0a93-4dc5-ac0a-988b98e5ad34"), false, "C", 3, "Hücre - Soru 5 için Seçenek C", new Guid("0604f96e-8559-4a9f-bd2e-0b1841b8e57c") },
                    { new Guid("a43da96e-12bc-458e-b03d-b8ea8d6234a2"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 2 için Seçenek B", new Guid("822514d4-6b32-453e-ab6f-51519f540fda") },
                    { new Guid("a6441b08-2dc0-4d1a-8d7e-648cd706defe"), false, "A", 1, "Temel Kavramlar - Soru 4 için Seçenek A", new Guid("4fb4073c-ca6b-4a72-bdb5-1f79777701dd") },
                    { new Guid("a7573164-c829-4b88-a0fc-1fdc5e16b9d5"), false, "D", 4, "Hücre - Soru 3 için Seçenek D", new Guid("a23e372a-03b9-40bd-922b-c8c678651ce9") },
                    { new Guid("a7c982f6-c13a-4763-86a2-4c9fe61b235d"), false, "C", 3, "Fizik Bilimine Giriş - Soru 3 için Seçenek C", new Guid("a84ea548-c1e3-40e8-9bbd-dbe29d3784a7") },
                    { new Guid("aa23cd4a-b90a-4b3e-87cd-e287276555a7"), false, "D", 4, "Problemler - Soru 1 için Seçenek D", new Guid("d65a8559-407e-4ad0-9440-86a0b977462e") },
                    { new Guid("aaab017d-bec5-4289-aab5-5df95d5f0129"), false, "B", 2, "Temel Kavramlar - Soru 4 için Seçenek B", new Guid("4fb4073c-ca6b-4a72-bdb5-1f79777701dd") },
                    { new Guid("aac2051f-9c56-43aa-905c-190b87089785"), false, "B", 2, "Fizik Bilimine Giriş - Soru 4 için Seçenek B", new Guid("eed7f50e-be17-4fa6-9183-65697522351f") },
                    { new Guid("acffef08-69b4-4c9d-93d5-06776a07353b"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek A", new Guid("f46a9bd5-6b08-4818-ad5f-df1deb0b326b") },
                    { new Guid("af58cd09-222e-45fb-ba05-8dfeb38b50e5"), true, "D", 4, "Maddenin Halleri - Soru 3 için Seçenek D", new Guid("cdcadaa8-d89e-4885-a3e8-cadfcf15483c") },
                    { new Guid("af973338-f8d0-493c-b2b4-2fe59b8e0ee4"), true, "B", 2, "Rasyonel Sayılar - Soru 2 için Seçenek B", new Guid("0f427dcb-4184-465a-a576-ba04c797429c") },
                    { new Guid("afa7cab6-0acd-41fe-9df3-f646d4e7a502"), false, "C", 3, "Hücre - Soru 4 için Seçenek C", new Guid("3901fd77-e668-458a-bb9c-d5126c131bf9") },
                    { new Guid("b11e4fcc-30ae-457d-90bd-62b8d7523410"), true, "A", 1, "Elektrostatik - Soru 4 için Seçenek A", new Guid("59b9584b-3741-4357-9321-0828919951ff") },
                    { new Guid("b1427122-a925-42ef-9d5f-9bf369daa49d"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek D", new Guid("fcceb9bf-9d39-46fd-81ec-6b7984a422f0") },
                    { new Guid("b14ce534-42fa-4346-9282-b7e090c54d01"), false, "C", 3, "Maddenin Halleri - Soru 2 için Seçenek C", new Guid("dc653c71-734f-4075-986b-aad18545a81d") },
                    { new Guid("b43bd7fa-a6b5-4e8d-82af-8b1490a0167d"), false, "B", 2, "Bölme ve Bölünebilme - Soru 5 için Seçenek B", new Guid("fd1ef666-b343-430a-935c-e90658a3bb44") },
                    { new Guid("b45fc6fe-7e52-48c3-bb04-49b0fb587dc6"), true, "B", 2, "Sayı Basamakları - Soru 5 için Seçenek B", new Guid("35cba56a-9c1f-4c1b-8f9a-fea395e1ff99") },
                    { new Guid("b4f1f99e-8c7f-4fd6-b977-43e54d2c26bd"), false, "A", 1, "Fizik Bilimine Giriş - Soru 1 için Seçenek A", new Guid("97674af0-4afc-4631-932d-012e5ef5ada3") },
                    { new Guid("b5b5ea98-bfaf-4ec4-be2d-64d43c22d3ca"), false, "D", 4, "İş, Güç ve Enerji - Soru 5 için Seçenek D", new Guid("6b988903-14c1-4408-b681-6b35c5435309") },
                    { new Guid("b5e6258a-a2ce-489c-a274-21b1c3b6deba"), false, "B", 2, "Bölme ve Bölünebilme - Soru 2 için Seçenek B", new Guid("a4292e06-0cb7-4b22-9b81-69a37cc7f538") },
                    { new Guid("b673d705-f6a1-41f9-9936-8e3851be0994"), false, "B", 2, "Kalıtım - Soru 1 için Seçenek B", new Guid("ab8f27c6-350d-484c-9a9e-f0ffdc9862bc") },
                    { new Guid("b6e6f1fc-33e7-4b2d-8327-06089c0e356c"), false, "B", 2, "İş, Güç ve Enerji - Soru 5 için Seçenek B", new Guid("6b988903-14c1-4408-b681-6b35c5435309") },
                    { new Guid("b73418ae-39c3-44e5-9416-89edce19acb8"), true, "D", 4, "Sayı Basamakları - Soru 3 için Seçenek D", new Guid("b7fddbc4-d0d9-4d11-b179-d54a3b8d5c29") },
                    { new Guid("b7622491-7d73-4fd8-b39d-4286725083e7"), false, "C", 3, "Elektrostatik - Soru 3 için Seçenek C", new Guid("18c0168d-72d4-48dd-995b-7419519d213a") },
                    { new Guid("b76a73c9-f59b-487d-b635-533800ea65cb"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 4 için Seçenek D", new Guid("6fd242ee-7d79-4d17-aa10-cdc75b053644") },
                    { new Guid("b86d6a92-a9fd-46f0-b6c0-c1b5e07d7266"), false, "B", 2, "Madde ve Özellikleri - Soru 5 için Seçenek B", new Guid("62b69aaf-f178-4d91-bf9a-4a71e78d6963") },
                    { new Guid("b8be9332-729b-4d61-92ff-1ffe41b5f942"), false, "A", 1, "İş, Güç ve Enerji - Soru 5 için Seçenek A", new Guid("6b988903-14c1-4408-b681-6b35c5435309") },
                    { new Guid("bac6e75c-c260-4497-9972-12cb0deb17fa"), true, "C", 3, "Sayı Basamakları - Soru 1 için Seçenek C", new Guid("805fe97e-0c5e-4d42-b6c9-1651f81a0975") },
                    { new Guid("bb51f334-1304-445d-afd6-a4a0b699af24"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 2 için Seçenek D", new Guid("822514d4-6b32-453e-ab6f-51519f540fda") },
                    { new Guid("bc071147-1674-4cc3-bbdf-8ccac7b93331"), false, "C", 3, "Hücre Bölünmeleri - Soru 5 için Seçenek C", new Guid("e4e028a6-beba-48b9-b82e-94f7d01486cf") },
                    { new Guid("bc661131-0707-465f-ac4d-7f4c17f8e51e"), false, "C", 3, "Sayı Basamakları - Soru 2 için Seçenek C", new Guid("ed7977f0-75c1-4ee0-a035-bb6875818830") },
                    { new Guid("bcd6a18d-3801-48a0-85c0-6d08f173613a"), false, "D", 4, "Kuvvet ve Hareket - Soru 3 için Seçenek D", new Guid("5b658537-f30f-4e2c-890d-3c5c17514784") },
                    { new Guid("bd5db126-8cfb-4cd9-a77c-159582f524dd"), false, "C", 3, "İş, Güç ve Enerji - Soru 2 için Seçenek C", new Guid("4613e5e0-97dc-4a0c-a755-05a65b74376b") },
                    { new Guid("be32d65b-24e0-4692-a93b-d89669dd4470"), false, "B", 2, "Sayı Basamakları - Soru 3 için Seçenek B", new Guid("b7fddbc4-d0d9-4d11-b179-d54a3b8d5c29") },
                    { new Guid("be3a2a6f-15d5-4046-850e-c6f61f3303c5"), false, "B", 2, "Kimya Bilimi - Soru 3 için Seçenek B", new Guid("a67002b0-f652-40c3-a097-1e61847592a8") },
                    { new Guid("beb60032-f057-43b0-a3b5-1473b995640a"), true, "B", 2, "Madde ve Özellikleri - Soru 2 için Seçenek B", new Guid("d53db1cd-4638-4559-b2b5-e547dec881ad") },
                    { new Guid("befcd18e-0798-4485-aa33-77e2339c0f55"), true, "C", 3, "Bölme ve Bölünebilme - Soru 5 için Seçenek C", new Guid("fd1ef666-b343-430a-935c-e90658a3bb44") },
                    { new Guid("bfcd9746-1686-49dd-b6c4-32101211e6fb"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 4 için Seçenek A", new Guid("da360ff9-8b66-48d4-86b0-85b4a375ce6d") },
                    { new Guid("c077bf7d-2bb5-4bb7-97d7-5fc207e09fc6"), false, "B", 2, "Maddenin Halleri - Soru 4 için Seçenek B", new Guid("3e0b2125-1137-4fae-a56d-7a73b625535d") },
                    { new Guid("c080096b-188e-4c3e-b468-9830afc4021d"), true, "B", 2, "Hücre Bölünmeleri - Soru 4 için Seçenek B", new Guid("8b42e08e-0b8d-4abb-adde-6f46fd3e9d8a") },
                    { new Guid("c0a8a090-b6f2-4552-bebd-ed778834d677"), false, "C", 3, "Sayı Basamakları - Soru 4 için Seçenek C", new Guid("03bfa8a7-93c9-4cbe-b9e9-0c1ac77156d8") },
                    { new Guid("c2a17d1d-4d5c-4adc-b39a-a9538c6f7bc1"), false, "D", 4, "Sayı Basamakları - Soru 5 için Seçenek D", new Guid("35cba56a-9c1f-4c1b-8f9a-fea395e1ff99") },
                    { new Guid("c2b9ea04-568b-4230-af09-3434fe096257"), false, "A", 1, "Rasyonel Sayılar - Soru 1 için Seçenek A", new Guid("58218d2a-cf24-4f59-a3f2-044be6e62a4e") },
                    { new Guid("c47a5dd8-3feb-438a-8a00-a38eef53853d"), false, "D", 4, "Kalıtım - Soru 4 için Seçenek D", new Guid("0ea05b44-952b-4dd1-bc36-299ba9498a1e") },
                    { new Guid("c4b84cea-7b15-4120-b005-31f4c32103f3"), false, "C", 3, "Hücre Bölünmeleri - Soru 4 için Seçenek C", new Guid("8b42e08e-0b8d-4abb-adde-6f46fd3e9d8a") },
                    { new Guid("c4bf2ce6-943b-43a0-a46b-ca9f84ff2b42"), false, "A", 1, "Temel Kavramlar - Soru 3 için Seçenek A", new Guid("396eba31-d145-4f20-8b4e-fbab042041af") },
                    { new Guid("c4d59330-873d-43e3-92e6-c94aad0ef142"), false, "B", 2, "Problemler - Soru 1 için Seçenek B", new Guid("d65a8559-407e-4ad0-9440-86a0b977462e") },
                    { new Guid("c4d8c98d-3b9f-4bc0-a140-e57ea86a05f7"), false, "B", 2, "Sayı Basamakları - Soru 1 için Seçenek B", new Guid("805fe97e-0c5e-4d42-b6c9-1651f81a0975") },
                    { new Guid("c4ff537b-ee0c-439d-b0ed-36b2a708e52f"), false, "B", 2, "Rasyonel Sayılar - Soru 5 için Seçenek B", new Guid("687d5a60-e0a7-4837-9ca5-23dc1e923069") },
                    { new Guid("c53437c5-8bc4-4885-880e-bea57b4f6467"), true, "C", 3, "Rasyonel Sayılar - Soru 3 için Seçenek C", new Guid("ca022ff0-2082-4994-ac28-c6fb111d024e") },
                    { new Guid("c5357174-229d-4cdb-b199-5185ab4dd18e"), false, "C", 3, "Hücre Bölünmeleri - Soru 2 için Seçenek C", new Guid("616002e8-a5c3-43e6-a934-e9341ef37268") },
                    { new Guid("c63ab91b-2333-4651-8a7a-470cf2448ee1"), false, "D", 4, "Madde ve Özellikleri - Soru 5 için Seçenek D", new Guid("62b69aaf-f178-4d91-bf9a-4a71e78d6963") },
                    { new Guid("c67ab8e2-461a-43f0-85ce-4af9859bab0d"), true, "A", 1, "Madde ve Özellikleri - Soru 5 için Seçenek A", new Guid("62b69aaf-f178-4d91-bf9a-4a71e78d6963") },
                    { new Guid("c6eb678d-378d-4143-a867-f8651e7fd7b1"), false, "D", 4, "Bölme ve Bölünebilme - Soru 4 için Seçenek D", new Guid("e08dff57-8a65-48bd-95b7-435e8e8ec667") },
                    { new Guid("c77c00b5-af5e-4237-b74b-815e5cdf1832"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 1 için Seçenek A", new Guid("aee10aee-00c3-424f-b8ea-ecf661170258") },
                    { new Guid("c7862283-194c-4456-b3aa-cdfa7e34cfa3"), true, "B", 2, "Elektrostatik - Soru 5 için Seçenek B", new Guid("2e1a6023-dd55-4731-bb12-036c52c2239f") },
                    { new Guid("c7daaac8-3a14-4c05-826a-b12eabb99f50"), false, "D", 4, "Maddenin Halleri - Soru 1 için Seçenek D", new Guid("78d4ea3b-9af6-40b1-8b70-0c8699b60e5d") },
                    { new Guid("c8df7413-dbfb-42df-9f13-3826263ab039"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek C", new Guid("c08f1dee-0678-4fa9-84a8-70efb13c6790") },
                    { new Guid("c9731213-b33f-4a56-a240-e6290a8fd1b3"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek D", new Guid("37d6f10e-c035-4779-98d4-38e99e2650a0") },
                    { new Guid("c97f8847-e1f8-4bc7-93cb-9afa87684f06"), false, "B", 2, "Kalıtım - Soru 4 için Seçenek B", new Guid("0ea05b44-952b-4dd1-bc36-299ba9498a1e") },
                    { new Guid("ca46d16c-58d5-45a2-8438-84524be0c416"), true, "D", 4, "Fizik Bilimine Giriş - Soru 4 için Seçenek D", new Guid("eed7f50e-be17-4fa6-9183-65697522351f") },
                    { new Guid("cac2dacc-de50-4650-b19f-60d86186f9e0"), false, "C", 3, "Elektrostatik - Soru 5 için Seçenek C", new Guid("2e1a6023-dd55-4731-bb12-036c52c2239f") },
                    { new Guid("cbcd3a15-4ede-4be1-80ea-6a4e8efd3970"), false, "B", 2, "Kalıtım - Soru 2 için Seçenek B", new Guid("1172d678-348d-46c4-b83d-7c0309ce818a") },
                    { new Guid("cc198312-2a8d-478b-96fb-028eead03741"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek C", new Guid("91dfc8bd-b7e2-4a67-be09-eee17cd91e61") },
                    { new Guid("cc4501f1-e80b-4d40-a334-cc0b1dba5584"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek A", new Guid("f3e06e73-a04b-4b47-a255-ec2608778018") },
                    { new Guid("cd7613b3-8d6f-4353-af9f-6e9e9043cba8"), false, "C", 3, "Temel Kavramlar - Soru 5 için Seçenek C", new Guid("f3da37c6-5f29-4e70-a63f-a8dc3a4f1421") },
                    { new Guid("cd90f25b-c31b-449a-9b8a-642da14c8a17"), false, "B", 2, "Fizik Bilimine Giriş - Soru 1 için Seçenek B", new Guid("97674af0-4afc-4631-932d-012e5ef5ada3") },
                    { new Guid("cdbcfecc-623f-407b-9ac8-07d40dfef215"), true, "D", 4, "Temel Kavramlar - Soru 1 için Seçenek D", new Guid("f7548d51-822a-445a-8d1b-679e7dff2519") },
                    { new Guid("cdcbcde8-c329-4b7b-8d0c-1a80c2fd353e"), false, "D", 4, "Rasyonel Sayılar - Soru 2 için Seçenek D", new Guid("0f427dcb-4184-465a-a576-ba04c797429c") },
                    { new Guid("ce1deb88-dc78-46ca-a22c-d94694d50470"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek B", new Guid("83cea481-cf9d-4001-98f8-c2fe416bbce7") },
                    { new Guid("d0222d05-61d3-4fd9-af43-31e5633ac64d"), false, "D", 4, "Elektrostatik - Soru 4 için Seçenek D", new Guid("59b9584b-3741-4357-9321-0828919951ff") },
                    { new Guid("d0d16bd0-3a21-4e7f-b4e1-dd2afdc58383"), false, "C", 3, "Kimya Bilimi - Soru 4 için Seçenek C", new Guid("577aee49-fde5-483b-81d8-d433c3ed578f") },
                    { new Guid("d1422bd6-9428-4f6a-8a45-3ee6fdad4659"), false, "A", 1, "Problemler - Soru 2 için Seçenek A", new Guid("a0f91289-e705-4772-b298-a5f81ebe5ad5") },
                    { new Guid("d1f8be5d-adc6-4cef-9ce4-93b283e00f70"), true, "A", 1, "Kimya Bilimi - Soru 2 için Seçenek A", new Guid("d1b2184c-dc3c-4a5f-abc6-b3ee58d54a5a") },
                    { new Guid("d33d4285-ff98-4940-80ef-d9c237e5aeb1"), false, "A", 1, "İş, Güç ve Enerji - Soru 4 için Seçenek A", new Guid("16e97036-90b0-4531-aa79-1356e62d7e0d") },
                    { new Guid("d350660e-b89c-4ef7-9d49-c8441bba425e"), false, "A", 1, "Problemler - Soru 1 için Seçenek A", new Guid("d65a8559-407e-4ad0-9440-86a0b977462e") },
                    { new Guid("d3577ebc-1b07-4c8b-963f-819586592392"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 3 için Seçenek D", new Guid("ce9701a4-91da-4eff-b9c7-fd5f94903df0") },
                    { new Guid("d35cf7a7-2842-4050-9224-26b613f7f22c"), false, "B", 2, "Problemler - Soru 5 için Seçenek B", new Guid("b1f52cc3-78a9-4132-a420-0f6ca34a7c18") },
                    { new Guid("d3f6ac85-08cd-4c95-a5de-b5e43cfb6a28"), false, "D", 4, "Hücre - Soru 1 için Seçenek D", new Guid("9c1896ef-5d2a-4cd1-8080-b0f63eeb6488") },
                    { new Guid("d472f76a-8d0c-4622-b2c2-b60ddf136c65"), false, "A", 1, "Fizik Bilimine Giriş - Soru 4 için Seçenek A", new Guid("eed7f50e-be17-4fa6-9183-65697522351f") },
                    { new Guid("d54f9fb8-d48b-43b6-96d9-ea7a6d4d3b6b"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek B", new Guid("4d6df717-fbc0-4950-8104-c7f552977e77") },
                    { new Guid("d5e0cd39-08c5-4323-9c47-757d56e5b306"), true, "D", 4, "Elektrostatik - Soru 3 için Seçenek D", new Guid("18c0168d-72d4-48dd-995b-7419519d213a") },
                    { new Guid("d86e1553-7796-4efb-a067-8b0c3d92edfa"), false, "B", 2, "Madde ve Özellikleri - Soru 4 için Seçenek B", new Guid("ffa8b6a4-472c-491a-a802-6c9d4e50da05") },
                    { new Guid("d89102f2-fc15-4df1-a3b6-c98607a77264"), false, "D", 4, "Elektrostatik - Soru 1 için Seçenek D", new Guid("d91a3c6a-43be-4ed7-b96d-53f248c64ca3") },
                    { new Guid("d8ada6e2-cd4f-462a-9bc4-f54bcd56b70c"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek D", new Guid("83cea481-cf9d-4001-98f8-c2fe416bbce7") },
                    { new Guid("d9b5a7aa-4217-4b7f-a9c4-bb5b61587ffc"), true, "A", 1, "Elektrostatik - Soru 2 için Seçenek A", new Guid("baa8e93f-3bea-47cc-9027-a6091693ccfe") },
                    { new Guid("d9f0e4ee-4e92-4612-a4e0-d153b428e30b"), true, "A", 1, "Hücre - Soru 5 için Seçenek A", new Guid("0604f96e-8559-4a9f-bd2e-0b1841b8e57c") },
                    { new Guid("da3d6ba6-e0d4-4635-8455-c02788554655"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 5 için Seçenek D", new Guid("b81ca42d-db92-41e3-a38a-69a072344be7") },
                    { new Guid("daa52a62-5b19-4d09-8459-6606aee192d9"), false, "D", 4, "Fizik Bilimine Giriş - Soru 3 için Seçenek D", new Guid("a84ea548-c1e3-40e8-9bbd-dbe29d3784a7") },
                    { new Guid("dba49616-b634-43ac-881f-363da0ba5f17"), false, "C", 3, "Hücre - Soru 1 için Seçenek C", new Guid("9c1896ef-5d2a-4cd1-8080-b0f63eeb6488") },
                    { new Guid("dc0d6e57-857e-4feb-9982-4208ad26d037"), true, "B", 2, "Bölme ve Bölünebilme - Soru 4 için Seçenek B", new Guid("e08dff57-8a65-48bd-95b7-435e8e8ec667") },
                    { new Guid("dc3963fc-884f-4dd0-9eeb-2cd69752ff27"), false, "B", 2, "Maddenin Halleri - Soru 3 için Seçenek B", new Guid("cdcadaa8-d89e-4885-a3e8-cadfcf15483c") },
                    { new Guid("dc785e2a-3360-4212-8f28-c719c8f855e9"), false, "D", 4, "Kuvvet ve Hareket - Soru 1 için Seçenek D", new Guid("e6190ebb-2fef-478f-af44-cfdba14440a5") },
                    { new Guid("dd7ff8bc-c6c2-4fff-b913-432bf352e431"), false, "D", 4, "Kuvvet ve Hareket - Soru 5 için Seçenek D", new Guid("7e62a768-fb2c-4cd9-8d8b-2e107a5bedbf") },
                    { new Guid("df040a86-8cd8-4cfb-8580-b9cf62c7a525"), false, "C", 3, "Rasyonel Sayılar - Soru 1 için Seçenek C", new Guid("58218d2a-cf24-4f59-a3f2-044be6e62a4e") },
                    { new Guid("df715cf1-42cb-4ab1-a5ad-69a5d55dd13d"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek D", new Guid("e1ded32b-f943-48a4-82e5-5706d8cbd01a") },
                    { new Guid("e07c5675-b474-42aa-9578-26b90d66df2c"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek D", new Guid("f46a9bd5-6b08-4818-ad5f-df1deb0b326b") },
                    { new Guid("e10cd9c6-5307-43e5-a6b6-c6d716d145f1"), false, "B", 2, "Temel Kavramlar - Soru 3 için Seçenek B", new Guid("396eba31-d145-4f20-8b4e-fbab042041af") },
                    { new Guid("e2357feb-4e0e-4969-94fa-e814a8d9b864"), false, "C", 3, "Elektrostatik - Soru 1 için Seçenek C", new Guid("d91a3c6a-43be-4ed7-b96d-53f248c64ca3") },
                    { new Guid("e2f0b777-2fd0-4fd5-a741-f9478a895bec"), true, "A", 1, "Kuvvet ve Hareket - Soru 5 için Seçenek A", new Guid("7e62a768-fb2c-4cd9-8d8b-2e107a5bedbf") },
                    { new Guid("e344a387-a901-4a6c-99f2-c51cc1052481"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek D", new Guid("53077c0e-1884-4d6a-a128-d8ee9b410822") },
                    { new Guid("e4fcb6f2-c9d6-4c80-800f-e4ae9727d44b"), false, "B", 2, "İş, Güç ve Enerji - Soru 3 için Seçenek B", new Guid("1833398a-7439-49a1-9298-1c67ee9965c6") },
                    { new Guid("e6031988-b7b0-461a-8ba5-60b272335c78"), false, "D", 4, "Rasyonel Sayılar - Soru 4 için Seçenek D", new Guid("6fafb9e7-75ca-463a-ad30-72356e12fd43") },
                    { new Guid("e71600ac-f206-49fc-b093-2b7823dec116"), true, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek A", new Guid("dbbca985-9be3-4ff1-bee8-9ea34f5c6314") },
                    { new Guid("e84614ab-a444-43e7-a25b-88365f1f00c3"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 1 için Seçenek C", new Guid("77cc75de-44d5-4a51-beb2-a592b05966be") },
                    { new Guid("e9156efc-5050-471a-9299-c9a534322cb7"), true, "C", 3, "Madde ve Özellikleri - Soru 4 için Seçenek C", new Guid("ffa8b6a4-472c-491a-a802-6c9d4e50da05") },
                    { new Guid("e975b13b-911b-4f63-8038-b0f6429a9d8f"), false, "D", 4, "Hücre Bölünmeleri - Soru 2 için Seçenek D", new Guid("616002e8-a5c3-43e6-a934-e9341ef37268") },
                    { new Guid("ea4525e6-67b4-461b-9dc8-b3353cadc5eb"), false, "C", 3, "İş, Güç ve Enerji - Soru 3 için Seçenek C", new Guid("1833398a-7439-49a1-9298-1c67ee9965c6") },
                    { new Guid("ebadcb9f-00e9-4038-9b7b-b076260eca06"), true, "D", 4, "Problemler - Soru 3 için Seçenek D", new Guid("76304573-b455-48c1-bda2-21632ba096fe") },
                    { new Guid("ec0c8028-5037-41bd-8a0c-3aaa60ecbeab"), false, "B", 2, "Kuvvet ve Hareket - Soru 3 için Seçenek B", new Guid("5b658537-f30f-4e2c-890d-3c5c17514784") },
                    { new Guid("ecbff77f-99c1-404e-b02e-102d65f3fce0"), true, "D", 4, "Rasyonel Sayılar - Soru 1 için Seçenek D", new Guid("58218d2a-cf24-4f59-a3f2-044be6e62a4e") },
                    { new Guid("edd44e12-eda1-48fb-bf59-eb5a0415b639"), true, "A", 1, "Madde ve Özellikleri - Soru 1 için Seçenek A", new Guid("dbce2b19-465b-40c3-ada1-3c0c4ba53c56") },
                    { new Guid("ee702ada-3051-4a99-a5f0-3592f14c9984"), false, "D", 4, "Problemler - Soru 2 için Seçenek D", new Guid("a0f91289-e705-4772-b298-a5f81ebe5ad5") },
                    { new Guid("ef610b68-688f-4f0a-8a2f-1f8f7a53ca56"), true, "C", 3, "Maddenin Halleri - Soru 1 için Seçenek C", new Guid("78d4ea3b-9af6-40b1-8b70-0c8699b60e5d") },
                    { new Guid("efcdf44e-999b-4c44-8a0f-6b3191cd09cf"), false, "B", 2, "Elektrostatik - Soru 2 için Seçenek B", new Guid("baa8e93f-3bea-47cc-9027-a6091693ccfe") },
                    { new Guid("f0145108-2caa-4c6b-95d6-75e65adf3c5c"), true, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek A", new Guid("91dfc8bd-b7e2-4a67-be09-eee17cd91e61") },
                    { new Guid("f017c456-b628-452b-990d-1dc5dd4052da"), false, "A", 1, "Fizik Bilimine Giriş - Soru 2 için Seçenek A", new Guid("09acf546-5843-4004-80f9-50b874f052b0") },
                    { new Guid("f093a5fe-0e20-4811-bc3f-693da12cccaa"), false, "A", 1, "Kalıtım - Soru 5 için Seçenek A", new Guid("40abdf7a-4c60-4aea-80c1-4fb0bcea6545") },
                    { new Guid("f2eb5b92-7a66-4495-a21e-e605b0c64234"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek A", new Guid("6d6137f0-d451-4382-a466-e29f7007980d") },
                    { new Guid("f2f35c6d-b2c2-4b31-b613-2032b36fe4e9"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek B", new Guid("dbbca985-9be3-4ff1-bee8-9ea34f5c6314") },
                    { new Guid("f31bae86-a2ed-4eca-8d59-3ee4b59be2fb"), false, "D", 4, "Madde ve Özellikleri - Soru 4 için Seçenek D", new Guid("ffa8b6a4-472c-491a-a802-6c9d4e50da05") },
                    { new Guid("f3f58a82-002c-4869-b986-85f7f17256c5"), false, "A", 1, "Madde ve Özellikleri - Soru 4 için Seçenek A", new Guid("ffa8b6a4-472c-491a-a802-6c9d4e50da05") },
                    { new Guid("f42b7fa6-70ea-4244-8a60-d2dd06d72578"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek D", new Guid("f3e06e73-a04b-4b47-a255-ec2608778018") },
                    { new Guid("f4c90a4a-5ab4-45c7-95d6-f6ca3b55706d"), false, "B", 2, "Kuvvet ve Hareket - Soru 2 için Seçenek B", new Guid("9a39674d-58ac-4e51-b97b-4b1ada660c52") },
                    { new Guid("f4edcf2d-e5f0-4ecd-99e4-cbf012ff7767"), true, "D", 4, "Bölme ve Bölünebilme - Soru 1 için Seçenek D", new Guid("c9f2259f-fc9c-43a7-b4fa-7caf7004d21d") },
                    { new Guid("f533aa3c-c481-4832-874b-646ac1861fcb"), false, "D", 4, "Hücre - Soru 2 için Seçenek D", new Guid("556ceb04-7c37-4ee1-8b45-0c2388393495") },
                    { new Guid("f53c4b96-41a4-438d-94ab-bf2f035f4974"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek B", new Guid("e3cd3934-06d1-4da2-af6f-55a8b9a94a49") },
                    { new Guid("f6356bc9-8826-4488-919c-0a0466848bdc"), false, "A", 1, "Sayı Basamakları - Soru 3 için Seçenek A", new Guid("b7fddbc4-d0d9-4d11-b179-d54a3b8d5c29") },
                    { new Guid("f8407ae5-ce94-4581-a2b0-14c6ad5942f9"), false, "A", 1, "Kalıtım - Soru 4 için Seçenek A", new Guid("0ea05b44-952b-4dd1-bc36-299ba9498a1e") },
                    { new Guid("f8c05e0b-ada3-4ad0-9757-606c33a04f0a"), false, "A", 1, "Hücre Bölünmeleri - Soru 3 için Seçenek A", new Guid("b276f802-fc02-4795-adb1-25e51edbe0bb") },
                    { new Guid("f932f03d-7b2a-4ad8-82ac-c0cb1fa5bfbc"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 4 için Seçenek D", new Guid("da360ff9-8b66-48d4-86b0-85b4a375ce6d") },
                    { new Guid("f9a73075-5f68-408d-87e2-02ed41b9f76f"), true, "B", 2, "Kimya Bilimi - Soru 4 için Seçenek B", new Guid("577aee49-fde5-483b-81d8-d433c3ed578f") },
                    { new Guid("f9dae968-b268-4562-bb15-5420f4857232"), false, "A", 1, "Hücre Bölünmeleri - Soru 4 için Seçenek A", new Guid("8b42e08e-0b8d-4abb-adde-6f46fd3e9d8a") },
                    { new Guid("fab661b0-538e-41bf-8dc4-6ca95299d9ed"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 4 için Seçenek A", new Guid("6fd242ee-7d79-4d17-aa10-cdc75b053644") },
                    { new Guid("faff1eb9-b7ad-4741-95a7-6b05151f7ec0"), false, "B", 2, "Hücre - Soru 2 için Seçenek B", new Guid("556ceb04-7c37-4ee1-8b45-0c2388393495") },
                    { new Guid("fb1814b1-37e4-4fc0-8894-834323cbdb21"), false, "C", 3, "Bölme ve Bölünebilme - Soru 3 için Seçenek C", new Guid("9dcf362b-cba4-4b9c-873e-d3bb1276d008") },
                    { new Guid("fb44920b-4276-46a6-82d0-731315dfc2ca"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 1 için Seçenek A", new Guid("77cc75de-44d5-4a51-beb2-a592b05966be") },
                    { new Guid("fba2f616-afaa-4695-89d6-994809e7fd8a"), false, "C", 3, "Kalıtım - Soru 3 için Seçenek C", new Guid("3b68d56e-0a7a-455c-a2b4-c46d7da1ad17") },
                    { new Guid("fc4d2aeb-47f1-4a30-92c0-d6e3c8c8ebd8"), false, "A", 1, "Bölme ve Bölünebilme - Soru 1 için Seçenek A", new Guid("c9f2259f-fc9c-43a7-b4fa-7caf7004d21d") },
                    { new Guid("fcc3aeab-8efa-41d4-a453-6b653492acf8"), false, "C", 3, "Kuvvet ve Hareket - Soru 4 için Seçenek C", new Guid("2f3ffe58-76a0-4606-9556-8f33eb206256") },
                    { new Guid("fe0e40ac-573a-494e-8118-59d8709cbddd"), true, "B", 2, "Canlıların Sınıflandırılması - Soru 1 için Seçenek B", new Guid("77cc75de-44d5-4a51-beb2-a592b05966be") },
                    { new Guid("ff068481-7f3e-4774-919e-f971dc4e4cdc"), false, "D", 4, "Kimya Bilimi - Soru 2 için Seçenek D", new Guid("d1b2184c-dc3c-4a5f-abc6-b3ee58d54a5a") },
                    { new Guid("ff3593e7-24cb-4cd1-8357-d4667af6b2e7"), true, "B", 2, "Temel Kavramlar - Soru 5 için Seçenek B", new Guid("f3da37c6-5f29-4e70-a63f-a8dc3a4f1421") },
                    { new Guid("ff58ed76-47e8-4fd8-85e3-e8fb6465920b"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 1 için Seçenek B", new Guid("aee10aee-00c3-424f-b8ea-ecf661170258") },
                    { new Guid("ff8d1f30-f0ec-4c19-aac9-e7f293e97c2a"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek B", new Guid("4837789b-b171-4698-b5a2-23f90e1be593") },
                    { new Guid("ffa58485-6a5b-4d7d-be3e-477da31f8c0d"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek C", new Guid("4d6df717-fbc0-4950-8104-c7f552977e77") }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ParentTopicId", "SubjectId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("0ca0b070-59b1-4477-a325-0c92959c5fe8"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9942), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Sayı Basamakları" },
                    { new Guid("17160126-d7a6-4f2c-8f50-4fafc50e5b37"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9944), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Bölme ve Bölünebilme" },
                    { new Guid("4bdb7107-cdc0-49b8-8935-4fab107a545d"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9946), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Rasyonel Sayılar" },
                    { new Guid("51179be4-481b-472a-b83d-897fd2564161"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9995), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Canlıların Sınıflandırılması" },
                    { new Guid("53fef1e8-67a7-45f1-a338-0b13833f5906"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9994), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre" },
                    { new Guid("664051b2-6b97-4ee8-a4bd-7b9a8ec4ad6b"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9999), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Kalıtım" },
                    { new Guid("6a7bb8e8-9dab-4ce7-9320-193eee600dc0"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9962), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Madde ve Özellikleri" },
                    { new Guid("6b24fe25-72c9-499b-bf3e-05ffdd5fa6af"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9948), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Problemler" },
                    { new Guid("83fc14ae-390f-4812-a152-6d2e4b0bc51e"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9997), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre Bölünmeleri" },
                    { new Guid("84256273-6d1f-45c9-9879-4ae319732fa9"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9960), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Fizik Bilimine Giriş" },
                    { new Guid("8918897e-afe4-4cba-8ce6-0ed81a23a56b"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9984), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimyasal Türler Arası Etkileşimler" },
                    { new Guid("8ae7bf0a-a65a-4f82-9af8-958f1d374311"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9982), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Atom ve Periyodik Sistem" },
                    { new Guid("b0fcd6fc-03b7-4555-8b56-92a8cb403b30"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9965), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "İş, Güç ve Enerji" },
                    { new Guid("cb4b6107-12e3-46bf-8bd2-7f34edc1d6d1"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9981), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimya Bilimi" },
                    { new Guid("e63914ea-9e15-43e0-b47c-8dc7c86201f9"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9940), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Temel Kavramlar" },
                    { new Guid("e6b77b4f-8faf-4149-8552-4c5322b94951"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9992), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Yaşam Bilimi Biyoloji" },
                    { new Guid("e758651e-47f7-4a27-ab88-47e4106c17bf"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9967), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Elektrostatik" },
                    { new Guid("f03eb1e7-74d4-4e25-9089-038da8809839"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9987), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Maddenin Halleri" },
                    { new Guid("f46d7cad-4d67-401e-9a21-4865f600b85e"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9989), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Asitler, Bazlar ve Tuzlar" },
                    { new Guid("fdecf8d9-889d-44e5-8c02-1006dfdc3e31"), new DateTime(2025, 8, 7, 13, 21, 53, 646, DateTimeKind.Utc).AddTicks(9963), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Kuvvet ve Hareket" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsTopics",
                columns: new[] { "QuestionId", "TopicId", "Id" },
                values: new object[,]
                {
                    { new Guid("03bfa8a7-93c9-4cbe-b9e9-0c1ac77156d8"), new Guid("0ca0b070-59b1-4477-a325-0c92959c5fe8"), new Guid("7f1085dc-1f11-49bc-8180-659909f442e8") },
                    { new Guid("04c7f17a-78a5-42a0-b449-47824a1a2b4f"), new Guid("8ae7bf0a-a65a-4f82-9af8-958f1d374311"), new Guid("bf0b4ff6-e7ed-4f14-997c-b5d9a5ea3cdf") },
                    { new Guid("0604f96e-8559-4a9f-bd2e-0b1841b8e57c"), new Guid("53fef1e8-67a7-45f1-a338-0b13833f5906"), new Guid("b7eb0ab9-7024-4861-a6f9-379b707c7e62") },
                    { new Guid("09acf546-5843-4004-80f9-50b874f052b0"), new Guid("84256273-6d1f-45c9-9879-4ae319732fa9"), new Guid("2ec8a25d-78b0-4630-818e-c6c5141eb813") },
                    { new Guid("0ea05b44-952b-4dd1-bc36-299ba9498a1e"), new Guid("664051b2-6b97-4ee8-a4bd-7b9a8ec4ad6b"), new Guid("93ebf7c9-6aff-473b-a08f-892dc942a399") },
                    { new Guid("0f427dcb-4184-465a-a576-ba04c797429c"), new Guid("4bdb7107-cdc0-49b8-8935-4fab107a545d"), new Guid("a39a4df9-7fba-47c7-8c73-60916b53a83e") },
                    { new Guid("10edea59-5fde-4ac7-8be2-9fe88f953ebd"), new Guid("b0fcd6fc-03b7-4555-8b56-92a8cb403b30"), new Guid("99ef0b62-003c-4c85-b6ce-bd706c4d458f") },
                    { new Guid("1172d678-348d-46c4-b83d-7c0309ce818a"), new Guid("664051b2-6b97-4ee8-a4bd-7b9a8ec4ad6b"), new Guid("e32eab25-2966-41c4-bb7e-1bad5b2284aa") },
                    { new Guid("15d2a829-ce0d-4053-9110-acc0fefec4ce"), new Guid("51179be4-481b-472a-b83d-897fd2564161"), new Guid("80550755-bb3c-4c29-9008-3ac24d26d3f9") },
                    { new Guid("16e97036-90b0-4531-aa79-1356e62d7e0d"), new Guid("b0fcd6fc-03b7-4555-8b56-92a8cb403b30"), new Guid("a7775b30-f4de-4473-b6af-8875351eb9a1") },
                    { new Guid("1833398a-7439-49a1-9298-1c67ee9965c6"), new Guid("b0fcd6fc-03b7-4555-8b56-92a8cb403b30"), new Guid("8e9bbec5-78ac-4bd3-9aba-69840eabc23e") },
                    { new Guid("18c0168d-72d4-48dd-995b-7419519d213a"), new Guid("e758651e-47f7-4a27-ab88-47e4106c17bf"), new Guid("488b5c66-a557-4b6b-9d0b-35deb20d42c6") },
                    { new Guid("2ce01653-bb0e-4dff-b914-b326422645bd"), new Guid("83fc14ae-390f-4812-a152-6d2e4b0bc51e"), new Guid("4bbffcb3-3ef3-4697-9953-12346ed01b77") },
                    { new Guid("2e1a6023-dd55-4731-bb12-036c52c2239f"), new Guid("e758651e-47f7-4a27-ab88-47e4106c17bf"), new Guid("31d5ed74-d729-4dff-8b09-3d07deb7f890") },
                    { new Guid("2f3ffe58-76a0-4606-9556-8f33eb206256"), new Guid("fdecf8d9-889d-44e5-8c02-1006dfdc3e31"), new Guid("94907a92-5fae-4a3c-8354-c575f23f4e17") },
                    { new Guid("35cba56a-9c1f-4c1b-8f9a-fea395e1ff99"), new Guid("0ca0b070-59b1-4477-a325-0c92959c5fe8"), new Guid("cbbad6de-6e50-4a92-853b-870efe37388b") },
                    { new Guid("37d6f10e-c035-4779-98d4-38e99e2650a0"), new Guid("e6b77b4f-8faf-4149-8552-4c5322b94951"), new Guid("3b0afc88-510c-4403-8a24-b0306ad4a0ac") },
                    { new Guid("3901fd77-e668-458a-bb9c-d5126c131bf9"), new Guid("53fef1e8-67a7-45f1-a338-0b13833f5906"), new Guid("16f69ee1-b281-48c4-a114-a4d6ab9aaa40") },
                    { new Guid("396eba31-d145-4f20-8b4e-fbab042041af"), new Guid("e63914ea-9e15-43e0-b47c-8dc7c86201f9"), new Guid("0e481d9a-40a3-44ac-8bb2-f244ad0e53ab") },
                    { new Guid("3b68d56e-0a7a-455c-a2b4-c46d7da1ad17"), new Guid("664051b2-6b97-4ee8-a4bd-7b9a8ec4ad6b"), new Guid("5da1baf4-4eaf-44c7-bbe2-4b9376480bff") },
                    { new Guid("3e0b2125-1137-4fae-a56d-7a73b625535d"), new Guid("f03eb1e7-74d4-4e25-9089-038da8809839"), new Guid("522610d1-8f1c-4b13-af99-2c322f79dfc1") },
                    { new Guid("40abdf7a-4c60-4aea-80c1-4fb0bcea6545"), new Guid("664051b2-6b97-4ee8-a4bd-7b9a8ec4ad6b"), new Guid("cbf33a52-be77-444d-a48d-ce41a842b533") },
                    { new Guid("4613e5e0-97dc-4a0c-a755-05a65b74376b"), new Guid("b0fcd6fc-03b7-4555-8b56-92a8cb403b30"), new Guid("477ab9cb-80b9-44bc-908c-9fab449ae9b8") },
                    { new Guid("4837789b-b171-4698-b5a2-23f90e1be593"), new Guid("f46d7cad-4d67-401e-9a21-4865f600b85e"), new Guid("eee370c5-8d94-4765-9810-6f050541ba1e") },
                    { new Guid("4d6df717-fbc0-4950-8104-c7f552977e77"), new Guid("8918897e-afe4-4cba-8ce6-0ed81a23a56b"), new Guid("0bac3e62-e9f5-4542-9f80-369dae6a8e14") },
                    { new Guid("4e1a5fed-6a72-4e03-a2c9-0235d079b4c8"), new Guid("8ae7bf0a-a65a-4f82-9af8-958f1d374311"), new Guid("0fd76541-e3af-40ce-b31d-64aff7ebff42") },
                    { new Guid("4f5e358d-f82d-4c9d-ad75-e7ea88d58e6f"), new Guid("cb4b6107-12e3-46bf-8bd2-7f34edc1d6d1"), new Guid("3415031f-60b7-43fb-8cb9-f940af5eb24a") },
                    { new Guid("4fb4073c-ca6b-4a72-bdb5-1f79777701dd"), new Guid("e63914ea-9e15-43e0-b47c-8dc7c86201f9"), new Guid("1402f3da-6f27-4360-9c75-7e35436df8c1") },
                    { new Guid("53077c0e-1884-4d6a-a128-d8ee9b410822"), new Guid("8918897e-afe4-4cba-8ce6-0ed81a23a56b"), new Guid("5d97a234-ffe6-488b-8450-ffc40628b586") },
                    { new Guid("556ceb04-7c37-4ee1-8b45-0c2388393495"), new Guid("53fef1e8-67a7-45f1-a338-0b13833f5906"), new Guid("babb0444-76a2-4b88-b65b-9e65f455838e") },
                    { new Guid("577aee49-fde5-483b-81d8-d433c3ed578f"), new Guid("cb4b6107-12e3-46bf-8bd2-7f34edc1d6d1"), new Guid("7830be6a-b634-46bb-9ca0-5e89307645be") },
                    { new Guid("58218d2a-cf24-4f59-a3f2-044be6e62a4e"), new Guid("4bdb7107-cdc0-49b8-8935-4fab107a545d"), new Guid("583eba96-d7e6-4663-8038-0d7748e2b631") },
                    { new Guid("59b9584b-3741-4357-9321-0828919951ff"), new Guid("e758651e-47f7-4a27-ab88-47e4106c17bf"), new Guid("0d5fbc6b-586f-421c-b439-2817a743b681") },
                    { new Guid("5b658537-f30f-4e2c-890d-3c5c17514784"), new Guid("fdecf8d9-889d-44e5-8c02-1006dfdc3e31"), new Guid("0a75d419-856f-46e4-a6ed-e4904ab98d3c") },
                    { new Guid("616002e8-a5c3-43e6-a934-e9341ef37268"), new Guid("83fc14ae-390f-4812-a152-6d2e4b0bc51e"), new Guid("f5d86593-6f57-489b-a407-749ac57e350c") },
                    { new Guid("62b69aaf-f178-4d91-bf9a-4a71e78d6963"), new Guid("6a7bb8e8-9dab-4ce7-9320-193eee600dc0"), new Guid("0683a7c8-acfe-4341-a8b9-1b6713162682") },
                    { new Guid("687d5a60-e0a7-4837-9ca5-23dc1e923069"), new Guid("4bdb7107-cdc0-49b8-8935-4fab107a545d"), new Guid("7abff238-1636-4246-aae4-9c920691c3d8") },
                    { new Guid("6b988903-14c1-4408-b681-6b35c5435309"), new Guid("b0fcd6fc-03b7-4555-8b56-92a8cb403b30"), new Guid("0f8f5e76-8ebe-41e2-8a0e-2edc2a79b7e1") },
                    { new Guid("6d6137f0-d451-4382-a466-e29f7007980d"), new Guid("f46d7cad-4d67-401e-9a21-4865f600b85e"), new Guid("183009e2-f1dd-4807-85f3-0b365fb84db9") },
                    { new Guid("6dbfafa1-9246-425f-a9a9-a8fb675373db"), new Guid("cb4b6107-12e3-46bf-8bd2-7f34edc1d6d1"), new Guid("bd207841-6d84-46c5-8657-120a1af24198") },
                    { new Guid("6fafb9e7-75ca-463a-ad30-72356e12fd43"), new Guid("4bdb7107-cdc0-49b8-8935-4fab107a545d"), new Guid("0f66fa42-dbe0-46b1-8bb2-76ece01ea151") },
                    { new Guid("6fd242ee-7d79-4d17-aa10-cdc75b053644"), new Guid("51179be4-481b-472a-b83d-897fd2564161"), new Guid("ccc884d3-53c3-4b9e-86ce-689309cea50e") },
                    { new Guid("76304573-b455-48c1-bda2-21632ba096fe"), new Guid("6b24fe25-72c9-499b-bf3e-05ffdd5fa6af"), new Guid("f62c5dc3-ad27-4b5c-87db-e103c8db0c29") },
                    { new Guid("77419c6a-2c89-45ae-b5c8-44cee62a8cb1"), new Guid("6b24fe25-72c9-499b-bf3e-05ffdd5fa6af"), new Guid("a67c412a-4d16-4682-9d14-3f89c376ce14") },
                    { new Guid("77cc75de-44d5-4a51-beb2-a592b05966be"), new Guid("51179be4-481b-472a-b83d-897fd2564161"), new Guid("4e7c7ab4-d944-459b-a254-aee76281dc31") },
                    { new Guid("78bbc65e-a615-4705-a4ea-1b9dc552a82d"), new Guid("f03eb1e7-74d4-4e25-9089-038da8809839"), new Guid("30055712-0b9d-4d5c-a493-ba1d40ae5bc5") },
                    { new Guid("78d4ea3b-9af6-40b1-8b70-0c8699b60e5d"), new Guid("f03eb1e7-74d4-4e25-9089-038da8809839"), new Guid("382dcacc-d095-4933-9d9e-caef8255f9f9") },
                    { new Guid("7e62a768-fb2c-4cd9-8d8b-2e107a5bedbf"), new Guid("fdecf8d9-889d-44e5-8c02-1006dfdc3e31"), new Guid("352176ae-aaf9-4854-a17c-53359bf2a2ad") },
                    { new Guid("805fe97e-0c5e-4d42-b6c9-1651f81a0975"), new Guid("0ca0b070-59b1-4477-a325-0c92959c5fe8"), new Guid("f0a00454-312d-4a43-9844-b0e24054fa9c") },
                    { new Guid("822514d4-6b32-453e-ab6f-51519f540fda"), new Guid("51179be4-481b-472a-b83d-897fd2564161"), new Guid("dbb51abc-f426-4e98-b0ac-150f141db01e") },
                    { new Guid("83cea481-cf9d-4001-98f8-c2fe416bbce7"), new Guid("e6b77b4f-8faf-4149-8552-4c5322b94951"), new Guid("bede7c9e-5d6e-4c00-8d33-882f81395b59") },
                    { new Guid("8b42e08e-0b8d-4abb-adde-6f46fd3e9d8a"), new Guid("83fc14ae-390f-4812-a152-6d2e4b0bc51e"), new Guid("91288372-94b0-4f38-a8cb-ffb128fc2a13") },
                    { new Guid("91dfc8bd-b7e2-4a67-be09-eee17cd91e61"), new Guid("f46d7cad-4d67-401e-9a21-4865f600b85e"), new Guid("84d01f15-b0a8-4112-baae-484875d4ec9b") },
                    { new Guid("97674af0-4afc-4631-932d-012e5ef5ada3"), new Guid("84256273-6d1f-45c9-9879-4ae319732fa9"), new Guid("0ca56ba8-3ac8-43d3-81df-92faa49b12e7") },
                    { new Guid("9787b9c9-1ae8-48c1-8853-e60327ff2633"), new Guid("6a7bb8e8-9dab-4ce7-9320-193eee600dc0"), new Guid("357b2414-48cb-4ef4-a3ce-ede95594624a") },
                    { new Guid("9a39674d-58ac-4e51-b97b-4b1ada660c52"), new Guid("fdecf8d9-889d-44e5-8c02-1006dfdc3e31"), new Guid("510f9776-8c11-4db5-b41a-6b54d6c7cff5") },
                    { new Guid("9c1896ef-5d2a-4cd1-8080-b0f63eeb6488"), new Guid("53fef1e8-67a7-45f1-a338-0b13833f5906"), new Guid("4d6b6390-9b42-4728-b966-ffdfc0220b1d") },
                    { new Guid("9dcf362b-cba4-4b9c-873e-d3bb1276d008"), new Guid("17160126-d7a6-4f2c-8f50-4fafc50e5b37"), new Guid("c2e38b0b-7449-42d5-8557-bf70602850e3") },
                    { new Guid("a0f91289-e705-4772-b298-a5f81ebe5ad5"), new Guid("6b24fe25-72c9-499b-bf3e-05ffdd5fa6af"), new Guid("95ffc2a3-44fb-4a37-b773-76d6a15cb656") },
                    { new Guid("a23e372a-03b9-40bd-922b-c8c678651ce9"), new Guid("53fef1e8-67a7-45f1-a338-0b13833f5906"), new Guid("c5a74401-5f8e-43c1-a16b-5cd8fe2ed39e") },
                    { new Guid("a4292e06-0cb7-4b22-9b81-69a37cc7f538"), new Guid("17160126-d7a6-4f2c-8f50-4fafc50e5b37"), new Guid("39f3e86b-502a-4672-8953-05956a616d72") },
                    { new Guid("a67002b0-f652-40c3-a097-1e61847592a8"), new Guid("cb4b6107-12e3-46bf-8bd2-7f34edc1d6d1"), new Guid("f042c605-94bd-4b8b-850e-456c9a29809a") },
                    { new Guid("a84ea548-c1e3-40e8-9bbd-dbe29d3784a7"), new Guid("84256273-6d1f-45c9-9879-4ae319732fa9"), new Guid("b6fd87f5-bded-4548-9c30-8b9493ee956d") },
                    { new Guid("ab8f27c6-350d-484c-9a9e-f0ffdc9862bc"), new Guid("664051b2-6b97-4ee8-a4bd-7b9a8ec4ad6b"), new Guid("0e3b5c91-7a6e-4fc1-9edb-eea2a1e4488d") },
                    { new Guid("aee10aee-00c3-424f-b8ea-ecf661170258"), new Guid("8ae7bf0a-a65a-4f82-9af8-958f1d374311"), new Guid("8dd9a635-73af-43bc-9df2-624619e841b0") },
                    { new Guid("b1f52cc3-78a9-4132-a420-0f6ca34a7c18"), new Guid("6b24fe25-72c9-499b-bf3e-05ffdd5fa6af"), new Guid("305435c2-723b-47fb-8a18-245ad5828ba2") },
                    { new Guid("b276f802-fc02-4795-adb1-25e51edbe0bb"), new Guid("83fc14ae-390f-4812-a152-6d2e4b0bc51e"), new Guid("56833dad-ada5-4c1e-8fa4-2d42213272d6") },
                    { new Guid("b7fddbc4-d0d9-4d11-b179-d54a3b8d5c29"), new Guid("0ca0b070-59b1-4477-a325-0c92959c5fe8"), new Guid("df8c2de3-bf50-46d2-ba2c-4743ad50469e") },
                    { new Guid("b81ca42d-db92-41e3-a38a-69a072344be7"), new Guid("51179be4-481b-472a-b83d-897fd2564161"), new Guid("0de4ccae-9006-4f16-a047-d997add8f80d") },
                    { new Guid("baa8e93f-3bea-47cc-9027-a6091693ccfe"), new Guid("e758651e-47f7-4a27-ab88-47e4106c17bf"), new Guid("72ff035c-9cf9-4de9-a12d-52161ff5ea44") },
                    { new Guid("c08f1dee-0678-4fa9-84a8-70efb13c6790"), new Guid("f46d7cad-4d67-401e-9a21-4865f600b85e"), new Guid("5845d581-6dee-4480-a423-93ab11f599df") },
                    { new Guid("c9f2259f-fc9c-43a7-b4fa-7caf7004d21d"), new Guid("17160126-d7a6-4f2c-8f50-4fafc50e5b37"), new Guid("a16fd86d-d83e-470b-8593-535c7df0ece3") },
                    { new Guid("ca022ff0-2082-4994-ac28-c6fb111d024e"), new Guid("4bdb7107-cdc0-49b8-8935-4fab107a545d"), new Guid("57dd5cef-d37a-4980-b5f0-4f16febab773") },
                    { new Guid("cdcadaa8-d89e-4885-a3e8-cadfcf15483c"), new Guid("f03eb1e7-74d4-4e25-9089-038da8809839"), new Guid("6068d89a-f06b-4cf4-b9ce-7223d67c5cfd") },
                    { new Guid("ce9701a4-91da-4eff-b9c7-fd5f94903df0"), new Guid("8ae7bf0a-a65a-4f82-9af8-958f1d374311"), new Guid("4be4654d-c756-4eec-9f7e-12c9938ace48") },
                    { new Guid("d1b2184c-dc3c-4a5f-abc6-b3ee58d54a5a"), new Guid("cb4b6107-12e3-46bf-8bd2-7f34edc1d6d1"), new Guid("0c90b5a7-db4d-476a-9560-3334aa9f9d64") },
                    { new Guid("d53db1cd-4638-4559-b2b5-e547dec881ad"), new Guid("6a7bb8e8-9dab-4ce7-9320-193eee600dc0"), new Guid("54211566-ce2e-42fe-bce0-b30657232e32") },
                    { new Guid("d65a8559-407e-4ad0-9440-86a0b977462e"), new Guid("6b24fe25-72c9-499b-bf3e-05ffdd5fa6af"), new Guid("bf0cc374-e0fe-4347-8c54-eb9a66830b9a") },
                    { new Guid("d6f82f30-79ab-4c4b-bc39-4041420e0ee5"), new Guid("84256273-6d1f-45c9-9879-4ae319732fa9"), new Guid("6f734509-9b39-45d9-8f1d-54b84f0fe662") },
                    { new Guid("d91a3c6a-43be-4ed7-b96d-53f248c64ca3"), new Guid("e758651e-47f7-4a27-ab88-47e4106c17bf"), new Guid("bb0921ab-2667-4550-80e1-d1f985e48971") },
                    { new Guid("da360ff9-8b66-48d4-86b0-85b4a375ce6d"), new Guid("8ae7bf0a-a65a-4f82-9af8-958f1d374311"), new Guid("11edb4a7-2b37-402a-88ae-cc737590aa36") },
                    { new Guid("dbbca985-9be3-4ff1-bee8-9ea34f5c6314"), new Guid("f46d7cad-4d67-401e-9a21-4865f600b85e"), new Guid("304e4e7c-a10f-4bbb-8749-b5590b353d65") },
                    { new Guid("dbce2b19-465b-40c3-ada1-3c0c4ba53c56"), new Guid("6a7bb8e8-9dab-4ce7-9320-193eee600dc0"), new Guid("91b0e458-5a65-4cf7-b90d-8f5a3758d3c0") },
                    { new Guid("dc653c71-734f-4075-986b-aad18545a81d"), new Guid("f03eb1e7-74d4-4e25-9089-038da8809839"), new Guid("dd77f729-b7a8-4b1e-942e-4c7b5c152c94") },
                    { new Guid("e08dff57-8a65-48bd-95b7-435e8e8ec667"), new Guid("17160126-d7a6-4f2c-8f50-4fafc50e5b37"), new Guid("e905bc5b-1fbe-4bb2-93c0-e14bfddf5438") },
                    { new Guid("e1ded32b-f943-48a4-82e5-5706d8cbd01a"), new Guid("e6b77b4f-8faf-4149-8552-4c5322b94951"), new Guid("22a7fd2d-60cf-4a2f-ac95-017b56065d6b") },
                    { new Guid("e22d4674-8953-4e4a-9b8e-4892d9b9006e"), new Guid("e63914ea-9e15-43e0-b47c-8dc7c86201f9"), new Guid("2028b7e1-eda7-43ab-a9e4-ad96f40abd5f") },
                    { new Guid("e3cd3934-06d1-4da2-af6f-55a8b9a94a49"), new Guid("e6b77b4f-8faf-4149-8552-4c5322b94951"), new Guid("fb97ee71-bc3c-4d8b-809f-b2990dbd5450") },
                    { new Guid("e4e028a6-beba-48b9-b82e-94f7d01486cf"), new Guid("83fc14ae-390f-4812-a152-6d2e4b0bc51e"), new Guid("d90d7873-42ca-4437-a16b-9a5adccfde69") },
                    { new Guid("e6190ebb-2fef-478f-af44-cfdba14440a5"), new Guid("fdecf8d9-889d-44e5-8c02-1006dfdc3e31"), new Guid("ae01e139-fcf6-43a8-98e1-59d43f049d5e") },
                    { new Guid("ed7977f0-75c1-4ee0-a035-bb6875818830"), new Guid("0ca0b070-59b1-4477-a325-0c92959c5fe8"), new Guid("312855cd-022a-4198-bda7-63f7784e60ec") },
                    { new Guid("eed7f50e-be17-4fa6-9183-65697522351f"), new Guid("84256273-6d1f-45c9-9879-4ae319732fa9"), new Guid("29bc04dd-aec5-4a6c-9553-f50348faf6d4") },
                    { new Guid("f3da37c6-5f29-4e70-a63f-a8dc3a4f1421"), new Guid("e63914ea-9e15-43e0-b47c-8dc7c86201f9"), new Guid("42514907-517f-4eba-bf5a-ac126d5342b1") },
                    { new Guid("f3e06e73-a04b-4b47-a255-ec2608778018"), new Guid("8918897e-afe4-4cba-8ce6-0ed81a23a56b"), new Guid("a7e4871a-cf82-4f1a-b009-e24d73f4da55") },
                    { new Guid("f46a9bd5-6b08-4818-ad5f-df1deb0b326b"), new Guid("8918897e-afe4-4cba-8ce6-0ed81a23a56b"), new Guid("de3d4f34-bb86-44cd-b13a-7539f7a42378") },
                    { new Guid("f51ee193-8a7d-48cd-ab48-fe72bcd7f605"), new Guid("8918897e-afe4-4cba-8ce6-0ed81a23a56b"), new Guid("d74355d4-bfe7-433e-9273-dbf4d7b24eaa") },
                    { new Guid("f7548d51-822a-445a-8d1b-679e7dff2519"), new Guid("e63914ea-9e15-43e0-b47c-8dc7c86201f9"), new Guid("08bc7b82-3851-466e-9409-7386d482297f") },
                    { new Guid("fcceb9bf-9d39-46fd-81ec-6b7984a422f0"), new Guid("e6b77b4f-8faf-4149-8552-4c5322b94951"), new Guid("ed777924-239f-4c89-9884-0a9235414649") },
                    { new Guid("fd1ef666-b343-430a-935c-e90658a3bb44"), new Guid("17160126-d7a6-4f2c-8f50-4fafc50e5b37"), new Guid("bd09af02-8519-48d6-9b76-8a6c4aff8358") },
                    { new Guid("ffa8b6a4-472c-491a-a802-6c9d4e50da05"), new Guid("6a7bb8e8-9dab-4ce7-9320-193eee600dc0"), new Guid("a8f01a38-6769-4692-b4c1-8a211dd545c3") }
                });

            migrationBuilder.InsertData(
                table: "UserPerformanceSummaries",
                columns: new[] { "Id", "CorrectAnswers", "CreatedAt", "LastUpdatedAt", "SuccessRate", "TopicId", "TotalQuestionsAnswered", "UserId" },
                values: new object[,]
                {
                    { new Guid("03e71382-2e17-4dc4-b232-9d9345fc1d49"), 11, new DateTime(2025, 7, 17, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4340), new DateTime(2025, 8, 7, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4347), 32.350000000000001, new Guid("e63914ea-9e15-43e0-b47c-8dc7c86201f9"), 34, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("16cef69b-09bc-4fbf-826c-b153d38f949f"), 13, new DateTime(2025, 7, 15, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4378), new DateTime(2025, 8, 4, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4378), 65.0, new Guid("e63914ea-9e15-43e0-b47c-8dc7c86201f9"), 20, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("26d6fb15-6f70-4799-931b-8d1d0de20f21"), 18, new DateTime(2025, 7, 30, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4356), new DateTime(2025, 8, 6, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4357), 31.579999999999998, new Guid("17160126-d7a6-4f2c-8f50-4fafc50e5b37"), 57, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("414e01d1-3fa9-4840-8804-e14f755a4b47"), 66, new DateTime(2025, 7, 31, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4380), new DateTime(2025, 8, 2, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4380), 90.409999999999997, new Guid("0ca0b070-59b1-4477-a325-0c92959c5fe8"), 73, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("463d122e-f359-400e-b229-b5720eb74f6d"), 9, new DateTime(2025, 7, 28, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4360), new DateTime(2025, 8, 3, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4361), 69.230000000000004, new Guid("6b24fe25-72c9-499b-bf3e-05ffdd5fa6af"), 13, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("50851207-c28a-43eb-b66f-b541ea1ae145"), 45, new DateTime(2025, 8, 4, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4385), new DateTime(2025, 8, 2, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4385), 55.560000000000002, new Guid("6b24fe25-72c9-499b-bf3e-05ffdd5fa6af"), 81, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("5b791c9c-d8b2-4b77-8282-a586385f793f"), 20, new DateTime(2025, 7, 13, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4383), new DateTime(2025, 8, 3, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4383), 24.100000000000001, new Guid("4bdb7107-cdc0-49b8-8935-4fab107a545d"), 83, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("6f80e0fe-ceb7-4f26-903f-5545c4af56ec"), 36, new DateTime(2025, 8, 5, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4381), new DateTime(2025, 8, 4, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4382), 94.739999999999995, new Guid("17160126-d7a6-4f2c-8f50-4fafc50e5b37"), 38, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("904d5003-f0db-4d53-9518-57f8bc034e46"), 47, new DateTime(2025, 7, 19, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4371), new DateTime(2025, 8, 7, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4371), 51.649999999999999, new Guid("4bdb7107-cdc0-49b8-8935-4fab107a545d"), 91, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("91439e12-eff1-4b28-9504-696c34021901"), 49, new DateTime(2025, 7, 17, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4367), new DateTime(2025, 8, 2, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4367), 98.0, new Guid("0ca0b070-59b1-4477-a325-0c92959c5fe8"), 50, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("a3fe98d0-1da9-4c75-9b66-69295e218bbb"), 40, new DateTime(2025, 7, 10, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4358), new DateTime(2025, 8, 4, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4359), 54.049999999999997, new Guid("4bdb7107-cdc0-49b8-8935-4fab107a545d"), 74, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c5bf37a5-317f-4ece-90e0-dc0db025e385"), 47, new DateTime(2025, 8, 4, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4365), new DateTime(2025, 8, 4, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4365), 49.469999999999999, new Guid("e63914ea-9e15-43e0-b47c-8dc7c86201f9"), 95, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("c996d069-f120-4b6c-850b-3efed95171d9"), 42, new DateTime(2025, 8, 4, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4369), new DateTime(2025, 8, 7, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4369), 76.359999999999999, new Guid("17160126-d7a6-4f2c-8f50-4fafc50e5b37"), 55, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("d33a783a-50c9-423c-a751-d45365df891d"), 6, new DateTime(2025, 8, 1, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4373), new DateTime(2025, 8, 4, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4374), 7.8899999999999997, new Guid("6b24fe25-72c9-499b-bf3e-05ffdd5fa6af"), 76, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("d343db2e-4431-4d2b-94c4-a35fdd31a4e9"), 12, new DateTime(2025, 7, 19, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4352), new DateTime(2025, 8, 1, 13, 21, 53, 647, DateTimeKind.Utc).AddTicks(4352), 13.039999999999999, new Guid("0ca0b070-59b1-4477-a325-0c92959c5fe8"), 92, new Guid("11111111-1111-1111-1111-111111111111") }
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
