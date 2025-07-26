using AkademikAi.Data.Context;
using Microsoft.EntityFrameworkCore;
using AkademikAi.Entity.Entites;
using AkademikAi.Data.IRepositories;


namespace AkademikAi.Data.Repositories
{
    public class UserAnswerRepository:GenericRepository<UserAnswers>, IUserAnswersRepository
    {

        private readonly AppDbContext _context;
        public UserAnswerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<UserAnswers>> GetUserAnswersByQuestionIdAsync(Guid questionId)
        {
            return await _context.UserAnswers
                .Where(ua => ua.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task<List<UserAnswers>> GetUserAnswersByUserIdAsync(Guid userId)
        {
            return await _context.UserAnswers
                .Where(ua => ua.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserAnswers> GetUserAnswerByIdAsync(Guid userAnswerId)
        {
            return await _context.UserAnswers
                .FirstOrDefaultAsync(ua => ua.Id == userAnswerId);
        }

        public async Task<List<UserAnswers>> GetUserAnswersByQuestionTextAsync(string questionText)
        {
            return await _context.UserAnswers
                .Include(ua => ua.Question)
                .Where(ua => ua.Question.QuestionText.Contains(questionText))
                .ToListAsync();
        }




    }
}
