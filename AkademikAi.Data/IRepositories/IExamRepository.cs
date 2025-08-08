using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface IExamRepository:IGenericRepository<Exam>
    {
        // Raporlama ve Listeleme Sorguları
        Task<Exam> GetExamWithQuestionsAndOptionsAsync(Guid examId);
        Task<List<Exam>> GetActiveAndUpcomingExamsAsync();
        Task<List<Exam>> GetUserExamHistoryAsync(Guid userId);
        Task<List<Exam>> GetUserRegisteredExamsAsync(Guid userId);

        Task<bool> IsUserRegisteredForExam(Guid userId, Guid examId);
        Task<ExamParticipant> GetParticipantAsync(Guid userId, Guid examId);

        Task AddParticipantAsync(ExamParticipant participant);
        void UpdateParticipant(ExamParticipant participant);
    }
}
