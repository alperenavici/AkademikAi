using AkademikAi.Data.Context;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface IQuestionRepository : IGenericRepository<Questions>
    {
        Task<List<Questions>> GetQuestionsByTopicIdAsync(Guid topicId);
        Task<List<Questions>> GetQuestionsByUserIdAsync(Guid userId);
        Task<List<Questions>> GetActiveQuestionsAsync();
        Task<List<Questions>> GetRandomQuestionsByCriteriaAsync(Guid topicId, QuestionsDiff difficulty, int count);
        Task<Questions?> GetQuestionByIdAsync(Guid questionId);
        Task<List<Questions>> GetQuestionsByIdsAsync(List<Guid> questionIds);

        Task<List<Questions>> GetQuestionsByDifficultyAsync(QuestionsDiff DiffucultyDifficultyLevel);
        Task<List<Questions>> GetQuestionsBySourceAsync(string source);
        Task<List<Questions>> GetQuestionsByUserIdAndDifficultyAsync(Guid userId,QuestionsDiff DiffucultyDiffucultyLevel);
        Task<List<Questions>> GetQuestionsByUserIdAndSourceAsync(Guid userId,string source);
        Task<List<Questions>> GetQuestionsByQuestionTextAsync(string questionText);
        Task<List<Questions>> GetQuestionsBySolutionTextAsync(string solutionText);
        Task<List<Questions>> GetQuestionsForUserAsync(Guid userId, int count, QuestionsDiff? difficultyLevel = null);
        Task<List<Questions>> GetRandomQuestionsAsync(int count, QuestionsDiff? difficultyLevel = null, Guid? topicId = null);
    }
    }
