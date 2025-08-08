using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.Repositories
{
        public class ExamRepository : GenericRepository<Exam>, IExamRepository
        {
            private readonly AppDbContext _context;

            public ExamRepository(AppDbContext context) : base(context)
            {
                _context = context;
            }

            public async Task<List<Exam>> GetActiveAndUpcomingExamsAsync()
            {
                return await _context.Exams
                    .Where(e => e.Status == ExamStatus.Scheduled || e.Status == ExamStatus.InProgress)
                    .OrderBy(e => e.StartTime)
                    .ToListAsync();
            }

            public async Task<Exam> GetExamWithQuestionsAndOptionsAsync(Guid examId)
            {
                // Sınavın sorularını ve bu soruların seçeneklerini getiren detaylı sorgu
                return await _context.Exams
                    .Include(e => e.ExamQuestions)
                        .ThenInclude(eq => eq.Question)
                            .ThenInclude(q => q.QuestionsOptions)
                    .FirstOrDefaultAsync(e => e.Id == examId);
            }

            public async Task<bool> IsUserRegisteredForExam(Guid userId, Guid examId)
            {
                // Verilen kullanıcının sınava kayıtlı olup olmadığını kontrol eder
                return await _context.ExamParticipants
                    .AnyAsync(p => p.UserId == userId && p.ExamId == examId);
            }

            public async Task<ExamParticipant> GetParticipantAsync(Guid userId, Guid examId)
            {
                // Belirli bir katılımcı kaydını getirir
                return await _context.ExamParticipants
                    .FirstOrDefaultAsync(p => p.UserId == userId && p.ExamId == examId);
            }

            public async Task AddParticipantAsync(ExamParticipant participant)
            {
                // Yeni bir katılımcı kaydı ekler
                await _context.ExamParticipants.AddAsync(participant);
            }

            public void UpdateParticipant(ExamParticipant participant)
            {
                // Mevcut bir katılımcı kaydını günceller
                _context.ExamParticipants.Update(participant);
            }

                    public async Task<List<Exam>> GetUserExamHistoryAsync(Guid userId)
        {
            return await _context.Exams
                .Include(e => e.UserAnswers.Where(ua => ua.UserId == userId))
                .Where(e => e.Participants.Any(p => p.UserId == userId))
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Exam>> GetUserRegisteredExamsAsync(Guid userId)
        {
            return await _context.Exams
                .Include(e => e.Participants)
                .Where(e => e.Participants.Any(p => p.UserId == userId && p.Status == ExamParticipationStatus.Registered))
                .OrderBy(e => e.StartTime)
                .ToListAsync();
        }
        }
}
