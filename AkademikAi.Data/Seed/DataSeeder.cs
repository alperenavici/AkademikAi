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
            // 1. Tüm ana ve alt konuları oluştur ve veritabanına ekle
            var allTopics = GetTopics();
            modelBuilder.Entity<Topics>().HasData(allTopics);

            // Sadece alt konuları (derslerin içindeki konuları) seç, çünkü sorular alt konulara aittir.
            var subTopics = allTopics.Where(t => t.ParentTopicId != null).ToList();

            var allQuestions = new List<Questions>();
            var allQuestionOptions = new List<QuestionsOptions>();
            var allQuestionsTopics = new List<QuestionsTopic>();

            // 2. Her bir alt konu için 20 soru oluştur
            foreach (var topic in subTopics)
            {
                for (int i = 1; i <= 20; i++)
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

            // 3. Oluşturulan tüm verileri veritabanına ekle
            modelBuilder.Entity<Questions>().HasData(allQuestions);
            modelBuilder.Entity<QuestionsOptions>().HasData(allQuestionOptions);
            modelBuilder.Entity<QuestionsTopic>().HasData(allQuestionsTopics);
        }

        private static List<Topics> GetTopics()
        {
            var topics = new List<Topics>
            {
                // Ana Dersler (Kök Konular)
                new Topics { Id = Guid.NewGuid(), TopicName = "Matematik", ParentTopicId = null },
                new Topics { Id = Guid.NewGuid(), TopicName = "Fizik", ParentTopicId = null },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kimya", ParentTopicId = null },
                new Topics { Id = Guid.NewGuid(), TopicName = "Biyoloji", ParentTopicId = null },
                new Topics { Id = Guid.NewGuid(), TopicName = "Türkçe", ParentTopicId = null },
                new Topics { Id = Guid.NewGuid(), TopicName = "Tarih", ParentTopicId = null },
                new Topics { Id = Guid.NewGuid(), TopicName = "Coğrafya", ParentTopicId = null },
                new Topics { Id = Guid.NewGuid(), TopicName = "Felsefe Grubu", ParentTopicId = null }
            };

            // --- Matematik Konuları ---
            var mathId = topics.First(t => t.TopicName == "Matematik").Id;
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Temel Kavramlar", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Sayı Basamakları", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Bölme ve Bölünebilme", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "EBOB-EKOK", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Rasyonel Sayılar", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Basit Eşitsizlikler", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Mutlak Değer", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Üslü Sayılar", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Köklü Sayılar", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Çarpanlara Ayırma", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Oran Orantı", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Problemler", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kümeler", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Fonksiyonlar", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Permütasyon-Kombinasyon-Binom", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Olasılık", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Polinomlar", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "İkinci Dereceden Denklemler", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Parabol", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Trigonometri", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Logaritma", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Diziler", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Limit ve Süreklilik", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Türev", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "İntegral", ParentTopicId = mathId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Geometri", ParentTopicId = mathId }
            });

            // --- Fizik Konuları ---
            var physicsId = topics.First(t => t.TopicName == "Fizik").Id;
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Fizik Bilimine Giriş", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Madde ve Özellikleri", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kuvvet ve Hareket", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "İş, Güç ve Enerji", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Isı, Sıcaklık ve Genleşme", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Elektrostatik", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Elektrik Akımı ve Devreleri", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Manyetizma", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Basınç ve Kaldırma Kuvveti", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Dalgalar", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Optik", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Çembersel Hareket", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Basit Harmonik Hareket", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Atom Fiziği ve Radyoaktivite", ParentTopicId = physicsId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Modern Fizik", ParentTopicId = physicsId }
            });

            // --- Kimya Konuları ---
            var chemistryId = topics.First(t => t.TopicName == "Kimya").Id;
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Kimya Bilimi", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Atom ve Periyodik Sistem", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kimyasal Türler Arası Etkileşimler", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Maddenin Halleri", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kimyanın Temel Kanunları ve Hesaplamalar", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Asitler, Bazlar ve Tuzlar", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Karışımlar", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kimya Her Yerde", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Modern Atom Teorisi", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Gazlar", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Sıvı Çözeltiler ve Çözünürlük", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kimyasal Tepkimelerde Enerji", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kimyasal Tepkimelerde Hız", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kimyasal Denge", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kimya ve Elektrik", ParentTopicId = chemistryId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Organik Kimya", ParentTopicId = chemistryId }
            });

            // --- Biyoloji Konuları ---
            var biologyId = topics.First(t => t.TopicName == "Biyoloji").Id;
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Yaşam Bilimi Biyoloji", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Hücre", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Canlıların Sınıflandırılması", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Hücre Bölünmeleri", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Kalıtım", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Ekosistem Ekolojisi", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Sinir Sistemi", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Endokrin Sistem", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Duyu Organları", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Destek ve Hareket Sistemi", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Sindirim Sistemi", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Dolaşım ve Bağışıklık Sistemi", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Solunum Sistemi", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Boşaltım Sistemi", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Üreme Sistemi ve Embriyonik Gelişim", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Genden Proteine", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Canlılarda Enerji Dönüşümleri", ParentTopicId = biologyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Bitki Biyolojisi", ParentTopicId = biologyId }
            });

            // --- Türkçe Konuları ---
            var turkishId = topics.First(t => t.TopicName == "Türkçe").Id;
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Sözcükte Anlam", ParentTopicId = turkishId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Cümlede Anlam", ParentTopicId = turkishId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Paragrafta Anlam", ParentTopicId = turkishId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Ses Bilgisi", ParentTopicId = turkishId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Yazım Kuralları", ParentTopicId = turkishId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Noktalama İşaretleri", ParentTopicId = turkishId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Sözcükte Yapı", ParentTopicId = turkishId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Sözcük Türleri", ParentTopicId = turkishId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Fiiller", ParentTopicId = turkishId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Cümlenin Öğeleri", ParentTopicId = turkishId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Cümle Türleri", ParentTopicId = turkishId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Anlatım Bozuklukları", ParentTopicId = turkishId }
            });

            // --- Tarih Konuları ---
            var historyId = topics.First(t => t.TopicName == "Tarih").Id;
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Tarih ve Zaman", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "İnsanlığın İlk Dönemleri", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Orta Çağ'da Dünya", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "İlk ve Orta Çağlarda Türk Dünyası", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "İslam Medeniyetinin Doğuşu", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Türklerin İslamiyet'i Kabulü ve İlk Türk İslam Devletleri", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Yerleşme ve Devletleşme Sürecinde Selçuklu Türkiyesi", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Beylikten Devlete Osmanlı Siyaseti", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Devletleşme Sürecinde Savaşçılar ve Askerler", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Dünya Gücü Osmanlı", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Sultan ve Osmanlı Merkez Teşkilatı", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Değişen Dünya Dengeleri Karşısında Osmanlı Siyaseti", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Uluslararası İlişkilerde Denge Stratejisi (1774-1914)", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "20. Yüzyıl Başlarında Osmanlı Devleti ve Dünya", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Milli Mücadele", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Atatürkçülük ve Türk İnkılabı", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "İki Savaş Arasındaki Dönemde Türkiye ve Dünya", ParentTopicId = historyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "II. Dünya Savaşı Sonrasında Türkiye ve Dünya", ParentTopicId = historyId }
            });

            // --- Coğrafya Konuları ---
            var geographyId = topics.First(t => t.TopicName == "Coğrafya").Id;
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Doğa, İnsan ve Coğrafya", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Dünya'nın Şekli ve Hareketleri", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Coğrafi Konum", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Harita Bilgisi", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "İklim Bilgisi", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Yerin Şekillenmesi (İç ve Dış Kuvvetler)", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Doğadaki Üç Unsur: Su, Toprak, Bitki", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Nüfus ve Yerleşme", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Ekonomik Faaliyetler", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Bölgeler ve Ülkeler", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Ulaşım Yolları", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Çevre ve Toplum", ParentTopicId = geographyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Doğal Afetler", ParentTopicId = geographyId }
            });

            // --- Felsefe Grubu Konuları ---
            var philosophyId = topics.First(t => t.TopicName == "Felsefe Grubu").Id;
            topics.AddRange(new[] {
                new Topics { Id = Guid.NewGuid(), TopicName = "Felsefe ile Tanışma", ParentTopicId = philosophyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Bilgi Felsefesi (Epistemoloji)", ParentTopicId = philosophyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Varlık Felsefesi (Ontoloji)", ParentTopicId = philosophyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Ahlak Felsefesi (Etik)", ParentTopicId = philosophyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Sanat Felsefesi (Estetik)", ParentTopicId = philosophyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Din Felsefesi", ParentTopicId = philosophyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Siyaset Felsefesi", ParentTopicId = philosophyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Bilim Felsefesi", ParentTopicId = philosophyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Psikoloji Bilimini Tanıyalım", ParentTopicId = philosophyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Sosyolojiye Giriş", ParentTopicId = philosophyId },
                new Topics { Id = Guid.NewGuid(), TopicName = "Mantığa Giriş", ParentTopicId = philosophyId }
            });

            return topics;
        }
    }
}