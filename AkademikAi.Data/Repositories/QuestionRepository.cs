using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using Microsoft.EntityFrameworkCore;

namespace AkademikAi.Data.Repositories
{
    public class QuestionRepository: GenericRepository<Questions>,IQuestionRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Questions> _dbSet;


        public QuestionRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<Questions>> GetQuestionsByTopicIdAsync(Guid topicId)
        {
            return _context.Questions
                .Where(q => q.QuestionsTopics.Any(qt => qt.TopicId == topicId))
                .ToListAsync();
        }

        public Task<List<Questions>> GetQuestionsByUserIdAsync(Guid userId)
        {
            return _context.Questions
                .Where(q => q.GeneratedForUserId == userId)
                .ToListAsync();
        }

        public Task<List<Questions>> GetActiveQuestionsAsync()
        {
            return _context.Questions
                .Where(q => q.IsActive)
                .ToListAsync();
        }

        public Task<Questions> GetQuestionByIdAsync(Guid questionId)
        {
            return _context.Questions
                .Include(q => q.QuestionsOptions)
                .Include(q => q.QuestionsTopics)
                .FirstOrDefaultAsync(q => q.Id == questionId);
        }

        public Task <List<Questions>>GetQuestionsByDifficultyAsync(QuestionsDiff DiffucultyDifficultyLevel)
        {
            return _context.Questions
                .Where(q => q.DifficultyLevel == DiffucultyDifficultyLevel)
                .ToListAsync();
        }

        public Task<List<Questions>>GetQuestionsBySourceAsync(string source)
                    {
            return _context.Questions
                .Where(q => q.Source == source)
                .ToListAsync();
        }

        public Task<List<Questions>> GetQuestionsByUserIdAndDifficultyAsync(Guid userId, QuestionsDiff difficulty)
        {
            return _context.Questions
                .Where(q => q.GeneratedForUserId == userId && q.DifficultyLevel == difficulty)
                .ToListAsync();
        }

        public Task<List<Questions>> GetQuestionsByUserIdAndSourceAsync(Guid userId, string source)
        {
            return _context.Questions
                .Where(q => q.GeneratedForUserId == userId && q.Source == source)
                .ToListAsync();
        }

        public Task<List<Questions>> GetQuestionsByQuestionTextAsync(string questionText)
        {
            return _context.Questions
                .Where(q => q.QuestionText.Contains(questionText))
                .ToListAsync();
        }

        public Task<List<Questions>>GetQuestionsBySolutionTextAsync(string solutionText)
        {
            return _context.Questions
                .Where(q => q.SolutionText.Contains(solutionText))
                .ToListAsync();
        }


    }
}
