using AkademikAi.Data.Context;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using Microsoft.EntityFrameworkCore;

namespace AkademikAi.Data.Seed
{
    public static class ExamSeeder
    {
        public static async Task SeedExamsAsync(AppDbContext context)
        {
            // Eğer zaten sınav varsa, seedleme
            if (await context.Exams.AnyAsync())
                return;

            // İlk olarak konuları al
            var topics = await context.Topics.Take(5).ToListAsync();
            if (!topics.Any())
            {
                Console.WriteLine("⚠️ Konu bulunamadı. Önce konuları oluşturun.");
                return;
            }

            // Soruları al
            var questions = await context.Questions.Take(100).ToListAsync();
            if (!questions.Any())
            {
                Console.WriteLine("⚠️ Soru bulunamadı. Önce soruları oluşturun.");
                return;
            }

            var now = DateTime.UtcNow;

            var exams = new List<Exam>
            {
                // 1. Geçmiş sınav (tamamlanmış)
                new Exam
                {
                    Id = Guid.NewGuid(),
                    Title = "TYT Matematik Genel Denemesi",
                    Description = "Temel matematik konularını kapsayan kapsamlı deneme sınavı.",
                    StartTime = now.AddDays(-7), // 7 gün önce
                    EndTime = now.AddDays(-7).AddHours(2), // 2 saat sürmüş
                    DurationMinutes = 120,
                    Status = ExamStatus.Completed,
                    CreatedAt = now.AddDays(-10)
                },

                // 2. Aktif sınav (şu anda devam ediyor)
                new Exam
                {
                    Id = Guid.NewGuid(),
                    Title = "AYT Fizik Deneme Sınavı",
                    Description = "İleri düzey fizik konularını içeren deneme sınavı.",
                    StartTime = now.AddHours(-1), // 1 saat önce başlamış
                    EndTime = now.AddHours(1), // 1 saat daha devam edecek
                    DurationMinutes = 90,
                    Status = ExamStatus.InProgress,
                    CreatedAt = now.AddDays(-3)
                },

                // 3. Gelecek sınav (kayıt açık)
                new Exam
                {
                    Id = Guid.NewGuid(),
                    Title = "TYT Genel Deneme",
                    Description = "Tüm TYT konularını kapsayan genel deneme sınavı.",
                    StartTime = now.AddDays(2), // 2 gün sonra
                    EndTime = now.AddDays(2).AddHours(3), // 3 saat sürecek
                    DurationMinutes = 180,
                    Status = ExamStatus.Scheduled,
                    CreatedAt = now.AddDays(-1)
                },

                // 4. Uzak gelecek sınav
                new Exam
                {
                    Id = Guid.NewGuid(),
                    Title = "AYT Kimya Özel Denemesi",
                    Description = "Organik ve anorganik kimya konularına odaklanan özel sınav.",
                    StartTime = now.AddDays(7), // 1 hafta sonra
                    EndTime = now.AddDays(7).AddMinutes(75), // 75 dakika
                    DurationMinutes = 75,
                    Status = ExamStatus.Scheduled,
                    CreatedAt = now
                },

                // 5. İptal edilmiş sınav
                new Exam
                {
                    Id = Guid.NewGuid(),
                    Title = "TYT Türkçe Test Sınavı",
                    Description = "Dil ve anlatım konularını kapsayan test sınavı.",
                    StartTime = now.AddDays(5),
                    EndTime = now.AddDays(5).AddMinutes(60),
                    DurationMinutes = 60,
                    Status = ExamStatus.Cancelled,
                    CreatedAt = now.AddDays(-2)
                }
            };

            // Sınavları veritabanına ekle
            context.Exams.AddRange(exams);
            await context.SaveChangesAsync();

            // Her sınav için rastgele sorular ekle
            Random random = new Random();
            foreach (var exam in exams)
            {
                // Her sınav için 20-40 arası rastgele soru sayısı
                int questionCount = random.Next(20, 41);
                var selectedQuestions = questions.OrderBy(x => Guid.NewGuid()).Take(questionCount).ToList();

                var examQuestions = new List<ExamQuestions>();
                for (int i = 0; i < selectedQuestions.Count; i++)
                {
                    examQuestions.Add(new ExamQuestions
                    {
                        ExamId = exam.Id,
                        QuestionId = selectedQuestions[i].Id,
                        QuestionOrder = i + 1
                    });
                }

                context.ExamQuestions.AddRange(examQuestions);
            }

            await context.SaveChangesAsync();

            // Örnek katılımcılar ekle (eğer kullanıcı varsa)
            var users = await context.Users.Take(10).ToListAsync();
            if (users.Any())
            {
                var participants = new List<ExamParticipant>();

                foreach (var exam in exams)
                {
                    // Her sınava rastgele kullanıcıları ekle
                    var participantCount = random.Next(5, Math.Min(users.Count, 15));
                    var selectedUsers = users.OrderBy(x => Guid.NewGuid()).Take(participantCount);

                    foreach (var user in selectedUsers)
                    {
                        ExamParticipationStatus status;
                        
                        // Sınav durumuna göre katılımcı durumu belirle
                        switch (exam.Status)
                        {
                            case ExamStatus.Completed:
                                status = ExamParticipationStatus.Completed;
                                break;
                            case ExamStatus.InProgress:
                                status = random.Next(0, 3) switch
                                {
                                    0 => ExamParticipationStatus.Registered,
                                    1 => ExamParticipationStatus.Started,
                                    _ => ExamParticipationStatus.Completed
                                };
                                break;
                            case ExamStatus.Scheduled:
                                status = ExamParticipationStatus.Registered;
                                break;
                            default:
                                continue; // İptal edilmiş sınavlara katılımcı ekleme
                        }

                        participants.Add(new ExamParticipant
                        {
                            UserId = user.Id,
                            ExamId = exam.Id,
                            Status = status,
                            TimeStarted = status != ExamParticipationStatus.Registered ? 
                                exam.StartTime.AddMinutes(random.Next(0, 30)) : null,
                            TimeFinished = status == ExamParticipationStatus.Completed ? 
                                exam.StartTime.AddMinutes(random.Next(30, exam.DurationMinutes)) : DateTime.UtcNow,
                            Score = status == ExamParticipationStatus.Completed ? 
                                Math.Round(random.NextDouble() * 100, 2) : null
                        });
                    }
                }

                context.ExamParticipants.AddRange(participants);
                await context.SaveChangesAsync();
            }

            Console.WriteLine($"✅ {exams.Count} adet örnek sınav ve katılımcıları başarıyla oluşturuldu.");
        }
    }
}
