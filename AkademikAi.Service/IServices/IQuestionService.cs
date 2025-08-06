using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface IQuestionService : IGenericService<Questions>
    {
        Task<List<Questions>> GetQuestionsByTopicIdAsync(Guid topicId);
        Task<List<Questions>> GetQuestionsByUserIdAsync(Guid userId);
        Task<List<Questions>> GetActiveQuestionsAsync();
        Task<Questions> GetQuestionByIdAsync(Guid questionId);
        Task<List<Questions>> GetQuestionsByIdsAsync(List<Guid> questionIds);
        Task<List<Questions>> GetQuestionsByDifficultyAsync(QuestionsDiff difficultyLevel);
        Task<List<Questions>> GetQuestionsBySourceAsync(string source);
        Task<List<Questions>> GetQuestionsByUserIdAndDifficultyAsync(Guid userId, QuestionsDiff difficultyLevel);
        Task<List<Questions>> GetQuestionsByUserIdAndSourceAsync(Guid userId, string source);
        Task<List<Questions>> GetQuestionsByQuestionTextAsync(string questionText);
        Task<List<Questions>> GetQuestionsBySolutionTextAsync(string solutionText);
        
        Task<Questions> CreateQuestionAsync(Questions question, List<Guid> topicIds, List<string> options);
        Task<bool> UpdateQuestionAsync(Questions question, List<Guid> topicIds, List<string> options);
        Task<bool> DeactivateQuestionAsync(Guid questionId);
        Task<bool> ActivateQuestionAsync(Guid questionId);
        Task<List<Questions>> GetRandomQuestionsAsync(int count, QuestionsDiff? difficultyLevel = null, Guid? topicId = null);
        Task<List<Questions>> GetQuestionsForUserAsync(Guid userId, int count, QuestionsDiff? difficultyLevel = null);
    }
} 