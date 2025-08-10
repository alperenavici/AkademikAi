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
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "dummy-conc-1", new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(194), "ali@example.com", true, false, null, "Ali", "ALI@EXAMPLE.COM", "ALI", "AQAAAAEAACcQAAAAEDummyHash1==", "5551111111", false, "dummy-stamp-1", "Veli", false, "ali", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "dummy-conc-2", new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(204), "ayse@example.com", true, false, null, "Ayşe", "AYSE@EXAMPLE.COM", "AYSE", "AQAAAAEAACcQAAAAEDummyHash2==", "5552222222", false, "dummy-stamp-2", "Yılmaz", false, "ayse", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "dummy-conc-3", new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(209), "mehmet@example.com", true, false, null, "Mehmet", "MEHMET@EXAMPLE.COM", "MEHMET", "AQAAAAEAACcQAAAAEDummyHash3==", "5553333333", false, "dummy-stamp-3", "Demir", false, "mehmet", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevel", "GeneratedForUserId", "IsActive", "QuestionText", "SolutionText", "Source" },
                values: new object[,]
                {
                    { new Guid("003dfac8-e219-4b3a-9eb6-cb76104e1492"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("02e6f607-8b8a-43a2-b3aa-caa30b7802d9"), 2, null, true, "Elektrostatik konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("03adc41e-0332-46b2-a6b9-8e2a5d5fbde3"), 2, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("03e98a56-7841-45f4-b07d-07d699aede00"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("062a784f-4baf-4140-91d1-1ab886f68c0f"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("06bd1a8e-5569-4a61-92a3-bd4c80266f7e"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0f92b22f-6510-4b8d-9135-82302d726865"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1202a873-23eb-4ca1-90b3-7987ee911752"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("18d203ba-bf99-4be7-8bb7-c38ef6f99e99"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("199ef779-16ad-4e64-a1e3-bb499cad8e25"), 2, null, true, "Kalıtım konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1c06427a-dc7f-4849-9e67-a10856b039ab"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1c6b18a9-9524-49cf-9033-b29c50e5d383"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1e1b3926-764e-495f-bdb6-03ddb6d7c7bf"), 2, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1f850f00-4f74-4039-8f90-f1270d74e1cf"), 0, null, true, "Kalıtım konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("21880a68-508c-4b46-b8e9-69e97596898f"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("23b4e4d9-2530-4dac-a9b6-dd5d48e785b0"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("25953dc6-27d2-46db-acf3-152509ffc736"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("28002858-465a-417b-bfa7-3a72038cd8a6"), 2, null, true, "Maddenin Halleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2a741688-ecc6-48cb-93a0-482a4741de3f"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2b22135d-f156-4c29-9e19-09f32fb87aff"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2dd76c28-9021-4441-bbf8-e296fc826e2a"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2f24a948-46b8-469e-a612-922a2df4f1a3"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("30b03c24-5ff2-41c4-92f0-a65ad999b151"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("31327bd2-4b4d-4be6-831d-6a18ee884399"), 2, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3162e81e-ad16-4374-968f-a2abaa8733f9"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("345b8a1b-411a-46f7-874b-5e495468ee9d"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3733dd7f-a924-441e-8efc-274eb40e0f81"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("392f71a1-1c67-4ec0-86ad-227e45e0bee5"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3c302787-ec8d-4529-a7c5-ce61d4823c4f"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3faaef56-9f97-4651-a80e-2a722a915d28"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("408fd400-a4f0-46c4-963a-c57129bc26d3"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("41a635e5-f01e-46c6-951d-c6bc9848c652"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("47bbd168-a4f9-4e56-a387-92c939b267b8"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("495d2ec6-e940-4040-9bc1-89a4807156cd"), 2, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("497aec3f-a50d-4ea3-bf7c-d40ae715ca5b"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4a636af9-c040-4ae1-95b0-025e142f9f7f"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("527ec67a-8698-436d-a363-42a6122ca448"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("53e5b503-786e-415d-b17a-8756c8c9a680"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("55c237bd-4d6c-4c61-b819-90f432067fb5"), 1, null, true, "Hücre konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5bf2a380-cd04-4ba5-a758-3feed65fe551"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("605f0a56-070a-4151-af2d-bdbb9b9be810"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("60940b98-535b-4fab-9663-9b7d15c6670c"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6153cdd5-27a9-4d11-a834-419ba59efb1d"), 2, null, true, "Problemler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("64b6621b-cfc1-4be3-80b5-47b205e5968d"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6a3a8811-4a55-4b7b-bcaf-4eeb71e8c55f"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6d438930-6ae4-4f8a-a2fd-778d7b0775c2"), 0, null, true, "Kalıtım konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("71e8619c-4c33-40ed-8191-cb207d1e2bb6"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("73e503b1-c6d5-4d16-a76c-6ad75743af00"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("76515146-e41b-4f4f-bf2f-4253febf5911"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("79160525-70da-4a07-b0a6-7a80351e5ce8"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7abddf71-514b-4424-8bd6-7007eb4a6378"), 2, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7b9c9537-a6b3-4b23-a21c-6b95938ff38a"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7c6b1554-0525-49ed-8016-5420e0f95176"), 2, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7d7d1fd0-07f8-4b0c-8325-093a3e577906"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7d95f37a-80a7-4275-8814-7a04fdb92254"), 1, null, true, "Kalıtım konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("84ca6a0b-0d63-4a8a-be9f-1faa3759bd05"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("874a316b-b698-4b4b-95fa-492afcc48702"), 1, null, true, "Problemler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("87cc61ee-3d84-4fdb-9c26-dea768357115"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("89c38696-4e47-486c-b0e4-6b2d84d5f3fc"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8b3995f9-4a90-4557-a64e-298811ffa5b6"), 1, null, true, "Problemler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8c3df66f-aef3-4986-8cc8-93b4c3090e44"), 1, null, true, "Hücre konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("91ba48ff-55fc-44be-a780-3f8e5fff3b3f"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("92bcea13-5532-46a5-98de-0e75f45a6b59"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("95202c6b-63b7-4a5a-bb0f-7581906a16e8"), 2, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("957806db-cbe6-4b24-984a-c8be2bad6e90"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("96ac416a-2cd8-4c3b-9f9a-122353e62104"), 2, null, true, "Hücre konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("96f4a0bf-b982-45a5-9e10-55771b562f73"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("99246c1b-b094-4a3a-83eb-e7e225f55134"), 1, null, true, "Kalıtım konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("994089a5-c409-447f-9cc4-98e9c4581290"), 2, null, true, "Temel Kavramlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9b1b3dc7-beaf-4cde-9040-b82d977d5370"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9be55a0d-09ad-481e-b11e-cce848bf86d8"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9cac2c9b-0317-4e60-acbc-da4f0527ce11"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a0e996de-9b39-41bf-9689-fecce472fd7a"), 2, null, true, "Sayı Basamakları konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a195ec7e-e341-4d0a-9c0f-e612c10733b2"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a859809a-5720-4d9a-a5fe-9e5986391703"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a886e878-83df-425d-a358-a88f8ef3a4db"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a9ea9bb2-c3fe-4e18-97ee-6c6b8f7b909c"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("aa743add-6dfa-4d6c-b1ef-65402ea03d59"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b06e41d9-c68e-46f1-af6b-3d619ab9ca4a"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b0e0f817-a3d2-4e52-8402-f6c5b2f3a97e"), 2, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b30ce0c8-830c-471c-891f-5ce8b24965dd"), 2, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b64cb03b-5c9b-4247-a02b-90a69dece5bc"), 2, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b82e78da-37d7-4ec3-a0e1-486515ee1cc4"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("bb47c3d2-dc1c-4b5d-aaf6-595bef028bf6"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c02d5253-9ab6-4618-b155-75d4ac0c0182"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c58172f4-9b92-4e2a-8564-885024aa9bdc"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c5b6cdb9-24a1-4902-b106-42bc7399534b"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c983e23f-dc16-4608-83f4-caf219f635c1"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("cfa2bf07-4e6f-4416-98d4-79f4470ae71a"), 2, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("cfd52a72-184d-4294-9f53-b1894bce57f5"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("de2f121c-e0dd-4f61-82d6-1aee68263d83"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("dff054d4-bfde-49fb-adf3-b2e1d0eb1610"), 0, null, true, "Hücre konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e1c15fd8-3a8f-44ec-af02-c417b63bba07"), 2, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e3fd23d0-22ec-4efb-89db-303d2130ddd5"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e962f3e7-943a-43dd-a1e8-4df9146bfc3d"), 0, null, true, "Problemler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e9ebb795-ef4f-412f-a8dd-f0c2d0dc335c"), 0, null, true, "Problemler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ec7a34ec-7da6-4f97-b2b4-b7a305766dbe"), 2, null, true, "Kimya Bilimi konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f7659659-5021-4e61-81a4-c8190a649d9f"), 0, null, true, "Hücre konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f85acec7-f71c-4e30-b854-ce0fb755eef4"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f9b41ecd-86d3-4d58-8b25-92251cd4ac5f"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(319), "Temel kimya konuları", true, "Kimya" },
                    { new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(317), "Temel fizik konuları", true, "Fizik" },
                    { new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(321), "Temel biyoloji konuları", true, "Biyoloji" },
                    { new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(313), "Temel matematik konuları", true, "Matematik" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "IsCorrect", "Label", "OptionOrder", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("006f6f6a-3355-418e-b24e-63e1e8c52640"), false, "C", 3, "Maddenin Halleri - Soru 4 için Seçenek C", new Guid("a886e878-83df-425d-a358-a88f8ef3a4db") },
                    { new Guid("0094c5b3-bb95-41d8-b853-9ee7cb586d82"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 2 için Seçenek A", new Guid("de2f121c-e0dd-4f61-82d6-1aee68263d83") },
                    { new Guid("012ed45d-7c0e-426d-9344-d973777d7f00"), false, "A", 1, "Rasyonel Sayılar - Soru 2 için Seçenek A", new Guid("957806db-cbe6-4b24-984a-c8be2bad6e90") },
                    { new Guid("021967c8-576e-47ff-9dce-7509c0b9de49"), false, "B", 2, "Hücre Bölünmeleri - Soru 2 için Seçenek B", new Guid("c983e23f-dc16-4608-83f4-caf219f635c1") },
                    { new Guid("022f9e3a-b8fd-4662-bffb-33a989c161fc"), false, "D", 4, "Problemler - Soru 4 için Seçenek D", new Guid("874a316b-b698-4b4b-95fa-492afcc48702") },
                    { new Guid("0300b9a0-c365-4a35-aa11-0729b7209a0f"), false, "C", 3, "Kimya Bilimi - Soru 5 için Seçenek C", new Guid("ec7a34ec-7da6-4f97-b2b4-b7a305766dbe") },
                    { new Guid("03f4e5a2-706b-4ed1-a902-a73c6395a9b8"), false, "B", 2, "İş, Güç ve Enerji - Soru 4 için Seçenek B", new Guid("2b22135d-f156-4c29-9e19-09f32fb87aff") },
                    { new Guid("04d30841-2cc8-4ad6-9dc6-a7de8e28d88a"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek D", new Guid("5bf2a380-cd04-4ba5-a758-3feed65fe551") },
                    { new Guid("053931c9-2205-4cb7-adcd-944007dbe94c"), false, "B", 2, "Fizik Bilimine Giriş - Soru 1 için Seçenek B", new Guid("25953dc6-27d2-46db-acf3-152509ffc736") },
                    { new Guid("06482769-e184-4858-a15c-e2cc38354cb8"), false, "A", 1, "Kuvvet ve Hareket - Soru 2 için Seçenek A", new Guid("96f4a0bf-b982-45a5-9e10-55771b562f73") },
                    { new Guid("06c14071-f65c-487d-abb3-e4f4910f354a"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek C", new Guid("b0e0f817-a3d2-4e52-8402-f6c5b2f3a97e") },
                    { new Guid("06d36916-64d6-4164-985e-5dfee19cc889"), true, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek B", new Guid("87cc61ee-3d84-4fdb-9c26-dea768357115") },
                    { new Guid("073cd488-d025-4db0-91c0-c64b6bea4683"), false, "A", 1, "Hücre Bölünmeleri - Soru 2 için Seçenek A", new Guid("c983e23f-dc16-4608-83f4-caf219f635c1") },
                    { new Guid("081b7a4d-51d4-4c4e-beb8-ca8d5f60f3f0"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 2 için Seçenek D", new Guid("60940b98-535b-4fab-9663-9b7d15c6670c") },
                    { new Guid("09cf92a3-e846-487e-b0ff-3a37153cead0"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek A", new Guid("87cc61ee-3d84-4fdb-9c26-dea768357115") },
                    { new Guid("0b26e612-fe68-4794-b334-ad5b785795ed"), false, "A", 1, "Hücre - Soru 3 için Seçenek A", new Guid("dff054d4-bfde-49fb-adf3-b2e1d0eb1610") },
                    { new Guid("0b5c9fff-b117-4915-96c2-3ed5da56e7eb"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek C", new Guid("03e98a56-7841-45f4-b07d-07d699aede00") },
                    { new Guid("0c30fb7a-051e-41c0-b09a-906a2e597b7e"), true, "D", 4, "Temel Kavramlar - Soru 3 için Seçenek D", new Guid("e3fd23d0-22ec-4efb-89db-303d2130ddd5") },
                    { new Guid("0c95b951-cdbd-44b8-a182-c12718e5d3e1"), false, "A", 1, "Kuvvet ve Hareket - Soru 3 için Seçenek A", new Guid("cfd52a72-184d-4294-9f53-b1894bce57f5") },
                    { new Guid("0cf19cbb-4743-4e9b-bd35-f8c3b2ae24e0"), false, "D", 4, "Kalıtım - Soru 2 için Seçenek D", new Guid("7d95f37a-80a7-4275-8814-7a04fdb92254") },
                    { new Guid("0f0d794e-6b02-498e-88a9-d0d713b5c1d1"), false, "A", 1, "Fizik Bilimine Giriş - Soru 1 için Seçenek A", new Guid("25953dc6-27d2-46db-acf3-152509ffc736") },
                    { new Guid("0fe92eb4-cefa-4a6f-b7e4-d3a496d16981"), false, "C", 3, "Kimya Bilimi - Soru 2 için Seçenek C", new Guid("b82e78da-37d7-4ec3-a0e1-486515ee1cc4") },
                    { new Guid("1015d8cd-51d6-4935-94c7-166f2733d7a6"), false, "A", 1, "Kuvvet ve Hareket - Soru 4 için Seçenek A", new Guid("9b1b3dc7-beaf-4cde-9040-b82d977d5370") },
                    { new Guid("10bbf10b-3128-481b-8f0f-e292c3dd0449"), false, "D", 4, "Hücre Bölünmeleri - Soru 4 için Seçenek D", new Guid("3c302787-ec8d-4529-a7c5-ce61d4823c4f") },
                    { new Guid("12094ca1-ec0c-46c6-883d-a32bc3929de3"), false, "D", 4, "Temel Kavramlar - Soru 5 için Seçenek D", new Guid("994089a5-c409-447f-9cc4-98e9c4581290") },
                    { new Guid("126d9e0c-aea7-42d2-a98a-31e7ddc060db"), false, "C", 3, "Hücre Bölünmeleri - Soru 5 için Seçenek C", new Guid("e1c15fd8-3a8f-44ec-af02-c417b63bba07") },
                    { new Guid("126f3d41-ba26-4291-baaa-89c67f5ab682"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 5 için Seçenek C", new Guid("7abddf71-514b-4424-8bd6-7007eb4a6378") },
                    { new Guid("1358c54c-7f14-4449-bd07-48fa09ee7cd5"), false, "C", 3, "İş, Güç ve Enerji - Soru 4 için Seçenek C", new Guid("2b22135d-f156-4c29-9e19-09f32fb87aff") },
                    { new Guid("13944371-32f5-4c9d-9fdc-941253f739e6"), false, "D", 4, "Elektrostatik - Soru 2 için Seçenek D", new Guid("21880a68-508c-4b46-b8e9-69e97596898f") },
                    { new Guid("14f5c9a5-b2c6-4a62-87c7-ff9a13a0db68"), false, "A", 1, "Elektrostatik - Soru 2 için Seçenek A", new Guid("21880a68-508c-4b46-b8e9-69e97596898f") },
                    { new Guid("15594ea7-6afb-456c-98e8-133b107a3e7a"), false, "A", 1, "Temel Kavramlar - Soru 4 için Seçenek A", new Guid("73e503b1-c6d5-4d16-a76c-6ad75743af00") },
                    { new Guid("1562e769-b3a1-4b16-a8fa-6b6911071d81"), false, "D", 4, "Problemler - Soru 2 için Seçenek D", new Guid("8b3995f9-4a90-4557-a64e-298811ffa5b6") },
                    { new Guid("1568cfbf-56d8-4824-8b71-eb2bd91c2ed6"), false, "D", 4, "Rasyonel Sayılar - Soru 2 için Seçenek D", new Guid("957806db-cbe6-4b24-984a-c8be2bad6e90") },
                    { new Guid("16959bbe-6184-4c68-a46b-51f5033464a6"), true, "C", 3, "Kimya Bilimi - Soru 3 için Seçenek C", new Guid("3733dd7f-a924-441e-8efc-274eb40e0f81") },
                    { new Guid("17c1828e-49b7-425b-83d4-09cd0ee4f498"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek D", new Guid("03e98a56-7841-45f4-b07d-07d699aede00") },
                    { new Guid("19a3e275-1d08-4209-849f-8ea4ff30179a"), false, "D", 4, "Sayı Basamakları - Soru 3 için Seçenek D", new Guid("71e8619c-4c33-40ed-8191-cb207d1e2bb6") },
                    { new Guid("1a49acc7-0f16-46eb-832d-35f018d9c008"), true, "D", 4, "Sayı Basamakları - Soru 2 için Seçenek D", new Guid("c58172f4-9b92-4e2a-8564-885024aa9bdc") },
                    { new Guid("1a50bfee-b284-42c0-8809-3e1937a1e82e"), false, "B", 2, "Sayı Basamakları - Soru 3 için Seçenek B", new Guid("71e8619c-4c33-40ed-8191-cb207d1e2bb6") },
                    { new Guid("1a522533-4fc8-472c-b54c-6241bf0c9416"), false, "B", 2, "Rasyonel Sayılar - Soru 3 için Seçenek B", new Guid("a195ec7e-e341-4d0a-9c0f-e612c10733b2") },
                    { new Guid("1b2a669c-1d77-4039-b279-a4226a65945e"), false, "B", 2, "Rasyonel Sayılar - Soru 4 için Seçenek B", new Guid("392f71a1-1c67-4ec0-86ad-227e45e0bee5") },
                    { new Guid("1c57a063-f17a-43ea-b5ef-1422f64b06c0"), false, "B", 2, "Kimya Bilimi - Soru 2 için Seçenek B", new Guid("b82e78da-37d7-4ec3-a0e1-486515ee1cc4") },
                    { new Guid("1cda61c2-3c23-43b0-b7a6-ed92edd86fad"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 5 için Seçenek D", new Guid("03adc41e-0332-46b2-a6b9-8e2a5d5fbde3") },
                    { new Guid("1f3b69c3-8b29-4492-bc09-3c5df31871c0"), false, "B", 2, "Hücre - Soru 4 için Seçenek B", new Guid("55c237bd-4d6c-4c61-b819-90f432067fb5") },
                    { new Guid("1fe5710d-a2e9-4f6e-9f36-2945e9d740a5"), false, "A", 1, "İş, Güç ve Enerji - Soru 4 için Seçenek A", new Guid("2b22135d-f156-4c29-9e19-09f32fb87aff") },
                    { new Guid("206825ad-2fc5-4122-bf6f-dcaf7abe556c"), false, "B", 2, "Madde ve Özellikleri - Soru 2 için Seçenek B", new Guid("64b6621b-cfc1-4be3-80b5-47b205e5968d") },
                    { new Guid("2080bca9-771b-44ff-80b7-640d5e78148c"), false, "D", 4, "Problemler - Soru 3 için Seçenek D", new Guid("e962f3e7-943a-43dd-a1e8-4df9146bfc3d") },
                    { new Guid("21a958ed-fc9f-4c3b-8e68-ef36dce16b17"), true, "B", 2, "Kalıtım - Soru 3 için Seçenek B", new Guid("1f850f00-4f74-4039-8f90-f1270d74e1cf") },
                    { new Guid("22c96aa3-f2f2-41f1-97b7-69d77fa91c2c"), false, "A", 1, "Kuvvet ve Hareket - Soru 5 için Seçenek A", new Guid("1e1b3926-764e-495f-bdb6-03ddb6d7c7bf") },
                    { new Guid("23a27664-b654-44f4-8404-9fce5eb8f8d2"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek D", new Guid("2a741688-ecc6-48cb-93a0-482a4741de3f") },
                    { new Guid("23d12601-d5c9-47d0-b59a-82ab95e579ce"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek A", new Guid("7c6b1554-0525-49ed-8016-5420e0f95176") },
                    { new Guid("24491b6e-a842-4ae3-b782-a38998ca0378"), false, "A", 1, "Maddenin Halleri - Soru 5 için Seçenek A", new Guid("28002858-465a-417b-bfa7-3a72038cd8a6") },
                    { new Guid("24766792-22f8-41a7-9cc1-18142ce64925"), false, "A", 1, "Fizik Bilimine Giriş - Soru 2 için Seçenek A", new Guid("605f0a56-070a-4151-af2d-bdbb9b9be810") },
                    { new Guid("25302b82-8e88-42f7-9466-c54e1a8214d7"), false, "D", 4, "Maddenin Halleri - Soru 3 için Seçenek D", new Guid("aa743add-6dfa-4d6c-b1ef-65402ea03d59") },
                    { new Guid("267483c1-1d07-4673-9dc0-9b6f8286c58b"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek B", new Guid("cfa2bf07-4e6f-4416-98d4-79f4470ae71a") },
                    { new Guid("2912033c-2f12-4f74-9a5f-a3ecd54541b5"), false, "C", 3, "Rasyonel Sayılar - Soru 4 için Seçenek C", new Guid("392f71a1-1c67-4ec0-86ad-227e45e0bee5") },
                    { new Guid("2b52cdc9-854a-4c90-a623-3b4373704d7d"), false, "C", 3, "Elektrostatik - Soru 2 için Seçenek C", new Guid("21880a68-508c-4b46-b8e9-69e97596898f") },
                    { new Guid("2b6b3f8b-96cf-4ad9-a2e8-12a428f4451c"), true, "B", 2, "Hücre - Soru 3 için Seçenek B", new Guid("dff054d4-bfde-49fb-adf3-b2e1d0eb1610") },
                    { new Guid("2c347ab3-a696-4d59-b1cb-4e4b8e259520"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek D", new Guid("30b03c24-5ff2-41c4-92f0-a65ad999b151") },
                    { new Guid("2c671d03-4356-4bc7-989a-13094b6b353a"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek B", new Guid("9cac2c9b-0317-4e60-acbc-da4f0527ce11") },
                    { new Guid("2cb4b0a2-09e6-440e-a344-8da9b5d5d359"), false, "D", 4, "Madde ve Özellikleri - Soru 2 için Seçenek D", new Guid("64b6621b-cfc1-4be3-80b5-47b205e5968d") },
                    { new Guid("2e060b17-b635-44bd-ba26-134f54087b01"), false, "B", 2, "Madde ve Özellikleri - Soru 3 için Seçenek B", new Guid("9be55a0d-09ad-481e-b11e-cce848bf86d8") },
                    { new Guid("2e3c775a-e7dc-41ae-a9fc-69d89840988b"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek C", new Guid("87cc61ee-3d84-4fdb-9c26-dea768357115") },
                    { new Guid("2e721128-27df-431c-a192-ee73a1965e8e"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek A", new Guid("003dfac8-e219-4b3a-9eb6-cb76104e1492") },
                    { new Guid("2e99dc88-4ba6-4f3d-9b6f-ff39cea3aafe"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 4 için Seçenek C", new Guid("bb47c3d2-dc1c-4b5d-aaf6-595bef028bf6") },
                    { new Guid("2f6266a0-92d1-420c-8537-c556e1a07f39"), false, "C", 3, "Sayı Basamakları - Soru 5 için Seçenek C", new Guid("a0e996de-9b39-41bf-9689-fecce472fd7a") },
                    { new Guid("2f6ae8d9-8d08-41f0-bfc4-dd817ff9e1b9"), false, "C", 3, "Problemler - Soru 3 için Seçenek C", new Guid("e962f3e7-943a-43dd-a1e8-4df9146bfc3d") },
                    { new Guid("3137dd61-6523-42ed-8a4d-f39abf5bd44a"), false, "B", 2, "Hücre Bölünmeleri - Soru 3 için Seçenek B", new Guid("89c38696-4e47-486c-b0e4-6b2d84d5f3fc") },
                    { new Guid("313a83ad-5781-4616-82be-bd7383335195"), false, "C", 3, "Rasyonel Sayılar - Soru 1 için Seçenek C", new Guid("7b9c9537-a6b3-4b23-a21c-6b95938ff38a") },
                    { new Guid("325b46fb-67d6-4423-8346-7e6485653362"), true, "A", 1, "Elektrostatik - Soru 3 için Seçenek A", new Guid("f85acec7-f71c-4e30-b854-ce0fb755eef4") },
                    { new Guid("3267313b-30f3-4118-96f1-c7d62db12908"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek C", new Guid("cfa2bf07-4e6f-4416-98d4-79f4470ae71a") },
                    { new Guid("33837580-2c75-44ad-af28-bcb4108982a5"), false, "A", 1, "Temel Kavramlar - Soru 1 için Seçenek A", new Guid("18d203ba-bf99-4be7-8bb7-c38ef6f99e99") },
                    { new Guid("3395f2cc-12e6-4f37-85a1-ced6af3a8b71"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 3 için Seçenek A", new Guid("41a635e5-f01e-46c6-951d-c6bc9848c652") },
                    { new Guid("342358f7-ffa5-4ade-9380-1ccc75a19241"), false, "A", 1, "Elektrostatik - Soru 4 için Seçenek A", new Guid("c5b6cdb9-24a1-4902-b106-42bc7399534b") },
                    { new Guid("3462174d-20b6-44a9-b476-f8fe70fb29bc"), true, "D", 4, "Rasyonel Sayılar - Soru 4 için Seçenek D", new Guid("392f71a1-1c67-4ec0-86ad-227e45e0bee5") },
                    { new Guid("34a87f1d-3eaf-4194-841d-32c233f853da"), false, "C", 3, "Fizik Bilimine Giriş - Soru 4 için Seçenek C", new Guid("7d7d1fd0-07f8-4b0c-8325-093a3e577906") },
                    { new Guid("34efba00-8914-471a-9c20-76532384d941"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek C", new Guid("91ba48ff-55fc-44be-a780-3f8e5fff3b3f") },
                    { new Guid("35c33793-34a0-4745-8e8b-c203e157bfba"), false, "A", 1, "Fizik Bilimine Giriş - Soru 3 için Seçenek A", new Guid("a9ea9bb2-c3fe-4e18-97ee-6c6b8f7b909c") },
                    { new Guid("368638ec-b037-43f9-b1f3-7d4cb6e5f55c"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek B", new Guid("03e98a56-7841-45f4-b07d-07d699aede00") },
                    { new Guid("36b34eec-3be7-48d2-a9a6-ff55a4b02088"), false, "A", 1, "Temel Kavramlar - Soru 3 için Seçenek A", new Guid("e3fd23d0-22ec-4efb-89db-303d2130ddd5") },
                    { new Guid("37053487-db7c-467f-a95f-09824d960e4d"), false, "D", 4, "Kimya Bilimi - Soru 3 için Seçenek D", new Guid("3733dd7f-a924-441e-8efc-274eb40e0f81") },
                    { new Guid("373850c7-85b9-47a8-8e97-48bcec59ad96"), true, "A", 1, "Problemler - Soru 2 için Seçenek A", new Guid("8b3995f9-4a90-4557-a64e-298811ffa5b6") },
                    { new Guid("373ddaa9-5427-4aac-afa9-155a0a79b9ed"), false, "B", 2, "Elektrostatik - Soru 4 için Seçenek B", new Guid("c5b6cdb9-24a1-4902-b106-42bc7399534b") },
                    { new Guid("37404076-a719-4589-94a8-0aed9738617e"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 4 için Seçenek A", new Guid("bb47c3d2-dc1c-4b5d-aaf6-595bef028bf6") },
                    { new Guid("3742977f-316c-4f63-8591-2bfdcf600185"), true, "A", 1, "Kimya Bilimi - Soru 4 için Seçenek A", new Guid("3faaef56-9f97-4651-a80e-2a722a915d28") },
                    { new Guid("37d805f4-10ca-4d21-8d7d-38dae8f6ae5d"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 4 için Seçenek B", new Guid("bb47c3d2-dc1c-4b5d-aaf6-595bef028bf6") },
                    { new Guid("39b568c3-26ef-4ea5-933b-91b813b40fe1"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek A", new Guid("91ba48ff-55fc-44be-a780-3f8e5fff3b3f") },
                    { new Guid("3a024959-e694-44b6-87ad-a83779feaaff"), true, "A", 1, "Hücre Bölünmeleri - Soru 4 için Seçenek A", new Guid("3c302787-ec8d-4529-a7c5-ce61d4823c4f") },
                    { new Guid("3a741acb-b5f6-4bb6-be2b-83a39b16f1d5"), true, "B", 2, "Kuvvet ve Hareket - Soru 3 için Seçenek B", new Guid("cfd52a72-184d-4294-9f53-b1894bce57f5") },
                    { new Guid("3bc84416-d109-4555-87c8-49990f535490"), false, "B", 2, "Temel Kavramlar - Soru 4 için Seçenek B", new Guid("73e503b1-c6d5-4d16-a76c-6ad75743af00") },
                    { new Guid("3d0568ab-d6f0-4020-8355-dee5e7e3804d"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek B", new Guid("91ba48ff-55fc-44be-a780-3f8e5fff3b3f") },
                    { new Guid("3dcc3d2b-b6e9-4c93-bdb1-a3853da280ff"), true, "D", 4, "Hücre Bölünmeleri - Soru 2 için Seçenek D", new Guid("c983e23f-dc16-4608-83f4-caf219f635c1") },
                    { new Guid("3e2bbef6-e260-4ce5-a468-fdbdaaaa5c07"), false, "B", 2, "Problemler - Soru 3 için Seçenek B", new Guid("e962f3e7-943a-43dd-a1e8-4df9146bfc3d") },
                    { new Guid("3e53f546-9efd-4ce6-be4e-1bb39fa6c551"), false, "B", 2, "İş, Güç ve Enerji - Soru 2 için Seçenek B", new Guid("92bcea13-5532-46a5-98de-0e75f45a6b59") },
                    { new Guid("3f3cb476-8810-4759-b721-920c0cf26633"), true, "C", 3, "Madde ve Özellikleri - Soru 5 için Seçenek C", new Guid("95202c6b-63b7-4a5a-bb0f-7581906a16e8") },
                    { new Guid("3f65a1de-301d-4746-9336-2aeba44186d3"), false, "A", 1, "Kalıtım - Soru 3 için Seçenek A", new Guid("1f850f00-4f74-4039-8f90-f1270d74e1cf") },
                    { new Guid("3fa1144b-959a-471e-81ca-642ddf48bff1"), false, "B", 2, "Hücre Bölünmeleri - Soru 4 için Seçenek B", new Guid("3c302787-ec8d-4529-a7c5-ce61d4823c4f") },
                    { new Guid("3ffa002f-3641-4fa4-956b-6916f7492e5c"), true, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek A", new Guid("1c06427a-dc7f-4849-9e67-a10856b039ab") },
                    { new Guid("407629f6-1909-4ba3-a80a-dce4247f5927"), false, "B", 2, "Madde ve Özellikleri - Soru 1 için Seçenek B", new Guid("53e5b503-786e-415d-b17a-8756c8c9a680") },
                    { new Guid("4081f563-048a-4d79-bdd9-c3340d383e02"), false, "A", 1, "Elektrostatik - Soru 5 için Seçenek A", new Guid("02e6f607-8b8a-43a2-b3aa-caa30b7802d9") },
                    { new Guid("4131401b-067b-4757-a045-4a0af22a5bb9"), true, "A", 1, "Madde ve Özellikleri - Soru 2 için Seçenek A", new Guid("64b6621b-cfc1-4be3-80b5-47b205e5968d") },
                    { new Guid("41f8466f-36b6-4d59-8a39-e9efb7c23e3f"), false, "C", 3, "Fizik Bilimine Giriş - Soru 2 için Seçenek C", new Guid("605f0a56-070a-4151-af2d-bdbb9b9be810") },
                    { new Guid("4277b2b3-91e8-4762-ab56-da1b5ad8b071"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 2 için Seçenek B", new Guid("60940b98-535b-4fab-9663-9b7d15c6670c") },
                    { new Guid("428338bb-1c21-47a1-afd3-2be46ab04b0f"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 4 için Seçenek A", new Guid("2dd76c28-9021-4441-bbf8-e296fc826e2a") },
                    { new Guid("43461422-e62f-4551-a7da-b8ca594c182f"), false, "D", 4, "Fizik Bilimine Giriş - Soru 4 için Seçenek D", new Guid("7d7d1fd0-07f8-4b0c-8325-093a3e577906") },
                    { new Guid("43884c18-06f9-4671-9cdb-189137bdb3fc"), false, "D", 4, "Bölme ve Bölünebilme - Soru 2 için Seçenek D", new Guid("1202a873-23eb-4ca1-90b3-7987ee911752") },
                    { new Guid("443bf8b0-80be-48c8-94bb-eebcb663109a"), false, "D", 4, "İş, Güç ve Enerji - Soru 5 için Seçenek D", new Guid("b64cb03b-5c9b-4247-a02b-90a69dece5bc") },
                    { new Guid("444d6ff1-470f-45df-9f54-baa230a6ecc8"), true, "B", 2, "Temel Kavramlar - Soru 1 için Seçenek B", new Guid("18d203ba-bf99-4be7-8bb7-c38ef6f99e99") },
                    { new Guid("45015b57-6976-460c-b7dd-8efb26ba924c"), false, "C", 3, "Maddenin Halleri - Soru 5 için Seçenek C", new Guid("28002858-465a-417b-bfa7-3a72038cd8a6") },
                    { new Guid("4503f523-d596-44df-aac8-205c150c3a55"), false, "D", 4, "Kimya Bilimi - Soru 1 için Seçenek D", new Guid("a859809a-5720-4d9a-a5fe-9e5986391703") },
                    { new Guid("46016809-f658-4484-b62f-6771ccc1b043"), false, "A", 1, "Bölme ve Bölünebilme - Soru 2 için Seçenek A", new Guid("1202a873-23eb-4ca1-90b3-7987ee911752") },
                    { new Guid("47f40cb5-9786-408a-8690-47e98ed50084"), true, "A", 1, "Problemler - Soru 5 için Seçenek A", new Guid("6153cdd5-27a9-4d11-a834-419ba59efb1d") },
                    { new Guid("49265595-e09d-42d9-ab20-8be4d632ad45"), false, "D", 4, "Hücre Bölünmeleri - Soru 1 için Seçenek D", new Guid("1c6b18a9-9524-49cf-9033-b29c50e5d383") },
                    { new Guid("49e895b7-42eb-4f5a-9118-66928ef39c46"), false, "B", 2, "Problemler - Soru 2 için Seçenek B", new Guid("8b3995f9-4a90-4557-a64e-298811ffa5b6") },
                    { new Guid("49f9d151-5145-4d88-b53b-1f66d863a458"), false, "B", 2, "Hücre Bölünmeleri - Soru 1 için Seçenek B", new Guid("1c6b18a9-9524-49cf-9033-b29c50e5d383") },
                    { new Guid("4a5498df-1ff7-4429-9dc3-bc9e30615b6c"), true, "A", 1, "Hücre - Soru 1 için Seçenek A", new Guid("f7659659-5021-4e61-81a4-c8190a649d9f") },
                    { new Guid("4bf360fe-6355-496b-bbbd-c90255ed8a8f"), false, "B", 2, "Kimya Bilimi - Soru 4 için Seçenek B", new Guid("3faaef56-9f97-4651-a80e-2a722a915d28") },
                    { new Guid("4c11b7f7-e2d9-4ade-ac80-22558f995ff4"), true, "C", 3, "Kuvvet ve Hareket - Soru 2 için Seçenek C", new Guid("96f4a0bf-b982-45a5-9e10-55771b562f73") },
                    { new Guid("4c4e0293-4f38-4fab-bc85-3380de10efde"), true, "C", 3, "Temel Kavramlar - Soru 2 için Seçenek C", new Guid("76515146-e41b-4f4f-bf2f-4253febf5911") },
                    { new Guid("4c767163-3167-4f03-b697-9fa7bf8bc54b"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek D", new Guid("b0e0f817-a3d2-4e52-8402-f6c5b2f3a97e") },
                    { new Guid("4ccfd929-9320-4b4b-92e3-d74dc104a980"), false, "A", 1, "Problemler - Soru 4 için Seçenek A", new Guid("874a316b-b698-4b4b-95fa-492afcc48702") },
                    { new Guid("4ef4d708-d4c8-41c0-aed7-3c54bd3027c3"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek B", new Guid("1c06427a-dc7f-4849-9e67-a10856b039ab") },
                    { new Guid("4f0a5959-a8ea-4cfb-8622-408c4dd1562b"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek D", new Guid("cfa2bf07-4e6f-4416-98d4-79f4470ae71a") },
                    { new Guid("50af5659-b667-46f7-b26e-514f02a71a66"), false, "B", 2, "Rasyonel Sayılar - Soru 1 için Seçenek B", new Guid("7b9c9537-a6b3-4b23-a21c-6b95938ff38a") },
                    { new Guid("50e1eecc-0a46-4282-b7b7-2ad80d3c8e1e"), false, "C", 3, "Maddenin Halleri - Soru 3 için Seçenek C", new Guid("aa743add-6dfa-4d6c-b1ef-65402ea03d59") },
                    { new Guid("517e1428-6150-499e-a7f9-e04353b8f337"), false, "B", 2, "Madde ve Özellikleri - Soru 4 için Seçenek B", new Guid("06bd1a8e-5569-4a61-92a3-bd4c80266f7e") },
                    { new Guid("523a4974-3eb4-48ad-a9ff-2b0baae2178b"), false, "C", 3, "Hücre Bölünmeleri - Soru 1 için Seçenek C", new Guid("1c6b18a9-9524-49cf-9033-b29c50e5d383") },
                    { new Guid("52628e87-ac4e-4332-81a9-25618a26464e"), false, "B", 2, "Fizik Bilimine Giriş - Soru 5 için Seçenek B", new Guid("b30ce0c8-830c-471c-891f-5ce8b24965dd") },
                    { new Guid("52ff3d84-4e94-4898-ba73-f3cf05f76cb0"), true, "B", 2, "Kalıtım - Soru 2 için Seçenek B", new Guid("7d95f37a-80a7-4275-8814-7a04fdb92254") },
                    { new Guid("533f833b-1629-4816-86f3-6850722c0ecd"), false, "A", 1, "Hücre Bölünmeleri - Soru 3 için Seçenek A", new Guid("89c38696-4e47-486c-b0e4-6b2d84d5f3fc") },
                    { new Guid("534efa4f-2dbc-44e6-a68e-d9153a36376f"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 1 için Seçenek A", new Guid("408fd400-a4f0-46c4-963a-c57129bc26d3") },
                    { new Guid("537e049b-3ee4-4c1e-81aa-6d8d7a74c1fd"), false, "C", 3, "Sayı Basamakları - Soru 4 için Seçenek C", new Guid("23b4e4d9-2530-4dac-a9b6-dd5d48e785b0") },
                    { new Guid("546b1126-fd1c-4fcf-a09f-d7c724bd1cb1"), false, "D", 4, "Problemler - Soru 5 için Seçenek D", new Guid("6153cdd5-27a9-4d11-a834-419ba59efb1d") },
                    { new Guid("5485cb42-c0ac-4992-8d0c-c824498a0996"), false, "A", 1, "Kalıtım - Soru 5 için Seçenek A", new Guid("199ef779-16ad-4e64-a1e3-bb499cad8e25") },
                    { new Guid("56aed079-8ea0-4591-9b54-397344aea59d"), false, "B", 2, "Fizik Bilimine Giriş - Soru 4 için Seçenek B", new Guid("7d7d1fd0-07f8-4b0c-8325-093a3e577906") },
                    { new Guid("56dae429-8b6a-45a0-b38d-07f97bfa7015"), false, "B", 2, "Problemler - Soru 5 için Seçenek B", new Guid("6153cdd5-27a9-4d11-a834-419ba59efb1d") },
                    { new Guid("570163af-ffd2-4b78-b86d-ca74db8620e6"), false, "C", 3, "Fizik Bilimine Giriş - Soru 1 için Seçenek C", new Guid("25953dc6-27d2-46db-acf3-152509ffc736") },
                    { new Guid("57938552-4e56-401b-a099-70829b657018"), true, "A", 1, "Atom ve Periyodik Sistem - Soru 5 için Seçenek A", new Guid("7abddf71-514b-4424-8bd6-7007eb4a6378") },
                    { new Guid("58077536-1ee0-474d-b4ed-ec88750024df"), false, "B", 2, "Sayı Basamakları - Soru 2 için Seçenek B", new Guid("c58172f4-9b92-4e2a-8564-885024aa9bdc") },
                    { new Guid("58738e47-1cc2-4905-a4cd-e71b8b899faa"), true, "D", 4, "Fizik Bilimine Giriş - Soru 3 için Seçenek D", new Guid("a9ea9bb2-c3fe-4e18-97ee-6c6b8f7b909c") },
                    { new Guid("58b113f0-d4d5-4f05-8e64-e52e173b6610"), false, "C", 3, "Problemler - Soru 2 için Seçenek C", new Guid("8b3995f9-4a90-4557-a64e-298811ffa5b6") },
                    { new Guid("59296341-4141-4874-bcd1-8ad57339bc9f"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 3 için Seçenek D", new Guid("41a635e5-f01e-46c6-951d-c6bc9848c652") },
                    { new Guid("5bb60872-081f-4047-a343-0ae0d9448c7b"), false, "B", 2, "Kimya Bilimi - Soru 3 için Seçenek B", new Guid("3733dd7f-a924-441e-8efc-274eb40e0f81") },
                    { new Guid("5c1f8b96-2ce6-4e2c-bc61-4d21e7d7d9e3"), false, "B", 2, "Kalıtım - Soru 1 için Seçenek B", new Guid("6d438930-6ae4-4f8a-a2fd-778d7b0775c2") },
                    { new Guid("5caeff65-c8ab-4ffc-afe1-71025e33830c"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek A", new Guid("9cac2c9b-0317-4e60-acbc-da4f0527ce11") },
                    { new Guid("5ebd399b-ff69-4498-90a6-5ca8c2944b1c"), false, "C", 3, "Hücre - Soru 3 için Seçenek C", new Guid("dff054d4-bfde-49fb-adf3-b2e1d0eb1610") },
                    { new Guid("5f1a675b-a113-45d9-88dd-47b1d9b966f0"), false, "D", 4, "Hücre - Soru 4 için Seçenek D", new Guid("55c237bd-4d6c-4c61-b819-90f432067fb5") },
                    { new Guid("5ff52d2c-75fa-4eb9-a1c8-a6f7b7b9920c"), false, "B", 2, "Kuvvet ve Hareket - Soru 2 için Seçenek B", new Guid("96f4a0bf-b982-45a5-9e10-55771b562f73") },
                    { new Guid("60331146-40d4-4728-bdfd-03f7fa7e1e20"), true, "D", 4, "Temel Kavramlar - Soru 4 için Seçenek D", new Guid("73e503b1-c6d5-4d16-a76c-6ad75743af00") },
                    { new Guid("60880a50-54d9-498f-9cde-b25a604faace"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 2 için Seçenek D", new Guid("de2f121c-e0dd-4f61-82d6-1aee68263d83") },
                    { new Guid("60b1680c-872e-4bd9-abfe-02e38721dcfe"), false, "D", 4, "Madde ve Özellikleri - Soru 5 için Seçenek D", new Guid("95202c6b-63b7-4a5a-bb0f-7581906a16e8") },
                    { new Guid("60bf1451-1cc5-435c-84ca-84a05690bdad"), true, "D", 4, "Kalıtım - Soru 5 için Seçenek D", new Guid("199ef779-16ad-4e64-a1e3-bb499cad8e25") },
                    { new Guid("60f2ceb0-473a-4e91-8912-2a760a8dddcd"), false, "A", 1, "Rasyonel Sayılar - Soru 4 için Seçenek A", new Guid("392f71a1-1c67-4ec0-86ad-227e45e0bee5") },
                    { new Guid("61975e56-4771-4580-b08e-5e7177ce2881"), false, "A", 1, "Maddenin Halleri - Soru 2 için Seçenek A", new Guid("4a636af9-c040-4ae1-95b0-025e142f9f7f") },
                    { new Guid("61dd97ff-54a2-4df7-be21-43e4b216753c"), false, "A", 1, "İş, Güç ve Enerji - Soru 1 için Seçenek A", new Guid("497aec3f-a50d-4ea3-bf7c-d40ae715ca5b") },
                    { new Guid("620f6af0-78cb-4ff5-b954-1aa7870ad69e"), true, "D", 4, "Hücre Bölünmeleri - Soru 3 için Seçenek D", new Guid("89c38696-4e47-486c-b0e4-6b2d84d5f3fc") },
                    { new Guid("627ed86e-e732-4d60-b19e-f54a72ca90ca"), false, "D", 4, "Kuvvet ve Hareket - Soru 5 için Seçenek D", new Guid("1e1b3926-764e-495f-bdb6-03ddb6d7c7bf") },
                    { new Guid("637259d4-becf-447f-9388-1b921afd2676"), false, "B", 2, "Maddenin Halleri - Soru 1 için Seçenek B", new Guid("c02d5253-9ab6-4618-b155-75d4ac0c0182") },
                    { new Guid("63991b1d-d547-453d-a083-95ad747cb8c5"), false, "D", 4, "Temel Kavramlar - Soru 2 için Seçenek D", new Guid("76515146-e41b-4f4f-bf2f-4253febf5911") },
                    { new Guid("64d1d3a2-cb6d-4cc9-b765-e618b264a3c1"), false, "D", 4, "Maddenin Halleri - Soru 1 için Seçenek D", new Guid("c02d5253-9ab6-4618-b155-75d4ac0c0182") },
                    { new Guid("659b94a7-8569-4d2e-83f9-0e08efd3ff22"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 3 için Seçenek C", new Guid("345b8a1b-411a-46f7-874b-5e495468ee9d") },
                    { new Guid("66349aa4-b057-4ae0-b3dc-2b2d7b091b27"), true, "B", 2, "Temel Kavramlar - Soru 5 için Seçenek B", new Guid("994089a5-c409-447f-9cc4-98e9c4581290") },
                    { new Guid("6647712a-6b8b-4137-95ba-8591f6f9b1a7"), true, "B", 2, "Problemler - Soru 4 için Seçenek B", new Guid("874a316b-b698-4b4b-95fa-492afcc48702") },
                    { new Guid("66ccda6a-73a2-42a0-8373-047bc08da705"), false, "D", 4, "Kuvvet ve Hareket - Soru 4 için Seçenek D", new Guid("9b1b3dc7-beaf-4cde-9040-b82d977d5370") },
                    { new Guid("674cab12-6079-46f3-8d7d-3f76f97723e8"), false, "C", 3, "Temel Kavramlar - Soru 3 için Seçenek C", new Guid("e3fd23d0-22ec-4efb-89db-303d2130ddd5") },
                    { new Guid("6787b0b0-4834-4097-ac41-0d126a3df249"), false, "D", 4, "İş, Güç ve Enerji - Soru 3 için Seçenek D", new Guid("b06e41d9-c68e-46f1-af6b-3d619ab9ca4a") },
                    { new Guid("691fd76b-99ff-4962-a088-67219e2ed2b8"), true, "B", 2, "İş, Güç ve Enerji - Soru 5 için Seçenek B", new Guid("b64cb03b-5c9b-4247-a02b-90a69dece5bc") },
                    { new Guid("6929269a-c9b9-490d-b53f-490d7c14a145"), true, "A", 1, "Kalıtım - Soru 1 için Seçenek A", new Guid("6d438930-6ae4-4f8a-a2fd-778d7b0775c2") },
                    { new Guid("69885633-6519-49eb-9c10-1d486b2c71b9"), true, "C", 3, "Elektrostatik - Soru 1 için Seçenek C", new Guid("527ec67a-8698-436d-a363-42a6122ca448") },
                    { new Guid("6a1f3da5-3cfb-492e-b304-d18703e39ff1"), true, "A", 1, "Hücre Bölünmeleri - Soru 1 için Seçenek A", new Guid("1c6b18a9-9524-49cf-9033-b29c50e5d383") },
                    { new Guid("6a21f8c4-1201-4507-9323-110e5e6ab69c"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 4 için Seçenek D", new Guid("2dd76c28-9021-4441-bbf8-e296fc826e2a") },
                    { new Guid("6a87631b-6179-44bb-b86a-8bc1f715ac3a"), false, "C", 3, "Bölme ve Bölünebilme - Soru 1 için Seçenek C", new Guid("062a784f-4baf-4140-91d1-1ab886f68c0f") },
                    { new Guid("6ad78ff6-2f73-43db-a235-00ac58eb8340"), true, "A", 1, "Fizik Bilimine Giriş - Soru 4 için Seçenek A", new Guid("7d7d1fd0-07f8-4b0c-8325-093a3e577906") },
                    { new Guid("6af938b5-dae2-4c6f-a315-da9171c71e73"), false, "C", 3, "Kalıtım - Soru 4 için Seçenek C", new Guid("99246c1b-b094-4a3a-83eb-e7e225f55134") },
                    { new Guid("6b6f0321-d4a1-4198-94f7-2eca92cc538f"), false, "D", 4, "Temel Kavramlar - Soru 1 için Seçenek D", new Guid("18d203ba-bf99-4be7-8bb7-c38ef6f99e99") },
                    { new Guid("6c9329e6-f894-4a17-b1f5-8f8dfb227195"), true, "A", 1, "Hücre - Soru 2 için Seçenek A", new Guid("8c3df66f-aef3-4986-8cc8-93b4c3090e44") },
                    { new Guid("6cd4a3c9-92d8-4c5e-9836-ef421efd7e6a"), false, "D", 4, "Kalıtım - Soru 4 için Seçenek D", new Guid("99246c1b-b094-4a3a-83eb-e7e225f55134") },
                    { new Guid("6cf913b7-3681-48c9-9395-ac0d510680ef"), false, "B", 2, "Rasyonel Sayılar - Soru 5 için Seçenek B", new Guid("495d2ec6-e940-4040-9bc1-89a4807156cd") },
                    { new Guid("6d3642e8-815a-4213-bb16-11e76fe86d45"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 2 için Seçenek C", new Guid("60940b98-535b-4fab-9663-9b7d15c6670c") },
                    { new Guid("6f457deb-0e9e-45d4-ac85-fdd5092b539b"), false, "A", 1, "Sayı Basamakları - Soru 5 için Seçenek A", new Guid("a0e996de-9b39-41bf-9689-fecce472fd7a") },
                    { new Guid("6f7a2a91-b2f1-4336-baaa-4d9ec9ef0881"), false, "C", 3, "Kuvvet ve Hareket - Soru 1 için Seçenek C", new Guid("84ca6a0b-0d63-4a8a-be9f-1faa3759bd05") },
                    { new Guid("6f871433-b01a-4fb2-97cd-097abadb1f98"), false, "D", 4, "Problemler - Soru 1 için Seçenek D", new Guid("e9ebb795-ef4f-412f-a8dd-f0c2d0dc335c") },
                    { new Guid("6f92497e-213b-4741-99ca-9368377ad78b"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek C", new Guid("5bf2a380-cd04-4ba5-a758-3feed65fe551") },
                    { new Guid("70164150-d493-4f57-a43c-8ef49134be12"), false, "B", 2, "Problemler - Soru 1 için Seçenek B", new Guid("e9ebb795-ef4f-412f-a8dd-f0c2d0dc335c") },
                    { new Guid("71278b31-75bc-4d7b-90ba-4d570aa7896e"), true, "A", 1, "Hücre Bölünmeleri - Soru 5 için Seçenek A", new Guid("e1c15fd8-3a8f-44ec-af02-c417b63bba07") },
                    { new Guid("716c9410-59e6-4268-a811-73973079c186"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek C", new Guid("47bbd168-a4f9-4e56-a387-92c939b267b8") },
                    { new Guid("7283b67f-92f0-4cc2-9152-3c07c03e16de"), false, "C", 3, "Problemler - Soru 5 için Seçenek C", new Guid("6153cdd5-27a9-4d11-a834-419ba59efb1d") },
                    { new Guid("72b10e20-e2ae-4271-9a3e-f4cb3296f73a"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek C", new Guid("0f92b22f-6510-4b8d-9135-82302d726865") },
                    { new Guid("731021a5-7f30-458a-adec-7d141bfa72d9"), false, "A", 1, "Kimya Bilimi - Soru 3 için Seçenek A", new Guid("3733dd7f-a924-441e-8efc-274eb40e0f81") },
                    { new Guid("76e8603b-4c92-4d7e-83bf-e7a7e0a14ec2"), false, "D", 4, "Sayı Basamakları - Soru 1 için Seçenek D", new Guid("f9b41ecd-86d3-4d58-8b25-92251cd4ac5f") },
                    { new Guid("77451ac4-5957-4de8-a544-1ea306c2e89d"), false, "C", 3, "Kuvvet ve Hareket - Soru 3 için Seçenek C", new Guid("cfd52a72-184d-4294-9f53-b1894bce57f5") },
                    { new Guid("780f03b1-cafd-41ff-a1cc-cf43a5fc5bc9"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 4 için Seçenek B", new Guid("2dd76c28-9021-4441-bbf8-e296fc826e2a") },
                    { new Guid("782c65e5-4b55-4c07-846e-9c9ec0b8f623"), true, "A", 1, "Problemler - Soru 3 için Seçenek A", new Guid("e962f3e7-943a-43dd-a1e8-4df9146bfc3d") },
                    { new Guid("799b9bbb-bac6-4b19-9bb9-8e23b761305e"), false, "C", 3, "Kimya Bilimi - Soru 4 için Seçenek C", new Guid("3faaef56-9f97-4651-a80e-2a722a915d28") },
                    { new Guid("79e84090-ef23-4be2-9a69-0815a6c6b388"), false, "C", 3, "Bölme ve Bölünebilme - Soru 2 için Seçenek C", new Guid("1202a873-23eb-4ca1-90b3-7987ee911752") },
                    { new Guid("7ad9ad62-26b2-492d-b444-2e7dcc8fae9e"), false, "B", 2, "Kalıtım - Soru 4 için Seçenek B", new Guid("99246c1b-b094-4a3a-83eb-e7e225f55134") },
                    { new Guid("7b11ae41-3117-4beb-b942-31fdeda298f9"), false, "B", 2, "Kimya Bilimi - Soru 5 için Seçenek B", new Guid("ec7a34ec-7da6-4f97-b2b4-b7a305766dbe") },
                    { new Guid("7d051744-8037-4b17-8929-40bdf0330ddb"), false, "A", 1, "Kuvvet ve Hareket - Soru 1 için Seçenek A", new Guid("84ca6a0b-0d63-4a8a-be9f-1faa3759bd05") },
                    { new Guid("7f35c496-405b-421f-be2f-9f3474f1ccee"), false, "B", 2, "İş, Güç ve Enerji - Soru 1 için Seçenek B", new Guid("497aec3f-a50d-4ea3-bf7c-d40ae715ca5b") },
                    { new Guid("7f8756e2-4f28-4cec-978d-cdc438ab56bd"), false, "B", 2, "Hücre - Soru 2 için Seçenek B", new Guid("8c3df66f-aef3-4986-8cc8-93b4c3090e44") },
                    { new Guid("802af956-3e3c-410a-874c-3b3b01db6c52"), false, "B", 2, "Hücre Bölünmeleri - Soru 5 için Seçenek B", new Guid("e1c15fd8-3a8f-44ec-af02-c417b63bba07") },
                    { new Guid("80f3a3d6-ec73-43cf-a8ca-3f713669f0ab"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 5 için Seçenek D", new Guid("7abddf71-514b-4424-8bd6-7007eb4a6378") },
                    { new Guid("80ffa1f9-4308-44c9-a844-5e40807958b7"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 4 için Seçenek D", new Guid("bb47c3d2-dc1c-4b5d-aaf6-595bef028bf6") },
                    { new Guid("8106ca5e-28ed-498f-8edc-f28319cdbec8"), true, "A", 1, "Maddenin Halleri - Soru 1 için Seçenek A", new Guid("c02d5253-9ab6-4618-b155-75d4ac0c0182") },
                    { new Guid("8281e0f5-e699-4e01-a1c9-8a000283cd31"), true, "D", 4, "Fizik Bilimine Giriş - Soru 2 için Seçenek D", new Guid("605f0a56-070a-4151-af2d-bdbb9b9be810") },
                    { new Guid("82844d1a-d529-4718-951b-b24110ee1733"), false, "C", 3, "Hücre Bölünmeleri - Soru 4 için Seçenek C", new Guid("3c302787-ec8d-4529-a7c5-ce61d4823c4f") },
                    { new Guid("82b5abce-9684-4192-ac3d-a919ecfb03eb"), false, "D", 4, "Maddenin Halleri - Soru 4 için Seçenek D", new Guid("a886e878-83df-425d-a358-a88f8ef3a4db") },
                    { new Guid("82f99d58-5fe8-46c0-97cf-530b1c63db08"), true, "B", 2, "Hücre - Soru 5 için Seçenek B", new Guid("96ac416a-2cd8-4c3b-9f9a-122353e62104") },
                    { new Guid("831e96d1-09db-4159-ae49-cda050a8ae09"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek C", new Guid("1c06427a-dc7f-4849-9e67-a10856b039ab") },
                    { new Guid("832b0508-87ae-475e-995a-33ecc32f1255"), false, "D", 4, "Fizik Bilimine Giriş - Soru 5 için Seçenek D", new Guid("b30ce0c8-830c-471c-891f-5ce8b24965dd") },
                    { new Guid("8420ff27-d181-4527-9198-c83d2ede8a27"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek D", new Guid("0f92b22f-6510-4b8d-9135-82302d726865") },
                    { new Guid("842e7971-58e7-4efc-a7ac-4b4875ee716b"), true, "C", 3, "Maddenin Halleri - Soru 2 için Seçenek C", new Guid("4a636af9-c040-4ae1-95b0-025e142f9f7f") },
                    { new Guid("84407608-778d-4c28-a97c-9e10eded5287"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek A", new Guid("03e98a56-7841-45f4-b07d-07d699aede00") },
                    { new Guid("84c16bd7-bd6b-405c-82eb-90b41918e65f"), false, "C", 3, "Kuvvet ve Hareket - Soru 5 için Seçenek C", new Guid("1e1b3926-764e-495f-bdb6-03ddb6d7c7bf") },
                    { new Guid("8532707b-64d5-4d69-a9ca-71ba4d54fe66"), true, "B", 2, "Sayı Basamakları - Soru 4 için Seçenek B", new Guid("23b4e4d9-2530-4dac-a9b6-dd5d48e785b0") },
                    { new Guid("8621d541-8bb5-4b34-8dd6-32796d612c42"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek D", new Guid("7c6b1554-0525-49ed-8016-5420e0f95176") },
                    { new Guid("868286d1-db37-4ac2-941d-eed98bba435c"), false, "D", 4, "Sayı Basamakları - Soru 4 için Seçenek D", new Guid("23b4e4d9-2530-4dac-a9b6-dd5d48e785b0") },
                    { new Guid("86ab0843-279d-47e8-afb6-afb9588edf83"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 3 için Seçenek D", new Guid("345b8a1b-411a-46f7-874b-5e495468ee9d") },
                    { new Guid("88ac65f9-27c1-4c74-8166-724ac3e46679"), false, "C", 3, "Hücre - Soru 5 için Seçenek C", new Guid("96ac416a-2cd8-4c3b-9f9a-122353e62104") },
                    { new Guid("88ea2ac3-4393-4ec3-96e7-410e1ca72a44"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 1 için Seçenek B", new Guid("2f24a948-46b8-469e-a612-922a2df4f1a3") },
                    { new Guid("8990200e-fea4-48b6-99b9-638ff968b250"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek D", new Guid("003dfac8-e219-4b3a-9eb6-cb76104e1492") },
                    { new Guid("8a6bf80c-c1dc-4008-ab3f-567ebfc60168"), true, "A", 1, "Bölme ve Bölünebilme - Soru 4 için Seçenek A", new Guid("79160525-70da-4a07-b0a6-7a80351e5ce8") },
                    { new Guid("8a78b55a-326c-495d-a0aa-dfe4a27b6a7a"), false, "C", 3, "Hücre - Soru 4 için Seçenek C", new Guid("55c237bd-4d6c-4c61-b819-90f432067fb5") },
                    { new Guid("8ac0cd02-79a9-41f6-a3ad-c012afe20517"), false, "A", 1, "Rasyonel Sayılar - Soru 1 için Seçenek A", new Guid("7b9c9537-a6b3-4b23-a21c-6b95938ff38a") },
                    { new Guid("8ad71be5-bb40-4747-8d76-c5e7017ca4a7"), false, "D", 4, "Elektrostatik - Soru 4 için Seçenek D", new Guid("c5b6cdb9-24a1-4902-b106-42bc7399534b") },
                    { new Guid("8b3d59cf-1fff-4b6f-b3a9-900bd302f308"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek D", new Guid("47bbd168-a4f9-4e56-a387-92c939b267b8") },
                    { new Guid("8b555f75-c593-4ca8-8c17-41678c4c398f"), true, "A", 1, "Kalıtım - Soru 4 için Seçenek A", new Guid("99246c1b-b094-4a3a-83eb-e7e225f55134") },
                    { new Guid("8cd822b4-0526-4894-bafb-007d2a47d41f"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek D", new Guid("91ba48ff-55fc-44be-a780-3f8e5fff3b3f") },
                    { new Guid("8f6fca3b-e349-4fee-9604-c98893642a24"), false, "D", 4, "Maddenin Halleri - Soru 2 için Seçenek D", new Guid("4a636af9-c040-4ae1-95b0-025e142f9f7f") },
                    { new Guid("8fd7cad8-a532-49fc-8bab-7daf3be8288a"), true, "C", 3, "Kuvvet ve Hareket - Soru 4 için Seçenek C", new Guid("9b1b3dc7-beaf-4cde-9040-b82d977d5370") },
                    { new Guid("907f2d04-23dc-49d4-84fd-ab428b5aafb9"), false, "D", 4, "Madde ve Özellikleri - Soru 4 için Seçenek D", new Guid("06bd1a8e-5569-4a61-92a3-bd4c80266f7e") },
                    { new Guid("90f6d0d4-ae6d-4a7b-b44a-2af3535b460a"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek D", new Guid("3162e81e-ad16-4374-968f-a2abaa8733f9") },
                    { new Guid("9286deaf-775d-4e83-98b2-407475375ae9"), false, "B", 2, "Kalıtım - Soru 5 için Seçenek B", new Guid("199ef779-16ad-4e64-a1e3-bb499cad8e25") },
                    { new Guid("929011e9-9092-4861-9595-534c78d3449e"), false, "A", 1, "Bölme ve Bölünebilme - Soru 5 için Seçenek A", new Guid("31327bd2-4b4d-4be6-831d-6a18ee884399") },
                    { new Guid("9295e034-d575-48c2-895f-f97cc2603e65"), false, "A", 1, "Madde ve Özellikleri - Soru 3 için Seçenek A", new Guid("9be55a0d-09ad-481e-b11e-cce848bf86d8") },
                    { new Guid("958c80c8-3073-41f6-996b-15ea7753de41"), false, "A", 1, "Madde ve Özellikleri - Soru 1 için Seçenek A", new Guid("53e5b503-786e-415d-b17a-8756c8c9a680") },
                    { new Guid("962153f5-a375-4075-b7d4-5629fd8e0212"), false, "C", 3, "Sayı Basamakları - Soru 2 için Seçenek C", new Guid("c58172f4-9b92-4e2a-8564-885024aa9bdc") },
                    { new Guid("964b6a4f-a6d7-47a9-a9ca-5f30cd0aed16"), false, "C", 3, "Bölme ve Bölünebilme - Soru 4 için Seçenek C", new Guid("79160525-70da-4a07-b0a6-7a80351e5ce8") },
                    { new Guid("969d1ce7-ef4b-47e2-ae96-6e321dca510b"), false, "D", 4, "Sayı Basamakları - Soru 5 için Seçenek D", new Guid("a0e996de-9b39-41bf-9689-fecce472fd7a") },
                    { new Guid("970d5153-8d87-45ab-b497-86483871d05d"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 5 için Seçenek B", new Guid("7abddf71-514b-4424-8bd6-7007eb4a6378") },
                    { new Guid("971c64f9-2b38-43d4-b7e1-4b6a34a8e049"), true, "A", 1, "Kimya Bilimi - Soru 5 için Seçenek A", new Guid("ec7a34ec-7da6-4f97-b2b4-b7a305766dbe") },
                    { new Guid("97578efc-d1e0-4472-8723-d05933c4be46"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 5 için Seçenek B", new Guid("03adc41e-0332-46b2-a6b9-8e2a5d5fbde3") },
                    { new Guid("980c8f5c-d3fb-4e94-aa0d-cb7b04d211d1"), true, "D", 4, "Madde ve Özellikleri - Soru 3 için Seçenek D", new Guid("9be55a0d-09ad-481e-b11e-cce848bf86d8") },
                    { new Guid("98345be2-28d9-482a-8881-1211de412c9a"), false, "B", 2, "Kuvvet ve Hareket - Soru 4 için Seçenek B", new Guid("9b1b3dc7-beaf-4cde-9040-b82d977d5370") },
                    { new Guid("9848bb95-9827-4925-a287-399306d6f065"), true, "B", 2, "Bölme ve Bölünebilme - Soru 5 için Seçenek B", new Guid("31327bd2-4b4d-4be6-831d-6a18ee884399") },
                    { new Guid("987d7eee-f5d1-4ccd-a220-3ef191242c75"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 1 için Seçenek D", new Guid("2f24a948-46b8-469e-a612-922a2df4f1a3") },
                    { new Guid("99392b2f-c1bb-4e18-bc15-739ceb50ceb9"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek C", new Guid("7c6b1554-0525-49ed-8016-5420e0f95176") },
                    { new Guid("9a66598e-47cd-460c-b7da-e25675857f66"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek B", new Guid("3162e81e-ad16-4374-968f-a2abaa8733f9") },
                    { new Guid("9abc559c-f6ea-441e-8b5a-24b3873477cc"), false, "D", 4, "Bölme ve Bölünebilme - Soru 3 için Seçenek D", new Guid("6a3a8811-4a55-4b7b-bcaf-4eeb71e8c55f") },
                    { new Guid("9b0e8300-8ecb-4771-a111-1b9eb36ba6b6"), false, "B", 2, "Fizik Bilimine Giriş - Soru 3 için Seçenek B", new Guid("a9ea9bb2-c3fe-4e18-97ee-6c6b8f7b909c") },
                    { new Guid("9b79a94d-0d1b-482d-b6b0-269aaf9dea5f"), false, "A", 1, "Madde ve Özellikleri - Soru 5 için Seçenek A", new Guid("95202c6b-63b7-4a5a-bb0f-7581906a16e8") },
                    { new Guid("9c73cae4-1b8e-440a-8f6d-73fd66c8032c"), false, "D", 4, "Kuvvet ve Hareket - Soru 2 için Seçenek D", new Guid("96f4a0bf-b982-45a5-9e10-55771b562f73") },
                    { new Guid("9d7cbb52-d44f-4546-982f-5399deb7ddc4"), false, "A", 1, "İş, Güç ve Enerji - Soru 5 için Seçenek A", new Guid("b64cb03b-5c9b-4247-a02b-90a69dece5bc") },
                    { new Guid("9dab50bc-a53c-4328-8125-e214d00eb294"), false, "D", 4, "Kalıtım - Soru 3 için Seçenek D", new Guid("1f850f00-4f74-4039-8f90-f1270d74e1cf") },
                    { new Guid("9ee3a276-bad1-47cf-9fbb-c9efd7c2ad40"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek C", new Guid("9cac2c9b-0317-4e60-acbc-da4f0527ce11") },
                    { new Guid("a0b1ebe3-64f9-490f-b727-95d724c26a26"), true, "A", 1, "Atom ve Periyodik Sistem - Soru 1 için Seçenek A", new Guid("2f24a948-46b8-469e-a612-922a2df4f1a3") },
                    { new Guid("a11e196d-b9bb-47c7-ac5b-3f80a437c37d"), true, "B", 2, "Kuvvet ve Hareket - Soru 5 için Seçenek B", new Guid("1e1b3926-764e-495f-bdb6-03ddb6d7c7bf") },
                    { new Guid("a12fcf4b-28af-4c7a-8ea7-42cca56f2d95"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 3 için Seçenek B", new Guid("345b8a1b-411a-46f7-874b-5e495468ee9d") },
                    { new Guid("a14b2cd5-beb8-46ce-aa18-0a675b7a8d85"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 1 için Seçenek C", new Guid("408fd400-a4f0-46c4-963a-c57129bc26d3") },
                    { new Guid("a2fc65da-73e2-40e8-b096-6d711d22abea"), false, "C", 3, "Hücre - Soru 2 için Seçenek C", new Guid("8c3df66f-aef3-4986-8cc8-93b4c3090e44") },
                    { new Guid("a31a1607-ec31-46b1-a038-ffb70ce51b24"), false, "B", 2, "İş, Güç ve Enerji - Soru 3 için Seçenek B", new Guid("b06e41d9-c68e-46f1-af6b-3d619ab9ca4a") },
                    { new Guid("a40a3e46-ed2d-45ee-9713-63f031e65101"), false, "D", 4, "Kuvvet ve Hareket - Soru 3 için Seçenek D", new Guid("cfd52a72-184d-4294-9f53-b1894bce57f5") },
                    { new Guid("a608c7e0-7385-4a5f-adb1-528dc916663f"), true, "A", 1, "Hücre - Soru 4 için Seçenek A", new Guid("55c237bd-4d6c-4c61-b819-90f432067fb5") },
                    { new Guid("a7d3784b-f92b-43aa-9039-3f8c02e292b9"), true, "D", 4, "Rasyonel Sayılar - Soru 5 için Seçenek D", new Guid("495d2ec6-e940-4040-9bc1-89a4807156cd") },
                    { new Guid("a883600a-381a-406a-b1bb-5741ad241872"), false, "C", 3, "Maddenin Halleri - Soru 1 için Seçenek C", new Guid("c02d5253-9ab6-4618-b155-75d4ac0c0182") },
                    { new Guid("a8de0e34-d220-4f63-a470-c04627400040"), false, "C", 3, "Bölme ve Bölünebilme - Soru 5 için Seçenek C", new Guid("31327bd2-4b4d-4be6-831d-6a18ee884399") },
                    { new Guid("a9240360-a3ec-40d9-a1e5-1cda8a14983f"), false, "C", 3, "Kalıtım - Soru 2 için Seçenek C", new Guid("7d95f37a-80a7-4275-8814-7a04fdb92254") },
                    { new Guid("a92641d1-a69b-4a7f-a8c5-b571bff9e623"), true, "A", 1, "Sayı Basamakları - Soru 3 için Seçenek A", new Guid("71e8619c-4c33-40ed-8191-cb207d1e2bb6") },
                    { new Guid("a9367c80-672d-48fc-974a-9fe3dfe5612c"), false, "D", 4, "Kalıtım - Soru 1 için Seçenek D", new Guid("6d438930-6ae4-4f8a-a2fd-778d7b0775c2") },
                    { new Guid("a9609779-bf87-4e06-952e-713bcebaa03f"), false, "A", 1, "Problemler - Soru 1 için Seçenek A", new Guid("e9ebb795-ef4f-412f-a8dd-f0c2d0dc335c") },
                    { new Guid("a9f2eefd-5c80-485e-8e87-fb3b6a7ffde7"), false, "D", 4, "İş, Güç ve Enerji - Soru 2 için Seçenek D", new Guid("92bcea13-5532-46a5-98de-0e75f45a6b59") },
                    { new Guid("aa320686-5e3b-432d-ba5e-fd19b6e36699"), false, "C", 3, "Problemler - Soru 4 için Seçenek C", new Guid("874a316b-b698-4b4b-95fa-492afcc48702") },
                    { new Guid("abb700f0-b062-4611-a090-321a899778b7"), false, "A", 1, "Elektrostatik - Soru 1 için Seçenek A", new Guid("527ec67a-8698-436d-a363-42a6122ca448") },
                    { new Guid("abc328ec-b397-440c-ab47-65d3dc380770"), true, "A", 1, "Sayı Basamakları - Soru 1 için Seçenek A", new Guid("f9b41ecd-86d3-4d58-8b25-92251cd4ac5f") },
                    { new Guid("ac545ebf-cb0c-4039-9810-27fcde674214"), false, "C", 3, "Kalıtım - Soru 3 için Seçenek C", new Guid("1f850f00-4f74-4039-8f90-f1270d74e1cf") },
                    { new Guid("ac8707d6-1345-47e0-b909-b18d22670542"), false, "C", 3, "Kalıtım - Soru 5 için Seçenek C", new Guid("199ef779-16ad-4e64-a1e3-bb499cad8e25") },
                    { new Guid("acc13840-ab32-481d-9ccd-02a6d2cbd323"), false, "A", 1, "Kalıtım - Soru 2 için Seçenek A", new Guid("7d95f37a-80a7-4275-8814-7a04fdb92254") },
                    { new Guid("ad528d18-41b6-41db-937a-d27cade1ea6d"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek B", new Guid("2a741688-ecc6-48cb-93a0-482a4741de3f") },
                    { new Guid("ae0c7fe9-9aa6-4c1c-80fe-9fe456e62fbd"), false, "C", 3, "Elektrostatik - Soru 5 için Seçenek C", new Guid("02e6f607-8b8a-43a2-b3aa-caa30b7802d9") },
                    { new Guid("af11bc12-e15a-4c38-9cee-88d494ba0777"), false, "D", 4, "Hücre - Soru 1 için Seçenek D", new Guid("f7659659-5021-4e61-81a4-c8190a649d9f") },
                    { new Guid("b11924d4-e535-446e-896a-c5ead52048c3"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek A", new Guid("47bbd168-a4f9-4e56-a387-92c939b267b8") },
                    { new Guid("b160f5fb-b740-4bfc-99bb-884d5eb5f059"), true, "C", 3, "Bölme ve Bölünebilme - Soru 3 için Seçenek C", new Guid("6a3a8811-4a55-4b7b-bcaf-4eeb71e8c55f") },
                    { new Guid("b1ba559b-925c-4f56-a264-cfd3607cc01b"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 4 için Seçenek C", new Guid("2dd76c28-9021-4441-bbf8-e296fc826e2a") },
                    { new Guid("b2e9be95-e255-4182-8da3-7b5682548320"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek D", new Guid("87cc61ee-3d84-4fdb-9c26-dea768357115") },
                    { new Guid("b3891bc4-63d2-481f-8da5-0c55d82dcb55"), false, "B", 2, "Maddenin Halleri - Soru 2 için Seçenek B", new Guid("4a636af9-c040-4ae1-95b0-025e142f9f7f") },
                    { new Guid("b44a6d59-bfb5-4c36-b8ea-fadf07807af9"), false, "A", 1, "Maddenin Halleri - Soru 4 için Seçenek A", new Guid("a886e878-83df-425d-a358-a88f8ef3a4db") },
                    { new Guid("b500e486-aee9-4ad0-9e23-6c5412418d02"), false, "D", 4, "Kimya Bilimi - Soru 4 için Seçenek D", new Guid("3faaef56-9f97-4651-a80e-2a722a915d28") },
                    { new Guid("b72a43a2-7fc2-4662-844e-7f64a7630501"), false, "A", 1, "Rasyonel Sayılar - Soru 5 için Seçenek A", new Guid("495d2ec6-e940-4040-9bc1-89a4807156cd") },
                    { new Guid("b89e8565-769b-4a1f-a6d8-e92b246d4c7d"), false, "D", 4, "Maddenin Halleri - Soru 5 için Seçenek D", new Guid("28002858-465a-417b-bfa7-3a72038cd8a6") },
                    { new Guid("b972adfa-be09-4672-8ca7-ad88aa5c265c"), false, "B", 2, "Bölme ve Bölünebilme - Soru 3 için Seçenek B", new Guid("6a3a8811-4a55-4b7b-bcaf-4eeb71e8c55f") },
                    { new Guid("b99e1d56-fb63-48d6-823f-e9c32cf4b9be"), false, "C", 3, "İş, Güç ve Enerji - Soru 5 için Seçenek C", new Guid("b64cb03b-5c9b-4247-a02b-90a69dece5bc") },
                    { new Guid("b9becf91-4219-4dcf-b973-e9155eb8e9cd"), false, "D", 4, "Kimya Bilimi - Soru 2 için Seçenek D", new Guid("b82e78da-37d7-4ec3-a0e1-486515ee1cc4") },
                    { new Guid("ba22a997-4b3e-43a2-9eed-eb9e747885bd"), false, "D", 4, "Bölme ve Bölünebilme - Soru 1 için Seçenek D", new Guid("062a784f-4baf-4140-91d1-1ab886f68c0f") },
                    { new Guid("be16da43-82c6-4788-82a2-11c6e80f9add"), false, "C", 3, "Sayı Basamakları - Soru 1 için Seçenek C", new Guid("f9b41ecd-86d3-4d58-8b25-92251cd4ac5f") },
                    { new Guid("bea42d09-4d62-47a3-8d1e-865784ec8d5a"), false, "D", 4, "Hücre Bölünmeleri - Soru 5 için Seçenek D", new Guid("e1c15fd8-3a8f-44ec-af02-c417b63bba07") },
                    { new Guid("beb787ea-ef95-48cd-8d62-ab1d50de9be6"), false, "D", 4, "Kimya Bilimi - Soru 5 için Seçenek D", new Guid("ec7a34ec-7da6-4f97-b2b4-b7a305766dbe") },
                    { new Guid("bef26f10-2fdc-475d-9fe3-e5f8ae158084"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek A", new Guid("3162e81e-ad16-4374-968f-a2abaa8733f9") },
                    { new Guid("bf1cdf8e-9ee2-44f5-88ef-e7f0e7fad655"), false, "C", 3, "Hücre Bölünmeleri - Soru 3 için Seçenek C", new Guid("89c38696-4e47-486c-b0e4-6b2d84d5f3fc") },
                    { new Guid("bfcb52d4-2b7d-475e-8867-0947d739c649"), false, "C", 3, "Madde ve Özellikleri - Soru 1 için Seçenek C", new Guid("53e5b503-786e-415d-b17a-8756c8c9a680") },
                    { new Guid("c3a7db72-1e5b-4546-92e9-099a74f15855"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 5 için Seçenek A", new Guid("03adc41e-0332-46b2-a6b9-8e2a5d5fbde3") },
                    { new Guid("c468e0fd-1249-4946-b688-4f9b30e3dbb0"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 3 için Seçenek A", new Guid("345b8a1b-411a-46f7-874b-5e495468ee9d") },
                    { new Guid("c4facfd5-6cdb-48fc-9ffb-e063f1031a12"), false, "D", 4, "Hücre - Soru 2 için Seçenek D", new Guid("8c3df66f-aef3-4986-8cc8-93b4c3090e44") },
                    { new Guid("c5124a5e-ce04-4d14-8d49-8680c89ca78a"), false, "D", 4, "Rasyonel Sayılar - Soru 3 için Seçenek D", new Guid("a195ec7e-e341-4d0a-9c0f-e612c10733b2") },
                    { new Guid("c572c0b2-0f8c-4028-abc7-93e4c6ca8dbe"), false, "A", 1, "Sayı Basamakları - Soru 4 için Seçenek A", new Guid("23b4e4d9-2530-4dac-a9b6-dd5d48e785b0") },
                    { new Guid("c58c6eb1-6bdb-4029-89a3-c9f199c88fb0"), true, "C", 3, "Madde ve Özellikleri - Soru 4 için Seçenek C", new Guid("06bd1a8e-5569-4a61-92a3-bd4c80266f7e") },
                    { new Guid("c62502c2-62dc-4415-a0e9-3ea13ef6251a"), false, "C", 3, "Temel Kavramlar - Soru 1 için Seçenek C", new Guid("18d203ba-bf99-4be7-8bb7-c38ef6f99e99") },
                    { new Guid("c6b95aa9-a1e2-4ed1-8fd4-2ca8044d335c"), true, "D", 4, "İş, Güç ve Enerji - Soru 4 için Seçenek D", new Guid("2b22135d-f156-4c29-9e19-09f32fb87aff") },
                    { new Guid("c7154e0e-5a7c-4ce8-9411-be43106a0d99"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek D", new Guid("9cac2c9b-0317-4e60-acbc-da4f0527ce11") },
                    { new Guid("c786e86f-2ead-4f6b-a9cf-3d337c52dd82"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek B", new Guid("5bf2a380-cd04-4ba5-a758-3feed65fe551") },
                    { new Guid("c7d28b1b-1cbb-4b47-9b9e-278b7e81b2bf"), false, "C", 3, "Kimya Bilimi - Soru 1 için Seçenek C", new Guid("a859809a-5720-4d9a-a5fe-9e5986391703") },
                    { new Guid("c8b08476-ea88-4f62-9546-464e82228ac8"), true, "D", 4, "Rasyonel Sayılar - Soru 1 için Seçenek D", new Guid("7b9c9537-a6b3-4b23-a21c-6b95938ff38a") },
                    { new Guid("ca33d58c-2469-41dc-addb-d75274b6c983"), false, "C", 3, "Temel Kavramlar - Soru 5 için Seçenek C", new Guid("994089a5-c409-447f-9cc4-98e9c4581290") },
                    { new Guid("ca8b43ea-88bc-47c0-8075-6af012eb5a47"), false, "B", 2, "Elektrostatik - Soru 1 için Seçenek B", new Guid("527ec67a-8698-436d-a363-42a6122ca448") },
                    { new Guid("cafb3072-d340-4df1-b884-44ef01509fb5"), false, "A", 1, "Kimya Bilimi - Soru 1 için Seçenek A", new Guid("a859809a-5720-4d9a-a5fe-9e5986391703") },
                    { new Guid("cb3008e6-dc6e-4d0c-8abe-addfc0432684"), false, "B", 2, "Hücre - Soru 1 için Seçenek B", new Guid("f7659659-5021-4e61-81a4-c8190a649d9f") },
                    { new Guid("cd6391b4-1e1c-4af4-b01c-d3fcdcd1941e"), false, "B", 2, "Bölme ve Bölünebilme - Soru 4 için Seçenek B", new Guid("79160525-70da-4a07-b0a6-7a80351e5ce8") },
                    { new Guid("cd7abde3-e424-4c04-abaa-1bfaaadcfc5b"), true, "C", 3, "Rasyonel Sayılar - Soru 3 için Seçenek C", new Guid("a195ec7e-e341-4d0a-9c0f-e612c10733b2") },
                    { new Guid("cdcbb977-717d-4dc7-838e-a5b4143c0bc0"), false, "A", 1, "Temel Kavramlar - Soru 5 için Seçenek A", new Guid("994089a5-c409-447f-9cc4-98e9c4581290") },
                    { new Guid("cdecaa19-15cf-4f25-bb44-0e88f3afa61e"), true, "B", 2, "Bölme ve Bölünebilme - Soru 1 için Seçenek B", new Guid("062a784f-4baf-4140-91d1-1ab886f68c0f") },
                    { new Guid("cea05214-52ce-47f0-9aa6-7b0894d093b1"), true, "A", 1, "İş, Güç ve Enerji - Soru 3 için Seçenek A", new Guid("b06e41d9-c68e-46f1-af6b-3d619ab9ca4a") },
                    { new Guid("cf97d35b-9a16-46b5-b707-311b83b81bae"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek C", new Guid("30b03c24-5ff2-41c4-92f0-a65ad999b151") },
                    { new Guid("cfc887a9-50ff-4f31-bc06-bd3ecf6c2f0c"), true, "A", 1, "Kimya Bilimi - Soru 2 için Seçenek A", new Guid("b82e78da-37d7-4ec3-a0e1-486515ee1cc4") },
                    { new Guid("d0cce8c7-0e3c-474a-a9bb-85eaf51be106"), false, "A", 1, "Rasyonel Sayılar - Soru 3 için Seçenek A", new Guid("a195ec7e-e341-4d0a-9c0f-e612c10733b2") },
                    { new Guid("d119cb47-c4c7-48f7-a081-c4431d4a141d"), false, "C", 3, "Rasyonel Sayılar - Soru 5 için Seçenek C", new Guid("495d2ec6-e940-4040-9bc1-89a4807156cd") },
                    { new Guid("d15ccc25-e77d-479c-b00d-f43d1d587f09"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek A", new Guid("b0e0f817-a3d2-4e52-8402-f6c5b2f3a97e") },
                    { new Guid("d1e2322b-3501-4434-86fe-871c2adeaf1e"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 3 için Seçenek B", new Guid("41a635e5-f01e-46c6-951d-c6bc9848c652") },
                    { new Guid("d2538ed1-ac9d-4d0f-b415-4c19f71c7b99"), false, "C", 3, "Kalıtım - Soru 1 için Seçenek C", new Guid("6d438930-6ae4-4f8a-a2fd-778d7b0775c2") },
                    { new Guid("d2c30e05-7d2f-4f1e-89ff-dcc96d032054"), false, "C", 3, "Elektrostatik - Soru 3 için Seçenek C", new Guid("f85acec7-f71c-4e30-b854-ce0fb755eef4") },
                    { new Guid("d2ee5c16-a908-4e94-bd05-4c7e6f6fac95"), true, "D", 4, "Kuvvet ve Hareket - Soru 1 için Seçenek D", new Guid("84ca6a0b-0d63-4a8a-be9f-1faa3759bd05") },
                    { new Guid("d315956e-c19e-4610-8a27-7b31c66ba2dc"), false, "D", 4, "Bölme ve Bölünebilme - Soru 4 için Seçenek D", new Guid("79160525-70da-4a07-b0a6-7a80351e5ce8") },
                    { new Guid("d3b224a4-7be5-41ae-a890-7f7c21c56b32"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek A", new Guid("30b03c24-5ff2-41c4-92f0-a65ad999b151") },
                    { new Guid("d45494f9-62c1-42f9-82f8-f04083069d51"), false, "B", 2, "Temel Kavramlar - Soru 3 için Seçenek B", new Guid("e3fd23d0-22ec-4efb-89db-303d2130ddd5") },
                    { new Guid("d4e69dd2-4a5a-48a0-b2ea-16b6b2b5da97"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek B", new Guid("b0e0f817-a3d2-4e52-8402-f6c5b2f3a97e") },
                    { new Guid("d614a269-34c9-4c9e-bc5e-9d5638815c92"), false, "C", 3, "Fizik Bilimine Giriş - Soru 3 için Seçenek C", new Guid("a9ea9bb2-c3fe-4e18-97ee-6c6b8f7b909c") },
                    { new Guid("d63c9b50-334b-4eb7-bdd4-b759ff3780c8"), true, "D", 4, "Madde ve Özellikleri - Soru 1 için Seçenek D", new Guid("53e5b503-786e-415d-b17a-8756c8c9a680") },
                    { new Guid("d71e8ce7-a02d-418e-bcb5-c4560ea6cb1f"), false, "A", 1, "Fizik Bilimine Giriş - Soru 5 için Seçenek A", new Guid("b30ce0c8-830c-471c-891f-5ce8b24965dd") },
                    { new Guid("d7660213-d09f-490c-adfb-1c50911e8319"), false, "A", 1, "Temel Kavramlar - Soru 2 için Seçenek A", new Guid("76515146-e41b-4f4f-bf2f-4253febf5911") },
                    { new Guid("d7da7818-965c-4ccb-8709-0c8d35c186a0"), true, "D", 4, "İş, Güç ve Enerji - Soru 1 için Seçenek D", new Guid("497aec3f-a50d-4ea3-bf7c-d40ae715ca5b") },
                    { new Guid("d82731c0-4cdd-4b9a-bef7-bebf4de4a5c0"), true, "A", 1, "Maddenin Halleri - Soru 3 için Seçenek A", new Guid("aa743add-6dfa-4d6c-b1ef-65402ea03d59") },
                    { new Guid("d88453e3-1f58-4cc4-b224-d1ad03b46ed2"), true, "C", 3, "Fizik Bilimine Giriş - Soru 5 için Seçenek C", new Guid("b30ce0c8-830c-471c-891f-5ce8b24965dd") },
                    { new Guid("d90671e4-227b-41e9-88da-393b9090a6e0"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 1 için Seçenek C", new Guid("2f24a948-46b8-469e-a612-922a2df4f1a3") },
                    { new Guid("d97c0964-fbdb-4bdd-aaed-9a5943302a06"), true, "B", 2, "Sayı Basamakları - Soru 5 için Seçenek B", new Guid("a0e996de-9b39-41bf-9689-fecce472fd7a") },
                    { new Guid("d9d95390-e0d4-44dd-bb2b-2ebe60f10e78"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 2 için Seçenek C", new Guid("de2f121c-e0dd-4f61-82d6-1aee68263d83") },
                    { new Guid("db70876c-d09d-4ff8-91fd-dd92af15e479"), false, "B", 2, "Elektrostatik - Soru 5 için Seçenek B", new Guid("02e6f607-8b8a-43a2-b3aa-caa30b7802d9") },
                    { new Guid("dbf0e28b-0c1a-45ac-8cc1-b2e034874b9d"), false, "C", 3, "Madde ve Özellikleri - Soru 2 için Seçenek C", new Guid("64b6621b-cfc1-4be3-80b5-47b205e5968d") },
                    { new Guid("dc67754d-a55c-4593-b31d-7dbb23862933"), false, "D", 4, "Hücre - Soru 5 için Seçenek D", new Guid("96ac416a-2cd8-4c3b-9f9a-122353e62104") },
                    { new Guid("dcdc6816-ed33-490b-9359-1f1b609a8759"), false, "C", 3, "Sayı Basamakları - Soru 3 için Seçenek C", new Guid("71e8619c-4c33-40ed-8191-cb207d1e2bb6") },
                    { new Guid("dd3db0cd-b12a-47a7-abe2-0157ed6604b3"), false, "C", 3, "Madde ve Özellikleri - Soru 3 için Seçenek C", new Guid("9be55a0d-09ad-481e-b11e-cce848bf86d8") },
                    { new Guid("de098311-2a77-4972-ae8e-d45c0588f157"), false, "C", 3, "İş, Güç ve Enerji - Soru 3 için Seçenek C", new Guid("b06e41d9-c68e-46f1-af6b-3d619ab9ca4a") },
                    { new Guid("de345754-a6b1-432e-a5af-527e5c2f6a81"), false, "A", 1, "Bölme ve Bölünebilme - Soru 1 için Seçenek A", new Guid("062a784f-4baf-4140-91d1-1ab886f68c0f") },
                    { new Guid("de34c0eb-d44e-40ea-ba80-f59f68ebbed1"), true, "A", 1, "Canlıların Sınıflandırılması - Soru 2 için Seçenek A", new Guid("60940b98-535b-4fab-9663-9b7d15c6670c") },
                    { new Guid("de5ed490-b053-4c65-82f9-cc61ae91071f"), true, "C", 3, "İş, Güç ve Enerji - Soru 2 için Seçenek C", new Guid("92bcea13-5532-46a5-98de-0e75f45a6b59") },
                    { new Guid("df81df20-503e-4f19-81c9-07256c7190d6"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek C", new Guid("3162e81e-ad16-4374-968f-a2abaa8733f9") },
                    { new Guid("e0725e70-33c2-407e-9f1a-e354ccdb2579"), false, "A", 1, "İş, Güç ve Enerji - Soru 2 için Seçenek A", new Guid("92bcea13-5532-46a5-98de-0e75f45a6b59") },
                    { new Guid("e0a9763a-a509-4aec-8c09-d0b1f1990a1c"), true, "B", 2, "Canlıların Sınıflandırılması - Soru 1 için Seçenek B", new Guid("408fd400-a4f0-46c4-963a-c57129bc26d3") },
                    { new Guid("e0bf6c89-b98a-4275-8776-37fe94ea807c"), false, "B", 2, "Sayı Basamakları - Soru 1 için Seçenek B", new Guid("f9b41ecd-86d3-4d58-8b25-92251cd4ac5f") },
                    { new Guid("e1b1dba3-b7e3-4886-a4e0-0488c842db9f"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 2 için Seçenek B", new Guid("de2f121c-e0dd-4f61-82d6-1aee68263d83") },
                    { new Guid("e2ceeb15-6a36-463b-9c11-eb9b039f4ade"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek A", new Guid("cfa2bf07-4e6f-4416-98d4-79f4470ae71a") },
                    { new Guid("e3e25c4a-0a8f-49e5-a8b5-01bf8f6cfc1d"), false, "B", 2, "Maddenin Halleri - Soru 3 için Seçenek B", new Guid("aa743add-6dfa-4d6c-b1ef-65402ea03d59") },
                    { new Guid("e4e9763a-253a-46fd-b215-a806ad60d50f"), false, "D", 4, "Bölme ve Bölünebilme - Soru 5 için Seçenek D", new Guid("31327bd2-4b4d-4be6-831d-6a18ee884399") },
                    { new Guid("e51a08fd-3867-4713-8f99-67e34d1f0c26"), false, "C", 3, "İş, Güç ve Enerji - Soru 1 için Seçenek C", new Guid("497aec3f-a50d-4ea3-bf7c-d40ae715ca5b") },
                    { new Guid("e51b0df0-9d09-4c85-8834-221c028d2019"), true, "B", 2, "Maddenin Halleri - Soru 4 için Seçenek B", new Guid("a886e878-83df-425d-a358-a88f8ef3a4db") },
                    { new Guid("e57afbc1-da50-4a04-ad84-341d8ef93109"), false, "D", 4, "Hücre - Soru 3 için Seçenek D", new Guid("dff054d4-bfde-49fb-adf3-b2e1d0eb1610") },
                    { new Guid("e5aac283-86f1-40f1-810c-4269975b38b4"), false, "B", 2, "Rasyonel Sayılar - Soru 2 için Seçenek B", new Guid("957806db-cbe6-4b24-984a-c8be2bad6e90") },
                    { new Guid("e66769cd-de2f-48a2-b268-05378452343d"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek A", new Guid("0f92b22f-6510-4b8d-9135-82302d726865") },
                    { new Guid("e694a4a3-2d2d-436f-b7eb-b19e71f511e0"), false, "A", 1, "Bölme ve Bölünebilme - Soru 3 için Seçenek A", new Guid("6a3a8811-4a55-4b7b-bcaf-4eeb71e8c55f") },
                    { new Guid("e6c132d1-8332-4f6c-a64a-ea0ba4251fc5"), false, "B", 2, "Elektrostatik - Soru 3 için Seçenek B", new Guid("f85acec7-f71c-4e30-b854-ce0fb755eef4") },
                    { new Guid("e73c30f9-d948-4e85-99a2-da6874a88a46"), false, "A", 1, "Sayı Basamakları - Soru 2 için Seçenek A", new Guid("c58172f4-9b92-4e2a-8564-885024aa9bdc") },
                    { new Guid("e7a477a7-f94c-4799-8874-4320e9bfe790"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek A", new Guid("5bf2a380-cd04-4ba5-a758-3feed65fe551") },
                    { new Guid("e8ef2b2e-7400-4a4c-a721-40ecfc80de96"), true, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek B", new Guid("003dfac8-e219-4b3a-9eb6-cb76104e1492") },
                    { new Guid("ea2c9bfd-e55a-4f7a-aca4-c7db5af80266"), true, "C", 3, "Elektrostatik - Soru 4 için Seçenek C", new Guid("c5b6cdb9-24a1-4902-b106-42bc7399534b") },
                    { new Guid("ec297dad-396b-42ae-adb0-763c60fc88c4"), true, "C", 3, "Problemler - Soru 1 için Seçenek C", new Guid("e9ebb795-ef4f-412f-a8dd-f0c2d0dc335c") },
                    { new Guid("ecdb996f-ffdc-42e7-8023-fb0d3414bbb9"), true, "D", 4, "Elektrostatik - Soru 5 için Seçenek D", new Guid("02e6f607-8b8a-43a2-b3aa-caa30b7802d9") },
                    { new Guid("ece03aee-2332-4d10-aead-0d6f4bf8a621"), false, "C", 3, "Temel Kavramlar - Soru 4 için Seçenek C", new Guid("73e503b1-c6d5-4d16-a76c-6ad75743af00") },
                    { new Guid("ecf1776d-7422-4cd0-8072-b42593fd7ef5"), false, "C", 3, "Hücre Bölünmeleri - Soru 2 için Seçenek C", new Guid("c983e23f-dc16-4608-83f4-caf219f635c1") },
                    { new Guid("ee2b2e8c-c897-4f6b-8fd4-b90c1ebf739f"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek B", new Guid("7c6b1554-0525-49ed-8016-5420e0f95176") },
                    { new Guid("efa1c83e-315f-4f71-b328-4f2c385b506e"), true, "B", 2, "Maddenin Halleri - Soru 5 için Seçenek B", new Guid("28002858-465a-417b-bfa7-3a72038cd8a6") },
                    { new Guid("efcc0486-6c7c-4284-a77f-f4ac5652a67a"), true, "C", 3, "Rasyonel Sayılar - Soru 2 için Seçenek C", new Guid("957806db-cbe6-4b24-984a-c8be2bad6e90") },
                    { new Guid("effa390e-3bbf-4bc4-b762-8e7217be5cea"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 3 için Seçenek C", new Guid("41a635e5-f01e-46c6-951d-c6bc9848c652") },
                    { new Guid("f069e0ac-e0c2-4f62-b8de-5712ab74fc23"), false, "D", 4, "Elektrostatik - Soru 1 için Seçenek D", new Guid("527ec67a-8698-436d-a363-42a6122ca448") },
                    { new Guid("f08a1ee8-369c-4977-ab72-b66fc9c56746"), false, "C", 3, "Hücre - Soru 1 için Seçenek C", new Guid("f7659659-5021-4e61-81a4-c8190a649d9f") },
                    { new Guid("f16202c9-48d9-4e50-81d4-32b5f9e9c232"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek B", new Guid("47bbd168-a4f9-4e56-a387-92c939b267b8") },
                    { new Guid("f1ca6b9f-b391-4712-bfbb-002bb24cffde"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek B", new Guid("30b03c24-5ff2-41c4-92f0-a65ad999b151") },
                    { new Guid("f1f9df75-639f-4e0f-a5bd-d75bddfe0118"), false, "D", 4, "Elektrostatik - Soru 3 için Seçenek D", new Guid("f85acec7-f71c-4e30-b854-ce0fb755eef4") },
                    { new Guid("f21ca447-2349-48c9-b763-06050032a274"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek B", new Guid("0f92b22f-6510-4b8d-9135-82302d726865") },
                    { new Guid("f2205e5d-9090-499b-a8f8-a35424e3f52c"), true, "B", 2, "Bölme ve Bölünebilme - Soru 2 için Seçenek B", new Guid("1202a873-23eb-4ca1-90b3-7987ee911752") },
                    { new Guid("f30c85f3-d51f-487f-a213-84a934964b09"), true, "B", 2, "Kimya Bilimi - Soru 1 için Seçenek B", new Guid("a859809a-5720-4d9a-a5fe-9e5986391703") },
                    { new Guid("f3322122-e934-45a9-a66a-c1e6dffe1d30"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek A", new Guid("2a741688-ecc6-48cb-93a0-482a4741de3f") },
                    { new Guid("f36d8e83-497e-4145-beba-f6d3c05f40f3"), true, "B", 2, "Elektrostatik - Soru 2 için Seçenek B", new Guid("21880a68-508c-4b46-b8e9-69e97596898f") },
                    { new Guid("f374a669-8745-4b4f-bda5-47297d365031"), false, "B", 2, "Kuvvet ve Hareket - Soru 1 için Seçenek B", new Guid("84ca6a0b-0d63-4a8a-be9f-1faa3759bd05") },
                    { new Guid("f427607a-bca5-4883-97e7-0dfe011585f8"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 1 için Seçenek D", new Guid("408fd400-a4f0-46c4-963a-c57129bc26d3") },
                    { new Guid("f5a21749-8ab1-4ff4-902e-b9ff35a9e3e3"), false, "A", 1, "Hücre - Soru 5 için Seçenek A", new Guid("96ac416a-2cd8-4c3b-9f9a-122353e62104") },
                    { new Guid("f7dbd8ea-c675-4e4b-8a8d-96426ecc01da"), false, "B", 2, "Temel Kavramlar - Soru 2 için Seçenek B", new Guid("76515146-e41b-4f4f-bf2f-4253febf5911") },
                    { new Guid("faa4069b-a793-4c63-ab5b-ac4378b77cc8"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek C", new Guid("2a741688-ecc6-48cb-93a0-482a4741de3f") },
                    { new Guid("fadac885-ca05-4115-9479-c05277411fdb"), false, "A", 1, "Madde ve Özellikleri - Soru 4 için Seçenek A", new Guid("06bd1a8e-5569-4a61-92a3-bd4c80266f7e") },
                    { new Guid("fb819aed-d111-48ea-b4cb-1107524771fe"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 5 için Seçenek C", new Guid("03adc41e-0332-46b2-a6b9-8e2a5d5fbde3") },
                    { new Guid("fb8813fb-4e67-45e8-9991-7abe598a6c04"), false, "B", 2, "Fizik Bilimine Giriş - Soru 2 için Seçenek B", new Guid("605f0a56-070a-4151-af2d-bdbb9b9be810") },
                    { new Guid("fd4cdc92-4aa8-47f9-bc43-798226a9d72f"), true, "D", 4, "Fizik Bilimine Giriş - Soru 1 için Seçenek D", new Guid("25953dc6-27d2-46db-acf3-152509ffc736") },
                    { new Guid("fe0630e5-47ec-4691-9fab-be941515587c"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek D", new Guid("1c06427a-dc7f-4849-9e67-a10856b039ab") },
                    { new Guid("fe26f3c1-7ff2-4c23-b4d8-0ae88dbf7b35"), false, "B", 2, "Madde ve Özellikleri - Soru 5 için Seçenek B", new Guid("95202c6b-63b7-4a5a-bb0f-7581906a16e8") },
                    { new Guid("ff66535e-cdd3-4795-af46-c718aa360b47"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek C", new Guid("003dfac8-e219-4b3a-9eb6-cb76104e1492") }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ParentTopicId", "SubjectId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("01de30cb-f870-4d1a-b4f0-6028afc1c143"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(444), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Yaşam Bilimi Biyoloji" },
                    { new Guid("09dee641-f9a9-4c28-8015-c9eb79dbac5f"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(446), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre" },
                    { new Guid("0c8d687f-2587-4494-9e5a-ee46655c21cd"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(450), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre Bölünmeleri" },
                    { new Guid("388f36b2-f016-4133-b42c-c41229181e07"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(407), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Elektrostatik" },
                    { new Guid("4b0250a6-9fc8-4167-86dd-0218e6aabbe8"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(375), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Temel Kavramlar" },
                    { new Guid("4ccb86e8-df53-436a-af24-eb056571282f"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(452), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Kalıtım" },
                    { new Guid("575f6632-8899-49a2-b225-1d31a30231d1"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(391), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Rasyonel Sayılar" },
                    { new Guid("5e5c6311-80c3-4625-b7e3-05da5dbb15c0"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(436), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Atom ve Periyodik Sistem" },
                    { new Guid("7b3885a6-88cc-42a2-a1d2-9a61dbb8a920"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(439), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Maddenin Halleri" },
                    { new Guid("888ccd3c-517f-45e5-9004-97ab0de47e54"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(402), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Kuvvet ve Hareket" },
                    { new Guid("91fed905-0c66-47ff-a53f-6be108c434fc"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(398), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Fizik Bilimine Giriş" },
                    { new Guid("a784ddf8-afd5-40d5-a124-77e91a706b80"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(400), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Madde ve Özellikleri" },
                    { new Guid("aec0d6bf-bb76-4a00-b496-ca392ca869f6"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(389), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Bölme ve Bölünebilme" },
                    { new Guid("b6abad46-8a07-47f6-a456-0c4d9d90d6fd"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(403), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "İş, Güç ve Enerji" },
                    { new Guid("bf41370b-ac1b-4132-bc7f-383945cdd59a"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(393), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Problemler" },
                    { new Guid("d250cebc-c0bf-4ccd-a58d-4780e44f5a90"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(441), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Asitler, Bazlar ve Tuzlar" },
                    { new Guid("d7f77511-607d-4be5-b40f-5f71d3fc1199"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(387), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Sayı Basamakları" },
                    { new Guid("d8e0a046-8e54-4703-ada5-77b625c1aebf"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(410), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimya Bilimi" },
                    { new Guid("ef30376a-eb08-440c-a04a-402de3f105af"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(437), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimyasal Türler Arası Etkileşimler" },
                    { new Guid("f8728a78-7cac-48fc-ab6e-9c4217ab046b"), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(449), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Canlıların Sınıflandırılması" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsTopics",
                columns: new[] { "QuestionId", "TopicId", "Id" },
                values: new object[,]
                {
                    { new Guid("003dfac8-e219-4b3a-9eb6-cb76104e1492"), new Guid("ef30376a-eb08-440c-a04a-402de3f105af"), new Guid("38202623-23b9-402e-9ec7-82d175024b0e") },
                    { new Guid("02e6f607-8b8a-43a2-b3aa-caa30b7802d9"), new Guid("388f36b2-f016-4133-b42c-c41229181e07"), new Guid("315a2641-4f15-408c-91ec-4a9a628a62bd") },
                    { new Guid("03adc41e-0332-46b2-a6b9-8e2a5d5fbde3"), new Guid("f8728a78-7cac-48fc-ab6e-9c4217ab046b"), new Guid("f3c6548d-eafa-4ef7-b04f-8a0140be8324") },
                    { new Guid("03e98a56-7841-45f4-b07d-07d699aede00"), new Guid("01de30cb-f870-4d1a-b4f0-6028afc1c143"), new Guid("1174daac-6d93-498e-914f-699a87c4d805") },
                    { new Guid("062a784f-4baf-4140-91d1-1ab886f68c0f"), new Guid("aec0d6bf-bb76-4a00-b496-ca392ca869f6"), new Guid("64c67465-64c8-4d5f-a678-58aee19c8387") },
                    { new Guid("06bd1a8e-5569-4a61-92a3-bd4c80266f7e"), new Guid("a784ddf8-afd5-40d5-a124-77e91a706b80"), new Guid("4812d2bf-dbb3-4f92-a62f-baca5eaa28af") },
                    { new Guid("0f92b22f-6510-4b8d-9135-82302d726865"), new Guid("d250cebc-c0bf-4ccd-a58d-4780e44f5a90"), new Guid("1aeddd2c-77f5-418f-aca1-67b1dfe962c8") },
                    { new Guid("1202a873-23eb-4ca1-90b3-7987ee911752"), new Guid("aec0d6bf-bb76-4a00-b496-ca392ca869f6"), new Guid("0608b3f3-82ef-4d79-b5e7-720c8863cb60") },
                    { new Guid("18d203ba-bf99-4be7-8bb7-c38ef6f99e99"), new Guid("4b0250a6-9fc8-4167-86dd-0218e6aabbe8"), new Guid("1313483a-72d8-46d3-ac5c-3b3ad2fe92ad") },
                    { new Guid("199ef779-16ad-4e64-a1e3-bb499cad8e25"), new Guid("4ccb86e8-df53-436a-af24-eb056571282f"), new Guid("a26099b7-b35c-4923-a8dc-717f869682f0") },
                    { new Guid("1c06427a-dc7f-4849-9e67-a10856b039ab"), new Guid("d250cebc-c0bf-4ccd-a58d-4780e44f5a90"), new Guid("a601541e-8b31-46a4-a416-32656e33c300") },
                    { new Guid("1c6b18a9-9524-49cf-9033-b29c50e5d383"), new Guid("0c8d687f-2587-4494-9e5a-ee46655c21cd"), new Guid("0422423b-416e-4025-bf0c-e7db51ea4141") },
                    { new Guid("1e1b3926-764e-495f-bdb6-03ddb6d7c7bf"), new Guid("888ccd3c-517f-45e5-9004-97ab0de47e54"), new Guid("1fdeef8e-b4c2-476b-bd6d-922360cb45e7") },
                    { new Guid("1f850f00-4f74-4039-8f90-f1270d74e1cf"), new Guid("4ccb86e8-df53-436a-af24-eb056571282f"), new Guid("56f63439-2a21-4865-8243-1823a7e1f322") },
                    { new Guid("21880a68-508c-4b46-b8e9-69e97596898f"), new Guid("388f36b2-f016-4133-b42c-c41229181e07"), new Guid("3843649d-8427-47fe-9fc9-a7a3e6acc356") },
                    { new Guid("23b4e4d9-2530-4dac-a9b6-dd5d48e785b0"), new Guid("d7f77511-607d-4be5-b40f-5f71d3fc1199"), new Guid("7355df85-bca5-4559-b76a-4370b3ac1dd4") },
                    { new Guid("25953dc6-27d2-46db-acf3-152509ffc736"), new Guid("91fed905-0c66-47ff-a53f-6be108c434fc"), new Guid("a24b0568-91b9-4312-ba6f-39d500ef0575") },
                    { new Guid("28002858-465a-417b-bfa7-3a72038cd8a6"), new Guid("7b3885a6-88cc-42a2-a1d2-9a61dbb8a920"), new Guid("ee6564ce-944e-4da6-8fc4-1e25eba950c6") },
                    { new Guid("2a741688-ecc6-48cb-93a0-482a4741de3f"), new Guid("01de30cb-f870-4d1a-b4f0-6028afc1c143"), new Guid("527ac719-b399-49de-8ab5-834f3fda7a86") },
                    { new Guid("2b22135d-f156-4c29-9e19-09f32fb87aff"), new Guid("b6abad46-8a07-47f6-a456-0c4d9d90d6fd"), new Guid("a82a12ab-8cdc-4b13-820d-1cd0f352d965") },
                    { new Guid("2dd76c28-9021-4441-bbf8-e296fc826e2a"), new Guid("f8728a78-7cac-48fc-ab6e-9c4217ab046b"), new Guid("d52d7cc3-9503-4902-8257-f24bcd68d599") },
                    { new Guid("2f24a948-46b8-469e-a612-922a2df4f1a3"), new Guid("5e5c6311-80c3-4625-b7e3-05da5dbb15c0"), new Guid("79feb560-964a-45c8-80a8-38df4f11eb66") },
                    { new Guid("30b03c24-5ff2-41c4-92f0-a65ad999b151"), new Guid("ef30376a-eb08-440c-a04a-402de3f105af"), new Guid("749b42d4-4e9d-471c-a4de-2b430d3d4589") },
                    { new Guid("31327bd2-4b4d-4be6-831d-6a18ee884399"), new Guid("aec0d6bf-bb76-4a00-b496-ca392ca869f6"), new Guid("922285e7-0690-416b-909c-11ca65cf5386") },
                    { new Guid("3162e81e-ad16-4374-968f-a2abaa8733f9"), new Guid("01de30cb-f870-4d1a-b4f0-6028afc1c143"), new Guid("577a0fa7-f54a-4b5d-b2cb-03542fa3cc75") },
                    { new Guid("345b8a1b-411a-46f7-874b-5e495468ee9d"), new Guid("5e5c6311-80c3-4625-b7e3-05da5dbb15c0"), new Guid("bc3fe665-568a-4fa1-af52-2e08d09b2005") },
                    { new Guid("3733dd7f-a924-441e-8efc-274eb40e0f81"), new Guid("d8e0a046-8e54-4703-ada5-77b625c1aebf"), new Guid("cc33959d-a801-44b1-acd4-933e39e59b9d") },
                    { new Guid("392f71a1-1c67-4ec0-86ad-227e45e0bee5"), new Guid("575f6632-8899-49a2-b225-1d31a30231d1"), new Guid("a4c029fb-d9dc-4447-a567-cfb8f366db16") },
                    { new Guid("3c302787-ec8d-4529-a7c5-ce61d4823c4f"), new Guid("0c8d687f-2587-4494-9e5a-ee46655c21cd"), new Guid("4989d18b-af19-45f0-9053-ac8d7d7c6af1") },
                    { new Guid("3faaef56-9f97-4651-a80e-2a722a915d28"), new Guid("d8e0a046-8e54-4703-ada5-77b625c1aebf"), new Guid("d63bacf3-a740-4dc4-a88a-5126f1b3608a") },
                    { new Guid("408fd400-a4f0-46c4-963a-c57129bc26d3"), new Guid("f8728a78-7cac-48fc-ab6e-9c4217ab046b"), new Guid("9ca5f299-e6c0-4bec-8e47-3c6cd68196ea") },
                    { new Guid("41a635e5-f01e-46c6-951d-c6bc9848c652"), new Guid("f8728a78-7cac-48fc-ab6e-9c4217ab046b"), new Guid("79f97b0f-2f97-4a1a-8e59-bfbe2680f801") },
                    { new Guid("47bbd168-a4f9-4e56-a387-92c939b267b8"), new Guid("d250cebc-c0bf-4ccd-a58d-4780e44f5a90"), new Guid("9ba131cc-c65b-4cc2-94e2-39a745538cff") },
                    { new Guid("495d2ec6-e940-4040-9bc1-89a4807156cd"), new Guid("575f6632-8899-49a2-b225-1d31a30231d1"), new Guid("01f6b928-163b-4892-9dce-7b9f38f163e8") },
                    { new Guid("497aec3f-a50d-4ea3-bf7c-d40ae715ca5b"), new Guid("b6abad46-8a07-47f6-a456-0c4d9d90d6fd"), new Guid("404bb702-e2c2-4479-a312-03fd984b218f") },
                    { new Guid("4a636af9-c040-4ae1-95b0-025e142f9f7f"), new Guid("7b3885a6-88cc-42a2-a1d2-9a61dbb8a920"), new Guid("75276309-101c-48f8-9b29-9d6cf9f94183") },
                    { new Guid("527ec67a-8698-436d-a363-42a6122ca448"), new Guid("388f36b2-f016-4133-b42c-c41229181e07"), new Guid("24a83dc7-b875-46d5-ab06-14201cbebd52") },
                    { new Guid("53e5b503-786e-415d-b17a-8756c8c9a680"), new Guid("a784ddf8-afd5-40d5-a124-77e91a706b80"), new Guid("1dbe52b8-105b-4b2e-90d0-a7b13d84f755") },
                    { new Guid("55c237bd-4d6c-4c61-b819-90f432067fb5"), new Guid("09dee641-f9a9-4c28-8015-c9eb79dbac5f"), new Guid("8c5b9a16-972c-436f-afd0-2306fa3373f0") },
                    { new Guid("5bf2a380-cd04-4ba5-a758-3feed65fe551"), new Guid("01de30cb-f870-4d1a-b4f0-6028afc1c143"), new Guid("299684e1-7ec9-41ff-a984-639092f84beb") },
                    { new Guid("605f0a56-070a-4151-af2d-bdbb9b9be810"), new Guid("91fed905-0c66-47ff-a53f-6be108c434fc"), new Guid("b62aa75e-afac-4eb1-b296-b93a389bbac3") },
                    { new Guid("60940b98-535b-4fab-9663-9b7d15c6670c"), new Guid("f8728a78-7cac-48fc-ab6e-9c4217ab046b"), new Guid("fda1e38c-23cf-46f1-88df-80a978452445") },
                    { new Guid("6153cdd5-27a9-4d11-a834-419ba59efb1d"), new Guid("bf41370b-ac1b-4132-bc7f-383945cdd59a"), new Guid("9e624810-04ea-4ce0-ac32-1931cb8d46a1") },
                    { new Guid("64b6621b-cfc1-4be3-80b5-47b205e5968d"), new Guid("a784ddf8-afd5-40d5-a124-77e91a706b80"), new Guid("528f2315-b7fb-41ae-8811-6e51f0cae67d") },
                    { new Guid("6a3a8811-4a55-4b7b-bcaf-4eeb71e8c55f"), new Guid("aec0d6bf-bb76-4a00-b496-ca392ca869f6"), new Guid("86a54bec-ab9b-4523-ae3c-3182bb77ba9f") },
                    { new Guid("6d438930-6ae4-4f8a-a2fd-778d7b0775c2"), new Guid("4ccb86e8-df53-436a-af24-eb056571282f"), new Guid("f4a9447e-c6fc-44f4-b19d-a9d500053c57") },
                    { new Guid("71e8619c-4c33-40ed-8191-cb207d1e2bb6"), new Guid("d7f77511-607d-4be5-b40f-5f71d3fc1199"), new Guid("dcc04bdf-1790-426a-af7f-9647a68ec465") },
                    { new Guid("73e503b1-c6d5-4d16-a76c-6ad75743af00"), new Guid("4b0250a6-9fc8-4167-86dd-0218e6aabbe8"), new Guid("645e42f8-475b-4f4d-95a8-83f0bfafd9da") },
                    { new Guid("76515146-e41b-4f4f-bf2f-4253febf5911"), new Guid("4b0250a6-9fc8-4167-86dd-0218e6aabbe8"), new Guid("011759bd-77ba-41e7-a2b7-71be2ef23a55") },
                    { new Guid("79160525-70da-4a07-b0a6-7a80351e5ce8"), new Guid("aec0d6bf-bb76-4a00-b496-ca392ca869f6"), new Guid("85440d9e-52f6-4624-9473-7f746a804904") },
                    { new Guid("7abddf71-514b-4424-8bd6-7007eb4a6378"), new Guid("5e5c6311-80c3-4625-b7e3-05da5dbb15c0"), new Guid("bb286f15-29bd-4b21-bf81-26c7c6dd60dc") },
                    { new Guid("7b9c9537-a6b3-4b23-a21c-6b95938ff38a"), new Guid("575f6632-8899-49a2-b225-1d31a30231d1"), new Guid("314ac3ea-2afa-4ebc-91b9-fa42a095995f") },
                    { new Guid("7c6b1554-0525-49ed-8016-5420e0f95176"), new Guid("ef30376a-eb08-440c-a04a-402de3f105af"), new Guid("67e73acd-da22-4673-8bf1-f6fd4db4487e") },
                    { new Guid("7d7d1fd0-07f8-4b0c-8325-093a3e577906"), new Guid("91fed905-0c66-47ff-a53f-6be108c434fc"), new Guid("c3aa90ee-fe6e-4beb-a8aa-b0cbed479eaf") },
                    { new Guid("7d95f37a-80a7-4275-8814-7a04fdb92254"), new Guid("4ccb86e8-df53-436a-af24-eb056571282f"), new Guid("39c72f70-8414-4b6e-8423-76e5590d1d78") },
                    { new Guid("84ca6a0b-0d63-4a8a-be9f-1faa3759bd05"), new Guid("888ccd3c-517f-45e5-9004-97ab0de47e54"), new Guid("704c6587-0345-4eaf-a546-fb0f226bc995") },
                    { new Guid("874a316b-b698-4b4b-95fa-492afcc48702"), new Guid("bf41370b-ac1b-4132-bc7f-383945cdd59a"), new Guid("b5012762-654e-4c0e-845b-1dfc93dadd80") },
                    { new Guid("87cc61ee-3d84-4fdb-9c26-dea768357115"), new Guid("ef30376a-eb08-440c-a04a-402de3f105af"), new Guid("4da39829-9606-4fcb-8fa8-a6ffa26cec49") },
                    { new Guid("89c38696-4e47-486c-b0e4-6b2d84d5f3fc"), new Guid("0c8d687f-2587-4494-9e5a-ee46655c21cd"), new Guid("d7ece26d-e392-47da-8538-9498b1fd919e") },
                    { new Guid("8b3995f9-4a90-4557-a64e-298811ffa5b6"), new Guid("bf41370b-ac1b-4132-bc7f-383945cdd59a"), new Guid("c998535e-3692-4135-aaa3-b15767417f92") },
                    { new Guid("8c3df66f-aef3-4986-8cc8-93b4c3090e44"), new Guid("09dee641-f9a9-4c28-8015-c9eb79dbac5f"), new Guid("668dec21-895d-4ef1-8fed-8d306c360118") },
                    { new Guid("91ba48ff-55fc-44be-a780-3f8e5fff3b3f"), new Guid("ef30376a-eb08-440c-a04a-402de3f105af"), new Guid("9ca6abf1-fd9f-4c0f-b4a4-f3b11a950a18") },
                    { new Guid("92bcea13-5532-46a5-98de-0e75f45a6b59"), new Guid("b6abad46-8a07-47f6-a456-0c4d9d90d6fd"), new Guid("1541fac7-99c8-4468-82aa-12bebd2361f2") },
                    { new Guid("95202c6b-63b7-4a5a-bb0f-7581906a16e8"), new Guid("a784ddf8-afd5-40d5-a124-77e91a706b80"), new Guid("43dc43f2-e786-4c0b-b71b-a8e45bec7e62") },
                    { new Guid("957806db-cbe6-4b24-984a-c8be2bad6e90"), new Guid("575f6632-8899-49a2-b225-1d31a30231d1"), new Guid("94fd146f-c64f-45ce-b65d-237785544539") },
                    { new Guid("96ac416a-2cd8-4c3b-9f9a-122353e62104"), new Guid("09dee641-f9a9-4c28-8015-c9eb79dbac5f"), new Guid("9564e2fc-517b-486c-aa50-1badcc309fbe") },
                    { new Guid("96f4a0bf-b982-45a5-9e10-55771b562f73"), new Guid("888ccd3c-517f-45e5-9004-97ab0de47e54"), new Guid("9b5a943b-8b7f-4965-894a-415d62beb409") },
                    { new Guid("99246c1b-b094-4a3a-83eb-e7e225f55134"), new Guid("4ccb86e8-df53-436a-af24-eb056571282f"), new Guid("738f8291-efa0-4749-93e5-3ffde1dcb03f") },
                    { new Guid("994089a5-c409-447f-9cc4-98e9c4581290"), new Guid("4b0250a6-9fc8-4167-86dd-0218e6aabbe8"), new Guid("26ab0d48-6e3f-4192-8bc0-68085c89ac65") },
                    { new Guid("9b1b3dc7-beaf-4cde-9040-b82d977d5370"), new Guid("888ccd3c-517f-45e5-9004-97ab0de47e54"), new Guid("54993d11-46b6-4c25-b9f3-75526a71ae94") },
                    { new Guid("9be55a0d-09ad-481e-b11e-cce848bf86d8"), new Guid("a784ddf8-afd5-40d5-a124-77e91a706b80"), new Guid("b8b98bf4-1f37-4e2d-9431-f99fd09d48c7") },
                    { new Guid("9cac2c9b-0317-4e60-acbc-da4f0527ce11"), new Guid("d250cebc-c0bf-4ccd-a58d-4780e44f5a90"), new Guid("9b8aebba-56e5-42a1-bf8c-d2334e86e30e") },
                    { new Guid("a0e996de-9b39-41bf-9689-fecce472fd7a"), new Guid("d7f77511-607d-4be5-b40f-5f71d3fc1199"), new Guid("4d6347e6-635c-4c83-ac64-eaedf05c3d53") },
                    { new Guid("a195ec7e-e341-4d0a-9c0f-e612c10733b2"), new Guid("575f6632-8899-49a2-b225-1d31a30231d1"), new Guid("d9a2830e-4035-41a1-92d7-450a26d71351") },
                    { new Guid("a859809a-5720-4d9a-a5fe-9e5986391703"), new Guid("d8e0a046-8e54-4703-ada5-77b625c1aebf"), new Guid("0bfd56ec-6bb7-4fdf-aa49-d40eb67a0b1f") },
                    { new Guid("a886e878-83df-425d-a358-a88f8ef3a4db"), new Guid("7b3885a6-88cc-42a2-a1d2-9a61dbb8a920"), new Guid("e954102a-75af-4190-a29c-49efc88fe39b") },
                    { new Guid("a9ea9bb2-c3fe-4e18-97ee-6c6b8f7b909c"), new Guid("91fed905-0c66-47ff-a53f-6be108c434fc"), new Guid("9b9ef5a5-c358-4584-b2a0-4269e9934437") },
                    { new Guid("aa743add-6dfa-4d6c-b1ef-65402ea03d59"), new Guid("7b3885a6-88cc-42a2-a1d2-9a61dbb8a920"), new Guid("256fae59-13a5-4495-af0c-97c809a711e2") },
                    { new Guid("b06e41d9-c68e-46f1-af6b-3d619ab9ca4a"), new Guid("b6abad46-8a07-47f6-a456-0c4d9d90d6fd"), new Guid("2d20e144-552d-4d69-82d3-b84ca082491a") },
                    { new Guid("b0e0f817-a3d2-4e52-8402-f6c5b2f3a97e"), new Guid("d250cebc-c0bf-4ccd-a58d-4780e44f5a90"), new Guid("861f2aed-7c8c-452f-a4df-947a3096cd77") },
                    { new Guid("b30ce0c8-830c-471c-891f-5ce8b24965dd"), new Guid("91fed905-0c66-47ff-a53f-6be108c434fc"), new Guid("d7dd1803-e75c-4a73-9d29-2ff6c4e3ac20") },
                    { new Guid("b64cb03b-5c9b-4247-a02b-90a69dece5bc"), new Guid("b6abad46-8a07-47f6-a456-0c4d9d90d6fd"), new Guid("f670c492-2c18-4ebc-a887-1a81fe96ee32") },
                    { new Guid("b82e78da-37d7-4ec3-a0e1-486515ee1cc4"), new Guid("d8e0a046-8e54-4703-ada5-77b625c1aebf"), new Guid("d3add210-6ede-4d8a-9fe7-2c17bf6be555") },
                    { new Guid("bb47c3d2-dc1c-4b5d-aaf6-595bef028bf6"), new Guid("5e5c6311-80c3-4625-b7e3-05da5dbb15c0"), new Guid("b5d2f45a-cfb2-44c6-b4ab-795bfa9ffb8c") },
                    { new Guid("c02d5253-9ab6-4618-b155-75d4ac0c0182"), new Guid("7b3885a6-88cc-42a2-a1d2-9a61dbb8a920"), new Guid("7260b790-f0e9-403e-849f-9122613a60d7") },
                    { new Guid("c58172f4-9b92-4e2a-8564-885024aa9bdc"), new Guid("d7f77511-607d-4be5-b40f-5f71d3fc1199"), new Guid("32a43a73-3fa1-4155-bbf0-043766e8d31e") },
                    { new Guid("c5b6cdb9-24a1-4902-b106-42bc7399534b"), new Guid("388f36b2-f016-4133-b42c-c41229181e07"), new Guid("89f61adf-9f52-467a-88c0-ea502a072fa4") },
                    { new Guid("c983e23f-dc16-4608-83f4-caf219f635c1"), new Guid("0c8d687f-2587-4494-9e5a-ee46655c21cd"), new Guid("7cde960b-d221-4b2f-97e3-6c630e581536") },
                    { new Guid("cfa2bf07-4e6f-4416-98d4-79f4470ae71a"), new Guid("01de30cb-f870-4d1a-b4f0-6028afc1c143"), new Guid("8ffe7fe3-510d-49f1-8002-935e16f5aa3e") },
                    { new Guid("cfd52a72-184d-4294-9f53-b1894bce57f5"), new Guid("888ccd3c-517f-45e5-9004-97ab0de47e54"), new Guid("0fb40361-a433-4f76-9a98-033f7ecbf08f") },
                    { new Guid("de2f121c-e0dd-4f61-82d6-1aee68263d83"), new Guid("5e5c6311-80c3-4625-b7e3-05da5dbb15c0"), new Guid("f5ed9df7-0f06-4f3f-b78d-4b3ede5124f4") },
                    { new Guid("dff054d4-bfde-49fb-adf3-b2e1d0eb1610"), new Guid("09dee641-f9a9-4c28-8015-c9eb79dbac5f"), new Guid("b87f320f-3767-4c5a-a5a3-7d973a2198b5") },
                    { new Guid("e1c15fd8-3a8f-44ec-af02-c417b63bba07"), new Guid("0c8d687f-2587-4494-9e5a-ee46655c21cd"), new Guid("a30de358-55db-46bc-94f1-c5183b5fec42") },
                    { new Guid("e3fd23d0-22ec-4efb-89db-303d2130ddd5"), new Guid("4b0250a6-9fc8-4167-86dd-0218e6aabbe8"), new Guid("ed0fa8c9-71e3-4a3a-9a11-f80e45c8c723") },
                    { new Guid("e962f3e7-943a-43dd-a1e8-4df9146bfc3d"), new Guid("bf41370b-ac1b-4132-bc7f-383945cdd59a"), new Guid("f187d134-5368-43a2-8642-d1ef73f94752") },
                    { new Guid("e9ebb795-ef4f-412f-a8dd-f0c2d0dc335c"), new Guid("bf41370b-ac1b-4132-bc7f-383945cdd59a"), new Guid("e105ac8e-4bed-4737-8513-2726e5307f2c") },
                    { new Guid("ec7a34ec-7da6-4f97-b2b4-b7a305766dbe"), new Guid("d8e0a046-8e54-4703-ada5-77b625c1aebf"), new Guid("7ce7b285-67df-4121-ba17-f0261d0bb6b3") },
                    { new Guid("f7659659-5021-4e61-81a4-c8190a649d9f"), new Guid("09dee641-f9a9-4c28-8015-c9eb79dbac5f"), new Guid("1a417a42-62aa-47bf-ba47-153819dd1b49") },
                    { new Guid("f85acec7-f71c-4e30-b854-ce0fb755eef4"), new Guid("388f36b2-f016-4133-b42c-c41229181e07"), new Guid("f299a724-bccb-4fd4-a6fc-5320cf1730df") },
                    { new Guid("f9b41ecd-86d3-4d58-8b25-92251cd4ac5f"), new Guid("d7f77511-607d-4be5-b40f-5f71d3fc1199"), new Guid("5f9c6b97-1a7a-4812-a06e-cb12681e9778") }
                });

            migrationBuilder.InsertData(
                table: "UserPerformanceSummaries",
                columns: new[] { "Id", "CorrectAnswers", "CreatedAt", "LastUpdatedAt", "SuccessRate", "TopicId", "TotalQuestionsAnswered", "UserId" },
                values: new object[,]
                {
                    { new Guid("02e747b5-fb1c-4188-a39f-9282b8e6c118"), 54, new DateTime(2025, 7, 20, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2612), new DateTime(2025, 8, 6, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2612), 98.180000000000007, new Guid("aec0d6bf-bb76-4a00-b496-ca392ca869f6"), 55, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("02f044b2-2a96-4cd5-acd6-e63096fe7a2c"), 29, new DateTime(2025, 7, 30, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2595), new DateTime(2025, 8, 7, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2601), 40.280000000000001, new Guid("4b0250a6-9fc8-4167-86dd-0218e6aabbe8"), 72, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("04255711-891f-4486-8493-238e7861d40f"), 27, new DateTime(2025, 7, 13, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2622), new DateTime(2025, 8, 9, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2622), 87.099999999999994, new Guid("aec0d6bf-bb76-4a00-b496-ca392ca869f6"), 31, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("1f083d05-931b-4ee3-94b2-aca73a29032c"), 27, new DateTime(2025, 7, 25, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2619), new DateTime(2025, 8, 8, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2619), 42.859999999999999, new Guid("4b0250a6-9fc8-4167-86dd-0218e6aabbe8"), 63, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("321e101a-643b-49cc-95a2-3c69485a5c95"), 12, new DateTime(2025, 7, 16, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2610), new DateTime(2025, 8, 8, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2611), 80.0, new Guid("d7f77511-607d-4be5-b40f-5f71d3fc1199"), 15, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("3d21a25f-f0a7-43a4-96e4-e01e1688670b"), 29, new DateTime(2025, 7, 14, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2633), new DateTime(2025, 8, 9, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2633), 43.280000000000001, new Guid("bf41370b-ac1b-4132-bc7f-383945cdd59a"), 67, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("4ff20ff9-f08a-4524-a0c1-df8aa924517c"), 30, new DateTime(2025, 8, 3, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2625), new DateTime(2025, 8, 5, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2625), 41.100000000000001, new Guid("bf41370b-ac1b-4132-bc7f-383945cdd59a"), 73, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("51501bdb-ada3-4ff1-a54e-8bb8b81a5dd3"), 32, new DateTime(2025, 7, 29, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2631), new DateTime(2025, 8, 5, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2631), 51.609999999999999, new Guid("aec0d6bf-bb76-4a00-b496-ca392ca869f6"), 62, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("549311b6-9b9e-421c-a410-133b5e2193da"), 30, new DateTime(2025, 7, 16, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2627), new DateTime(2025, 8, 10, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2627), 44.119999999999997, new Guid("4b0250a6-9fc8-4167-86dd-0218e6aabbe8"), 68, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("a96ac7fc-caae-46af-8fb0-433a612796b1"), 34, new DateTime(2025, 7, 26, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2623), new DateTime(2025, 8, 8, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2623), 94.439999999999998, new Guid("575f6632-8899-49a2-b225-1d31a30231d1"), 36, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("aa1afbfe-abcf-456b-af72-4f58d4a2dce2"), 17, new DateTime(2025, 8, 9, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2615), new DateTime(2025, 8, 8, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2615), 36.170000000000002, new Guid("575f6632-8899-49a2-b225-1d31a30231d1"), 47, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("cbf2cfe6-8263-4245-909a-a7adb779ca80"), 53, new DateTime(2025, 7, 29, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2630), new DateTime(2025, 8, 6, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2630), 76.810000000000002, new Guid("d7f77511-607d-4be5-b40f-5f71d3fc1199"), 69, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("ce088351-5ca9-408a-a9aa-1357bf5c8dcf"), 9, new DateTime(2025, 7, 15, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2620), new DateTime(2025, 8, 4, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2621), 47.369999999999997, new Guid("d7f77511-607d-4be5-b40f-5f71d3fc1199"), 19, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("dd0c5cf9-6685-463e-8d38-75c8578fe285"), 45, new DateTime(2025, 7, 21, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2632), new DateTime(2025, 8, 5, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2632), 47.369999999999997, new Guid("575f6632-8899-49a2-b225-1d31a30231d1"), 95, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("f7b9baa6-0a09-49c1-8e38-211b5e39c8e6"), 29, new DateTime(2025, 7, 15, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2616), new DateTime(2025, 8, 7, 12, 32, 19, 838, DateTimeKind.Utc).AddTicks(2616), 29.899999999999999, new Guid("bf41370b-ac1b-4132-bc7f-383945cdd59a"), 97, new Guid("11111111-1111-1111-1111-111111111111") }
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
