using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AkademikAi.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("55555555-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("55555555-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("55555555-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("55555555-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("66666666-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("66666666-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("66666666-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("66666666-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("77777777-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("77777777-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("77777777-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("77777777-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("88888888-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("88888888-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("88888888-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("88888888-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("99999999-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("99999999-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("99999999-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("99999999-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("77777777-7777-7777-7777-777777777777"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("99999999-9999-9999-9999-999999999999"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") });

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevel", "GeneratedForUserId", "IsActive", "QuestionText", "SolutionText", "Source" },
                values: new object[,]
                {
                    { new Guid("11111111-7777-7777-7777-777777777777"), 1, null, true, "F = ma formülünde F, m ve a neyi temsil eder?", "F: Kuvvet (Newton), m: Kütle (kg), a: İvme (m/s²)", "Fizik Kitabı" },
                    { new Guid("22222222-8888-8888-8888-888888888888"), 1, null, true, "Bir cismin kinetik enerjisi hangi formülle hesaplanır?", "Kinetik enerji = 1/2 × m × v²", "Fizik Kitabı" },
                    { new Guid("33333333-9999-9999-9999-999999999999"), 0, null, true, "Suyun kimyasal formülü nedir?", "H₂O", "Kimya Kitabı" },
                    { new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 0, null, true, "pH değeri 7'den küçük olan çözeltiler nasıl adlandırılır?", "Asidik çözeltiler", "Kimya Kitabı" },
                    { new Guid("aaaaaaaa-1111-1111-1111-111111111111"), 0, null, true, "2x + 5 = 13 denklemini çözünüz.", "2x + 5 = 13\n2x = 13 - 5\n2x = 8\nx = 4", "Matematik Kitabı" },
                    { new Guid("bbbbbbbb-2222-2222-2222-222222222222"), 0, null, true, "Bir üçgenin iç açıları toplamı kaç derecedir?", "Bir üçgenin iç açıları toplamı 180 derecedir.", "Geometri Kitabı" },
                    { new Guid("cccccccc-3333-3333-3333-333333333333"), 1, null, true, "x² - 4x + 4 = 0 denkleminin çözümü nedir?", "x² - 4x + 4 = 0\n(x - 2)² = 0\nx = 2", "Matematik Kitabı" },
                    { new Guid("dddddddd-4444-4444-4444-444444444444"), 1, null, true, "Bir dairenin alanı πr² formülü ile hesaplanır. Yarıçapı 5 cm olan dairenin alanı kaç cm²'dir?", "A = πr²\nA = π × 5²\nA = 25π cm²", "Geometri Kitabı" },
                    { new Guid("eeeeeeee-5555-5555-5555-555555555555"), 0, null, true, "sin(30°) değeri kaçtır?", "sin(30°) = 1/2 = 0.5", "Trigonometri Kitabı" },
                    { new Guid("ffffffff-6666-6666-6666-666666666666"), 0, null, true, "Newton'un birinci yasası nedir?", "Bir cisme etki eden net kuvvet sıfır ise, cisim durumunu korur (durgun kalır veya sabit hızla hareket eder).", "Fizik Kitabı" }
                });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Kuvvet = Kütle × Hız", new Guid("11111111-7777-7777-7777-777777777777") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Kuvvet = Kütle × İvme", new Guid("11111111-7777-7777-7777-777777777777") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Kuvvet = Kütle × Zaman", new Guid("11111111-7777-7777-7777-777777777777") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Kuvvet = Kütle × Mesafe", new Guid("11111111-7777-7777-7777-777777777777") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "m × v", new Guid("22222222-8888-8888-8888-888888888888") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "1/2 × m × v²", new Guid("22222222-8888-8888-8888-888888888888") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "m × v²", new Guid("22222222-8888-8888-8888-888888888888") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "2 × m × v", new Guid("22222222-8888-8888-8888-888888888888") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "CO₂", new Guid("33333333-9999-9999-9999-999999999999") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "H₂O", new Guid("33333333-9999-9999-9999-999999999999") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "O₂", new Guid("33333333-9999-9999-9999-999999999999") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "N₂", new Guid("33333333-9999-9999-9999-999999999999") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Bazik", new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Asidik", new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Nötr", new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Amfoter", new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "3", new Guid("aaaaaaaa-1111-1111-1111-111111111111") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "4", new Guid("aaaaaaaa-1111-1111-1111-111111111111") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "5", new Guid("aaaaaaaa-1111-1111-1111-111111111111") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "6", new Guid("aaaaaaaa-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "ParentTopicId", "TopicName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Cebir" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Geometri" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Trigonometri" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Mekanik" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Elektrik" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "Organik Kimya" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "İnorganik Kimya" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "IsCorrect", "Label", "OptionOrder", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 'A', 1, "90", new Guid("bbbbbbbb-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, 'B', 2, "180", new Guid("bbbbbbbb-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-cccc-cccc-cccc-cccccccccccc"), false, 'C', 3, "270", new Guid("bbbbbbbb-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-dddd-dddd-dddd-dddddddddddd"), false, 'D', 4, "360", new Guid("bbbbbbbb-2222-2222-2222-222222222222") },
                    { new Guid("cccccccc-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 'A', 1, "1", new Guid("cccccccc-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, 'B', 2, "2", new Guid("cccccccc-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), false, 'C', 3, "3", new Guid("cccccccc-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-dddd-dddd-dddd-dddddddddddd"), false, 'D', 4, "4", new Guid("cccccccc-3333-3333-3333-333333333333") },
                    { new Guid("dddddddd-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 'A', 1, "20π", new Guid("dddddddd-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, 'B', 2, "25π", new Guid("dddddddd-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-cccc-cccc-cccc-cccccccccccc"), false, 'C', 3, "30π", new Guid("dddddddd-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), false, 'D', 4, "35π", new Guid("dddddddd-4444-4444-4444-444444444444") },
                    { new Guid("eeeeeeee-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 'A', 1, "0.25", new Guid("eeeeeeee-5555-5555-5555-555555555555") },
                    { new Guid("eeeeeeee-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, 'B', 2, "0.5", new Guid("eeeeeeee-5555-5555-5555-555555555555") },
                    { new Guid("eeeeeeee-cccc-cccc-cccc-cccccccccccc"), false, 'C', 3, "0.75", new Guid("eeeeeeee-5555-5555-5555-555555555555") },
                    { new Guid("eeeeeeee-dddd-dddd-dddd-dddddddddddd"), false, 'D', 4, "1", new Guid("eeeeeeee-5555-5555-5555-555555555555") },
                    { new Guid("ffffffff-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, 'A', 1, "Eylemsizlik yasası", new Guid("ffffffff-6666-6666-6666-666666666666") },
                    { new Guid("ffffffff-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), false, 'B', 2, "Dinamik yasası", new Guid("ffffffff-6666-6666-6666-666666666666") },
                    { new Guid("ffffffff-cccc-cccc-cccc-cccccccccccc"), false, 'C', 3, "Statik yasası", new Guid("ffffffff-6666-6666-6666-666666666666") },
                    { new Guid("ffffffff-dddd-dddd-dddd-dddddddddddd"), false, 'D', 4, "Kinetik yasası", new Guid("ffffffff-6666-6666-6666-666666666666") }
                });

            migrationBuilder.InsertData(
                table: "QuestionsTopics",
                columns: new[] { "QuestionId", "TopicId", "Id" },
                values: new object[,]
                {
                    { new Guid("11111111-7777-7777-7777-777777777777"), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("dddddddd-2222-2222-2222-222222222222") },
                    { new Guid("11111111-7777-7777-7777-777777777777"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("cccccccc-2222-2222-2222-222222222222") },
                    { new Guid("22222222-8888-8888-8888-888888888888"), new Guid("55555555-5555-5555-5555-555555555555"), new Guid("dddddddd-3333-3333-3333-333333333333") },
                    { new Guid("22222222-8888-8888-8888-888888888888"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("cccccccc-3333-3333-3333-333333333333") },
                    { new Guid("33333333-9999-9999-9999-999999999999"), new Guid("66666666-6666-6666-6666-666666666666"), new Guid("eeeeeeee-3333-3333-3333-333333333333") },
                    { new Guid("33333333-9999-9999-9999-999999999999"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("eeeeeeee-1111-1111-1111-111111111111") },
                    { new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("77777777-7777-7777-7777-777777777777"), new Guid("eeeeeeee-4444-4444-4444-444444444444") },
                    { new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("eeeeeeee-2222-2222-2222-222222222222") },
                    { new Guid("aaaaaaaa-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("bbbbbbbb-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-1111-1111-111111111111"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("aaaaaaaa-1111-1111-1111-111111111111") },
                    { new Guid("bbbbbbbb-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("bbbbbbbb-3333-3333-3333-333333333333") },
                    { new Guid("bbbbbbbb-2222-2222-2222-222222222222"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("aaaaaaaa-2222-2222-2222-222222222222") },
                    { new Guid("cccccccc-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("bbbbbbbb-2222-2222-2222-222222222222") },
                    { new Guid("cccccccc-3333-3333-3333-333333333333"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("aaaaaaaa-3333-3333-3333-333333333333") },
                    { new Guid("dddddddd-4444-4444-4444-444444444444"), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("bbbbbbbb-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-4444-4444-4444-444444444444"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("aaaaaaaa-4444-4444-4444-444444444444") },
                    { new Guid("eeeeeeee-5555-5555-5555-555555555555"), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("bbbbbbbb-5555-5555-5555-555555555555") },
                    { new Guid("eeeeeeee-5555-5555-5555-555555555555"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("aaaaaaaa-5555-5555-5555-555555555555") },
                    { new Guid("ffffffff-6666-6666-6666-666666666666"), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("dddddddd-1111-1111-1111-111111111111") },
                    { new Guid("ffffffff-6666-6666-6666-666666666666"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("cccccccc-1111-1111-1111-111111111111") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("11111111-7777-7777-7777-777777777777"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("11111111-7777-7777-7777-777777777777"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("22222222-8888-8888-8888-888888888888"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("22222222-8888-8888-8888-888888888888"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("33333333-9999-9999-9999-999999999999"), new Guid("66666666-6666-6666-6666-666666666666") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("33333333-9999-9999-9999-999999999999"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("aaaaaaaa-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("aaaaaaaa-1111-1111-1111-111111111111"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("bbbbbbbb-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("bbbbbbbb-2222-2222-2222-222222222222"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("cccccccc-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("cccccccc-3333-3333-3333-333333333333"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("dddddddd-4444-4444-4444-444444444444"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("dddddddd-4444-4444-4444-444444444444"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("eeeeeeee-5555-5555-5555-555555555555"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("eeeeeeee-5555-5555-5555-555555555555"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("ffffffff-6666-6666-6666-666666666666"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "QuestionsTopics",
                keyColumns: new[] { "QuestionId", "TopicId" },
                keyValues: new object[] { new Guid("ffffffff-6666-6666-6666-666666666666"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevel", "GeneratedForUserId", "IsActive", "QuestionText", "SolutionText", "Source" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, null, true, "2x + 5 = 13 denklemini çözünüz.", "2x + 5 = 13\n2x = 13 - 5\n2x = 8\nx = 4", "Matematik Kitabı" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, null, true, "Bir üçgenin iç açıları toplamı kaç derecedir?", "Bir üçgenin iç açıları toplamı 180 derecedir.", "Geometri Kitabı" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 1, null, true, "x² - 4x + 4 = 0 denkleminin çözümü nedir?", "x² - 4x + 4 = 0\n(x - 2)² = 0\nx = 2", "Matematik Kitabı" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), 1, null, true, "Bir dairenin alanı πr² formülü ile hesaplanır. Yarıçapı 5 cm olan dairenin alanı kaç cm²'dir?", "A = πr²\nA = π × 5²\nA = 25π cm²", "Geometri Kitabı" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), 0, null, true, "sin(30°) değeri kaçtır?", "sin(30°) = 1/2 = 0.5", "Trigonometri Kitabı" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), 0, null, true, "Newton'un birinci yasası nedir?", "Bir cisme etki eden net kuvvet sıfır ise, cisim durumunu korur (durgun kalır veya sabit hızla hareket eder).", "Fizik Kitabı" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), 1, null, true, "F = ma formülünde F, m ve a neyi temsil eder?", "F: Kuvvet (Newton), m: Kütle (kg), a: İvme (m/s²)", "Fizik Kitabı" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), 1, null, true, "Bir cismin kinetik enerjisi hangi formülle hesaplanır?", "Kinetik enerji = 1/2 × m × v²", "Fizik Kitabı" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), 0, null, true, "Suyun kimyasal formülü nedir?", "H₂O", "Kimya Kitabı" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 0, null, true, "pH değeri 7'den küçük olan çözeltiler nasıl adlandırılır?", "Asidik çözeltiler", "Kimya Kitabı" }
                });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "3", new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "4", new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "5", new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "6", new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "90", new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "180", new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "270", new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "360", new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "1", new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "2", new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "3", new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "4", new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "20π", new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "25π", new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "30π", new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "35π", new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Bazik", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Asidik", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Nötr", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.UpdateData(
                table: "QuestionsOptions",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "OptionText", "QuestionId" },
                values: new object[] { "Amfoter", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.InsertData(
                table: "QuestionsOptions",
                columns: new[] { "Id", "IsCorrect", "Label", "OptionOrder", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("55555555-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 'A', 1, "0.25", new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("55555555-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, 'B', 2, "0.5", new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("55555555-cccc-cccc-cccc-cccccccccccc"), false, 'C', 3, "0.75", new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("55555555-dddd-dddd-dddd-dddddddddddd"), false, 'D', 4, "1", new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("66666666-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, 'A', 1, "Eylemsizlik yasası", new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("66666666-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), false, 'B', 2, "Dinamik yasası", new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("66666666-cccc-cccc-cccc-cccccccccccc"), false, 'C', 3, "Statik yasası", new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("66666666-dddd-dddd-dddd-dddddddddddd"), false, 'D', 4, "Kinetik yasası", new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("77777777-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 'A', 1, "Kuvvet = Kütle × Hız", new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("77777777-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, 'B', 2, "Kuvvet = Kütle × İvme", new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("77777777-cccc-cccc-cccc-cccccccccccc"), false, 'C', 3, "Kuvvet = Kütle × Zaman", new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("77777777-dddd-dddd-dddd-dddddddddddd"), false, 'D', 4, "Kuvvet = Kütle × Mesafe", new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("88888888-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 'A', 1, "m × v", new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("88888888-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, 'B', 2, "1/2 × m × v²", new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("88888888-cccc-cccc-cccc-cccccccccccc"), false, 'C', 3, "m × v²", new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("88888888-dddd-dddd-dddd-dddddddddddd"), false, 'D', 4, "2 × m × v", new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("99999999-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 'A', 1, "CO₂", new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("99999999-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, 'B', 2, "H₂O", new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("99999999-cccc-cccc-cccc-cccccccccccc"), false, 'C', 3, "O₂", new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("99999999-dddd-dddd-dddd-dddddddddddd"), false, 'D', 4, "N₂", new Guid("99999999-9999-9999-9999-999999999999") }
                });

            migrationBuilder.InsertData(
                table: "QuestionsTopics",
                columns: new[] { "QuestionId", "TopicId", "Id" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") }
                });
        }
    }
}
