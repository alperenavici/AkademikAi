using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class UserAnswerService : GenericService<UserAnswers>, IUserAnswerService
    {
        private readonly IUserAnswersRepository _userAnswersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserAnswerService(
            IUserAnswersRepository userAnswersRepository,
            IUnitOfWork unitOfWork) : base(userAnswersRepository)
        {
            _userAnswersRepository = userAnswersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Dictionary<string, double>> GetUserPerformanceByTopicAsync(Guid userId)
        {
            var userAnswers = await _userAnswersRepository.GetUserAnswersByUserIdAsync(userId);
            var performanceByTopic = new Dictionary<string, double>();

            // Group answers by topic and calculate success rate
            var groupedAnswers = userAnswers
                .Where(ua => ua.Question?.QuestionsTopics != null)
                .SelectMany(ua => ua.Question.QuestionsTopics.Select(qt => new
                {
                    TopicName = qt.Topic?.TopicName ?? "Unknown",
                    IsCorrect = ua.IsCorrect
                }))
                .GroupBy(x => x.TopicName)
                .Select(g => new
                {
                    TopicName = g.Key,
                    SuccessRate = g.Count(x => x.IsCorrect) * 100.0 / g.Count()
                });

            foreach (var group in groupedAnswers)
            {
                performanceByTopic[group.TopicName] = group.SuccessRate;
            }

            return performanceByTopic;
        }

        public async Task<List<UserAnswers>> GetUserRecentAnswersAsync(Guid userId, int count = 10)
        {
            var answers = await _userAnswersRepository.GetUserAnswersByUserIdAsync(userId);
            return answers.OrderByDescending(ua => ua.AnsweredAt).Take(count).ToList();
        }

        public async Task<double> GetAppUseruccessRateAsync(Guid userId)
        {
            var answers = await _userAnswersRepository.GetUserAnswersByUserIdAsync(userId);
            if (!answers.Any()) return 0;

            var correctAnswers = answers.Count(ua => ua.IsCorrect);
            return (double)correctAnswers / answers.Count * 100;
        }

        public async Task<double> GetAppUseruccessRateByDifficultyAsync(Guid userId, int difficultyLevel)
        {
            var answers = await _userAnswersRepository.GetUserAnswersByUserIdAsync(userId);
            var filteredAnswers = answers.Where(ua => (int)ua.Question.DifficultyLevel == difficultyLevel).ToList();

            if (!filteredAnswers.Any()) return 0;

            var correctAnswers = filteredAnswers.Count(ua => ua.IsCorrect);
            return (double)correctAnswers / filteredAnswers.Count * 100;
        }

        public async Task<double> GetAppUseruccessRateByTopicAsync(Guid userId, Guid topicId)
        {
            var answers = await _userAnswersRepository.GetUserAnswersByUserIdAsync(userId);
            var filteredAnswers = answers.Where(ua => ua.Question?.QuestionsTopics?.Any(qt => qt.TopicId == topicId) == true).ToList();

            if (!filteredAnswers.Any()) return 0;

            var correctAnswers = filteredAnswers.Count(ua => ua.IsCorrect);
            return (double)correctAnswers / filteredAnswers.Count * 100;
        }

        public async Task<List<UserAnswers>> GetUserAnswerByUserAndQuestionAsync(Guid userId, Guid questionId)
        {
            return await _userAnswersRepository.GetUserAnswerByUserAndQuestionAsync(userId, questionId);
        }

        public async Task<List<UserAnswers>> GetUserAnswersByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate)
        {
            return await _userAnswersRepository.GetUserAnswersByDateRangeAsync(userId, startDate, endDate);
        }

        public async Task<List<UserAnswers>> GetUserAnswersByQuestionIdAsync(Guid questionId)
        {
            return await _userAnswersRepository.GetUserAnswersByQuestionIdAsync(questionId);
        }

        public async Task<List<UserAnswers>> GetUserAnswersByUserIdAsync(Guid userId)
        {
            return await _userAnswersRepository.GetUserAnswersByUserIdAsync(userId);
        }

        public async Task<UserAnswers> SubmitAnswerAsync(Guid userId, Guid questionId, Guid selectedOptionId, bool isCorrect)
        {
            var userAnswer = new UserAnswers
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                QuestionId = questionId,
                SelectedOptionId = selectedOptionId,
                IsCorrect = isCorrect,
                AnsweredAt = DateTime.UtcNow
            };

            await _userAnswersRepository.AddAsync(userAnswer);
            await _unitOfWork.SaveChangesAsync();
            return userAnswer;
        }

        public async Task<bool> UpdateAnswerAsync(Guid answerId, Guid selectedOptionId, bool isCorrect)
        {
            var answer = await _userAnswersRepository.GetByIdAsync(answerId);
            if (answer == null) return false;

            answer.SelectedOptionId = selectedOptionId;
            answer.IsCorrect = isCorrect;

            _userAnswersRepository.Update(answer);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
} 