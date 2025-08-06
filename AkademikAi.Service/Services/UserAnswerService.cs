using AkademikAi.Core.DTOs;
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
        private readonly IQuestionService _questionService;
        private readonly IUserPerformanceSummaryService _performanceService;

        public UserAnswerService(
            IUserAnswersRepository userAnswersRepository,
            IUnitOfWork unitOfWork,
            IQuestionService questionService,
            IUserPerformanceSummaryService performanceService) : base(userAnswersRepository)
        {
            _userAnswersRepository = userAnswersRepository;
            _unitOfWork = unitOfWork;
            _questionService = questionService;
            _performanceService = performanceService;
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

        public async Task<ServiceResponse> SubmitUserAnswersAsync(Guid userId, List<UserAnswerDto> userAnswers)
        {
            try
            {
                if (userAnswers == null || !userAnswers.Any())
                {
                    return ServiceResponse.Failure("Cevap verisi bulunamadı");
                }

                // 1. Tüm soruların bilgilerini tek seferde çek
                var questionIds = userAnswers.Select(ua => ua.QuestionId).ToList();
                var questions = await _questionService.GetQuestionsByIdsAsync(questionIds);
                
                if (!questions.Any())
                {
                    return ServiceResponse.Failure("Sorular bulunamadı");
                }

                // 2. Kullanıcı cevaplarını hazırla
                var userAnswerEntities = new List<UserAnswers>();
                var performanceByTopic = new Dictionary<Guid, (int total, int correct)>();

                foreach (var userAnswer in userAnswers)
                {
                    var question = questions.FirstOrDefault(q => q.Id == userAnswer.QuestionId);
                    if (question == null) continue;

                    // Kullanıcı cevabını oluştur
                    var userAnswerEntity = new UserAnswers
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        QuestionId = userAnswer.QuestionId,
                        SelectedOptionId = userAnswer.SelectedOptionId ?? Guid.Empty, // Guid? to Guid conversion
                        IsCorrect = userAnswer.IsCorrect,
                        AnsweredAt = DateTime.UtcNow
                    };
                    userAnswerEntities.Add(userAnswerEntity);

                    // Konu bazında performans istatistiklerini topla
                    var questionTopics = question.QuestionsTopics;
                    foreach (var questionTopic in questionTopics)
                    {
                        var topicId = questionTopic.TopicId;
                        if (!performanceByTopic.ContainsKey(topicId))
                        {
                            performanceByTopic[topicId] = (0, 0);
                        }

                        var (total, correct) = performanceByTopic[topicId];
                        performanceByTopic[topicId] = (total + 1, correct + (userAnswer.IsCorrect ? 1 : 0));
                    }
                }

                // 3. Transaction içinde tüm işlemleri yap
                var transaction = await _unitOfWork.BeginTransactionAsync();
                try
                {
                    // UserAnswers'ları kaydet
                    foreach (var userAnswer in userAnswerEntities)
                    {
                        await _userAnswersRepository.AddAsync(userAnswer);
                    }

                    // UserPerformanceSummaries'leri güncelle
                    foreach (var (topicId, (total, correct)) in performanceByTopic)
                    {
                        var successRate = total > 0 ? (double)correct / total * 100 : 0;
                        
                        // Mevcut performans özetini kontrol et
                        var existingSummary = await _performanceService.GetUserPerformanceSummaryByUserAndTopicAsync(userId, topicId);
                        
                        if (existingSummary != null)
                        {
                            // Mevcut kaydı güncelle
                            existingSummary.TotalQuestionsAnswered += total;
                            existingSummary.CorrectAnswers += correct;
                            existingSummary.SuccessRate = Math.Round((double)existingSummary.CorrectAnswers / existingSummary.TotalQuestionsAnswered * 100, 2);
                            existingSummary.LastUpdatedAt = DateTime.UtcNow;
                            
                            _performanceService.Update(existingSummary);
                        }
                        else
                        {
                            // Yeni kayıt oluştur
                            var newSummary = new UserPerformanceSummaries
                            {
                                Id = Guid.NewGuid(),
                                UserId = userId,
                                TopicId = topicId,
                                TotalQuestionsAnswered = total,
                                CorrectAnswers = correct,
                                SuccessRate = Math.Round(successRate, 2),
                                CreatedAt = DateTime.UtcNow,
                                LastUpdatedAt = DateTime.UtcNow
                            };
                            
                            await _performanceService.AddAsync(newSummary);
                        }
                    }

                    await _unitOfWork.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return ServiceResponse.Success("Sorular başarıyla kaydedildi");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return ServiceResponse.Failure($"Veritabanı işlemi sırasında hata: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"İşlem sırasında hata: {ex.Message}");
            }
        }
    }
} 