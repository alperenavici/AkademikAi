using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AkademikAi.Data.Migrations
{
    /// <inheritdoc />
    public partial class dataseed3 : Migration
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
                    UserAnswer = table.Column<string>(type: "nvarchar(1)", nullable: false)
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
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "dummy-conc-1", new DateTime(2025, 8, 6, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(989), "ali@example.com", true, false, null, "Ali", "ALI@EXAMPLE.COM", "ALI", "AQAAAAEAACcQAAAAEDummyHash1==", "5551111111", false, "dummy-stamp-1", "Veli", false, "ali", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "dummy-conc-2", new DateTime(2025, 8, 6, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(998), "ayse@example.com", true, false, null, "Ayşe", "AYSE@EXAMPLE.COM", "AYSE", "AQAAAAEAACcQAAAAEDummyHash2==", "5552222222", false, "dummy-stamp-2", "Yılmaz", false, "ayse", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "dummy-conc-3", new DateTime(2025, 8, 6, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(1003), "mehmet@example.com", true, false, null, "Mehmet", "MEHMET@EXAMPLE.COM", "MEHMET", "AQAAAAEAACcQAAAAEDummyHash3==", "5553333333", false, "dummy-stamp-3", "Demir", false, "mehmet", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevel", "GeneratedForUserId", "IsActive", "QuestionText", "SolutionText", "Source" },
                values: new object[,]
                {
                    { new Guid("01a9587a-25e4-44f4-8df4-508cbb9a77f9"), 0, null, true, "Hücre konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0233b75b-fc5f-433b-8b25-f1ea9bf7e24a"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("02e06a72-a24b-4c79-8554-5c5d3a0f690e"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("098c0294-e295-418b-8584-a474a543ce57"), 2, null, true, "Elektrostatik konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0c042cf3-828e-4666-ae74-babd2a8867e5"), 2, null, true, "Hücre konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0c74f6e0-f119-4eb4-870c-4e0a012dac62"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0e66c047-70d9-4633-b93d-99596e03e587"), 1, null, true, "Kalıtım konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("0f978155-b4d4-492f-8882-7962db20a1c5"), 1, null, true, "Kalıtım konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1009f8ca-b6e5-4d48-b026-e09bb931440a"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1358289a-1e0b-4980-a5bb-d607371c7a5a"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("16afaa12-4373-4d70-bef7-98ffb4d9f6a6"), 2, null, true, "Problemler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1933f90d-5a0d-4bab-86e1-5a0b62437257"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("1d4a4817-3bca-43c1-9260-c5c18dd57c04"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("221a0f0e-cf85-4bc0-aded-5a8656a2c299"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("248ea080-7a2d-4b84-8380-9f657c4f47ad"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("25235f01-94d7-44ef-8df7-65b4ea673f41"), 0, null, true, "Hücre konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2866c61b-0e65-4877-851e-eae49172b97f"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("292f0973-81c9-4fb5-901a-8669ef6140fc"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2a03292f-89ed-4a1c-a4b2-01a611206507"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("2ddb4e92-91a2-4353-9d52-852aa7436e44"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3067a84b-bac9-4f6c-b7d9-ad015cce7c0d"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("34e314d2-6eac-415f-aa6e-e0f897d9e269"), 1, null, true, "Hücre konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("362c7a90-f21a-4173-876b-9050468faa5c"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("39d91e48-8493-4e10-bb04-ab34ae0bf0eb"), 1, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3af36b1d-6a81-48d9-8860-a6e159ce589c"), 0, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3b83a713-4247-4c07-91d4-c3caf938fa7f"), 0, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3ba00a28-2894-4b40-8a7b-e53512625139"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3cd20882-e1e1-42e5-ae33-8fc92419b6d3"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("3ce122cb-1c48-4be7-a51f-4fdd5b12c5c6"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("42499533-fdea-429b-bea2-1e2bcffc8658"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("42810fcb-cd77-456e-89b9-8feb1b28e453"), 1, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("42c11598-3852-4e12-b35d-bbbf4f72ffb2"), 2, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("48b5b8d3-5334-4893-89fb-dbc44593e45e"), 0, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4afd8381-555b-4ec3-9a73-7ed8907ab7c3"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4c6abc09-d17a-4778-af53-c530846c3ff6"), 1, null, true, "Hücre konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Hücre konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("4ccd78f3-5704-4e01-bcb2-35e7d2f35f17"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("51dcfbd9-a51c-4d05-b812-e1c2d9c3b669"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("543e91dd-e515-4159-8559-173831a23126"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("55a27875-3df9-4c24-861d-f17bfc35365e"), 2, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5872a838-0cd1-4018-9731-abca959bdb39"), 2, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("59c0613e-a322-4889-92fb-6013cc2a5684"), 0, null, true, "Temel Kavramlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5bc8ec1e-81e9-473c-a7b3-f752bc65255b"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5dd51a86-3176-4a65-a867-3041c5370432"), 0, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("5f6c65c8-d64c-4cf6-a8d0-5dd96568ed4d"), 1, null, true, "Elektrostatik konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("61ac1c3e-1731-4ee2-9f83-ebb4e598e533"), 0, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("68ca8f05-550d-4765-9737-dabce0aa5ffc"), 2, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("69f036f0-79de-4029-934a-63ddbf662d83"), 2, null, true, "Sayı Basamakları konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6cabd61a-c648-4f87-95b8-d9fabe420688"), 0, null, true, "Kalıtım konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("6d5d5989-b2ee-4c47-9412-957595ae406f"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("73f8f286-95e9-4277-a1b4-812da3ac3a9f"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7798a2d4-a3e7-46e6-9fdd-b7feb4b1abbc"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("794e0d8f-ca97-4b4e-9beb-7bf9c1b2caf2"), 1, null, true, "Kimya Bilimi konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7b3565ae-b2ef-4f03-a7c8-fcbe9ac69456"), 0, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7c396664-400e-45e8-8d23-a3d5a5e969ae"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7cbc7cb4-af78-4bc8-88bc-7d912c560c1e"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7da4761d-fb49-43b3-acc8-55498a0585bb"), 1, null, true, "Problemler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7dfb1223-bd42-4c4c-a53b-c8d0a4c56f4f"), 2, null, true, "Kimya Bilimi konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("7e9f77e3-7fcf-4e2a-bee1-7fa87ab0c208"), 1, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("81f07ac7-e14d-4304-8804-cbbdc234e956"), 1, null, true, "Bölme ve Bölünebilme konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Bölme ve Bölünebilme konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("82320167-6165-4fc1-a852-73d4b20d4e54"), 2, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8890f19a-353b-410d-9974-01397de8aaa7"), 2, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("891f1a20-f395-409f-a22e-26647dc3854e"), 2, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("89cb1dc0-930d-4304-962e-7705b208f8d4"), 1, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8b424e90-945f-4815-9655-53f67a69b851"), 2, null, true, "Temel Kavramlar konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8d8bb501-08c2-47fa-94a8-7310aa4cfdae"), 0, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8e2c1cdc-dc12-474f-b8f2-912de6f55791"), 1, null, true, "Kimyasal Türler Arası Etkileşimler konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Kimyasal Türler Arası Etkileşimler konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("8ecf8c65-9dd0-4cc8-a084-7b60ca8c43ea"), 2, null, true, "Canlıların Sınıflandırılması konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Canlıların Sınıflandırılması konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("90b334c6-0e94-4daf-a35d-aa6ad7f56089"), 2, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("91f9d112-83c2-42a9-8f5c-bce62e82650f"), 0, null, true, "Problemler konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("93ba2974-7749-47dc-884e-3d421d1f367e"), 2, null, true, "Yaşam Bilimi Biyoloji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Yaşam Bilimi Biyoloji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("99de93fc-dec5-47d8-aff3-41ffc3eec503"), 0, null, true, "Sayı Basamakları konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("9e0e17a0-6679-4b55-834e-5d7e719ff030"), 0, null, true, "Madde ve Özellikleri konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Madde ve Özellikleri konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a26eca4d-afff-4a40-8120-d063dbdec33c"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a35c1795-e04c-4b6a-92c6-e104f67a5c0d"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a512055f-9d76-4e33-8411-07bcf8c4e618"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("a79ecc15-c8eb-4647-ab75-106b617d4e93"), 2, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b029d7d5-57af-4cd1-934f-2bff76f8a13a"), 1, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b3bd9e58-bb2a-4bc5-aa34-083a508530d7"), 1, null, true, "Maddenin Halleri konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b78be876-d961-474a-8c75-98d7c7f12f96"), 1, null, true, "Atom ve Periyodik Sistem konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Atom ve Periyodik Sistem konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("b7ee8f00-1320-4faf-a3cf-b12837c5442d"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("bcab9ca3-7bce-462c-872f-6725b0fcc1b2"), 0, null, true, "Kalıtım konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("bd16f100-ca62-49db-ad78-8b478f3eeff1"), 1, null, true, "Kuvvet ve Hareket konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Kuvvet ve Hareket konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("bdfa31e4-595c-42a1-9ba8-e3c221b1ef2e"), 1, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("bfbbcbad-727d-49b7-9435-797d8df747fe"), 0, null, true, "Fizik Bilimine Giriş konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Fizik Bilimine Giriş konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c437d306-03d1-4f8b-b0e4-9bbe1ac6f880"), 1, null, true, "Sayı Basamakları konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Sayı Basamakları konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c708b46d-0ccc-4dc7-ac4e-06ac637ddcc2"), 0, null, true, "Maddenin Halleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("c94752a5-1a5f-477c-bd8a-3005118e81ed"), 0, null, true, "Kimya Bilimi konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "Kimya Bilimi konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("cf0b9f26-7c09-4bf5-b431-41fe42244f1b"), 2, null, true, "Maddenin Halleri konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Maddenin Halleri konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("cf7ad12d-37e6-47b9-8175-4dbfc677bb04"), 2, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d1fe5dd6-ec5d-4ada-8072-668ec2a7b8c3"), 0, null, true, "Problemler konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("d984ceb1-4662-429e-a0b3-566e5aa6f8b0"), 0, null, true, "Hücre Bölünmeleri konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Hücre Bölünmeleri konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("da24cd1b-7c2b-4eb8-8fb5-718415cad32b"), 1, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e2a6b9ba-9de9-4a4d-a4af-359681274b5c"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 1: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 1 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e63e3dd4-0f9c-4981-86cb-6986a0633d80"), 1, null, true, "Temel Kavramlar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Temel Kavramlar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("e8a71430-7ce7-41a5-886e-abf7a9e34b2d"), 1, null, true, "Problemler konusuyla ilgili Soru 2: Bu sorunun detayı ve metni burada yer alacak.", "Problemler konusundaki Soru 2 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("eb79ae86-fd5c-45a5-bd95-616cc35770ab"), 0, null, true, "İş, Güç ve Enerji konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "İş, Güç ve Enerji konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("eedb2b9f-a744-49b8-989d-92917de9153d"), 1, null, true, "Rasyonel Sayılar konusuyla ilgili Soru 4: Bu sorunun detayı ve metni burada yer alacak.", "Rasyonel Sayılar konusundaki Soru 4 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f3da43bf-54ae-4fb8-9a0b-b464725942d9"), 2, null, true, "Kalıtım konusuyla ilgili Soru 5: Bu sorunun detayı ve metni burada yer alacak.", "Kalıtım konusundaki Soru 5 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f606f647-7f39-47f9-a54f-1f2bb8badda1"), 0, null, true, "Asitler, Bazlar ve Tuzlar konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Asitler, Bazlar ve Tuzlar konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" },
                    { new Guid("f8ac317a-7495-4a64-9b53-eb0d83011a10"), 0, null, true, "Elektrostatik konusuyla ilgili Soru 3: Bu sorunun detayı ve metni burada yer alacak.", "Elektrostatik konusundaki Soru 3 için detaylı çözüm metni.", "AkademikAI Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "ParentTopicId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("5bbaa0a5-aa52-4752-80c6-e7e1af496cb6"), null, "Biyoloji" },
                    { new Guid("7c653779-46ea-4a73-aa20-222b7f26ca2b"), null, "Matematik" },
                    { new Guid("8264e9ed-d4bb-4a0a-a807-2cacc7ebdbb0"), null, "Fizik" },
                    { new Guid("f319c7ca-f6d4-49b2-a8b3-174a6228e08f"), null, "Kimya" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "IsCorrect", "Label", "OptionOrder", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("00eec633-2c9b-4706-a09c-933e3780f775"), true, "A", 1, "Hücre Bölünmeleri - Soru 4 için Seçenek A", new Guid("39d91e48-8493-4e10-bb04-ab34ae0bf0eb") },
                    { new Guid("012f2b42-e282-4f95-b2da-c75598d70224"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek C", new Guid("da24cd1b-7c2b-4eb8-8fb5-718415cad32b") },
                    { new Guid("025c2461-ac13-4145-826e-9ca2110e5e92"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 2 için Seçenek D", new Guid("b78be876-d961-474a-8c75-98d7c7f12f96") },
                    { new Guid("02a1abfa-bbb6-493d-bb87-afa95dc9aa49"), false, "C", 3, "Kimya Bilimi - Soru 3 için Seçenek C", new Guid("4afd8381-555b-4ec3-9a73-7ed8907ab7c3") },
                    { new Guid("02c4ca7d-9e7f-4e12-a757-8392cafea22c"), false, "B", 2, "Rasyonel Sayılar - Soru 5 için Seçenek B", new Guid("68ca8f05-550d-4765-9737-dabce0aa5ffc") },
                    { new Guid("02ecf9ae-0c6b-4806-9e9d-0fdf5dc665e9"), false, "D", 4, "Kalıtım - Soru 3 için Seçenek D", new Guid("6cabd61a-c648-4f87-95b8-d9fabe420688") },
                    { new Guid("0301d3a2-3833-44e0-9703-e100123fd6be"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek C", new Guid("891f1a20-f395-409f-a22e-26647dc3854e") },
                    { new Guid("031031b3-4693-432f-8f82-2ad947c12c52"), false, "D", 4, "Rasyonel Sayılar - Soru 1 için Seçenek D", new Guid("221a0f0e-cf85-4bc0-aded-5a8656a2c299") },
                    { new Guid("0320d32a-afcd-449b-9f5b-aa8be8b92e14"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek A", new Guid("5872a838-0cd1-4018-9731-abca959bdb39") },
                    { new Guid("04031ad9-67ee-49db-9b01-31e4ad9c4cba"), false, "A", 1, "Hücre Bölünmeleri - Soru 2 için Seçenek A", new Guid("292f0973-81c9-4fb5-901a-8669ef6140fc") },
                    { new Guid("04957ca9-4309-4427-9eda-5bf365227293"), true, "D", 4, "Temel Kavramlar - Soru 1 için Seçenek D", new Guid("362c7a90-f21a-4173-876b-9050468faa5c") },
                    { new Guid("04f9c540-c0c0-4dac-bf75-1d62b0258713"), true, "D", 4, "Kimya Bilimi - Soru 3 için Seçenek D", new Guid("4afd8381-555b-4ec3-9a73-7ed8907ab7c3") },
                    { new Guid("05991fd8-bac9-4a7b-b92d-63998d0c79d9"), true, "D", 4, "Sayı Basamakları - Soru 5 için Seçenek D", new Guid("69f036f0-79de-4029-934a-63ddbf662d83") },
                    { new Guid("05a954fc-68aa-4e90-a5d9-c75a51f9b09f"), false, "C", 3, "Temel Kavramlar - Soru 2 için Seçenek C", new Guid("0c74f6e0-f119-4eb4-870c-4e0a012dac62") },
                    { new Guid("05b1372c-e9da-49a2-9362-f8aba4ead35f"), false, "B", 2, "Problemler - Soru 2 için Seçenek B", new Guid("e8a71430-7ce7-41a5-886e-abf7a9e34b2d") },
                    { new Guid("05fc69e8-4b05-43bd-8663-c14f95e68d24"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek A", new Guid("8d8bb501-08c2-47fa-94a8-7310aa4cfdae") },
                    { new Guid("062d2273-6371-414b-959a-b46874feec03"), false, "C", 3, "İş, Güç ve Enerji - Soru 1 için Seçenek C", new Guid("e2a6b9ba-9de9-4a4d-a4af-359681274b5c") },
                    { new Guid("07871f28-4940-4d9b-ac92-23c084eb48ce"), false, "A", 1, "Sayı Basamakları - Soru 1 için Seçenek A", new Guid("99de93fc-dec5-47d8-aff3-41ffc3eec503") },
                    { new Guid("079188d9-a514-40cb-9e7b-08acf4e8d890"), true, "C", 3, "Rasyonel Sayılar - Soru 1 için Seçenek C", new Guid("221a0f0e-cf85-4bc0-aded-5a8656a2c299") },
                    { new Guid("07bcda4f-60e0-4351-9010-e2724476aa85"), false, "D", 4, "Maddenin Halleri - Soru 2 için Seçenek D", new Guid("3067a84b-bac9-4f6c-b7d9-ad015cce7c0d") },
                    { new Guid("07c4f463-645a-42e4-9be7-cdb8b1f37826"), false, "A", 1, "Temel Kavramlar - Soru 4 için Seçenek A", new Guid("e63e3dd4-0f9c-4981-86cb-6986a0633d80") },
                    { new Guid("08f66011-b8ce-491d-abf5-89670cc46171"), true, "A", 1, "Sayı Basamakları - Soru 4 için Seçenek A", new Guid("c437d306-03d1-4f8b-b0e4-9bbe1ac6f880") },
                    { new Guid("09121769-b408-470e-ad2f-952139d89e1e"), true, "D", 4, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek D", new Guid("89cb1dc0-930d-4304-962e-7705b208f8d4") },
                    { new Guid("09d618b3-90ae-4167-ab25-c211f0e8fe89"), false, "C", 3, "Hücre Bölünmeleri - Soru 5 için Seçenek C", new Guid("8890f19a-353b-410d-9974-01397de8aaa7") },
                    { new Guid("0b6ab8cf-aeb0-4c96-bb13-a644fbc9486f"), false, "A", 1, "Problemler - Soru 5 için Seçenek A", new Guid("16afaa12-4373-4d70-bef7-98ffb4d9f6a6") },
                    { new Guid("0bc351c8-5f95-479a-bc99-24d4bb1a06fb"), false, "A", 1, "Kimya Bilimi - Soru 5 için Seçenek A", new Guid("7dfb1223-bd42-4c4c-a53b-c8d0a4c56f4f") },
                    { new Guid("0bf3a613-30c6-46c3-9c84-8ab2e3c9261c"), false, "C", 3, "Rasyonel Sayılar - Soru 2 için Seçenek C", new Guid("2866c61b-0e65-4877-851e-eae49172b97f") },
                    { new Guid("0c075d2b-c6a6-4302-a376-f399e8823205"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 3 için Seçenek A", new Guid("1d4a4817-3bca-43c1-9260-c5c18dd57c04") },
                    { new Guid("0dbebf7f-75ce-4b66-b0ec-0ea1ea7a732b"), true, "A", 1, "Fizik Bilimine Giriş - Soru 1 için Seçenek A", new Guid("51dcfbd9-a51c-4d05-b812-e1c2d9c3b669") },
                    { new Guid("0fe0be9e-21e8-4bad-9e40-21bc27a8ad3b"), false, "D", 4, "Fizik Bilimine Giriş - Soru 5 için Seçenek D", new Guid("82320167-6165-4fc1-a852-73d4b20d4e54") },
                    { new Guid("0ff79c20-de03-470b-a4ca-3fc9b83f50c5"), true, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek D", new Guid("a35c1795-e04c-4b6a-92c6-e104f67a5c0d") },
                    { new Guid("1001114e-781a-44ba-b404-a06b27bcaac8"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek B", new Guid("93ba2974-7749-47dc-884e-3d421d1f367e") },
                    { new Guid("10228b9d-d3e3-44bf-a1f8-3327c05beb69"), true, "B", 2, "Kalıtım - Soru 4 için Seçenek B", new Guid("0f978155-b4d4-492f-8882-7962db20a1c5") },
                    { new Guid("10735147-2283-4485-b318-bf4250c8d457"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek B", new Guid("6d5d5989-b2ee-4c47-9412-957595ae406f") },
                    { new Guid("10fb4ab7-1d7c-4437-ae1f-f57a755144bd"), false, "A", 1, "Kalıtım - Soru 2 için Seçenek A", new Guid("0e66c047-70d9-4633-b93d-99596e03e587") },
                    { new Guid("11a8bb1b-03f8-4f9d-8e0c-bca4d1e391c3"), false, "B", 2, "Rasyonel Sayılar - Soru 3 için Seçenek B", new Guid("5dd51a86-3176-4a65-a867-3041c5370432") },
                    { new Guid("11b9fd59-b3b6-4e55-82cf-5eedef15fd6e"), false, "A", 1, "Kimya Bilimi - Soru 1 için Seçenek A", new Guid("c94752a5-1a5f-477c-bd8a-3005118e81ed") },
                    { new Guid("11cd5754-e551-4feb-bded-17da077ae041"), true, "D", 4, "İş, Güç ve Enerji - Soru 2 için Seçenek D", new Guid("bdfa31e4-595c-42a1-9ba8-e3c221b1ef2e") },
                    { new Guid("1231c14b-7bca-4d28-885b-f975bac694c8"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek B", new Guid("8e2c1cdc-dc12-474f-b8f2-912de6f55791") },
                    { new Guid("12a7fcf5-5bbe-448c-a56e-9f17a69c1335"), false, "A", 1, "Elektrostatik - Soru 3 için Seçenek A", new Guid("f8ac317a-7495-4a64-9b53-eb0d83011a10") },
                    { new Guid("13ec8aaa-3ff8-441b-83ea-d159867b7fe1"), false, "A", 1, "Maddenin Halleri - Soru 1 için Seçenek A", new Guid("3ba00a28-2894-4b40-8a7b-e53512625139") },
                    { new Guid("148c468b-a04c-4f45-948d-31c405d7b0c5"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 1 için Seçenek C", new Guid("3b83a713-4247-4c07-91d4-c3caf938fa7f") },
                    { new Guid("14f8d752-7bf4-4391-bff0-89dd8e98fb61"), false, "C", 3, "Kalıtım - Soru 3 için Seçenek C", new Guid("6cabd61a-c648-4f87-95b8-d9fabe420688") },
                    { new Guid("166fc81c-b597-4c4d-ba3e-96d65eb81d4c"), true, "C", 3, "Kalıtım - Soru 5 için Seçenek C", new Guid("f3da43bf-54ae-4fb8-9a0b-b464725942d9") },
                    { new Guid("17b3e475-2b38-4db7-9b18-5d08db9c709e"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek D", new Guid("8e2c1cdc-dc12-474f-b8f2-912de6f55791") },
                    { new Guid("17ec78bd-dc54-4573-a252-cb58e0d1f106"), false, "A", 1, "Problemler - Soru 4 için Seçenek A", new Guid("7da4761d-fb49-43b3-acc8-55498a0585bb") },
                    { new Guid("18102261-ccad-4e53-89e4-796513c3d838"), false, "A", 1, "Kalıtım - Soru 5 için Seçenek A", new Guid("f3da43bf-54ae-4fb8-9a0b-b464725942d9") },
                    { new Guid("18529760-0358-47fa-b31e-0b7c1c4628ae"), false, "D", 4, "Elektrostatik - Soru 1 için Seçenek D", new Guid("7798a2d4-a3e7-46e6-9fdd-b7feb4b1abbc") },
                    { new Guid("186d03e9-67ea-4c31-b668-795fc2883760"), false, "D", 4, "Kimya Bilimi - Soru 1 için Seçenek D", new Guid("c94752a5-1a5f-477c-bd8a-3005118e81ed") },
                    { new Guid("1950dba7-8f30-4dd0-810d-b48ba0a497ec"), false, "D", 4, "Temel Kavramlar - Soru 4 için Seçenek D", new Guid("e63e3dd4-0f9c-4981-86cb-6986a0633d80") },
                    { new Guid("19e26d46-9666-4cca-8f53-f696d225c6ee"), true, "A", 1, "Maddenin Halleri - Soru 4 için Seçenek A", new Guid("b3bd9e58-bb2a-4bc5-aa34-083a508530d7") },
                    { new Guid("1a196b08-89aa-4eeb-bfa1-41f00a3d3492"), false, "D", 4, "Temel Kavramlar - Soru 5 için Seçenek D", new Guid("8b424e90-945f-4815-9655-53f67a69b851") },
                    { new Guid("1a9c2f57-5c38-4149-8835-c2d75859ae7b"), true, "A", 1, "Madde ve Özellikleri - Soru 2 için Seçenek A", new Guid("3cd20882-e1e1-42e5-ae33-8fc92419b6d3") },
                    { new Guid("1b345aa8-1974-4227-a9ea-ac78519d5c96"), false, "C", 3, "Hücre Bölünmeleri - Soru 1 için Seçenek C", new Guid("543e91dd-e515-4159-8559-173831a23126") },
                    { new Guid("1c789070-590e-4c84-8a20-057ae29fbdfd"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek B", new Guid("5872a838-0cd1-4018-9731-abca959bdb39") },
                    { new Guid("1de78872-1cfa-4b1c-94c4-6479d283995e"), false, "B", 2, "Kalıtım - Soru 3 için Seçenek B", new Guid("6cabd61a-c648-4f87-95b8-d9fabe420688") },
                    { new Guid("202f50f6-be8b-468e-a653-61dbcddbf207"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 3 için Seçenek C", new Guid("1d4a4817-3bca-43c1-9260-c5c18dd57c04") },
                    { new Guid("2116d0bc-6ded-4a74-b3ed-84286de6db9b"), false, "A", 1, "Hücre - Soru 1 için Seçenek A", new Guid("25235f01-94d7-44ef-8df7-65b4ea673f41") },
                    { new Guid("22598cc4-a15f-4521-b53c-0b1c8e492865"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek B", new Guid("89cb1dc0-930d-4304-962e-7705b208f8d4") },
                    { new Guid("2422c714-0eed-4394-8e77-2f4baad067ab"), false, "A", 1, "Elektrostatik - Soru 4 için Seçenek A", new Guid("4ccd78f3-5704-4e01-bcb2-35e7d2f35f17") },
                    { new Guid("25273d53-83d1-40ce-93d4-4d67a280c39c"), false, "D", 4, "Hücre Bölünmeleri - Soru 2 için Seçenek D", new Guid("292f0973-81c9-4fb5-901a-8669ef6140fc") },
                    { new Guid("258918b0-b0c9-4882-99b7-13b0dda6e7ed"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek D", new Guid("5872a838-0cd1-4018-9731-abca959bdb39") },
                    { new Guid("25de35ba-14c1-47bc-96ec-468df6820e2f"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek C", new Guid("2a03292f-89ed-4a1c-a4b2-01a611206507") },
                    { new Guid("26885151-ed36-4028-9adc-9d9fda49843d"), false, "B", 2, "Madde ve Özellikleri - Soru 2 için Seçenek B", new Guid("3cd20882-e1e1-42e5-ae33-8fc92419b6d3") },
                    { new Guid("26ba41ba-e797-464a-845c-e50c29d19f00"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek A", new Guid("8e2c1cdc-dc12-474f-b8f2-912de6f55791") },
                    { new Guid("2726938d-07b6-4f99-8423-71c999046d05"), false, "A", 1, "Elektrostatik - Soru 5 için Seçenek A", new Guid("098c0294-e295-418b-8584-a474a543ce57") },
                    { new Guid("27600e47-5612-43dd-82b8-79b76a31fc98"), true, "A", 1, "Elektrostatik - Soru 2 için Seçenek A", new Guid("5f6c65c8-d64c-4cf6-a8d0-5dd96568ed4d") },
                    { new Guid("27d7c5f3-4238-4d0d-83bd-01d782eba223"), false, "B", 2, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek B", new Guid("73f8f286-95e9-4277-a1b4-812da3ac3a9f") },
                    { new Guid("28039603-8ea9-40f5-9acc-0e2de0905151"), true, "C", 3, "Fizik Bilimine Giriş - Soru 2 için Seçenek C", new Guid("42499533-fdea-429b-bea2-1e2bcffc8658") },
                    { new Guid("288c9d2c-95a8-44fa-8acf-2f4563e0891f"), true, "B", 2, "Temel Kavramlar - Soru 4 için Seçenek B", new Guid("e63e3dd4-0f9c-4981-86cb-6986a0633d80") },
                    { new Guid("29fd7d7f-5d41-4c92-a178-c85d3ec3bbca"), false, "C", 3, "Hücre Bölünmeleri - Soru 4 için Seçenek C", new Guid("39d91e48-8493-4e10-bb04-ab34ae0bf0eb") },
                    { new Guid("2b9c37c6-bbbb-4123-98c1-facc6e097b65"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek C", new Guid("6d5d5989-b2ee-4c47-9412-957595ae406f") },
                    { new Guid("2cc67444-a5c1-4949-8c4d-6ed972f497ae"), false, "D", 4, "Madde ve Özellikleri - Soru 2 için Seçenek D", new Guid("3cd20882-e1e1-42e5-ae33-8fc92419b6d3") },
                    { new Guid("2cd1a215-44bc-4b88-8005-999076138a27"), false, "A", 1, "Fizik Bilimine Giriş - Soru 2 için Seçenek A", new Guid("42499533-fdea-429b-bea2-1e2bcffc8658") },
                    { new Guid("2d7d3656-186e-4713-80e9-ec861e776429"), true, "A", 1, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek A", new Guid("93ba2974-7749-47dc-884e-3d421d1f367e") },
                    { new Guid("2dbd63e9-d53b-4030-a555-4b12fd34bf5c"), true, "B", 2, "Kimya Bilimi - Soru 2 için Seçenek B", new Guid("02e06a72-a24b-4c79-8554-5c5d3a0f690e") },
                    { new Guid("3001cc14-fcd1-4a15-ba79-0e829ff7facf"), false, "B", 2, "Hücre Bölünmeleri - Soru 4 için Seçenek B", new Guid("39d91e48-8493-4e10-bb04-ab34ae0bf0eb") },
                    { new Guid("30f713f6-9ed6-47d0-8c84-f3516d368700"), false, "B", 2, "Kimya Bilimi - Soru 4 için Seçenek B", new Guid("794e0d8f-ca97-4b4e-9beb-7bf9c1b2caf2") },
                    { new Guid("32e902fe-3877-49c9-bcb6-62b7d327335e"), false, "D", 4, "Kalıtım - Soru 1 için Seçenek D", new Guid("bcab9ca3-7bce-462c-872f-6725b0fcc1b2") },
                    { new Guid("33c5538e-939c-4483-a667-3b5cfd8f209c"), false, "B", 2, "Kuvvet ve Hareket - Soru 2 için Seçenek B", new Guid("bd16f100-ca62-49db-ad78-8b478f3eeff1") },
                    { new Guid("33f7d451-77ff-4a21-8767-442d495b2465"), false, "A", 1, "Temel Kavramlar - Soru 1 için Seçenek A", new Guid("362c7a90-f21a-4173-876b-9050468faa5c") },
                    { new Guid("355ae1e0-800f-4724-97d3-42289d629534"), false, "A", 1, "Maddenin Halleri - Soru 3 için Seçenek A", new Guid("c708b46d-0ccc-4dc7-ac4e-06ac637ddcc2") },
                    { new Guid("358b719d-dad6-4e02-990d-dac1b98fdc3a"), true, "B", 2, "Sayı Basamakları - Soru 3 için Seçenek B", new Guid("1358289a-1e0b-4980-a5bb-d607371c7a5a") },
                    { new Guid("359cff7a-de05-47e4-8945-28ef3d3d66ed"), false, "D", 4, "Sayı Basamakları - Soru 3 için Seçenek D", new Guid("1358289a-1e0b-4980-a5bb-d607371c7a5a") },
                    { new Guid("3646914e-c686-4471-8ac6-498a4f8ef2bd"), false, "A", 1, "Hücre - Soru 4 için Seçenek A", new Guid("34e314d2-6eac-415f-aa6e-e0f897d9e269") },
                    { new Guid("367ed3d9-ff5d-49fc-81f1-61d7228cf0ba"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 3 için Seçenek D", new Guid("1d4a4817-3bca-43c1-9260-c5c18dd57c04") },
                    { new Guid("38476398-0ec5-4d2a-8ca5-651309730558"), false, "D", 4, "Madde ve Özellikleri - Soru 4 için Seçenek D", new Guid("42810fcb-cd77-456e-89b9-8feb1b28e453") },
                    { new Guid("38a7f544-9208-41ff-b7e2-4ada7b51b83f"), false, "D", 4, "Fizik Bilimine Giriş - Soru 2 için Seçenek D", new Guid("42499533-fdea-429b-bea2-1e2bcffc8658") },
                    { new Guid("38ef1e40-93b5-444e-ae09-cc326bd3d38c"), true, "A", 1, "Temel Kavramlar - Soru 3 için Seçenek A", new Guid("59c0613e-a322-4889-92fb-6013cc2a5684") },
                    { new Guid("3923bbf0-8050-4bfe-95d5-1c3a1cf6bc40"), true, "C", 3, "Kuvvet ve Hareket - Soru 3 için Seçenek C", new Guid("2ddb4e92-91a2-4353-9d52-852aa7436e44") },
                    { new Guid("39453363-e296-4133-ac09-0356d4234bc2"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek C", new Guid("f606f647-7f39-47f9-a54f-1f2bb8badda1") },
                    { new Guid("39be62e7-0b3b-4b6e-81f4-05eb41d7a4ad"), false, "B", 2, "İş, Güç ve Enerji - Soru 1 için Seçenek B", new Guid("e2a6b9ba-9de9-4a4d-a4af-359681274b5c") },
                    { new Guid("3a1232f4-a6e5-471d-aeeb-69511454fda1"), false, "C", 3, "Bölme ve Bölünebilme - Soru 1 için Seçenek C", new Guid("1009f8ca-b6e5-4d48-b026-e09bb931440a") },
                    { new Guid("3a97e380-783b-4c29-8a11-2ebbd8223e8b"), false, "B", 2, "Madde ve Özellikleri - Soru 5 için Seçenek B", new Guid("42c11598-3852-4e12-b35d-bbbf4f72ffb2") },
                    { new Guid("3b5db6cf-4d68-42ce-b52c-76bda75646d6"), false, "D", 4, "Kuvvet ve Hareket - Soru 2 için Seçenek D", new Guid("bd16f100-ca62-49db-ad78-8b478f3eeff1") },
                    { new Guid("3c1b4893-8120-4819-9bc9-32e8ad3c0fbe"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 5 için Seçenek B", new Guid("90b334c6-0e94-4daf-a35d-aa6ad7f56089") },
                    { new Guid("3d5720e1-9778-4850-9495-188da3677aba"), false, "B", 2, "Madde ve Özellikleri - Soru 1 için Seçenek B", new Guid("9e0e17a0-6679-4b55-834e-5d7e719ff030") },
                    { new Guid("3d83a082-1b2e-4080-87f6-1d3aa9900e21"), false, "C", 3, "Bölme ve Bölünebilme - Soru 4 için Seçenek C", new Guid("5bc8ec1e-81e9-473c-a7b3-f752bc65255b") },
                    { new Guid("3e3c36de-f6f5-4821-bb18-cfbd62f0431a"), false, "B", 2, "Kuvvet ve Hareket - Soru 5 için Seçenek B", new Guid("a79ecc15-c8eb-4647-ab75-106b617d4e93") },
                    { new Guid("3f51085c-1b01-4924-bf2d-3adf6624a000"), false, "C", 3, "Kimya Bilimi - Soru 5 için Seçenek C", new Guid("7dfb1223-bd42-4c4c-a53b-c8d0a4c56f4f") },
                    { new Guid("3f684eee-e2a3-4798-ba88-3cb8f46a7a3d"), false, "B", 2, "Kalıtım - Soru 5 için Seçenek B", new Guid("f3da43bf-54ae-4fb8-9a0b-b464725942d9") },
                    { new Guid("3f69bab8-6ff8-4db8-943c-ece1fcf942f4"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 5 için Seçenek A", new Guid("8ecf8c65-9dd0-4cc8-a084-7b60ca8c43ea") },
                    { new Guid("405f55b2-ec5f-4f0e-b51e-30ced7841d28"), true, "D", 4, "İş, Güç ve Enerji - Soru 1 için Seçenek D", new Guid("e2a6b9ba-9de9-4a4d-a4af-359681274b5c") },
                    { new Guid("40a1e5f6-8db9-49f1-b07d-2bb39b9693b4"), false, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek C", new Guid("a35c1795-e04c-4b6a-92c6-e104f67a5c0d") },
                    { new Guid("40d8ed4a-2d97-4f38-b4b6-ad46d7f8254b"), false, "A", 1, "Kuvvet ve Hareket - Soru 1 için Seçenek A", new Guid("3af36b1d-6a81-48d9-8860-a6e159ce589c") },
                    { new Guid("417dd263-7b79-4299-93b0-e61f6d597332"), false, "A", 1, "Problemler - Soru 2 için Seçenek A", new Guid("e8a71430-7ce7-41a5-886e-abf7a9e34b2d") },
                    { new Guid("4428f9b3-5a6e-43b3-bb03-b5a08232b529"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 4 için Seçenek A", new Guid("248ea080-7a2d-4b84-8380-9f657c4f47ad") },
                    { new Guid("458148d4-f495-4e57-9828-f7fa6e936cad"), true, "B", 2, "Madde ve Özellikleri - Soru 4 için Seçenek B", new Guid("42810fcb-cd77-456e-89b9-8feb1b28e453") },
                    { new Guid("45dd1613-5cba-47e9-8c65-e7f1a83ef70c"), true, "A", 1, "Problemler - Soru 3 için Seçenek A", new Guid("d1fe5dd6-ec5d-4ada-8072-668ec2a7b8c3") },
                    { new Guid("49146879-e41f-47d3-aef9-3cbde837b0d9"), false, "D", 4, "Problemler - Soru 4 için Seçenek D", new Guid("7da4761d-fb49-43b3-acc8-55498a0585bb") },
                    { new Guid("4951b02e-8b56-41ec-a3b6-88853d90dd06"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek A", new Guid("73f8f286-95e9-4277-a1b4-812da3ac3a9f") },
                    { new Guid("4bd6c2a2-f02d-4aa5-b29b-788e58a451bc"), false, "D", 4, "Bölme ve Bölünebilme - Soru 5 için Seçenek D", new Guid("55a27875-3df9-4c24-861d-f17bfc35365e") },
                    { new Guid("4c160256-7f92-4e92-b496-c05a5dede913"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 2 için Seçenek C", new Guid("b78be876-d961-474a-8c75-98d7c7f12f96") },
                    { new Guid("4c9d206b-94e5-40b8-a767-2611a8f12610"), false, "B", 2, "Fizik Bilimine Giriş - Soru 5 için Seçenek B", new Guid("82320167-6165-4fc1-a852-73d4b20d4e54") },
                    { new Guid("4e963185-401d-4d2c-b41c-d5b9ecd8b54d"), false, "D", 4, "Hücre - Soru 2 için Seçenek D", new Guid("4c6abc09-d17a-4778-af53-c530846c3ff6") },
                    { new Guid("4e9b24f2-d0f8-401e-9085-0526c91707e7"), true, "C", 3, "Kuvvet ve Hareket - Soru 1 için Seçenek C", new Guid("3af36b1d-6a81-48d9-8860-a6e159ce589c") },
                    { new Guid("4ead26a7-4c9d-4101-9761-d5a7a5b56ec1"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek A", new Guid("89cb1dc0-930d-4304-962e-7705b208f8d4") },
                    { new Guid("4ee47d34-dabf-4693-92a4-da02c08fed3c"), true, "A", 1, "Hücre - Soru 5 için Seçenek A", new Guid("0c042cf3-828e-4666-ae74-babd2a8867e5") },
                    { new Guid("4f2d606d-b6db-48cc-a853-93d31e8669b9"), false, "A", 1, "Hücre - Soru 3 için Seçenek A", new Guid("01a9587a-25e4-44f4-8df4-508cbb9a77f9") },
                    { new Guid("50151e5e-765d-41dc-9d9a-d0587adfc2c2"), false, "C", 3, "Hücre - Soru 1 için Seçenek C", new Guid("25235f01-94d7-44ef-8df7-65b4ea673f41") },
                    { new Guid("506898e4-fcc3-4b70-8c85-ca12b9951132"), false, "B", 2, "Kimya Bilimi - Soru 1 için Seçenek B", new Guid("c94752a5-1a5f-477c-bd8a-3005118e81ed") },
                    { new Guid("51b8fa08-ae87-4422-8722-9281664a173f"), false, "D", 4, "Hücre - Soru 5 için Seçenek D", new Guid("0c042cf3-828e-4666-ae74-babd2a8867e5") },
                    { new Guid("52dd81e7-76e5-4987-be31-4d0db8639ed4"), false, "A", 1, "Kalıtım - Soru 4 için Seçenek A", new Guid("0f978155-b4d4-492f-8882-7962db20a1c5") },
                    { new Guid("5496b201-bd20-45b1-8918-2d0ae03dddfe"), false, "B", 2, "İş, Güç ve Enerji - Soru 2 için Seçenek B", new Guid("bdfa31e4-595c-42a1-9ba8-e3c221b1ef2e") },
                    { new Guid("554f5fd5-e0d9-4325-b012-304bec59dbaf"), false, "D", 4, "Kimya Bilimi - Soru 4 için Seçenek D", new Guid("794e0d8f-ca97-4b4e-9beb-7bf9c1b2caf2") },
                    { new Guid("56adbe11-a0a0-4651-b9bc-fdbad9411b48"), false, "A", 1, "Hücre Bölünmeleri - Soru 3 için Seçenek A", new Guid("d984ceb1-4662-429e-a0b3-566e5aa6f8b0") },
                    { new Guid("572affb4-596c-4f6c-b1f8-598a12ae42d5"), true, "B", 2, "İş, Güç ve Enerji - Soru 3 için Seçenek B", new Guid("eb79ae86-fd5c-45a5-bd95-616cc35770ab") },
                    { new Guid("576fd4d9-30a1-4483-8db4-ef2a20b8938c"), true, "B", 2, "Maddenin Halleri - Soru 2 için Seçenek B", new Guid("3067a84b-bac9-4f6c-b7d9-ad015cce7c0d") },
                    { new Guid("57b15ff8-fa97-4350-b16b-ab197f6a4da9"), true, "A", 1, "Fizik Bilimine Giriş - Soru 4 için Seçenek A", new Guid("b029d7d5-57af-4cd1-934f-2bff76f8a13a") },
                    { new Guid("594d1de4-bb00-4c03-8c24-6fe905ef4e7a"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 3 için Seçenek B", new Guid("1d4a4817-3bca-43c1-9260-c5c18dd57c04") },
                    { new Guid("59ee944d-e50a-48a9-bb0e-e0eaa0d097ff"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 4 için Seçenek D", new Guid("248ea080-7a2d-4b84-8380-9f657c4f47ad") },
                    { new Guid("5a9c41bb-8d94-489e-af2a-8875d55bfbbd"), false, "D", 4, "Elektrostatik - Soru 5 için Seçenek D", new Guid("098c0294-e295-418b-8584-a474a543ce57") },
                    { new Guid("5aaed408-3c9d-46a6-8d4d-cc4bc44e0798"), false, "D", 4, "Bölme ve Bölünebilme - Soru 1 için Seçenek D", new Guid("1009f8ca-b6e5-4d48-b026-e09bb931440a") },
                    { new Guid("5abf886c-73d3-4e11-99b2-db5b890cb143"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek C", new Guid("7b3565ae-b2ef-4f03-a7c8-fcbe9ac69456") },
                    { new Guid("5af0d305-a36e-493b-99b4-017adfc41cab"), true, "D", 4, "Madde ve Özellikleri - Soru 1 için Seçenek D", new Guid("9e0e17a0-6679-4b55-834e-5d7e719ff030") },
                    { new Guid("5bb1ad6e-4d75-45fe-b2f0-0723dd43a340"), false, "B", 2, "Kuvvet ve Hareket - Soru 4 için Seçenek B", new Guid("7c396664-400e-45e8-8d23-a3d5a5e969ae") },
                    { new Guid("5bc4725a-99ea-4d05-989b-12efae737e00"), false, "D", 4, "Problemler - Soru 3 için Seçenek D", new Guid("d1fe5dd6-ec5d-4ada-8072-668ec2a7b8c3") },
                    { new Guid("5d481063-096b-4616-b10a-5bdd5b8c54f2"), true, "B", 2, "İş, Güç ve Enerji - Soru 5 için Seçenek B", new Guid("cf7ad12d-37e6-47b9-8175-4dbfc677bb04") },
                    { new Guid("5e1a797e-03bb-451c-8c0f-408a048063fa"), true, "D", 4, "Problemler - Soru 2 için Seçenek D", new Guid("e8a71430-7ce7-41a5-886e-abf7a9e34b2d") },
                    { new Guid("5e80e430-8c77-48f3-a3ff-796c36380946"), false, "C", 3, "Sayı Basamakları - Soru 1 için Seçenek C", new Guid("99de93fc-dec5-47d8-aff3-41ffc3eec503") },
                    { new Guid("5e9fd59a-a09e-4883-b43b-c6d85b771cbd"), false, "D", 4, "Kalıtım - Soru 5 için Seçenek D", new Guid("f3da43bf-54ae-4fb8-9a0b-b464725942d9") },
                    { new Guid("5eee5f3c-92f6-4580-a8e3-330e01bedd4c"), true, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek B", new Guid("891f1a20-f395-409f-a22e-26647dc3854e") },
                    { new Guid("5fd04ab6-e7d0-4ecd-8b3d-12b470be2e4b"), true, "C", 3, "İş, Güç ve Enerji - Soru 4 için Seçenek C", new Guid("b7ee8f00-1320-4faf-a3cf-b12837c5442d") },
                    { new Guid("5fd58443-9220-4d17-addc-5a64c646d52e"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek D", new Guid("f606f647-7f39-47f9-a54f-1f2bb8badda1") },
                    { new Guid("5ff8ba3f-57bc-427d-925f-85382415136f"), false, "C", 3, "Rasyonel Sayılar - Soru 3 için Seçenek C", new Guid("5dd51a86-3176-4a65-a867-3041c5370432") },
                    { new Guid("60810307-8662-4c47-9ac8-3480cd1aa56b"), true, "B", 2, "Hücre Bölünmeleri - Soru 3 için Seçenek B", new Guid("d984ceb1-4662-429e-a0b3-566e5aa6f8b0") },
                    { new Guid("609be096-57a6-46ca-8963-f0a9aa8d26e6"), true, "A", 1, "Rasyonel Sayılar - Soru 3 için Seçenek A", new Guid("5dd51a86-3176-4a65-a867-3041c5370432") },
                    { new Guid("615e74ea-a4e7-4eb2-8d53-06aa7d130cc0"), false, "C", 3, "Temel Kavramlar - Soru 4 için Seçenek C", new Guid("e63e3dd4-0f9c-4981-86cb-6986a0633d80") },
                    { new Guid("618cb0c8-7720-45d9-95ef-7c7f72f5a8c1"), true, "B", 2, "Atom ve Periyodik Sistem - Soru 1 için Seçenek B", new Guid("3b83a713-4247-4c07-91d4-c3caf938fa7f") },
                    { new Guid("629d830c-7716-457b-96e0-d5e531a56a54"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek B", new Guid("8d8bb501-08c2-47fa-94a8-7310aa4cfdae") },
                    { new Guid("62f7ffa6-a82d-49b9-8929-891a0a9606f8"), true, "B", 2, "Hücre Bölünmeleri - Soru 2 için Seçenek B", new Guid("292f0973-81c9-4fb5-901a-8669ef6140fc") },
                    { new Guid("63bf0e73-1641-4207-bff4-dc2e7381e737"), false, "B", 2, "Fizik Bilimine Giriş - Soru 1 için Seçenek B", new Guid("51dcfbd9-a51c-4d05-b812-e1c2d9c3b669") },
                    { new Guid("64301674-6410-440b-82d2-668472bdf1f6"), true, "D", 4, "Maddenin Halleri - Soru 5 için Seçenek D", new Guid("cf0b9f26-7c09-4bf5-b431-41fe42244f1b") },
                    { new Guid("64b4d3e9-d3bb-4f28-be9c-097ecbc5528e"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek C", new Guid("3ce122cb-1c48-4be7-a51f-4fdd5b12c5c6") },
                    { new Guid("658f1755-72f3-45c6-9add-c25446e175d5"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 2 için Seçenek A", new Guid("7e9f77e3-7fcf-4e2a-bee1-7fa87ab0c208") },
                    { new Guid("673561f3-473c-4c8a-b615-eacdbec0c839"), true, "D", 4, "Hücre Bölünmeleri - Soru 1 için Seçenek D", new Guid("543e91dd-e515-4159-8559-173831a23126") },
                    { new Guid("68167c95-655c-47a4-9473-a8eaf0ca6009"), true, "B", 2, "Bölme ve Bölünebilme - Soru 4 için Seçenek B", new Guid("5bc8ec1e-81e9-473c-a7b3-f752bc65255b") },
                    { new Guid("6818b72e-038a-4f80-8b2f-ba62c42e16fd"), true, "B", 2, "Hücre Bölünmeleri - Soru 5 için Seçenek B", new Guid("8890f19a-353b-410d-9974-01397de8aaa7") },
                    { new Guid("68426bf6-01dc-4d05-9daa-a7e482397f9a"), false, "B", 2, "Temel Kavramlar - Soru 1 için Seçenek B", new Guid("362c7a90-f21a-4173-876b-9050468faa5c") },
                    { new Guid("6956673e-152d-420b-9598-52fe8de47fc1"), false, "D", 4, "Hücre Bölünmeleri - Soru 5 için Seçenek D", new Guid("8890f19a-353b-410d-9974-01397de8aaa7") },
                    { new Guid("6b6712f2-8de6-46a6-aa47-61e60e33bb1a"), false, "C", 3, "Problemler - Soru 1 için Seçenek C", new Guid("91f9d112-83c2-42a9-8f5c-bce62e82650f") },
                    { new Guid("6b78fdfc-1ed8-4baf-8df3-ca3ee21f8c01"), false, "D", 4, "Temel Kavramlar - Soru 3 için Seçenek D", new Guid("59c0613e-a322-4889-92fb-6013cc2a5684") },
                    { new Guid("6be3936b-cf9e-457c-b84e-84a88fdbebef"), false, "B", 2, "Elektrostatik - Soru 2 için Seçenek B", new Guid("5f6c65c8-d64c-4cf6-a8d0-5dd96568ed4d") },
                    { new Guid("6bec57cf-09c7-4f27-a32d-3e239251e9ce"), true, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek A", new Guid("6d5d5989-b2ee-4c47-9412-957595ae406f") },
                    { new Guid("6d463570-fd1e-43ef-b561-7d7c6311451f"), false, "A", 1, "Madde ve Özellikleri - Soru 4 için Seçenek A", new Guid("42810fcb-cd77-456e-89b9-8feb1b28e453") },
                    { new Guid("6e743198-f563-45c0-b1ba-c3829d81f31c"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek B", new Guid("f606f647-7f39-47f9-a54f-1f2bb8badda1") },
                    { new Guid("6edf13c0-3a78-4588-bc2f-c1e8d3f07464"), false, "D", 4, "Sayı Basamakları - Soru 4 için Seçenek D", new Guid("c437d306-03d1-4f8b-b0e4-9bbe1ac6f880") },
                    { new Guid("6f0d1b66-2fea-4412-b353-12d69b9fc3fb"), false, "D", 4, "Madde ve Özellikleri - Soru 3 için Seçenek D", new Guid("1933f90d-5a0d-4bab-86e1-5a0b62437257") },
                    { new Guid("6f5a2140-a050-48dd-91c1-fecf2bfe869d"), true, "C", 3, "Kimya Bilimi - Soru 1 için Seçenek C", new Guid("c94752a5-1a5f-477c-bd8a-3005118e81ed") },
                    { new Guid("70b969c0-ea13-417b-b9d6-9ee0ea1b8de7"), false, "A", 1, "Kuvvet ve Hareket - Soru 5 için Seçenek A", new Guid("a79ecc15-c8eb-4647-ab75-106b617d4e93") },
                    { new Guid("725dfd79-d65f-4f3d-b5bb-7cb03d3672d5"), true, "A", 1, "Kuvvet ve Hareket - Soru 4 için Seçenek A", new Guid("7c396664-400e-45e8-8d23-a3d5a5e969ae") },
                    { new Guid("729d6f8a-8c5d-40b9-957d-05134010ecd7"), false, "D", 4, "Fizik Bilimine Giriş - Soru 4 için Seçenek D", new Guid("b029d7d5-57af-4cd1-934f-2bff76f8a13a") },
                    { new Guid("739f9fa2-a0c5-4746-91f2-32a880cd7ecf"), true, "B", 2, "Bölme ve Bölünebilme - Soru 1 için Seçenek B", new Guid("1009f8ca-b6e5-4d48-b026-e09bb931440a") },
                    { new Guid("73a5e64d-a44d-41cd-84d7-edf3855ec62f"), true, "C", 3, "Elektrostatik - Soru 1 için Seçenek C", new Guid("7798a2d4-a3e7-46e6-9fdd-b7feb4b1abbc") },
                    { new Guid("7420e525-13dd-4fd6-bddc-96221118bd72"), false, "A", 1, "Sayı Basamakları - Soru 3 için Seçenek A", new Guid("1358289a-1e0b-4980-a5bb-d607371c7a5a") },
                    { new Guid("74bd5355-eaba-4358-a8e2-c065954d1183"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 4 için Seçenek B", new Guid("a512055f-9d76-4e33-8411-07bcf8c4e618") },
                    { new Guid("74eee95b-5c1f-47bc-addd-c5558eae6b4b"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 1 için Seçenek D", new Guid("61ac1c3e-1731-4ee2-9f83-ebb4e598e533") },
                    { new Guid("76adfb31-d133-4028-a6d3-1495fb32f75a"), false, "C", 3, "Hücre - Soru 5 için Seçenek C", new Guid("0c042cf3-828e-4666-ae74-babd2a8867e5") },
                    { new Guid("78508177-4144-44c9-8d7e-f1842fc37c0b"), false, "C", 3, "İş, Güç ve Enerji - Soru 5 için Seçenek C", new Guid("cf7ad12d-37e6-47b9-8175-4dbfc677bb04") },
                    { new Guid("7853ac26-3c7b-47b2-897d-7c6dd6c7037c"), false, "A", 1, "Elektrostatik - Soru 1 için Seçenek A", new Guid("7798a2d4-a3e7-46e6-9fdd-b7feb4b1abbc") },
                    { new Guid("78811ce8-ec9c-4011-b51d-4bb98ca4775f"), false, "A", 1, "Bölme ve Bölünebilme - Soru 4 için Seçenek A", new Guid("5bc8ec1e-81e9-473c-a7b3-f752bc65255b") },
                    { new Guid("78918d25-812b-4292-820f-337fc404683d"), true, "D", 4, "Kalıtım - Soru 2 için Seçenek D", new Guid("0e66c047-70d9-4633-b93d-99596e03e587") },
                    { new Guid("7a113c76-cb98-46f6-a763-e8f2fba502db"), false, "B", 2, "Hücre - Soru 2 için Seçenek B", new Guid("4c6abc09-d17a-4778-af53-c530846c3ff6") },
                    { new Guid("7a7ad3ae-5b72-4ad4-b019-4848035da7fa"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 5 için Seçenek D", new Guid("90b334c6-0e94-4daf-a35d-aa6ad7f56089") },
                    { new Guid("7b15c17f-be98-4d3a-b450-68ec563e5ba1"), false, "B", 2, "Sayı Basamakları - Soru 4 için Seçenek B", new Guid("c437d306-03d1-4f8b-b0e4-9bbe1ac6f880") },
                    { new Guid("7d6129ab-269b-4041-bafe-7a73cb6fd124"), false, "B", 2, "Sayı Basamakları - Soru 5 için Seçenek B", new Guid("69f036f0-79de-4029-934a-63ddbf662d83") },
                    { new Guid("7e046523-3f58-48d8-9624-22efe9f39e11"), false, "C", 3, "Fizik Bilimine Giriş - Soru 4 için Seçenek C", new Guid("b029d7d5-57af-4cd1-934f-2bff76f8a13a") },
                    { new Guid("7f35285a-b536-4b95-a672-ce990960bca4"), false, "D", 4, "Sayı Basamakları - Soru 2 için Seçenek D", new Guid("7cbc7cb4-af78-4bc8-88bc-7d912c560c1e") },
                    { new Guid("807ca351-d14b-413d-8c0f-092b00e104ae"), false, "B", 2, "Maddenin Halleri - Soru 3 için Seçenek B", new Guid("c708b46d-0ccc-4dc7-ac4e-06ac637ddcc2") },
                    { new Guid("80f26657-1efe-4408-b944-d3a54e12e5bd"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek B", new Guid("a26eca4d-afff-4a40-8120-d063dbdec33c") },
                    { new Guid("827a301b-b46f-48be-a0cc-2d95337ba743"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek D", new Guid("3ce122cb-1c48-4be7-a51f-4fdd5b12c5c6") },
                    { new Guid("82c56b96-302b-40c4-a26c-5d1e4cb3afd5"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 4 için Seçenek C", new Guid("89cb1dc0-930d-4304-962e-7705b208f8d4") },
                    { new Guid("82f2ec4b-7b93-4622-987e-4e0a2bfad211"), true, "A", 1, "Problemler - Soru 1 için Seçenek A", new Guid("91f9d112-83c2-42a9-8f5c-bce62e82650f") },
                    { new Guid("84402b76-ed5b-4195-bea2-a9359df95eab"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek A", new Guid("7b3565ae-b2ef-4f03-a7c8-fcbe9ac69456") },
                    { new Guid("845781a0-4190-48cf-8542-f0e88a69e2fc"), false, "B", 2, "Rasyonel Sayılar - Soru 1 için Seçenek B", new Guid("221a0f0e-cf85-4bc0-aded-5a8656a2c299") },
                    { new Guid("8530ed77-a6bd-4a95-8459-2d554ab59665"), true, "C", 3, "Temel Kavramlar - Soru 5 için Seçenek C", new Guid("8b424e90-945f-4815-9655-53f67a69b851") },
                    { new Guid("854dc089-a9c3-4de6-9824-faf56fcc6643"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 2 için Seçenek B", new Guid("b78be876-d961-474a-8c75-98d7c7f12f96") },
                    { new Guid("87339e5e-5ca9-4f9e-8a4c-4f2e871ef218"), true, "D", 4, "Rasyonel Sayılar - Soru 2 için Seçenek D", new Guid("2866c61b-0e65-4877-851e-eae49172b97f") },
                    { new Guid("877d9482-252d-4d2b-8fac-44431f8aec26"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek A", new Guid("a35c1795-e04c-4b6a-92c6-e104f67a5c0d") },
                    { new Guid("877dd758-1b72-473c-a0d2-c01e9fbbab4f"), true, "C", 3, "Maddenin Halleri - Soru 1 için Seçenek C", new Guid("3ba00a28-2894-4b40-8a7b-e53512625139") },
                    { new Guid("8781cd38-47b9-4ee1-a683-649cac394ea6"), false, "D", 4, "Sayı Basamakları - Soru 1 için Seçenek D", new Guid("99de93fc-dec5-47d8-aff3-41ffc3eec503") },
                    { new Guid("88d5184c-a0ef-4352-8506-89ef0337cd16"), false, "B", 2, "Bölme ve Bölünebilme - Soru 2 için Seçenek B", new Guid("81f07ac7-e14d-4304-8804-cbbdc234e956") },
                    { new Guid("88d85893-de8d-4351-8a51-7c4f0f117af7"), true, "C", 3, "Kimya Bilimi - Soru 4 için Seçenek C", new Guid("794e0d8f-ca97-4b4e-9beb-7bf9c1b2caf2") },
                    { new Guid("893f4710-5aa0-4f2a-9d37-81e4be48b1c2"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 2 için Seçenek D", new Guid("6d5d5989-b2ee-4c47-9412-957595ae406f") },
                    { new Guid("8a0445fd-83af-44e9-81ee-dc5e64d1de84"), false, "D", 4, "Kimya Bilimi - Soru 5 için Seçenek D", new Guid("7dfb1223-bd42-4c4c-a53b-c8d0a4c56f4f") },
                    { new Guid("8a7ffc4b-33b4-4831-94ec-2948ef8f0f00"), false, "C", 3, "Madde ve Özellikleri - Soru 5 için Seçenek C", new Guid("42c11598-3852-4e12-b35d-bbbf4f72ffb2") },
                    { new Guid("8bb93eb8-2ddc-48f2-a20e-1897f5cc525f"), false, "C", 3, "Kalıtım - Soru 2 için Seçenek C", new Guid("0e66c047-70d9-4633-b93d-99596e03e587") },
                    { new Guid("8c5c87dc-99e0-49d8-ad82-8f51949452e2"), false, "D", 4, "Kuvvet ve Hareket - Soru 4 için Seçenek D", new Guid("7c396664-400e-45e8-8d23-a3d5a5e969ae") },
                    { new Guid("8c919a1f-ec5b-40fa-b0a1-b1ff49987d02"), false, "A", 1, "İş, Güç ve Enerji - Soru 3 için Seçenek A", new Guid("eb79ae86-fd5c-45a5-bd95-616cc35770ab") },
                    { new Guid("8d0fa911-c179-4810-813b-e2aa5cefef86"), false, "B", 2, "Elektrostatik - Soru 4 için Seçenek B", new Guid("4ccd78f3-5704-4e01-bcb2-35e7d2f35f17") },
                    { new Guid("8ec5dab5-ea4c-42cd-b44c-a88b7d665935"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 2 için Seçenek B", new Guid("7e9f77e3-7fcf-4e2a-bee1-7fa87ab0c208") },
                    { new Guid("8fe3aaae-b7f6-45bc-9e5a-b66cf19c0fba"), false, "A", 1, "Madde ve Özellikleri - Soru 3 için Seçenek A", new Guid("1933f90d-5a0d-4bab-86e1-5a0b62437257") },
                    { new Guid("9011336b-78c6-418d-a93e-b45092c2f42e"), true, "A", 1, "Kalıtım - Soru 3 için Seçenek A", new Guid("6cabd61a-c648-4f87-95b8-d9fabe420688") },
                    { new Guid("90272622-3321-4326-b7a8-1797053da09a"), false, "B", 2, "Problemler - Soru 5 için Seçenek B", new Guid("16afaa12-4373-4d70-bef7-98ffb4d9f6a6") },
                    { new Guid("912cb67a-ef9b-43ba-90e8-84957d35b54e"), false, "A", 1, "İş, Güç ve Enerji - Soru 4 için Seçenek A", new Guid("b7ee8f00-1320-4faf-a3cf-b12837c5442d") },
                    { new Guid("9230c074-1b06-4114-99da-fef53d38fb79"), true, "C", 3, "Fizik Bilimine Giriş - Soru 5 için Seçenek C", new Guid("82320167-6165-4fc1-a852-73d4b20d4e54") },
                    { new Guid("9388e930-ba17-4fbe-ab4b-ff0f208872c9"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 1 için Seçenek B", new Guid("61ac1c3e-1731-4ee2-9f83-ebb4e598e533") },
                    { new Guid("93e5dcaa-df2e-4ca8-beff-7caa54f1072e"), false, "D", 4, "Elektrostatik - Soru 2 için Seçenek D", new Guid("5f6c65c8-d64c-4cf6-a8d0-5dd96568ed4d") },
                    { new Guid("94e75378-4464-4956-9ebe-f11edd8a99f7"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 4 için Seçenek A", new Guid("a512055f-9d76-4e33-8411-07bcf8c4e618") },
                    { new Guid("94f16799-6163-44e9-a921-fdd7fde121af"), false, "C", 3, "Madde ve Özellikleri - Soru 3 için Seçenek C", new Guid("1933f90d-5a0d-4bab-86e1-5a0b62437257") },
                    { new Guid("97a4314b-97b9-4d86-a4fd-c5910ccb7fce"), false, "C", 3, "Madde ve Özellikleri - Soru 2 için Seçenek C", new Guid("3cd20882-e1e1-42e5-ae33-8fc92419b6d3") },
                    { new Guid("98044e28-d514-4e96-a28a-d28514686a2f"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 4 için Seçenek C", new Guid("248ea080-7a2d-4b84-8380-9f657c4f47ad") },
                    { new Guid("98076cdc-b111-4d5e-b315-cd215e72cd3c"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek D", new Guid("73f8f286-95e9-4277-a1b4-812da3ac3a9f") },
                    { new Guid("983bfc96-0866-4fa3-a626-cc58d7c7a42a"), true, "C", 3, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek C", new Guid("a26eca4d-afff-4a40-8120-d063dbdec33c") },
                    { new Guid("98bffee3-f552-48eb-9006-bfa12b50da0a"), true, "D", 4, "Madde ve Özellikleri - Soru 5 için Seçenek D", new Guid("42c11598-3852-4e12-b35d-bbbf4f72ffb2") },
                    { new Guid("9ab6ba4a-c9da-4aab-a074-20c5974fafef"), false, "A", 1, "İş, Güç ve Enerji - Soru 2 için Seçenek A", new Guid("bdfa31e4-595c-42a1-9ba8-e3c221b1ef2e") },
                    { new Guid("9afe0259-03a0-4604-89d5-69cc44232de9"), true, "D", 4, "Elektrostatik - Soru 4 için Seçenek D", new Guid("4ccd78f3-5704-4e01-bcb2-35e7d2f35f17") },
                    { new Guid("9c694652-4fbf-40c6-aece-9bdca5e9021a"), false, "B", 2, "Fizik Bilimine Giriş - Soru 2 için Seçenek B", new Guid("42499533-fdea-429b-bea2-1e2bcffc8658") },
                    { new Guid("9da20d2f-3162-4eb8-bc11-a951c3097309"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 1 için Seçenek C", new Guid("61ac1c3e-1731-4ee2-9f83-ebb4e598e533") },
                    { new Guid("9e824786-7d5e-47bb-b29e-2dc3ed664a3b"), false, "A", 1, "Bölme ve Bölünebilme - Soru 5 için Seçenek A", new Guid("55a27875-3df9-4c24-861d-f17bfc35365e") },
                    { new Guid("9e8f57fa-6c96-4070-b2a7-6c8aa9685b09"), false, "B", 2, "Hücre Bölünmeleri - Soru 1 için Seçenek B", new Guid("543e91dd-e515-4159-8559-173831a23126") },
                    { new Guid("9ef708a0-c4ff-4a80-904e-5a9416d86788"), false, "A", 1, "İş, Güç ve Enerji - Soru 1 için Seçenek A", new Guid("e2a6b9ba-9de9-4a4d-a4af-359681274b5c") },
                    { new Guid("a0303ee5-fe20-484c-ac6c-863939b62437"), false, "A", 1, "Hücre Bölünmeleri - Soru 1 için Seçenek A", new Guid("543e91dd-e515-4159-8559-173831a23126") },
                    { new Guid("a0d2fa5e-3567-4d20-96b4-32ab3e360f3d"), false, "D", 4, "İş, Güç ve Enerji - Soru 4 için Seçenek D", new Guid("b7ee8f00-1320-4faf-a3cf-b12837c5442d") },
                    { new Guid("a1928487-28d8-4567-bb41-9b445f64ba11"), false, "B", 2, "Fizik Bilimine Giriş - Soru 3 için Seçenek B", new Guid("bfbbcbad-727d-49b7-9435-797d8df747fe") },
                    { new Guid("a3fcce2d-bc44-43b7-a73a-416afa4dbb95"), false, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek D", new Guid("8d8bb501-08c2-47fa-94a8-7310aa4cfdae") },
                    { new Guid("a468a068-aae0-44e4-afdd-630491b01969"), false, "B", 2, "Sayı Basamakları - Soru 2 için Seçenek B", new Guid("7cbc7cb4-af78-4bc8-88bc-7d912c560c1e") },
                    { new Guid("a51aa59e-3c17-4493-957e-0e6823192896"), true, "A", 1, "Kuvvet ve Hareket - Soru 2 için Seçenek A", new Guid("bd16f100-ca62-49db-ad78-8b478f3eeff1") },
                    { new Guid("a530f485-dfa9-441a-b6d9-3f8436d70416"), false, "D", 4, "Kuvvet ve Hareket - Soru 3 için Seçenek D", new Guid("2ddb4e92-91a2-4353-9d52-852aa7436e44") },
                    { new Guid("a64800c2-4b14-4b39-b663-da7328cc9185"), true, "B", 2, "Sayı Basamakları - Soru 1 için Seçenek B", new Guid("99de93fc-dec5-47d8-aff3-41ffc3eec503") },
                    { new Guid("a67682b1-afea-4adf-ab3a-1d44ec2953e0"), false, "D", 4, "Bölme ve Bölünebilme - Soru 4 için Seçenek D", new Guid("5bc8ec1e-81e9-473c-a7b3-f752bc65255b") },
                    { new Guid("a68a69ec-fed6-4c90-aa7e-4cd89724a75f"), false, "B", 2, "Elektrostatik - Soru 1 için Seçenek B", new Guid("7798a2d4-a3e7-46e6-9fdd-b7feb4b1abbc") },
                    { new Guid("a6df3aa7-41d5-40dd-a602-142186ebab09"), false, "C", 3, "Problemler - Soru 2 için Seçenek C", new Guid("e8a71430-7ce7-41a5-886e-abf7a9e34b2d") },
                    { new Guid("a7703cba-95d1-4036-aeb5-ce88fe5e0bb6"), false, "D", 4, "Rasyonel Sayılar - Soru 4 için Seçenek D", new Guid("eedb2b9f-a744-49b8-989d-92917de9153d") },
                    { new Guid("a7a509a1-59fe-42b9-aaff-0f70c37cbb77"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek B", new Guid("7b3565ae-b2ef-4f03-a7c8-fcbe9ac69456") },
                    { new Guid("a84df905-2f10-47f0-9fc7-7ab40ec45f5e"), true, "D", 4, "Canlıların Sınıflandırılması - Soru 2 için Seçenek D", new Guid("7e9f77e3-7fcf-4e2a-bee1-7fa87ab0c208") },
                    { new Guid("a86e78f5-7e8f-495e-bc85-47c78a0dddfa"), false, "B", 2, "Kimya Bilimi - Soru 3 için Seçenek B", new Guid("4afd8381-555b-4ec3-9a73-7ed8907ab7c3") },
                    { new Guid("a97c96f1-0f28-4935-beee-053c74bd1173"), false, "B", 2, "Kuvvet ve Hareket - Soru 1 için Seçenek B", new Guid("3af36b1d-6a81-48d9-8860-a6e159ce589c") },
                    { new Guid("a982aa75-2e6e-4e08-85b9-60b9d7177587"), true, "C", 3, "Rasyonel Sayılar - Soru 5 için Seçenek C", new Guid("68ca8f05-550d-4765-9737-dabce0aa5ffc") },
                    { new Guid("a9fcc52b-1712-488a-82f0-4284895301a7"), true, "D", 4, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek D", new Guid("2a03292f-89ed-4a1c-a4b2-01a611206507") },
                    { new Guid("aa022658-41a0-48be-94f2-11ecbcf32f78"), false, "B", 2, "Kuvvet ve Hareket - Soru 3 için Seçenek B", new Guid("2ddb4e92-91a2-4353-9d52-852aa7436e44") },
                    { new Guid("aa53f8c6-2443-4872-9a34-dcd01c5319a5"), false, "A", 1, "Fizik Bilimine Giriş - Soru 5 için Seçenek A", new Guid("82320167-6165-4fc1-a852-73d4b20d4e54") },
                    { new Guid("aba251dc-764f-4ca1-b5ec-607d67764a5e"), false, "C", 3, "Sayı Basamakları - Soru 4 için Seçenek C", new Guid("c437d306-03d1-4f8b-b0e4-9bbe1ac6f880") },
                    { new Guid("abad42d1-3ce3-4a09-be5d-6346b5f7c5b7"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek A", new Guid("891f1a20-f395-409f-a22e-26647dc3854e") },
                    { new Guid("ac3ee014-790a-471e-b5d7-297260355cc9"), true, "A", 1, "Atom ve Periyodik Sistem - Soru 5 için Seçenek A", new Guid("90b334c6-0e94-4daf-a35d-aa6ad7f56089") },
                    { new Guid("ac8947a6-e720-45fd-b6e5-d2e829849621"), false, "B", 2, "Temel Kavramlar - Soru 5 için Seçenek B", new Guid("8b424e90-945f-4815-9655-53f67a69b851") },
                    { new Guid("ad4351e9-4835-4b7d-8baa-1ddc9de3b0e5"), false, "B", 2, "Kalıtım - Soru 2 için Seçenek B", new Guid("0e66c047-70d9-4633-b93d-99596e03e587") },
                    { new Guid("ad80c291-335e-4a1b-aef9-ee73dc47fc3b"), false, "C", 3, "İş, Güç ve Enerji - Soru 3 için Seçenek C", new Guid("eb79ae86-fd5c-45a5-bd95-616cc35770ab") },
                    { new Guid("ad84a952-a0f1-43b5-89e7-9a9355037977"), false, "C", 3, "Kimya Bilimi - Soru 2 için Seçenek C", new Guid("02e06a72-a24b-4c79-8554-5c5d3a0f690e") },
                    { new Guid("ad9574f2-e447-4808-b0e6-0faedca22a1e"), false, "C", 3, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek C", new Guid("93ba2974-7749-47dc-884e-3d421d1f367e") },
                    { new Guid("ae8429fa-c3b3-4f3f-9983-da06ecef8172"), false, "B", 2, "Atom ve Periyodik Sistem - Soru 3 için Seçenek B", new Guid("0233b75b-fc5f-433b-8b25-f1ea9bf7e24a") },
                    { new Guid("aebd8e82-5143-4bcf-862f-adf7fb0096fc"), false, "A", 1, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek A", new Guid("3ce122cb-1c48-4be7-a51f-4fdd5b12c5c6") },
                    { new Guid("afa07f46-e8db-4ca1-8ae5-9d69109cb20f"), false, "B", 2, "Fizik Bilimine Giriş - Soru 4 için Seçenek B", new Guid("b029d7d5-57af-4cd1-934f-2bff76f8a13a") },
                    { new Guid("b09beb65-ed80-494d-941e-0b4f9aae9e1f"), false, "C", 3, "Sayı Basamakları - Soru 5 için Seçenek C", new Guid("69f036f0-79de-4029-934a-63ddbf662d83") },
                    { new Guid("b1fe06cf-6356-44c3-8477-c6524d07a060"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 3 için Seçenek D", new Guid("0233b75b-fc5f-433b-8b25-f1ea9bf7e24a") },
                    { new Guid("b2ef0256-3439-488d-a33a-8eb36ab15493"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 1 için Seçenek A", new Guid("3b83a713-4247-4c07-91d4-c3caf938fa7f") },
                    { new Guid("b3d75a2f-34e2-4b42-beb4-26c1940dbc93"), true, "C", 3, "Problemler - Soru 5 için Seçenek C", new Guid("16afaa12-4373-4d70-bef7-98ffb4d9f6a6") },
                    { new Guid("b41074ba-6f24-4e6f-bef6-482fde82486a"), false, "A", 1, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek A", new Guid("2a03292f-89ed-4a1c-a4b2-01a611206507") },
                    { new Guid("b42662f0-065f-41e8-a932-c4c1b8a82059"), true, "B", 2, "Yaşam Bilimi Biyoloji - Soru 2 için Seçenek B", new Guid("3ce122cb-1c48-4be7-a51f-4fdd5b12c5c6") },
                    { new Guid("b473f088-c86a-42a9-be1e-7f7f094ee830"), false, "C", 3, "İş, Güç ve Enerji - Soru 2 için Seçenek C", new Guid("bdfa31e4-595c-42a1-9ba8-e3c221b1ef2e") },
                    { new Guid("b4a38689-5e8f-42fa-aeae-b163ac4fb514"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek A", new Guid("a26eca4d-afff-4a40-8120-d063dbdec33c") },
                    { new Guid("b4feb371-5506-4373-9362-5ead517d5aaa"), false, "C", 3, "Canlıların Sınıflandırılması - Soru 2 için Seçenek C", new Guid("7e9f77e3-7fcf-4e2a-bee1-7fa87ab0c208") },
                    { new Guid("b5010dad-7cdb-4a4e-b740-e3889a09ed11"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 4 için Seçenek B", new Guid("248ea080-7a2d-4b84-8380-9f657c4f47ad") },
                    { new Guid("b5424259-9555-4db3-a9d2-012d93b9fbb8"), false, "C", 3, "Sayı Basamakları - Soru 3 için Seçenek C", new Guid("1358289a-1e0b-4980-a5bb-d607371c7a5a") },
                    { new Guid("b6703abd-d915-4ec9-80d7-4136fe8c8d52"), false, "A", 1, "Kimya Bilimi - Soru 2 için Seçenek A", new Guid("02e06a72-a24b-4c79-8554-5c5d3a0f690e") },
                    { new Guid("b6ae66a0-1f83-406c-893f-2ee67a5d5875"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 5 için Seçenek C", new Guid("90b334c6-0e94-4daf-a35d-aa6ad7f56089") },
                    { new Guid("b78d424b-5b9e-4fd2-a005-dc9968ffb471"), true, "C", 3, "Atom ve Periyodik Sistem - Soru 3 için Seçenek C", new Guid("0233b75b-fc5f-433b-8b25-f1ea9bf7e24a") },
                    { new Guid("b7eee54a-4297-47eb-885a-bea70f19575e"), false, "A", 1, "Madde ve Özellikleri - Soru 5 için Seçenek A", new Guid("42c11598-3852-4e12-b35d-bbbf4f72ffb2") },
                    { new Guid("b9656cce-ae19-4729-8fed-d7730e890183"), false, "D", 4, "Hücre Bölünmeleri - Soru 4 için Seçenek D", new Guid("39d91e48-8493-4e10-bb04-ab34ae0bf0eb") },
                    { new Guid("bbc20d05-4198-42c0-8c5f-309c9224d6ed"), true, "D", 4, "Atom ve Periyodik Sistem - Soru 4 için Seçenek D", new Guid("a512055f-9d76-4e33-8411-07bcf8c4e618") },
                    { new Guid("bc61c385-4612-4e86-8fa5-90a7409b0d0f"), false, "A", 1, "Kimya Bilimi - Soru 4 için Seçenek A", new Guid("794e0d8f-ca97-4b4e-9beb-7bf9c1b2caf2") },
                    { new Guid("bcb316c0-0581-4288-a571-c45907b0b5b2"), false, "D", 4, "Kuvvet ve Hareket - Soru 1 için Seçenek D", new Guid("3af36b1d-6a81-48d9-8860-a6e159ce589c") },
                    { new Guid("bd2083ee-3e9c-4c5a-8ac4-ee979b4bbda0"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 5 için Seçenek D", new Guid("93ba2974-7749-47dc-884e-3d421d1f367e") },
                    { new Guid("bdac1329-6cfe-4d7b-96e9-ea1df5385874"), false, "B", 2, "Hücre - Soru 4 için Seçenek B", new Guid("34e314d2-6eac-415f-aa6e-e0f897d9e269") },
                    { new Guid("bdaf823b-18b3-4ec6-8596-77384ecf698d"), false, "B", 2, "Problemler - Soru 1 için Seçenek B", new Guid("91f9d112-83c2-42a9-8f5c-bce62e82650f") },
                    { new Guid("be2fd6d4-e5ba-4b70-9b50-d339cfa159ba"), false, "A", 1, "Kimya Bilimi - Soru 3 için Seçenek A", new Guid("4afd8381-555b-4ec3-9a73-7ed8907ab7c3") },
                    { new Guid("be310927-7033-4f90-b24a-4a5cfd6bacb2"), false, "B", 2, "Hücre - Soru 5 için Seçenek B", new Guid("0c042cf3-828e-4666-ae74-babd2a8867e5") },
                    { new Guid("be80826b-106a-4c78-9042-f2dc841d56f3"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 5 için Seçenek D", new Guid("891f1a20-f395-409f-a22e-26647dc3854e") },
                    { new Guid("c025cd4d-411c-438b-9778-f476bb62c5c8"), false, "D", 4, "Problemler - Soru 5 için Seçenek D", new Guid("16afaa12-4373-4d70-bef7-98ffb4d9f6a6") },
                    { new Guid("c1cc4c48-d7a2-45bf-9ad5-9d731e303109"), false, "A", 1, "Canlıların Sınıflandırılması - Soru 1 için Seçenek A", new Guid("61ac1c3e-1731-4ee2-9f83-ebb4e598e533") },
                    { new Guid("c20cf3af-aa04-4fec-abaf-62e1be50fb0c"), true, "B", 2, "Kimya Bilimi - Soru 5 için Seçenek B", new Guid("7dfb1223-bd42-4c4c-a53b-c8d0a4c56f4f") },
                    { new Guid("c25830d5-0fd5-467a-9a17-7b624476fa6a"), false, "D", 4, "Rasyonel Sayılar - Soru 3 için Seçenek D", new Guid("5dd51a86-3176-4a65-a867-3041c5370432") },
                    { new Guid("c316cc01-b162-47db-b5d6-06603fd46283"), false, "D", 4, "Elektrostatik - Soru 3 için Seçenek D", new Guid("f8ac317a-7495-4a64-9b53-eb0d83011a10") },
                    { new Guid("c40d887d-0879-4623-8e42-09c041159589"), false, "C", 3, "Maddenin Halleri - Soru 3 için Seçenek C", new Guid("c708b46d-0ccc-4dc7-ac4e-06ac637ddcc2") },
                    { new Guid("c471948e-86c0-4c1d-a94a-d2f349a398f8"), false, "C", 3, "Problemler - Soru 4 için Seçenek C", new Guid("7da4761d-fb49-43b3-acc8-55498a0585bb") },
                    { new Guid("c49ef4f1-2967-4382-b0cc-8bf64cdd7d67"), true, "C", 3, "Hücre - Soru 2 için Seçenek C", new Guid("4c6abc09-d17a-4778-af53-c530846c3ff6") },
                    { new Guid("c5b66948-abda-4a8c-a55c-85c6338339c9"), true, "C", 3, "Canlıların Sınıflandırılması - Soru 5 için Seçenek C", new Guid("8ecf8c65-9dd0-4cc8-a084-7b60ca8c43ea") },
                    { new Guid("c5c29ed7-9b10-4ce6-a8a6-973a9ea86a48"), true, "A", 1, "Kalıtım - Soru 1 için Seçenek A", new Guid("bcab9ca3-7bce-462c-872f-6725b0fcc1b2") },
                    { new Guid("c62b9041-1241-46c7-8d7a-c2bf3d02fe45"), false, "A", 1, "Maddenin Halleri - Soru 2 için Seçenek A", new Guid("3067a84b-bac9-4f6c-b7d9-ad015cce7c0d") },
                    { new Guid("c647b67d-296e-43b1-a44b-dc367a04b151"), false, "C", 3, "Problemler - Soru 3 için Seçenek C", new Guid("d1fe5dd6-ec5d-4ada-8072-668ec2a7b8c3") },
                    { new Guid("c6bc1581-9199-469c-b974-200849d9b2eb"), false, "C", 3, "Elektrostatik - Soru 2 için Seçenek C", new Guid("5f6c65c8-d64c-4cf6-a8d0-5dd96568ed4d") },
                    { new Guid("c6d3b00f-e2a2-4b8f-9f74-f2161902e90a"), false, "B", 2, "Elektrostatik - Soru 5 için Seçenek B", new Guid("098c0294-e295-418b-8584-a474a543ce57") },
                    { new Guid("c7232bde-e801-4060-af16-2dafe4915d6c"), false, "A", 1, "Bölme ve Bölünebilme - Soru 3 için Seçenek A", new Guid("48b5b8d3-5334-4893-89fb-dbc44593e45e") },
                    { new Guid("c74fd897-663b-4c40-87fa-39575b4f0cbc"), false, "A", 1, "Madde ve Özellikleri - Soru 1 için Seçenek A", new Guid("9e0e17a0-6679-4b55-834e-5d7e719ff030") },
                    { new Guid("c7b2f5be-e07a-42ef-ab6d-b6bde6ea3c39"), false, "C", 3, "Bölme ve Bölünebilme - Soru 3 için Seçenek C", new Guid("48b5b8d3-5334-4893-89fb-dbc44593e45e") },
                    { new Guid("c7f05e98-b26a-4750-b398-0696402f836c"), false, "A", 1, "Bölme ve Bölünebilme - Soru 1 için Seçenek A", new Guid("1009f8ca-b6e5-4d48-b026-e09bb931440a") },
                    { new Guid("c89e5ddd-dc96-49ff-926e-08468dd7a3d2"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 2 için Seçenek A", new Guid("b78be876-d961-474a-8c75-98d7c7f12f96") },
                    { new Guid("c91d827e-8f5d-461f-ab25-a377553b4f2f"), false, "A", 1, "İş, Güç ve Enerji - Soru 5 için Seçenek A", new Guid("cf7ad12d-37e6-47b9-8175-4dbfc677bb04") },
                    { new Guid("c9551921-d8c6-47a5-8bf4-9847c97d4195"), false, "B", 2, "Maddenin Halleri - Soru 5 için Seçenek B", new Guid("cf0b9f26-7c09-4bf5-b431-41fe42244f1b") },
                    { new Guid("c999c7af-b31c-40a6-be5c-7c461b17fddc"), false, "C", 3, "Fizik Bilimine Giriş - Soru 1 için Seçenek C", new Guid("51dcfbd9-a51c-4d05-b812-e1c2d9c3b669") },
                    { new Guid("c9f2d824-2704-40fa-92ec-50fee1749493"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek B", new Guid("da24cd1b-7c2b-4eb8-8fb5-718415cad32b") },
                    { new Guid("ca4ec201-3889-4575-8825-3c72949f024f"), false, "B", 2, "Maddenin Halleri - Soru 4 için Seçenek B", new Guid("b3bd9e58-bb2a-4bc5-aa34-083a508530d7") },
                    { new Guid("cacbe968-3291-4e1a-b717-c63f79654025"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek D", new Guid("da24cd1b-7c2b-4eb8-8fb5-718415cad32b") },
                    { new Guid("cbb25a0d-18fc-40a3-bf2f-f35ad10eda55"), true, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 4 için Seçenek A", new Guid("da24cd1b-7c2b-4eb8-8fb5-718415cad32b") },
                    { new Guid("cc3cbe1a-ca85-4fcb-a07f-05243c90c3df"), false, "D", 4, "Kimya Bilimi - Soru 2 için Seçenek D", new Guid("02e06a72-a24b-4c79-8554-5c5d3a0f690e") },
                    { new Guid("ccf3ca00-e69c-4bc9-a7cb-4e09696dc654"), false, "B", 2, "Maddenin Halleri - Soru 1 için Seçenek B", new Guid("3ba00a28-2894-4b40-8a7b-e53512625139") },
                    { new Guid("cd2fb809-0700-4e41-9756-6cf8cbadd2cf"), false, "B", 2, "Rasyonel Sayılar - Soru 4 için Seçenek B", new Guid("eedb2b9f-a744-49b8-989d-92917de9153d") },
                    { new Guid("ce1a12d0-504c-459b-bcef-35ce85324ac4"), false, "A", 1, "Rasyonel Sayılar - Soru 1 için Seçenek A", new Guid("221a0f0e-cf85-4bc0-aded-5a8656a2c299") },
                    { new Guid("ceb7d3ec-5ca1-4430-a3f1-557aa54a402c"), false, "C", 3, "Madde ve Özellikleri - Soru 4 için Seçenek C", new Guid("42810fcb-cd77-456e-89b9-8feb1b28e453") },
                    { new Guid("cee99431-74d9-40b8-b6de-6a66238e6134"), false, "C", 3, "Kuvvet ve Hareket - Soru 2 için Seçenek C", new Guid("bd16f100-ca62-49db-ad78-8b478f3eeff1") },
                    { new Guid("cefcbc99-0488-4114-a592-dd17e2532770"), false, "C", 3, "Kalıtım - Soru 1 için Seçenek C", new Guid("bcab9ca3-7bce-462c-872f-6725b0fcc1b2") },
                    { new Guid("cf0a9c3b-6485-45d2-aee7-8367421d342f"), false, "D", 4, "Hücre Bölünmeleri - Soru 3 için Seçenek D", new Guid("d984ceb1-4662-429e-a0b3-566e5aa6f8b0") },
                    { new Guid("cf9c6cc7-5932-4eb6-b11a-79b0ed9d439e"), false, "D", 4, "Asitler, Bazlar ve Tuzlar - Soru 2 için Seçenek D", new Guid("a26eca4d-afff-4a40-8120-d063dbdec33c") },
                    { new Guid("cfd0791c-7eba-4cef-b7e0-a17189efe4ab"), false, "B", 2, "Elektrostatik - Soru 3 için Seçenek B", new Guid("f8ac317a-7495-4a64-9b53-eb0d83011a10") },
                    { new Guid("cfe42b92-62a6-4624-8529-1d9042b2bfe0"), false, "A", 1, "Rasyonel Sayılar - Soru 4 için Seçenek A", new Guid("eedb2b9f-a744-49b8-989d-92917de9153d") },
                    { new Guid("d01963f1-128e-40df-80d7-d4bfcf9b4ddc"), true, "C", 3, "Bölme ve Bölünebilme - Soru 5 için Seçenek C", new Guid("55a27875-3df9-4c24-861d-f17bfc35365e") },
                    { new Guid("d067b86a-0a1d-4e54-ad2b-f481f8db6057"), false, "C", 3, "Maddenin Halleri - Soru 4 için Seçenek C", new Guid("b3bd9e58-bb2a-4bc5-aa34-083a508530d7") },
                    { new Guid("d404db9b-dd7a-4d2d-bf16-9e73f9d3b17c"), false, "D", 4, "Atom ve Periyodik Sistem - Soru 1 için Seçenek D", new Guid("3b83a713-4247-4c07-91d4-c3caf938fa7f") },
                    { new Guid("d4cdde39-ea6b-4a85-be96-3cc692dc3de9"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 1 için Seçenek C", new Guid("8d8bb501-08c2-47fa-94a8-7310aa4cfdae") },
                    { new Guid("d4d0e159-ed6e-485d-b995-9f2c5791e59c"), true, "B", 2, "Problemler - Soru 4 için Seçenek B", new Guid("7da4761d-fb49-43b3-acc8-55498a0585bb") },
                    { new Guid("d52fa7ad-6c7d-4924-ae1a-df4563d5b03d"), false, "C", 3, "Sayı Basamakları - Soru 2 için Seçenek C", new Guid("7cbc7cb4-af78-4bc8-88bc-7d912c560c1e") },
                    { new Guid("d5c75c94-8151-4e9c-9a11-360a98c8e274"), false, "D", 4, "Rasyonel Sayılar - Soru 5 için Seçenek D", new Guid("68ca8f05-550d-4765-9737-dabce0aa5ffc") },
                    { new Guid("d68a27c5-daf2-45ed-9bd5-090b5bbb4550"), false, "B", 2, "Kimyasal Türler Arası Etkileşimler - Soru 3 için Seçenek B", new Guid("2a03292f-89ed-4a1c-a4b2-01a611206507") },
                    { new Guid("d85b5a87-ef16-4c3c-b5e2-85a5c13c20e2"), false, "D", 4, "Fizik Bilimine Giriş - Soru 3 için Seçenek D", new Guid("bfbbcbad-727d-49b7-9435-797d8df747fe") },
                    { new Guid("d90c34fb-2bd3-4932-8581-86d41a516c6c"), false, "B", 2, "Rasyonel Sayılar - Soru 2 için Seçenek B", new Guid("2866c61b-0e65-4877-851e-eae49172b97f") },
                    { new Guid("d9eb5bdd-d365-498b-8149-ef39d53ad281"), true, "D", 4, "Kuvvet ve Hareket - Soru 5 için Seçenek D", new Guid("a79ecc15-c8eb-4647-ab75-106b617d4e93") },
                    { new Guid("da14805d-03f0-4500-9796-04761607a909"), false, "D", 4, "Canlıların Sınıflandırılması - Soru 5 için Seçenek D", new Guid("8ecf8c65-9dd0-4cc8-a084-7b60ca8c43ea") },
                    { new Guid("dab4e31a-1874-4518-b779-5c92d9cdcfa1"), false, "B", 2, "İş, Güç ve Enerji - Soru 4 için Seçenek B", new Guid("b7ee8f00-1320-4faf-a3cf-b12837c5442d") },
                    { new Guid("db8eb178-5095-4bef-925c-304d4b9f1a8a"), true, "D", 4, "Maddenin Halleri - Soru 3 için Seçenek D", new Guid("c708b46d-0ccc-4dc7-ac4e-06ac637ddcc2") },
                    { new Guid("db966abb-6091-40a2-ae98-0a5dc415ad4e"), false, "D", 4, "Kalıtım - Soru 4 için Seçenek D", new Guid("0f978155-b4d4-492f-8882-7962db20a1c5") },
                    { new Guid("ddb17060-05c4-4dbb-ad76-e3e027efc22e"), false, "B", 2, "Asitler, Bazlar ve Tuzlar - Soru 1 için Seçenek B", new Guid("a35c1795-e04c-4b6a-92c6-e104f67a5c0d") },
                    { new Guid("de3d2b08-60e3-475a-bb3c-c441ce10fc50"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 5 için Seçenek C", new Guid("5872a838-0cd1-4018-9731-abca959bdb39") },
                    { new Guid("de48e4e6-9147-4d66-9b8a-07790605cf58"), false, "B", 2, "Kalıtım - Soru 1 için Seçenek B", new Guid("bcab9ca3-7bce-462c-872f-6725b0fcc1b2") },
                    { new Guid("deae723d-a5c1-4634-902e-fa57ff793895"), true, "B", 2, "Madde ve Özellikleri - Soru 3 için Seçenek B", new Guid("1933f90d-5a0d-4bab-86e1-5a0b62437257") },
                    { new Guid("ded34d04-5656-437e-b7a7-1cbffe93c0d9"), false, "D", 4, "Problemler - Soru 1 için Seçenek D", new Guid("91f9d112-83c2-42a9-8f5c-bce62e82650f") },
                    { new Guid("deeaa09b-8452-483e-85a8-32664a3753e9"), true, "D", 4, "Temel Kavramlar - Soru 2 için Seçenek D", new Guid("0c74f6e0-f119-4eb4-870c-4e0a012dac62") },
                    { new Guid("defa6e17-9ce8-4f8e-a34b-effa5bcb9d22"), true, "C", 3, "Yaşam Bilimi Biyoloji - Soru 3 için Seçenek C", new Guid("73f8f286-95e9-4277-a1b4-812da3ac3a9f") },
                    { new Guid("e108bdb7-9dde-4b1c-b6b6-07e080a2a4de"), true, "C", 3, "Rasyonel Sayılar - Soru 4 için Seçenek C", new Guid("eedb2b9f-a744-49b8-989d-92917de9153d") },
                    { new Guid("e1381d89-1a81-42ce-a46e-65ab67a71d9d"), false, "A", 1, "Rasyonel Sayılar - Soru 5 için Seçenek A", new Guid("68ca8f05-550d-4765-9737-dabce0aa5ffc") },
                    { new Guid("e161e024-ffdf-4990-a5af-aa04f4438728"), false, "C", 3, "Kuvvet ve Hareket - Soru 5 için Seçenek C", new Guid("a79ecc15-c8eb-4647-ab75-106b617d4e93") },
                    { new Guid("e1eaac17-e182-470c-a497-881a995b78d5"), false, "D", 4, "Hücre - Soru 1 için Seçenek D", new Guid("25235f01-94d7-44ef-8df7-65b4ea673f41") },
                    { new Guid("e2765830-de99-4ca2-869d-f9d5a890ec60"), false, "A", 1, "Hücre Bölünmeleri - Soru 5 için Seçenek A", new Guid("8890f19a-353b-410d-9974-01397de8aaa7") },
                    { new Guid("e2c7643b-6050-4a58-9a1d-e409226224d6"), false, "A", 1, "Rasyonel Sayılar - Soru 2 için Seçenek A", new Guid("2866c61b-0e65-4877-851e-eae49172b97f") },
                    { new Guid("e2c99406-9552-41c9-b87b-830f49736c08"), false, "B", 2, "Temel Kavramlar - Soru 3 için Seçenek B", new Guid("59c0613e-a322-4889-92fb-6013cc2a5684") },
                    { new Guid("e2d1c560-f8dc-4494-88e5-7e0a13bf59ea"), false, "C", 3, "Kuvvet ve Hareket - Soru 4 için Seçenek C", new Guid("7c396664-400e-45e8-8d23-a3d5a5e969ae") },
                    { new Guid("e358a7bb-029f-4649-938e-165c5e28d3db"), true, "D", 4, "Hücre - Soru 4 için Seçenek D", new Guid("34e314d2-6eac-415f-aa6e-e0f897d9e269") },
                    { new Guid("e4c2241c-0e3f-4df8-9a84-7a3f24355fca"), false, "C", 3, "Hücre - Soru 4 için Seçenek C", new Guid("34e314d2-6eac-415f-aa6e-e0f897d9e269") },
                    { new Guid("e525b0ee-cf97-4cb7-9e4e-4d954965ff5e"), false, "D", 4, "İş, Güç ve Enerji - Soru 5 için Seçenek D", new Guid("cf7ad12d-37e6-47b9-8175-4dbfc677bb04") },
                    { new Guid("e5566360-f7ba-4c27-ad38-2613d926d012"), false, "C", 3, "Atom ve Periyodik Sistem - Soru 4 için Seçenek C", new Guid("a512055f-9d76-4e33-8411-07bcf8c4e618") },
                    { new Guid("e9b7c4ce-a9d6-4abb-abd5-89861d62d7b6"), false, "A", 1, "Hücre - Soru 2 için Seçenek A", new Guid("4c6abc09-d17a-4778-af53-c530846c3ff6") },
                    { new Guid("ea2b4c08-6f5b-49e0-9282-ac7e8f311a9e"), false, "A", 1, "Temel Kavramlar - Soru 2 için Seçenek A", new Guid("0c74f6e0-f119-4eb4-870c-4e0a012dac62") },
                    { new Guid("eb7f0b7b-ee58-4ed7-99a8-ec62fc690c03"), false, "D", 4, "Maddenin Halleri - Soru 4 için Seçenek D", new Guid("b3bd9e58-bb2a-4bc5-aa34-083a508530d7") },
                    { new Guid("ecc51520-7687-4fbd-8632-1bc65b82c264"), false, "B", 2, "Temel Kavramlar - Soru 2 için Seçenek B", new Guid("0c74f6e0-f119-4eb4-870c-4e0a012dac62") },
                    { new Guid("ed01ef58-094d-43b1-91b0-e507eb093f12"), false, "C", 3, "Temel Kavramlar - Soru 1 için Seçenek C", new Guid("362c7a90-f21a-4173-876b-9050468faa5c") },
                    { new Guid("ed529081-dd9c-4077-95a2-726414147110"), false, "C", 3, "Hücre Bölünmeleri - Soru 2 için Seçenek C", new Guid("292f0973-81c9-4fb5-901a-8669ef6140fc") },
                    { new Guid("ed85e010-ec40-42eb-beb0-db837a64538a"), false, "D", 4, "Yaşam Bilimi Biyoloji - Soru 1 için Seçenek D", new Guid("7b3565ae-b2ef-4f03-a7c8-fcbe9ac69456") },
                    { new Guid("ed8a7680-a2e6-4e68-acc8-596cdae22f10"), false, "C", 3, "Kalıtım - Soru 4 için Seçenek C", new Guid("0f978155-b4d4-492f-8882-7962db20a1c5") },
                    { new Guid("ed995801-3e38-4519-a47e-160505032186"), false, "D", 4, "Fizik Bilimine Giriş - Soru 1 için Seçenek D", new Guid("51dcfbd9-a51c-4d05-b812-e1c2d9c3b669") },
                    { new Guid("ee457cac-9ffe-45fa-a944-20d9b0c5bc17"), false, "B", 2, "Bölme ve Bölünebilme - Soru 3 için Seçenek B", new Guid("48b5b8d3-5334-4893-89fb-dbc44593e45e") },
                    { new Guid("ee462ba0-8f83-4799-af8f-b50e79bb96ee"), false, "A", 1, "Asitler, Bazlar ve Tuzlar - Soru 3 için Seçenek A", new Guid("f606f647-7f39-47f9-a54f-1f2bb8badda1") },
                    { new Guid("ee80e8d9-90c4-47dc-b95e-2bfdc5008a62"), false, "D", 4, "Hücre - Soru 3 için Seçenek D", new Guid("01a9587a-25e4-44f4-8df4-508cbb9a77f9") },
                    { new Guid("ef01937e-b7f9-446d-beab-aac0aeaf04b8"), true, "C", 3, "Fizik Bilimine Giriş - Soru 3 için Seçenek C", new Guid("bfbbcbad-727d-49b7-9435-797d8df747fe") },
                    { new Guid("f069f547-104f-4a2b-90ac-d9cf86da17a5"), false, "B", 2, "Canlıların Sınıflandırılması - Soru 5 için Seçenek B", new Guid("8ecf8c65-9dd0-4cc8-a084-7b60ca8c43ea") },
                    { new Guid("f0d8f690-5ca2-4481-b09b-4837cb395d16"), true, "C", 3, "Elektrostatik - Soru 3 için Seçenek C", new Guid("f8ac317a-7495-4a64-9b53-eb0d83011a10") },
                    { new Guid("f0dcc4f6-3796-4400-87fd-72705033deff"), true, "C", 3, "Hücre - Soru 3 için Seçenek C", new Guid("01a9587a-25e4-44f4-8df4-508cbb9a77f9") },
                    { new Guid("f142e444-a7a3-4b99-afaf-6a479a36d59a"), false, "C", 3, "Maddenin Halleri - Soru 2 için Seçenek C", new Guid("3067a84b-bac9-4f6c-b7d9-ad015cce7c0d") },
                    { new Guid("f17828d3-692e-4b33-a83a-8604118970e4"), false, "B", 2, "Bölme ve Bölünebilme - Soru 5 için Seçenek B", new Guid("55a27875-3df9-4c24-861d-f17bfc35365e") },
                    { new Guid("f1db02cf-69b3-4d2b-a04b-e7d5d779142b"), true, "D", 4, "Bölme ve Bölünebilme - Soru 2 için Seçenek D", new Guid("81f07ac7-e14d-4304-8804-cbbdc234e956") },
                    { new Guid("f23c13d1-09d1-4f5f-959b-503448a476f8"), false, "C", 3, "Hücre Bölünmeleri - Soru 3 için Seçenek C", new Guid("d984ceb1-4662-429e-a0b3-566e5aa6f8b0") },
                    { new Guid("f355102b-1db2-4438-b07d-bb1edfaa427e"), true, "A", 1, "Sayı Basamakları - Soru 2 için Seçenek A", new Guid("7cbc7cb4-af78-4bc8-88bc-7d912c560c1e") },
                    { new Guid("f38fc4ec-2506-4c8f-b0f1-cd368bf71d8c"), false, "A", 1, "Kuvvet ve Hareket - Soru 3 için Seçenek A", new Guid("2ddb4e92-91a2-4353-9d52-852aa7436e44") },
                    { new Guid("f3a46e41-77ad-459e-90b1-82ea559c631b"), false, "A", 1, "Fizik Bilimine Giriş - Soru 3 için Seçenek A", new Guid("bfbbcbad-727d-49b7-9435-797d8df747fe") },
                    { new Guid("f479da13-953f-4aea-8c0f-51dc78ff9d0e"), false, "D", 4, "İş, Güç ve Enerji - Soru 3 için Seçenek D", new Guid("eb79ae86-fd5c-45a5-bd95-616cc35770ab") },
                    { new Guid("f4b74843-e3d1-4d98-b701-66e255c9be13"), true, "D", 4, "Bölme ve Bölünebilme - Soru 3 için Seçenek D", new Guid("48b5b8d3-5334-4893-89fb-dbc44593e45e") },
                    { new Guid("f5e271fd-b6da-4cd5-beb2-a788f6d8c2ff"), false, "A", 1, "Sayı Basamakları - Soru 5 için Seçenek A", new Guid("69f036f0-79de-4029-934a-63ddbf662d83") },
                    { new Guid("f61cced2-b36d-41b1-a760-4077195becb8"), false, "B", 2, "Hücre - Soru 3 için Seçenek B", new Guid("01a9587a-25e4-44f4-8df4-508cbb9a77f9") },
                    { new Guid("f738cdb7-72d8-4c18-afcf-23e58d37e6a5"), false, "C", 3, "Elektrostatik - Soru 4 için Seçenek C", new Guid("4ccd78f3-5704-4e01-bcb2-35e7d2f35f17") },
                    { new Guid("f78b128f-d24e-4938-b392-5d3fd6158d57"), false, "A", 1, "Maddenin Halleri - Soru 5 için Seçenek A", new Guid("cf0b9f26-7c09-4bf5-b431-41fe42244f1b") },
                    { new Guid("f7d107bb-edf1-407b-9156-b119268f0a1e"), false, "C", 3, "Temel Kavramlar - Soru 3 için Seçenek C", new Guid("59c0613e-a322-4889-92fb-6013cc2a5684") },
                    { new Guid("f9556def-4ef4-40b8-87ab-514e58385310"), false, "C", 3, "Madde ve Özellikleri - Soru 1 için Seçenek C", new Guid("9e0e17a0-6679-4b55-834e-5d7e719ff030") },
                    { new Guid("f97836be-61be-48a1-b494-feefbf27ff06"), false, "D", 4, "Maddenin Halleri - Soru 1 için Seçenek D", new Guid("3ba00a28-2894-4b40-8a7b-e53512625139") },
                    { new Guid("f9be3ccf-7d8f-4c04-8be7-5eec602cc83c"), true, "B", 2, "Hücre - Soru 1 için Seçenek B", new Guid("25235f01-94d7-44ef-8df7-65b4ea673f41") },
                    { new Guid("fa330d5c-c506-4827-b84e-46ef11f6dbfd"), true, "C", 3, "Elektrostatik - Soru 5 için Seçenek C", new Guid("098c0294-e295-418b-8584-a474a543ce57") },
                    { new Guid("fa69c59f-78fb-4836-a318-f7e22a5c2996"), false, "A", 1, "Atom ve Periyodik Sistem - Soru 3 için Seçenek A", new Guid("0233b75b-fc5f-433b-8b25-f1ea9bf7e24a") },
                    { new Guid("faaa321d-9b29-42bd-aede-62af5c67428e"), false, "A", 1, "Bölme ve Bölünebilme - Soru 2 için Seçenek A", new Guid("81f07ac7-e14d-4304-8804-cbbdc234e956") },
                    { new Guid("fbd72644-b647-486f-8915-2c9c9dae2a91"), false, "C", 3, "Maddenin Halleri - Soru 5 için Seçenek C", new Guid("cf0b9f26-7c09-4bf5-b431-41fe42244f1b") },
                    { new Guid("fc8400fe-804d-4d14-abe4-7544e0282b62"), false, "C", 3, "Bölme ve Bölünebilme - Soru 2 için Seçenek C", new Guid("81f07ac7-e14d-4304-8804-cbbdc234e956") },
                    { new Guid("fe10463e-b579-4f4d-81b1-9a59d9e3ba49"), false, "C", 3, "Kimyasal Türler Arası Etkileşimler - Soru 4 için Seçenek C", new Guid("8e2c1cdc-dc12-474f-b8f2-912de6f55791") },
                    { new Guid("fe90be42-8ce0-4657-869b-9e35d8cf454a"), false, "B", 2, "Problemler - Soru 3 için Seçenek B", new Guid("d1fe5dd6-ec5d-4ada-8072-668ec2a7b8c3") },
                    { new Guid("fe9c8410-4700-41a3-9384-5c6cad62f783"), false, "A", 1, "Temel Kavramlar - Soru 5 için Seçenek A", new Guid("8b424e90-945f-4815-9655-53f67a69b851") }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "ParentTopicId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("06836c41-0584-4c21-9c06-4a7e68fcc23e"), new Guid("f319c7ca-f6d4-49b2-a8b3-174a6228e08f"), "Atom ve Periyodik Sistem" },
                    { new Guid("08ec99c4-e1b3-4157-966d-7c2825a7fb92"), new Guid("8264e9ed-d4bb-4a0a-a807-2cacc7ebdbb0"), "İş, Güç ve Enerji" },
                    { new Guid("0de000da-fbae-48c5-bbf6-b421d267e460"), new Guid("f319c7ca-f6d4-49b2-a8b3-174a6228e08f"), "Asitler, Bazlar ve Tuzlar" },
                    { new Guid("19bc32de-bd8f-4e5a-8c94-8b9222dc82c9"), new Guid("7c653779-46ea-4a73-aa20-222b7f26ca2b"), "Rasyonel Sayılar" },
                    { new Guid("2a9f92ee-68ed-40ea-b200-ca47a7da95aa"), new Guid("5bbaa0a5-aa52-4752-80c6-e7e1af496cb6"), "Canlıların Sınıflandırılması" },
                    { new Guid("2b4418a4-4447-45a5-8631-713985a87d44"), new Guid("8264e9ed-d4bb-4a0a-a807-2cacc7ebdbb0"), "Elektrostatik" },
                    { new Guid("2fb9c2e9-0a9f-41bd-9838-63b0f5657b1f"), new Guid("8264e9ed-d4bb-4a0a-a807-2cacc7ebdbb0"), "Kuvvet ve Hareket" },
                    { new Guid("3a8ff3b8-8703-4f55-ae2c-3df3044df02e"), new Guid("f319c7ca-f6d4-49b2-a8b3-174a6228e08f"), "Maddenin Halleri" },
                    { new Guid("3ec5c0d5-2b91-4755-9881-ec3fed43ce8f"), new Guid("7c653779-46ea-4a73-aa20-222b7f26ca2b"), "Bölme ve Bölünebilme" },
                    { new Guid("6152e7a4-f418-4007-9fbe-74927516be03"), new Guid("8264e9ed-d4bb-4a0a-a807-2cacc7ebdbb0"), "Madde ve Özellikleri" },
                    { new Guid("79a16664-a48a-4ac1-903d-3a2e05c64195"), new Guid("8264e9ed-d4bb-4a0a-a807-2cacc7ebdbb0"), "Fizik Bilimine Giriş" },
                    { new Guid("7efd046b-ef86-4ca2-bbd2-18ec5d86bf13"), new Guid("f319c7ca-f6d4-49b2-a8b3-174a6228e08f"), "Kimyasal Türler Arası Etkileşimler" },
                    { new Guid("8ad43107-9308-4a0e-bea1-7b9171182d3a"), new Guid("5bbaa0a5-aa52-4752-80c6-e7e1af496cb6"), "Yaşam Bilimi Biyoloji" },
                    { new Guid("a3b185c8-59de-4f9c-a16b-e7f7b5d3d9f5"), new Guid("5bbaa0a5-aa52-4752-80c6-e7e1af496cb6"), "Hücre Bölünmeleri" },
                    { new Guid("b315aa2f-acf3-4576-967c-c3b2f671767d"), new Guid("5bbaa0a5-aa52-4752-80c6-e7e1af496cb6"), "Kalıtım" },
                    { new Guid("c430d0ed-18b6-4311-bf47-1f0a47069eae"), new Guid("7c653779-46ea-4a73-aa20-222b7f26ca2b"), "Temel Kavramlar" },
                    { new Guid("c7921fd7-1f76-440a-82cd-90e669b73816"), new Guid("5bbaa0a5-aa52-4752-80c6-e7e1af496cb6"), "Hücre" },
                    { new Guid("cfeea6f1-6515-46d6-9079-fea8adcf72d2"), new Guid("7c653779-46ea-4a73-aa20-222b7f26ca2b"), "Sayı Basamakları" },
                    { new Guid("e4e21532-797f-4cee-b5fd-55697e63ac13"), new Guid("f319c7ca-f6d4-49b2-a8b3-174a6228e08f"), "Kimya Bilimi" },
                    { new Guid("f04a7b61-532b-45b3-8097-d6fb57387b27"), new Guid("7c653779-46ea-4a73-aa20-222b7f26ca2b"), "Problemler" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsTopics",
                columns: new[] { "QuestionId", "TopicId", "Id" },
                values: new object[,]
                {
                    { new Guid("01a9587a-25e4-44f4-8df4-508cbb9a77f9"), new Guid("c7921fd7-1f76-440a-82cd-90e669b73816"), new Guid("7c6b022e-b78c-4dad-978d-34f1946ce7c4") },
                    { new Guid("0233b75b-fc5f-433b-8b25-f1ea9bf7e24a"), new Guid("06836c41-0584-4c21-9c06-4a7e68fcc23e"), new Guid("982b8932-965c-4ba3-914f-b2bbae951221") },
                    { new Guid("02e06a72-a24b-4c79-8554-5c5d3a0f690e"), new Guid("e4e21532-797f-4cee-b5fd-55697e63ac13"), new Guid("1f4b613c-7ba8-4d4c-817e-694f903f5d28") },
                    { new Guid("098c0294-e295-418b-8584-a474a543ce57"), new Guid("2b4418a4-4447-45a5-8631-713985a87d44"), new Guid("19b275e5-c01b-456a-9939-8dcf511fd058") },
                    { new Guid("0c042cf3-828e-4666-ae74-babd2a8867e5"), new Guid("c7921fd7-1f76-440a-82cd-90e669b73816"), new Guid("1414e5ff-6ce2-424b-8095-b5a66085af3d") },
                    { new Guid("0c74f6e0-f119-4eb4-870c-4e0a012dac62"), new Guid("c430d0ed-18b6-4311-bf47-1f0a47069eae"), new Guid("80ee71c1-204d-406a-aca6-070f7949c849") },
                    { new Guid("0e66c047-70d9-4633-b93d-99596e03e587"), new Guid("b315aa2f-acf3-4576-967c-c3b2f671767d"), new Guid("8c8ac9ae-8e21-4c3c-8dfe-8c18eaeaa22b") },
                    { new Guid("0f978155-b4d4-492f-8882-7962db20a1c5"), new Guid("b315aa2f-acf3-4576-967c-c3b2f671767d"), new Guid("4ac48e23-a3c7-4d96-8733-11f1de6864e1") },
                    { new Guid("1009f8ca-b6e5-4d48-b026-e09bb931440a"), new Guid("3ec5c0d5-2b91-4755-9881-ec3fed43ce8f"), new Guid("93ab3140-4a73-4764-92a3-59915a965ed8") },
                    { new Guid("1358289a-1e0b-4980-a5bb-d607371c7a5a"), new Guid("cfeea6f1-6515-46d6-9079-fea8adcf72d2"), new Guid("4aa37c60-a402-4740-93f2-336e1cab0351") },
                    { new Guid("16afaa12-4373-4d70-bef7-98ffb4d9f6a6"), new Guid("f04a7b61-532b-45b3-8097-d6fb57387b27"), new Guid("b3aaf632-9999-4490-b5d2-babe0185b523") },
                    { new Guid("1933f90d-5a0d-4bab-86e1-5a0b62437257"), new Guid("6152e7a4-f418-4007-9fbe-74927516be03"), new Guid("688ad098-431f-40f5-ad5a-ac71a4502c02") },
                    { new Guid("1d4a4817-3bca-43c1-9260-c5c18dd57c04"), new Guid("2a9f92ee-68ed-40ea-b200-ca47a7da95aa"), new Guid("8a642bce-9b5e-464b-94bb-382ff72bcde6") },
                    { new Guid("221a0f0e-cf85-4bc0-aded-5a8656a2c299"), new Guid("19bc32de-bd8f-4e5a-8c94-8b9222dc82c9"), new Guid("e27baa2b-dcb6-41df-941c-8a7aa4d7c8f2") },
                    { new Guid("248ea080-7a2d-4b84-8380-9f657c4f47ad"), new Guid("2a9f92ee-68ed-40ea-b200-ca47a7da95aa"), new Guid("3c541d01-dcea-4cdb-ad9f-55af3901c59a") },
                    { new Guid("25235f01-94d7-44ef-8df7-65b4ea673f41"), new Guid("c7921fd7-1f76-440a-82cd-90e669b73816"), new Guid("6a144b68-2cbb-4af4-9f10-72c88783f8e0") },
                    { new Guid("2866c61b-0e65-4877-851e-eae49172b97f"), new Guid("19bc32de-bd8f-4e5a-8c94-8b9222dc82c9"), new Guid("2f63454b-7990-4ca6-b7b5-83ec62937e09") },
                    { new Guid("292f0973-81c9-4fb5-901a-8669ef6140fc"), new Guid("a3b185c8-59de-4f9c-a16b-e7f7b5d3d9f5"), new Guid("38212e82-c439-48eb-ab60-0930fe139117") },
                    { new Guid("2a03292f-89ed-4a1c-a4b2-01a611206507"), new Guid("7efd046b-ef86-4ca2-bbd2-18ec5d86bf13"), new Guid("b6c87d1d-05f2-49b0-a4ae-21038d38ebe6") },
                    { new Guid("2ddb4e92-91a2-4353-9d52-852aa7436e44"), new Guid("2fb9c2e9-0a9f-41bd-9838-63b0f5657b1f"), new Guid("50cb3f35-a04a-4917-8703-f748a42b5a09") },
                    { new Guid("3067a84b-bac9-4f6c-b7d9-ad015cce7c0d"), new Guid("3a8ff3b8-8703-4f55-ae2c-3df3044df02e"), new Guid("a06b6bb9-f1d6-4ec8-9285-715ee31bd836") },
                    { new Guid("34e314d2-6eac-415f-aa6e-e0f897d9e269"), new Guid("c7921fd7-1f76-440a-82cd-90e669b73816"), new Guid("5bcabbc3-d1f1-42e7-8333-cb822f51c33d") },
                    { new Guid("362c7a90-f21a-4173-876b-9050468faa5c"), new Guid("c430d0ed-18b6-4311-bf47-1f0a47069eae"), new Guid("61a7cfd0-aed5-4d30-aecc-c52bc8adc817") },
                    { new Guid("39d91e48-8493-4e10-bb04-ab34ae0bf0eb"), new Guid("a3b185c8-59de-4f9c-a16b-e7f7b5d3d9f5"), new Guid("bd51d708-2354-4625-b409-aeb61a984edc") },
                    { new Guid("3af36b1d-6a81-48d9-8860-a6e159ce589c"), new Guid("2fb9c2e9-0a9f-41bd-9838-63b0f5657b1f"), new Guid("53009207-3fef-4825-a5db-668cf3ec169b") },
                    { new Guid("3b83a713-4247-4c07-91d4-c3caf938fa7f"), new Guid("06836c41-0584-4c21-9c06-4a7e68fcc23e"), new Guid("5d2cd3d6-cbc8-4612-8709-87397d4a7da2") },
                    { new Guid("3ba00a28-2894-4b40-8a7b-e53512625139"), new Guid("3a8ff3b8-8703-4f55-ae2c-3df3044df02e"), new Guid("3974045a-3eeb-4e8e-962d-6867284985d1") },
                    { new Guid("3cd20882-e1e1-42e5-ae33-8fc92419b6d3"), new Guid("6152e7a4-f418-4007-9fbe-74927516be03"), new Guid("e14aec52-7793-4a98-9ae7-fb38025e212b") },
                    { new Guid("3ce122cb-1c48-4be7-a51f-4fdd5b12c5c6"), new Guid("8ad43107-9308-4a0e-bea1-7b9171182d3a"), new Guid("03db9c10-2c09-43a7-8240-99bfb08dd39d") },
                    { new Guid("42499533-fdea-429b-bea2-1e2bcffc8658"), new Guid("79a16664-a48a-4ac1-903d-3a2e05c64195"), new Guid("9473f93d-7db9-45d5-a642-4c12205c9b84") },
                    { new Guid("42810fcb-cd77-456e-89b9-8feb1b28e453"), new Guid("6152e7a4-f418-4007-9fbe-74927516be03"), new Guid("9c61dd50-854a-4e20-b4ff-3ad0e9a7419c") },
                    { new Guid("42c11598-3852-4e12-b35d-bbbf4f72ffb2"), new Guid("6152e7a4-f418-4007-9fbe-74927516be03"), new Guid("d2db83b7-e067-4cbe-9c51-0987fefb59fb") },
                    { new Guid("48b5b8d3-5334-4893-89fb-dbc44593e45e"), new Guid("3ec5c0d5-2b91-4755-9881-ec3fed43ce8f"), new Guid("d480f39e-03bb-448f-9f17-97df95b980fb") },
                    { new Guid("4afd8381-555b-4ec3-9a73-7ed8907ab7c3"), new Guid("e4e21532-797f-4cee-b5fd-55697e63ac13"), new Guid("f0630692-0621-466c-80d2-d87c0e768877") },
                    { new Guid("4c6abc09-d17a-4778-af53-c530846c3ff6"), new Guid("c7921fd7-1f76-440a-82cd-90e669b73816"), new Guid("790f5023-09fa-4237-8f39-4ab2d8de684d") },
                    { new Guid("4ccd78f3-5704-4e01-bcb2-35e7d2f35f17"), new Guid("2b4418a4-4447-45a5-8631-713985a87d44"), new Guid("9642cd38-6571-457a-a531-981a92d4879f") },
                    { new Guid("51dcfbd9-a51c-4d05-b812-e1c2d9c3b669"), new Guid("79a16664-a48a-4ac1-903d-3a2e05c64195"), new Guid("2433bafa-fd46-40c7-bd4e-93c2e513a9c4") },
                    { new Guid("543e91dd-e515-4159-8559-173831a23126"), new Guid("a3b185c8-59de-4f9c-a16b-e7f7b5d3d9f5"), new Guid("ee02e5e5-55e4-4b1d-9669-cc3a22418665") },
                    { new Guid("55a27875-3df9-4c24-861d-f17bfc35365e"), new Guid("3ec5c0d5-2b91-4755-9881-ec3fed43ce8f"), new Guid("46735441-8360-481b-8f13-d7535a37a3dd") },
                    { new Guid("5872a838-0cd1-4018-9731-abca959bdb39"), new Guid("7efd046b-ef86-4ca2-bbd2-18ec5d86bf13"), new Guid("e59e4b0f-85c1-4a14-9956-31c35d305c04") },
                    { new Guid("59c0613e-a322-4889-92fb-6013cc2a5684"), new Guid("c430d0ed-18b6-4311-bf47-1f0a47069eae"), new Guid("d567925f-f791-4167-b9b6-7cb853db7a3e") },
                    { new Guid("5bc8ec1e-81e9-473c-a7b3-f752bc65255b"), new Guid("3ec5c0d5-2b91-4755-9881-ec3fed43ce8f"), new Guid("2dddf74a-4526-427b-9138-720cf222175f") },
                    { new Guid("5dd51a86-3176-4a65-a867-3041c5370432"), new Guid("19bc32de-bd8f-4e5a-8c94-8b9222dc82c9"), new Guid("d738c558-c081-4259-a0fc-6e19aa1f488c") },
                    { new Guid("5f6c65c8-d64c-4cf6-a8d0-5dd96568ed4d"), new Guid("2b4418a4-4447-45a5-8631-713985a87d44"), new Guid("c397537f-e183-4aae-aace-5cda4b848fc2") },
                    { new Guid("61ac1c3e-1731-4ee2-9f83-ebb4e598e533"), new Guid("2a9f92ee-68ed-40ea-b200-ca47a7da95aa"), new Guid("3f0de566-ba04-4634-b330-1874945f4acf") },
                    { new Guid("68ca8f05-550d-4765-9737-dabce0aa5ffc"), new Guid("19bc32de-bd8f-4e5a-8c94-8b9222dc82c9"), new Guid("0ed51912-b05b-44f1-a2d8-68bb220d912e") },
                    { new Guid("69f036f0-79de-4029-934a-63ddbf662d83"), new Guid("cfeea6f1-6515-46d6-9079-fea8adcf72d2"), new Guid("bf0dc11a-b33f-4815-a4aa-62dd37da556b") },
                    { new Guid("6cabd61a-c648-4f87-95b8-d9fabe420688"), new Guid("b315aa2f-acf3-4576-967c-c3b2f671767d"), new Guid("46f1d84f-6462-4b3c-a420-6f804332b19d") },
                    { new Guid("6d5d5989-b2ee-4c47-9412-957595ae406f"), new Guid("7efd046b-ef86-4ca2-bbd2-18ec5d86bf13"), new Guid("15ec6a02-fc89-4c02-81f8-945646688d20") },
                    { new Guid("73f8f286-95e9-4277-a1b4-812da3ac3a9f"), new Guid("8ad43107-9308-4a0e-bea1-7b9171182d3a"), new Guid("37061d08-d8b5-48b9-b32e-dc1bb6a3fd97") },
                    { new Guid("7798a2d4-a3e7-46e6-9fdd-b7feb4b1abbc"), new Guid("2b4418a4-4447-45a5-8631-713985a87d44"), new Guid("a3567b52-89d2-4109-b506-78b8f63a3869") },
                    { new Guid("794e0d8f-ca97-4b4e-9beb-7bf9c1b2caf2"), new Guid("e4e21532-797f-4cee-b5fd-55697e63ac13"), new Guid("f520edad-c891-4f3a-b854-ff0e7cad05c6") },
                    { new Guid("7b3565ae-b2ef-4f03-a7c8-fcbe9ac69456"), new Guid("8ad43107-9308-4a0e-bea1-7b9171182d3a"), new Guid("015d9128-26c2-4592-8d7a-e9c0e213db90") },
                    { new Guid("7c396664-400e-45e8-8d23-a3d5a5e969ae"), new Guid("2fb9c2e9-0a9f-41bd-9838-63b0f5657b1f"), new Guid("d1c66866-60a7-4eca-b4e3-939c69d345c0") },
                    { new Guid("7cbc7cb4-af78-4bc8-88bc-7d912c560c1e"), new Guid("cfeea6f1-6515-46d6-9079-fea8adcf72d2"), new Guid("4429e55b-b99d-40c6-a238-4314aa780c8d") },
                    { new Guid("7da4761d-fb49-43b3-acc8-55498a0585bb"), new Guid("f04a7b61-532b-45b3-8097-d6fb57387b27"), new Guid("9714babf-5f68-4689-b569-5b04e0716576") },
                    { new Guid("7dfb1223-bd42-4c4c-a53b-c8d0a4c56f4f"), new Guid("e4e21532-797f-4cee-b5fd-55697e63ac13"), new Guid("ac8af718-f436-45f7-a7ce-ebe55c6575af") },
                    { new Guid("7e9f77e3-7fcf-4e2a-bee1-7fa87ab0c208"), new Guid("2a9f92ee-68ed-40ea-b200-ca47a7da95aa"), new Guid("8de33a98-f84c-4350-a9b4-a1f039f4c2b6") },
                    { new Guid("81f07ac7-e14d-4304-8804-cbbdc234e956"), new Guid("3ec5c0d5-2b91-4755-9881-ec3fed43ce8f"), new Guid("41f2f965-bd68-4ec7-8df8-73707608a9e9") },
                    { new Guid("82320167-6165-4fc1-a852-73d4b20d4e54"), new Guid("79a16664-a48a-4ac1-903d-3a2e05c64195"), new Guid("03a2a143-206b-44bf-abd6-886ff2393435") },
                    { new Guid("8890f19a-353b-410d-9974-01397de8aaa7"), new Guid("a3b185c8-59de-4f9c-a16b-e7f7b5d3d9f5"), new Guid("aa060bd5-ad63-4c1c-90fc-ee46eaf267cb") },
                    { new Guid("891f1a20-f395-409f-a22e-26647dc3854e"), new Guid("0de000da-fbae-48c5-bbf6-b421d267e460"), new Guid("36642452-0dae-48e8-b716-d02ee21a43d6") },
                    { new Guid("89cb1dc0-930d-4304-962e-7705b208f8d4"), new Guid("8ad43107-9308-4a0e-bea1-7b9171182d3a"), new Guid("669987fc-6269-47cd-b420-c36c324b297b") },
                    { new Guid("8b424e90-945f-4815-9655-53f67a69b851"), new Guid("c430d0ed-18b6-4311-bf47-1f0a47069eae"), new Guid("fcd7f70d-bacb-4b91-ad7d-0d5359cc1dfb") },
                    { new Guid("8d8bb501-08c2-47fa-94a8-7310aa4cfdae"), new Guid("7efd046b-ef86-4ca2-bbd2-18ec5d86bf13"), new Guid("751939df-f0bc-4ca3-bfc6-0cddf58ec904") },
                    { new Guid("8e2c1cdc-dc12-474f-b8f2-912de6f55791"), new Guid("7efd046b-ef86-4ca2-bbd2-18ec5d86bf13"), new Guid("1d5b0136-4dab-433c-b0fb-86d6cf43b4ad") },
                    { new Guid("8ecf8c65-9dd0-4cc8-a084-7b60ca8c43ea"), new Guid("2a9f92ee-68ed-40ea-b200-ca47a7da95aa"), new Guid("ac5f10f0-c427-4429-ae85-e704f5cd6fac") },
                    { new Guid("90b334c6-0e94-4daf-a35d-aa6ad7f56089"), new Guid("06836c41-0584-4c21-9c06-4a7e68fcc23e"), new Guid("d348c45b-6b6b-4ff5-8904-4422500e0770") },
                    { new Guid("91f9d112-83c2-42a9-8f5c-bce62e82650f"), new Guid("f04a7b61-532b-45b3-8097-d6fb57387b27"), new Guid("3d564043-54ea-4715-a4a7-fbed4eb9e400") },
                    { new Guid("93ba2974-7749-47dc-884e-3d421d1f367e"), new Guid("8ad43107-9308-4a0e-bea1-7b9171182d3a"), new Guid("cb5f32c6-bbd0-4f14-8f7d-412ad5ed3db9") },
                    { new Guid("99de93fc-dec5-47d8-aff3-41ffc3eec503"), new Guid("cfeea6f1-6515-46d6-9079-fea8adcf72d2"), new Guid("719a8296-dbf8-4c89-8122-2b83e67b7846") },
                    { new Guid("9e0e17a0-6679-4b55-834e-5d7e719ff030"), new Guid("6152e7a4-f418-4007-9fbe-74927516be03"), new Guid("e273116b-7b3c-4aa8-a378-e202c6e5e155") },
                    { new Guid("a26eca4d-afff-4a40-8120-d063dbdec33c"), new Guid("0de000da-fbae-48c5-bbf6-b421d267e460"), new Guid("95ba798a-44e8-46c9-bd3a-e5128b1c8a40") },
                    { new Guid("a35c1795-e04c-4b6a-92c6-e104f67a5c0d"), new Guid("0de000da-fbae-48c5-bbf6-b421d267e460"), new Guid("e1fa81db-bd02-4337-98ff-fbf2aed996dd") },
                    { new Guid("a512055f-9d76-4e33-8411-07bcf8c4e618"), new Guid("06836c41-0584-4c21-9c06-4a7e68fcc23e"), new Guid("665f695e-2fd3-4385-864b-6293e197ae19") },
                    { new Guid("a79ecc15-c8eb-4647-ab75-106b617d4e93"), new Guid("2fb9c2e9-0a9f-41bd-9838-63b0f5657b1f"), new Guid("fab9a81f-3071-45ba-9a25-2f995db80b98") },
                    { new Guid("b029d7d5-57af-4cd1-934f-2bff76f8a13a"), new Guid("79a16664-a48a-4ac1-903d-3a2e05c64195"), new Guid("3fa14225-2188-43bb-9eac-e4934a5917f9") },
                    { new Guid("b3bd9e58-bb2a-4bc5-aa34-083a508530d7"), new Guid("3a8ff3b8-8703-4f55-ae2c-3df3044df02e"), new Guid("990152ea-c2d7-4777-b515-6dcdae957d27") },
                    { new Guid("b78be876-d961-474a-8c75-98d7c7f12f96"), new Guid("06836c41-0584-4c21-9c06-4a7e68fcc23e"), new Guid("f4f63690-d580-4f3e-bb11-946b911c6afa") },
                    { new Guid("b7ee8f00-1320-4faf-a3cf-b12837c5442d"), new Guid("08ec99c4-e1b3-4157-966d-7c2825a7fb92"), new Guid("10593677-9500-40d1-ac65-6ed324722749") },
                    { new Guid("bcab9ca3-7bce-462c-872f-6725b0fcc1b2"), new Guid("b315aa2f-acf3-4576-967c-c3b2f671767d"), new Guid("a52be8e1-21de-4a56-9392-f7cf09dfbed0") },
                    { new Guid("bd16f100-ca62-49db-ad78-8b478f3eeff1"), new Guid("2fb9c2e9-0a9f-41bd-9838-63b0f5657b1f"), new Guid("b8c0ac2c-2abc-481a-91f2-2a272a575b7c") },
                    { new Guid("bdfa31e4-595c-42a1-9ba8-e3c221b1ef2e"), new Guid("08ec99c4-e1b3-4157-966d-7c2825a7fb92"), new Guid("0c698d00-5d5d-43a2-89a4-6a4952ae0255") },
                    { new Guid("bfbbcbad-727d-49b7-9435-797d8df747fe"), new Guid("79a16664-a48a-4ac1-903d-3a2e05c64195"), new Guid("0ba473ca-dd48-4b3a-b22b-3b8bdeb7fb2f") },
                    { new Guid("c437d306-03d1-4f8b-b0e4-9bbe1ac6f880"), new Guid("cfeea6f1-6515-46d6-9079-fea8adcf72d2"), new Guid("3e21c2dd-2c08-4878-8a44-f88f48accc62") },
                    { new Guid("c708b46d-0ccc-4dc7-ac4e-06ac637ddcc2"), new Guid("3a8ff3b8-8703-4f55-ae2c-3df3044df02e"), new Guid("1653f6b8-5a6c-40d9-862e-20df5fa4c321") },
                    { new Guid("c94752a5-1a5f-477c-bd8a-3005118e81ed"), new Guid("e4e21532-797f-4cee-b5fd-55697e63ac13"), new Guid("f0666bc6-2925-4c55-9701-dc2f15d5fad7") },
                    { new Guid("cf0b9f26-7c09-4bf5-b431-41fe42244f1b"), new Guid("3a8ff3b8-8703-4f55-ae2c-3df3044df02e"), new Guid("cb1a0410-a118-4566-a1ba-8d995ada5c72") },
                    { new Guid("cf7ad12d-37e6-47b9-8175-4dbfc677bb04"), new Guid("08ec99c4-e1b3-4157-966d-7c2825a7fb92"), new Guid("511958e9-16ff-4fe0-bda1-1184f46629dc") },
                    { new Guid("d1fe5dd6-ec5d-4ada-8072-668ec2a7b8c3"), new Guid("f04a7b61-532b-45b3-8097-d6fb57387b27"), new Guid("6e549914-485a-4edb-9965-87febc13a61a") },
                    { new Guid("d984ceb1-4662-429e-a0b3-566e5aa6f8b0"), new Guid("a3b185c8-59de-4f9c-a16b-e7f7b5d3d9f5"), new Guid("5ca3d464-fa79-4ae0-96cb-3ddb54eb5aae") },
                    { new Guid("da24cd1b-7c2b-4eb8-8fb5-718415cad32b"), new Guid("0de000da-fbae-48c5-bbf6-b421d267e460"), new Guid("e43e848f-e975-4afa-95b4-02a17228148c") },
                    { new Guid("e2a6b9ba-9de9-4a4d-a4af-359681274b5c"), new Guid("08ec99c4-e1b3-4157-966d-7c2825a7fb92"), new Guid("1f04836f-dd88-4d66-a991-bca383acd102") },
                    { new Guid("e63e3dd4-0f9c-4981-86cb-6986a0633d80"), new Guid("c430d0ed-18b6-4311-bf47-1f0a47069eae"), new Guid("0bf4b615-ec32-47e8-8171-40df971a7808") },
                    { new Guid("e8a71430-7ce7-41a5-886e-abf7a9e34b2d"), new Guid("f04a7b61-532b-45b3-8097-d6fb57387b27"), new Guid("6cfb2bc8-1e90-4673-8628-f7ecea2d45a5") },
                    { new Guid("eb79ae86-fd5c-45a5-bd95-616cc35770ab"), new Guid("08ec99c4-e1b3-4157-966d-7c2825a7fb92"), new Guid("9a73d8f0-6a4c-44f8-b051-56d3128dd691") },
                    { new Guid("eedb2b9f-a744-49b8-989d-92917de9153d"), new Guid("19bc32de-bd8f-4e5a-8c94-8b9222dc82c9"), new Guid("a626e075-d677-4c4f-beef-eaf72bff7336") },
                    { new Guid("f3da43bf-54ae-4fb8-9a0b-b464725942d9"), new Guid("b315aa2f-acf3-4576-967c-c3b2f671767d"), new Guid("c6d3403e-b749-4103-af92-cd06fc0356bf") },
                    { new Guid("f606f647-7f39-47f9-a54f-1f2bb8badda1"), new Guid("0de000da-fbae-48c5-bbf6-b421d267e460"), new Guid("9bc8bf0d-869f-43e4-a4e3-e9320830bcde") },
                    { new Guid("f8ac317a-7495-4a64-9b53-eb0d83011a10"), new Guid("2b4418a4-4447-45a5-8631-713985a87d44"), new Guid("b86bf4e7-99d8-44d6-8dad-0fb482fbc269") }
                });

            migrationBuilder.InsertData(
                table: "UserPerformanceSummaries",
                columns: new[] { "Id", "CorrectAnswers", "CreatedAt", "LastUpdatedAt", "SuccessRate", "TopicId", "TotalQuestionsAnswered", "UserId" },
                values: new object[,]
                {
                    { new Guid("244fa504-668a-420e-9127-5787f453e78a"), 47, new DateTime(2025, 7, 29, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3228), new DateTime(2025, 8, 4, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3228), 97.920000000000002, new Guid("3ec5c0d5-2b91-4755-9881-ec3fed43ce8f"), 48, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("25ee5e68-267c-4f82-b857-14c6013adf55"), 21, new DateTime(2025, 7, 16, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3222), new DateTime(2025, 7, 31, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3222), 56.759999999999998, new Guid("f04a7b61-532b-45b3-8097-d6fb57387b27"), 37, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("28e6430f-ab06-4a0b-8b92-384eb08aa100"), 34, new DateTime(2025, 7, 18, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3216), new DateTime(2025, 7, 31, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3217), 44.740000000000002, new Guid("c430d0ed-18b6-4311-bf47-1f0a47069eae"), 76, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("30a3d3ad-ecdd-4f3c-803d-83a6b568f0c6"), 28, new DateTime(2025, 7, 27, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3219), new DateTime(2025, 8, 6, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3219), 75.680000000000007, new Guid("3ec5c0d5-2b91-4755-9881-ec3fed43ce8f"), 37, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("40f354b0-3efd-4920-8119-1e0f07273e23"), 31, new DateTime(2025, 7, 23, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3207), new DateTime(2025, 7, 31, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3207), 79.489999999999995, new Guid("cfeea6f1-6515-46d6-9079-fea8adcf72d2"), 39, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("520338fe-4289-407c-9514-41be6e880994"), 25, new DateTime(2025, 8, 1, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3218), new DateTime(2025, 8, 3, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3218), 38.460000000000001, new Guid("cfeea6f1-6515-46d6-9079-fea8adcf72d2"), 65, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("6dae36cc-7ffa-4543-8dca-60a0a7f59594"), 21, new DateTime(2025, 7, 27, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3212), new DateTime(2025, 8, 5, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3212), 25.0, new Guid("19bc32de-bd8f-4e5a-8c94-8b9222dc82c9"), 84, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("8f64c658-20c1-4cc3-92e2-ebfe43b611bc"), 9, new DateTime(2025, 7, 30, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3209), new DateTime(2025, 8, 2, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3209), 69.230000000000004, new Guid("3ec5c0d5-2b91-4755-9881-ec3fed43ce8f"), 13, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("96755b66-3b03-423f-a44d-04d3cd08b131"), 13, new DateTime(2025, 7, 8, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3220), new DateTime(2025, 8, 5, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3221), 38.240000000000002, new Guid("19bc32de-bd8f-4e5a-8c94-8b9222dc82c9"), 34, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("9cbf0832-7925-4a2c-bc4a-ff96380ee9c7"), 17, new DateTime(2025, 7, 27, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3229), new DateTime(2025, 7, 31, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3229), 22.670000000000002, new Guid("19bc32de-bd8f-4e5a-8c94-8b9222dc82c9"), 75, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("a97d2b29-2748-4370-9d07-fa8a906f549e"), 40, new DateTime(2025, 8, 1, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3226), new DateTime(2025, 8, 1, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3226), 72.730000000000004, new Guid("cfeea6f1-6515-46d6-9079-fea8adcf72d2"), 55, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("aa90c237-a0ee-42c9-834d-2aa6a6921478"), 80, new DateTime(2025, 7, 21, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3224), new DateTime(2025, 8, 2, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3224), 96.390000000000001, new Guid("c430d0ed-18b6-4311-bf47-1f0a47069eae"), 83, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("ade69644-a561-4fb4-a819-c79b87e7f90f"), 66, new DateTime(2025, 7, 19, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3230), new DateTime(2025, 8, 2, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3230), 72.530000000000001, new Guid("f04a7b61-532b-45b3-8097-d6fb57387b27"), 91, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("df044e66-dae8-4ca2-aadd-c704416d85d6"), 10, new DateTime(2025, 7, 22, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3197), new DateTime(2025, 8, 5, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3204), 18.870000000000001, new Guid("c430d0ed-18b6-4311-bf47-1f0a47069eae"), 53, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("e4d34473-1ea9-41b3-903c-94d022706f0d"), 57, new DateTime(2025, 7, 8, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3213), new DateTime(2025, 8, 2, 13, 56, 38, 416, DateTimeKind.Utc).AddTicks(3214), 89.060000000000002, new Guid("f04a7b61-532b-45b3-8097-d6fb57387b27"), 64, new Guid("11111111-1111-1111-1111-111111111111") }
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
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
