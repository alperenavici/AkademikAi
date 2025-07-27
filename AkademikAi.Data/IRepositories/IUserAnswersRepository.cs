using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface IUserAnswersRepository : IGenericRepository<UserAnswers>
    {
        Task<List<UserAnswers>> GetUserAnswersByQuestionIdAsync(Guid questionId);
        Task<List<UserAnswers>> GetUserAnswersByUserIdAsync(Guid userId);
        Task<UserAnswers> GetUserAnswerByIdAsync(Guid userAnswerId);
        Task<List<UserAnswers>> GetUserAnswerByUserAndQuestionAsync(Guid userId, Guid questionId);
        Task<List<UserAnswers>> GetUserAnswersByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate);
        Task<List<UserAnswers>> GetUserAnswersByQuestionTextAsync(string questionText);
    }
}
