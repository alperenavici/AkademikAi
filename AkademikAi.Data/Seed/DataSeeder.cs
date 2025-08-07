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
            // 0. Örnek kullanıcıları ekle
            var users = GetSeedUsers();
            modelBuilder.Entity<AppUser>().HasData(users);

            // 1. Subject'ları (dersleri) oluştur ve ekle
            var subjects = GetSubjects();
            modelBuilder.Entity<Subject>().HasData(subjects);

            // 2. Tüm konuları oluştur ve veritabanına ekle
            var allTopics = GetTopics(subjects);
            modelBuilder.Entity<Topics>().HasData(allTopics);

            // Tüm konuları al, çünkü artık tüm konular doğrudan derslere ait
            var allActiveTopics = allTopics.Where(t => t.IsActive).ToList();

            var allQuestions = new List<Questions>();
            var allQuestionOptions = new List<QuestionsOptions>();
            var allQuestionsTopics = new List<QuestionsTopic>();

            // 3. Her bir konu için 5 soru oluştur (20'den 5'e düşürüldü)
            foreach (var topic in allActiveTopics)
            {
                for (int i = 1; i <= 5; i++) // 20'den 5'e düşürüldü
                {
                    // Yeni bir soru oluştur
                    var newQuestion = new Questions
                    {
                        Id = Guid.NewGuid(),
                        QuestionText = $"{topic.TopicName} konusuyla ilgili Soru {i}: Bu sorunun detayı ve metni burada yer alacak.",
                        DifficultyLevel = i % 5 == 0 ? QuestionsDiff.hard : i % 2 == 0 ? QuestionsDiff.medium : QuestionsDiff.easy,
                        Source = "AkademikAI Seed Data",
                        IsActive = true,
                        SolutionText = $"{topic.TopicName} konusundaki Soru {i} için detaylı çözüm metni.",
                        GeneratedForUserId = null
                    };
                    allQuestions.Add(newQuestion);

                    // Bu soru için 4 seçenek oluştur
                    char[] labels = { 'A', 'B', 'C', 'D' };
                    // Rastgele bir doğru cevap belirle (0-3 arası)
                    var random = new Random();
                    int correctOptionIndex = random.Next(0, 4);

                    for (int j = 0; j < 4; j++)
                    {
                        allQuestionOptions.Add(new QuestionsOptions
                        {
                            Id = Guid.NewGuid(),
                            QuestionId = newQuestion.Id,
                            OptionText = $"{topic.TopicName} - Soru {i} için Seçenek {labels[j]}",
                            Label = labels[j],
                            IsCorrect = (j == correctOptionIndex), // Sadece belirlenen index'teki seçenek doğru
                            OptionOrder = j + 1
                        });
                    }

                    // Soru ve konu arasındaki ilişkiyi kur
                    allQuestionsTopics.Add(new QuestionsTopic
                    {
                        Id = Guid.NewGuid(),
                        QuestionId = newQuestion.Id,
                        TopicId = topic.Id
                    });
                }
            }

            // 4. Oluşturulan tüm verileri veritabanına ekle
            modelBuilder.Entity<Questions>().HasData(allQuestions);
            modelBuilder.Entity<QuestionsOptions>().HasData(allQuestionOptions);
            modelBuilder.Entity<QuestionsTopic>().HasData(allQuestionsTopics);

            // 5. UserPerformanceSummaries için örnek veriler oluştur
            var userPerformanceSummaries = GetUserPerformanceSummaries(allActiveTopics);
            modelBuilder.Entity<UserPerformanceSummaries>().HasData(userPerformanceSummaries);
        }

        private static List<Subject> GetSubjects()
        {
            return new List<Subject>
            {
                new Subject 
                { 
                    Id = Guid.Parse("f458884d-bb86-46a8-a604-5beb8469a5a8"), 
                    SubjectName = "Matematik", 
                    Description = "Temel matematik konuları",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Subject 
                { 
                    Id = Guid.Parse("7ed69d3c-87ab-44d9-b863-61219df3a23e"), 
                    SubjectName = "Fizik", 
                    Description = "Temel fizik konuları",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Subject 
                { 
                    Id = Guid.Parse("7580abcc-0b61-4569-8a54-953195b09a4d"), 
                    SubjectName = "Kimya", 
                    Description = "Temel kimya konuları",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Subject 
                { 
                    Id = Guid.Parse("da61c306-0160-49db-92b6-eaa8418a2f8c"), 
                    SubjectName = "Biyoloji", 
                    Description = "Temel biyoloji konuları",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            };
        }

        private static List<Topics> GetTopics(List<Subject> subjects)
        {
            var topics = new List<Topics>();
            var mathId = subjects.First(s => s.SubjectName == "Matematik").Id;
            var physicsId = subjects.First(s => s.SubjectName == "Fizik").Id;
            var chemistryId = subjects.First(s => s.SubjectName == "Kimya").Id;
            var biologyId = subjects.First(s => s.SubjectName == "Biyoloji").Id;

            // --- Matematik Konuları (5 alt konu) ---
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Temel Kavramlar", SubjectId = mathId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Sayı Basamakları", SubjectId = mathId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Bölme ve Bölünebilme", SubjectId = mathId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Rasyonel Sayılar", SubjectId = mathId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Problemler", SubjectId = mathId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow }
            });

            // --- Fizik Konuları (5 alt konu) ---
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Fizik Bilimine Giriş", SubjectId = physicsId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Madde ve Özellikleri", SubjectId = physicsId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kuvvet ve Hareket", SubjectId = physicsId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "İş, Güç ve Enerji", SubjectId = physicsId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Elektrostatik", SubjectId = physicsId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow }
            });

            // --- Kimya Konuları (5 alt konu) ---
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Kimya Bilimi", SubjectId = chemistryId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Atom ve Periyodik Sistem", SubjectId = chemistryId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kimyasal Türler Arası Etkileşimler", SubjectId = chemistryId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Maddenin Halleri", SubjectId = chemistryId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Asitler, Bazlar ve Tuzlar", SubjectId = chemistryId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow }
            });

            // --- Biyoloji Konuları (5 alt konu) ---
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Yaşam Bilimi Biyoloji", SubjectId = biologyId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Hücre", SubjectId = biologyId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Canlıların Sınıflandırılması", SubjectId = biologyId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Hücre Bölünmeleri", SubjectId = biologyId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kalıtım", SubjectId = biologyId, ParentTopicId = null, IsActive = true, CreatedAt = DateTime.UtcNow }
            });

            return topics;
        }

        private static List<UserPerformanceSummaries> GetUserPerformanceSummaries(List<Topics> allTopics)
        {
            var performanceSummaries = new List<UserPerformanceSummaries>();
            var random = new Random();
            
            // Örnek kullanıcı ID'leri (gerçek uygulamada var olan kullanıcılar kullanılır)
            var sampleUserIds = new List<Guid>
            {
                Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Guid.Parse("33333333-3333-3333-3333-333333333333")
            };

            foreach (var userId in sampleUserIds)
            {
                foreach (var topic in allTopics.Take(5)) // Her kullanıcı için 5 konu (10'dan 5'e düşürüldü)
                {
                    var totalQuestions = random.Next(10, 100);
                    var correctAnswers = random.Next(5, totalQuestions);
                    var successRate = (double)correctAnswers / totalQuestions * 100;

                    performanceSummaries.Add(new UserPerformanceSummaries
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        TopicId = topic.Id,
                        TotalQuestionsAnswered = totalQuestions,
                        CorrectAnswers = correctAnswers,
                        SuccessRate = Math.Round(successRate, 2),
                        CreatedAt = DateTime.UtcNow.AddDays(-random.Next(1, 30)),
                        LastUpdatedAt = DateTime.UtcNow.AddDays(-random.Next(0, 7))
                    });
                }
            }

            return performanceSummaries;
        }

        private static List<AppUser> GetSeedUsers()
        {
            return new List<AppUser>
            {
                new AppUser {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Ali",
                    Surname = "Veli",
                    Email = "ali@example.com",
                    NormalizedEmail = "ALI@EXAMPLE.COM",
                    UserName = "ali",
                    NormalizedUserName = "ALI",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEDummyHash1==", // dummy hash
                    SecurityStamp = "dummy-stamp-1",
                    ConcurrencyStamp = "dummy-conc-1",
                    PhoneNumber = "5551111111",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    CreatedAt = DateTime.UtcNow,
                    UserRole = UserRole.Student
                },
                new AppUser {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Ayşe",
                    Surname = "Yılmaz",
                    Email = "ayse@example.com",
                    NormalizedEmail = "AYSE@EXAMPLE.COM",
                    UserName = "ayse",
                    NormalizedUserName = "AYSE",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEDummyHash2==",
                    SecurityStamp = "dummy-stamp-2",
                    ConcurrencyStamp = "dummy-conc-2",
                    PhoneNumber = "5552222222",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    CreatedAt = DateTime.UtcNow,
                    UserRole = UserRole.Student
                },
                new AppUser {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Mehmet",
                    Surname = "Demir",
                    Email = "mehmet@example.com",
                    NormalizedEmail = "MEHMET@EXAMPLE.COM",
                    UserName = "mehmet",
                    NormalizedUserName = "MEHMET",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEDummyHash3==",
                    SecurityStamp = "dummy-stamp-3",
                    ConcurrencyStamp = "dummy-conc-3",
                    PhoneNumber = "5553333333",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    CreatedAt = DateTime.UtcNow,
                    UserRole = UserRole.Student
                }
            };
        }
    }
}