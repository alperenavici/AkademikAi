using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class QuestionService : GenericService<Questions>, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionOptionsRepository _questionOptionsRepository;
        private readonly IQuestionTopicRepository _questionTopicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(
            IQuestionRepository questionRepository,
            IQuestionOptionsRepository questionOptionsRepository,
            IQuestionTopicRepository questionTopicRepository,
            IUnitOfWork unitOfWork) : base(questionRepository)
        {
            _questionRepository = questionRepository;
            _questionOptionsRepository = questionOptionsRepository;
            _questionTopicRepository = questionTopicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ActivateQuestionAsync(Guid questionId)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(questionId);
            if (question == null) return false;

            question.IsActive = true;
            _questionRepository.Update(question);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Questions> CreateQuestionAsync(Questions question, List<Guid> topicIds, List<string> options)
        {
            question.Id = Guid.NewGuid();
            question.IsActive = true;

            await _questionRepository.AddAsync(question);

            // Add question options
            if (options != null && options.Any())
            {
                var questionOptions = options.Select((option, index) => new QuestionsOptions
                {
                    Id = Guid.NewGuid(),
                    QuestionId = question.Id,
                    OptionText = option,
                    IsCorrect = index == 0, // First option is correct by default
                    OptionOrder = index + 1
                }).ToList();

                await _questionOptionsRepository.AddRangeAsync(questionOptions);
            }

            // Add question topics
            if (topicIds != null && topicIds.Any())
            {
                var questionTopics = topicIds.Select(topicId => new QuestionsTopic
                {
                    Id = Guid.NewGuid(),
                    QuestionId = question.Id,
                    TopicId = topicId
                }).ToList();

                await _questionTopicRepository.AddRangeAsync(questionTopics);
            }

            await _unitOfWork.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeactivateQuestionAsync(Guid questionId)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(questionId);
            if (question == null) return false;

            question.IsActive = false;
            _questionRepository.Update(question);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<Questions>> GetActiveQuestionsAsync()
        {
            return await _questionRepository.GetActiveQuestionsAsync();
        }

        public async Task<Questions> GetQuestionByIdAsync(Guid questionId)
        {
            return await _questionRepository.GetQuestionByIdAsync(questionId);
        }

        public async Task<List<Questions>> GetQuestionsByDifficultyAsync(QuestionsDiff difficultyLevel)
        {
            return await _questionRepository.GetQuestionsByDifficultyAsync(difficultyLevel);
        }

        public async Task<List<Questions>> GetQuestionsByQuestionTextAsync(string questionText)
        {
            return await _questionRepository.GetQuestionsByQuestionTextAsync(questionText);
        }

        public async Task<List<Questions>> GetQuestionsBySolutionTextAsync(string solutionText)
        {
            return await _questionRepository.GetQuestionsBySolutionTextAsync(solutionText);
        }

        public async Task<List<Questions>> GetQuestionsBySourceAsync(string source)
        {
            return await _questionRepository.GetQuestionsBySourceAsync(source);
        }

        public async Task<List<Questions>> GetQuestionsByTopicIdAsync(Guid topicId)
        {
            return await _questionRepository.GetQuestionsByTopicIdAsync(topicId);
        }

        public async Task<List<Questions>> GetQuestionsByUserIdAsync(Guid userId)
        {
            return await _questionRepository.GetQuestionsByUserIdAsync(userId);
        }

        public async Task<List<Questions>> GetQuestionsByUserIdAndDifficultyAsync(Guid userId, QuestionsDiff difficultyLevel)
        {
            return await _questionRepository.GetQuestionsByUserIdAndDifficultyAsync(userId, difficultyLevel);
        }

        public async Task<List<Questions>> GetQuestionsByUserIdAndSourceAsync(Guid userId, string source)
        {
            return await _questionRepository.GetQuestionsByUserIdAndSourceAsync(userId, source);
        }

        public async Task<List<Questions>> GetQuestionsForUserAsync(Guid userId, int count, QuestionsDiff? difficultyLevel = null)
        {
            var questions = await _questionRepository.GetQuestionsByUserIdAsync(userId);
            
            if (difficultyLevel.HasValue)
            {
                questions = questions.Where(q => q.DifficultyLevel == difficultyLevel.Value).ToList();
            }

            return questions.Take(count).ToList();
        }

        public async Task<List<Questions>> GetRandomQuestionsAsync(int count, QuestionsDiff? difficultyLevel = null, Guid? topicId = null)
        {
            var questions = await _questionRepository.GetActiveQuestionsAsync();

            if (difficultyLevel.HasValue)
            {
                questions = questions.Where(q => q.DifficultyLevel == difficultyLevel.Value).ToList();
            }

            if (topicId.HasValue)
            {
                questions = questions.Where(q => q.QuestionsTopics.Any(qt => qt.TopicId == topicId.Value)).ToList();
            }

            var random = new Random();
            return questions.OrderBy(x => random.Next()).Take(count).ToList();
        }

        public async Task<bool> UpdateQuestionAsync(Questions question, List<Guid> topicIds, List<string> options)
        {
            var existingQuestion = await _questionRepository.GetQuestionByIdAsync(question.Id);
            if (existingQuestion == null) return false;

            // Update question properties
            existingQuestion.QuestionText = question.QuestionText;
            existingQuestion.DifficultyLevel = question.DifficultyLevel;
            existingQuestion.Source = question.Source;
            existingQuestion.SolutionText = question.SolutionText;
            existingQuestion.IsActive = question.IsActive;

            _questionRepository.Update(existingQuestion);

            // Update options if provided
            if (options != null && options.Any())
            {
                // Remove existing options
                var existingOptions = await _questionOptionsRepository.GetWhereAsync(qo => qo.QuestionId == question.Id);
                _questionOptionsRepository.RemoveRange(existingOptions);

                // Add new options
                var newOptions = options.Select((option, index) => new QuestionsOptions
                {
                    Id = Guid.NewGuid(),
                    QuestionId = question.Id,
                    OptionText = option,
                    IsCorrect = index == 0,
                    OptionOrder = index + 1
                }).ToList();

                await _questionOptionsRepository.AddRangeAsync(newOptions);
            }

            // Update topics if provided
            if (topicIds != null && topicIds.Any())
            {
                // Remove existing topic associations
                var existingTopics = await _questionTopicRepository.GetWhereAsync(qt => qt.QuestionId == question.Id);
                _questionTopicRepository.RemoveRange(existingTopics);

                // Add new topic associations
                var newTopics = topicIds.Select(topicId => new QuestionsTopic
                {
                    Id = Guid.NewGuid(),
                    QuestionId = question.Id,
                    TopicId = topicId
                }).ToList();

                await _questionTopicRepository.AddRangeAsync(newTopics);
            }

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
} 