using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AkademikAi.Data.Context;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using System.Security.Cryptography;
using System.Text;

namespace AkademikAi.Data.Seed
{
    public static class DatabaseSeeder
    {
        // Örnek kullanıcı ve konu ID'leri için sabitler
        private static readonly Guid _user1Id = Guid.Parse("U1111111-1111-1111-1111-111111111111");
        private static readonly Guid _user2Id = Guid.Parse("U2222222-2222-2222-2222-222222222222");

        public static void SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppDbContext>>();

            try
            {
                logger.LogInformation("DatabaseSeeder başlatılıyor...");
                context.Database.EnsureCreated();
                logger.LogInformation("Veritabanı oluşturuldu/doğrulandı.");

                if (!context.Topics.Any() && !context.Questions.Any())
                {
                    logger.LogInformation("Veritabanı boş. Seed data başlatılıyor...");
                    SeedDataManually(context);
                    logger.LogInformation("Seed data başarıyla eklendi.");
                }

                // Sınav seeding'i ayrı kontrol et
                if (!context.Exams.Any())
                {
                    logger.LogInformation("Sınav verileri boş. Örnek sınavlar oluşturuluyor...");
                    logger.LogInformation("Örnek sınavlar başarıyla eklendi.");
                }
                else
                {
                    logger.LogInformation("Veritabanında zaten veri mevcut. Seed data atlanıyor.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Seed data eklenirken bir hata oluştu: {Message}", ex.Message);
                // Geliştirme ortamında hatanın detayını görmek için throw önemlidir.
                throw;
            }
        }

        private static void SeedDataManually(AppDbContext context)
        {
            // Tüm verileri listeler halinde al
            var allTopics = GetTopics();
            var allQuestions = GetQuestions();
            var allQuestionOptions = GetQuestionOptions(allQuestions);
            var allQuestionsTopics = GetQuestionsTopics(allQuestions, allTopics);

            // Diğer ilişkili verileri oluştur (örnek kullanıcılar için)
            var userAnswers = GetUserAnswers(allQuestions, allQuestionOptions);
            var userNotifications = GetUserNotifications();
            var userPerformanceSummaries = GetUserPerformanceSummaries(allTopics);
            var userRecommendations = GetUserRecommendations(allTopics);

            // Veritabanına toplu olarak ekle (daha performanslı)
            context.Topics.AddRange(allTopics);
            context.Questions.AddRange(allQuestions);
            context.QuestionsOptions.AddRange(allQuestionOptions);
            context.QuestionsTopics.AddRange(allQuestionsTopics);
            context.UserAnswers.AddRange(userAnswers);
            context.UserNotifications.AddRange(userNotifications);
            context.UserPerformanceSummaries.AddRange(userPerformanceSummaries);
            context.UserRecommendations.AddRange(userRecommendations);

            // Değişiklikleri tek seferde kaydet
            context.SaveChanges();
        }

        #region YKS Konuları
        private static List<Topics> GetTopics()
        {
            // Ana Dersler (Kök Konular)
            var mathId = Guid.Parse("01000000-0000-0000-0000-000000000000");
            var physicsId = Guid.Parse("02000000-0000-0000-0000-000000000000");
            var chemistryId = Guid.Parse("03000000-0000-0000-0000-000000000000");
            var biologyId = Guid.Parse("04000000-0000-0000-0000-000000000000");
            var turkishId = Guid.Parse("05000000-0000-0000-0000-000000000000");
            var historyId = Guid.Parse("06000000-0000-0000-0000-000000000000");
            var geographyId = Guid.Parse("07000000-0000-0000-0000-000000000000");
            var philosophyId = Guid.Parse("08000000-0000-0000-0000-000000000000");

            return new List<Topics>
            {
                new Topics { Id = mathId, TopicName = "Matematik", ParentTopicId = null },
                new Topics { Id = physicsId, TopicName = "Fizik", ParentTopicId = null },
                new Topics { Id = chemistryId, TopicName = "Kimya", ParentTopicId = null },
                new Topics { Id = biologyId, TopicName = "Biyoloji", ParentTopicId = null },
                new Topics { Id = turkishId, TopicName = "Türkçe", ParentTopicId = null },
                new Topics { Id = historyId, TopicName = "Tarih", ParentTopicId = null },
                new Topics { Id = geographyId, TopicName = "Coğrafya", ParentTopicId = null },
                new Topics { Id = philosophyId, TopicName = "Felsefe Grubu", ParentTopicId = null },

                // --- Matematik Alt Konuları ---
                new Topics { Id = Guid.Parse("01010000-0000-0000-0000-000000000000"), TopicName = "Temel Kavramlar", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01020000-0000-0000-0000-000000000000"), TopicName = "Sayı Basamakları", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01030000-0000-0000-0000-000000000000"), TopicName = "Bölme ve Bölünebilme", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01040000-0000-0000-0000-000000000000"), TopicName = "EBOB-EKOK", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01050000-0000-0000-0000-000000000000"), TopicName = "Rasyonel Sayılar", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01060000-0000-0000-0000-000000000000"), TopicName = "Basit Eşitsizlikler", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01070000-0000-0000-0000-000000000000"), TopicName = "Mutlak Değer", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01080000-0000-0000-0000-000000000000"), TopicName = "Üslü Sayılar", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01090000-0000-0000-0000-000000000000"), TopicName = "Köklü Sayılar", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01100000-0000-0000-0000-000000000000"), TopicName = "Çarpanlara Ayırma", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01110000-0000-0000-0000-000000000000"), TopicName = "Oran Orantı", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01120000-0000-0000-0000-000000000000"), TopicName = "Problemler", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01130000-0000-0000-0000-000000000000"), TopicName = "Kümeler", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01140000-0000-0000-0000-000000000000"), TopicName = "Fonksiyonlar", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01150000-0000-0000-0000-000000000000"), TopicName = "Permütasyon-Kombinasyon-Binom", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01160000-0000-0000-0000-000000000000"), TopicName = "Olasılık", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01170000-0000-0000-0000-000000000000"), TopicName = "Polinomlar", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01180000-0000-0000-0000-000000000000"), TopicName = "İkinci Dereceden Denklemler", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01190000-0000-0000-0000-000000000000"), TopicName = "Parabol", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01200000-0000-0000-0000-000000000000"), TopicName = "Trigonometri", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01210000-0000-0000-0000-000000000000"), TopicName = "Logaritma", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01220000-0000-0000-0000-000000000000"), TopicName = "Diziler", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01230000-0000-0000-0000-000000000000"), TopicName = "Limit ve Süreklilik", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01240000-0000-0000-0000-000000000000"), TopicName = "Türev", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01250000-0000-0000-0000-000000000000"), TopicName = "İntegral", ParentTopicId = mathId },
                new Topics { Id = Guid.Parse("01260000-0000-0000-0000-000000000000"), TopicName = "Geometri", ParentTopicId = mathId },

                // --- Fizik Alt Konuları ---
                new Topics { Id = Guid.Parse("02010000-0000-0000-0000-000000000000"), TopicName = "Fizik Bilimine Giriş", ParentTopicId = physicsId },
                new Topics { Id = Guid.Parse("02020000-0000-0000-0000-000000000000"), TopicName = "Madde ve Özellikleri", ParentTopicId = physicsId },
                new Topics { Id = Guid.Parse("02030000-0000-0000-0000-000000000000"), TopicName = "Kuvvet ve Hareket", ParentTopicId = physicsId },
                new Topics { Id = Guid.Parse("02040000-0000-0000-0000-000000000000"), TopicName = "İş, Güç ve Enerji", ParentTopicId = physicsId },
                new Topics { Id = Guid.Parse("02050000-0000-0000-0000-000000000000"), TopicName = "Isı, Sıcaklık ve Genleşme", ParentTopicId = physicsId },
                new Topics { Id = Guid.Parse("02060000-0000-0000-0000-000000000000"), TopicName = "Optik", ParentTopicId = physicsId },
                
                // --- Kimya Alt Konuları ---
                new Topics { Id = Guid.Parse("03010000-0000-0000-0000-000000000000"), TopicName = "Kimya Bilimi", ParentTopicId = chemistryId },
                new Topics { Id = Guid.Parse("03020000-0000-0000-0000-000000000000"), TopicName = "Atom ve Periyodik Sistem", ParentTopicId = chemistryId },
                new Topics { Id = Guid.Parse("03030000-0000-0000-0000-000000000000"), TopicName = "Asitler, Bazlar ve Tuzlar", ParentTopicId = chemistryId },
                new Topics { Id = Guid.Parse("03040000-0000-0000-0000-000000000000"), TopicName = "Organik Kimya", ParentTopicId = chemistryId },

                // --- Türkçe Alt Konuları ---
                new Topics { Id = Guid.Parse("05010000-0000-0000-0000-000000000000"), TopicName = "Sözcükte Anlam", ParentTopicId = turkishId },
                new Topics { Id = Guid.Parse("05020000-0000-0000-0000-000000000000"), TopicName = "Paragrafta Anlam", ParentTopicId = turkishId },
                new Topics { Id = Guid.Parse("05030000-0000-0000-0000-000000000000"), TopicName = "Yazım Kuralları", ParentTopicId = turkishId },
                new Topics { Id = Guid.Parse("05040000-0000-0000-0000-000000000000"), TopicName = "Noktalama İşaretleri", ParentTopicId = turkishId },
                
                // Diğer dersler için de benzer şekilde eklenebilir...
            };
        }
        #endregion

        #region Örnek Sorular
        private static List<Questions> GetQuestions()
        {
            return new List<Questions>
            {
                // --- Matematik Soruları ---
                new Questions
                {
                    Id = Guid.Parse("Q1010001-0000-0000-0000-000000000000"),
                    QuestionText = "a ve b birer tam sayı olmak üzere, a.b = 24 olduğuna göre, a+b toplamı en az kaç olabilir?",
                    DifficultyLevel = QuestionsDiff.medium,
                    Source = "YKS 2020 Benzeri", IsActive = true,
                    SolutionText = "Toplamın en az olması için sayılar birbirine en uzak ve negatif seçilmelidir. a = -1 ve b = -24 seçilirse, a.b = 24 olur. Toplamları a+b = -1 + (-24) = -25 olur.",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("Q1200001-0000-0000-0000-000000000000"),
                    QuestionText = "sin²(x) + cos²(x) ifadesinin eşiti nedir?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "Trigonometri Temel Özdeşlik", IsActive = true,
                    SolutionText = "Trigonometrinin temel özdeşliklerinden birine göre, aynı açının sinüsünün karesi ile kosinüsünün karesinin toplamı daima 1'e eşittir. Yani sin²(x) + cos²(x) = 1.",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("Q1210001-0000-0000-0000-000000000000"),
                    QuestionText = "log₂(16) + log₃(27) işleminin sonucu kaçtır?",
                    DifficultyLevel = QuestionsDiff.medium,
                    Source = "Logaritma Temel Özellikler", IsActive = true,
                    SolutionText = "log₂(16) = log₂(2⁴) = 4.log₂(2) = 4.1 = 4.\nlog₃(27) = log₃(3³) = 3.log₃(3) = 3.1 = 3.\nSonuç: 4 + 3 = 7.",
                    GeneratedForUserId = null
                },

                // --- Fizik Soruları ---
                new Questions
                {
                    Id = Guid.Parse("Q2030001-0000-0000-0000-000000000000"),
                    QuestionText = "Duran bir cisme etki eden net kuvvet sıfırdan farklı ise cisim nasıl bir hareket yapar?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "Newton'un Hareket Yasaları", IsActive = true,
                    SolutionText = "Newton'un ikinci hareket yasasına (F=m.a) göre, bir cisme etki eden net kuvvet varsa, cisim o kuvvet yönünde ivmeli hareket yapar. Yani hızı düzgün olarak artar veya azalır.",
                    GeneratedForUserId = null
                },
                new Questions
                {
                    Id = Guid.Parse("Q2060001-0000-0000-0000-000000000000"),
                    QuestionText = "Işığın bir saydam ortamdan başka bir saydam ortama geçerken doğrultu değiştirmesi olayına ne denir?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "Optik Temel Kavramlar", IsActive = true,
                    SolutionText = "Işığın yoğunlukları farklı saydam ortamlar arasında geçerken yön ve doğrultu değiştirmesi olayına 'kırılma' denir.",
                    GeneratedForUserId = null
                },
                
                // --- Kimya Soruları ---
                new Questions
                {
                    Id = Guid.Parse("Q3030001-0000-0000-0000-000000000000"),
                    QuestionText = "Oda koşullarında pH değeri 7 olan bir çözelti için aşağıdakilerden hangisi doğrudur?",
                    DifficultyLevel = QuestionsDiff.easy,
                    Source = "Asit-Baz Kavramları", IsActive = true,
                    SolutionText = "pH skalasında 7 değeri nötr noktayı temsil eder. pH 7'den küçükse asidik, 7'den büyükse bazik, tam 7 ise nötrdür. Saf su buna bir örnektir.",
                    GeneratedForUserId = null
                },
                
                // --- Türkçe Soruları ---
                new Questions
                {
                    Id = Guid.Parse("Q5030001-0000-0000-0000-000000000000"),
                    QuestionText = "Aşağıdaki cümlelerin hangisinde 'de' bağlacının yazımı ile ilgili bir yanlışlık yapılmıştır?",
                    DifficultyLevel = QuestionsDiff.medium,
                    Source = "Yazım Kuralları", IsActive = true,
                    SolutionText = "Bağlaç olan 'de/da' her zaman ayrı yazılır ve cümleden çıkarıldığında anlam bozulmaz. Bulunma hali olan '-de/-da' ise bitişik yazılır ve cümleden çıkarıldığında anlam bozulur. Doğru cevap olan 'Sen de mi bizimle geleceksin?' cümlesindeki 'de' bağlaçtır ve ayrı yazılması doğrudur. 'Kitaplar masa da kalmış.' cümlesinde ise bulunma hali olduğu için bitişik yazılmalıydı.",
                    GeneratedForUserId = null
                }
            };
        }
        #endregion

        #region Soru Seçenekleri
        private static List<QuestionsOptions> GetQuestionOptions(List<Questions> questions)
        {
            var options = new List<QuestionsOptions>();
            foreach (var q in questions)
            {
                if (q.Id == Guid.Parse("Q1010001-0000-0000-0000-000000000000")) // a+b en az?
                {
                    options.AddRange(new[] {
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "10", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "11", Label = 'B', IsCorrect = false, OptionOrder = 2 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "-25", Label = 'C', IsCorrect = true, OptionOrder = 3 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "-10", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                    });
                }
                else if (q.Id == Guid.Parse("Q1200001-0000-0000-0000-000000000000")) // sin²(x)+cos²(x)
                {
                    options.AddRange(new[] {
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "0", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "1", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "tan(x)", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "sin(2x)", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                    });
                }
                else if (q.Id == Guid.Parse("Q1210001-0000-0000-0000-000000000000")) // log₂(16)+log₃(27)
                {
                    options.AddRange(new[] {
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "5", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "6", Label = 'B', IsCorrect = false, OptionOrder = 2 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "7", Label = 'C', IsCorrect = true, OptionOrder = 3 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "12", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                    });
                }
                else if (q.Id == Guid.Parse("Q2030001-0000-0000-0000-000000000000")) // Net kuvvet varsa hareket
                {
                    options.AddRange(new[] {
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Durgun kalmaya devam eder.", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Sabit hızla hareket eder.", Label = 'B', IsCorrect = false, OptionOrder = 2 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "İvmeli hareket yapar.", Label = 'C', IsCorrect = true, OptionOrder = 3 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Yavaşlar ve durur.", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                    });
                }
                else if (q.Id == Guid.Parse("Q2060001-0000-0000-0000-000000000000")) // Işığın yön değiştirmesi
                {
                    options.AddRange(new[] {
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Yansıma", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Kırılma", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Soğurulma", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Kırınım", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                    });
                }
                else if (q.Id == Guid.Parse("Q3030001-0000-0000-0000-000000000000")) // pH 7
                {
                    options.AddRange(new[] {
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Çözelti asidiktir.", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Çözelti baziktir.", Label = 'B', IsCorrect = false, OptionOrder = 2 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Çözelti nötrdür.", Label = 'C', IsCorrect = true, OptionOrder = 3 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Kırmızı turnusol kağıdını maviye çevirir.", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                    });
                }
                else if (q.Id == Guid.Parse("Q5030001-0000-0000-0000-000000000000")) // Yazım yanlışı 'de'
                {
                    options.AddRange(new[] {
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "O da bizimle sinemaya gelecek.", Label = 'A', IsCorrect = false, OptionOrder = 1 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Kitaplar masa da kalmış.", Label = 'B', IsCorrect = true, OptionOrder = 2 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Evde kimse yoktu.", Label = 'C', IsCorrect = false, OptionOrder = 3 },
                        new QuestionsOptions { Id = Guid.NewGuid(), QuestionId = q.Id, OptionText = "Anlatsan da anlamaz.", Label = 'D', IsCorrect = false, OptionOrder = 4 }
                    });
                }
            }
            return options;
        }
        #endregion

        #region Soru-Konu Eşleştirmeleri
        private static List<QuestionsTopic> GetQuestionsTopics(List<Questions> questions, List<Topics> topics)
        {
            return new List<QuestionsTopic>
            {
                // QuestionId'leri ve TopicId'leri manuel olarak eşleştir
                new QuestionsTopic { Id = Guid.NewGuid(), QuestionId = Guid.Parse("Q1010001-0000-0000-0000-000000000000"), TopicId = Guid.Parse("01010000-0000-0000-0000-000000000000") }, // Temel Kavramlar
                new QuestionsTopic { Id = Guid.NewGuid(), QuestionId = Guid.Parse("Q1200001-0000-0000-0000-000000000000"), TopicId = Guid.Parse("01200000-0000-0000-0000-000000000000") }, // Trigonometri
                new QuestionsTopic { Id = Guid.NewGuid(), QuestionId = Guid.Parse("Q1210001-0000-0000-0000-000000000000"), TopicId = Guid.Parse("01210000-0000-0000-0000-000000000000") }, // Logaritma
                new QuestionsTopic { Id = Guid.NewGuid(), QuestionId = Guid.Parse("Q2030001-0000-0000-0000-000000000000"), TopicId = Guid.Parse("02030000-0000-0000-0000-000000000000") }, // Kuvvet ve Hareket
                new QuestionsTopic { Id = Guid.NewGuid(), QuestionId = Guid.Parse("Q2060001-0000-0000-0000-000000000000"), TopicId = Guid.Parse("02060000-0000-0000-0000-000000000000") }, // Optik
                new QuestionsTopic { Id = Guid.NewGuid(), QuestionId = Guid.Parse("Q3030001-0000-0000-0000-000000000000"), TopicId = Guid.Parse("03030000-0000-0000-0000-000000000000") }, // Asitler, Bazlar ve Tuzlar
                new QuestionsTopic { Id = Guid.NewGuid(), QuestionId = Guid.Parse("Q5030001-0000-0000-0000-000000000000"), TopicId = Guid.Parse("05030000-0000-0000-0000-000000000000") }  // Yazım Kuralları
            };
        }
        #endregion

        #region Örnek Kullanıcı Verileri
        private static List<UserAnswers> GetUserAnswers(List<Questions> questions, List<QuestionsOptions> allOptions)
        {
            var userAnswers = new List<UserAnswers>();
            var random = new Random();

            // User 1'in cevapları
            var user1Questions = questions.Take(3).ToList();
            foreach (var q in user1Questions)
            {
                var optionsForQ = allOptions.Where(o => o.QuestionId == q.Id).ToList();
                var selectedOption = optionsForQ[random.Next(optionsForQ.Count)]; // Rastgele bir seçenek seç
                userAnswers.Add(new UserAnswers
                {
                    Id = Guid.NewGuid(),
                    UserId = _user1Id,
                    QuestionId = q.Id,
                    SelectedOptionId = selectedOption.Id,
                    IsCorrect = selectedOption.IsCorrect,
                    AnsweredAt = DateTime.Now.AddDays(-random.Next(1, 10)),
                    UserAnswer = selectedOption.Label
                });
            }

            // User 2'nin cevapları
            var user2Questions = questions.Skip(3).Take(3).ToList();
            foreach (var q in user2Questions)
            {
                var optionsForQ = allOptions.Where(o => o.QuestionId == q.Id).ToList();
                var correctOption = optionsForQ.First(o => o.IsCorrect); // Bu kullanıcı hep doğru cevap versin
                userAnswers.Add(new UserAnswers
                {
                    Id = Guid.NewGuid(),
                    UserId = _user2Id,
                    QuestionId = q.Id,
                    SelectedOptionId = correctOption.Id,
                    IsCorrect = true,
                    AnsweredAt = DateTime.Now.AddDays(-random.Next(1, 10)),
                    UserAnswer = correctOption.Label
                });
            }

            return userAnswers;
        }

        private static List<UserNotifications> GetUserNotifications()
        {
            return new List<UserNotifications>
            {
                new UserNotifications
                {
                    Id = Guid.NewGuid(), UserId = _user1Id, Title = "Hoş Geldin!", NotificationType = "welcome",
                    Message = "AkademikAI'ye hoş geldin! Başarıya giden yolda yanındayız.", IsRead = false,
                    CreatedAt = DateTime.Now.AddDays(-5)
                },
                new UserNotifications
                {
                    Id = Guid.NewGuid(), UserId = _user2Id, Title = "Performans Raporun Hazır", NotificationType = "performance",
                    Message = "Haftalık Trigonometri performans raporunu inceleyebilirsin.", IsRead = true, ReadAt = DateTime.Now.AddDays(-1),
                    CreatedAt = DateTime.Now.AddDays(-2)
                }
            };
        }

        private static List<UserPerformanceSummaries> GetUserPerformanceSummaries(List<Topics> topics)
        {
            var mathTopicId = Guid.Parse("01000000-0000-0000-0000-000000000000");
            var physicsTopicId = Guid.Parse("02000000-0000-0000-0000-000000000000");

            return new List<UserPerformanceSummaries>
            {
                new UserPerformanceSummaries
                {
                    Id = Guid.NewGuid(), UserId = _user1Id, TopicId = mathTopicId,
                    TotalQuestionsAnswered = 15, CorrectAnswers = 9, SuccessRate = 60.00,
                    LastUpdatedAt = DateTime.Now.AddDays(-1)
                },
                new UserPerformanceSummaries
                {
                    Id = Guid.NewGuid(), UserId = _user2Id, TopicId = physicsTopicId,
                    TotalQuestionsAnswered = 20, CorrectAnswers = 18, SuccessRate = 90.00,
                    LastUpdatedAt = DateTime.Now.AddDays(-2)
                }
            };
        }

        private static List<UserRecommendation> GetUserRecommendations(List<Topics> topics)
        {
            var mathTrigTopicId = Guid.Parse("01200000-0000-0000-0000-000000000000"); // Trigonometri
            var physicsOpticTopicId = Guid.Parse("02060000-0000-0000-0000-000000000000"); // Optik

            return new List<UserRecommendation>
            {
                new UserRecommendation
                {
                    Id = Guid.NewGuid(), UserId = _user1Id, RelatedTopicId = mathTrigTopicId,
                    RecommendationType = 2, // Konu tekrarı
                    RecommendationText = "Trigonometri konusunda eksiklerin var.",
                    Description = "Özellikle birim çember ve temel özdeşlikler konularını tekrar etmen faydalı olacaktır.",
                    IsRead = false, IsApplied = false, CreatedAt = DateTime.Now.AddDays(-1)
                },
                new UserRecommendation
                {
                    Id = Guid.NewGuid(), UserId = _user2Id, RelatedTopicId = physicsOpticTopicId,
                    RecommendationType = 0, // Test
                    RecommendationText = "Optik konusunda kendini geliştir.",
                    Description = "Mercekler ve kırılma indisleri ile ilgili daha fazla soru çözerek bu konudaki başarını pekiştirebilirsin.",
                    IsRead = true, ReadAt = DateTime.Now.AddDays(-1), IsApplied = false, CreatedAt = DateTime.Now.AddDays(-3)
                }
            };
        }
        #endregion
    }
}