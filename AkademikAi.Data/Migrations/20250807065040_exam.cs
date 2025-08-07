using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AkademikAi.Data.Migrations
{
    /// <inheritdoc />
    public partial class exam : Migration
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
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
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
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Topics_ParentTopicId",
                        column: x => x.ParentTopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Score = table.Column<double>(type: "float", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "dummy-conc-1", new DateTime(2025, 8, 7, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(7584), "ali@example.com", true, false, null, "Ali", "ALI@EXAMPLE.COM", "ALI", "AQAAAAEAACcQAAAAEDummyHash1==", "5551111111", false, "dummy-stamp-1", "Veli", false, "ali", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "dummy-conc-2", new DateTime(2025, 8, 7, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(7592), "ayse@example.com", true, false, null, "Ayşe", "AYSE@EXAMPLE.COM", "AYSE", "AQAAAAEAACcQAAAAEDummyHash2==", "5552222222", false, "dummy-stamp-2", "Yılmaz", false, "ayse", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "dummy-conc-3", new DateTime(2025, 8, 7, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(7599), "mehmet@example.com", true, false, null, "Mehmet", "MEHMET@EXAMPLE.COM", "MEHMET", "AQAAAAEAACcQAAAAEDummyHash3==", "5553333333", false, "dummy-stamp-3", "Demir", false, "mehmet", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevel", "GeneratedForUserId", "IsActive", "QuestionText", "SolutionText", "Source" },
                values: new object[,]
                {
                    { new Guid("007903b8-17e9-49e4-b732-1ed680d84cb2"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("043d6340-d790-47dd-a266-b378691dcd3d"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("05e32d82-8545-4692-a9cd-adb7b7a2063b"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0785a31a-66db-4bfb-a215-55cf6d9536ac"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0bbde36b-91ec-4ae1-b758-f5118102484a"), 2, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0c61c300-af71-4502-8dca-a38735279402"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0d1aa2c6-af98-4384-86d4-630f67bee88b"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("138b10e4-a139-426e-816e-ae353b9a4211"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("139d648e-a97b-4091-bb09-21bd01bf4d68"), 2, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("146e1fb0-2242-43b0-a29f-9231913a84d5"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("14f6577b-0d37-4a5c-9250-bf1de916dda2"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("152a3643-eac5-4d14-a7bf-c1b46b376270"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("18d91c97-d883-4711-b99f-11989ff19248"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("19d76a6f-5546-4d3e-82c6-ab74a7a47728"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1a468d3c-8f5a-4967-8eb3-e69ed21ce138"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1c04632a-f394-45aa-aa42-fdb468b36b54"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1d46d737-bba7-4b6b-8c51-58578b86ef74"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1e1f5424-2284-453f-9c37-963233005ac2"), 2, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1f6ae920-0c90-4589-8c44-4934bcc58028"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2176b97f-c705-4f95-9360-9bd35e1c0b14"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("21e95a17-b30a-455c-afe0-cc4e1301420a"), 2, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("267e405f-f997-47c6-8e8a-5ca5a995bf82"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("26ea5c49-cb47-40ba-8dd0-3d81bc934546"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("27cfb64e-b730-46e9-b4c0-5c58194b6b7b"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("29a31835-aa03-4eb8-9d12-8c4491c43221"), 2, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2b4ac114-f67d-440f-9892-8581eabb3bab"), 2, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2df9815e-35de-426e-b606-1a85eec77cdc"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2e12e4bc-335e-41fe-be0a-d47ca983d560"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("34b2990d-cdc6-4dd2-b469-ce81ed49fe23"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3538996d-ec48-4bd9-89eb-1eaa86b55634"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("383bcd24-7c1a-4723-8b5b-5f7fa11bb8d9"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3d62281a-b911-444d-891b-984de319fe68"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3f05a1f7-39fa-4bd8-82ec-5db7cd7b2e87"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("400bdfdf-789e-4ed3-bc7d-d743f4b84b66"), 2, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("406d0dfb-972b-4cf8-90cd-f4957f91c739"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("412f6db2-18c0-49e1-9db2-5d9383cf4f08"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("43b3905f-c7a1-41dd-b6c7-887944c214f8"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("46b72d22-3af7-4b24-ac9a-44586519a14a"), 2, null, true, "Temel Kavramlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("471fa72e-a88a-4503-a932-068d224b9ba7"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4d17b5ae-1399-42a4-8d8d-32451680ba1f"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5199d68a-3aec-4d88-80ae-dd7a45d40fd0"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("53557f50-3e0f-4dff-9813-92d4a2a3dfe0"), 0, null, true, "Problemler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("540e9ff6-0357-4c10-99c6-2d73726698eb"), 2, null, true, "Sayı Basamakları konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("563f05a2-5a15-4bbb-9b5c-353dc45f70c3"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("57dbf6ef-3626-4bea-8179-b197e52d5113"), 2, null, true, "Kimya Bilimi konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5b0f6c26-296d-4d8a-b3ee-4b507e05c03b"), 1, null, true, "Hücre konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6193f954-1651-4047-8ee4-f98504850b71"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("620149c2-3cb6-4616-8aa7-25671167e77a"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("66d184dc-b34e-470c-a630-e61ff6602da5"), 1, null, true, "Hücre konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("69ded171-0d51-4273-be01-3165bcb19c5f"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7321bc85-d438-4b05-a823-81c1120da3da"), 1, null, true, "Problemler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("78ffad7b-5b72-4703-a192-ea1f5e53286e"), 2, null, true, "Elektrostatik konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7ed511b7-d394-4b9d-b5da-dcdcbcd4874c"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7fb13328-c3ea-471c-81a5-477ca2e4e464"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("815fcedc-c0c2-465f-963b-afe800ab5659"), 0, null, true, "Hücre konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("82bdb667-44a1-4b80-b10b-f4fb7facf3c1"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("88060534-8b7e-40b9-8f68-1a8152283d13"), 0, null, true, "Kalıtım konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8ae253de-b346-4784-a87c-6603cf699ac2"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("90560d53-059e-406f-8f8a-9da46f2abc1c"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9145349a-77f3-4b5b-8712-7d1a0bc2d6b5"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("95f558eb-361b-410b-b128-33187a312dcc"), 0, null, true, "Hücre konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9904cc1c-583d-46ca-a149-bfc0c23ac171"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9ba36baa-0b55-498f-afa7-566d104317cd"), 2, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a0c342b0-4995-4496-9875-2abf600e70ad"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a3589401-d917-4bb5-9f98-3c210fc58ec7"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a79688f8-3e47-4c89-8760-5a6b3860f850"), 2, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a989a459-c781-436f-a812-6773b6dbaed7"), 0, null, true, "Problemler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ad85a2df-ab4b-479a-8130-7d821136a8ee"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("af9bdb27-2430-4199-b441-3b4026095e43"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b2282a5d-c02d-4943-9a03-3232803ee544"), 1, null, true, "Kalıtım konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b8468c14-7588-48ab-9569-86b7d8a8ca0d"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("be4d6081-8f2a-4b83-bd52-d312dd406fa7"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c0212217-b2f6-4619-9892-1bb6ae63c8aa"), 2, null, true, "Hücre konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c1883ebc-94f3-4b09-b5e6-913470ac24f2"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c2c7b026-71af-45c0-95b2-fa443024fb52"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c30b0f82-ecda-4066-80b2-3bf48ee36f05"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c61589b3-4f7d-436b-9a7b-f7ad4f25c046"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c745d452-2f55-4c88-b054-f003b104e723"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ca4b97ac-6382-40f1-8df5-7ba899d4372f"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("cd0cb688-6910-49e7-b97f-1b9768ceda02"), 0, null, true, "Kalıtım konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ce93e37c-5cdb-40ee-8d42-7bda3a6e62b5"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d0b8ed35-7bf8-4ec1-8bb0-5be5965b17c7"), 2, null, true, "Kalıtım konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d27798bb-be62-42cd-8a2f-b08dfa214c38"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d49b0490-9425-4075-94d5-d4428abbb0ba"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d534a582-6b26-4287-9937-ff4f608352a7"), 1, null, true, "Kalıtım konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d54a745f-2025-4166-b22e-57ce8b62119b"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d6fdb98c-7910-49d0-a210-f380edea7791"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("db6e78ba-f5b3-4754-8396-6a62e566b26a"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("dd295827-7146-44ba-a342-5094d90dfe59"), 2, null, true, "Problemler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("de6628ac-bc56-465e-bad0-06c5d502a2c7"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e1b631fc-9076-421c-baa2-cc87a182c182"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ea10acd6-608b-4806-b79f-2d2ab55a4f76"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("ed5a5f5f-1cfa-41be-92e6-3ca41a64ce75"), 2, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("efb2d9d3-a3a9-404e-b378-e58f29a73007"), 2, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f149242c-1aba-4edb-9148-9d451a2dc9a5"), 2, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f6f2e5ba-950f-4a48-ab01-e96f225c1272"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f721fd66-2cd9-4531-bb43-4794e743d80f"), 2, null, true, "Maddenin Halleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f84d228d-be92-4632-90e1-3a513a5186f9"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fa6f2db7-a9f1-408a-abfb-8af8dc2a1faa"), 1, null, true, "Problemler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("fbc475d5-a073-4981-997d-5f96c2723251"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "ParentTopicId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("3ad0b735-1f66-4ee2-84fa-9882494ba074"), null, "Fizik" },
                    { new Guid("4bfce486-d3db-4af0-b0e1-69b317fa3caf"), null, "Matematik" },
                    { new Guid("8d44d040-57eb-4611-9564-08989c22b610"), null, "Kimya" },
                    { new Guid("c678f063-7077-48c5-88e1-0e363b049b81"), null, "Biyoloji" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "IsCorrect", "Label", "OptionOrder", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("013c52cc-f998-4eb1-9165-dc2358b9e4a5"), false, "B", 2, "Kuvvet ve Hareket - Soru 1 için Seçenek B", new Guid("69ded171-0d51-4273-be01-3165bcb19c5f") },
                    { new Guid("0195cd60-591e-4c9c-b562-add426d4b34a"), false, "A", 1, "Problemler - Soru 5 için Seçenek A", new Guid("dd295827-7146-44ba-a342-5094d90dfe59") },
                    { new Guid("01b55d92-b606-4f23-b4db-e9228e24cb31"), false, "A", 1, "Hücre Bölünmeleri - Soru 4 için Seçenek A", new Guid("3538996d-ec48-4bd9-89eb-1eaa86b55634") },
                    { new Guid("026cf14e-2e99-4b61-acfd-62c35cbb767c"), false, "B", 2, "Elektrostatik - Soru 2 için Seçenek B", new Guid("9145349a-77f3-4b5b-8712-7d1a0bc2d6b5") },
                    { new Guid("02beb6e7-7a59-4cd1-9aa3-84b8c2421663"), false, "B", 2, "Hücre - Soru 2 için Seçenek B", new Guid("5b0f6c26-296d-4d8a-b3ee-4b507e05c03b") },
                    { new Guid("032f9d10-e0ad-4fca-8b66-5c616c895734"), false, "D", 4, "İş, Güç ve Enerji - Soru 3 için Seçenek D", new Guid("18d91c97-d883-4711-b99f-11989ff19248") },
                    { new Guid("037c966e-1ea1-48a9-bfe5-5cea590cec05"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek A", new Guid("d6fdb98c-7910-49d0-a210-f380edea7791") },
                    { new Guid("03ed932d-d5f1-405c-9f23-4b62221b1c2c"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek B", new Guid("ea10acd6-608b-4806-b79f-2d2ab55a4f76") },
                    { new Guid("0493fb48-bdce-4be1-b1b2-15b38d03dc9d"), true, "A", 1, "Sayı Basamakları - Soru 2 için Seçenek A", new Guid("82bdb667-44a1-4b80-b10b-f4fb7facf3c1") },
                    { new Guid("04e8529f-a83e-4a11-a0ea-abac2e853c8f"), false, "C", 3, "Madde ve Özellikleri - Soru 1 için Seçenek C", new Guid("27cfb64e-b730-46e9-b4c0-5c58194b6b7b") },
                    { new Guid("0519de64-709b-4293-afa9-c118dbad873c"), true, "B", 2, "İş, Güç ve Enerji - Soru 4 için Seçenek B", new Guid("8ae253de-b346-4784-a87c-6603cf699ac2") },
                    { new Guid("058a4623-b91e-491f-9a58-aab0cfbcabba"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek D", new Guid("383bcd24-7c1a-4723-8b5b-5f7fa11bb8d9") },
                    { new Guid("05a62da8-c738-4706-a5e5-167ff69d9338"), false, "D", 4, "Sayı Basamakları - Soru 2 için Seçenek D", new Guid("82bdb667-44a1-4b80-b10b-f4fb7facf3c1") },
                    { new Guid("07221e39-c7bd-456a-a95b-9af3a053b0d8"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 1 için Seçenek C", new Guid("ad85a2df-ab4b-479a-8130-7d821136a8ee") },
                    { new Guid("078e2c67-9397-4680-a77a-9e81e327a7b5"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek B", new Guid("400bdfdf-789e-4ed3-bc7d-d743f4b84b66") },
                    { new Guid("081ee45c-faeb-40ef-bf5b-495d4a5fb2e4"), false, "A", 1, "Maddenin Halleri - Soru 1 için Seçenek A", new Guid("7ed511b7-d394-4b9d-b5da-dcdcbcd4874c") },
                    { new Guid("084bbb55-7bc8-4a52-9fb7-9d107b16c45f"), true, "A", 1, "Problemler - Soru 1 için Seçenek A", new Guid("53557f50-3e0f-4dff-9813-92d4a2a3dfe0") },
                    { new Guid("08862002-da73-47d0-b44e-7fbdb8cbdb0c"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek D", new Guid("9904cc1c-583d-46ca-a149-bfc0c23ac171") },
                    { new Guid("08c7fbdd-8bf0-4862-a77c-189a51c20ce7"), false, "B", 2, "Kimya Bilimi - Soru 2 için Seçenek B", new Guid("26ea5c49-cb47-40ba-8dd0-3d81bc934546") },
                    { new Guid("0a6cb5e8-68dd-4ab5-89fd-742096f29b50"), false, "A", 1, "İş, Güç ve Enerji - Soru 4 için Seçenek A", new Guid("8ae253de-b346-4784-a87c-6603cf699ac2") },
                    { new Guid("0b491e1f-0f36-44d6-8aa1-7d5b1b95666c"), false, "C", 3, "Kuvvet ve Hareket - Soru 2 için Seçenek C", new Guid("c2c7b026-71af-45c0-95b2-fa443024fb52") },
                    { new Guid("0c55ee32-b7b8-4aa4-aab4-6d2873bd5864"), true, "A", 1, "Rasyonel Sayılar - Soru 3 için Seçenek A", new Guid("f6f2e5ba-950f-4a48-ab01-e96f225c1272") },
                    { new Guid("0c66ce11-419a-492f-9dd7-42efe3d5a4c0"), true, "A", 1, "Fizik Bilimine Giriş - Soru 3 için Seçenek A", new Guid("0785a31a-66db-4bfb-a215-55cf6d9536ac") },
                    { new Guid("0cb3ff42-bb91-40ce-b0cb-0654c1fc7cba"), false, "B", 2, "İş, Güç ve Enerji - Soru 5 için Seçenek B", new Guid("a79688f8-3e47-4c89-8760-5a6b3860f850") },
                    { new Guid("0d8030f7-c13a-4e09-bdcb-c35b2434724c"), false, "C", 3, "Sayı Basamakları - Soru 3 için Seçenek C", new Guid("c1883ebc-94f3-4b09-b5e6-913470ac24f2") },
                    { new Guid("0dd6cb80-505f-48b6-b8a4-170ab88e2e15"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 3 için Seçenek C", new Guid("d49b0490-9425-4075-94d5-d4428abbb0ba") },
                    { new Guid("0ee70069-e0dc-48d7-8904-8ead6a54cba3"), true, "D", 4, "Problemler - Soru 2 için Seçenek D", new Guid("7321bc85-d438-4b05-a823-81c1120da3da") },
                    { new Guid("0ef0dd1e-ccee-4764-a425-64afc55bb743"), true, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek C", new Guid("400bdfdf-789e-4ed3-bc7d-d743f4b84b66") },
                    { new Guid("0f42f916-c2c6-4b8f-8d18-f536f5d8e52e"), true, "D", 4, "Rasyonel Sayılar - Soru 2 için Seçenek D", new Guid("d54a745f-2025-4166-b22e-57ce8b62119b") },
                    { new Guid("0f5da86e-cbec-4cb8-8781-47fe67633f42"), true, "B", 2, "Kimya Bilimi - Soru 3 için Seçenek B", new Guid("471fa72e-a88a-4503-a932-068d224b9ba7") },
                    { new Guid("10d8a12d-74a9-4eb7-a2c5-c0de8b29a4e0"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek B", new Guid("146e1fb0-2242-43b0-a29f-9231913a84d5") },
                    { new Guid("10ec2bf5-72cd-460b-89b2-5a314d360970"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek D", new Guid("b8468c14-7588-48ab-9569-86b7d8a8ca0d") },
                    { new Guid("10faa145-2b5b-4548-808b-55aa5b4f8ff9"), true, "D", 4, "Elektrostatik - Soru 1 için Seçenek D", new Guid("be4d6081-8f2a-4b83-bd52-d312dd406fa7") },
                    { new Guid("110ab658-9e54-454e-a9e6-80da680c6b86"), false, "C", 3, "Maddenin Halleri - Soru 1 için Seçenek C", new Guid("7ed511b7-d394-4b9d-b5da-dcdcbcd4874c") },
                    { new Guid("113b275f-982e-4419-8fc8-ba53fad0bffa"), false, "B", 2, "Maddenin Halleri - Soru 3 için Seçenek B", new Guid("7fb13328-c3ea-471c-81a5-477ca2e4e464") },
                    { new Guid("1178299b-d5b6-455c-825f-052468a1198a"), false, "C", 3, "Sayı Basamakları - Soru 5 için Seçenek C", new Guid("540e9ff6-0357-4c10-99c6-2d73726698eb") },
                    { new Guid("12241bf3-9723-49f1-9773-f29f997062a7"), false, "A", 1, "Madde ve Özellikleri - Soru 1 için Seçenek A", new Guid("27cfb64e-b730-46e9-b4c0-5c58194b6b7b") },
                    { new Guid("12e48a3b-789f-4e40-ba4b-efb8da2d22dc"), true, "A", 1, "Hücre Bölünmeleri - Soru 1 için Seçenek A", new Guid("d27798bb-be62-42cd-8a2f-b08dfa214c38") },
                    { new Guid("152a0fd4-2055-416e-b9d6-5f102310e9c7"), false, "C", 3, "Kimya Bilimi - Soru 2 için Seçenek C", new Guid("26ea5c49-cb47-40ba-8dd0-3d81bc934546") },
                    { new Guid("1559abb7-dbd1-4cc8-ad57-31177553bde1"), false, "A", 1, "Bölme ve Bölünebilme - Soru 2 için Seçenek A", new Guid("a3589401-d917-4bb5-9f98-3c210fc58ec7") },
                    { new Guid("155ab2ee-c013-4ea0-842e-b7d9d09c981d"), false, "A", 1, "Maddenin Halleri - Soru 3 için Seçenek A", new Guid("7fb13328-c3ea-471c-81a5-477ca2e4e464") },
                    { new Guid("15b800da-d770-440c-8020-30302e74c754"), false, "A", 1, "Elektrostatik - Soru 1 için Seçenek A", new Guid("be4d6081-8f2a-4b83-bd52-d312dd406fa7") },
                    { new Guid("1671177c-c890-463f-b17c-73e430e67638"), false, "A", 1, "Temel Kavramlar - Soru 2 için Seçenek A", new Guid("2e12e4bc-335e-41fe-be0a-d47ca983d560") },
                    { new Guid("1817d2ba-4c49-4eb2-a57b-70ee61fecfbc"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek A", new Guid("b8468c14-7588-48ab-9569-86b7d8a8ca0d") },
                    { new Guid("190c0fd0-a5da-4aae-9ce3-c00cfd043331"), false, "B", 2, "Rasyonel Sayılar - Soru 1 için Seçenek B", new Guid("de6628ac-bc56-465e-bad0-06c5d502a2c7") },
                    { new Guid("1ac9acf6-6446-4dfe-b1b1-7e854a702677"), false, "A", 1, "Kalıtım - Soru 4 için Seçenek A", new Guid("d534a582-6b26-4287-9937-ff4f608352a7") },
                    { new Guid("1b0a04a0-762a-4ac9-9935-bd26c93dd945"), false, "A", 1, "İş, Güç ve Enerji - Soru 2 için Seçenek A", new Guid("05e32d82-8545-4692-a9cd-adb7b7a2063b") },
                    { new Guid("1bc660a0-213b-4264-9fef-07773300a110"), false, "B", 2, "Elektrostatik - Soru 3 için Seçenek B", new Guid("620149c2-3cb6-4616-8aa7-25671167e77a") },
                    { new Guid("1beeead2-c09f-4133-8c37-becf3a3686c5"), true, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek C", new Guid("34b2990d-cdc6-4dd2-b469-ce81ed49fe23") },
                    { new Guid("1cc84b09-fa63-4c6f-b990-32deae8ec1c0"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek B", new Guid("4d17b5ae-1399-42a4-8d8d-32451680ba1f") },
                    { new Guid("1ce03f69-0827-4f30-b15c-cd0e5f07452f"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 4 için Seçenek B", new Guid("1d46d737-bba7-4b6b-8c51-58578b86ef74") },
                    { new Guid("1e076f57-f7f1-4ae1-b143-41b562f462de"), false, "A", 1, "Maddenin Halleri - Soru 2 için Seçenek A", new Guid("1f6ae920-0c90-4589-8c44-4934bcc58028") },
                    { new Guid("1edaf0a9-b601-4ae0-91f8-e268f7c11e13"), true, "D", 4, "Temel Kavramlar - Soru 2 için Seçenek D", new Guid("2e12e4bc-335e-41fe-be0a-d47ca983d560") },
                    { new Guid("1fd05c09-e703-4dd8-a453-fda34c127b9c"), true, "D", 4, "Hücre Bölünmeleri - Soru 4 için Seçenek D", new Guid("3538996d-ec48-4bd9-89eb-1eaa86b55634") },
                    { new Guid("21e4c05b-2a4e-4b73-83e1-cef0d92c72ac"), false, "A", 1, "Kalıtım - Soru 3 için Seçenek A", new Guid("88060534-8b7e-40b9-8f68-1a8152283d13") },
                    { new Guid("221be819-db8c-40e6-a447-5783d1baff95"), true, "A", 1, "Sayı Basamakları - Soru 1 için Seçenek A", new Guid("fbc475d5-a073-4981-997d-5f96c2723251") },
                    { new Guid("22a9860a-9862-43b5-9b72-6fc9c110ee7f"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek C", new Guid("4d17b5ae-1399-42a4-8d8d-32451680ba1f") },
                    { new Guid("23500466-a1bc-47d3-b5a8-8423e272d365"), false, "D", 4, "Hücre - Soru 1 için Seçenek D", new Guid("95f558eb-361b-410b-b128-33187a312dcc") },
                    { new Guid("235f44cc-09f9-4c2f-adae-c9b5241075f1"), true, "B", 2, "Kalıtım - Soru 5 için Seçenek B", new Guid("d0b8ed35-7bf8-4ec1-8bb0-5be5965b17c7") },
                    { new Guid("240cf86c-0489-4665-ae23-5753c83a0155"), false, "B", 2, "İş, Güç ve Enerji - Soru 1 için Seçenek B", new Guid("0c61c300-af71-4502-8dca-a38735279402") },
                    { new Guid("241f7cc6-261f-4320-b363-d7a484ae5aa5"), false, "A", 1, "Bölme ve Bölünebilme - Soru 3 için Seçenek A", new Guid("a0c342b0-4995-4496-9875-2abf600e70ad") },
                    { new Guid("247ce37a-0160-4825-a99a-0c85d1938811"), false, "A", 1, "Madde ve Özellikleri - Soru 3 için Seçenek A", new Guid("1a468d3c-8f5a-4967-8eb3-e69ed21ce138") },
                    { new Guid("2520e6c3-ebed-4279-a020-518d965f50e4"), false, "B", 2, "Problemler - Soru 3 için Seçenek B", new Guid("a989a459-c781-436f-a812-6773b6dbaed7") },
                    { new Guid("262ec68c-f33d-425b-a544-e8d5f0cd589e"), false, "A", 1, "Hücre - Soru 5 için Seçenek A", new Guid("c0212217-b2f6-4619-9892-1bb6ae63c8aa") },
                    { new Guid("2706ec2c-b6a7-4673-87f5-b2b15f8d5c48"), false, "D", 4, "Bölme ve Bölünebilme - Soru 1 için Seçenek D", new Guid("f84d228d-be92-4632-90e1-3a513a5186f9") },
                    { new Guid("27dc4356-b584-457f-823c-3e721d5ba4c2"), true, "B", 2, "Sayı Basamakları - Soru 4 için Seçenek B", new Guid("19d76a6f-5546-4d3e-82c6-ab74a7a47728") },
                    { new Guid("284013b5-6e83-4bf5-a258-953995281c53"), true, "C", 3, "Maddenin Halleri - Soru 3 için Seçenek C", new Guid("7fb13328-c3ea-471c-81a5-477ca2e4e464") },
                    { new Guid("286ac99a-311e-4008-8026-366433fcf5a2"), false, "B", 2, "Kimya Bilimi - Soru 1 için Seçenek B", new Guid("e1b631fc-9076-421c-baa2-cc87a182c182") },
                    { new Guid("28a5fbca-3fc7-4572-978f-838ea7024f1d"), false, "A", 1, "Temel Kavramlar - Soru 4 için Seçenek A", new Guid("6193f954-1651-4047-8ee4-f98504850b71") },
                    { new Guid("29048b75-8dc4-4aa1-87f3-1374cb236fff"), true, "C", 3, "Hücre - Soru 1 için Seçenek C", new Guid("95f558eb-361b-410b-b128-33187a312dcc") },
                    { new Guid("298dc715-2efe-4dae-9cf5-f64976698949"), false, "D", 4, "Maddenin Halleri - Soru 3 için Seçenek D", new Guid("7fb13328-c3ea-471c-81a5-477ca2e4e464") },
                    { new Guid("2a4179df-2d58-46ba-a02c-1697e77c4820"), true, "C", 3, "Kalıtım - Soru 1 için Seçenek C", new Guid("cd0cb688-6910-49e7-b97f-1b9768ceda02") },
                    { new Guid("2ae051e5-e675-4db5-ba34-8801b2510ae2"), false, "A", 1, "Elektrostatik - Soru 3 için Seçenek A", new Guid("620149c2-3cb6-4616-8aa7-25671167e77a") },
                    { new Guid("2b781e64-acd4-40cc-b1ca-6b14d8c1179c"), false, "B", 2, "Kuvvet ve Hareket - Soru 4 için Seçenek B", new Guid("1c04632a-f394-45aa-aa42-fdb468b36b54") },
                    { new Guid("2b8c57ec-0ac7-48a7-8b61-3c141f1be191"), false, "D", 4, "Elektrostatik - Soru 5 için Seçenek D", new Guid("78ffad7b-5b72-4703-a192-ea1f5e53286e") },
                    { new Guid("2c8f1364-528d-470b-bcb8-8b4532a4ace2"), false, "B", 2, "Kalıtım - Soru 4 için Seçenek B", new Guid("d534a582-6b26-4287-9937-ff4f608352a7") },
                    { new Guid("2cddd2a8-b06e-42e3-91ec-496dd0673e9a"), false, "A", 1, "Rasyonel Sayılar - Soru 2 için Seçenek A", new Guid("d54a745f-2025-4166-b22e-57ce8b62119b") },
                    { new Guid("2e156688-cef9-46e2-b391-0997f7d897c4"), false, "B", 2, "Kalıtım - Soru 2 için Seçenek B", new Guid("b2282a5d-c02d-4943-9a03-3232803ee544") },
                    { new Guid("2fbcd61f-2e27-41ae-bfce-405e447fc5c1"), true, "C", 3, "Temel Kavramlar - Soru 4 için Seçenek C", new Guid("6193f954-1651-4047-8ee4-f98504850b71") },
                    { new Guid("3108e712-2f82-4ebd-b9a9-53a72b78f12a"), true, "D", 4, "Rasyonel Sayılar - Soru 1 için Seçenek D", new Guid("de6628ac-bc56-465e-bad0-06c5d502a2c7") },
                    { new Guid("320febdd-6bea-46d4-9fe9-d1047b976b78"), false, "C", 3, "Bölme ve Bölünebilme - Soru 3 için Seçenek C", new Guid("a0c342b0-4995-4496-9875-2abf600e70ad") },
                    { new Guid("327e0e99-ebad-4a35-8562-98b30ff48fea"), false, "C", 3, "Elektrostatik - Soru 4 için Seçenek C", new Guid("043d6340-d790-47dd-a266-b378691dcd3d") },
                    { new Guid("33109783-4676-4e4a-b813-b5366a81a7a0"), false, "B", 2, "İş, Güç ve Enerji - Soru 3 için Seçenek B", new Guid("18d91c97-d883-4711-b99f-11989ff19248") },
                    { new Guid("33d4cd67-6417-4fe5-a57a-a11eb85e55c9"), true, "C", 3, "Kalıtım - Soru 4 için Seçenek C", new Guid("d534a582-6b26-4287-9937-ff4f608352a7") },
                    { new Guid("35245d09-c3af-4130-9c4d-3a453d22e8f3"), false, "A", 1, "İş, Güç ve Enerji - Soru 5 için Seçenek A", new Guid("a79688f8-3e47-4c89-8760-5a6b3860f850") },
                    { new Guid("363b8f7d-f770-4fa3-87e7-7cb7082e894f"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 5 için Seçenek B", new Guid("139d648e-a97b-4091-bb09-21bd01bf4d68") },
                    { new Guid("37279456-7219-459e-a076-310d60bf567d"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek D", new Guid("ea10acd6-608b-4806-b79f-2d2ab55a4f76") },
                    { new Guid("3757fb4a-08b5-486d-b6ec-24d02dbf3b2d"), false, "B", 2, "Madde ve Özellikleri - Soru 2 için Seçenek B", new Guid("43b3905f-c7a1-41dd-b6c7-887944c214f8") },
                    { new Guid("37acaa56-345c-40db-8358-1b8e5313c055"), true, "A", 1, "Temel Kavramlar - Soru 5 için Seçenek A", new Guid("46b72d22-3af7-4b24-ac9a-44586519a14a") },
                    { new Guid("38090ff2-0f9f-499a-a133-38f0cee965d8"), false, "C", 3, "Elektrostatik - Soru 1 için Seçenek C", new Guid("be4d6081-8f2a-4b83-bd52-d312dd406fa7") },
                    { new Guid("38a67478-b624-42e1-acff-90f1191fc978"), false, "B", 2, "Sayı Basamakları - Soru 2 için Seçenek B", new Guid("82bdb667-44a1-4b80-b10b-f4fb7facf3c1") },
                    { new Guid("38c860c4-6070-476b-a52e-2c55feec1d00"), true, "B", 2, "Madde ve Özellikleri - Soru 5 için Seçenek B", new Guid("1e1f5424-2284-453f-9c37-963233005ac2") },
                    { new Guid("38f801a6-866d-46f7-81f0-ce071cdfc36b"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek B", new Guid("d6fdb98c-7910-49d0-a210-f380edea7791") },
                    { new Guid("39678553-1583-4542-a324-e4bb4a47e5b5"), true, "D", 4, "Fizik Bilimine Giriş - Soru 4 için Seçenek D", new Guid("c61589b3-4f7d-436b-9a7b-f7ad4f25c046") },
                    { new Guid("39eb7fe7-2857-4ff7-accf-4dd3f15589b5"), false, "D", 4, "Bölme ve Bölünebilme - Soru 3 için Seçenek D", new Guid("a0c342b0-4995-4496-9875-2abf600e70ad") },
                    { new Guid("39f6a7c4-307b-4d4d-b9ca-727ba8ac5985"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek A", new Guid("4d17b5ae-1399-42a4-8d8d-32451680ba1f") },
                    { new Guid("3b98e0c6-2fe6-43c4-b0fb-bc8a889a999d"), true, "D", 4, "Maddenin Halleri - Soru 5 için Seçenek D", new Guid("f721fd66-2cd9-4531-bb43-4794e743d80f") },
                    { new Guid("3be86f65-9d6f-472f-b70f-8949a874c390"), false, "B", 2, "Maddenin Halleri - Soru 4 için Seçenek B", new Guid("3d62281a-b911-444d-891b-984de319fe68") },
                    { new Guid("3e404241-3861-4f3a-bcb9-a421f5a9997f"), false, "B", 2, "Hücre Bölünmeleri - Soru 4 için Seçenek B", new Guid("3538996d-ec48-4bd9-89eb-1eaa86b55634") },
                    { new Guid("3e67f3f0-2a61-4a84-8af2-8608929492c0"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek D", new Guid("0bbde36b-91ec-4ae1-b758-f5118102484a") },
                    { new Guid("405195ad-b431-4eee-983e-c6a63a3734ac"), false, "B", 2, "Temel Kavramlar - Soru 1 için Seçenek B", new Guid("3f05a1f7-39fa-4bd8-82ec-5db7cd7b2e87") },
                    { new Guid("41edb128-fe7f-425f-a000-86cf2162baa8"), false, "C", 3, "Kimya Bilimi - Soru 3 için Seçenek C", new Guid("471fa72e-a88a-4503-a932-068d224b9ba7") },
                    { new Guid("41f17fe0-db8a-4c19-81a4-a75ab8a86b9a"), false, "D", 4, "Madde ve Özellikleri - Soru 1 için Seçenek D", new Guid("27cfb64e-b730-46e9-b4c0-5c58194b6b7b") },
                    { new Guid("4282f7cd-351c-449b-ab4d-c9588809e444"), false, "B", 2, "Bölme ve Bölünebilme - Soru 4 için Seçenek B", new Guid("563f05a2-5a15-4bbb-9b5c-353dc45f70c3") },
                    { new Guid("42d354b4-0aa1-40fd-b920-93c8b8d6bc58"), false, "D", 4, "Sayı Basamakları - Soru 5 için Seçenek D", new Guid("540e9ff6-0357-4c10-99c6-2d73726698eb") },
                    { new Guid("43412f50-5ed5-494b-bfc4-cc33d6aef5e0"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek B", new Guid("ca4b97ac-6382-40f1-8df5-7ba899d4372f") },
                    { new Guid("445ed03f-97d0-4ba1-804e-480ab24cfd97"), false, "A", 1, "Rasyonel Sayılar - Soru 1 için Seçenek A", new Guid("de6628ac-bc56-465e-bad0-06c5d502a2c7") },
                    { new Guid("44acd020-57d2-41db-b2d4-e400c26ba3cb"), true, "A", 1, "Madde ve Özellikleri - Soru 4 için Seçenek A", new Guid("007903b8-17e9-49e4-b732-1ed680d84cb2") },
                    { new Guid("44fc9678-96cd-45b9-a8d9-ef5b3c073eca"), false, "D", 4, "Hücre Bölünmeleri - Soru 3 için Seçenek D", new Guid("ce93e37c-5cdb-40ee-8d42-7bda3a6e62b5") },
                    { new Guid("450e25fe-42ed-466a-8360-4aab4dea0e6f"), false, "C", 3, "Hücre - Soru 5 için Seçenek C", new Guid("c0212217-b2f6-4619-9892-1bb6ae63c8aa") },
                    { new Guid("46305e9c-a7c0-4493-9399-b5e8dff052a9"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek C", new Guid("412f6db2-18c0-49e1-9db2-5d9383cf4f08") },
                    { new Guid("46d51414-9cbb-4b32-a7a1-1600d8c22eb9"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek A", new Guid("db6e78ba-f5b3-4754-8396-6a62e566b26a") },
                    { new Guid("46e7c973-485f-49f6-b751-d991733ed121"), false, "B", 2, "Hücre Bölünmeleri - Soru 5 için Seçenek B", new Guid("2b4ac114-f67d-440f-9892-8581eabb3bab") },
                    { new Guid("470ab585-5b86-40d6-9025-d2a2eb20bec6"), false, "D", 4, "Kimya Bilimi - Soru 3 için Seçenek D", new Guid("471fa72e-a88a-4503-a932-068d224b9ba7") },
                    { new Guid("48fa591b-0c1c-4565-a8be-35b4ef28fb9c"), false, "D", 4, "Sayı Basamakları - Soru 3 için Seçenek D", new Guid("c1883ebc-94f3-4b09-b5e6-913470ac24f2") },
                    { new Guid("4945a42e-9c9f-44b5-a3f6-02bdf1e7f398"), false, "C", 3, "Hücre Bölünmeleri - Soru 2 için Seçenek C", new Guid("2176b97f-c705-4f95-9360-9bd35e1c0b14") },
                    { new Guid("4a15dc9a-d45a-401b-b9f2-438f0a48b690"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 4 için Seçenek D", new Guid("152a3643-eac5-4d14-a7bf-c1b46b376270") },
                    { new Guid("4afb2734-f1f3-4ec6-b2b1-cf7da0ea12c6"), false, "D", 4, "Hücre Bölünmeleri - Soru 1 için Seçenek D", new Guid("d27798bb-be62-42cd-8a2f-b08dfa214c38") },
                    { new Guid("4b393468-5ee4-40e9-bd47-64d72246f141"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek D", new Guid("146e1fb0-2242-43b0-a29f-9231913a84d5") },
                    { new Guid("4c462c87-4301-4d14-9144-4ecddc4d5653"), false, "C", 3, "Elektrostatik - Soru 2 için Seçenek C", new Guid("9145349a-77f3-4b5b-8712-7d1a0bc2d6b5") },
                    { new Guid("4d7b8307-2d66-41eb-8302-a0ef3f3c1310"), true, "A", 1, "Bölme ve Bölünebilme - Soru 1 için Seçenek A", new Guid("f84d228d-be92-4632-90e1-3a513a5186f9") },
                    { new Guid("4e216e78-73bd-4be4-a723-0bf5853e1d15"), false, "A", 1, "Kalıtım - Soru 5 için Seçenek A", new Guid("d0b8ed35-7bf8-4ec1-8bb0-5be5965b17c7") },
                    { new Guid("4e56fae1-d514-4cad-a267-39c9a6325d76"), false, "D", 4, "İş, Güç ve Enerji - Soru 1 için Seçenek D", new Guid("0c61c300-af71-4502-8dca-a38735279402") },
                    { new Guid("4f0c0d62-4499-4b86-ba0e-33e8972559a0"), false, "B", 2, "Sayı Basamakları - Soru 5 için Seçenek B", new Guid("540e9ff6-0357-4c10-99c6-2d73726698eb") },
                    { new Guid("503aca4b-dd4f-4fa1-9110-5a9b4c08c082"), false, "C", 3, "Kuvvet ve Hareket - Soru 5 için Seçenek C", new Guid("efb2d9d3-a3a9-404e-b378-e58f29a73007") },
                    { new Guid("504f9e84-d39e-487b-bc9b-fe421cf9df93"), false, "D", 4, "Hücre - Soru 2 için Seçenek D", new Guid("5b0f6c26-296d-4d8a-b3ee-4b507e05c03b") },
                    { new Guid("50a14d38-3e5f-41b4-b6a5-26f954e9321a"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek C", new Guid("29a31835-aa03-4eb8-9d12-8c4491c43221") },
                    { new Guid("5347da74-d0de-43ff-b833-1e1435d1965d"), false, "A", 1, "Madde ve Özellikleri - Soru 2 için Seçenek A", new Guid("43b3905f-c7a1-41dd-b6c7-887944c214f8") },
                    { new Guid("539b0b0c-7007-4ec6-91d0-faace53e902e"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek B", new Guid("0bbde36b-91ec-4ae1-b758-f5118102484a") },
                    { new Guid("5425c007-f838-4894-8bfe-b0de56210309"), true, "C", 3, "İş, Güç ve Enerji - Soru 5 için Seçenek C", new Guid("a79688f8-3e47-4c89-8760-5a6b3860f850") },
                    { new Guid("549a86e7-cb39-4d3b-9a5f-30380ac61f04"), true, "D", 4, "Rasyonel Sayılar - Soru 5 için Seçenek D", new Guid("ed5a5f5f-1cfa-41be-92e6-3ca41a64ce75") },
                    { new Guid("54b8dad9-9054-4e75-814e-bcfd54b8a686"), false, "B", 2, "Bölme ve Bölünebilme - Soru 1 için Seçenek B", new Guid("f84d228d-be92-4632-90e1-3a513a5186f9") },
                    { new Guid("55b6abff-fec2-4f9d-8938-4666fb1d460d"), false, "C", 3, "Hücre Bölünmeleri - Soru 1 için Seçenek C", new Guid("d27798bb-be62-42cd-8a2f-b08dfa214c38") },
                    { new Guid("55f662bb-ed59-4317-a1d6-a3b59e5111ce"), true, "C", 3, "Elektrostatik - Soru 3 için Seçenek C", new Guid("620149c2-3cb6-4616-8aa7-25671167e77a") },
                    { new Guid("56b29350-d3dc-4626-9388-d95d9d753916"), true, "D", 4, "Kuvvet ve Hareket - Soru 2 için Seçenek D", new Guid("c2c7b026-71af-45c0-95b2-fa443024fb52") },
                    { new Guid("573c4324-80c6-44c1-a430-f20ee3ac7c82"), false, "A", 1, "Fizik Bilimine Giriş - Soru 1 için Seçenek A", new Guid("14f6577b-0d37-4a5c-9250-bf1de916dda2") },
                    { new Guid("57e1921e-dce6-4cb7-980f-87d852589a8a"), false, "C", 3, "Hücre - Soru 4 için Seçenek C", new Guid("66d184dc-b34e-470c-a630-e61ff6602da5") },
                    { new Guid("58225b09-be4b-4ed4-ba55-eac4665cc959"), false, "C", 3, "Rasyonel Sayılar - Soru 5 için Seçenek C", new Guid("ed5a5f5f-1cfa-41be-92e6-3ca41a64ce75") },
                    { new Guid("58564831-1f32-4339-be60-286bf6fa4cee"), false, "D", 4, "Hücre - Soru 3 için Seçenek D", new Guid("815fcedc-c0c2-465f-963b-afe800ab5659") },
                    { new Guid("59215fb0-c9f7-46db-bc6f-6e65a3897a46"), false, "C", 3, "Rasyonel Sayılar - Soru 3 için Seçenek C", new Guid("f6f2e5ba-950f-4a48-ab01-e96f225c1272") },
                    { new Guid("5b07f669-8311-44e3-9efe-c0338aa81130"), false, "A", 1, "Kuvvet ve Hareket - Soru 2 için Seçenek A", new Guid("c2c7b026-71af-45c0-95b2-fa443024fb52") },
                    { new Guid("5b95b5e6-d3b5-483d-8a25-715589c795ee"), false, "D", 4, "Problemler - Soru 4 için Seçenek D", new Guid("fa6f2db7-a9f1-408a-abfb-8af8dc2a1faa") },
                    { new Guid("5bb86cd9-6eb2-4ef1-914d-7c4ef15f9d01"), false, "D", 4, "Kalıtım - Soru 1 için Seçenek D", new Guid("cd0cb688-6910-49e7-b97f-1b9768ceda02") },
                    { new Guid("5c448fd8-38c9-477e-88f4-602f91240452"), false, "C", 3, "Temel Kavramlar - Soru 5 için Seçenek C", new Guid("46b72d22-3af7-4b24-ac9a-44586519a14a") },
                    { new Guid("5c4ec438-ca8e-4965-9f9f-5c48c97013da"), false, "C", 3, "Maddenin Halleri - Soru 2 için Seçenek C", new Guid("1f6ae920-0c90-4589-8c44-4934bcc58028") },
                    { new Guid("5d124bd2-6159-4ccf-bd68-5aa3bc78e863"), true, "A", 1, "Sayı Basamakları - Soru 3 için Seçenek A", new Guid("c1883ebc-94f3-4b09-b5e6-913470ac24f2") },
                    { new Guid("5dec05a0-a953-471d-9553-095f588fe359"), false, "C", 3, "Kuvvet ve Hareket - Soru 1 için Seçenek C", new Guid("69ded171-0d51-4273-be01-3165bcb19c5f") },
                    { new Guid("5e172ec8-1c9c-46ed-b307-13d0a18bcfb0"), false, "D", 4, "Hücre Bölünmeleri - Soru 5 için Seçenek D", new Guid("2b4ac114-f67d-440f-9892-8581eabb3bab") },
                    { new Guid("5fb2663f-be83-4dbf-89bf-70bc9d9d6ad6"), false, "D", 4, "Rasyonel Sayılar - Soru 4 için Seçenek D", new Guid("af9bdb27-2430-4199-b441-3b4026095e43") },
                    { new Guid("5fea1ec8-fc6d-4236-bed7-2a2ddbd110e1"), false, "D", 4, "Hücre - Soru 4 için Seçenek D", new Guid("66d184dc-b34e-470c-a630-e61ff6602da5") },
                    { new Guid("6028c0d3-09d0-4a6a-b43f-dd55144e737e"), false, "A", 1, "Hücre - Soru 4 için Seçenek A", new Guid("66d184dc-b34e-470c-a630-e61ff6602da5") },
                    { new Guid("60ddae31-cbb1-4435-b1ab-0e25e6cff980"), true, "C", 3, "İş, Güç ve Enerji - Soru 3 için Seçenek C", new Guid("18d91c97-d883-4711-b99f-11989ff19248") },
                    { new Guid("614402cd-6d72-47ad-b5d5-84a8c885510b"), true, "C", 3, "Hücre - Soru 2 için Seçenek C", new Guid("5b0f6c26-296d-4d8a-b3ee-4b507e05c03b") },
                    { new Guid("615b88ce-c9eb-4907-8df7-66d052539584"), true, "D", 4, "Kuvvet ve Hareket - Soru 5 için Seçenek D", new Guid("efb2d9d3-a3a9-404e-b378-e58f29a73007") },
                    { new Guid("618ec158-fd24-4817-bf84-3f8e772294b0"), false, "D", 4, "Kimya Bilimi - Soru 2 için Seçenek D", new Guid("26ea5c49-cb47-40ba-8dd0-3d81bc934546") },
                    { new Guid("61c2c670-14d5-4a64-92f5-e7f2bda9696b"), false, "D", 4, "Kimya Bilimi - Soru 5 için Seçenek D", new Guid("57dbf6ef-3626-4bea-8179-b197e52d5113") },
                    { new Guid("6209bc10-6402-41b2-8797-457d3e9abc85"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek C", new Guid("383bcd24-7c1a-4723-8b5b-5f7fa11bb8d9") },
                    { new Guid("63064593-88b4-430f-957a-5d5770e67e5b"), false, "A", 1, "Hücre - Soru 3 için Seçenek A", new Guid("815fcedc-c0c2-465f-963b-afe800ab5659") },
                    { new Guid("63599e5e-ff63-41bf-b60e-c873ba5d27e4"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 5 için Seçenek B", new Guid("21e95a17-b30a-455c-afe0-cc4e1301420a") },
                    { new Guid("6363e87b-4c40-4784-994d-d7551f9c9028"), true, "A", 1, "Problemler - Soru 4 için Seçenek A", new Guid("fa6f2db7-a9f1-408a-abfb-8af8dc2a1faa") },
                    { new Guid("63c89ad1-6fc2-49a4-b6ad-69500488a050"), false, "C", 3, "Fizik Bilimine Giriş - Soru 5 için Seçenek C", new Guid("f149242c-1aba-4edb-9148-9d451a2dc9a5") },
                    { new Guid("652c3bdc-8998-4939-8e9f-1ca3e2ee307c"), false, "C", 3, "Maddenin Halleri - Soru 4 için Seçenek C", new Guid("3d62281a-b911-444d-891b-984de319fe68") },
                    { new Guid("6553445d-eb3d-4540-b6d2-3fdc50aed18e"), true, "B", 2, "Bölme ve Bölünebilme - Soru 3 için Seçenek B", new Guid("a0c342b0-4995-4496-9875-2abf600e70ad") },
                    { new Guid("67bc32b3-66f9-4966-920e-ebaa58cfd688"), false, "B", 2, "Fizik Bilimine Giriş - Soru 1 için Seçenek B", new Guid("14f6577b-0d37-4a5c-9250-bf1de916dda2") },
                    { new Guid("6885df77-f619-462b-8219-ceb9d465e48d"), true, "A", 1, "Fizik Bilimine Giriş - Soru 5 için Seçenek A", new Guid("f149242c-1aba-4edb-9148-9d451a2dc9a5") },
                    { new Guid("6a181f01-1061-4af9-a393-6ed754b8b2c5"), true, "C", 3, "Kimya Bilimi - Soru 1 için Seçenek C", new Guid("e1b631fc-9076-421c-baa2-cc87a182c182") },
                    { new Guid("6a514d93-cbf3-45ae-b5b9-b81ef1725945"), true, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek B", new Guid("9904cc1c-583d-46ca-a149-bfc0c23ac171") },
                    { new Guid("6a79cd97-455f-452f-97f6-6c4ecebe6ba1"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek B", new Guid("db6e78ba-f5b3-4754-8396-6a62e566b26a") },
                    { new Guid("6a958894-bbd1-49ab-ae4f-82fc600115c5"), true, "C", 3, "Madde ve Özellikleri - Soru 2 için Seçenek C", new Guid("43b3905f-c7a1-41dd-b6c7-887944c214f8") },
                    { new Guid("6bc1719e-c425-4c21-900f-a45c8c3591db"), false, "B", 2, "Elektrostatik - Soru 5 için Seçenek B", new Guid("78ffad7b-5b72-4703-a192-ea1f5e53286e") },
                    { new Guid("6cc667a3-b309-4405-9971-ccbcae55ed34"), false, "B", 2, "Problemler - Soru 4 için Seçenek B", new Guid("fa6f2db7-a9f1-408a-abfb-8af8dc2a1faa") },
                    { new Guid("6d0dcd3a-6a1d-456f-9356-1f2ded9a3e67"), true, "A", 1, "Atom ve Periyodik Sistem - Soru 5 için Seçenek A", new Guid("139d648e-a97b-4091-bb09-21bd01bf4d68") },
                    { new Guid("6e538bdb-7e52-4f25-b957-d548d606ad1f"), false, "C", 3, "Bölme ve Bölünebilme - Soru 1 için Seçenek C", new Guid("f84d228d-be92-4632-90e1-3a513a5186f9") },
                    { new Guid("6e955e22-0c39-4bc8-8253-afd5a89a8229"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 2 için Seçenek B", new Guid("267e405f-f997-47c6-8e8a-5ca5a995bf82") },
                    { new Guid("6eab2ea8-fe41-4568-99d0-39bc44e78893"), false, "A", 1, "Kuvvet ve Hareket - Soru 3 için Seçenek A", new Guid("406d0dfb-972b-4cf8-90cd-f4957f91c739") },
                    { new Guid("6f207468-d263-416f-92f4-acc3843ebc2e"), true, "B", 2, "Hücre - Soru 5 için Seçenek B", new Guid("c0212217-b2f6-4619-9892-1bb6ae63c8aa") },
                    { new Guid("6fa80e17-1b03-4e20-93ce-3a2f8617c4ea"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek C", new Guid("d6fdb98c-7910-49d0-a210-f380edea7791") },
                    { new Guid("6fe28787-5874-428c-b095-5597dfac85d4"), true, "B", 2, "Hücre - Soru 3 için Seçenek B", new Guid("815fcedc-c0c2-465f-963b-afe800ab5659") },
                    { new Guid("70770d6b-879e-4752-8228-b63ab12e4fd5"), false, "A", 1, "Kimya Bilimi - Soru 3 için Seçenek A", new Guid("471fa72e-a88a-4503-a932-068d224b9ba7") },
                    { new Guid("70eb6ecd-9f63-4b45-a691-e7924b4a71b1"), true, "D", 4, "Bölme ve Bölünebilme - Soru 4 için Seçenek D", new Guid("563f05a2-5a15-4bbb-9b5c-353dc45f70c3") },
                    { new Guid("7108929a-b62c-4edb-bddb-a8e78ac4e1ce"), false, "B", 2, "Rasyonel Sayılar - Soru 2 için Seçenek B", new Guid("d54a745f-2025-4166-b22e-57ce8b62119b") },
                    { new Guid("72184319-c04f-4c81-ac4a-a0310572b671"), false, "A", 1, "Kimya Bilimi - Soru 1 için Seçenek A", new Guid("e1b631fc-9076-421c-baa2-cc87a182c182") },
                    { new Guid("726741be-5152-4770-b274-21b70772cab0"), false, "A", 1, "Fizik Bilimine Giriş - Soru 4 için Seçenek A", new Guid("c61589b3-4f7d-436b-9a7b-f7ad4f25c046") },
                    { new Guid("7287b04a-1726-4291-9185-15f5709dfc5b"), false, "D", 4, "Temel Kavramlar - Soru 5 için Seçenek D", new Guid("46b72d22-3af7-4b24-ac9a-44586519a14a") },
                    { new Guid("72eef85b-5b56-497d-99ed-a2adcb58409b"), false, "C", 3, "Kimya Bilimi - Soru 4 için Seçenek C", new Guid("90560d53-059e-406f-8f8a-9da46f2abc1c") },
                    { new Guid("735fe81c-344d-4768-baef-8e8002ee9324"), false, "A", 1, "Maddenin Halleri - Soru 5 için Seçenek A", new Guid("f721fd66-2cd9-4531-bb43-4794e743d80f") },
                    { new Guid("73955cc2-5f05-4703-aa82-9eefa8b51880"), true, "A", 1, "Kimya Bilimi - Soru 2 için Seçenek A", new Guid("26ea5c49-cb47-40ba-8dd0-3d81bc934546") },
                    { new Guid("741838b5-1c02-42b7-9262-eea279a6edd9"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 3 için Seçenek D", new Guid("d49b0490-9425-4075-94d5-d4428abbb0ba") },
                    { new Guid("7478f6f8-d1eb-4567-ad65-7c0a36395494"), false, "B", 2, "Temel Kavramlar - Soru 5 için Seçenek B", new Guid("46b72d22-3af7-4b24-ac9a-44586519a14a") },
                    { new Guid("7539d026-0089-4e63-8475-be096ceb7a33"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 1 için Seçenek D", new Guid("ad85a2df-ab4b-479a-8130-7d821136a8ee") },
                    { new Guid("75d1897d-02c9-4d56-a39f-05319b947650"), false, "C", 3, "Sayı Basamakları - Soru 4 için Seçenek C", new Guid("19d76a6f-5546-4d3e-82c6-ab74a7a47728") },
                    { new Guid("75fda24f-d697-4bb0-8a56-626be4eee90c"), true, "D", 4, "Kuvvet ve Hareket - Soru 3 için Seçenek D", new Guid("406d0dfb-972b-4cf8-90cd-f4957f91c739") },
                    { new Guid("76830861-ad0b-4c29-b463-816b6f267b66"), true, "A", 1, "Kimya Bilimi - Soru 4 için Seçenek A", new Guid("90560d53-059e-406f-8f8a-9da46f2abc1c") },
                    { new Guid("782defff-54e5-4bed-9dce-eb6b8ffee460"), true, "D", 4, "Fizik Bilimine Giriş - Soru 1 için Seçenek D", new Guid("14f6577b-0d37-4a5c-9250-bf1de916dda2") },
                    { new Guid("783c06e2-2b40-4fd0-a2f2-c7745d4333e2"), false, "B", 2, "Kuvvet ve Hareket - Soru 3 için Seçenek B", new Guid("406d0dfb-972b-4cf8-90cd-f4957f91c739") },
                    { new Guid("78b57f5f-2a41-4532-959f-19692f804057"), false, "C", 3, "Rasyonel Sayılar - Soru 2 için Seçenek C", new Guid("d54a745f-2025-4166-b22e-57ce8b62119b") },
                    { new Guid("7903afdb-4b06-4aea-bd8d-06d7ac88b3dd"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 3 için Seçenek D", new Guid("c745d452-2f55-4c88-b054-f003b104e723") },
                    { new Guid("7924eafa-9d96-4d45-ada6-0bb804615e9d"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 3 için Seçenek A", new Guid("d49b0490-9425-4075-94d5-d4428abbb0ba") },
                    { new Guid("79915473-4f9c-4cfc-af2b-e1bdee315706"), false, "C", 3, "Problemler - Soru 2 için Seçenek C", new Guid("7321bc85-d438-4b05-a823-81c1120da3da") },
                    { new Guid("7b758507-4de9-46b1-8706-044cad977cbe"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 5 için Seçenek A", new Guid("21e95a17-b30a-455c-afe0-cc4e1301420a") },
                    { new Guid("7bb8e7b4-6426-4c78-9fba-a30408e86282"), false, "B", 2, "Fizik Bilimine Giriş - Soru 4 için Seçenek B", new Guid("c61589b3-4f7d-436b-9a7b-f7ad4f25c046") },
                    { new Guid("7d1c38c7-7375-45a6-9f4f-375d57f34732"), false, "A", 1, "Kuvvet ve Hareket - Soru 1 için Seçenek A", new Guid("69ded171-0d51-4273-be01-3165bcb19c5f") },
                    { new Guid("7d93a499-b87a-4f92-a772-ef7034aaa37c"), false, "A", 1, "Fizik Bilimine Giriş - Soru 2 için Seçenek A", new Guid("5199d68a-3aec-4d88-80ae-dd7a45d40fd0") },
                    { new Guid("7de151b9-666f-4953-bea2-f25ebbf272b5"), false, "A", 1, "Problemler - Soru 3 için Seçenek A", new Guid("a989a459-c781-436f-a812-6773b6dbaed7") },
                    { new Guid("7ed13d2d-bef0-4325-a315-d3f21c8c4038"), true, "A", 1, "Kalıtım - Soru 2 için Seçenek A", new Guid("b2282a5d-c02d-4943-9a03-3232803ee544") },
                    { new Guid("81028b1c-e4a8-4418-b45f-4db68cbf2f43"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek A", new Guid("383bcd24-7c1a-4723-8b5b-5f7fa11bb8d9") },
                    { new Guid("810dd1b7-5607-450c-bb5d-be16716b189a"), false, "B", 2, "Kuvvet ve Hareket - Soru 5 için Seçenek B", new Guid("efb2d9d3-a3a9-404e-b378-e58f29a73007") },
                    { new Guid("8117c0f4-49b6-4a85-b147-d0b846f74fb1"), false, "A", 1, "Problemler - Soru 2 için Seçenek A", new Guid("7321bc85-d438-4b05-a823-81c1120da3da") },
                    { new Guid("8163d73c-ea6d-4190-b1f6-146385d934a8"), false, "B", 2, "Madde ve Özellikleri - Soru 3 için Seçenek B", new Guid("1a468d3c-8f5a-4967-8eb3-e69ed21ce138") },
                    { new Guid("81d181e3-3d3f-4b30-85ff-90ff8b2b8ae3"), false, "B", 2, "Kalıtım - Soru 1 için Seçenek B", new Guid("cd0cb688-6910-49e7-b97f-1b9768ceda02") },
                    { new Guid("81de0497-8d16-416b-9b2d-234e22ccc8fd"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek A", new Guid("29a31835-aa03-4eb8-9d12-8c4491c43221") },
                    { new Guid("81fc179f-9f60-4847-8a0c-ddcccfaea9cd"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 2 için Seçenek A", new Guid("138b10e4-a139-426e-816e-ae353b9a4211") },
                    { new Guid("8225bede-ff47-4cc8-93e7-54c590a516b3"), false, "C", 3, "Kalıtım - Soru 3 için Seçenek C", new Guid("88060534-8b7e-40b9-8f68-1a8152283d13") },
                    { new Guid("827173bd-dfc6-4a50-ae03-fab1cc8690ee"), true, "C", 3, "Bölme ve Bölünebilme - Soru 2 için Seçenek C", new Guid("a3589401-d917-4bb5-9f98-3c210fc58ec7") },
                    { new Guid("830e5a3d-74d2-497b-8170-12ff633c6876"), false, "D", 4, "Problemler - Soru 5 için Seçenek D", new Guid("dd295827-7146-44ba-a342-5094d90dfe59") },
                    { new Guid("8468ce4f-8213-491c-8bfe-e906ba2079af"), false, "B", 2, "Kimya Bilimi - Soru 5 için Seçenek B", new Guid("57dbf6ef-3626-4bea-8179-b197e52d5113") },
                    { new Guid("8500d215-7245-4d27-aca0-677066661627"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek D", new Guid("412f6db2-18c0-49e1-9db2-5d9383cf4f08") },
                    { new Guid("85967fa8-8b93-47fa-9f1b-3119ee8ac319"), false, "C", 3, "Rasyonel Sayılar - Soru 1 için Seçenek C", new Guid("de6628ac-bc56-465e-bad0-06c5d502a2c7") },
                    { new Guid("86aa62d7-f42c-4407-8c1e-fd1972992b2c"), true, "C", 3, "Temel Kavramlar - Soru 1 için Seçenek C", new Guid("3f05a1f7-39fa-4bd8-82ec-5db7cd7b2e87") },
                    { new Guid("8737d38d-3a07-4c06-a177-0379de72eaff"), false, "B", 2, "Hücre Bölünmeleri - Soru 1 için Seçenek B", new Guid("d27798bb-be62-42cd-8a2f-b08dfa214c38") },
                    { new Guid("8816dcd2-147c-42c2-8a2a-25bcb0b95c21"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek B", new Guid("b8468c14-7588-48ab-9569-86b7d8a8ca0d") },
                    { new Guid("887481c6-12e4-4a83-a86f-7987e8c0462a"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek D", new Guid("ca4b97ac-6382-40f1-8df5-7ba899d4372f") },
                    { new Guid("88ae71d9-fe57-46d5-b95f-c8865f4ae565"), false, "C", 3, "Temel Kavramlar - Soru 2 için Seçenek C", new Guid("2e12e4bc-335e-41fe-be0a-d47ca983d560") },
                    { new Guid("8a3d9b3e-7f3a-425d-a42d-b8f121bd00b9"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 4 için Seçenek A", new Guid("1d46d737-bba7-4b6b-8c51-58578b86ef74") },
                    { new Guid("8a541576-a3a6-47cb-bcd4-790f19c16647"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 1 için Seçenek A", new Guid("2df9815e-35de-426e-b606-1a85eec77cdc") },
                    { new Guid("8a6928f8-ff36-43d2-9a09-11847b2cdaff"), false, "A", 1, "Elektrostatik - Soru 4 için Seçenek A", new Guid("043d6340-d790-47dd-a266-b378691dcd3d") },
                    { new Guid("8a7deace-1066-47c9-b4cb-3aef956df8f6"), false, "B", 2, "Rasyonel Sayılar - Soru 3 için Seçenek B", new Guid("f6f2e5ba-950f-4a48-ab01-e96f225c1272") },
                    { new Guid("8aa31583-49f5-4e35-adea-145a6bbd09dd"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 2 için Seçenek C", new Guid("138b10e4-a139-426e-816e-ae353b9a4211") },
                    { new Guid("8b265f06-b40e-4e7a-a710-eb4c63fd5a69"), false, "C", 3, "Sayı Basamakları - Soru 1 için Seçenek C", new Guid("fbc475d5-a073-4981-997d-5f96c2723251") },
                    { new Guid("8c04b5d1-d541-47b2-8e16-b4d01ffdfb48"), false, "D", 4, "Kimya Bilimi - Soru 1 için Seçenek D", new Guid("e1b631fc-9076-421c-baa2-cc87a182c182") },
                    { new Guid("8c27fe36-3902-40c6-92e8-35e1d2697886"), false, "A", 1, "Kalıtım - Soru 1 için Seçenek A", new Guid("cd0cb688-6910-49e7-b97f-1b9768ceda02") },
                    { new Guid("8c957b82-ea4c-4fb2-9ec2-a5ceba3108d0"), false, "B", 2, "Kuvvet ve Hareket - Soru 2 için Seçenek B", new Guid("c2c7b026-71af-45c0-95b2-fa443024fb52") },
                    { new Guid("8e4274d3-753f-4295-bffc-132d7613ad9c"), false, "A", 1, "Hücre - Soru 2 için Seçenek A", new Guid("5b0f6c26-296d-4d8a-b3ee-4b507e05c03b") },
                    { new Guid("8e5f5e09-fb3f-46f7-b090-cc2c58c50709"), false, "B", 2, "Hücre Bölünmeleri - Soru 2 için Seçenek B", new Guid("2176b97f-c705-4f95-9360-9bd35e1c0b14") },
                    { new Guid("8eb8eb8e-5700-40eb-9f54-e227c7979958"), false, "A", 1, "Bölme ve Bölünebilme - Soru 4 için Seçenek A", new Guid("563f05a2-5a15-4bbb-9b5c-353dc45f70c3") },
                    { new Guid("8f6fb337-d6ab-4404-9f0d-f2325755e9fc"), true, "A", 1, "Bölme ve Bölünebilme - Soru 5 için Seçenek A", new Guid("9ba36baa-0b55-498f-afa7-566d104317cd") },
                    { new Guid("90f2092c-d510-471d-9b21-e380493f1d49"), false, "D", 4, "Temel Kavramlar - Soru 4 için Seçenek D", new Guid("6193f954-1651-4047-8ee4-f98504850b71") },
                    { new Guid("918834a3-ae21-4793-b6d8-5c3540e16399"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek D", new Guid("400bdfdf-789e-4ed3-bc7d-d743f4b84b66") },
                    { new Guid("926c2a4a-c85b-4607-a22c-0621e94be155"), false, "C", 3, "Kalıtım - Soru 2 için Seçenek C", new Guid("b2282a5d-c02d-4943-9a03-3232803ee544") },
                    { new Guid("928b9fb2-84e0-4410-a8f0-76248c0c145c"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek D", new Guid("db6e78ba-f5b3-4754-8396-6a62e566b26a") },
                    { new Guid("94e30689-3b8a-4040-ad3d-d7fb7967d2de"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek A", new Guid("146e1fb0-2242-43b0-a29f-9231913a84d5") },
                    { new Guid("95e3efb0-f3ec-49d7-891b-248170efaae9"), true, "B", 2, "Kalıtım - Soru 3 için Seçenek B", new Guid("88060534-8b7e-40b9-8f68-1a8152283d13") },
                    { new Guid("95f103fd-3f8b-4ac4-9202-0921c35c952f"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 4 için Seçenek D", new Guid("1d46d737-bba7-4b6b-8c51-58578b86ef74") },
                    { new Guid("961c1409-3040-4de8-8176-4e58c5d0162c"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek A", new Guid("ea10acd6-608b-4806-b79f-2d2ab55a4f76") },
                    { new Guid("96916f9a-b0a3-408b-ae98-b5c47326394b"), false, "B", 2, "Rasyonel Sayılar - Soru 5 için Seçenek B", new Guid("ed5a5f5f-1cfa-41be-92e6-3ca41a64ce75") },
                    { new Guid("96fa2201-191d-488b-b1ff-aadbab128494"), false, "C", 3, "Hücre Bölünmeleri - Soru 5 için Seçenek C", new Guid("2b4ac114-f67d-440f-9892-8581eabb3bab") },
                    { new Guid("96ff3960-8946-4202-8c84-9504793bf022"), false, "A", 1, "Hücre Bölünmeleri - Soru 3 için Seçenek A", new Guid("ce93e37c-5cdb-40ee-8d42-7bda3a6e62b5") },
                    { new Guid("971146c1-5904-4630-8bbb-b3b6fbc44988"), false, "B", 2, "Temel Kavramlar - Soru 3 için Seçenek B", new Guid("0d1aa2c6-af98-4384-86d4-630f67bee88b") },
                    { new Guid("971e95d8-906e-48c9-a7e4-02ea42ee68f1"), false, "C", 3, "İş, Güç ve Enerji - Soru 4 için Seçenek C", new Guid("8ae253de-b346-4784-a87c-6603cf699ac2") },
                    { new Guid("97a4a113-96a2-4509-a7c8-ffc759486d89"), false, "C", 3, "Maddenin Halleri - Soru 5 için Seçenek C", new Guid("f721fd66-2cd9-4531-bb43-4794e743d80f") },
                    { new Guid("98ec188e-b2e4-4986-816a-2e4373c65d5d"), false, "A", 1, "Madde ve Özellikleri - Soru 5 için Seçenek A", new Guid("1e1f5424-2284-453f-9c37-963233005ac2") },
                    { new Guid("9924350d-39e8-44a3-a75d-35e00cfcdec0"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek C", new Guid("9904cc1c-583d-46ca-a149-bfc0c23ac171") },
                    { new Guid("9a6594eb-776f-4395-8748-9b171953d8f0"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 1 için Seçenek C", new Guid("2df9815e-35de-426e-b606-1a85eec77cdc") },
                    { new Guid("9bbc8216-aa1e-4cd2-af65-c1d7efba679d"), true, "D", 4, "Maddenin Halleri - Soru 1 için Seçenek D", new Guid("7ed511b7-d394-4b9d-b5da-dcdcbcd4874c") },
                    { new Guid("9bca7a2d-26fd-48af-82d7-e09948648e8e"), true, "B", 2, "Rasyonel Sayılar - Soru 4 için Seçenek B", new Guid("af9bdb27-2430-4199-b441-3b4026095e43") },
                    { new Guid("9bd4676b-c2ac-4d7e-863e-8f15a7193a37"), false, "B", 2, "Temel Kavramlar - Soru 2 için Seçenek B", new Guid("2e12e4bc-335e-41fe-be0a-d47ca983d560") },
                    { new Guid("9c9e8114-fd3f-4717-9bd1-e322933095ce"), false, "C", 3, "Fizik Bilimine Giriş - Soru 2 için Seçenek C", new Guid("5199d68a-3aec-4d88-80ae-dd7a45d40fd0") },
                    { new Guid("9dfd65a2-3e73-465f-925f-858eff6e859a"), false, "D", 4, "Madde ve Özellikleri - Soru 5 için Seçenek D", new Guid("1e1f5424-2284-453f-9c37-963233005ac2") },
                    { new Guid("9f6f34c7-b5f7-4427-ab5f-f5f105caadec"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek C", new Guid("b8468c14-7588-48ab-9569-86b7d8a8ca0d") },
                    { new Guid("a04fe217-17df-4395-ac68-7f3022309c7a"), true, "A", 1, "Sayı Basamakları - Soru 5 için Seçenek A", new Guid("540e9ff6-0357-4c10-99c6-2d73726698eb") },
                    { new Guid("a17f2eaf-eaf3-49d0-b6a2-229a065567d7"), false, "C", 3, "Hücre Bölünmeleri - Soru 4 için Seçenek C", new Guid("3538996d-ec48-4bd9-89eb-1eaa86b55634") },
                    { new Guid("a31727d4-4975-4731-abb7-0708e98651d6"), false, "D", 4, "İş, Güç ve Enerji - Soru 2 için Seçenek D", new Guid("05e32d82-8545-4692-a9cd-adb7b7a2063b") },
                    { new Guid("a559aa9b-19ac-4cc4-a0bd-ebe103a1971e"), false, "B", 2, "Maddenin Halleri - Soru 1 için Seçenek B", new Guid("7ed511b7-d394-4b9d-b5da-dcdcbcd4874c") },
                    { new Guid("a5772082-6f5d-4b4e-acf0-6d0c41dee43d"), false, "B", 2, "Bölme ve Bölünebilme - Soru 5 için Seçenek B", new Guid("9ba36baa-0b55-498f-afa7-566d104317cd") },
                    { new Guid("a6645992-ad2e-4eeb-b91b-d94656a4ec6f"), false, "D", 4, "Kimya Bilimi - Soru 4 için Seçenek D", new Guid("90560d53-059e-406f-8f8a-9da46f2abc1c") },
                    { new Guid("a73628ca-0cb2-46c7-b9de-5bf5c300a1c6"), false, "A", 1, "Kimya Bilimi - Soru 5 için Seçenek A", new Guid("57dbf6ef-3626-4bea-8179-b197e52d5113") },
                    { new Guid("a7993677-f5c7-444d-9405-d25b2e9d8f7a"), true, "C", 3, "Kuvvet ve Hareket - Soru 4 için Seçenek C", new Guid("1c04632a-f394-45aa-aa42-fdb468b36b54") },
                    { new Guid("a90ff965-e36a-44b7-aa41-199baa2fbb8a"), true, "B", 2, "Hücre - Soru 4 için Seçenek B", new Guid("66d184dc-b34e-470c-a630-e61ff6602da5") },
                    { new Guid("a93f5117-de62-4be9-bd9f-ce2a622a2bc5"), false, "C", 3, "Fizik Bilimine Giriş - Soru 3 için Seçenek C", new Guid("0785a31a-66db-4bfb-a215-55cf6d9536ac") },
                    { new Guid("a97f8572-b9df-4dea-be6f-036beab0de6f"), true, "D", 4, "Madde ve Özellikleri - Soru 3 için Seçenek D", new Guid("1a468d3c-8f5a-4967-8eb3-e69ed21ce138") },
                    { new Guid("aa857c63-fef2-40ba-a4a5-54becc93ff1c"), false, "D", 4, "Madde ve Özellikleri - Soru 2 için Seçenek D", new Guid("43b3905f-c7a1-41dd-b6c7-887944c214f8") },
                    { new Guid("abb16e3a-1ee0-4d41-b69b-f473281f69aa"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek C", new Guid("ea10acd6-608b-4806-b79f-2d2ab55a4f76") },
                    { new Guid("ac438d9c-946f-4929-9248-517c6eacb79a"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek C", new Guid("0bbde36b-91ec-4ae1-b758-f5118102484a") },
                    { new Guid("ac6a07d6-6128-464c-92b2-a96824e1f7b0"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek B", new Guid("34b2990d-cdc6-4dd2-b469-ce81ed49fe23") },
                    { new Guid("accb411e-43bd-4441-b614-34022789aa60"), false, "C", 3, "Hücre - Soru 3 için Seçenek C", new Guid("815fcedc-c0c2-465f-963b-afe800ab5659") },
                    { new Guid("acd507a5-56e9-4284-9b6a-2adb5d23afc9"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek D", new Guid("4d17b5ae-1399-42a4-8d8d-32451680ba1f") },
                    { new Guid("aec1cb91-8d5e-4cd0-bfa3-5e5c008c2fdd"), false, "A", 1, "Temel Kavramlar - Soru 3 için Seçenek A", new Guid("0d1aa2c6-af98-4384-86d4-630f67bee88b") },
                    { new Guid("af48ed17-cc4c-4789-9a85-c7292c2bda23"), false, "C", 3, "Temel Kavramlar - Soru 3 için Seçenek C", new Guid("0d1aa2c6-af98-4384-86d4-630f67bee88b") },
                    { new Guid("b0a6d9a6-c3bb-4fd7-b2c5-00927f88c5f6"), false, "D", 4, "İş, Güç ve Enerji - Soru 4 için Seçenek D", new Guid("8ae253de-b346-4784-a87c-6603cf699ac2") },
                    { new Guid("b0ed5b84-b499-42fd-bf68-5793e7560d29"), false, "D", 4, "Elektrostatik - Soru 3 için Seçenek D", new Guid("620149c2-3cb6-4616-8aa7-25671167e77a") },
                    { new Guid("b146e0a8-3834-41d7-929b-f85d3f9a5627"), true, "A", 1, "Hücre Bölünmeleri - Soru 5 için Seçenek A", new Guid("2b4ac114-f67d-440f-9892-8581eabb3bab") },
                    { new Guid("b21b442c-b891-4be5-9d27-3b6f88044d4d"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 2 için Seçenek C", new Guid("267e405f-f997-47c6-8e8a-5ca5a995bf82") },
                    { new Guid("b2525d28-fd6a-48f3-ae3b-320bcdde60b2"), false, "B", 2, "Sayı Basamakları - Soru 3 için Seçenek B", new Guid("c1883ebc-94f3-4b09-b5e6-913470ac24f2") },
                    { new Guid("b297f7ac-7cf3-452a-ad6e-3438385f492c"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 3 için Seçenek C", new Guid("c745d452-2f55-4c88-b054-f003b104e723") },
                    { new Guid("b347a3af-1a85-476c-b580-d8156820f44a"), false, "C", 3, "Bölme ve Bölünebilme - Soru 5 için Seçenek C", new Guid("9ba36baa-0b55-498f-afa7-566d104317cd") },
                    { new Guid("b4964387-1180-4157-a36f-387426ece692"), false, "C", 3, "İş, Güç ve Enerji - Soru 1 için Seçenek C", new Guid("0c61c300-af71-4502-8dca-a38735279402") },
                    { new Guid("b58b7dbe-7458-4249-82ba-622c4c827706"), true, "D", 4, "Maddenin Halleri - Soru 4 için Seçenek D", new Guid("3d62281a-b911-444d-891b-984de319fe68") },
                    { new Guid("b5eef80a-7f2c-4e93-b47e-bb2a7f7ee92c"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 4 için Seçenek B", new Guid("152a3643-eac5-4d14-a7bf-c1b46b376270") },
                    { new Guid("b62c5841-73f3-4e69-9d65-d47c35c5c84a"), true, "A", 1, "Canlıların Sınıflandırılması - Soru 4 için Seçenek A", new Guid("152a3643-eac5-4d14-a7bf-c1b46b376270") },
                    { new Guid("b6c339e8-24cb-499a-a104-64332fbbe287"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek A", new Guid("ca4b97ac-6382-40f1-8df5-7ba899d4372f") },
                    { new Guid("b75f5103-3ac4-4567-9e03-43629ff3b469"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 5 için Seçenek C", new Guid("21e95a17-b30a-455c-afe0-cc4e1301420a") },
                    { new Guid("b79d6186-e87d-4a94-83eb-6cb9fde39447"), false, "C", 3, "Madde ve Özellikleri - Soru 3 için Seçenek C", new Guid("1a468d3c-8f5a-4967-8eb3-e69ed21ce138") },
                    { new Guid("b8a17f48-a751-48b6-97f9-fae228cefff1"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 1 için Seçenek B", new Guid("ad85a2df-ab4b-479a-8130-7d821136a8ee") },
                    { new Guid("b90cbcc1-be6b-4e87-ab76-9ab7eb8c0f28"), false, "D", 4, "Fizik Bilimine Giriş - Soru 3 için Seçenek D", new Guid("0785a31a-66db-4bfb-a215-55cf6d9536ac") },
                    { new Guid("b9350012-ec03-4345-9ba3-c370d6937fc6"), false, "C", 3, "Madde ve Özellikleri - Soru 4 için Seçenek C", new Guid("007903b8-17e9-49e4-b732-1ed680d84cb2") },
                    { new Guid("ba478db0-4d15-429a-a99e-49a275509bb4"), false, "C", 3, "Problemler - Soru 5 için Seçenek C", new Guid("dd295827-7146-44ba-a342-5094d90dfe59") },
                    { new Guid("ba88336b-f430-479f-94af-035213018b59"), false, "B", 2, "Elektrostatik - Soru 1 için Seçenek B", new Guid("be4d6081-8f2a-4b83-bd52-d312dd406fa7") },
                    { new Guid("bac66809-7a03-419d-a32b-d27d41f22a8c"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek D", new Guid("c30b0f82-ecda-4066-80b2-3bf48ee36f05") },
                    { new Guid("bafbc7b5-060a-4814-8de0-7e8c894b36a2"), false, "D", 4, "Problemler - Soru 1 için Seçenek D", new Guid("53557f50-3e0f-4dff-9813-92d4a2a3dfe0") },
                    { new Guid("bb1dd282-bf37-4aae-bd07-0e1b95864cbb"), false, "C", 3, "Kalıtım - Soru 5 için Seçenek C", new Guid("d0b8ed35-7bf8-4ec1-8bb0-5be5965b17c7") },
                    { new Guid("bbd266b9-de73-4810-8ff4-38ff2e60aa5b"), false, "D", 4, "Kalıtım - Soru 2 için Seçenek D", new Guid("b2282a5d-c02d-4943-9a03-3232803ee544") },
                    { new Guid("bc61b983-1c3c-4981-bad3-a4c87d8bdc0b"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek C", new Guid("146e1fb0-2242-43b0-a29f-9231913a84d5") },
                    { new Guid("bcd82737-52d1-45b7-b23e-cb638ec5c041"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 1 için Seçenek D", new Guid("2df9815e-35de-426e-b606-1a85eec77cdc") },
                    { new Guid("bddd2dbc-420c-43be-8569-c39ec3f0d903"), false, "C", 3, "Kuvvet ve Hareket - Soru 3 için Seçenek C", new Guid("406d0dfb-972b-4cf8-90cd-f4957f91c739") },
                    { new Guid("be093ff2-3c20-42ae-ba0e-d774eb5897cc"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek C", new Guid("c30b0f82-ecda-4066-80b2-3bf48ee36f05") },
                    { new Guid("bf000a3d-8bd1-4b0d-a4f6-a654d078062b"), true, "B", 2, "Maddenin Halleri - Soru 2 için Seçenek B", new Guid("1f6ae920-0c90-4589-8c44-4934bcc58028") },
                    { new Guid("c070dfc1-80c5-4173-ac25-23f579ec1857"), false, "C", 3, "Problemler - Soru 4 için Seçenek C", new Guid("fa6f2db7-a9f1-408a-abfb-8af8dc2a1faa") },
                    { new Guid("c08acef7-8e1f-473f-aa3c-cb93f73cd7ec"), false, "B", 2, "Fizik Bilimine Giriş - Soru 3 için Seçenek B", new Guid("0785a31a-66db-4bfb-a215-55cf6d9536ac") },
                    { new Guid("c2454eaf-2add-4af7-b08d-4a9cd97d575c"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 2 için Seçenek D", new Guid("138b10e4-a139-426e-816e-ae353b9a4211") },
                    { new Guid("c3072d4e-61e1-45c8-b4bf-03331a93db53"), false, "A", 1, "Sayı Basamakları - Soru 4 için Seçenek A", new Guid("19d76a6f-5546-4d3e-82c6-ab74a7a47728") },
                    { new Guid("c3c066ea-145e-487c-a3e4-f9195bc07c9a"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek B", new Guid("29a31835-aa03-4eb8-9d12-8c4491c43221") },
                    { new Guid("c7a748ce-e32b-4dc7-85df-959ac4bde4ea"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 4 için Seçenek C", new Guid("1d46d737-bba7-4b6b-8c51-58578b86ef74") },
                    { new Guid("c9759c5f-c727-4ac7-8e85-831aada85151"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 3 için Seçenek B", new Guid("c745d452-2f55-4c88-b054-f003b104e723") },
                    { new Guid("ca6ad9cb-a43d-48ec-924d-0598a0b9585d"), false, "A", 1, "Rasyonel Sayılar - Soru 5 için Seçenek A", new Guid("ed5a5f5f-1cfa-41be-92e6-3ca41a64ce75") },
                    { new Guid("cacd683c-6a8f-4242-9fb1-c20db784bb44"), false, "C", 3, "Hücre Bölünmeleri - Soru 3 için Seçenek C", new Guid("ce93e37c-5cdb-40ee-8d42-7bda3a6e62b5") },
                    { new Guid("cbf3b2e8-8221-4678-b2a4-e3366bc99a04"), false, "A", 1, "Kuvvet ve Hareket - Soru 4 için Seçenek A", new Guid("1c04632a-f394-45aa-aa42-fdb468b36b54") },
                    { new Guid("cc05c576-582e-43df-9d4a-9efc886e9299"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek A", new Guid("34b2990d-cdc6-4dd2-b469-ce81ed49fe23") },
                    { new Guid("cca20dcc-2cff-4296-9198-00b1ac3d6fd3"), false, "D", 4, "Sayı Basamakları - Soru 4 için Seçenek D", new Guid("19d76a6f-5546-4d3e-82c6-ab74a7a47728") },
                    { new Guid("ccc58b29-13c9-40ee-90df-faf9cfb67d6e"), true, "B", 2, "Hücre Bölünmeleri - Soru 3 için Seçenek B", new Guid("ce93e37c-5cdb-40ee-8d42-7bda3a6e62b5") },
                    { new Guid("ce657aaf-17e7-49d1-8a64-9de31b11c196"), false, "B", 2, "Bölme ve Bölünebilme - Soru 2 için Seçenek B", new Guid("a3589401-d917-4bb5-9f98-3c210fc58ec7") },
                    { new Guid("ceff5e80-ec55-4ff6-8d58-7c9c32781f5c"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 5 için Seçenek C", new Guid("139d648e-a97b-4091-bb09-21bd01bf4d68") },
                    { new Guid("cf732552-a57c-45e9-8880-3380445bb635"), true, "C", 3, "Kimya Bilimi - Soru 5 için Seçenek C", new Guid("57dbf6ef-3626-4bea-8179-b197e52d5113") },
                    { new Guid("cff0d5be-0933-459a-b7bf-71ade83b0854"), false, "C", 3, "Madde ve Özellikleri - Soru 5 için Seçenek C", new Guid("1e1f5424-2284-453f-9c37-963233005ac2") },
                    { new Guid("d04b942c-0cf6-46df-9ede-3f458bd97f8f"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek B", new Guid("383bcd24-7c1a-4723-8b5b-5f7fa11bb8d9") },
                    { new Guid("d0b8bfbd-057c-489c-b4f1-4544ffdeb48f"), true, "B", 2, "Fizik Bilimine Giriş - Soru 2 için Seçenek B", new Guid("5199d68a-3aec-4d88-80ae-dd7a45d40fd0") },
                    { new Guid("d0c17b38-366f-43cd-a8d3-547e83dfecaf"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 5 için Seçenek D", new Guid("21e95a17-b30a-455c-afe0-cc4e1301420a") },
                    { new Guid("d1a1263d-57f1-4552-b63d-8a5f5679e065"), false, "D", 4, "Problemler - Soru 3 için Seçenek D", new Guid("a989a459-c781-436f-a812-6773b6dbaed7") },
                    { new Guid("d23e75a3-4e9a-43c6-8e09-2c9bec7d2817"), false, "D", 4, "Fizik Bilimine Giriş - Soru 5 için Seçenek D", new Guid("f149242c-1aba-4edb-9148-9d451a2dc9a5") },
                    { new Guid("d24ed310-ff27-4ac3-bf51-f2ed53f577b6"), false, "C", 3, "İş, Güç ve Enerji - Soru 2 için Seçenek C", new Guid("05e32d82-8545-4692-a9cd-adb7b7a2063b") },
                    { new Guid("d2aa43fb-4ae0-4532-a20a-855343468db2"), false, "B", 2, "Elektrostatik - Soru 4 için Seçenek B", new Guid("043d6340-d790-47dd-a266-b378691dcd3d") },
                    { new Guid("d4f95c5b-bc35-4461-bf1a-b59a6bfb380d"), false, "A", 1, "İş, Güç ve Enerji - Soru 3 için Seçenek A", new Guid("18d91c97-d883-4711-b99f-11989ff19248") },
                    { new Guid("d51db068-a3b4-49ec-abee-dc3c6c6631a3"), false, "A", 1, "Temel Kavramlar - Soru 1 için Seçenek A", new Guid("3f05a1f7-39fa-4bd8-82ec-5db7cd7b2e87") },
                    { new Guid("d6047648-cb86-4c4a-8982-18c3ad3e2b97"), true, "A", 1, "Elektrostatik - Soru 5 için Seçenek A", new Guid("78ffad7b-5b72-4703-a192-ea1f5e53286e") },
                    { new Guid("d6171ab3-a088-4aab-b346-0153e888ad9f"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek B", new Guid("412f6db2-18c0-49e1-9db2-5d9383cf4f08") },
                    { new Guid("d6ec8d43-bb5e-4c23-b6d6-b6d53b37cf90"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek B", new Guid("c30b0f82-ecda-4066-80b2-3bf48ee36f05") },
                    { new Guid("d77cae27-a633-43c4-b827-dca480ba778c"), false, "C", 3, "Sayı Basamakları - Soru 2 için Seçenek C", new Guid("82bdb667-44a1-4b80-b10b-f4fb7facf3c1") },
                    { new Guid("d787cf1f-06bc-43d2-86f6-87c3e617cc9f"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek A", new Guid("400bdfdf-789e-4ed3-bc7d-d743f4b84b66") },
                    { new Guid("da12fd65-b035-4df3-8040-ea108d58a04c"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek A", new Guid("9904cc1c-583d-46ca-a149-bfc0c23ac171") },
                    { new Guid("da1b8264-a950-4214-858b-caf63593e057"), false, "D", 4, "Temel Kavramlar - Soru 1 için Seçenek D", new Guid("3f05a1f7-39fa-4bd8-82ec-5db7cd7b2e87") },
                    { new Guid("dac7d844-c064-4cda-9c12-d4729ec77e9a"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 2 için Seçenek A", new Guid("267e405f-f997-47c6-8e8a-5ca5a995bf82") },
                    { new Guid("dbef3675-dd85-42e9-9c02-765b20ec6aa8"), false, "D", 4, "Fizik Bilimine Giriş - Soru 2 için Seçenek D", new Guid("5199d68a-3aec-4d88-80ae-dd7a45d40fd0") },
                    { new Guid("dc1b77e1-66c6-4323-af18-280b79497969"), false, "D", 4, "Bölme ve Bölünebilme - Soru 5 için Seçenek D", new Guid("9ba36baa-0b55-498f-afa7-566d104317cd") },
                    { new Guid("de6046d9-b536-458b-a409-934df47a31ef"), true, "A", 1, "İş, Güç ve Enerji - Soru 1 için Seçenek A", new Guid("0c61c300-af71-4502-8dca-a38735279402") },
                    { new Guid("debaf3c1-c403-4ee7-9210-f4864d78e4b4"), false, "C", 3, "Rasyonel Sayılar - Soru 4 için Seçenek C", new Guid("af9bdb27-2430-4199-b441-3b4026095e43") },
                    { new Guid("ded5ce6c-482c-4a82-ba19-9caa2e89d73d"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 2 için Seçenek D", new Guid("267e405f-f997-47c6-8e8a-5ca5a995bf82") },
                    { new Guid("df5d88c4-3d57-4750-bd43-d96bebeb215d"), false, "B", 2, "Sayı Basamakları - Soru 1 için Seçenek B", new Guid("fbc475d5-a073-4981-997d-5f96c2723251") },
                    { new Guid("df8b05dc-2695-4e39-b6da-0ca2b42519de"), false, "B", 2, "Problemler - Soru 2 için Seçenek B", new Guid("7321bc85-d438-4b05-a823-81c1120da3da") },
                    { new Guid("df9b713f-331f-4fb0-bbbc-a4a9b92d9cc7"), false, "D", 4, "Hücre Bölünmeleri - Soru 2 için Seçenek D", new Guid("2176b97f-c705-4f95-9360-9bd35e1c0b14") },
                    { new Guid("dfddf99f-ef93-4ad0-9c20-3748b8bb5890"), false, "D", 4, "Kalıtım - Soru 5 için Seçenek D", new Guid("d0b8ed35-7bf8-4ec1-8bb0-5be5965b17c7") },
                    { new Guid("e00a26e5-3d07-4352-8c9b-e170670695d0"), false, "A", 1, "Maddenin Halleri - Soru 4 için Seçenek A", new Guid("3d62281a-b911-444d-891b-984de319fe68") },
                    { new Guid("e20626a5-f638-4e0a-b117-373dd23b68ee"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek D", new Guid("d6fdb98c-7910-49d0-a210-f380edea7791") },
                    { new Guid("e2ee978b-d583-45e2-9914-4825d9a8167a"), false, "D", 4, "Rasyonel Sayılar - Soru 3 için Seçenek D", new Guid("f6f2e5ba-950f-4a48-ab01-e96f225c1272") },
                    { new Guid("e355b953-db31-498d-9f13-59637ee6c9e5"), false, "D", 4, "Hücre - Soru 5 için Seçenek D", new Guid("c0212217-b2f6-4619-9892-1bb6ae63c8aa") },
                    { new Guid("e40703f5-d96e-4b1a-8bf4-c4b2333e155d"), false, "D", 4, "Kuvvet ve Hareket - Soru 4 için Seçenek D", new Guid("1c04632a-f394-45aa-aa42-fdb468b36b54") },
                    { new Guid("e5067965-c28b-4be8-96a2-ea4b71011093"), false, "C", 3, "Bölme ve Bölünebilme - Soru 4 için Seçenek C", new Guid("563f05a2-5a15-4bbb-9b5c-353dc45f70c3") },
                    { new Guid("e58aeea5-6918-4158-9679-e99d61ffab34"), true, "D", 4, "Temel Kavramlar - Soru 3 için Seçenek D", new Guid("0d1aa2c6-af98-4384-86d4-630f67bee88b") },
                    { new Guid("e69e703d-9eaf-4e0b-ac8d-68027c77aaa1"), false, "C", 3, "Fizik Bilimine Giriş - Soru 1 için Seçenek C", new Guid("14f6577b-0d37-4a5c-9250-bf1de916dda2") },
                    { new Guid("e746effe-f389-4f10-acf4-c66db896b836"), false, "A", 1, "Kuvvet ve Hareket - Soru 5 için Seçenek A", new Guid("efb2d9d3-a3a9-404e-b378-e58f29a73007") },
                    { new Guid("e7b32254-a3f3-4a50-8cdd-3a96d024564a"), false, "B", 2, "Madde ve Özellikleri - Soru 4 için Seçenek B", new Guid("007903b8-17e9-49e4-b732-1ed680d84cb2") },
                    { new Guid("e7bf293a-d495-4f9f-b0f8-86a740732b59"), false, "B", 2, "Temel Kavramlar - Soru 4 için Seçenek B", new Guid("6193f954-1651-4047-8ee4-f98504850b71") },
                    { new Guid("e7f239b7-d3b3-46b0-8ceb-b42f24529edb"), true, "A", 1, "Hücre Bölünmeleri - Soru 2 için Seçenek A", new Guid("2176b97f-c705-4f95-9360-9bd35e1c0b14") },
                    { new Guid("e7ff01c4-8cc8-430d-b749-7588cbc6f161"), false, "C", 3, "Elektrostatik - Soru 5 için Seçenek C", new Guid("78ffad7b-5b72-4703-a192-ea1f5e53286e") },
                    { new Guid("e89ef504-f996-4896-b85d-de8b042769b5"), false, "A", 1, "Rasyonel Sayılar - Soru 4 için Seçenek A", new Guid("af9bdb27-2430-4199-b441-3b4026095e43") },
                    { new Guid("ea219775-b236-4e21-a073-ab90fe24b8a4"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 3 için Seçenek B", new Guid("d49b0490-9425-4075-94d5-d4428abbb0ba") },
                    { new Guid("ea5768b2-17af-419c-a6b9-15c3285b5b81"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 4 için Seçenek C", new Guid("152a3643-eac5-4d14-a7bf-c1b46b376270") },
                    { new Guid("ea73d211-e9a1-4891-bd23-cdb74256e6fc"), true, "D", 4, "Kuvvet ve Hareket - Soru 1 için Seçenek D", new Guid("69ded171-0d51-4273-be01-3165bcb19c5f") },
                    { new Guid("eb673209-c5dd-4a0e-a061-587d196fd742"), false, "D", 4, "Kalıtım - Soru 4 için Seçenek D", new Guid("d534a582-6b26-4287-9937-ff4f608352a7") },
                    { new Guid("ec171491-d1b3-4dd5-a08b-007d34102262"), false, "B", 2, "Kimya Bilimi - Soru 4 için Seçenek B", new Guid("90560d53-059e-406f-8f8a-9da46f2abc1c") },
                    { new Guid("ecef9b70-024c-447b-8307-9ab3eb1279be"), false, "D", 4, "Bölme ve Bölünebilme - Soru 2 için Seçenek D", new Guid("a3589401-d917-4bb5-9f98-3c210fc58ec7") },
                    { new Guid("ed2bd7c8-5c7b-413a-9c96-e03c85d70b72"), true, "C", 3, "Problemler - Soru 3 için Seçenek C", new Guid("a989a459-c781-436f-a812-6773b6dbaed7") },
                    { new Guid("ee34c626-dce3-46b7-85d1-76940dbaf0fb"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 5 için Seçenek D", new Guid("139d648e-a97b-4091-bb09-21bd01bf4d68") },
                    { new Guid("eeac2b5d-2d02-472a-a312-357dc689755c"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek A", new Guid("c30b0f82-ecda-4066-80b2-3bf48ee36f05") },
                    { new Guid("ef4c4553-57e7-4d08-81d9-b6bae95e5700"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 1 için Seçenek B", new Guid("2df9815e-35de-426e-b606-1a85eec77cdc") },
                    { new Guid("efae32ee-6787-4776-a02f-bfcd0c581fe9"), false, "B", 2, "Maddenin Halleri - Soru 5 için Seçenek B", new Guid("f721fd66-2cd9-4531-bb43-4794e743d80f") },
                    { new Guid("f079941d-2927-4704-aab6-7af950c3a6c7"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek C", new Guid("db6e78ba-f5b3-4754-8396-6a62e566b26a") },
                    { new Guid("f09aedfd-5629-4284-8310-412a79e5ab2f"), false, "D", 4, "Maddenin Halleri - Soru 2 için Seçenek D", new Guid("1f6ae920-0c90-4589-8c44-4934bcc58028") },
                    { new Guid("f1ae2da1-cab7-4731-9daf-6283fc84bcb0"), false, "C", 3, "Problemler - Soru 1 için Seçenek C", new Guid("53557f50-3e0f-4dff-9813-92d4a2a3dfe0") },
                    { new Guid("f1dacebd-1bd8-4936-9aec-2b7d5e9d56d2"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 3 için Seçenek A", new Guid("c745d452-2f55-4c88-b054-f003b104e723") },
                    { new Guid("f1e603cb-ea5b-4c48-8143-bcca689660c8"), false, "D", 4, "Madde ve Özellikleri - Soru 4 için Seçenek D", new Guid("007903b8-17e9-49e4-b732-1ed680d84cb2") },
                    { new Guid("f1f66fee-c074-4d02-9ad7-3ae60282b6c8"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 1 için Seçenek A", new Guid("ad85a2df-ab4b-479a-8130-7d821136a8ee") },
                    { new Guid("f2218738-353b-48d3-b391-96d4ed843020"), false, "A", 1, "Hücre - Soru 1 için Seçenek A", new Guid("95f558eb-361b-410b-b128-33187a312dcc") },
                    { new Guid("f28ba9c0-defd-41ee-a186-111bd08a66ef"), false, "B", 2, "Problemler - Soru 1 için Seçenek B", new Guid("53557f50-3e0f-4dff-9813-92d4a2a3dfe0") },
                    { new Guid("f3b8d632-bb31-46d7-8c38-fb5f79306408"), false, "B", 2, "Fizik Bilimine Giriş - Soru 5 için Seçenek B", new Guid("f149242c-1aba-4edb-9148-9d451a2dc9a5") },
                    { new Guid("f3fcf8aa-7566-4176-aca7-f0b8f5fdbc7a"), false, "D", 4, "Kalıtım - Soru 3 için Seçenek D", new Guid("88060534-8b7e-40b9-8f68-1a8152283d13") },
                    { new Guid("f41a9b7f-69fd-45c8-b3dd-e47373dcfaf7"), true, "D", 4, "Elektrostatik - Soru 4 için Seçenek D", new Guid("043d6340-d790-47dd-a266-b378691dcd3d") },
                    { new Guid("f4362844-0732-467f-9f05-595478ace3ab"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 2 için Seçenek B", new Guid("138b10e4-a139-426e-816e-ae353b9a4211") },
                    { new Guid("f4e0bf39-e6b1-4889-a86b-20afedf12602"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek C", new Guid("ca4b97ac-6382-40f1-8df5-7ba899d4372f") },
                    { new Guid("f5d6c474-1fe7-4a50-80f0-667f2c18a91d"), false, "D", 4, "Sayı Basamakları - Soru 1 için Seçenek D", new Guid("fbc475d5-a073-4981-997d-5f96c2723251") },
                    { new Guid("f619f6f0-4348-48e9-9e74-9ca8f2a5e382"), true, "B", 2, "Problemler - Soru 5 için Seçenek B", new Guid("dd295827-7146-44ba-a342-5094d90dfe59") },
                    { new Guid("f78cade7-d1d3-4325-9192-eeb15c644191"), false, "C", 3, "Fizik Bilimine Giriş - Soru 4 için Seçenek C", new Guid("c61589b3-4f7d-436b-9a7b-f7ad4f25c046") },
                    { new Guid("f804f7cb-09b1-4e0f-b7ed-51e85b3ee565"), true, "A", 1, "Elektrostatik - Soru 2 için Seçenek A", new Guid("9145349a-77f3-4b5b-8712-7d1a0bc2d6b5") },
                    { new Guid("f8569591-2ea5-44b0-b3b4-6e90c3ea2cff"), true, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek A", new Guid("412f6db2-18c0-49e1-9db2-5d9383cf4f08") },
                    { new Guid("f8f83611-dd69-4210-91ca-17540893ea90"), false, "B", 2, "Hücre - Soru 1 için Seçenek B", new Guid("95f558eb-361b-410b-b128-33187a312dcc") },
                    { new Guid("f93dc48f-ccb2-4ebb-881f-3e865f0f5fed"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek D", new Guid("29a31835-aa03-4eb8-9d12-8c4491c43221") },
                    { new Guid("f9d615b1-358f-4137-95e3-39e9654ab995"), false, "D", 4, "Elektrostatik - Soru 2 için Seçenek D", new Guid("9145349a-77f3-4b5b-8712-7d1a0bc2d6b5") },
                    { new Guid("f9f26af3-774e-47c2-8974-f6e6edd32763"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek A", new Guid("0bbde36b-91ec-4ae1-b758-f5118102484a") },
                    { new Guid("fb6207ed-aca4-43da-bd6e-d34d3cfbfdbb"), false, "D", 4, "İş, Güç ve Enerji - Soru 5 için Seçenek D", new Guid("a79688f8-3e47-4c89-8760-5a6b3860f850") },
                    { new Guid("fc14b1d5-f63b-4827-b4b0-fbc27187d4a7"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek D", new Guid("34b2990d-cdc6-4dd2-b469-ce81ed49fe23") },
                    { new Guid("fc960946-b780-457e-81f5-75db859c6ab9"), true, "B", 2, "Madde ve Özellikleri - Soru 1 için Seçenek B", new Guid("27cfb64e-b730-46e9-b4c0-5c58194b6b7b") },
                    { new Guid("ff55a512-eac9-4763-b51b-f2eb4e3816e3"), true, "B", 2, "İş, Güç ve Enerji - Soru 2 için Seçenek B", new Guid("05e32d82-8545-4692-a9cd-adb7b7a2063b") }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "ParentTopicId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("0c648daa-f382-45f8-9e5e-968b04449b6b"), new Guid("4bfce486-d3db-4af0-b0e1-69b317fa3caf"), "Bölme ve Bölünebilme" },
                    { new Guid("0f558720-4b52-46ab-951e-c6a629766170"), new Guid("3ad0b735-1f66-4ee2-84fa-9882494ba074"), "Elektrostatik" },
                    { new Guid("2372d3de-6ff7-460c-9565-17f7d4bf1636"), new Guid("3ad0b735-1f66-4ee2-84fa-9882494ba074"), "Kuvvet ve Hareket" },
                    { new Guid("3131b0f5-a473-43f8-8782-dc6885e9541f"), new Guid("c678f063-7077-48c5-88e1-0e363b049b81"), "Canlıların Sınıflandırılması" },
                    { new Guid("39cb2c44-5836-4538-a5c6-3f35acd97ea1"), new Guid("8d44d040-57eb-4611-9564-08989c22b610"), "Asitler, Bazlar ve Tuzlar" },
                    { new Guid("446b120d-df8a-49ab-b8d0-cf1041e13694"), new Guid("4bfce486-d3db-4af0-b0e1-69b317fa3caf"), "Rasyonel Sayılar" },
                    { new Guid("76d1ea07-bfad-43e2-8929-fbd8aa33ff01"), new Guid("c678f063-7077-48c5-88e1-0e363b049b81"), "Yaşam Bilimi Biyoloji" },
                    { new Guid("7b5b63e8-5270-4988-986a-c89ec5a1e898"), new Guid("c678f063-7077-48c5-88e1-0e363b049b81"), "Kalıtım" },
                    { new Guid("7c731b91-9782-49a9-9b90-bb907a05f200"), new Guid("4bfce486-d3db-4af0-b0e1-69b317fa3caf"), "Sayı Basamakları" },
                    { new Guid("86423458-cdcf-49e0-abd4-620601a0846f"), new Guid("c678f063-7077-48c5-88e1-0e363b049b81"), "Hücre Bölünmeleri" },
                    { new Guid("a9c80470-49cf-4dd7-9c34-14a8e66e849f"), new Guid("4bfce486-d3db-4af0-b0e1-69b317fa3caf"), "Temel Kavramlar" },
                    { new Guid("adbfbcb2-800d-40b9-9fb9-882e09f3ae16"), new Guid("3ad0b735-1f66-4ee2-84fa-9882494ba074"), "Fizik Bilimine Giriş" },
                    { new Guid("b3f26cc7-b866-46dc-811b-942a9c081ad6"), new Guid("8d44d040-57eb-4611-9564-08989c22b610"), "Kimyasal Türler Arası Etkileşimler" },
                    { new Guid("b4d1422d-d98d-41dd-8f9d-73dd30ce22b3"), new Guid("c678f063-7077-48c5-88e1-0e363b049b81"), "Hücre" },
                    { new Guid("d4fb0837-456d-4ab1-b69e-fab25775bb87"), new Guid("3ad0b735-1f66-4ee2-84fa-9882494ba074"), "Madde ve Özellikleri" },
                    { new Guid("dab5aa24-7c1d-47fb-9121-6ab9f58d6785"), new Guid("4bfce486-d3db-4af0-b0e1-69b317fa3caf"), "Problemler" },
                    { new Guid("e2a5bf7c-fe55-4e48-89f4-59aafe6694f5"), new Guid("3ad0b735-1f66-4ee2-84fa-9882494ba074"), "İş, Güç ve Enerji" },
                    { new Guid("e9027198-60e6-48ab-b006-b55d821c8ddf"), new Guid("8d44d040-57eb-4611-9564-08989c22b610"), "Atom ve Periyodik Sistem" },
                    { new Guid("f4174eb6-e5de-4351-ad10-426450a91d97"), new Guid("8d44d040-57eb-4611-9564-08989c22b610"), "Kimya Bilimi" },
                    { new Guid("f82398ff-5327-4a49-917d-ebaa144c8f68"), new Guid("8d44d040-57eb-4611-9564-08989c22b610"), "Maddenin Halleri" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsTopics",
                columns: new[] { "QuestionId", "TopicId", "Id" },
                values: new object[,]
                {
                    { new Guid("007903b8-17e9-49e4-b732-1ed680d84cb2"), new Guid("d4fb0837-456d-4ab1-b69e-fab25775bb87"), new Guid("bfa5ac78-84d2-4d3a-88b1-bf4c5530e549") },
                    { new Guid("043d6340-d790-47dd-a266-b378691dcd3d"), new Guid("0f558720-4b52-46ab-951e-c6a629766170"), new Guid("79d593d8-8f02-4890-918a-d60ac991109b") },
                    { new Guid("05e32d82-8545-4692-a9cd-adb7b7a2063b"), new Guid("e2a5bf7c-fe55-4e48-89f4-59aafe6694f5"), new Guid("d5ffa253-c2af-48d2-b5dc-34ed3ac7801b") },
                    { new Guid("0785a31a-66db-4bfb-a215-55cf6d9536ac"), new Guid("adbfbcb2-800d-40b9-9fb9-882e09f3ae16"), new Guid("6f496114-9404-49c5-bc35-7fda0ca2f5ce") },
                    { new Guid("0bbde36b-91ec-4ae1-b758-f5118102484a"), new Guid("39cb2c44-5836-4538-a5c6-3f35acd97ea1"), new Guid("5b0f9467-bae9-42fc-a259-a0dd848c2ae8") },
                    { new Guid("0c61c300-af71-4502-8dca-a38735279402"), new Guid("e2a5bf7c-fe55-4e48-89f4-59aafe6694f5"), new Guid("f13a7611-c646-4ed4-a84f-ae01493f5eba") },
                    { new Guid("0d1aa2c6-af98-4384-86d4-630f67bee88b"), new Guid("a9c80470-49cf-4dd7-9c34-14a8e66e849f"), new Guid("cddc5093-9d33-40f8-b4ac-438a8e2b20d9") },
                    { new Guid("138b10e4-a139-426e-816e-ae353b9a4211"), new Guid("3131b0f5-a473-43f8-8782-dc6885e9541f"), new Guid("a73c4dac-4214-4ef8-9384-b128825db4e6") },
                    { new Guid("139d648e-a97b-4091-bb09-21bd01bf4d68"), new Guid("e9027198-60e6-48ab-b006-b55d821c8ddf"), new Guid("ec151c4e-14cb-4491-aa18-bea8997349eb") },
                    { new Guid("146e1fb0-2242-43b0-a29f-9231913a84d5"), new Guid("39cb2c44-5836-4538-a5c6-3f35acd97ea1"), new Guid("4742ed3a-85ca-47e6-8507-00ad73410ee1") },
                    { new Guid("14f6577b-0d37-4a5c-9250-bf1de916dda2"), new Guid("adbfbcb2-800d-40b9-9fb9-882e09f3ae16"), new Guid("f7ef3ca1-a248-4b69-908c-0cdb1db4c3b4") },
                    { new Guid("152a3643-eac5-4d14-a7bf-c1b46b376270"), new Guid("3131b0f5-a473-43f8-8782-dc6885e9541f"), new Guid("335f4647-cd2b-4676-8645-c9f1a6976b20") },
                    { new Guid("18d91c97-d883-4711-b99f-11989ff19248"), new Guid("e2a5bf7c-fe55-4e48-89f4-59aafe6694f5"), new Guid("432ce10d-7cb3-4953-97db-1f5607b00540") },
                    { new Guid("19d76a6f-5546-4d3e-82c6-ab74a7a47728"), new Guid("7c731b91-9782-49a9-9b90-bb907a05f200"), new Guid("36c339b1-2636-499c-b9d8-198b90753f5c") },
                    { new Guid("1a468d3c-8f5a-4967-8eb3-e69ed21ce138"), new Guid("d4fb0837-456d-4ab1-b69e-fab25775bb87"), new Guid("294cf6ac-4091-43cf-9949-c7e5c3497440") },
                    { new Guid("1c04632a-f394-45aa-aa42-fdb468b36b54"), new Guid("2372d3de-6ff7-460c-9565-17f7d4bf1636"), new Guid("9342f960-ec30-4390-85ff-00beabd015de") },
                    { new Guid("1d46d737-bba7-4b6b-8c51-58578b86ef74"), new Guid("e9027198-60e6-48ab-b006-b55d821c8ddf"), new Guid("884f19d5-ead9-486c-96b5-5814f299bf83") },
                    { new Guid("1e1f5424-2284-453f-9c37-963233005ac2"), new Guid("d4fb0837-456d-4ab1-b69e-fab25775bb87"), new Guid("d571c357-0b50-45a2-8a83-8328969fc1f0") },
                    { new Guid("1f6ae920-0c90-4589-8c44-4934bcc58028"), new Guid("f82398ff-5327-4a49-917d-ebaa144c8f68"), new Guid("4937b897-9376-47b7-8a92-183d2337ad0e") },
                    { new Guid("2176b97f-c705-4f95-9360-9bd35e1c0b14"), new Guid("86423458-cdcf-49e0-abd4-620601a0846f"), new Guid("f01346cb-37ab-4959-a4f1-9153c106a7e0") },
                    { new Guid("21e95a17-b30a-455c-afe0-cc4e1301420a"), new Guid("3131b0f5-a473-43f8-8782-dc6885e9541f"), new Guid("8b4265f1-4092-4aef-b1d5-902be0587d13") },
                    { new Guid("267e405f-f997-47c6-8e8a-5ca5a995bf82"), new Guid("e9027198-60e6-48ab-b006-b55d821c8ddf"), new Guid("5cd0a05d-a157-4c0a-ae51-2b8c66817457") },
                    { new Guid("26ea5c49-cb47-40ba-8dd0-3d81bc934546"), new Guid("f4174eb6-e5de-4351-ad10-426450a91d97"), new Guid("3797e7a1-29fc-4454-8b45-8a5cd9c34c8d") },
                    { new Guid("27cfb64e-b730-46e9-b4c0-5c58194b6b7b"), new Guid("d4fb0837-456d-4ab1-b69e-fab25775bb87"), new Guid("d70ed91b-7b9d-410f-a2b6-3c7ad7cc20a4") },
                    { new Guid("29a31835-aa03-4eb8-9d12-8c4491c43221"), new Guid("76d1ea07-bfad-43e2-8929-fbd8aa33ff01"), new Guid("01f70a42-8360-4155-b6c6-1a192f6a33be") },
                    { new Guid("2b4ac114-f67d-440f-9892-8581eabb3bab"), new Guid("86423458-cdcf-49e0-abd4-620601a0846f"), new Guid("5a288d79-940c-4b50-8d13-2999a5bd80d4") },
                    { new Guid("2df9815e-35de-426e-b606-1a85eec77cdc"), new Guid("e9027198-60e6-48ab-b006-b55d821c8ddf"), new Guid("fa2fd019-2388-48e7-a768-73d5b23ed409") },
                    { new Guid("2e12e4bc-335e-41fe-be0a-d47ca983d560"), new Guid("a9c80470-49cf-4dd7-9c34-14a8e66e849f"), new Guid("c6207d75-c805-485a-9f16-715faf989d61") },
                    { new Guid("34b2990d-cdc6-4dd2-b469-ce81ed49fe23"), new Guid("b3f26cc7-b866-46dc-811b-942a9c081ad6"), new Guid("2ee0a2a5-9dfc-490a-8e56-78311ac69238") },
                    { new Guid("3538996d-ec48-4bd9-89eb-1eaa86b55634"), new Guid("86423458-cdcf-49e0-abd4-620601a0846f"), new Guid("1959b7cb-d901-471d-ae23-7bc738ceff87") },
                    { new Guid("383bcd24-7c1a-4723-8b5b-5f7fa11bb8d9"), new Guid("76d1ea07-bfad-43e2-8929-fbd8aa33ff01"), new Guid("9aabb465-bf9e-4f37-b578-2894ab407c41") },
                    { new Guid("3d62281a-b911-444d-891b-984de319fe68"), new Guid("f82398ff-5327-4a49-917d-ebaa144c8f68"), new Guid("37f2283a-1e6e-44b3-8461-5114316934a9") },
                    { new Guid("3f05a1f7-39fa-4bd8-82ec-5db7cd7b2e87"), new Guid("a9c80470-49cf-4dd7-9c34-14a8e66e849f"), new Guid("71c70433-994e-4396-a5b6-dbea6747c94d") },
                    { new Guid("400bdfdf-789e-4ed3-bc7d-d743f4b84b66"), new Guid("b3f26cc7-b866-46dc-811b-942a9c081ad6"), new Guid("df4c1e74-5487-41a9-8246-1926a224e657") },
                    { new Guid("406d0dfb-972b-4cf8-90cd-f4957f91c739"), new Guid("2372d3de-6ff7-460c-9565-17f7d4bf1636"), new Guid("33bffc57-6c49-4fc9-8fab-1305a53a24f2") },
                    { new Guid("412f6db2-18c0-49e1-9db2-5d9383cf4f08"), new Guid("39cb2c44-5836-4538-a5c6-3f35acd97ea1"), new Guid("715145fa-5fbb-4526-83ab-265f46dd0bf4") },
                    { new Guid("43b3905f-c7a1-41dd-b6c7-887944c214f8"), new Guid("d4fb0837-456d-4ab1-b69e-fab25775bb87"), new Guid("9fa8d73e-ee67-49b3-8068-44b3c46f6e55") },
                    { new Guid("46b72d22-3af7-4b24-ac9a-44586519a14a"), new Guid("a9c80470-49cf-4dd7-9c34-14a8e66e849f"), new Guid("b75db95e-fe3b-43db-bd50-8484e186fcf3") },
                    { new Guid("471fa72e-a88a-4503-a932-068d224b9ba7"), new Guid("f4174eb6-e5de-4351-ad10-426450a91d97"), new Guid("66c3cec9-221e-4159-9ebe-d14589887cd5") },
                    { new Guid("4d17b5ae-1399-42a4-8d8d-32451680ba1f"), new Guid("39cb2c44-5836-4538-a5c6-3f35acd97ea1"), new Guid("e6cf2fd0-1280-4e2d-b6ba-73479f8ec567") },
                    { new Guid("5199d68a-3aec-4d88-80ae-dd7a45d40fd0"), new Guid("adbfbcb2-800d-40b9-9fb9-882e09f3ae16"), new Guid("637d69fb-031b-4c38-a1af-c4aed0714ae4") },
                    { new Guid("53557f50-3e0f-4dff-9813-92d4a2a3dfe0"), new Guid("dab5aa24-7c1d-47fb-9121-6ab9f58d6785"), new Guid("8188e869-0638-4df9-859f-712751e778d9") },
                    { new Guid("540e9ff6-0357-4c10-99c6-2d73726698eb"), new Guid("7c731b91-9782-49a9-9b90-bb907a05f200"), new Guid("071bd16a-3f0a-4a6e-9984-db0fe78b3ad4") },
                    { new Guid("563f05a2-5a15-4bbb-9b5c-353dc45f70c3"), new Guid("0c648daa-f382-45f8-9e5e-968b04449b6b"), new Guid("37cc24ba-c727-4cbc-a17e-4ea1cb69a6f1") },
                    { new Guid("57dbf6ef-3626-4bea-8179-b197e52d5113"), new Guid("f4174eb6-e5de-4351-ad10-426450a91d97"), new Guid("d6b9e52e-2fe9-4ac2-8eca-b0d5893010e5") },
                    { new Guid("5b0f6c26-296d-4d8a-b3ee-4b507e05c03b"), new Guid("b4d1422d-d98d-41dd-8f9d-73dd30ce22b3"), new Guid("c7ec448a-978b-4b0d-bec9-3348457ec06d") },
                    { new Guid("6193f954-1651-4047-8ee4-f98504850b71"), new Guid("a9c80470-49cf-4dd7-9c34-14a8e66e849f"), new Guid("caafa0d9-d342-498a-bcd1-270e1cb76cac") },
                    { new Guid("620149c2-3cb6-4616-8aa7-25671167e77a"), new Guid("0f558720-4b52-46ab-951e-c6a629766170"), new Guid("639bd696-123e-4c8f-a414-0df87c4cc5f7") },
                    { new Guid("66d184dc-b34e-470c-a630-e61ff6602da5"), new Guid("b4d1422d-d98d-41dd-8f9d-73dd30ce22b3"), new Guid("5cd55315-221e-43e3-9e5c-b5602b9b2d2c") },
                    { new Guid("69ded171-0d51-4273-be01-3165bcb19c5f"), new Guid("2372d3de-6ff7-460c-9565-17f7d4bf1636"), new Guid("36a4a0b6-9a42-40c6-bc5d-095203de5ef9") },
                    { new Guid("7321bc85-d438-4b05-a823-81c1120da3da"), new Guid("dab5aa24-7c1d-47fb-9121-6ab9f58d6785"), new Guid("3111215c-db89-43df-a8b9-dc366e925ee5") },
                    { new Guid("78ffad7b-5b72-4703-a192-ea1f5e53286e"), new Guid("0f558720-4b52-46ab-951e-c6a629766170"), new Guid("644d2599-4081-4514-9817-e38b1dd8179c") },
                    { new Guid("7ed511b7-d394-4b9d-b5da-dcdcbcd4874c"), new Guid("f82398ff-5327-4a49-917d-ebaa144c8f68"), new Guid("88048a9e-96a4-4e6f-9b25-f31c6978a041") },
                    { new Guid("7fb13328-c3ea-471c-81a5-477ca2e4e464"), new Guid("f82398ff-5327-4a49-917d-ebaa144c8f68"), new Guid("06408a04-aadc-4bed-ab53-1e89c8918599") },
                    { new Guid("815fcedc-c0c2-465f-963b-afe800ab5659"), new Guid("b4d1422d-d98d-41dd-8f9d-73dd30ce22b3"), new Guid("79c7990b-9e26-4852-be08-b883dc6bb3d7") },
                    { new Guid("82bdb667-44a1-4b80-b10b-f4fb7facf3c1"), new Guid("7c731b91-9782-49a9-9b90-bb907a05f200"), new Guid("295db5cf-0f2c-4999-95dd-fd14a25f7ad2") },
                    { new Guid("88060534-8b7e-40b9-8f68-1a8152283d13"), new Guid("7b5b63e8-5270-4988-986a-c89ec5a1e898"), new Guid("96484446-712d-416d-9291-51b8aa5c9d0b") },
                    { new Guid("8ae253de-b346-4784-a87c-6603cf699ac2"), new Guid("e2a5bf7c-fe55-4e48-89f4-59aafe6694f5"), new Guid("a130050f-a65a-4a74-ada3-852b0d7a5954") },
                    { new Guid("90560d53-059e-406f-8f8a-9da46f2abc1c"), new Guid("f4174eb6-e5de-4351-ad10-426450a91d97"), new Guid("f5d2c834-f40e-4839-ada6-81baf0ad13fa") },
                    { new Guid("9145349a-77f3-4b5b-8712-7d1a0bc2d6b5"), new Guid("0f558720-4b52-46ab-951e-c6a629766170"), new Guid("fe7d9b56-e328-4bbe-afc1-abd72f1c142c") },
                    { new Guid("95f558eb-361b-410b-b128-33187a312dcc"), new Guid("b4d1422d-d98d-41dd-8f9d-73dd30ce22b3"), new Guid("86bb11ea-38af-4d03-90f5-507c8eb721a3") },
                    { new Guid("9904cc1c-583d-46ca-a149-bfc0c23ac171"), new Guid("b3f26cc7-b866-46dc-811b-942a9c081ad6"), new Guid("33d7b5ed-3835-4ca4-9a07-1579e60f2a49") },
                    { new Guid("9ba36baa-0b55-498f-afa7-566d104317cd"), new Guid("0c648daa-f382-45f8-9e5e-968b04449b6b"), new Guid("110ba692-8d81-48ea-9d82-d51a671aeb97") },
                    { new Guid("a0c342b0-4995-4496-9875-2abf600e70ad"), new Guid("0c648daa-f382-45f8-9e5e-968b04449b6b"), new Guid("aadfbc7b-cf2d-4988-a0ad-c438c3529e4a") },
                    { new Guid("a3589401-d917-4bb5-9f98-3c210fc58ec7"), new Guid("0c648daa-f382-45f8-9e5e-968b04449b6b"), new Guid("09596559-44ff-4bcb-bdcc-3030ce756074") },
                    { new Guid("a79688f8-3e47-4c89-8760-5a6b3860f850"), new Guid("e2a5bf7c-fe55-4e48-89f4-59aafe6694f5"), new Guid("79dff30b-e165-494d-a910-fb0c468acffb") },
                    { new Guid("a989a459-c781-436f-a812-6773b6dbaed7"), new Guid("dab5aa24-7c1d-47fb-9121-6ab9f58d6785"), new Guid("db721b92-b946-4ff0-b448-40a29217485c") },
                    { new Guid("ad85a2df-ab4b-479a-8130-7d821136a8ee"), new Guid("3131b0f5-a473-43f8-8782-dc6885e9541f"), new Guid("9e595b67-6cb4-4f60-b997-b972e249bc63") },
                    { new Guid("af9bdb27-2430-4199-b441-3b4026095e43"), new Guid("446b120d-df8a-49ab-b8d0-cf1041e13694"), new Guid("0be61949-176f-4bfe-bac3-420e4e4a9af1") },
                    { new Guid("b2282a5d-c02d-4943-9a03-3232803ee544"), new Guid("7b5b63e8-5270-4988-986a-c89ec5a1e898"), new Guid("824ce1c4-a249-4c1d-9471-45869e11c336") },
                    { new Guid("b8468c14-7588-48ab-9569-86b7d8a8ca0d"), new Guid("b3f26cc7-b866-46dc-811b-942a9c081ad6"), new Guid("21eef5ea-7d1e-48e7-919c-cd51cfa8f1fe") },
                    { new Guid("be4d6081-8f2a-4b83-bd52-d312dd406fa7"), new Guid("0f558720-4b52-46ab-951e-c6a629766170"), new Guid("2d5188a6-cb98-4c18-b492-b614ac969096") },
                    { new Guid("c0212217-b2f6-4619-9892-1bb6ae63c8aa"), new Guid("b4d1422d-d98d-41dd-8f9d-73dd30ce22b3"), new Guid("f12977eb-93b7-4483-9666-1ab82d22bce4") },
                    { new Guid("c1883ebc-94f3-4b09-b5e6-913470ac24f2"), new Guid("7c731b91-9782-49a9-9b90-bb907a05f200"), new Guid("e599a66a-e0ea-422e-bfb4-98bec4436e1b") },
                    { new Guid("c2c7b026-71af-45c0-95b2-fa443024fb52"), new Guid("2372d3de-6ff7-460c-9565-17f7d4bf1636"), new Guid("d56160eb-f7d2-43b4-bd95-909f887f5127") },
                    { new Guid("c30b0f82-ecda-4066-80b2-3bf48ee36f05"), new Guid("39cb2c44-5836-4538-a5c6-3f35acd97ea1"), new Guid("352e35f3-3404-4c9e-8b86-4472a137c2c8") },
                    { new Guid("c61589b3-4f7d-436b-9a7b-f7ad4f25c046"), new Guid("adbfbcb2-800d-40b9-9fb9-882e09f3ae16"), new Guid("4cbac2c2-a1d4-43a4-95db-20e895b5c3a9") },
                    { new Guid("c745d452-2f55-4c88-b054-f003b104e723"), new Guid("e9027198-60e6-48ab-b006-b55d821c8ddf"), new Guid("92a2ee8d-2ce0-40ac-b525-e82eae47f880") },
                    { new Guid("ca4b97ac-6382-40f1-8df5-7ba899d4372f"), new Guid("76d1ea07-bfad-43e2-8929-fbd8aa33ff01"), new Guid("90129449-0d5d-4284-a58f-e0ca942b89fa") },
                    { new Guid("cd0cb688-6910-49e7-b97f-1b9768ceda02"), new Guid("7b5b63e8-5270-4988-986a-c89ec5a1e898"), new Guid("4444cec6-a841-44ca-917d-4433e087cc5d") },
                    { new Guid("ce93e37c-5cdb-40ee-8d42-7bda3a6e62b5"), new Guid("86423458-cdcf-49e0-abd4-620601a0846f"), new Guid("011486fc-5d74-4543-a40c-1a8f0a8ac57e") },
                    { new Guid("d0b8ed35-7bf8-4ec1-8bb0-5be5965b17c7"), new Guid("7b5b63e8-5270-4988-986a-c89ec5a1e898"), new Guid("57f9d79c-d958-43a6-bbeb-c53eabc63eff") },
                    { new Guid("d27798bb-be62-42cd-8a2f-b08dfa214c38"), new Guid("86423458-cdcf-49e0-abd4-620601a0846f"), new Guid("1b373e7f-cde5-4c45-97ec-0144f8ee7042") },
                    { new Guid("d49b0490-9425-4075-94d5-d4428abbb0ba"), new Guid("3131b0f5-a473-43f8-8782-dc6885e9541f"), new Guid("173bf3bb-ef16-4a06-aa5d-0c67b7ddc6d8") },
                    { new Guid("d534a582-6b26-4287-9937-ff4f608352a7"), new Guid("7b5b63e8-5270-4988-986a-c89ec5a1e898"), new Guid("2ad8a5a0-9b01-4d31-b32d-c33f48071c3a") },
                    { new Guid("d54a745f-2025-4166-b22e-57ce8b62119b"), new Guid("446b120d-df8a-49ab-b8d0-cf1041e13694"), new Guid("d3ec3268-8878-41c6-a4b0-27d4943b81d2") },
                    { new Guid("d6fdb98c-7910-49d0-a210-f380edea7791"), new Guid("76d1ea07-bfad-43e2-8929-fbd8aa33ff01"), new Guid("30803cc9-6dad-4cc4-adba-46cb58466fa3") },
                    { new Guid("db6e78ba-f5b3-4754-8396-6a62e566b26a"), new Guid("b3f26cc7-b866-46dc-811b-942a9c081ad6"), new Guid("e4d15160-194e-49ab-beb0-313362beeb14") },
                    { new Guid("dd295827-7146-44ba-a342-5094d90dfe59"), new Guid("dab5aa24-7c1d-47fb-9121-6ab9f58d6785"), new Guid("2e57aca1-58ec-46ca-8faf-43e18db19dc8") },
                    { new Guid("de6628ac-bc56-465e-bad0-06c5d502a2c7"), new Guid("446b120d-df8a-49ab-b8d0-cf1041e13694"), new Guid("6ea10670-94b9-40d6-b51d-f85f9764131c") },
                    { new Guid("e1b631fc-9076-421c-baa2-cc87a182c182"), new Guid("f4174eb6-e5de-4351-ad10-426450a91d97"), new Guid("1951dfb2-3c20-4107-a21d-4d9d73b02155") },
                    { new Guid("ea10acd6-608b-4806-b79f-2d2ab55a4f76"), new Guid("76d1ea07-bfad-43e2-8929-fbd8aa33ff01"), new Guid("f2b8ea04-b06c-46d9-8a71-807b834ac410") },
                    { new Guid("ed5a5f5f-1cfa-41be-92e6-3ca41a64ce75"), new Guid("446b120d-df8a-49ab-b8d0-cf1041e13694"), new Guid("75c63876-95be-4b30-a4db-a072913639a8") },
                    { new Guid("efb2d9d3-a3a9-404e-b378-e58f29a73007"), new Guid("2372d3de-6ff7-460c-9565-17f7d4bf1636"), new Guid("295f5537-1d64-4508-b9b7-bb071ca0f72f") },
                    { new Guid("f149242c-1aba-4edb-9148-9d451a2dc9a5"), new Guid("adbfbcb2-800d-40b9-9fb9-882e09f3ae16"), new Guid("2df91da3-1c34-45c2-851a-f919fbd982a8") },
                    { new Guid("f6f2e5ba-950f-4a48-ab01-e96f225c1272"), new Guid("446b120d-df8a-49ab-b8d0-cf1041e13694"), new Guid("c95dafc6-4db9-4651-ae8a-23d809522ecb") },
                    { new Guid("f721fd66-2cd9-4531-bb43-4794e743d80f"), new Guid("f82398ff-5327-4a49-917d-ebaa144c8f68"), new Guid("e3398a38-f5cc-47a6-927b-026141996e4b") },
                    { new Guid("f84d228d-be92-4632-90e1-3a513a5186f9"), new Guid("0c648daa-f382-45f8-9e5e-968b04449b6b"), new Guid("9e1cc7ea-4577-48bd-87c3-77de5435147d") },
                    { new Guid("fa6f2db7-a9f1-408a-abfb-8af8dc2a1faa"), new Guid("dab5aa24-7c1d-47fb-9121-6ab9f58d6785"), new Guid("88f8f2b9-e5ce-4fa3-a6c2-48cbe0b91b06") },
                    { new Guid("fbc475d5-a073-4981-997d-5f96c2723251"), new Guid("7c731b91-9782-49a9-9b90-bb907a05f200"), new Guid("b5308d0c-561b-4760-bd01-1831576d06ce") }
                });

            migrationBuilder.InsertData(
                table: "UserPerformanceSummaries",
                columns: new[] { "Id", "CorrectAnswers", "CreatedAt", "LastUpdatedAt", "SuccessRate", "TopicId", "TotalQuestionsAnswered", "UserId" },
                values: new object[,]
                {
                    { new Guid("128c85db-1b2d-4d05-aa8e-73e406de78e7"), 17, new DateTime(2025, 7, 16, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9791), new DateTime(2025, 8, 3, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9791), 73.909999999999997, new Guid("0c648daa-f382-45f8-9e5e-968b04449b6b"), 23, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("40d88541-610d-4be1-a9a5-d0360a161d36"), 29, new DateTime(2025, 7, 29, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9784), new DateTime(2025, 8, 5, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9785), 80.560000000000002, new Guid("dab5aa24-7c1d-47fb-9121-6ab9f58d6785"), 36, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("49b30942-1a8d-43c4-a98a-d66288267197"), 27, new DateTime(2025, 7, 17, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9792), new DateTime(2025, 8, 2, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9792), 34.18, new Guid("446b120d-df8a-49ab-b8d0-cf1041e13694"), 79, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("7b99c6e4-a605-4c2b-8cff-dfe0b192614f"), 6, new DateTime(2025, 7, 24, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9797), new DateTime(2025, 8, 3, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9798), 13.640000000000001, new Guid("a9c80470-49cf-4dd7-9c34-14a8e66e849f"), 44, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("86485769-b476-4ffc-bc91-b9fc5681a81d"), 69, new DateTime(2025, 7, 19, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9783), new DateTime(2025, 8, 1, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9783), 87.340000000000003, new Guid("446b120d-df8a-49ab-b8d0-cf1041e13694"), 79, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("afde20dd-381d-4844-8453-7ef855f261fd"), 68, new DateTime(2025, 8, 2, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9768), new DateTime(2025, 8, 1, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9775), 73.120000000000005, new Guid("a9c80470-49cf-4dd7-9c34-14a8e66e849f"), 93, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("b65c672f-9246-4367-a416-a63918e51757"), 32, new DateTime(2025, 8, 1, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9795), new DateTime(2025, 8, 3, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9796), 71.109999999999999, new Guid("dab5aa24-7c1d-47fb-9121-6ab9f58d6785"), 45, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbe9954a-4c7a-48fb-9308-87ff412eef31"), 7, new DateTime(2025, 7, 9, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9780), new DateTime(2025, 8, 1, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9780), 63.640000000000001, new Guid("7c731b91-9782-49a9-9b90-bb907a05f200"), 11, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("bdc16851-8e2e-4cf5-a114-b3c88b23461f"), 8, new DateTime(2025, 8, 1, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9782), new DateTime(2025, 8, 1, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9782), 57.140000000000001, new Guid("0c648daa-f382-45f8-9e5e-968b04449b6b"), 14, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c72f45a5-a4ec-4103-bad8-ceb0c43c5d08"), 5, new DateTime(2025, 7, 13, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9801), new DateTime(2025, 8, 4, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9801), 8.7699999999999996, new Guid("446b120d-df8a-49ab-b8d0-cf1041e13694"), 57, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cd78fb2a-6a79-4112-93c3-a09baa2dbe55"), 20, new DateTime(2025, 7, 17, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9800), new DateTime(2025, 8, 6, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9800), 57.140000000000001, new Guid("0c648daa-f382-45f8-9e5e-968b04449b6b"), 35, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("d3223a91-9039-4c95-9700-a26b2993ab33"), 7, new DateTime(2025, 7, 30, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9789), new DateTime(2025, 8, 5, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9790), 43.75, new Guid("7c731b91-9782-49a9-9b90-bb907a05f200"), 16, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("dc00473e-9cf3-4da0-9abc-19a4465a1925"), 19, new DateTime(2025, 7, 18, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9788), new DateTime(2025, 8, 1, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9788), 70.370000000000005, new Guid("a9c80470-49cf-4dd7-9c34-14a8e66e849f"), 27, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("f6bc5d7c-4264-4d39-a071-7dbc5b95094d"), 18, new DateTime(2025, 8, 6, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9799), new DateTime(2025, 8, 3, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9799), 85.709999999999994, new Guid("7c731b91-9782-49a9-9b90-bb907a05f200"), 21, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("fd423e94-783f-44b7-8640-50a0a0c193b6"), 44, new DateTime(2025, 8, 2, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9802), new DateTime(2025, 8, 3, 6, 50, 39, 685, DateTimeKind.Utc).AddTicks(9803), 56.409999999999997, new Guid("dab5aa24-7c1d-47fb-9121-6ab9f58d6785"), 78, new Guid("33333333-3333-3333-3333-333333333333") }
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
        }
    }
}
