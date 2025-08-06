using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.Repositories
{
    public class UserPerformanceSummariesRepository : GenericRepository<UserPerformanceSummaries>, IUserPerformanceSummariesRepository
    {
        private readonly AppDbContext _context;

        public UserPerformanceSummariesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserPerformanceSummaries?> GetByUserIdAndTopicIdAsync(Guid userId, Guid topicId)
        {
            return await _context.UserPerformanceSummaries
                .FirstOrDefaultAsync(p => p.UserId == userId && p.TopicId == topicId);
        }

        public async Task<List<UserPerformanceSummaries>> GetAllSummariesForUserAsync(Guid userId)
        {
            return await _context.UserPerformanceSummaries
                .Where(p => p.UserId == userId)
                .Include(p => p.Topic) 
                .OrderBy(p => (double)p.CorrectAnswers / p.TotalQuestionsAnswered) 
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<UserPerformanceSummaries>> GetWeakestTopicsForUserAsync(Guid userId, int count = 5)
        {
            return await _context.UserPerformanceSummaries
                .Where(p => p.UserId == userId && p.TotalQuestionsAnswered > 5) 
                .Include(p => p.Topic)
                .OrderBy(p => (double)p.CorrectAnswers / p.TotalQuestionsAnswered)
                .Take(count) 
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UserPerformanceSummaries?> GetUserPerformanceSummaryByUserIdAsync(Guid userId)
        {
            return await _context.UserPerformanceSummaries
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task<List<UserPerformanceSummaries>> GetUserPerformanceSummariesByUserIdAsync(Guid userId)
        {
            return await _context.UserPerformanceSummaries
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserPerformanceSummaries?> GetUserPerformanceSummaryByUserAndTopicAsync(Guid userId, Guid topicId)
        {
            return await _context.UserPerformanceSummaries
                .FirstOrDefaultAsync(p => p.UserId == userId && p.TopicId == topicId);
        }
    }
}
