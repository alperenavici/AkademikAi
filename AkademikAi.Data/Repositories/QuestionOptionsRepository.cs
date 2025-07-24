using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using Microsoft.EntityFrameworkCore;

namespace AkademikAi.Data.Repositories
{
    public class QuestionOptionsRepository:GenericRepository<Entity.Entites.QuestionsOptions>
    {
        private readonly AppDbContext _context;
        public QuestionOptionsRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<QuestionsOptions>>GetQuestionsOptionsbyQuestionIdAsync(Guid questionId)
        {
            return _context.QuestionsOptions
                .Where(qo => qo.QuestionId == questionId)
                .ToListAsync();
        }

        public Task<QuestionsOptions> GetQuestionOptionByIdAsync(Guid optionId)
        {
            return _context.QuestionsOptions
                .FirstOrDefaultAsync(qo => qo.Id == optionId);
        }

        public Task<List<QuestionsOptions>> GetQuestionsOptionsByLabelAsync(char label)
        {
            return _context.QuestionsOptions
                .Where(qo => qo.Label == label)
                .ToListAsync();
        }





    }
}
