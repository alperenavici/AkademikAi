using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace AkademikAi.Data.Seed
{
    public static class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Topics seed data - önce ana konular, sonra alt konular
            var allTopics = GetTopics();
            var rootTopics = allTopics.Where(t => t.ParentTopicId == Guid.Empty).ToList();
            var subTopics = allTopics.Where(t => t.ParentTopicId != Guid.Empty).ToList();
            
            modelBuilder.Entity<Topics>().HasData(rootTopics);
            modelBuilder.Entity<Topics>().HasData(subTopics);

            // Questions seed data
            var questions = GetQuestions();
            modelBuilder.Entity<Questions>().HasData(questions);

            // QuestionsOptions seed data
            var questionOptions = GetQuestionOptions(questions);
            modelBuilder.Entity<QuestionsOptions>().HasData(questionOptions);

            // QuestionsTopic seed data
            var questionsTopics = GetQuestionsTopics(questions, allTopics);
            modelBuilder.Entity<QuestionsTopic>().HasData(questionsTopics);
        }

        private static List<Topics> GetTopics()
        {
            return new List<Topics>
            {
                // Ana konular
                new Topics
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    TopicName = "Matematik",
                    ParentTopicId = null
                },
                new Topics
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    TopicName = "Fizik",
                    ParentTopicId = null
                },
                new Topics
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    TopicName = "Kimya",
                    ParentTopicId = null
                },
                new Topics
                {
                    Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                    TopicName = "Biyoloji",
                    ParentTopicId = null
                },
                new Topics
                {
                    Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                    TopicName = "Türkçe",
                    ParentTopicId = null
                },
                new Topics
                {
                    Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                    TopicName = "Tarih",
                    ParentTopicId = null
                }
            };
        }

        private static List<Questions> GetQuestions()
        {
            return new List<Questions>
            {
                new Questions
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    QuestionText = "2x + 5 = 13 denklemini çözünüz.",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "Matematik Kitabı",
                    IsActive = true,
                    SolutionText = "2x + 5 = 13\n2x = 13 - 5\n2x = 8\nx = 4",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    QuestionText = "Bir üçgenin iç açıları toplamı kaç derecedir?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "Geometri Kitabı",
                    IsActive = true,
                    SolutionText = "Bir üçgenin iç açıları toplamı 180 derecedir.",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    QuestionText = "x² - 4x + 4 = 0 denkleminin çözümü nedir?",
                    DifficultyLevel = QuestionsDiff.medium,
                    Source = "Matematik Kitabı",
                    IsActive = true,
                    SolutionText = "x² - 4x + 4 = 0\n(x - 2)² = 0\nx = 2",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    QuestionText = "Bir dairenin alanı πr² formülü ile hesaplanır. Yarıçapı 5 cm olan dairenin alanı kaç cm²'dir?",
                    DifficultyLevel = QuestionsDiff.medium,
                    Source = "Geometri Kitabı",
                    IsActive = true,
                    SolutionText = "A = πr²\nA = π × 5²\nA = 25π cm²",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    QuestionText = "sin(30°) değeri kaçtır?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "Trigonometri Kitabı",
                    IsActive = true,
                    SolutionText = "sin(30°) = 1/2 = 0.5",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    QuestionText = "Newton'un birinci yasası nedir?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "Fizik Kitabı",
                    IsActive = true,
                    SolutionText = "Bir cisme etki eden net kuvvet sıfır ise, cisim durumunu korur (durgun kalır veya sabit hızla hareket eder).",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    QuestionText = "F = ma formülünde F, m ve a neyi temsil eder?",
                    DifficultyLevel = QuestionsDiff.medium,
                    Source = "Fizik Kitabı",
                    IsActive = true,
                    SolutionText = "F: Kuvvet (Newton), m: Kütle (kg), a: İvme (m/s²)",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    QuestionText = "Bir cismin kinetik enerjisi hangi formülle hesaplanır?",
                    DifficultyLevel = QuestionsDiff.medium,
                    Source = "Fizik Kitabı",
                    IsActive = true,
                    SolutionText = "Kinetik enerji = 1/2 × m × v²",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    QuestionText = "Suyun kimyasal formülü nedir?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "Kimya Kitabı",
                    IsActive = true,
                    SolutionText = "H₂O",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    QuestionText = "pH değeri 7'den küçük olan çözeltiler nasıl adlandırılır?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "Kimya Kitabı",
                    IsActive = true,
                    SolutionText = "Asidik çözeltiler",
                    GeneratedForUserId = null
                }
            };
        }

        private static List<QuestionsOptions> GetQuestionOptions(List<Questions> questions)
        {
            var options = new List<QuestionsOptions>();

            foreach (var question in questions)
            {
                switch (question.Id.ToString())
                {
                    case "11111111-1111-1111-1111-111111111111": // 2x + 5 = 13
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.Parse("11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), QuestionId = question.Id, OptionText = "3", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.Parse("11111111-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), QuestionId = question.Id, OptionText = "4", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.Parse("11111111-cccc-cccc-cccc-cccccccccccc"), QuestionId = question.Id, OptionText = "5", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.Parse("11111111-dddd-dddd-dddd-dddddddddddd"), QuestionId = question.Id, OptionText = "6", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "22222222-2222-2222-2222-222222222222": // Üçgen iç açıları
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.Parse("22222222-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), QuestionId = question.Id, OptionText = "90", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.Parse("22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), QuestionId = question.Id, OptionText = "180", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.Parse("22222222-cccc-cccc-cccc-cccccccccccc"), QuestionId = question.Id, OptionText = "270", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.Parse("22222222-dddd-dddd-dddd-dddddddddddd"), QuestionId = question.Id, OptionText = "360", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "33333333-3333-3333-3333-333333333333": // x² - 4x + 4 = 0
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.Parse("33333333-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), QuestionId = question.Id, OptionText = "1", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.Parse("33333333-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), QuestionId = question.Id, OptionText = "2", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.Parse("33333333-cccc-cccc-cccc-cccccccccccc"), QuestionId = question.Id, OptionText = "3", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.Parse("33333333-dddd-dddd-dddd-dddddddddddd"), QuestionId = question.Id, OptionText = "4", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "44444444-4444-4444-4444-444444444444": // Daire alanı
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.Parse("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), QuestionId = question.Id, OptionText = "20π", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.Parse("44444444-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), QuestionId = question.Id, OptionText = "25π", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.Parse("44444444-cccc-cccc-cccc-cccccccccccc"), QuestionId = question.Id, OptionText = "30π", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.Parse("44444444-dddd-dddd-dddd-dddddddddddd"), QuestionId = question.Id, OptionText = "35π", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "55555555-5555-5555-5555-555555555555": // sin(30°)
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.Parse("55555555-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), QuestionId = question.Id, OptionText = "0.25", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.Parse("55555555-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), QuestionId = question.Id, OptionText = "0.5", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.Parse("55555555-cccc-cccc-cccc-cccccccccccc"), QuestionId = question.Id, OptionText = "0.75", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.Parse("55555555-dddd-dddd-dddd-dddddddddddd"), QuestionId = question.Id, OptionText = "1", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "66666666-6666-6666-6666-666666666666": // Newton'un birinci yasası
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.Parse("66666666-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), QuestionId = question.Id, OptionText = "Eylemsizlik yasası", Label = 'A', IsCorrect = true, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.Parse("66666666-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), QuestionId = question.Id, OptionText = "Dinamik yasası", Label = 'B', IsCorrect = false, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.Parse("66666666-cccc-cccc-cccc-cccccccccccc"), QuestionId = question.Id, OptionText = "Statik yasası", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.Parse("66666666-dddd-dddd-dddd-dddddddddddd"), QuestionId = question.Id, OptionText = "Kinetik yasası", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "77777777-7777-7777-7777-777777777777": // F = ma
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.Parse("77777777-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), QuestionId = question.Id, OptionText = "Kuvvet = Kütle × Hız", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.Parse("77777777-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), QuestionId = question.Id, OptionText = "Kuvvet = Kütle × İvme", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.Parse("77777777-cccc-cccc-cccc-cccccccccccc"), QuestionId = question.Id, OptionText = "Kuvvet = Kütle × Zaman", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.Parse("77777777-dddd-dddd-dddd-dddddddddddd"), QuestionId = question.Id, OptionText = "Kuvvet = Kütle × Mesafe", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "88888888-8888-8888-8888-888888888888": // Kinetik enerji
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.Parse("88888888-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), QuestionId = question.Id, OptionText = "m × v", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.Parse("88888888-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), QuestionId = question.Id, OptionText = "1/2 × m × v²", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.Parse("88888888-cccc-cccc-cccc-cccccccccccc"), QuestionId = question.Id, OptionText = "m × v²", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.Parse("88888888-dddd-dddd-dddd-dddddddddddd"), QuestionId = question.Id, OptionText = "2 × m × v", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "99999999-9999-9999-9999-999999999999": // Su formülü
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.Parse("99999999-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), QuestionId = question.Id, OptionText = "CO₂", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.Parse("99999999-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), QuestionId = question.Id, OptionText = "H₂O", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.Parse("99999999-cccc-cccc-cccc-cccccccccccc"), QuestionId = question.Id, OptionText = "O₂", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.Parse("99999999-dddd-dddd-dddd-dddddddddddd"), QuestionId = question.Id, OptionText = "N₂", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa": // pH değeri
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), QuestionId = question.Id, OptionText = "Bazik", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.Parse("aaaaaaaa-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), QuestionId = question.Id, OptionText = "Asidik", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.Parse("aaaaaaaa-cccc-cccc-cccc-cccccccccccc"), QuestionId = question.Id, OptionText = "Nötr", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.Parse("aaaaaaaa-dddd-dddd-dddd-dddddddddddd"), QuestionId = question.Id, OptionText = "Amfoter", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;
                }
            }

            return options;
        }

        private static List<QuestionsTopic> GetQuestionsTopics(List<Questions> questions, List<Topics> topics)
        {
            var questionsTopics = new List<QuestionsTopic>();

            // Matematik soruları
            var mathTopic = topics.First(t => t.TopicName == "Matematik");
            var mathQuestions = questions.Take(5).ToList();

            questionsTopics.Add(new QuestionsTopic
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                QuestionId = mathQuestions[0].Id,
                TopicId = mathTopic.Id
            });
            questionsTopics.Add(new QuestionsTopic
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                QuestionId = mathQuestions[1].Id,
                TopicId = mathTopic.Id
            });
            questionsTopics.Add(new QuestionsTopic
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                QuestionId = mathQuestions[2].Id,
                TopicId = mathTopic.Id
            });
            questionsTopics.Add(new QuestionsTopic
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                QuestionId = mathQuestions[3].Id,
                TopicId = mathTopic.Id
            });
            questionsTopics.Add(new QuestionsTopic
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                QuestionId = mathQuestions[4].Id,
                TopicId = mathTopic.Id
            });

            // Fizik soruları
            var physicsTopic = topics.First(t => t.TopicName == "Fizik");
            var physicsQuestions = questions.Skip(5).Take(3).ToList();

            questionsTopics.Add(new QuestionsTopic
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                QuestionId = physicsQuestions[0].Id,
                TopicId = physicsTopic.Id
            });
            questionsTopics.Add(new QuestionsTopic
            {
                Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                QuestionId = physicsQuestions[1].Id,
                TopicId = physicsTopic.Id
            });
            questionsTopics.Add(new QuestionsTopic
            {
                Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                QuestionId = physicsQuestions[2].Id,
                TopicId = physicsTopic.Id
            });

            // Kimya soruları
            var chemistryQuestions = questions.Skip(8).Take(2).ToList();
            var chemistryTopic = topics.First(t => t.TopicName == "Kimya");

            questionsTopics.Add(new QuestionsTopic
            {
                Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                QuestionId = chemistryQuestions[0].Id,
                TopicId = chemistryTopic.Id
            });
            questionsTopics.Add(new QuestionsTopic
            {
                Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                QuestionId = chemistryQuestions[1].Id,
                TopicId = chemistryTopic.Id
            });

            return questionsTopics;
        }
    }
} 