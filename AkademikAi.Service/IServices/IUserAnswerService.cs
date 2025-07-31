using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface IUserAnswerService : IGenericService<UserAnswers>
    {
        Task<List<UserAnswers>> GetUserAnswersByUserIdAsync(Guid userId);
        Task<List<UserAnswers>> GetUserAnswersByQuestionIdAsync(Guid questionId);
        Task<List<UserAnswers>> GetUserAnswerByUserAndQuestionAsync(Guid userId, Guid questionId);
        Task<List<UserAnswers>> GetUserAnswersByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate);
        
        Task<UserAnswers> SubmitAnswerAsync(Guid userId, Guid questionId, Guid selectedOptionId, bool isCorrect);
        Task<bool> UpdateAnswerAsync(Guid answerId, Guid selectedOptionId, bool isCorrect);
        Task<double> GetAppUseruccessRateAsync(Guid userId);
        Task<double> GetAppUseruccessRateByTopicAsync(Guid userId, Guid topicId);
        Task<double> GetAppUseruccessRateByDifficultyAsync(Guid userId, int difficultyLevel);
        Task<List<UserAnswers>> GetUserRecentAnswersAsync(Guid userId, int count = 10);
        Task<Dictionary<string, double>> GetUserPerformanceByTopicAsync(Guid userId);
    }
} 