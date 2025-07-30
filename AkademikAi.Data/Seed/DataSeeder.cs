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
            // Users seed data
            var users = GetUsers();
            modelBuilder.Entity<Users>().HasData(users);

            // Topics seed data
            var topics = GetTopics();
            modelBuilder.Entity<Topics>().HasData(topics);

            // Questions seed data
            var questions = GetQuestions(users);
            modelBuilder.Entity<Questions>().HasData(questions);

            // QuestionsOptions seed data
            var questionOptions = GetQuestionOptions(questions);
            modelBuilder.Entity<QuestionsOptions>().HasData(questionOptions);

            // QuestionsTopic seed data
            var questionsTopics = GetQuestionsTopics(questions, topics);
            modelBuilder.Entity<QuestionsTopic>().HasData(questionsTopics);

            // UserAnswers seed data
            var userAnswers = GetUserAnswers(users, questions, questionOptions);
            modelBuilder.Entity<UserAnswers>().HasData(userAnswers);

            // UserNotifications seed data
            var userNotifications = GetUserNotifications(users);
            modelBuilder.Entity<UserNotifications>().HasData(userNotifications);

            // UserPerformanceSummaries seed data
            var userPerformanceSummaries = GetUserPerformanceSummaries(users, topics);
            modelBuilder.Entity<UserPerformanceSummaries>().HasData(userPerformanceSummaries);

            // UserRecommendation seed data
            var userRecommendations = GetUserRecommendations(users, topics);
            modelBuilder.Entity<UserRecommendation>().HasData(userRecommendations);
        }

        private static List<Users> GetUsers()
        {
            return new List<Users>
            {
                new Users
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Admin",
                    Surname = "User",
                    Email = "admin@akademikai.com",
                    PasswordHash = HashPassword("admin123Aa."),
                    Phone = "5551234567",
                    UserRole = UserRole.Admin,
                    CreatedAt = DateTime.Now.AddDays(-30)
                },
                new Users
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Öğretmen",
                    Surname = "Demo",
                    Email = "ogretmen@akademikai.com",
                    PasswordHash = HashPassword("ogretmen123"),
                    Phone = "5551234568",
                    UserRole = UserRole.Teacher,
                    CreatedAt = DateTime.Now.AddDays(-25)
                },
                new Users
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Ahmet",
                    Surname = "Yılmaz",
                    Email = "ahmet@akademikai.com",
                    PasswordHash = HashPassword("ahmet123"),
                    Phone = "5551234569",
                    UserRole = UserRole.Student,
                    CreatedAt = DateTime.Now.AddDays(-20)
                },
                new Users
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Name = "Ayşe",
                    Surname = "Demir",
                    Email = "ayse@akademikai.com",
                    PasswordHash = HashPassword("ayse123"),
                    Phone = "5551234570",
                    UserRole = UserRole.Student,
                    CreatedAt = DateTime.Now.AddDays(-15)
                },
                new Users
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Name = "Mehmet",
                    Surname = "Kaya",
                    Email = "mehmet@akademikai.com",
                    PasswordHash = HashPassword("mehmet123"),
                    Phone = "5551234571",
                    UserRole = UserRole.Student,
                    CreatedAt = DateTime.Now.AddDays(-10)
                }
            };
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
                    ParentTopicId = Guid.Empty
                },
                new Topics
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    TopicName = "Fizik",
                    ParentTopicId = Guid.Empty
                },
                new Topics
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    TopicName = "Kimya",
                    ParentTopicId = Guid.Empty
                },
                new Topics
                {
                    Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                    TopicName = "Biyoloji",
                    ParentTopicId = Guid.Empty
                },
                new Topics
                {
                    Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                    TopicName = "Türkçe",
                    ParentTopicId = Guid.Empty
                },
                new Topics
                {
                    Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                    TopicName = "Tarih",
                    ParentTopicId = Guid.Empty
                },

                // Matematik alt konuları
                new Topics
                {
                    Id = Guid.Parse("11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    TopicName = "Temel Matematik",
                    ParentTopicId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")
                },
                new Topics
                {
                    Id = Guid.Parse("22222222-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    TopicName = "Cebir",
                    ParentTopicId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")
                },
                new Topics
                {
                    Id = Guid.Parse("33333333-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    TopicName = "Geometri",
                    ParentTopicId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")
                },
                new Topics
                {
                    Id = Guid.Parse("44444444-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    TopicName = "Trigonometri",
                    ParentTopicId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")
                },

                // Fizik alt konuları
                new Topics
                {
                    Id = Guid.Parse("11111111-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    TopicName = "Mekanik",
                    ParentTopicId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")
                },
                new Topics
                {
                    Id = Guid.Parse("22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    TopicName = "Elektrik",
                    ParentTopicId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")
                },
                new Topics
                {
                    Id = Guid.Parse("33333333-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    TopicName = "Optik",
                    ParentTopicId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")
                }
            };
        }

        private static List<Questions> GetQuestions(List<Users> users)
        {
            var adminUser = users.First(u => u.UserRole == UserRole.Admin);
            var teacherUser = users.First(u => u.UserRole == UserRole.Teacher);

            return new List<Questions>
            {
                // Matematik Soruları
                new Questions
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    QuestionText = "2x + 5 = 13 denkleminin çözümü nedir?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "meb",
                    IsActive = true,
                    SolutionText = "2x + 5 = 13\n2x = 13 - 5\n2x = 8\nx = 4",
                    GeneratedForUserId = adminUser.Id
                },
                new Questions
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    QuestionText = "Bir üçgenin iç açıları toplamı kaç derecedir?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "meb",
                    IsActive = true,
                    SolutionText = "Bir üçgenin iç açıları toplamı 180 derecedir.",
                    GeneratedForUserId = adminUser.Id
                },
                new Questions
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    QuestionText = "x² - 4x + 4 = 0 denkleminin çözümü nedir?",
                    DifficultyLevel = QuestionsDiff.medium,
                    Source = "meb",
                    IsActive = true,
                    SolutionText = "x² - 4x + 4 = 0\n(x - 2)² = 0\nx = 2",
                    GeneratedForUserId = teacherUser.Id
                },
                new Questions
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    QuestionText = "Bir dairenin alanı πr² formülü ile hesaplanır. Yarıçapı 5 cm olan dairenin alanı kaç cm²'dir?",
                    DifficultyLevel = QuestionsDiff.medium,
                    Source = "meb",
                    IsActive = true,
                    SolutionText = "A = πr²\nA = π × 5²\nA = 25π cm²",
                    GeneratedForUserId = teacherUser.Id
                },
                new Questions
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    QuestionText = "sin(30°) değeri kaçtır?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "meb",
                    IsActive = true,
                    SolutionText = "sin(30°) = 1/2 = 0.5",
                    GeneratedForUserId = adminUser.Id
                },

                // Fizik Soruları
                new Questions
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    QuestionText = "Newton'un birinci yasası nedir?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "meb",
                    IsActive = true,
                    SolutionText = "Bir cisme etki eden net kuvvet sıfır ise, cisim durumunu korur (durgun kalır veya sabit hızla hareket eder).",
                    GeneratedForUserId = teacherUser.Id
                },
                new Questions
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    QuestionText = "F = ma formülünde F, m ve a neyi temsil eder?",
                    DifficultyLevel = QuestionsDiff.medium,
                    Source = "meb",
                    IsActive = true,
                    SolutionText = "F: Kuvvet (Newton), m: Kütle (kg), a: İvme (m/s²)",
                    GeneratedForUserId = teacherUser.Id
                },
                new Questions
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    QuestionText = "Bir cismin kinetik enerjisi hangi formülle hesaplanır?",
                    DifficultyLevel = QuestionsDiff.medium,
                    Source = "meb",
                    IsActive = true,
                    SolutionText = "Kinetik enerji = 1/2 × m × v²",
                    GeneratedForUserId = adminUser.Id
                },

                // Kimya Soruları
                new Questions
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    QuestionText = "Suyun kimyasal formülü nedir?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "meb",
                    IsActive = true,
                    SolutionText = "H₂O",
                    GeneratedForUserId = adminUser.Id
                },
                new Questions
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    QuestionText = "pH değeri 7'den küçük olan çözeltiler nasıl adlandırılır?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "meb",
                    IsActive = true,
                    SolutionText = "Asidik çözeltiler",
                    GeneratedForUserId = teacherUser.Id
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
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "3", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "4", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "5", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "6", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "22222222-2222-2222-2222-222222222222": // Üçgen iç açıları
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "90", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "180", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "270", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "360", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "33333333-3333-3333-3333-333333333333": // x² - 4x + 4 = 0
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "1", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "2", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "3", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "4", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "44444444-4444-4444-4444-444444444444": // Daire alanı
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "20π", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "25π", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "30π", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "35π", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "55555555-5555-5555-5555-555555555555": // sin(30°)
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "0.25", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "0.5", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "0.75", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "1", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "66666666-6666-6666-6666-666666666666": // Newton'un birinci yasası
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Eylemsizlik yasası", Label = 'A', IsCorrect = true, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Dinamik yasası", Label = 'B', IsCorrect = false, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Statik yasası", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Kinetik yasası", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "77777777-7777-7777-7777-777777777777": // F = ma
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Kuvvet = Kütle × Hız", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Kuvvet = Kütle × İvme", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Kuvvet = Kütle × Zaman", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Kuvvet = Kütle × Mesafe", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "88888888-8888-8888-8888-888888888888": // Kinetik enerji
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "m × v", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "1/2 × m × v²", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "m × v²", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "2 × m × v", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "99999999-9999-9999-9999-999999999999": // Su formülü
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "CO₂", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "H₂O", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "O₂", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "N₂", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                        });
                        break;

                    case "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa": // pH değeri
                        options.AddRange(new[]
                        {
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Bazik", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Asidik", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Nötr", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                            new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = question.Id, OptionText = "Amfoter", Label = 'D', IsCorrect = false, OptionOrder = 4 }
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
            var mathTopics = topics.Where(t => t.ParentTopicId == Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")).ToList();
            var mathQuestions = questions.Take(5).ToList();

            for (int i = 0; i < mathQuestions.Count; i++)
            {
                questionsTopics.Add(new QuestionsTopic
                {
                    Id = Guid.NewGuid(),
                    QuestionId = mathQuestions[i].Id,
                    TopicId = mathTopics[i % mathTopics.Count].Id
                });
            }

            // Fizik soruları
            var physicsTopics = topics.Where(t => t.ParentTopicId == Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")).ToList();
            var physicsQuestions = questions.Skip(5).Take(3).ToList();

            for (int i = 0; i < physicsQuestions.Count; i++)
            {
                questionsTopics.Add(new QuestionsTopic
                {
                    Id = Guid.NewGuid(),
                    QuestionId = physicsQuestions[i].Id,
                    TopicId = physicsTopics[i % physicsTopics.Count].Id
                });
            }

            // Kimya soruları
            var chemistryQuestions = questions.Skip(8).Take(2).ToList();
            var chemistryTopic = topics.First(t => t.TopicName == "Kimya");

            foreach (var question in chemistryQuestions)
            {
                questionsTopics.Add(new QuestionsTopic
                {
                    Id = Guid.NewGuid(),
                    QuestionId = question.Id,
                    TopicId = chemistryTopic.Id
                });
            }

            return questionsTopics;
        }

        private static List<UserAnswers> GetUserAnswers(List<Users> users, List<Questions> questions, List<QuestionsOptions> options)
        {
            var studentUsers = users.Where(u => u.UserRole == UserRole.Student).ToList();
            var userAnswers = new List<UserAnswers>();

            foreach (var student in studentUsers)
            {
                var random = new Random(student.Id.GetHashCode());
                var studentQuestions = questions.OrderBy(x => random.Next()).Take(5).ToList();

                foreach (var question in studentQuestions)
                {
                    var questionOptions = options.Where(o => o.QuestionId == question.Id).ToList();
                    var selectedOption = questionOptions.OrderBy(x => random.Next()).First();
                    var isCorrect = selectedOption.IsCorrect;

                    userAnswers.Add(new UserAnswers
                    {
                        Id = Guid.NewGuid(),
                        UserId = student.Id,
                        QuestionId = question.Id,
                        SelectedOptionId = selectedOption.Id,
                        IsCorrect = isCorrect,
                        AnsweredAt = DateTime.Now.AddDays(-random.Next(1, 30)),
                        UserAnswer = selectedOption.Label
                    });
                }
            }

            return userAnswers;
        }

        private static List<UserNotifications> GetUserNotifications(List<Users> users)
        {
            var notifications = new List<UserNotifications>();
            var studentUsers = users.Where(u => u.UserRole == UserRole.Student).ToList();

            foreach (var student in studentUsers)
            {
                notifications.AddRange(new[]
                {
                    new UserNotifications
                    {
                        Id = Guid.NewGuid(),
                        UserId = student.Id,
                        Title = "Hoş Geldiniz!",
                        NotificationType = "welcome",
                        Message = "AkademikAI platformuna hoş geldiniz. İlk sınavınızı çözmeye başlayabilirsiniz.",
                        IsRead = false,
                        CreatedAt = DateTime.Now.AddDays(-5)
                    },
                    new UserNotifications
                    {
                        Id = Guid.NewGuid(),
                        UserId = student.Id,
                        Title = "Yeni Soru Seti",
                        NotificationType = "exam",
                        Message = "Matematik konusunda yeni soru seti eklendi. Hemen çözmeye başlayın!",
                        IsRead = true,
                        ReadAt = DateTime.Now.AddDays(-2),
                        CreatedAt = DateTime.Now.AddDays(-3)
                    },
                    new UserNotifications
                    {
                        Id = Guid.NewGuid(),
                        UserId = student.Id,
                        Title = "Performans Raporu",
                        NotificationType = "performance",
                        Message = "Bu haftaki performans raporunuz hazır. Detayları görüntüleyebilirsiniz.",
                        IsRead = false,
                        CreatedAt = DateTime.Now.AddDays(-1)
                    }
                });
            }

            return notifications;
        }

        private static List<UserPerformanceSummaries> GetUserPerformanceSummaries(List<Users> users, List<Topics> topics)
        {
            var summaries = new List<UserPerformanceSummaries>();
            var studentUsers = users.Where(u => u.UserRole == UserRole.Student).ToList();
            var mainTopics = topics.Where(t => t.ParentTopicId == Guid.Empty).Take(3).ToList();

            foreach (var student in studentUsers)
            {
                foreach (var topic in mainTopics)
                {
                    var random = new Random(student.Id.GetHashCode() + topic.Id.GetHashCode());
                    var totalQuestions = random.Next(10, 50);
                    var correctAnswers = random.Next(5, totalQuestions);
                    var successRate = (double)correctAnswers / totalQuestions * 100;

                    summaries.Add(new UserPerformanceSummaries
                    {
                        Id = Guid.NewGuid(),
                        UserId = student.Id,
                        TopicId = topic.Id,
                        TotalAnsweredQuestions = totalQuestions,
                        TotalQuestionsAnswered = totalQuestions,
                        CorrectAnswers = correctAnswers,
                        SuccessRate = Math.Round(successRate, 2),
                        CreatedAt = DateTime.Now.AddDays(-random.Next(1, 30)),
                        LastUpdatedAt = DateTime.Now.AddDays(-random.Next(1, 7))
                    });
                }
            }

            return summaries;
        }

        private static List<UserRecommendation> GetUserRecommendations(List<Users> users, List<Topics> topics)
        {
            var recommendations = new List<UserRecommendation>();
            var studentUsers = users.Where(u => u.UserRole == UserRole.Student).ToList();
            var mainTopics = topics.Where(t => t.ParentTopicId == Guid.Empty).Take(3).ToList();

            foreach (var student in studentUsers)
            {
                foreach (var topic in mainTopics)
                {
                    var random = new Random(student.Id.GetHashCode() + topic.Id.GetHashCode());
                    var recommendationType = random.Next(0, 3);

                    string recommendationText = "";
                    string description = "";

                    switch (recommendationType)
                    {
                        case 0: // test
                            recommendationText = $"{topic.TopicName} konusunda test çözün";
                            description = $"Bu konuda daha fazla pratik yapmanız gerekiyor. En az 20 soru çözün.";
                            break;
                        case 1: // sınav
                            recommendationText = $"{topic.TopicName} konusunda sınav hazırlığı yapın";
                            description = $"Bu konuda sınav performansınızı artırmak için konu tekrarı yapın.";
                            break;
                        case 2: // konu tekrarı
                            recommendationText = $"{topic.TopicName} konusunu tekrar edin";
                            description = $"Bu konunun temel kavramlarını gözden geçirin ve eksiklerinizi tamamlayın.";
                            break;
                    }

                    recommendations.Add(new UserRecommendation
                    {
                        Id = Guid.NewGuid(),
                        UserId = student.Id,
                        RecommendationType = recommendationType,
                        RecommendationText = recommendationText,
                        Description = description,
                        IsRead = random.Next(0, 2) == 1,
                        IsApplied = random.Next(0, 2) == 1,
                        ReadAt = random.Next(0, 2) == 1 ? DateTime.Now.AddDays(-random.Next(1, 7)) : null,
                        AppliedAt = random.Next(0, 2) == 1 ? DateTime.Now.AddDays(-random.Next(1, 3)) : null,
                        CreatedAt = DateTime.Now.AddDays(-random.Next(1, 14)),
                        RelatedTopicId = topic.Id
                    });
                }
            }

            return recommendations;
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
} 