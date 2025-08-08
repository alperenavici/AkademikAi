using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AkademikAi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
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
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "dummy-conc-1", new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2632), "ali@example.com", true, false, null, "Ali", "ALI@EXAMPLE.COM", "ALI", "AQAAAAEAACcQAAAAEDummyHash1==", "5551111111", false, "dummy-stamp-1", "Veli", false, "ali", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "dummy-conc-2", new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2640), "ayse@example.com", true, false, null, "Ayşe", "AYSE@EXAMPLE.COM", "AYSE", "AQAAAAEAACcQAAAAEDummyHash2==", "5552222222", false, "dummy-stamp-2", "Yılmaz", false, "ayse", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "dummy-conc-3", new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2646), "mehmet@example.com", true, false, null, "Mehmet", "MEHMET@EXAMPLE.COM", "MEHMET", "AQAAAAEAACcQAAAAEDummyHash3==", "5553333333", false, "dummy-stamp-3", "Demir", false, "mehmet", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevel", "GeneratedForUserId", "IsActive", "QuestionText", "SolutionText", "Source" },
                values: new object[,]
                {
                    { new Guid("0225dd79-44d5-4896-8535-4dd7a224c0bd"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0524f2d8-80c7-4c07-b88a-51f5732988e5"), 0, null, true, "Problemler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("07275a11-660a-4714-b144-2c1674a9159d"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0a565ce3-b8da-4436-8b2d-eb941ad72d65"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("11958f01-663f-4eca-a5ef-42220b832f48"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("151a454e-0914-4dca-ab49-55d9b3b56d15"), 1, null, true, "Hücre konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("16600417-0c21-4956-8b71-8836701774cb"), 0, null, true, "Kalıtım konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("16ff1bef-c628-4282-b9d4-4f904dfe26f9"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("17765af3-d439-4c62-b2ea-ae0d78373d0f"), 1, null, true, "Kalıtım konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1bb03557-0d91-4b37-9731-fe25a5dcc1b4"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1c1d3c18-e572-4b53-a412-4eaa3a6d7362"), 2, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1fd817a1-8306-44b2-ac3f-bf4ef71886ce"), 2, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("225ceec4-b0b4-440d-b780-b7a8488a61ac"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("274b6607-903a-42c7-900e-ea061edad52e"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2a0ca876-c54c-4366-9557-33d6fe888052"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2a88c66c-63d7-42ba-a09e-5cbb90c1f40e"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2e942ef6-bd04-465e-b48b-9198da3ed184"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2f14c246-71a1-48f2-8276-d4fb48a28469"), 2, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2fb3c924-ac51-49b9-9e68-e858edcb1833"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("315fc4e1-18cc-460d-a7c3-59651596e46e"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("329c6d37-5ea1-4baf-9b1c-8abdae9c8381"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("39088d66-ff18-446e-9f09-6ad742386041"), 2, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3967e945-ec12-4f05-be4c-6016a89a4a94"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3995ec03-77a8-429e-b07b-a22cf5734e96"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("43de3d81-a894-4688-8526-ed5d16b1928e"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("44f68edd-eafe-461f-9982-75e41c7a4968"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("48cae202-0e62-464a-ad3f-1a9f14ce2746"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("490f660a-c379-42c0-b719-2ba4624e93ca"), 2, null, true, "Kimya Bilimi konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4e8c6825-ef2e-4a84-b4df-e79a997b1ebf"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4ebd85e6-72a7-4898-9475-77fc5cf18969"), 0, null, true, "Problemler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("52981242-d892-4fb2-8668-d4d76535f7a5"), 2, null, true, "Problemler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5526b4ef-01d5-45f3-bbfe-7024593fe8ad"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("55c170dd-bd95-453d-aef9-677e0765cb15"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("55f44740-8550-4b7a-8941-a65422e2c2f9"), 2, null, true, "Hücre konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5860549a-484e-4ae1-967f-a4f8534d20f8"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5a6c14d0-a73a-4ec7-8979-5fe94c6c2043"), 1, null, true, "Hücre konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("60026912-cd8a-4694-90a9-0c3cd3989a6d"), 0, null, true, "Hücre konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("69182758-9c19-45e2-859b-16c88ed14498"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6e7bf6b0-7ea4-41cc-9e48-6fa86ba52409"), 2, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("706242ea-1c96-477c-97eb-9ace499eeeb2"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("77e44df7-dfdb-4d61-a723-8c3353a0660d"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("77f2cb9e-b745-4a2d-bfd3-be1190da2295"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("79d4ebf5-b53e-4645-b7ec-58e222f87dc3"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7b1c5aca-a3b7-4b81-ba92-d27b648df07b"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7cccb9c6-1eaf-4ca4-ad14-2036250fffca"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7daf99b2-789c-4534-a5e4-d19019a227c8"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7e402648-3316-48ad-8a99-3c04f0c9f847"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("82fbf916-01e1-4522-a9cd-4232a55df333"), 0, null, true, "Hücre konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("838bf26e-e88a-4052-8898-25db3513e15e"), 2, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("86479721-42a4-413d-a215-aa5659ee0d7c"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8ba8eb31-eb0e-4e91-b68f-fc65e029cac2"), 2, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8ed7249f-399d-4734-8ec4-3accac46a47c"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8ef3a8e2-fde1-4419-b3e3-6a2ccbe4683b"), 1, null, true, "Problemler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("933a962a-660c-46d6-b34f-07e5760b5be0"), 2, null, true, "Elektrostatik konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9433fa3c-3702-45ff-a914-d09197cffd17"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("951da81d-39db-4aff-9589-2e34d3dd0829"), 2, null, true, "Kalıtım konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("95d5c966-00f8-4753-a22b-2b58c529d327"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("98a326c7-9c4c-471d-b210-b0c00568d00a"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("995b4610-29cc-47a1-a7e9-45f09a9ec050"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9cd4f04f-af2f-47bd-a5d9-b66d214375aa"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9e0ddce5-c1fb-4f04-ae65-d9f5cafc0f0f"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9e99054e-413b-4298-a560-ac01394facfc"), 2, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a1448740-7497-45e3-a2d6-edd5b1105377"), 2, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ab9797d5-33ce-47ee-8182-e0749480d66c"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ad728e0b-7834-4836-b1b2-18e581e0b43f"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("aede6a92-7d08-4be0-80d9-e9caf151ab38"), 2, null, true, "Temel Kavramlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b200fff6-c951-40f5-a58e-6d73580e8005"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b24819d9-5825-4306-9c92-1722bf73cd3b"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b339af85-4343-42e0-a6bb-e5b4ca444d08"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b4d12407-b028-4c90-b66d-2c3f3f97b4a1"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b53c8282-f044-46c8-ad26-74dbb03d5ff0"), 0, null, true, "Kalıtım konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b82f518a-7e25-4385-8b2c-66a9c94e9caf"), 2, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("bdc46dcb-182d-4394-87b5-2c903acaadc3"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("bf5118dc-a49f-4284-bc15-be183f6c19a5"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c3b66419-ea81-429a-a067-f4059e6e557b"), 2, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c3e31727-3b5b-4eba-8b75-fcb4cc8c5626"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c447bbe5-9ced-4be4-bac4-7246b14cba0e"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c7d4589c-296c-4b07-b561-0f8f99c862d3"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d1a60363-f78b-4a2b-8602-b227955b75f0"), 1, null, true, "Problemler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d1e342f3-2e64-47f0-b50f-8a030a9671f3"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d5ed33d9-5df4-436c-a662-edf21cd368ec"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("dc391e77-0e4c-488e-92fc-df6ca45032b5"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("de35257b-d910-46e0-8242-3733f2043af1"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("def357d9-d9c2-4b4c-a839-c2b545973536"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("df461bc5-1fff-47d7-ac67-53a7932d87f8"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e1c80035-16a5-4648-af08-e4a45011f04c"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e60f3c7f-c6e0-4de7-b41a-85f3726491ce"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e8f8a3f9-aff2-497f-8869-1a4389988c32"), 2, null, true, "Maddenin Halleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ea0bd87d-8f54-45de-9ff3-c7345e796663"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ec588e29-733e-4438-91d0-69b4201f3d0f"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ed6444ac-a1a1-4b44-9144-e65fc06c2653"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("efa1641f-c3c6-4b3d-970b-14b2eed93579"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f2250006-16b9-498a-be20-361d3378dd71"), 2, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f52f1673-08db-494e-a009-6dcb47af9554"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f6548a03-5517-4b20-96b8-05fddf1e4d61"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f76d06a7-1c86-4197-a209-bb9c4e3e1413"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f93a1338-cbca-484b-88ef-dc23b74cae9e"), 2, null, true, "Sayı Basamakları konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fad08b48-b804-47b3-a126-637fdf4a8c96"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fef58697-43c2-4923-8855-eecab92b797a"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ff21523c-4ea3-47e2-a49e-b10754ea393d"), 1, null, true, "Kalıtım konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2741), "Temel kimya konuları", true, "Kimya" },
                    { new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2739), "Temel fizik konuları", true, "Fizik" },
                    { new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2743), "Temel biyoloji konuları", true, "Biyoloji" },
                    { new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2736), "Temel matematik konuları", true, "Matematik" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "IsCorrect", "Label", "OptionOrder", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("0015ec1c-27d4-4721-87ce-3343415ea35e"), true, "C", 3, "Bölme ve Bölünebilme - Soru 5 için Seçenek C", new Guid("a1448740-7497-45e3-a2d6-edd5b1105377") },
                    { new Guid("00ee5bec-6100-40f9-b89c-9b83bb185f65"), false, "A", 1, "Elektrostatik - Soru 5 için Seçenek A", new Guid("933a962a-660c-46d6-b34f-07e5760b5be0") },
                    { new Guid("0155f818-ab4c-4ed4-b891-5ee1b315a4f8"), false, "C", 3, "Elektrostatik - Soru 2 için Seçenek C", new Guid("df461bc5-1fff-47d7-ac67-53a7932d87f8") },
                    { new Guid("01d810ce-2dc7-4d81-aa46-5fbe1f466a56"), false, "A", 1, "Madde ve Özellikleri - Soru 4 için Seçenek A", new Guid("706242ea-1c96-477c-97eb-9ace499eeeb2") },
                    { new Guid("01eb6ac0-05ab-4d5a-9e18-28ba15105f1f"), false, "D", 4, "Madde ve Özellikleri - Soru 3 için Seçenek D", new Guid("55c170dd-bd95-453d-aef9-677e0765cb15") },
                    { new Guid("02daa99c-b749-4240-8503-f3271bffd35b"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 2 için Seçenek A", new Guid("0a565ce3-b8da-4436-8b2d-eb941ad72d65") },
                    { new Guid("02eeca62-1dc6-4ee0-b6e8-b3e418796578"), false, "A", 1, "Kimya Bilimi - Soru 5 için Seçenek A", new Guid("490f660a-c379-42c0-b719-2ba4624e93ca") },
                    { new Guid("03e480fe-1e7f-4cdf-8e84-129bae700769"), false, "A", 1, "İş, Güç ve Enerji - Soru 2 için Seçenek A", new Guid("3967e945-ec12-4f05-be4c-6016a89a4a94") },
                    { new Guid("0442c6bc-9ffd-4375-9ffd-5ae3324baa6d"), true, "C", 3, "Madde ve Özellikleri - Soru 2 için Seçenek C", new Guid("f6548a03-5517-4b20-96b8-05fddf1e4d61") },
                    { new Guid("0600b6b4-0916-4e9c-ba59-664f856459c0"), false, "D", 4, "Hücre Bölünmeleri - Soru 3 için Seçenek D", new Guid("2a0ca876-c54c-4366-9557-33d6fe888052") },
                    { new Guid("060dac4b-fc35-401c-8ff6-c858b64485ee"), false, "D", 4, "Fizik Bilimine Giriş - Soru 4 için Seçenek D", new Guid("e60f3c7f-c6e0-4de7-b41a-85f3726491ce") },
                    { new Guid("06509f2d-b2c3-451a-adcd-5c0d5ec7b8cc"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek C", new Guid("995b4610-29cc-47a1-a7e9-45f09a9ec050") },
                    { new Guid("07a073c0-9a48-4d03-9108-8d797b412b72"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek A", new Guid("f52f1673-08db-494e-a009-6dcb47af9554") },
                    { new Guid("082a2bea-f7dc-4383-a937-9b6035a409df"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek D", new Guid("b4d12407-b028-4c90-b66d-2c3f3f97b4a1") },
                    { new Guid("0852c423-5f95-4601-8afd-1788da03fd02"), false, "D", 4, "Kuvvet ve Hareket - Soru 4 için Seçenek D", new Guid("8ed7249f-399d-4734-8ec4-3accac46a47c") },
                    { new Guid("087e5642-9e45-41bc-868d-92cbcd089568"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 5 için Seçenek D", new Guid("b82f518a-7e25-4385-8b2c-66a9c94e9caf") },
                    { new Guid("0a0447e1-68ac-4689-b35d-a6611afe1164"), false, "A", 1, "Temel Kavramlar - Soru 1 için Seçenek A", new Guid("ed6444ac-a1a1-4b44-9144-e65fc06c2653") },
                    { new Guid("0a9d9386-67bd-41ac-aff1-cc2c835204f7"), true, "B", 2, "Bölme ve Bölünebilme - Soru 3 için Seçenek B", new Guid("dc391e77-0e4c-488e-92fc-df6ca45032b5") },
                    { new Guid("0b52f846-6784-4dcf-804d-af8c2427efb9"), true, "C", 3, "Kimya Bilimi - Soru 5 için Seçenek C", new Guid("490f660a-c379-42c0-b719-2ba4624e93ca") },
                    { new Guid("0b6bf3d0-3e7e-47b7-ac28-05497a55b8c3"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek D", new Guid("f52f1673-08db-494e-a009-6dcb47af9554") },
                    { new Guid("0c041141-406c-4f59-9fca-ba8c63a45731"), false, "D", 4, "Hücre Bölünmeleri - Soru 2 için Seçenek D", new Guid("fad08b48-b804-47b3-a126-637fdf4a8c96") },
                    { new Guid("0c672f20-6ed8-46e4-9bbc-26f0ceb1959e"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 4 için Seçenek D", new Guid("7e402648-3316-48ad-8a99-3c04f0c9f847") },
                    { new Guid("0cd8acdf-a37e-4698-a24a-586506a1f261"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek D", new Guid("39088d66-ff18-446e-9f09-6ad742386041") },
                    { new Guid("0d15517f-79ea-490e-914b-43542518a5f8"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek C", new Guid("f2250006-16b9-498a-be20-361d3378dd71") },
                    { new Guid("0e97ac34-4b1b-47d1-a1fc-6dc6522e5d0f"), false, "D", 4, "Elektrostatik - Soru 4 için Seçenek D", new Guid("16ff1bef-c628-4282-b9d4-4f904dfe26f9") },
                    { new Guid("0e9dbe82-e9c8-4d45-b576-ae58c26a2055"), false, "B", 2, "Fizik Bilimine Giriş - Soru 2 için Seçenek B", new Guid("def357d9-d9c2-4b4c-a839-c2b545973536") },
                    { new Guid("0eaa7222-cd6a-40a4-902f-6f8023d4adaf"), false, "C", 3, "Madde ve Özellikleri - Soru 4 için Seçenek C", new Guid("706242ea-1c96-477c-97eb-9ace499eeeb2") },
                    { new Guid("0eeffbeb-fbdb-4eb0-8119-4120b6b04834"), false, "C", 3, "Temel Kavramlar - Soru 4 için Seçenek C", new Guid("d1e342f3-2e64-47f0-b50f-8a030a9671f3") },
                    { new Guid("0fe5754d-67da-490d-bdc7-9633965eed7f"), true, "D", 4, "Madde ve Özellikleri - Soru 4 için Seçenek D", new Guid("706242ea-1c96-477c-97eb-9ace499eeeb2") },
                    { new Guid("10fe8d4e-53b8-419d-b433-d40bd955dc3b"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek C", new Guid("7b1c5aca-a3b7-4b81-ba92-d27b648df07b") },
                    { new Guid("114593d4-ca1e-4ee0-9ee5-8dd76a776272"), false, "A", 1, "Maddenin Halleri - Soru 2 için Seçenek A", new Guid("43de3d81-a894-4688-8526-ed5d16b1928e") },
                    { new Guid("123ee8ff-a4a7-4f51-9894-c15881f11b58"), false, "A", 1, "Hücre - Soru 2 için Seçenek A", new Guid("151a454e-0914-4dca-ab49-55d9b3b56d15") },
                    { new Guid("13f81e79-95a2-4955-8d25-97a7f22700cb"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek B", new Guid("7b1c5aca-a3b7-4b81-ba92-d27b648df07b") },
                    { new Guid("142241e8-bcd0-457f-97ac-29860a2a7ee7"), false, "D", 4, "Bölme ve Bölünebilme - Soru 1 için Seçenek D", new Guid("ab9797d5-33ce-47ee-8182-e0749480d66c") },
                    { new Guid("146ae33b-7a45-41b0-a4aa-393b9493e353"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 3 için Seçenek B", new Guid("3995ec03-77a8-429e-b07b-a22cf5734e96") },
                    { new Guid("154401ce-3f9f-42da-a06b-50da7e217094"), true, "B", 2, "Fizik Bilimine Giriş - Soru 5 için Seçenek B", new Guid("9e99054e-413b-4298-a560-ac01394facfc") },
                    { new Guid("15a10efe-18a4-4c52-973a-e935e70f810c"), false, "B", 2, "Temel Kavramlar - Soru 1 için Seçenek B", new Guid("ed6444ac-a1a1-4b44-9144-e65fc06c2653") },
                    { new Guid("15bf9e1c-04ca-4b9d-9ab6-3d3c5ae5dbf2"), false, "B", 2, "Elektrostatik - Soru 2 için Seçenek B", new Guid("df461bc5-1fff-47d7-ac67-53a7932d87f8") },
                    { new Guid("15e1542a-9901-44b2-b5bc-718f30922a8b"), true, "A", 1, "Temel Kavramlar - Soru 4 için Seçenek A", new Guid("d1e342f3-2e64-47f0-b50f-8a030a9671f3") },
                    { new Guid("15f6b1f3-d1ec-468a-af41-f0749ad0ae2d"), true, "C", 3, "Fizik Bilimine Giriş - Soru 4 için Seçenek C", new Guid("e60f3c7f-c6e0-4de7-b41a-85f3726491ce") },
                    { new Guid("1647bd1f-9153-4c27-ab30-b9b932f76968"), false, "A", 1, "Temel Kavramlar - Soru 2 için Seçenek A", new Guid("c7d4589c-296c-4b07-b561-0f8f99c862d3") },
                    { new Guid("1703435a-1c85-448d-b2ea-8b8e40466db8"), false, "D", 4, "Problemler - Soru 1 için Seçenek D", new Guid("4ebd85e6-72a7-4898-9475-77fc5cf18969") },
                    { new Guid("171b17af-b3f0-43dc-b342-2a9f6be0d1f1"), true, "C", 3, "Temel Kavramlar - Soru 5 için Seçenek C", new Guid("aede6a92-7d08-4be0-80d9-e9caf151ab38") },
                    { new Guid("179746bf-bad6-49ee-a009-7374e86a1854"), false, "D", 4, "Bölme ve Bölünebilme - Soru 3 için Seçenek D", new Guid("dc391e77-0e4c-488e-92fc-df6ca45032b5") },
                    { new Guid("1841b5d2-6a83-4cf3-8e62-4b842d35c0b7"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek D", new Guid("2fb3c924-ac51-49b9-9e68-e858edcb1833") },
                    { new Guid("191d8827-0b6b-4720-9756-d2047ac29492"), false, "C", 3, "Bölme ve Bölünebilme - Soru 4 için Seçenek C", new Guid("f76d06a7-1c86-4197-a209-bb9c4e3e1413") },
                    { new Guid("192dd1e1-1bdd-467f-8654-71cfaf94ee8d"), false, "C", 3, "Kuvvet ve Hareket - Soru 2 için Seçenek C", new Guid("48cae202-0e62-464a-ad3f-1a9f14ce2746") },
                    { new Guid("19d2fdb6-7213-49a2-9739-1e7f2fcb6271"), false, "D", 4, "Sayı Basamakları - Soru 5 için Seçenek D", new Guid("f93a1338-cbca-484b-88ef-dc23b74cae9e") },
                    { new Guid("1a297037-9e6a-4489-bb61-73cb520c7654"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 1 için Seçenek C", new Guid("b339af85-4343-42e0-a6bb-e5b4ca444d08") },
                    { new Guid("1a3405c3-f36a-4d82-bc02-5c02e4179e50"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek A", new Guid("7daf99b2-789c-4534-a5e4-d19019a227c8") },
                    { new Guid("1b2b093f-d251-4062-a68d-cc10b7f43fee"), true, "C", 3, "Fizik Bilimine Giriş - Soru 1 için Seçenek C", new Guid("d5ed33d9-5df4-436c-a662-edf21cd368ec") },
                    { new Guid("1c61d246-ec25-44bc-aab6-17c8d9876b56"), true, "B", 2, "Sayı Basamakları - Soru 4 için Seçenek B", new Guid("b200fff6-c951-40f5-a58e-6d73580e8005") },
                    { new Guid("1d2445f4-3760-4868-8ab9-70e6b02a18dc"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 4 için Seçenek A", new Guid("44f68edd-eafe-461f-9982-75e41c7a4968") },
                    { new Guid("1f15139c-36b9-4240-bf99-bc95905ef6b2"), false, "B", 2, "Madde ve Özellikleri - Soru 4 için Seçenek B", new Guid("706242ea-1c96-477c-97eb-9ace499eeeb2") },
                    { new Guid("21ff37d2-d224-49b1-b62e-4e1f10e03a67"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 1 için Seçenek C", new Guid("4e8c6825-ef2e-4a84-b4df-e79a997b1ebf") },
                    { new Guid("23ee135e-ebe0-4778-aa8d-b6413c8ddbea"), false, "D", 4, "Kimya Bilimi - Soru 4 için Seçenek D", new Guid("11958f01-663f-4eca-a5ef-42220b832f48") },
                    { new Guid("2460f101-82b3-46b4-8266-731301c6c746"), false, "D", 4, "Fizik Bilimine Giriş - Soru 5 için Seçenek D", new Guid("9e99054e-413b-4298-a560-ac01394facfc") },
                    { new Guid("24a2d794-f8d5-4e9c-b0e6-477097c39d9f"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 5 için Seçenek B", new Guid("b82f518a-7e25-4385-8b2c-66a9c94e9caf") },
                    { new Guid("269b4028-91be-4665-a483-c70219f1e7b9"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek D", new Guid("7daf99b2-789c-4534-a5e4-d19019a227c8") },
                    { new Guid("26cace3b-9109-4b3f-98be-fde2620747b9"), false, "C", 3, "Sayı Basamakları - Soru 4 için Seçenek C", new Guid("b200fff6-c951-40f5-a58e-6d73580e8005") },
                    { new Guid("26d88c76-f5a5-4be9-9115-901ff5ee020d"), false, "D", 4, "Kimya Bilimi - Soru 5 için Seçenek D", new Guid("490f660a-c379-42c0-b719-2ba4624e93ca") },
                    { new Guid("26e10b95-1c5f-4848-82d1-30c8f340ce76"), false, "C", 3, "Kalıtım - Soru 3 için Seçenek C", new Guid("16600417-0c21-4956-8b71-8836701774cb") },
                    { new Guid("270ceb36-f0b7-49cf-b99e-1b9df6532091"), false, "D", 4, "İş, Güç ve Enerji - Soru 1 için Seçenek D", new Guid("79d4ebf5-b53e-4645-b7ec-58e222f87dc3") },
                    { new Guid("2729b862-d8cd-4fad-bd57-c21229053f3e"), false, "A", 1, "Fizik Bilimine Giriş - Soru 2 için Seçenek A", new Guid("def357d9-d9c2-4b4c-a839-c2b545973536") },
                    { new Guid("27852442-87b6-4458-ba6f-82cf562c8b07"), true, "D", 4, "Elektrostatik - Soru 2 için Seçenek D", new Guid("df461bc5-1fff-47d7-ac67-53a7932d87f8") },
                    { new Guid("28a28418-5d9d-48e7-a972-41f0c2793a0b"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 4 için Seçenek C", new Guid("44f68edd-eafe-461f-9982-75e41c7a4968") },
                    { new Guid("2987856a-242c-4e72-b3ab-e8b4152b09b0"), true, "A", 1, "Sayı Basamakları - Soru 2 için Seçenek A", new Guid("95d5c966-00f8-4753-a22b-2b58c529d327") },
                    { new Guid("2acdf78e-e481-4902-970f-601889c8c654"), true, "C", 3, "Elektrostatik - Soru 4 için Seçenek C", new Guid("16ff1bef-c628-4282-b9d4-4f904dfe26f9") },
                    { new Guid("2bc1bd34-7710-486d-b098-27b0c95165f3"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 3 için Seçenek D", new Guid("5860549a-484e-4ae1-967f-a4f8534d20f8") },
                    { new Guid("2bd1f0c7-f7e3-4826-af15-bb61c2066e84"), false, "C", 3, "Madde ve Özellikleri - Soru 1 için Seçenek C", new Guid("225ceec4-b0b4-440d-b780-b7a8488a61ac") },
                    { new Guid("2c05e2d6-906b-42d4-8e8b-97b970eb465e"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek A", new Guid("315fc4e1-18cc-460d-a7c3-59651596e46e") },
                    { new Guid("2de3feda-f898-4273-89e8-e210dd559c49"), false, "A", 1, "Problemler - Soru 3 için Seçenek A", new Guid("0524f2d8-80c7-4c07-b88a-51f5732988e5") },
                    { new Guid("2e58f139-11bd-4087-8743-e76ea13f3199"), true, "D", 4, "Kuvvet ve Hareket - Soru 2 için Seçenek D", new Guid("48cae202-0e62-464a-ad3f-1a9f14ce2746") },
                    { new Guid("2e80cc14-1660-4d84-bf2e-9cd030d0d526"), true, "C", 3, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek C", new Guid("9e0ddce5-c1fb-4f04-ae65-d9f5cafc0f0f") },
                    { new Guid("2f3c9b79-8151-4ef2-b936-cdb5ccbd31eb"), false, "D", 4, "Maddenin Halleri - Soru 3 için Seçenek D", new Guid("bf5118dc-a49f-4284-bc15-be183f6c19a5") },
                    { new Guid("2ff10cee-4ee3-4e57-b8ab-021329e060e0"), false, "B", 2, "Kuvvet ve Hareket - Soru 5 için Seçenek B", new Guid("8ba8eb31-eb0e-4e91-b68f-fc65e029cac2") },
                    { new Guid("321ca7f9-66e8-48d8-8ca8-bc8035912c75"), false, "C", 3, "İş, Güç ve Enerji - Soru 5 için Seçenek C", new Guid("838bf26e-e88a-4052-8898-25db3513e15e") },
                    { new Guid("321d140f-c55b-42d5-9c11-d01a5dd07bef"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 2 için Seçenek B", new Guid("0225dd79-44d5-4896-8535-4dd7a224c0bd") },
                    { new Guid("3265e84c-e929-4edb-904c-6b534b0519a3"), false, "C", 3, "Hücre - Soru 2 için Seçenek C", new Guid("151a454e-0914-4dca-ab49-55d9b3b56d15") },
                    { new Guid("32d6b903-6eeb-4814-8aa5-e98eb2c561ec"), false, "B", 2, "Kalıtım - Soru 5 için Seçenek B", new Guid("951da81d-39db-4aff-9589-2e34d3dd0829") },
                    { new Guid("3356fe7f-c14c-448d-9c08-0480484cf8a9"), true, "A", 1, "Kuvvet ve Hareket - Soru 1 için Seçenek A", new Guid("86479721-42a4-413d-a215-aa5659ee0d7c") },
                    { new Guid("33596c36-85bc-4526-9410-4d6b61d89e17"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek B", new Guid("39088d66-ff18-446e-9f09-6ad742386041") },
                    { new Guid("3365eb21-c51c-4b58-8585-c8cb94fd9789"), false, "C", 3, "Hücre Bölünmeleri - Soru 1 için Seçenek C", new Guid("bdc46dcb-182d-4394-87b5-2c903acaadc3") },
                    { new Guid("336a38d1-a8c7-4628-959e-24e5ae2100f0"), false, "D", 4, "Fizik Bilimine Giriş - Soru 2 için Seçenek D", new Guid("def357d9-d9c2-4b4c-a839-c2b545973536") },
                    { new Guid("350a179c-f121-489e-881f-1e97eee7fe94"), false, "B", 2, "Kuvvet ve Hareket - Soru 1 için Seçenek B", new Guid("86479721-42a4-413d-a215-aa5659ee0d7c") },
                    { new Guid("35bd1733-c111-43aa-8e36-41c164dc268b"), false, "B", 2, "Sayı Basamakları - Soru 5 için Seçenek B", new Guid("f93a1338-cbca-484b-88ef-dc23b74cae9e") },
                    { new Guid("3606ce3b-bc81-4b0a-b50b-04c7f9604d30"), false, "B", 2, "Rasyonel Sayılar - Soru 5 için Seçenek B", new Guid("1fd817a1-8306-44b2-ac3f-bf4ef71886ce") },
                    { new Guid("36f4c928-baa5-40e4-8b4e-d1ec8eff1cf0"), false, "A", 1, "Rasyonel Sayılar - Soru 4 için Seçenek A", new Guid("e1c80035-16a5-4648-af08-e4a45011f04c") },
                    { new Guid("377a9abe-d60d-4998-a24b-47de11fce565"), false, "D", 4, "Kalıtım - Soru 5 için Seçenek D", new Guid("951da81d-39db-4aff-9589-2e34d3dd0829") },
                    { new Guid("386ed3b5-553b-41c5-b54a-c3c4e09689a3"), false, "B", 2, "Hücre - Soru 2 için Seçenek B", new Guid("151a454e-0914-4dca-ab49-55d9b3b56d15") },
                    { new Guid("388916f2-0f02-456a-9df3-e640aca01d6d"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek B", new Guid("7daf99b2-789c-4534-a5e4-d19019a227c8") },
                    { new Guid("38cf920d-2374-42ca-8c4d-f81e74e4313a"), false, "A", 1, "Sayı Basamakları - Soru 1 için Seçenek A", new Guid("c3e31727-3b5b-4eba-8b75-fcb4cc8c5626") },
                    { new Guid("390d3b5b-6687-4678-a7ca-e154f22ee9b2"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek C", new Guid("c447bbe5-9ced-4be4-bac4-7246b14cba0e") },
                    { new Guid("3ac5e771-9693-4857-8712-67ef8af4ba79"), true, "B", 2, "Kalıtım - Soru 4 için Seçenek B", new Guid("ff21523c-4ea3-47e2-a49e-b10754ea393d") },
                    { new Guid("3bbebfbb-892f-4efd-ad9a-36d9350c1316"), false, "A", 1, "Kimya Bilimi - Soru 4 için Seçenek A", new Guid("11958f01-663f-4eca-a5ef-42220b832f48") },
                    { new Guid("3bca3e72-d4bf-4a92-a3bf-7e444979241a"), false, "A", 1, "Maddenin Halleri - Soru 4 için Seçenek A", new Guid("7cccb9c6-1eaf-4ca4-ad14-2036250fffca") },
                    { new Guid("3c2ca3d6-d2b1-44fa-8705-784ab3efdc4b"), true, "C", 3, "Hücre Bölünmeleri - Soru 3 için Seçenek C", new Guid("2a0ca876-c54c-4366-9557-33d6fe888052") },
                    { new Guid("3c938368-7e45-4449-ae23-d3646d4602de"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek D", new Guid("1c1d3c18-e572-4b53-a412-4eaa3a6d7362") },
                    { new Guid("3d2a7786-5962-462e-8344-59d085f9b550"), true, "C", 3, "Kalıtım - Soru 5 için Seçenek C", new Guid("951da81d-39db-4aff-9589-2e34d3dd0829") },
                    { new Guid("3e88dc36-97db-4c4f-a169-83f3348fffd0"), true, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek C", new Guid("9433fa3c-3702-45ff-a914-d09197cffd17") },
                    { new Guid("3ee2253e-6408-49f1-b329-b021c109cc3c"), false, "C", 3, "Hücre - Soru 1 için Seçenek C", new Guid("82fbf916-01e1-4522-a9cd-4232a55df333") },
                    { new Guid("3ee8a8e6-bf29-4cf5-bf46-f2238f13974d"), true, "D", 4, "Maddenin Halleri - Soru 5 için Seçenek D", new Guid("e8f8a3f9-aff2-497f-8869-1a4389988c32") },
                    { new Guid("3f299e3c-6615-49b9-9c4f-4bf4bfd39c4e"), false, "C", 3, "Hücre Bölünmeleri - Soru 5 için Seçenek C", new Guid("c3b66419-ea81-429a-a067-f4059e6e557b") },
                    { new Guid("4045fb80-bc4e-4b52-b8c6-ce677a45db3d"), false, "C", 3, "Rasyonel Sayılar - Soru 2 için Seçenek C", new Guid("9cd4f04f-af2f-47bd-a5d9-b66d214375aa") },
                    { new Guid("41848334-cfbf-432e-820e-d441de738210"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 3 için Seçenek A", new Guid("3995ec03-77a8-429e-b07b-a22cf5734e96") },
                    { new Guid("41d284c8-362c-432f-8a5d-fd08c99f34a5"), false, "A", 1, "Hücre Bölünmeleri - Soru 1 için Seçenek A", new Guid("bdc46dcb-182d-4394-87b5-2c903acaadc3") },
                    { new Guid("42e08663-d867-4de0-b4af-8493c26cb1de"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 2 için Seçenek D", new Guid("0225dd79-44d5-4896-8535-4dd7a224c0bd") },
                    { new Guid("4389bb9b-f6a9-4f70-b536-be07e58bd544"), false, "D", 4, "Madde ve Özellikleri - Soru 1 için Seçenek D", new Guid("225ceec4-b0b4-440d-b780-b7a8488a61ac") },
                    { new Guid("444509a7-3689-4cf8-aa28-80e75609fa22"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek A", new Guid("f2250006-16b9-498a-be20-361d3378dd71") },
                    { new Guid("44a86c60-86af-460f-8156-b321424b5b0d"), false, "A", 1, "Elektrostatik - Soru 4 için Seçenek A", new Guid("16ff1bef-c628-4282-b9d4-4f904dfe26f9") },
                    { new Guid("45a4bcd2-b83a-441c-a9f4-fefffba62e07"), false, "C", 3, "Bölme ve Bölünebilme - Soru 1 için Seçenek C", new Guid("ab9797d5-33ce-47ee-8182-e0749480d66c") },
                    { new Guid("45cc1800-169b-42c2-9db9-b23ccde98294"), false, "A", 1, "Madde ve Özellikleri - Soru 2 için Seçenek A", new Guid("f6548a03-5517-4b20-96b8-05fddf1e4d61") },
                    { new Guid("47919532-d3a4-4af6-aecc-ea7892a7f117"), false, "A", 1, "Hücre Bölünmeleri - Soru 4 için Seçenek A", new Guid("329c6d37-5ea1-4baf-9b1c-8abdae9c8381") },
                    { new Guid("4a23b530-b806-4010-8aae-4e683c373db9"), true, "D", 4, "Hücre - Soru 4 için Seçenek D", new Guid("5a6c14d0-a73a-4ec7-8979-5fe94c6c2043") },
                    { new Guid("4a43bfde-2be2-43bc-97af-d071c522a034"), false, "C", 3, "Kuvvet ve Hareket - Soru 1 için Seçenek C", new Guid("86479721-42a4-413d-a215-aa5659ee0d7c") },
                    { new Guid("4b50c4cf-d604-4773-a6ae-75a80fa459ec"), false, "D", 4, "Problemler - Soru 5 için Seçenek D", new Guid("52981242-d892-4fb2-8668-d4d76535f7a5") },
                    { new Guid("4d43e088-e03c-4253-a5fb-ea3496f5bdb1"), false, "C", 3, "Kimya Bilimi - Soru 1 için Seçenek C", new Guid("2a88c66c-63d7-42ba-a09e-5cbb90c1f40e") },
                    { new Guid("4d4811be-4b1d-4637-b506-7580a998a8f8"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek D", new Guid("9e0ddce5-c1fb-4f04-ae65-d9f5cafc0f0f") },
                    { new Guid("4da7439e-ad03-475f-943a-8fd2cd3e2cef"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 4 için Seçenek B", new Guid("44f68edd-eafe-461f-9982-75e41c7a4968") },
                    { new Guid("4e50bf41-fa84-4270-a4a7-a8ba67a1d2c8"), false, "B", 2, "Problemler - Soru 1 için Seçenek B", new Guid("4ebd85e6-72a7-4898-9475-77fc5cf18969") },
                    { new Guid("4e895604-380d-4f33-8197-d8c1c22bc40e"), false, "A", 1, "Sayı Basamakları - Soru 3 için Seçenek A", new Guid("98a326c7-9c4c-471d-b210-b0c00568d00a") },
                    { new Guid("4edfcb6a-aa27-43e5-b939-ff328fbba136"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 1 için Seçenek B", new Guid("4e8c6825-ef2e-4a84-b4df-e79a997b1ebf") },
                    { new Guid("4f9b0ed1-257d-4118-9498-b8cd4d6ac9a8"), true, "C", 3, "Kuvvet ve Hareket - Soru 4 için Seçenek C", new Guid("8ed7249f-399d-4734-8ec4-3accac46a47c") },
                    { new Guid("5061eeda-0ed8-4218-80d6-f2666e192a02"), false, "D", 4, "Kimya Bilimi - Soru 1 için Seçenek D", new Guid("2a88c66c-63d7-42ba-a09e-5cbb90c1f40e") },
                    { new Guid("5126e1bd-d2e5-4d65-9074-b245d8219046"), false, "C", 3, "Elektrostatik - Soru 3 için Seçenek C", new Guid("ea0bd87d-8f54-45de-9ff3-c7345e796663") },
                    { new Guid("51a36a08-6575-4fc9-b208-d3789add26bd"), false, "D", 4, "Hücre Bölünmeleri - Soru 5 için Seçenek D", new Guid("c3b66419-ea81-429a-a067-f4059e6e557b") },
                    { new Guid("5244f005-9593-4151-935c-9700b5084567"), true, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek B", new Guid("de35257b-d910-46e0-8242-3733f2043af1") },
                    { new Guid("524abdf0-98b4-432d-800a-ce895cdcaf0e"), true, "B", 2, "Kalıtım - Soru 1 için Seçenek B", new Guid("b53c8282-f044-46c8-ad26-74dbb03d5ff0") },
                    { new Guid("549131c1-dd34-42c0-a239-7c2c246c6255"), false, "C", 3, "Kimya Bilimi - Soru 2 için Seçenek C", new Guid("07275a11-660a-4714-b144-2c1674a9159d") },
                    { new Guid("56182c29-561a-41a9-a7dc-050fe431f218"), false, "C", 3, "Elektrostatik - Soru 1 için Seçenek C", new Guid("77e44df7-dfdb-4d61-a723-8c3353a0660d") },
                    { new Guid("562906aa-8075-462b-bdbf-30752b983331"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek A", new Guid("995b4610-29cc-47a1-a7e9-45f09a9ec050") },
                    { new Guid("569267ba-0710-4ba0-8055-14aad72602d5"), false, "D", 4, "Madde ve Özellikleri - Soru 2 için Seçenek D", new Guid("f6548a03-5517-4b20-96b8-05fddf1e4d61") },
                    { new Guid("57013b0d-ac3c-47fd-b0d2-f660e8ef5a1d"), false, "C", 3, "İş, Güç ve Enerji - Soru 1 için Seçenek C", new Guid("79d4ebf5-b53e-4645-b7ec-58e222f87dc3") },
                    { new Guid("58c1f71e-cf07-44b6-8473-595887d4577c"), false, "B", 2, "Bölme ve Bölünebilme - Soru 2 için Seçenek B", new Guid("69182758-9c19-45e2-859b-16c88ed14498") },
                    { new Guid("590ccfd8-a5e5-458e-a511-50e166d606b0"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek A", new Guid("2fb3c924-ac51-49b9-9e68-e858edcb1833") },
                    { new Guid("59176a4f-af03-4930-82b1-d423a5f3524f"), false, "B", 2, "Madde ve Özellikleri - Soru 2 için Seçenek B", new Guid("f6548a03-5517-4b20-96b8-05fddf1e4d61") },
                    { new Guid("59588240-cd53-4146-bc0b-f0883866b75c"), false, "A", 1, "Kalıtım - Soru 5 için Seçenek A", new Guid("951da81d-39db-4aff-9589-2e34d3dd0829") },
                    { new Guid("59832d7b-4159-4e69-b953-6c9f66c6c702"), true, "B", 2, "Canlıların Sınıflandırılması - Soru 3 için Seçenek B", new Guid("5860549a-484e-4ae1-967f-a4f8534d20f8") },
                    { new Guid("5a873797-e9fb-4cd9-86c2-48c4e936d5f9"), true, "D", 4, "Rasyonel Sayılar - Soru 5 için Seçenek D", new Guid("1fd817a1-8306-44b2-ac3f-bf4ef71886ce") },
                    { new Guid("5aa9ee4e-3b3b-4ae7-9854-cc8421ea4300"), false, "C", 3, "İş, Güç ve Enerji - Soru 3 için Seçenek C", new Guid("5526b4ef-01d5-45f3-bbfe-7024593fe8ad") },
                    { new Guid("5ac3cd8b-ba57-49c6-80a0-c6d9ce1618c2"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek D", new Guid("de35257b-d910-46e0-8242-3733f2043af1") },
                    { new Guid("5b0055d5-f394-4625-a46c-d1449996b44e"), false, "B", 2, "Kalıtım - Soru 3 için Seçenek B", new Guid("16600417-0c21-4956-8b71-8836701774cb") },
                    { new Guid("5b914bc4-9530-4a25-a8fe-d99a8de02cd9"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 5 için Seçenek B", new Guid("6e7bf6b0-7ea4-41cc-9e48-6fa86ba52409") },
                    { new Guid("5bb0d1fa-dc71-48b2-ab24-70812b10146b"), false, "B", 2, "Hücre Bölünmeleri - Soru 1 için Seçenek B", new Guid("bdc46dcb-182d-4394-87b5-2c903acaadc3") },
                    { new Guid("5bd35995-5d8c-47fc-9959-264787d07757"), false, "A", 1, "Hücre - Soru 3 için Seçenek A", new Guid("60026912-cd8a-4694-90a9-0c3cd3989a6d") },
                    { new Guid("5ddc7580-7707-451c-9a21-716e828bc350"), false, "B", 2, "Rasyonel Sayılar - Soru 3 için Seçenek B", new Guid("1bb03557-0d91-4b37-9731-fe25a5dcc1b4") },
                    { new Guid("5f1c3b05-77d0-4a2a-a886-98f810121e47"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 1 için Seçenek A", new Guid("b339af85-4343-42e0-a6bb-e5b4ca444d08") },
                    { new Guid("5fba5e19-c2b8-4550-8a03-80c36152d81b"), false, "B", 2, "Temel Kavramlar - Soru 4 için Seçenek B", new Guid("d1e342f3-2e64-47f0-b50f-8a030a9671f3") },
                    { new Guid("609c0c3a-f75a-4aca-a824-b1fb847322d9"), false, "D", 4, "Temel Kavramlar - Soru 3 için Seçenek D", new Guid("2e942ef6-bd04-465e-b48b-9198da3ed184") },
                    { new Guid("60d76012-347b-4198-a9c7-054c010029bd"), true, "D", 4, "İş, Güç ve Enerji - Soru 3 için Seçenek D", new Guid("5526b4ef-01d5-45f3-bbfe-7024593fe8ad") },
                    { new Guid("62aa2abd-8887-4e0e-8e83-68003bd72de0"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek B", new Guid("1c1d3c18-e572-4b53-a412-4eaa3a6d7362") },
                    { new Guid("65d89044-4cdc-4443-9285-a9fec536a28e"), false, "D", 4, "Kuvvet ve Hareket - Soru 1 için Seçenek D", new Guid("86479721-42a4-413d-a215-aa5659ee0d7c") },
                    { new Guid("65e120f0-4e22-43ca-bf22-2ecfe1c948ba"), false, "B", 2, "Bölme ve Bölünebilme - Soru 4 için Seçenek B", new Guid("f76d06a7-1c86-4197-a209-bb9c4e3e1413") },
                    { new Guid("662785fa-8194-4fc6-9fb1-ccc30f8c8595"), false, "B", 2, "Hücre Bölünmeleri - Soru 4 için Seçenek B", new Guid("329c6d37-5ea1-4baf-9b1c-8abdae9c8381") },
                    { new Guid("67762fea-b65d-4a94-b86b-dc2da9550c35"), false, "D", 4, "Kimya Bilimi - Soru 3 için Seçenek D", new Guid("274b6607-903a-42c7-900e-ea061edad52e") },
                    { new Guid("6a2cddb6-b951-49a2-b556-86bde7a6cc26"), false, "B", 2, "Rasyonel Sayılar - Soru 4 için Seçenek B", new Guid("e1c80035-16a5-4648-af08-e4a45011f04c") },
                    { new Guid("6cdc6cdc-afd8-4fa6-b330-efa60034aeec"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 2 için Seçenek C", new Guid("0225dd79-44d5-4896-8535-4dd7a224c0bd") },
                    { new Guid("6d0c7fb2-745e-4a3d-a0e7-554a798501c8"), false, "A", 1, "Hücre - Soru 5 için Seçenek A", new Guid("55f44740-8550-4b7a-8941-a65422e2c2f9") },
                    { new Guid("6d44b095-dc71-42ef-b7fb-28597f2a637f"), false, "C", 3, "Madde ve Özellikleri - Soru 5 için Seçenek C", new Guid("2f14c246-71a1-48f2-8276-d4fb48a28469") },
                    { new Guid("6d9e6c75-4b2e-4959-ab8f-74c8e19b2ab6"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek B", new Guid("b4d12407-b028-4c90-b66d-2c3f3f97b4a1") },
                    { new Guid("6dfc861f-56b1-4def-8b7e-117035ff3ab5"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 4 için Seçenek B", new Guid("7e402648-3316-48ad-8a99-3c04f0c9f847") },
                    { new Guid("6f38b8b7-6611-4460-ae3e-67038dcde4c2"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek D", new Guid("fef58697-43c2-4923-8855-eecab92b797a") },
                    { new Guid("6fe79e74-3fc4-4e4e-b8a3-5b67548fa31f"), false, "B", 2, "Sayı Basamakları - Soru 1 için Seçenek B", new Guid("c3e31727-3b5b-4eba-8b75-fcb4cc8c5626") },
                    { new Guid("7050fe16-540e-474c-9a65-e8de7ee27fe1"), true, "A", 1, "Madde ve Özellikleri - Soru 3 için Seçenek A", new Guid("55c170dd-bd95-453d-aef9-677e0765cb15") },
                    { new Guid("715e7230-ed9e-4916-91dc-c37cacce688e"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek A", new Guid("1c1d3c18-e572-4b53-a412-4eaa3a6d7362") },
                    { new Guid("71b07ea5-ba35-4312-8349-895e0dcae3a8"), true, "D", 4, "Temel Kavramlar - Soru 2 için Seçenek D", new Guid("c7d4589c-296c-4b07-b561-0f8f99c862d3") },
                    { new Guid("71badfff-6051-4d28-9f49-c6d996a4d39d"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 2 için Seçenek B", new Guid("0a565ce3-b8da-4436-8b2d-eb941ad72d65") },
                    { new Guid("72053b9b-04a3-4bde-99ac-ce5874252be0"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek C", new Guid("fef58697-43c2-4923-8855-eecab92b797a") },
                    { new Guid("7462c6e3-1a06-4038-a235-6e7b871a82e0"), false, "D", 4, "Rasyonel Sayılar - Soru 1 için Seçenek D", new Guid("efa1641f-c3c6-4b3d-970b-14b2eed93579") },
                    { new Guid("74c8572e-24a1-47bf-a088-8dcd5e4293cb"), true, "A", 1, "Problemler - Soru 1 için Seçenek A", new Guid("4ebd85e6-72a7-4898-9475-77fc5cf18969") },
                    { new Guid("74f07af1-5f04-4dec-ae48-04238631ad39"), false, "C", 3, "Sayı Basamakları - Soru 2 için Seçenek C", new Guid("95d5c966-00f8-4753-a22b-2b58c529d327") },
                    { new Guid("75785bf8-bde3-4a62-99c8-058e2e573ef4"), false, "D", 4, "İş, Güç ve Enerji - Soru 4 için Seçenek D", new Guid("b24819d9-5825-4306-9c92-1722bf73cd3b") },
                    { new Guid("75acc559-5498-4ad2-a062-4e1bacc27dbe"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 2 için Seçenek A", new Guid("0225dd79-44d5-4896-8535-4dd7a224c0bd") },
                    { new Guid("76f1d560-aa75-4928-94d3-91c61be3c587"), true, "B", 2, "Hücre Bölünmeleri - Soru 5 için Seçenek B", new Guid("c3b66419-ea81-429a-a067-f4059e6e557b") },
                    { new Guid("771a63b3-596f-4c86-9376-6187a02e4419"), false, "B", 2, "Hücre - Soru 1 için Seçenek B", new Guid("82fbf916-01e1-4522-a9cd-4232a55df333") },
                    { new Guid("77b09a14-4180-4135-a8c3-37c0eee7d5d0"), false, "A", 1, "Madde ve Özellikleri - Soru 1 için Seçenek A", new Guid("225ceec4-b0b4-440d-b780-b7a8488a61ac") },
                    { new Guid("7816a2cf-fd44-4835-8f32-236ec0810732"), false, "C", 3, "Problemler - Soru 5 için Seçenek C", new Guid("52981242-d892-4fb2-8668-d4d76535f7a5") },
                    { new Guid("784d3605-3c3c-4a34-a289-8d63e270422e"), false, "A", 1, "İş, Güç ve Enerji - Soru 4 için Seçenek A", new Guid("b24819d9-5825-4306-9c92-1722bf73cd3b") },
                    { new Guid("78b6e19d-f5a2-4c0a-b1e7-45f399aa77db"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek B", new Guid("9433fa3c-3702-45ff-a914-d09197cffd17") },
                    { new Guid("7928dcb5-ef50-4fc5-ac3d-879c4a0ce5e1"), false, "C", 3, "Bölme ve Bölünebilme - Soru 2 için Seçenek C", new Guid("69182758-9c19-45e2-859b-16c88ed14498") },
                    { new Guid("7a70084a-2aaa-4319-a0fd-5e2b5aee180b"), false, "C", 3, "Sayı Basamakları - Soru 5 için Seçenek C", new Guid("f93a1338-cbca-484b-88ef-dc23b74cae9e") },
                    { new Guid("7ab8de36-875c-4e2d-859f-3e663cb7e0d0"), false, "A", 1, "Kuvvet ve Hareket - Soru 3 için Seçenek A", new Guid("ec588e29-733e-4438-91d0-69b4201f3d0f") },
                    { new Guid("7b2f9fc2-763e-42c4-b9e5-b8f17950a620"), false, "A", 1, "Sayı Basamakları - Soru 4 için Seçenek A", new Guid("b200fff6-c951-40f5-a58e-6d73580e8005") },
                    { new Guid("7c00ee26-2a81-427d-bf33-5478e0221162"), false, "D", 4, "Bölme ve Bölünebilme - Soru 2 için Seçenek D", new Guid("69182758-9c19-45e2-859b-16c88ed14498") },
                    { new Guid("7ca89689-b657-4cd2-80d7-8871662a6dde"), false, "D", 4, "İş, Güç ve Enerji - Soru 2 için Seçenek D", new Guid("3967e945-ec12-4f05-be4c-6016a89a4a94") },
                    { new Guid("7ce4db08-b9a1-4752-9c6c-620e53e8ca58"), false, "C", 3, "Fizik Bilimine Giriş - Soru 5 için Seçenek C", new Guid("9e99054e-413b-4298-a560-ac01394facfc") },
                    { new Guid("7dd16579-4fda-42dd-818d-048795a47340"), true, "D", 4, "Rasyonel Sayılar - Soru 3 için Seçenek D", new Guid("1bb03557-0d91-4b37-9731-fe25a5dcc1b4") },
                    { new Guid("7debfbe5-ab5c-40fa-8e4b-2fbcc7938df9"), true, "C", 3, "Maddenin Halleri - Soru 4 için Seçenek C", new Guid("7cccb9c6-1eaf-4ca4-ad14-2036250fffca") },
                    { new Guid("7ebf5315-89c4-40e4-8bdf-675e69ca7269"), false, "C", 3, "Sayı Basamakları - Soru 3 için Seçenek C", new Guid("98a326c7-9c4c-471d-b210-b0c00568d00a") },
                    { new Guid("7f30dfc8-11f5-44ba-b55c-c873e60733ef"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek A", new Guid("de35257b-d910-46e0-8242-3733f2043af1") },
                    { new Guid("7f3ef32a-0881-46ff-9be9-d1345778a347"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek C", new Guid("b4d12407-b028-4c90-b66d-2c3f3f97b4a1") },
                    { new Guid("7fafcfd7-9879-4a5f-8bc3-72307c74a146"), false, "B", 2, "Kimya Bilimi - Soru 5 için Seçenek B", new Guid("490f660a-c379-42c0-b719-2ba4624e93ca") },
                    { new Guid("81891851-5567-452d-a2e5-f68ac561326a"), true, "B", 2, "Kuvvet ve Hareket - Soru 3 için Seçenek B", new Guid("ec588e29-733e-4438-91d0-69b4201f3d0f") },
                    { new Guid("81d51bb7-7a00-4cd4-880a-37a85512bb61"), true, "B", 2, "Rasyonel Sayılar - Soru 1 için Seçenek B", new Guid("efa1641f-c3c6-4b3d-970b-14b2eed93579") },
                    { new Guid("81fa5549-807b-44ef-8653-2a13b09a7e1a"), false, "D", 4, "Sayı Basamakları - Soru 4 için Seçenek D", new Guid("b200fff6-c951-40f5-a58e-6d73580e8005") },
                    { new Guid("82532ac2-92bd-42c2-8881-e4514eff769a"), true, "A", 1, "Atom ve Periyodik Sistem - Soru 1 için Seçenek A", new Guid("4e8c6825-ef2e-4a84-b4df-e79a997b1ebf") },
                    { new Guid("828000c5-59a6-49a1-aad7-3f8ebfff6974"), false, "C", 3, "Madde ve Özellikleri - Soru 3 için Seçenek C", new Guid("55c170dd-bd95-453d-aef9-677e0765cb15") },
                    { new Guid("8290844a-c747-4fe5-8458-2c2a7ded78c5"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek D", new Guid("9433fa3c-3702-45ff-a914-d09197cffd17") },
                    { new Guid("82a07103-cc36-4838-8fbe-52cc7fbcecd9"), false, "A", 1, "İş, Güç ve Enerji - Soru 3 için Seçenek A", new Guid("5526b4ef-01d5-45f3-bbfe-7024593fe8ad") },
                    { new Guid("8346b900-e906-46fe-b38b-3697c1dea3dd"), false, "D", 4, "Kalıtım - Soru 4 için Seçenek D", new Guid("ff21523c-4ea3-47e2-a49e-b10754ea393d") },
                    { new Guid("835ba06f-8dfc-4f63-b983-24210dbcc002"), false, "C", 3, "Maddenin Halleri - Soru 1 için Seçenek C", new Guid("77f2cb9e-b745-4a2d-bfd3-be1190da2295") },
                    { new Guid("8366ea49-d6ca-41aa-bc02-245588d05f19"), false, "B", 2, "Bölme ve Bölünebilme - Soru 5 için Seçenek B", new Guid("a1448740-7497-45e3-a2d6-edd5b1105377") },
                    { new Guid("840611d9-e6d6-4aa1-8c1a-2a842ac1af58"), false, "D", 4, "Bölme ve Bölünebilme - Soru 5 için Seçenek D", new Guid("a1448740-7497-45e3-a2d6-edd5b1105377") },
                    { new Guid("841c0422-6176-4e29-a8ac-9d8f7f935110"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 5 için Seçenek D", new Guid("6e7bf6b0-7ea4-41cc-9e48-6fa86ba52409") },
                    { new Guid("844e6384-ba9a-45f0-8549-7ebd8548cb86"), false, "B", 2, "Kimya Bilimi - Soru 1 için Seçenek B", new Guid("2a88c66c-63d7-42ba-a09e-5cbb90c1f40e") },
                    { new Guid("8475d883-8f64-45c2-b4e3-3e5e8b852b17"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek C", new Guid("39088d66-ff18-446e-9f09-6ad742386041") },
                    { new Guid("86db700f-a09c-49ff-bf93-e4d2e612424a"), false, "A", 1, "Maddenin Halleri - Soru 1 için Seçenek A", new Guid("77f2cb9e-b745-4a2d-bfd3-be1190da2295") },
                    { new Guid("86f898e6-6cc4-447e-81ee-5dcf3270e4bc"), false, "A", 1, "Rasyonel Sayılar - Soru 1 için Seçenek A", new Guid("efa1641f-c3c6-4b3d-970b-14b2eed93579") },
                    { new Guid("8705263f-dfe8-4f2c-8382-fe013dd7ad95"), true, "C", 3, "Maddenin Halleri - Soru 2 için Seçenek C", new Guid("43de3d81-a894-4688-8526-ed5d16b1928e") },
                    { new Guid("871bb4d8-2b1c-41fa-ac34-aabc3e98d5f3"), false, "D", 4, "Hücre - Soru 3 için Seçenek D", new Guid("60026912-cd8a-4694-90a9-0c3cd3989a6d") },
                    { new Guid("872c595b-f7d4-40d8-b1d9-a7b5da9f9030"), false, "B", 2, "Rasyonel Sayılar - Soru 2 için Seçenek B", new Guid("9cd4f04f-af2f-47bd-a5d9-b66d214375aa") },
                    { new Guid("87f960d8-8d49-4ef8-807b-c642d2da790d"), true, "A", 1, "Maddenin Halleri - Soru 3 için Seçenek A", new Guid("bf5118dc-a49f-4284-bc15-be183f6c19a5") },
                    { new Guid("8833677f-ad0a-4a39-b2ab-65065a903b84"), false, "B", 2, "Elektrostatik - Soru 5 için Seçenek B", new Guid("933a962a-660c-46d6-b34f-07e5760b5be0") },
                    { new Guid("8857b8a6-58d5-4d43-b2e2-fd0ddab3fb2d"), true, "C", 3, "Kuvvet ve Hareket - Soru 5 için Seçenek C", new Guid("8ba8eb31-eb0e-4e91-b68f-fc65e029cac2") },
                    { new Guid("8887767a-dc47-445c-9e09-051b2f11d52e"), true, "D", 4, "Problemler - Soru 3 için Seçenek D", new Guid("0524f2d8-80c7-4c07-b88a-51f5732988e5") },
                    { new Guid("889d5c27-90e3-4217-a440-6bffffa202a7"), false, "D", 4, "Sayı Basamakları - Soru 2 için Seçenek D", new Guid("95d5c966-00f8-4753-a22b-2b58c529d327") },
                    { new Guid("8986420c-f998-4605-b093-a4dbacc577f0"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 5 için Seçenek C", new Guid("6e7bf6b0-7ea4-41cc-9e48-6fa86ba52409") },
                    { new Guid("89913fbf-7100-495e-954c-afdd39d6de38"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek C", new Guid("2fb3c924-ac51-49b9-9e68-e858edcb1833") },
                    { new Guid("8a745068-9b62-4b0d-843a-431e31f24823"), false, "B", 2, "Elektrostatik - Soru 4 için Seçenek B", new Guid("16ff1bef-c628-4282-b9d4-4f904dfe26f9") },
                    { new Guid("8acb5f19-1484-4fe6-a80c-b4fdd66523af"), false, "C", 3, "Maddenin Halleri - Soru 5 için Seçenek C", new Guid("e8f8a3f9-aff2-497f-8869-1a4389988c32") },
                    { new Guid("8ad8bd63-9636-4a64-9d7f-d37deee554db"), false, "A", 1, "Kuvvet ve Hareket - Soru 4 için Seçenek A", new Guid("8ed7249f-399d-4734-8ec4-3accac46a47c") },
                    { new Guid("8b2f2033-9814-4cdf-8ef3-28729199bebe"), false, "B", 2, "Maddenin Halleri - Soru 5 için Seçenek B", new Guid("e8f8a3f9-aff2-497f-8869-1a4389988c32") },
                    { new Guid("8c0c5195-309b-4aec-96a9-a98debd7e45b"), false, "D", 4, "Sayı Basamakları - Soru 3 için Seçenek D", new Guid("98a326c7-9c4c-471d-b210-b0c00568d00a") },
                    { new Guid("8c121ee9-c2f5-45e2-bb19-8354b8d8bbfe"), true, "C", 3, "İş, Güç ve Enerji - Soru 2 için Seçenek C", new Guid("3967e945-ec12-4f05-be4c-6016a89a4a94") },
                    { new Guid("8eb707ba-0c86-4b4c-b8a4-42902d7c7d36"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek B", new Guid("c447bbe5-9ced-4be4-bac4-7246b14cba0e") },
                    { new Guid("8ef3a7ef-71cd-4b31-ac13-11fff8a801e7"), false, "B", 2, "Temel Kavramlar - Soru 5 için Seçenek B", new Guid("aede6a92-7d08-4be0-80d9-e9caf151ab38") },
                    { new Guid("90387705-8c66-407e-9bc7-2662e27168e5"), false, "C", 3, "Problemler - Soru 4 için Seçenek C", new Guid("8ef3a8e2-fde1-4419-b3e3-6a2ccbe4683b") },
                    { new Guid("914fa5dc-8650-4156-a18c-2d39ec95e3b8"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek C", new Guid("de35257b-d910-46e0-8242-3733f2043af1") },
                    { new Guid("9275f7e2-9a31-464f-bbdf-649cf0dce7ae"), false, "D", 4, "Maddenin Halleri - Soru 4 için Seçenek D", new Guid("7cccb9c6-1eaf-4ca4-ad14-2036250fffca") },
                    { new Guid("95050931-b28e-4663-a015-c2c98f66a6eb"), false, "C", 3, "Maddenin Halleri - Soru 3 için Seçenek C", new Guid("bf5118dc-a49f-4284-bc15-be183f6c19a5") },
                    { new Guid("95367f7f-d10f-41e4-8701-70067d9f6e3d"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek A", new Guid("b4d12407-b028-4c90-b66d-2c3f3f97b4a1") },
                    { new Guid("9565d21c-6a03-4bb7-b19b-e469998c10c3"), false, "D", 4, "Temel Kavramlar - Soru 5 için Seçenek D", new Guid("aede6a92-7d08-4be0-80d9-e9caf151ab38") },
                    { new Guid("95edf51e-1af4-465e-a91a-6be5ebb3fc00"), true, "B", 2, "Elektrostatik - Soru 1 için Seçenek B", new Guid("77e44df7-dfdb-4d61-a723-8c3353a0660d") },
                    { new Guid("96b3f977-64ec-4d5e-a7f4-8c5a957a1fb1"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek A", new Guid("fef58697-43c2-4923-8855-eecab92b797a") },
                    { new Guid("96bd5626-4fcf-404a-9343-7503eea215b8"), false, "D", 4, "Bölme ve Bölünebilme - Soru 4 için Seçenek D", new Guid("f76d06a7-1c86-4197-a209-bb9c4e3e1413") },
                    { new Guid("970096f5-7fcb-49d3-9449-4ad1415cec63"), false, "A", 1, "Kalıtım - Soru 4 için Seçenek A", new Guid("ff21523c-4ea3-47e2-a49e-b10754ea393d") },
                    { new Guid("97905496-8dc9-4ffd-a466-0f268456f9fb"), false, "B", 2, "İş, Güç ve Enerji - Soru 3 için Seçenek B", new Guid("5526b4ef-01d5-45f3-bbfe-7024593fe8ad") },
                    { new Guid("980733f0-a932-46e9-be4e-3edfbc99d1e0"), false, "C", 3, "Kalıtım - Soru 4 için Seçenek C", new Guid("ff21523c-4ea3-47e2-a49e-b10754ea393d") },
                    { new Guid("9954ddf0-7995-4be3-a886-6973f6f41821"), false, "D", 4, "Maddenin Halleri - Soru 2 için Seçenek D", new Guid("43de3d81-a894-4688-8526-ed5d16b1928e") },
                    { new Guid("9964c254-8633-4ba1-93e2-f8d4957155c4"), true, "D", 4, "Hücre Bölünmeleri - Soru 1 için Seçenek D", new Guid("bdc46dcb-182d-4394-87b5-2c903acaadc3") },
                    { new Guid("99a9d47c-8e7e-485f-90b7-6dd8bc719e1a"), true, "A", 1, "Bölme ve Bölünebilme - Soru 2 için Seçenek A", new Guid("69182758-9c19-45e2-859b-16c88ed14498") },
                    { new Guid("9ae6b84d-6f5b-4ce1-b3c0-d6df5ee708bf"), false, "D", 4, "Kalıtım - Soru 1 için Seçenek D", new Guid("b53c8282-f044-46c8-ad26-74dbb03d5ff0") },
                    { new Guid("9bbe1bdb-9792-41d8-9f74-f44841244bf2"), false, "D", 4, "Kuvvet ve Hareket - Soru 3 için Seçenek D", new Guid("ec588e29-733e-4438-91d0-69b4201f3d0f") },
                    { new Guid("9be6a228-9af4-40f2-853a-4781bbf6fed2"), false, "D", 4, "Elektrostatik - Soru 5 için Seçenek D", new Guid("933a962a-660c-46d6-b34f-07e5760b5be0") },
                    { new Guid("9c53dc6e-c4ed-46fa-a634-34b09d91c6aa"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek D", new Guid("995b4610-29cc-47a1-a7e9-45f09a9ec050") },
                    { new Guid("9c5a8c82-3b6f-457a-89e9-aa025ca1fbbd"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 3 için Seçenek C", new Guid("3995ec03-77a8-429e-b07b-a22cf5734e96") },
                    { new Guid("9d131b77-c025-49ce-80f7-2ed29b6677b9"), false, "C", 3, "Problemler - Soru 3 için Seçenek C", new Guid("0524f2d8-80c7-4c07-b88a-51f5732988e5") },
                    { new Guid("9d981957-8171-406e-9838-7ef4b34b1592"), true, "A", 1, "Hücre - Soru 1 için Seçenek A", new Guid("82fbf916-01e1-4522-a9cd-4232a55df333") },
                    { new Guid("9e3ebd7e-7810-4f79-9e94-a4e8f7e58a87"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 5 için Seçenek A", new Guid("b82f518a-7e25-4385-8b2c-66a9c94e9caf") },
                    { new Guid("9eac920b-f90e-44c8-ad8f-cb486d33388c"), false, "B", 2, "İş, Güç ve Enerji - Soru 1 için Seçenek B", new Guid("79d4ebf5-b53e-4645-b7ec-58e222f87dc3") },
                    { new Guid("a046a682-cb20-449f-bd94-24244e7777ef"), false, "A", 1, "Kuvvet ve Hareket - Soru 5 için Seçenek A", new Guid("8ba8eb31-eb0e-4e91-b68f-fc65e029cac2") },
                    { new Guid("a1116daf-2764-4922-b23f-c3206ef9fca8"), true, "C", 3, "Fizik Bilimine Giriş - Soru 2 için Seçenek C", new Guid("def357d9-d9c2-4b4c-a839-c2b545973536") },
                    { new Guid("a176bbc3-80fc-4d49-9b37-e38882e63d5c"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 1 için Seçenek B", new Guid("b339af85-4343-42e0-a6bb-e5b4ca444d08") },
                    { new Guid("a241c963-9460-4395-bd49-f1bb1a2c987f"), false, "B", 2, "Temel Kavramlar - Soru 2 için Seçenek B", new Guid("c7d4589c-296c-4b07-b561-0f8f99c862d3") },
                    { new Guid("a3a01546-57db-46db-9592-a2c30e5449aa"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 2 için Seçenek D", new Guid("0a565ce3-b8da-4436-8b2d-eb941ad72d65") },
                    { new Guid("a3aafc12-98dd-444a-9ef4-aa9837893504"), false, "C", 3, "Temel Kavramlar - Soru 3 için Seçenek C", new Guid("2e942ef6-bd04-465e-b48b-9198da3ed184") },
                    { new Guid("a4a3a38e-c3e5-4c07-9dec-885680320702"), true, "B", 2, "Temel Kavramlar - Soru 3 için Seçenek B", new Guid("2e942ef6-bd04-465e-b48b-9198da3ed184") },
                    { new Guid("a4bd8465-7538-428f-bd03-1b617ead162f"), false, "A", 1, "Kalıtım - Soru 2 için Seçenek A", new Guid("17765af3-d439-4c62-b2ea-ae0d78373d0f") },
                    { new Guid("a61d73b3-336f-4e55-b417-1f28ab4f45c8"), false, "A", 1, "Fizik Bilimine Giriş - Soru 4 için Seçenek A", new Guid("e60f3c7f-c6e0-4de7-b41a-85f3726491ce") },
                    { new Guid("a68bcdb7-8b80-4003-899b-788cd3d1a141"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 2 için Seçenek C", new Guid("0a565ce3-b8da-4436-8b2d-eb941ad72d65") },
                    { new Guid("a7df86f7-e712-40c6-ad1e-e41fba7d0164"), false, "A", 1, "Kimya Bilimi - Soru 2 için Seçenek A", new Guid("07275a11-660a-4714-b144-2c1674a9159d") },
                    { new Guid("a86cad8c-7afc-4d04-8e9a-0e4cbf1569ae"), false, "B", 2, "Fizik Bilimine Giriş - Soru 4 için Seçenek B", new Guid("e60f3c7f-c6e0-4de7-b41a-85f3726491ce") },
                    { new Guid("a8f20066-fdc2-4afc-b911-6bede5c5a35e"), false, "A", 1, "Rasyonel Sayılar - Soru 5 için Seçenek A", new Guid("1fd817a1-8306-44b2-ac3f-bf4ef71886ce") },
                    { new Guid("a9cde8ff-f518-4390-bc57-739392b204f4"), false, "C", 3, "Kalıtım - Soru 1 için Seçenek C", new Guid("b53c8282-f044-46c8-ad26-74dbb03d5ff0") },
                    { new Guid("a9f8c3dc-269c-45d1-a9f4-d8ac7bdd79a8"), false, "C", 3, "Kuvvet ve Hareket - Soru 3 için Seçenek C", new Guid("ec588e29-733e-4438-91d0-69b4201f3d0f") },
                    { new Guid("aa2afcfd-32a1-4343-9004-aa410a18d182"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 1 için Seçenek D", new Guid("4e8c6825-ef2e-4a84-b4df-e79a997b1ebf") },
                    { new Guid("abb5a9d0-fb1b-46ba-bc4d-15da4c13eca6"), false, "A", 1, "Fizik Bilimine Giriş - Soru 1 için Seçenek A", new Guid("d5ed33d9-5df4-436c-a662-edf21cd368ec") },
                    { new Guid("ac78f201-71a6-4b81-b3a7-881f35fd0b14"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek C", new Guid("315fc4e1-18cc-460d-a7c3-59651596e46e") },
                    { new Guid("ace74458-30f9-4ff4-983a-6a0b0493fb9a"), false, "C", 3, "Rasyonel Sayılar - Soru 5 için Seçenek C", new Guid("1fd817a1-8306-44b2-ac3f-bf4ef71886ce") },
                    { new Guid("ad124580-393a-483d-b3fe-02ea613f15c0"), false, "A", 1, "Elektrostatik - Soru 2 için Seçenek A", new Guid("df461bc5-1fff-47d7-ac67-53a7932d87f8") },
                    { new Guid("ae8d503b-0cec-442c-8108-d487bb3dfa60"), false, "A", 1, "Kuvvet ve Hareket - Soru 2 için Seçenek A", new Guid("48cae202-0e62-464a-ad3f-1a9f14ce2746") },
                    { new Guid("af2cf579-3e0c-433d-8bfb-afabb05fac2d"), true, "B", 2, "Madde ve Özellikleri - Soru 5 için Seçenek B", new Guid("2f14c246-71a1-48f2-8276-d4fb48a28469") },
                    { new Guid("af64b82f-9d98-4f34-a497-04e338a8f30e"), true, "B", 2, "Hücre - Soru 3 için Seçenek B", new Guid("60026912-cd8a-4694-90a9-0c3cd3989a6d") },
                    { new Guid("b004da10-b529-43b9-b29b-248b309bc7da"), true, "A", 1, "Kalıtım - Soru 3 için Seçenek A", new Guid("16600417-0c21-4956-8b71-8836701774cb") },
                    { new Guid("b026a1b3-cf48-4ebb-a563-fbbcaf7f003e"), false, "A", 1, "Problemler - Soru 5 için Seçenek A", new Guid("52981242-d892-4fb2-8668-d4d76535f7a5") },
                    { new Guid("b05843ee-fec8-4732-ba5a-6a62a32bc656"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 5 için Seçenek C", new Guid("b82f518a-7e25-4385-8b2c-66a9c94e9caf") },
                    { new Guid("b07c5ab1-0123-4872-a087-3a06ad1f5339"), false, "C", 3, "Kimya Bilimi - Soru 3 için Seçenek C", new Guid("274b6607-903a-42c7-900e-ea061edad52e") },
                    { new Guid("b0c3d8aa-0546-4812-9cfd-891668c70d81"), true, "A", 1, "Bölme ve Bölünebilme - Soru 1 için Seçenek A", new Guid("ab9797d5-33ce-47ee-8182-e0749480d66c") },
                    { new Guid("b0f3b36c-a62b-43bb-9e76-92154029f04d"), false, "B", 2, "İş, Güç ve Enerji - Soru 2 için Seçenek B", new Guid("3967e945-ec12-4f05-be4c-6016a89a4a94") },
                    { new Guid("b16b65bc-6d1c-42b5-b74b-7de4a8f80af7"), true, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek B", new Guid("f52f1673-08db-494e-a009-6dcb47af9554") },
                    { new Guid("b181cb3e-cf94-4ffe-94ee-b4152e5df99a"), false, "D", 4, "Sayı Basamakları - Soru 1 için Seçenek D", new Guid("c3e31727-3b5b-4eba-8b75-fcb4cc8c5626") },
                    { new Guid("b19d7496-e0fa-47ef-9753-92a47141a23a"), false, "B", 2, "İş, Güç ve Enerji - Soru 5 için Seçenek B", new Guid("838bf26e-e88a-4052-8898-25db3513e15e") },
                    { new Guid("b225e171-b98f-4d2e-b17c-4cac003838a2"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek D", new Guid("315fc4e1-18cc-460d-a7c3-59651596e46e") },
                    { new Guid("b2f13bfb-3ef5-4a0e-80eb-14abf379f5d5"), true, "A", 1, "Hücre Bölünmeleri - Soru 2 için Seçenek A", new Guid("fad08b48-b804-47b3-a126-637fdf4a8c96") },
                    { new Guid("b36a9adb-83bd-475b-83cc-cfb5a6686708"), false, "D", 4, "Kalıtım - Soru 3 için Seçenek D", new Guid("16600417-0c21-4956-8b71-8836701774cb") },
                    { new Guid("b3a94232-2a64-4cf1-bdc3-6be4c413e99c"), false, "A", 1, "Kalıtım - Soru 1 için Seçenek A", new Guid("b53c8282-f044-46c8-ad26-74dbb03d5ff0") },
                    { new Guid("b3c4699f-2418-47ab-a23a-72300a758899"), false, "C", 3, "Temel Kavramlar - Soru 1 için Seçenek C", new Guid("ed6444ac-a1a1-4b44-9144-e65fc06c2653") },
                    { new Guid("b3d699c8-846b-4454-98b6-fdd4bc8e662a"), false, "B", 2, "İş, Güç ve Enerji - Soru 4 için Seçenek B", new Guid("b24819d9-5825-4306-9c92-1722bf73cd3b") },
                    { new Guid("b471b965-b282-4850-a674-b7c51e0fa49a"), false, "B", 2, "Problemler - Soru 3 için Seçenek B", new Guid("0524f2d8-80c7-4c07-b88a-51f5732988e5") },
                    { new Guid("b4c75842-22b8-4c0c-8ceb-4cbd7db5f9df"), false, "C", 3, "Kalıtım - Soru 2 için Seçenek C", new Guid("17765af3-d439-4c62-b2ea-ae0d78373d0f") },
                    { new Guid("b69f6c5a-56ac-42c6-8930-2567169014f9"), false, "C", 3, "Hücre Bölünmeleri - Soru 2 için Seçenek C", new Guid("fad08b48-b804-47b3-a126-637fdf4a8c96") },
                    { new Guid("b9682d6b-b653-4891-9621-830cd7a7bce2"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek A", new Guid("9e0ddce5-c1fb-4f04-ae65-d9f5cafc0f0f") },
                    { new Guid("b9fc6b35-ed88-4496-aa20-111538a91397"), false, "C", 3, "Hücre - Soru 5 için Seçenek C", new Guid("55f44740-8550-4b7a-8941-a65422e2c2f9") },
                    { new Guid("ba19c08d-aa4d-4b61-8dd3-176c9599b346"), true, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek A", new Guid("c447bbe5-9ced-4be4-bac4-7246b14cba0e") },
                    { new Guid("bb449056-437a-4636-8706-f4dc1e2d3686"), false, "B", 2, "Kimya Bilimi - Soru 2 için Seçenek B", new Guid("07275a11-660a-4714-b144-2c1674a9159d") },
                    { new Guid("bb619536-7a50-4044-8e62-ceb60ae7434b"), true, "B", 2, "Hücre - Soru 5 için Seçenek B", new Guid("55f44740-8550-4b7a-8941-a65422e2c2f9") },
                    { new Guid("bbabe5db-7d4c-4046-9821-7385799576e1"), true, "B", 2, "Kimya Bilimi - Soru 4 için Seçenek B", new Guid("11958f01-663f-4eca-a5ef-42220b832f48") },
                    { new Guid("bd63c31a-7d5e-4e61-bc95-3ba864f9ed9c"), false, "D", 4, "Fizik Bilimine Giriş - Soru 3 için Seçenek D", new Guid("ad728e0b-7834-4836-b1b2-18e581e0b43f") },
                    { new Guid("be53ed2c-7fde-4ed0-8d9d-0de383d2b61d"), true, "D", 4, "Problemler - Soru 2 için Seçenek D", new Guid("d1a60363-f78b-4a2b-8602-b227955b75f0") },
                    { new Guid("befb8b6b-ac4a-41bd-addb-0e093d58a257"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek C", new Guid("7daf99b2-789c-4534-a5e4-d19019a227c8") },
                    { new Guid("bf11ddc3-a775-47a3-a4ff-fd8b2fe0163f"), false, "A", 1, "Problemler - Soru 4 için Seçenek A", new Guid("8ef3a8e2-fde1-4419-b3e3-6a2ccbe4683b") },
                    { new Guid("bfa6fcc0-8214-4e38-821e-208167f07028"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 4 için Seçenek A", new Guid("7e402648-3316-48ad-8a99-3c04f0c9f847") },
                    { new Guid("bfc05ab0-272f-4623-b561-96e92f7b1547"), true, "D", 4, "Maddenin Halleri - Soru 1 için Seçenek D", new Guid("77f2cb9e-b745-4a2d-bfd3-be1190da2295") },
                    { new Guid("c08ef72a-8160-48c6-b396-b0d5501ea297"), false, "A", 1, "Rasyonel Sayılar - Soru 2 için Seçenek A", new Guid("9cd4f04f-af2f-47bd-a5d9-b66d214375aa") },
                    { new Guid("c1961d17-bcd4-477b-86cd-d0de44571b66"), false, "C", 3, "Problemler - Soru 1 için Seçenek C", new Guid("4ebd85e6-72a7-4898-9475-77fc5cf18969") },
                    { new Guid("c239c83f-1440-4e02-b58b-ccf5b60acb4d"), false, "C", 3, "Hücre Bölünmeleri - Soru 4 için Seçenek C", new Guid("329c6d37-5ea1-4baf-9b1c-8abdae9c8381") },
                    { new Guid("c43f9fe9-398b-481b-96c9-e79aa2265a83"), false, "A", 1, "Rasyonel Sayılar - Soru 3 için Seçenek A", new Guid("1bb03557-0d91-4b37-9731-fe25a5dcc1b4") },
                    { new Guid("c44175e4-e6aa-421e-ba6f-28b762b646b9"), false, "D", 4, "Kuvvet ve Hareket - Soru 5 için Seçenek D", new Guid("8ba8eb31-eb0e-4e91-b68f-fc65e029cac2") },
                    { new Guid("c6a32005-407e-4258-bfec-d78b395b9b12"), false, "B", 2, "Sayı Basamakları - Soru 2 için Seçenek B", new Guid("95d5c966-00f8-4753-a22b-2b58c529d327") },
                    { new Guid("c720e79e-9b3d-4266-bf96-57384f745603"), false, "B", 2, "Maddenin Halleri - Soru 3 için Seçenek B", new Guid("bf5118dc-a49f-4284-bc15-be183f6c19a5") },
                    { new Guid("c7e20b50-c05a-4e4c-84eb-dc6eafa27ad7"), true, "B", 2, "Sayı Basamakları - Soru 3 için Seçenek B", new Guid("98a326c7-9c4c-471d-b210-b0c00568d00a") },
                    { new Guid("c82aaa91-4c77-4aa4-84cb-fa5b1f3123a0"), true, "D", 4, "Kimya Bilimi - Soru 2 için Seçenek D", new Guid("07275a11-660a-4714-b144-2c1674a9159d") },
                    { new Guid("c852e1d3-4894-458c-8879-0dbbd822beae"), false, "B", 2, "Maddenin Halleri - Soru 4 için Seçenek B", new Guid("7cccb9c6-1eaf-4ca4-ad14-2036250fffca") },
                    { new Guid("c88fa605-ecff-4dcd-a479-0360403ed0aa"), false, "A", 1, "Bölme ve Bölünebilme - Soru 3 için Seçenek A", new Guid("dc391e77-0e4c-488e-92fc-df6ca45032b5") },
                    { new Guid("caaf14ec-c7b8-4fc5-b36e-9db8d75bda06"), false, "C", 3, "Temel Kavramlar - Soru 2 için Seçenek C", new Guid("c7d4589c-296c-4b07-b561-0f8f99c862d3") },
                    { new Guid("cb210669-e74f-4bfb-a311-25654e024644"), true, "C", 3, "Fizik Bilimine Giriş - Soru 3 için Seçenek C", new Guid("ad728e0b-7834-4836-b1b2-18e581e0b43f") },
                    { new Guid("cb34a1f4-73b0-4c3f-b21b-2a8e939895db"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 3 için Seçenek D", new Guid("3995ec03-77a8-429e-b07b-a22cf5734e96") },
                    { new Guid("cc37df18-ae47-45c9-8fcf-4f9a5ee12760"), false, "C", 3, "Problemler - Soru 2 için Seçenek C", new Guid("d1a60363-f78b-4a2b-8602-b227955b75f0") },
                    { new Guid("cc78f35a-8ad3-436d-985c-e2fe5ddc6fe4"), true, "A", 1, "Elektrostatik - Soru 3 için Seçenek A", new Guid("ea0bd87d-8f54-45de-9ff3-c7345e796663") },
                    { new Guid("cd12b50f-7db9-415b-b822-cef65d75aa7e"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 3 için Seçenek C", new Guid("5860549a-484e-4ae1-967f-a4f8534d20f8") },
                    { new Guid("ce7b8148-76f2-41bd-860b-7184e4ffed94"), false, "D", 4, "İş, Güç ve Enerji - Soru 5 için Seçenek D", new Guid("838bf26e-e88a-4052-8898-25db3513e15e") },
                    { new Guid("d1496b86-d1b2-48d3-ad5a-a9b66b322436"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 5 için Seçenek A", new Guid("6e7bf6b0-7ea4-41cc-9e48-6fa86ba52409") },
                    { new Guid("d241a825-0f34-48f5-9201-7ca915435414"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 4 için Seçenek D", new Guid("44f68edd-eafe-461f-9982-75e41c7a4968") },
                    { new Guid("d2686e38-56fc-4842-8fbf-4615a862f90c"), true, "B", 2, "Madde ve Özellikleri - Soru 1 için Seçenek B", new Guid("225ceec4-b0b4-440d-b780-b7a8488a61ac") },
                    { new Guid("d3336da4-b002-40ff-9f77-7ba1beda2707"), false, "A", 1, "Problemler - Soru 2 için Seçenek A", new Guid("d1a60363-f78b-4a2b-8602-b227955b75f0") },
                    { new Guid("d43ee26b-8577-4c6b-b8b3-b8de8c1f117a"), true, "B", 2, "Problemler - Soru 5 için Seçenek B", new Guid("52981242-d892-4fb2-8668-d4d76535f7a5") },
                    { new Guid("d4685baf-76e8-428f-bc22-1fc735eb5803"), false, "B", 2, "Kalıtım - Soru 2 için Seçenek B", new Guid("17765af3-d439-4c62-b2ea-ae0d78373d0f") },
                    { new Guid("d4a4d421-9bf0-4cb8-9c29-6e3c7a452bec"), true, "D", 4, "Hücre Bölünmeleri - Soru 4 için Seçenek D", new Guid("329c6d37-5ea1-4baf-9b1c-8abdae9c8381") },
                    { new Guid("d6e177fe-5095-47f6-b21c-9d878fdfeed2"), false, "B", 2, "Hücre - Soru 4 için Seçenek B", new Guid("5a6c14d0-a73a-4ec7-8979-5fe94c6c2043") },
                    { new Guid("d868fb16-1ef6-4081-b89a-c7f89fad6641"), false, "A", 1, "Temel Kavramlar - Soru 5 için Seçenek A", new Guid("aede6a92-7d08-4be0-80d9-e9caf151ab38") },
                    { new Guid("d870eb1a-d32e-451f-b88f-6b0aac698859"), true, "A", 1, "İş, Güç ve Enerji - Soru 1 için Seçenek A", new Guid("79d4ebf5-b53e-4645-b7ec-58e222f87dc3") },
                    { new Guid("d8a2e2cd-e8b3-464b-a92a-5c0816f05dc7"), true, "D", 4, "Hücre - Soru 2 için Seçenek D", new Guid("151a454e-0914-4dca-ab49-55d9b3b56d15") },
                    { new Guid("d945700b-1fb8-48a5-b208-5c7e12448818"), false, "B", 2, "Problemler - Soru 4 için Seçenek B", new Guid("8ef3a8e2-fde1-4419-b3e3-6a2ccbe4683b") },
                    { new Guid("d98866b2-fc7a-4a53-999d-6150daf342ae"), true, "A", 1, "Bölme ve Bölünebilme - Soru 4 için Seçenek A", new Guid("f76d06a7-1c86-4197-a209-bb9c4e3e1413") },
                    { new Guid("da052d69-c568-40fa-922b-e36945c8c297"), false, "C", 3, "Hücre - Soru 3 için Seçenek C", new Guid("60026912-cd8a-4694-90a9-0c3cd3989a6d") },
                    { new Guid("da87a9fc-0eda-4ea3-86eb-cfd314073f2b"), false, "B", 2, "Hücre Bölünmeleri - Soru 2 için Seçenek B", new Guid("fad08b48-b804-47b3-a126-637fdf4a8c96") },
                    { new Guid("daa0c8c2-0751-4517-abf7-ecfe161ec409"), false, "D", 4, "Hücre - Soru 5 için Seçenek D", new Guid("55f44740-8550-4b7a-8941-a65422e2c2f9") },
                    { new Guid("db2512bf-7c87-47f7-b05e-495b39bd7e41"), false, "D", 4, "Temel Kavramlar - Soru 4 için Seçenek D", new Guid("d1e342f3-2e64-47f0-b50f-8a030a9671f3") },
                    { new Guid("dbf86dda-c4bd-4055-93e8-668902b93997"), false, "D", 4, "Elektrostatik - Soru 1 için Seçenek D", new Guid("77e44df7-dfdb-4d61-a723-8c3353a0660d") },
                    { new Guid("dc25497e-647f-49fe-91c9-ed241157eed5"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek C", new Guid("1c1d3c18-e572-4b53-a412-4eaa3a6d7362") },
                    { new Guid("dc5970bb-c686-4023-b861-ee77f8f4acb6"), true, "B", 2, "Kimya Bilimi - Soru 3 için Seçenek B", new Guid("274b6607-903a-42c7-900e-ea061edad52e") },
                    { new Guid("dc66b1b0-923f-4f1f-995c-cbac8028f17b"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek A", new Guid("7b1c5aca-a3b7-4b81-ba92-d27b648df07b") },
                    { new Guid("dda53d11-b2dd-4921-9daa-f6e35f3235c0"), true, "D", 4, "Kalıtım - Soru 2 için Seçenek D", new Guid("17765af3-d439-4c62-b2ea-ae0d78373d0f") },
                    { new Guid("ddeaf2bd-bcb6-425d-a368-1d79e8941b98"), false, "B", 2, "Hücre Bölünmeleri - Soru 3 için Seçenek B", new Guid("2a0ca876-c54c-4366-9557-33d6fe888052") },
                    { new Guid("de7b5de4-6b66-4ee2-9117-eb6ad969e0ed"), false, "A", 1, "Fizik Bilimine Giriş - Soru 3 için Seçenek A", new Guid("ad728e0b-7834-4836-b1b2-18e581e0b43f") },
                    { new Guid("df273846-51e0-449b-8561-34499745afb4"), false, "A", 1, "Elektrostatik - Soru 1 için Seçenek A", new Guid("77e44df7-dfdb-4d61-a723-8c3353a0660d") },
                    { new Guid("e0c3f378-805c-4e43-8db1-47ff5de0cad3"), false, "B", 2, "Maddenin Halleri - Soru 2 için Seçenek B", new Guid("43de3d81-a894-4688-8526-ed5d16b1928e") },
                    { new Guid("e1216e37-8693-4a20-b898-99885ac42ab4"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek B", new Guid("2fb3c924-ac51-49b9-9e68-e858edcb1833") },
                    { new Guid("e194bfb9-8b70-411e-af1f-217be50f7cbc"), true, "C", 3, "Sayı Basamakları - Soru 1 için Seçenek C", new Guid("c3e31727-3b5b-4eba-8b75-fcb4cc8c5626") },
                    { new Guid("e1b8ec83-2d63-49d4-86e3-1965ca173d7d"), false, "C", 3, "Rasyonel Sayılar - Soru 3 için Seçenek C", new Guid("1bb03557-0d91-4b37-9731-fe25a5dcc1b4") },
                    { new Guid("e31dec53-3866-4d32-b6eb-805b630a4387"), false, "A", 1, "Maddenin Halleri - Soru 5 için Seçenek A", new Guid("e8f8a3f9-aff2-497f-8869-1a4389988c32") },
                    { new Guid("e35c4539-f7ee-4b7d-a3cc-adb4e85528bb"), false, "D", 4, "Madde ve Özellikleri - Soru 5 için Seçenek D", new Guid("2f14c246-71a1-48f2-8276-d4fb48a28469") },
                    { new Guid("e44bf72b-9614-490f-b798-2e441c6f9694"), false, "A", 1, "Madde ve Özellikleri - Soru 5 için Seçenek A", new Guid("2f14c246-71a1-48f2-8276-d4fb48a28469") },
                    { new Guid("e5a088cd-c6f1-45ba-b609-af843d2a74da"), false, "D", 4, "Rasyonel Sayılar - Soru 4 için Seçenek D", new Guid("e1c80035-16a5-4648-af08-e4a45011f04c") },
                    { new Guid("e5a9bbc3-b89a-45c3-9578-f9c9b8e54a1f"), true, "A", 1, "Kimya Bilimi - Soru 1 için Seçenek A", new Guid("2a88c66c-63d7-42ba-a09e-5cbb90c1f40e") },
                    { new Guid("e70e808d-aa4b-44b8-a9a9-518fa2865a91"), false, "C", 3, "Kimya Bilimi - Soru 4 için Seçenek C", new Guid("11958f01-663f-4eca-a5ef-42220b832f48") },
                    { new Guid("e7158807-b34e-4d49-86c4-bdd1843698dd"), true, "C", 3, "Rasyonel Sayılar - Soru 4 için Seçenek C", new Guid("e1c80035-16a5-4648-af08-e4a45011f04c") },
                    { new Guid("e7470acc-0e5d-44da-94c4-00d8c847a0a1"), false, "B", 2, "Kuvvet ve Hareket - Soru 2 için Seçenek B", new Guid("48cae202-0e62-464a-ad3f-1a9f14ce2746") },
                    { new Guid("e78c7b4b-e11d-46f3-a76f-d3eef9e5b820"), false, "B", 2, "Elektrostatik - Soru 3 için Seçenek B", new Guid("ea0bd87d-8f54-45de-9ff3-c7345e796663") },
                    { new Guid("e7d0b066-a608-4aae-9e6d-7cd719275c02"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek B", new Guid("315fc4e1-18cc-460d-a7c3-59651596e46e") },
                    { new Guid("e7e9e0b7-556d-44dc-86e5-33c92397eeb5"), true, "C", 3, "İş, Güç ve Enerji - Soru 4 için Seçenek C", new Guid("b24819d9-5825-4306-9c92-1722bf73cd3b") },
                    { new Guid("e9b99b9b-1aed-4fc1-abbf-bcf4daa18d77"), false, "A", 1, "Temel Kavramlar - Soru 3 için Seçenek A", new Guid("2e942ef6-bd04-465e-b48b-9198da3ed184") },
                    { new Guid("eacfdc8e-e520-454a-aabb-fd576b2073d3"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek B", new Guid("9e0ddce5-c1fb-4f04-ae65-d9f5cafc0f0f") },
                    { new Guid("ebfe0e7e-8760-4674-88ac-71885fd4a6ba"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 3 için Seçenek A", new Guid("5860549a-484e-4ae1-967f-a4f8534d20f8") },
                    { new Guid("ec767ff5-72c3-40c1-b5e4-4c8086d6ad4c"), false, "B", 2, "Problemler - Soru 2 için Seçenek B", new Guid("d1a60363-f78b-4a2b-8602-b227955b75f0") },
                    { new Guid("ed4a783f-fcf1-402f-a16f-248db455474e"), true, "D", 4, "Problemler - Soru 4 için Seçenek D", new Guid("8ef3a8e2-fde1-4419-b3e3-6a2ccbe4683b") },
                    { new Guid("ede2e526-c985-4f12-9ef9-25b2f553ec57"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 4 için Seçenek C", new Guid("7e402648-3316-48ad-8a99-3c04f0c9f847") },
                    { new Guid("ee801c7b-ecda-4376-950d-ece720acf0ef"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek D", new Guid("f2250006-16b9-498a-be20-361d3378dd71") },
                    { new Guid("eedbe346-139c-42f0-bb7b-09a4d41bbf3a"), false, "B", 2, "Madde ve Özellikleri - Soru 3 için Seçenek B", new Guid("55c170dd-bd95-453d-aef9-677e0765cb15") },
                    { new Guid("ef01eac9-d228-4905-80d9-a750ed079250"), false, "A", 1, "Hücre - Soru 4 için Seçenek A", new Guid("5a6c14d0-a73a-4ec7-8979-5fe94c6c2043") },
                    { new Guid("ef68572b-e87d-4bc1-a58c-67ff5de6b645"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek A", new Guid("9433fa3c-3702-45ff-a914-d09197cffd17") },
                    { new Guid("ef8eb74e-3bef-4f7f-8289-e535c8ca2598"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek D", new Guid("c447bbe5-9ced-4be4-bac4-7246b14cba0e") },
                    { new Guid("f0511822-c701-4eb8-aedc-1a5fccf979f9"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek C", new Guid("f52f1673-08db-494e-a009-6dcb47af9554") },
                    { new Guid("f0cd7a24-c83d-4d64-bb7b-50cfef330819"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek D", new Guid("7b1c5aca-a3b7-4b81-ba92-d27b648df07b") },
                    { new Guid("f0e44ed0-812f-4dbd-9632-385a271f601f"), false, "B", 2, "Maddenin Halleri - Soru 1 için Seçenek B", new Guid("77f2cb9e-b745-4a2d-bfd3-be1190da2295") },
                    { new Guid("f0f4cda0-b2c4-40ca-939d-eb16ad6c060a"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 1 için Seçenek D", new Guid("b339af85-4343-42e0-a6bb-e5b4ca444d08") },
                    { new Guid("f13342f4-8d72-4cc3-ae33-7287fe49e210"), false, "C", 3, "Rasyonel Sayılar - Soru 1 için Seçenek C", new Guid("efa1641f-c3c6-4b3d-970b-14b2eed93579") },
                    { new Guid("f298796a-4c91-4d07-906b-f74be76cfe0f"), false, "A", 1, "Hücre Bölünmeleri - Soru 3 için Seçenek A", new Guid("2a0ca876-c54c-4366-9557-33d6fe888052") },
                    { new Guid("f31dc533-5774-4062-8dfc-ff7f21900c4b"), false, "B", 2, "Kuvvet ve Hareket - Soru 4 için Seçenek B", new Guid("8ed7249f-399d-4734-8ec4-3accac46a47c") },
                    { new Guid("f5d5da81-bee9-4f93-a116-ef06753943dd"), false, "A", 1, "Hücre Bölünmeleri - Soru 5 için Seçenek A", new Guid("c3b66419-ea81-429a-a067-f4059e6e557b") },
                    { new Guid("f654857b-bedd-47ab-a948-1269287f768f"), true, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek B", new Guid("995b4610-29cc-47a1-a7e9-45f09a9ec050") },
                    { new Guid("f70faa86-aa69-4dd7-965b-06acaf89dfb1"), false, "D", 4, "Fizik Bilimine Giriş - Soru 1 için Seçenek D", new Guid("d5ed33d9-5df4-436c-a662-edf21cd368ec") },
                    { new Guid("f719ffa8-19eb-4b44-b42d-2d632af5bcc8"), false, "A", 1, "Fizik Bilimine Giriş - Soru 5 için Seçenek A", new Guid("9e99054e-413b-4298-a560-ac01394facfc") },
                    { new Guid("f7585a71-6270-4647-bd90-60c8efe4dd98"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek B", new Guid("fef58697-43c2-4923-8855-eecab92b797a") },
                    { new Guid("f93df094-5295-49da-9d2a-4198e285d696"), false, "B", 2, "Fizik Bilimine Giriş - Soru 1 için Seçenek B", new Guid("d5ed33d9-5df4-436c-a662-edf21cd368ec") },
                    { new Guid("f9fb092e-b2ef-4d7c-bb6a-2668980540d6"), true, "A", 1, "İş, Güç ve Enerji - Soru 5 için Seçenek A", new Guid("838bf26e-e88a-4052-8898-25db3513e15e") },
                    { new Guid("fa6c49a0-39b0-4015-abc7-aa568b153bdd"), false, "A", 1, "Kimya Bilimi - Soru 3 için Seçenek A", new Guid("274b6607-903a-42c7-900e-ea061edad52e") },
                    { new Guid("fab4e948-8039-442c-8dd3-df8636cc061a"), true, "C", 3, "Elektrostatik - Soru 5 için Seçenek C", new Guid("933a962a-660c-46d6-b34f-07e5760b5be0") },
                    { new Guid("fb6affac-3ebf-4720-8cf2-4673e781ab8e"), false, "D", 4, "Hücre - Soru 1 için Seçenek D", new Guid("82fbf916-01e1-4522-a9cd-4232a55df333") },
                    { new Guid("fc08afbd-964e-4d12-9fdc-d12e253726be"), true, "D", 4, "Rasyonel Sayılar - Soru 2 için Seçenek D", new Guid("9cd4f04f-af2f-47bd-a5d9-b66d214375aa") },
                    { new Guid("fc238afd-25dd-4b8a-a5fb-9dd46ada1583"), true, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek A", new Guid("39088d66-ff18-446e-9f09-6ad742386041") },
                    { new Guid("fc31476b-449c-4c0c-9e60-8dfe879d4435"), false, "D", 4, "Elektrostatik - Soru 3 için Seçenek D", new Guid("ea0bd87d-8f54-45de-9ff3-c7345e796663") },
                    { new Guid("fc5ef8a7-1d28-4299-8d9a-d623f46ebe42"), false, "B", 2, "Bölme ve Bölünebilme - Soru 1 için Seçenek B", new Guid("ab9797d5-33ce-47ee-8182-e0749480d66c") },
                    { new Guid("fc78f656-0392-4bc8-9cbc-0e6aa60323fa"), false, "A", 1, "Bölme ve Bölünebilme - Soru 5 için Seçenek A", new Guid("a1448740-7497-45e3-a2d6-edd5b1105377") },
                    { new Guid("fdcd31a7-813f-43fb-ac08-185d23d65b65"), true, "D", 4, "Temel Kavramlar - Soru 1 için Seçenek D", new Guid("ed6444ac-a1a1-4b44-9144-e65fc06c2653") },
                    { new Guid("fdee0faf-1344-4a16-9794-f420f43d4c48"), false, "C", 3, "Bölme ve Bölünebilme - Soru 3 için Seçenek C", new Guid("dc391e77-0e4c-488e-92fc-df6ca45032b5") },
                    { new Guid("fe8715bc-c7c2-4406-8305-3628e46b254f"), true, "A", 1, "Sayı Basamakları - Soru 5 için Seçenek A", new Guid("f93a1338-cbca-484b-88ef-dc23b74cae9e") },
                    { new Guid("fea7a431-17c4-4e59-863d-79253b21ab8a"), false, "C", 3, "Hücre - Soru 4 için Seçenek C", new Guid("5a6c14d0-a73a-4ec7-8979-5fe94c6c2043") },
                    { new Guid("fef62d54-59e2-45a4-84f4-2fdaa58b8217"), false, "B", 2, "Fizik Bilimine Giriş - Soru 3 için Seçenek B", new Guid("ad728e0b-7834-4836-b1b2-18e581e0b43f") },
                    { new Guid("ffccd99a-3636-4328-b291-def57f4b3cfd"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek B", new Guid("f2250006-16b9-498a-be20-361d3378dd71") }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ParentTopicId", "SubjectId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("2ab01677-fbfe-485a-a635-639ad2ef2dc3"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2832), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "İş, Güç ve Enerji" },
                    { new Guid("5cb1c2eb-5f9f-4894-bf01-36a463a00dd0"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2880), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Kalıtım" },
                    { new Guid("6705c61a-8c99-45de-bf0c-0b0599efa3bc"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2834), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Elektrostatik" },
                    { new Guid("70abd9c0-ad11-44b7-a3f5-e81f924b9e0f"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2850), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Yaşam Bilimi Biyoloji" },
                    { new Guid("73328357-7dd8-4a7b-b3b1-46b0682a7f73"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2852), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre" },
                    { new Guid("73d26d61-bd67-437e-a53b-7f0d96610711"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2805), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Sayı Basamakları" },
                    { new Guid("7a9d5e75-b024-4608-8131-f1956ebafe91"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2807), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Bölme ve Bölünebilme" },
                    { new Guid("84da2c2f-5923-4b7c-8ea0-d0ed314aa1da"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2845), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Maddenin Halleri" },
                    { new Guid("8876eb2a-b519-4376-889c-3cbc9c40a0d3"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2841), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Atom ve Periyodik Sistem" },
                    { new Guid("8da06326-a19b-42c3-85eb-9978d6bd1275"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2843), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimyasal Türler Arası Etkileşimler" },
                    { new Guid("9902a38b-eb9b-4a02-93f2-98dfe8ba6e60"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2830), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Kuvvet ve Hareket" },
                    { new Guid("a2dd4008-8c63-4d43-b46f-b1b3c2f0b39b"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2826), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Fizik Bilimine Giriş" },
                    { new Guid("a36519c0-a98d-4afd-b570-25088049de30"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2838), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Kimya Bilimi" },
                    { new Guid("a59b3cc8-0880-4b40-88e5-882162042718"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2854), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Canlıların Sınıflandırılması" },
                    { new Guid("b46c75d4-a4cd-46c3-9ff2-6a8ff5a8e927"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2828), true, null, new Guid("7ed69d3c-87ab-44d9-b863-61219df3a23e"), "Madde ve Özellikleri" },
                    { new Guid("b817df9c-6236-4028-8d6e-835a9d612742"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2818), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Rasyonel Sayılar" },
                    { new Guid("bab4bf49-7aaf-4640-b7b9-ea3b6ce91996"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2847), true, null, new Guid("7580abcc-0b61-4569-8a54-953195b09a4d"), "Asitler, Bazlar ve Tuzlar" },
                    { new Guid("c27d90eb-c47f-4e91-8366-ee753fd1f319"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2802), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Temel Kavramlar" },
                    { new Guid("f058ffed-24bf-404c-b7b1-3cb773d49166"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2856), true, null, new Guid("da61c306-0160-49db-92b6-eaa8418a2f8c"), "Hücre Bölünmeleri" },
                    { new Guid("fa8e0739-23a4-4c29-a9d3-1f34b93a40a1"), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(2820), true, null, new Guid("f458884d-bb86-46a8-a604-5beb8469a5a8"), "Problemler" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsTopics",
                columns: new[] { "QuestionId", "TopicId", "Id" },
                values: new object[,]
                {
                    { new Guid("0225dd79-44d5-4896-8535-4dd7a224c0bd"), new Guid("a59b3cc8-0880-4b40-88e5-882162042718"), new Guid("593684ac-ad94-42cb-af0d-45dc53643f33") },
                    { new Guid("0524f2d8-80c7-4c07-b88a-51f5732988e5"), new Guid("fa8e0739-23a4-4c29-a9d3-1f34b93a40a1"), new Guid("8ea7536a-3259-4188-a4f1-47af6b89e787") },
                    { new Guid("07275a11-660a-4714-b144-2c1674a9159d"), new Guid("a36519c0-a98d-4afd-b570-25088049de30"), new Guid("789d3aa1-b7a0-4e4a-8201-a7990d33c8dc") },
                    { new Guid("0a565ce3-b8da-4436-8b2d-eb941ad72d65"), new Guid("8876eb2a-b519-4376-889c-3cbc9c40a0d3"), new Guid("dbd30c51-b4ea-4906-8ff3-fe01306b7191") },
                    { new Guid("11958f01-663f-4eca-a5ef-42220b832f48"), new Guid("a36519c0-a98d-4afd-b570-25088049de30"), new Guid("d631f937-a47d-4c79-97bf-92496013b803") },
                    { new Guid("151a454e-0914-4dca-ab49-55d9b3b56d15"), new Guid("73328357-7dd8-4a7b-b3b1-46b0682a7f73"), new Guid("1bf728cd-bd77-4760-a66c-644270a56413") },
                    { new Guid("16600417-0c21-4956-8b71-8836701774cb"), new Guid("5cb1c2eb-5f9f-4894-bf01-36a463a00dd0"), new Guid("53fbdc7f-6bf0-4b09-8403-535dff843e15") },
                    { new Guid("16ff1bef-c628-4282-b9d4-4f904dfe26f9"), new Guid("6705c61a-8c99-45de-bf0c-0b0599efa3bc"), new Guid("9b3f5860-1ddc-4d95-aeca-b9e45e7bde76") },
                    { new Guid("17765af3-d439-4c62-b2ea-ae0d78373d0f"), new Guid("5cb1c2eb-5f9f-4894-bf01-36a463a00dd0"), new Guid("63031bdc-ff23-4bd0-98f2-752a793068e5") },
                    { new Guid("1bb03557-0d91-4b37-9731-fe25a5dcc1b4"), new Guid("b817df9c-6236-4028-8d6e-835a9d612742"), new Guid("990fe429-8703-432f-84b5-6932e87838bf") },
                    { new Guid("1c1d3c18-e572-4b53-a412-4eaa3a6d7362"), new Guid("8da06326-a19b-42c3-85eb-9978d6bd1275"), new Guid("b0280fd8-c17a-4396-87f5-cfec54ba4713") },
                    { new Guid("1fd817a1-8306-44b2-ac3f-bf4ef71886ce"), new Guid("b817df9c-6236-4028-8d6e-835a9d612742"), new Guid("587fbac3-d52c-4a08-8c03-9056b4a49c68") },
                    { new Guid("225ceec4-b0b4-440d-b780-b7a8488a61ac"), new Guid("b46c75d4-a4cd-46c3-9ff2-6a8ff5a8e927"), new Guid("186b26c0-2a98-4440-933c-db53c33ba023") },
                    { new Guid("274b6607-903a-42c7-900e-ea061edad52e"), new Guid("a36519c0-a98d-4afd-b570-25088049de30"), new Guid("88b17860-0f06-4439-a9b4-825587ccad03") },
                    { new Guid("2a0ca876-c54c-4366-9557-33d6fe888052"), new Guid("f058ffed-24bf-404c-b7b1-3cb773d49166"), new Guid("dd036b42-9d15-4179-9849-0271f19c4b3a") },
                    { new Guid("2a88c66c-63d7-42ba-a09e-5cbb90c1f40e"), new Guid("a36519c0-a98d-4afd-b570-25088049de30"), new Guid("312e8f80-11ed-4a47-abf9-efff0c9d7c7f") },
                    { new Guid("2e942ef6-bd04-465e-b48b-9198da3ed184"), new Guid("c27d90eb-c47f-4e91-8366-ee753fd1f319"), new Guid("50ee918a-7c5d-4db7-9503-40862f87ff76") },
                    { new Guid("2f14c246-71a1-48f2-8276-d4fb48a28469"), new Guid("b46c75d4-a4cd-46c3-9ff2-6a8ff5a8e927"), new Guid("15200ed6-5843-4e18-9a58-e46fbd69d043") },
                    { new Guid("2fb3c924-ac51-49b9-9e68-e858edcb1833"), new Guid("70abd9c0-ad11-44b7-a3f5-e81f924b9e0f"), new Guid("f3ae1d11-2187-44a5-b4b8-bcd3fa755886") },
                    { new Guid("315fc4e1-18cc-460d-a7c3-59651596e46e"), new Guid("8da06326-a19b-42c3-85eb-9978d6bd1275"), new Guid("ff00bbda-2891-406c-a0a7-aaa0cb096b77") },
                    { new Guid("329c6d37-5ea1-4baf-9b1c-8abdae9c8381"), new Guid("f058ffed-24bf-404c-b7b1-3cb773d49166"), new Guid("e04b4327-5bdc-4fc8-9ce1-a1984dfce653") },
                    { new Guid("39088d66-ff18-446e-9f09-6ad742386041"), new Guid("bab4bf49-7aaf-4640-b7b9-ea3b6ce91996"), new Guid("10684f9b-0615-4a2b-a5d4-6e4aee29271f") },
                    { new Guid("3967e945-ec12-4f05-be4c-6016a89a4a94"), new Guid("2ab01677-fbfe-485a-a635-639ad2ef2dc3"), new Guid("fd53b2a5-1594-4574-bdb7-6992e49b1be6") },
                    { new Guid("3995ec03-77a8-429e-b07b-a22cf5734e96"), new Guid("8876eb2a-b519-4376-889c-3cbc9c40a0d3"), new Guid("d3761f41-f177-4f80-bdf7-41aa9c31740a") },
                    { new Guid("43de3d81-a894-4688-8526-ed5d16b1928e"), new Guid("84da2c2f-5923-4b7c-8ea0-d0ed314aa1da"), new Guid("60948b24-5103-4082-bda2-ba68b5f9fd3f") },
                    { new Guid("44f68edd-eafe-461f-9982-75e41c7a4968"), new Guid("8876eb2a-b519-4376-889c-3cbc9c40a0d3"), new Guid("0eebd5ab-178b-4923-a428-02364bc56b38") },
                    { new Guid("48cae202-0e62-464a-ad3f-1a9f14ce2746"), new Guid("9902a38b-eb9b-4a02-93f2-98dfe8ba6e60"), new Guid("1b0c9faf-6634-4ec6-a02a-b302709a497b") },
                    { new Guid("490f660a-c379-42c0-b719-2ba4624e93ca"), new Guid("a36519c0-a98d-4afd-b570-25088049de30"), new Guid("1c2b1265-e4fa-46af-a38f-134e88861f78") },
                    { new Guid("4e8c6825-ef2e-4a84-b4df-e79a997b1ebf"), new Guid("8876eb2a-b519-4376-889c-3cbc9c40a0d3"), new Guid("d2116604-bdde-4445-9571-7ab42d78a944") },
                    { new Guid("4ebd85e6-72a7-4898-9475-77fc5cf18969"), new Guid("fa8e0739-23a4-4c29-a9d3-1f34b93a40a1"), new Guid("cc980a4e-9495-4b8a-91d7-4b09e522dc29") },
                    { new Guid("52981242-d892-4fb2-8668-d4d76535f7a5"), new Guid("fa8e0739-23a4-4c29-a9d3-1f34b93a40a1"), new Guid("529ee143-892a-4fd3-99a7-1444030b6f31") },
                    { new Guid("5526b4ef-01d5-45f3-bbfe-7024593fe8ad"), new Guid("2ab01677-fbfe-485a-a635-639ad2ef2dc3"), new Guid("c10ac035-78d8-4764-805b-64d64e2a1bf6") },
                    { new Guid("55c170dd-bd95-453d-aef9-677e0765cb15"), new Guid("b46c75d4-a4cd-46c3-9ff2-6a8ff5a8e927"), new Guid("f150feef-2c8e-48bf-9e76-bc416ef48c58") },
                    { new Guid("55f44740-8550-4b7a-8941-a65422e2c2f9"), new Guid("73328357-7dd8-4a7b-b3b1-46b0682a7f73"), new Guid("51430899-771a-4b95-8ab7-f8ca7e516716") },
                    { new Guid("5860549a-484e-4ae1-967f-a4f8534d20f8"), new Guid("a59b3cc8-0880-4b40-88e5-882162042718"), new Guid("fd015dd9-0901-45a1-a772-4e5f44894301") },
                    { new Guid("5a6c14d0-a73a-4ec7-8979-5fe94c6c2043"), new Guid("73328357-7dd8-4a7b-b3b1-46b0682a7f73"), new Guid("18f12884-a4fe-47df-bf98-34b25277f0c4") },
                    { new Guid("60026912-cd8a-4694-90a9-0c3cd3989a6d"), new Guid("73328357-7dd8-4a7b-b3b1-46b0682a7f73"), new Guid("77fea2a6-3236-4e4f-a39c-039d000ebf2b") },
                    { new Guid("69182758-9c19-45e2-859b-16c88ed14498"), new Guid("7a9d5e75-b024-4608-8131-f1956ebafe91"), new Guid("4ed81deb-c516-4a67-9964-c0991cf50517") },
                    { new Guid("6e7bf6b0-7ea4-41cc-9e48-6fa86ba52409"), new Guid("a59b3cc8-0880-4b40-88e5-882162042718"), new Guid("9267f871-9fb2-4711-a4bc-08da42a7ec88") },
                    { new Guid("706242ea-1c96-477c-97eb-9ace499eeeb2"), new Guid("b46c75d4-a4cd-46c3-9ff2-6a8ff5a8e927"), new Guid("6b4a0da8-fe0d-4c2e-a488-1c835be21da4") },
                    { new Guid("77e44df7-dfdb-4d61-a723-8c3353a0660d"), new Guid("6705c61a-8c99-45de-bf0c-0b0599efa3bc"), new Guid("57a270d9-04f4-4c2a-aec2-a7eab604965b") },
                    { new Guid("77f2cb9e-b745-4a2d-bfd3-be1190da2295"), new Guid("84da2c2f-5923-4b7c-8ea0-d0ed314aa1da"), new Guid("e761805f-e8a2-47d4-ba65-68d0979c5af1") },
                    { new Guid("79d4ebf5-b53e-4645-b7ec-58e222f87dc3"), new Guid("2ab01677-fbfe-485a-a635-639ad2ef2dc3"), new Guid("8dd74735-a60e-4aeb-9976-75f42867bb31") },
                    { new Guid("7b1c5aca-a3b7-4b81-ba92-d27b648df07b"), new Guid("8da06326-a19b-42c3-85eb-9978d6bd1275"), new Guid("03b99332-757f-4c6b-b9e6-81d42ff3b427") },
                    { new Guid("7cccb9c6-1eaf-4ca4-ad14-2036250fffca"), new Guid("84da2c2f-5923-4b7c-8ea0-d0ed314aa1da"), new Guid("6c1243b6-3fed-4f6c-a6ba-b6a27dd556d2") },
                    { new Guid("7daf99b2-789c-4534-a5e4-d19019a227c8"), new Guid("70abd9c0-ad11-44b7-a3f5-e81f924b9e0f"), new Guid("a9a13a41-2938-45c8-a51c-b14ab007ccca") },
                    { new Guid("7e402648-3316-48ad-8a99-3c04f0c9f847"), new Guid("a59b3cc8-0880-4b40-88e5-882162042718"), new Guid("e0a49957-5409-45e1-87a1-1e224d676fdc") },
                    { new Guid("82fbf916-01e1-4522-a9cd-4232a55df333"), new Guid("73328357-7dd8-4a7b-b3b1-46b0682a7f73"), new Guid("f1892f0d-8af0-4e25-85b3-ffade6b7cd5b") },
                    { new Guid("838bf26e-e88a-4052-8898-25db3513e15e"), new Guid("2ab01677-fbfe-485a-a635-639ad2ef2dc3"), new Guid("fed12704-6e08-4195-9e03-3f07501fe1a9") },
                    { new Guid("86479721-42a4-413d-a215-aa5659ee0d7c"), new Guid("9902a38b-eb9b-4a02-93f2-98dfe8ba6e60"), new Guid("ed0f80d4-d2e4-4faa-af6a-cb7d240c10b4") },
                    { new Guid("8ba8eb31-eb0e-4e91-b68f-fc65e029cac2"), new Guid("9902a38b-eb9b-4a02-93f2-98dfe8ba6e60"), new Guid("4a54e926-a2d8-4a1e-8fea-316fa0216a67") },
                    { new Guid("8ed7249f-399d-4734-8ec4-3accac46a47c"), new Guid("9902a38b-eb9b-4a02-93f2-98dfe8ba6e60"), new Guid("bad2c353-9d1c-4a0f-a150-6fb2c47c1627") },
                    { new Guid("8ef3a8e2-fde1-4419-b3e3-6a2ccbe4683b"), new Guid("fa8e0739-23a4-4c29-a9d3-1f34b93a40a1"), new Guid("2aa4b57b-fbbb-4993-9090-a3545d4e8e08") },
                    { new Guid("933a962a-660c-46d6-b34f-07e5760b5be0"), new Guid("6705c61a-8c99-45de-bf0c-0b0599efa3bc"), new Guid("c14c1c7b-91e8-4092-af40-274b66eea297") },
                    { new Guid("9433fa3c-3702-45ff-a914-d09197cffd17"), new Guid("8da06326-a19b-42c3-85eb-9978d6bd1275"), new Guid("26f8f5a0-200f-435c-9ad0-b40fe1883c47") },
                    { new Guid("951da81d-39db-4aff-9589-2e34d3dd0829"), new Guid("5cb1c2eb-5f9f-4894-bf01-36a463a00dd0"), new Guid("209c087d-989f-4be9-8268-b9a6fe06fac9") },
                    { new Guid("95d5c966-00f8-4753-a22b-2b58c529d327"), new Guid("73d26d61-bd67-437e-a53b-7f0d96610711"), new Guid("310a481f-de07-4667-8600-969bc04abab4") },
                    { new Guid("98a326c7-9c4c-471d-b210-b0c00568d00a"), new Guid("73d26d61-bd67-437e-a53b-7f0d96610711"), new Guid("f00f160d-6186-4a33-8c82-a34458fd82d9") },
                    { new Guid("995b4610-29cc-47a1-a7e9-45f09a9ec050"), new Guid("bab4bf49-7aaf-4640-b7b9-ea3b6ce91996"), new Guid("51104829-c4db-411f-bf6e-440df6ee667d") },
                    { new Guid("9cd4f04f-af2f-47bd-a5d9-b66d214375aa"), new Guid("b817df9c-6236-4028-8d6e-835a9d612742"), new Guid("b3c1747f-fea7-492b-86dd-0c693fa047a7") },
                    { new Guid("9e0ddce5-c1fb-4f04-ae65-d9f5cafc0f0f"), new Guid("70abd9c0-ad11-44b7-a3f5-e81f924b9e0f"), new Guid("d29e77f1-9c25-4818-8f5d-2bd402610d70") },
                    { new Guid("9e99054e-413b-4298-a560-ac01394facfc"), new Guid("a2dd4008-8c63-4d43-b46f-b1b3c2f0b39b"), new Guid("51664f3a-f993-4661-be70-0b5659fc43a7") },
                    { new Guid("a1448740-7497-45e3-a2d6-edd5b1105377"), new Guid("7a9d5e75-b024-4608-8131-f1956ebafe91"), new Guid("fb7e384f-bdce-4e0d-a188-9e4c92eee19d") },
                    { new Guid("ab9797d5-33ce-47ee-8182-e0749480d66c"), new Guid("7a9d5e75-b024-4608-8131-f1956ebafe91"), new Guid("cc636208-18c1-415c-b9e5-f3eea1c80ffb") },
                    { new Guid("ad728e0b-7834-4836-b1b2-18e581e0b43f"), new Guid("a2dd4008-8c63-4d43-b46f-b1b3c2f0b39b"), new Guid("22f78d15-a128-42fb-bc90-a0ff5a6a7a70") },
                    { new Guid("aede6a92-7d08-4be0-80d9-e9caf151ab38"), new Guid("c27d90eb-c47f-4e91-8366-ee753fd1f319"), new Guid("ff29a60e-87f8-4901-b579-d3f932dc5aba") },
                    { new Guid("b200fff6-c951-40f5-a58e-6d73580e8005"), new Guid("73d26d61-bd67-437e-a53b-7f0d96610711"), new Guid("1d9bf916-cd62-4947-a504-9cd733c94872") },
                    { new Guid("b24819d9-5825-4306-9c92-1722bf73cd3b"), new Guid("2ab01677-fbfe-485a-a635-639ad2ef2dc3"), new Guid("f206726d-5b6d-4d30-abe1-7e69acc2122a") },
                    { new Guid("b339af85-4343-42e0-a6bb-e5b4ca444d08"), new Guid("a59b3cc8-0880-4b40-88e5-882162042718"), new Guid("2921cb30-d0c2-4136-b8b6-15626f37d35f") },
                    { new Guid("b4d12407-b028-4c90-b66d-2c3f3f97b4a1"), new Guid("bab4bf49-7aaf-4640-b7b9-ea3b6ce91996"), new Guid("b9ba50ce-d03e-4e25-894a-a9e1d9bea747") },
                    { new Guid("b53c8282-f044-46c8-ad26-74dbb03d5ff0"), new Guid("5cb1c2eb-5f9f-4894-bf01-36a463a00dd0"), new Guid("e7520c05-574b-4a9e-9eda-45a6696c6f99") },
                    { new Guid("b82f518a-7e25-4385-8b2c-66a9c94e9caf"), new Guid("8876eb2a-b519-4376-889c-3cbc9c40a0d3"), new Guid("2c2fb173-2329-46a0-aa97-758baee666b8") },
                    { new Guid("bdc46dcb-182d-4394-87b5-2c903acaadc3"), new Guid("f058ffed-24bf-404c-b7b1-3cb773d49166"), new Guid("1cdde102-2543-4ebf-b4f1-75b20c6dbf49") },
                    { new Guid("bf5118dc-a49f-4284-bc15-be183f6c19a5"), new Guid("84da2c2f-5923-4b7c-8ea0-d0ed314aa1da"), new Guid("10c2a80e-6542-4037-af25-14af687f5f87") },
                    { new Guid("c3b66419-ea81-429a-a067-f4059e6e557b"), new Guid("f058ffed-24bf-404c-b7b1-3cb773d49166"), new Guid("14174a4c-6ca7-4249-b9a6-ada0a287583e") },
                    { new Guid("c3e31727-3b5b-4eba-8b75-fcb4cc8c5626"), new Guid("73d26d61-bd67-437e-a53b-7f0d96610711"), new Guid("c2fca2ec-d9c9-48f1-a37d-bbe9fef4171c") },
                    { new Guid("c447bbe5-9ced-4be4-bac4-7246b14cba0e"), new Guid("bab4bf49-7aaf-4640-b7b9-ea3b6ce91996"), new Guid("eaaf2c06-c4e7-4cde-adb7-ae2fd1ee2236") },
                    { new Guid("c7d4589c-296c-4b07-b561-0f8f99c862d3"), new Guid("c27d90eb-c47f-4e91-8366-ee753fd1f319"), new Guid("ed09528b-a14b-4cae-8e87-2ee282192584") },
                    { new Guid("d1a60363-f78b-4a2b-8602-b227955b75f0"), new Guid("fa8e0739-23a4-4c29-a9d3-1f34b93a40a1"), new Guid("69427507-bfda-4495-be34-8799f5b3865b") },
                    { new Guid("d1e342f3-2e64-47f0-b50f-8a030a9671f3"), new Guid("c27d90eb-c47f-4e91-8366-ee753fd1f319"), new Guid("a8ce0555-f26b-4259-8083-0c4fc0253863") },
                    { new Guid("d5ed33d9-5df4-436c-a662-edf21cd368ec"), new Guid("a2dd4008-8c63-4d43-b46f-b1b3c2f0b39b"), new Guid("8e359770-5f5e-4980-94d9-41f74802d1ce") },
                    { new Guid("dc391e77-0e4c-488e-92fc-df6ca45032b5"), new Guid("7a9d5e75-b024-4608-8131-f1956ebafe91"), new Guid("9411afab-0a29-4b88-9549-6b22cce2c6ab") },
                    { new Guid("de35257b-d910-46e0-8242-3733f2043af1"), new Guid("8da06326-a19b-42c3-85eb-9978d6bd1275"), new Guid("fd8c0c2f-8600-42d4-bf00-09bcf8807bc9") },
                    { new Guid("def357d9-d9c2-4b4c-a839-c2b545973536"), new Guid("a2dd4008-8c63-4d43-b46f-b1b3c2f0b39b"), new Guid("9cef5f55-3fa1-4dd3-8d8e-b4b2346307ea") },
                    { new Guid("df461bc5-1fff-47d7-ac67-53a7932d87f8"), new Guid("6705c61a-8c99-45de-bf0c-0b0599efa3bc"), new Guid("78d16027-9f3e-41b6-9063-5635c232a59b") },
                    { new Guid("e1c80035-16a5-4648-af08-e4a45011f04c"), new Guid("b817df9c-6236-4028-8d6e-835a9d612742"), new Guid("dd7e5377-345a-41e6-9690-5b3ce9a1019c") },
                    { new Guid("e60f3c7f-c6e0-4de7-b41a-85f3726491ce"), new Guid("a2dd4008-8c63-4d43-b46f-b1b3c2f0b39b"), new Guid("db42ccab-0c39-4f48-a9e3-893cc267fc32") },
                    { new Guid("e8f8a3f9-aff2-497f-8869-1a4389988c32"), new Guid("84da2c2f-5923-4b7c-8ea0-d0ed314aa1da"), new Guid("a0574cc8-d4e4-4e1a-b800-a95fea0548dd") },
                    { new Guid("ea0bd87d-8f54-45de-9ff3-c7345e796663"), new Guid("6705c61a-8c99-45de-bf0c-0b0599efa3bc"), new Guid("c2351e44-9dd8-4f1d-9a8a-e7a88012e3aa") },
                    { new Guid("ec588e29-733e-4438-91d0-69b4201f3d0f"), new Guid("9902a38b-eb9b-4a02-93f2-98dfe8ba6e60"), new Guid("047d0060-4ed4-4166-8f45-42a331f519b7") },
                    { new Guid("ed6444ac-a1a1-4b44-9144-e65fc06c2653"), new Guid("c27d90eb-c47f-4e91-8366-ee753fd1f319"), new Guid("79310aa5-a976-48e9-b477-5e7fae067ab3") },
                    { new Guid("efa1641f-c3c6-4b3d-970b-14b2eed93579"), new Guid("b817df9c-6236-4028-8d6e-835a9d612742"), new Guid("4ab07996-32d6-4bf3-96b3-92fd311cfaf2") },
                    { new Guid("f2250006-16b9-498a-be20-361d3378dd71"), new Guid("70abd9c0-ad11-44b7-a3f5-e81f924b9e0f"), new Guid("1cea68eb-f170-4864-8da2-d9a19d08f4b8") },
                    { new Guid("f52f1673-08db-494e-a009-6dcb47af9554"), new Guid("bab4bf49-7aaf-4640-b7b9-ea3b6ce91996"), new Guid("e91094d0-3741-45b5-9afc-097fa83a2456") },
                    { new Guid("f6548a03-5517-4b20-96b8-05fddf1e4d61"), new Guid("b46c75d4-a4cd-46c3-9ff2-6a8ff5a8e927"), new Guid("6decff71-e09b-4827-b70f-ee114035b98b") },
                    { new Guid("f76d06a7-1c86-4197-a209-bb9c4e3e1413"), new Guid("7a9d5e75-b024-4608-8131-f1956ebafe91"), new Guid("6d312def-149c-4b8c-ad84-37295d6fae40") },
                    { new Guid("f93a1338-cbca-484b-88ef-dc23b74cae9e"), new Guid("73d26d61-bd67-437e-a53b-7f0d96610711"), new Guid("05e28f06-4ab5-4e30-b4b1-e55ec292b8bd") },
                    { new Guid("fad08b48-b804-47b3-a126-637fdf4a8c96"), new Guid("f058ffed-24bf-404c-b7b1-3cb773d49166"), new Guid("2dbc4bd7-491a-4c86-8bfc-f11f6a129ce7") },
                    { new Guid("fef58697-43c2-4923-8855-eecab92b797a"), new Guid("70abd9c0-ad11-44b7-a3f5-e81f924b9e0f"), new Guid("0f5072b8-9347-4164-a0b2-75a267b567a2") },
                    { new Guid("ff21523c-4ea3-47e2-a49e-b10754ea393d"), new Guid("5cb1c2eb-5f9f-4894-bf01-36a463a00dd0"), new Guid("f76bdcdd-bc83-4500-9948-21eefef0aa7e") }
                });

            migrationBuilder.InsertData(
                table: "UserPerformanceSummaries",
                columns: new[] { "Id", "CorrectAnswers", "CreatedAt", "LastUpdatedAt", "SuccessRate", "TopicId", "TotalQuestionsAnswered", "UserId" },
                values: new object[,]
                {
                    { new Guid("0bd80173-3250-4052-a1d0-55a833858743"), 58, new DateTime(2025, 8, 2, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5276), new DateTime(2025, 8, 2, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5276), 96.670000000000002, new Guid("b817df9c-6236-4028-8d6e-835a9d612742"), 60, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("160c28d6-0e73-4449-bed7-b9de801d1f24"), 27, new DateTime(2025, 7, 22, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5277), new DateTime(2025, 8, 4, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5277), 50.0, new Guid("fa8e0739-23a4-4c29-a9d3-1f34b93a40a1"), 54, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("1da75d17-06ce-43d0-b27e-42846457dfa6"), 57, new DateTime(2025, 7, 30, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5284), new DateTime(2025, 8, 4, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5285), 59.380000000000003, new Guid("73d26d61-bd67-437e-a53b-7f0d96610711"), 96, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("547de789-6534-4d88-9ae6-be64b6c7e4f6"), 11, new DateTime(2025, 7, 26, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5263), new DateTime(2025, 8, 6, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5270), 32.350000000000001, new Guid("c27d90eb-c47f-4e91-8366-ee753fd1f319"), 34, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("56ad6fb7-ebf4-4ef6-84ca-eb576107cfc2"), 22, new DateTime(2025, 7, 27, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5294), new DateTime(2025, 8, 2, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5294), 45.829999999999998, new Guid("7a9d5e75-b024-4608-8131-f1956ebafe91"), 48, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("59a711d7-88fc-49c3-ad11-4f4de94abce2"), 28, new DateTime(2025, 7, 17, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5287), new DateTime(2025, 8, 6, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5287), 37.840000000000003, new Guid("b817df9c-6236-4028-8d6e-835a9d612742"), 74, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("5d3192a0-37f1-4de3-ba61-a8cd60efdc72"), 5, new DateTime(2025, 7, 25, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5298), new DateTime(2025, 8, 4, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5298), 8.9299999999999997, new Guid("fa8e0739-23a4-4c29-a9d3-1f34b93a40a1"), 56, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("8c9f6931-6a1f-41a8-9cc4-25e7cfbc6a52"), 22, new DateTime(2025, 7, 11, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5291), new DateTime(2025, 8, 4, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5292), 25.289999999999999, new Guid("c27d90eb-c47f-4e91-8366-ee753fd1f319"), 87, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("b59f7ac5-6e1e-4716-9102-05041e3c2e4c"), 8, new DateTime(2025, 7, 19, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5297), new DateTime(2025, 8, 6, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5297), 72.730000000000004, new Guid("b817df9c-6236-4028-8d6e-835a9d612742"), 11, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("b6c4dda2-772b-4c9a-900b-d6f4d5e6dce0"), 23, new DateTime(2025, 7, 31, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5273), new DateTime(2025, 8, 8, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5273), 45.100000000000001, new Guid("73d26d61-bd67-437e-a53b-7f0d96610711"), 51, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c3d7fda7-d3fb-45b4-a341-47c5ad1d9700"), 63, new DateTime(2025, 7, 20, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5283), new DateTime(2025, 8, 6, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5283), 65.620000000000005, new Guid("c27d90eb-c47f-4e91-8366-ee753fd1f319"), 96, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("dc01656b-5466-401f-89d8-6ef7cfb3025f"), 31, new DateTime(2025, 8, 5, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5293), new DateTime(2025, 8, 6, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5293), 44.93, new Guid("73d26d61-bd67-437e-a53b-7f0d96610711"), 69, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("ddb4026b-d0f4-4362-abc3-e07acf42a0da"), 52, new DateTime(2025, 8, 5, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5286), new DateTime(2025, 8, 6, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5286), 71.230000000000004, new Guid("7a9d5e75-b024-4608-8131-f1956ebafe91"), 73, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("e1a97b3f-e820-4eab-96ca-63d90aee9e1e"), 14, new DateTime(2025, 8, 4, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5289), new DateTime(2025, 8, 3, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5290), 70.0, new Guid("fa8e0739-23a4-4c29-a9d3-1f34b93a40a1"), 20, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("fa3fe97c-c9a6-4ed8-884b-14457fe6b947"), 66, new DateTime(2025, 7, 19, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5274), new DateTime(2025, 8, 7, 13, 27, 50, 261, DateTimeKind.Utc).AddTicks(5275), 86.840000000000003, new Guid("7a9d5e75-b024-4608-8131-f1956ebafe91"), 76, new Guid("11111111-1111-1111-1111-111111111111") }
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
