using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class UserPerformanceSummaryService : GenericService<UserPerformanceSummaries>, IUserPerformanceSummaryService
    {
        private readonly IUserPerformanceSummariesRepository _performanceRepository;
        private readonly IUserAnswersRepository _userAnswersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserPerformanceSummaryService(
            IUserPerformanceSummariesRepository performanceRepository,
            IUserAnswersRepository userAnswersRepository,
            IUnitOfWork unitOfWork) : base(performanceRepository)
        {
            _performanceRepository = performanceRepository;
            _userAnswersRepository = userAnswersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Dictionary<string, double>> GetAveragePerformanceByTopicAsync()
        {
            var allSummaries = await _performanceRepository.GetAllAsync();
            var averageByTopic = new Dictionary<string, double>();

            // This would typically involve more complex calculations
            // For now, returning empty dictionary as placeholder
            return averageByTopic;
        }

        public async Task<List<UserPerformanceSummaries>> GetPerformanceSummariesBySuccessRateRangeAsync(double minRate, double maxRate)
        {
            var summaries = await _performanceRepository.GetAllAsync();
            return summaries.Where(s => s.SuccessRate >= minRate && s.SuccessRate <= maxRate).ToList();
        }

        public async Task<List<UserPerformanceSummaries>> GetTopPerformersAsync(int count = 10)
        {
            var summaries = await _performanceRepository.GetAllAsync();
            return summaries.OrderByDescending(s => s.SuccessRate).Take(count).ToList();
        }

        public async Task<UserPerformanceSummaries> GetLatestUserPerformanceSummaryAsync(Guid userId)
        {
            var summaries = await _performanceRepository.GetUserPerformanceSummariesByUserIdAsync(userId);
            return summaries.OrderByDescending(s => s.CreatedAt).FirstOrDefault();
        }

        public async Task<UserPerformanceSummaries> GetUserPerformanceSummaryAsync(Guid userId)
        {
            return await _performanceRepository.GetUserPerformanceSummaryByUserIdAsync(userId);
        }

        public async Task<List<UserPerformanceSummaries>> GetUserPerformanceSummariesByUserIdAsync(Guid userId)
        {
            return await _performanceRepository.GetUserPerformanceSummariesByUserIdAsync(userId);
        }

        public async Task<UserPerformanceSummaries> GetUserPerformanceSummaryByUserAndTopicAsync(Guid userId, Guid topicId)
        {
            return await _performanceRepository.GetUserPerformanceSummaryByUserAndTopicAsync(userId, topicId);
        }

        public async Task<List<UserPerformanceSummaries>> GetUserPerformanceSummariesByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate)
        {
            var summaries = await _performanceRepository.GetUserPerformanceSummariesByUserIdAsync(userId);
            return summaries.Where(s => s.CreatedAt >= startDate && s.CreatedAt <= endDate).ToList();
        }

        public async Task<UserPerformanceSummaries> CreateOrUpdatePerformanceSummaryAsync(Guid userId)
        {
            var userAnswers = await _userAnswersRepository.GetUserAnswersByUserIdAsync(userId);
            
            if (!userAnswers.Any())
            {
                return null;
            }

            var totalAnswers = userAnswers.Count;
            var correctAnswers = userAnswers.Count(ua => ua.IsCorrect);
            var successRate = (double)correctAnswers / totalAnswers * 100;

            var existingSummary = await _performanceRepository.GetUserPerformanceSummaryByUserIdAsync(userId);
            
            if (existingSummary != null)
            {
                existingSummary.TotalQuestionsAnswered = totalAnswers;
                existingSummary.CorrectAnswers = correctAnswers;
                existingSummary.SuccessRate = successRate;
                existingSummary.LastUpdatedAt = DateTime.UtcNow;

                _performanceRepository.Update(existingSummary);
                await _unitOfWork.SaveChangesAsync();
                return existingSummary;
            }
            else
            {
                var newSummary = new UserPerformanceSummaries
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    TotalQuestionsAnswered = totalAnswers,
                    CorrectAnswers = correctAnswers,
                    SuccessRate = successRate,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedAt = DateTime.UtcNow
                };

                await _performanceRepository.AddAsync(newSummary);
                await _unitOfWork.SaveChangesAsync();
                return newSummary;
            }
        }

        public async Task<bool> UpdatePerformanceSummaryAsync(UserPerformanceSummaries summary)
        {
            var existingSummary = await _performanceRepository.GetByIdAsync(summary.Id);
            if (existingSummary == null) return false;

            existingSummary.TotalQuestionsAnswered = summary.TotalQuestionsAnswered;
            existingSummary.CorrectAnswers = summary.CorrectAnswers;
            existingSummary.SuccessRate = summary.SuccessRate;
            existingSummary.LastUpdatedAt = DateTime.UtcNow;

            _performanceRepository.Update(existingSummary);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
} 