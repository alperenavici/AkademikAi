using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using Microsoft.EntityFrameworkCore;
using AkademikAi.Entity.Enums;


namespace AkademikAi.Data.Repositories
{
    public class QuestionTopicRepository : GenericRepository<QuestionsTopic>, IQuestionTopicRepository
    {
        private readonly AppDbContext _context;
        public QuestionTopicRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<QuestionsTopic>> GetTopicsByQuestionIdAsync(Guid questionId)
        {
            return _context.QuestionsTopics
                .Where(qt => qt.QuestionId == questionId)
                .ToListAsync();
        }

        public Task<List<QuestionsTopic>> GetQuestionsByTopicIdAsync(Guid topicId)
        {
            return _context.QuestionsTopics
                .Where(qt => qt.TopicId == topicId)
                .ToListAsync();
        }

        public Task<QuestionsTopic?> GetQuestionTopicByIdAsync(Guid questionId)
        {
            return _context.QuestionsTopics
                .FirstOrDefaultAsync(qt => qt.QuestionId == questionId);
        }


        public Task<List<QuestionsTopic>> GetQuestionsTopicsByQuestionTextAsync(string questionText)
        {
            return _context.QuestionsTopics
                .Include(qt => qt.Question)
                .Where(qt => qt.Question.QuestionText.Contains(questionText))
                .ToListAsync();

        }


    }
}
