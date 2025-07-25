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
    public class UserRecommendationRepository : GenericRepository<UserRecommendation>, IUserRecommendationRepository
    {
        private readonly AppDbContext _context;

        public UserRecommendationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<UserRecommendation>> GetActiveRecommendationsForUserAsync(Guid userId)
        {
            var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);

            return await _context.UserRecommendations
                .Where(r => r.UserId == userId && r.CreatedAt >= sevenDaysAgo)
                .Include(r => r.Topic)
                .OrderByDescending(r => r.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> HasActiveRecommendationForTopicAsync(Guid userId, Guid topicId, int recommendationType)
        {
            var oneWeekAgo = DateTime.UtcNow.AddDays(-7);

            return await _context.UserRecommendations
                .AnyAsync(r => r.UserId == userId &&
                               r.RelatedTopicId == topicId &&
                               r.RecommendationType == recommendationType &&
                               r.CreatedAt > oneWeekAgo);
        }

        public async Task<List<UserRecommendation>> GetRecommendationsByTypeAsync(int recommendationType)
        {
            return await _context.UserRecommendations
                .Where(r => r.RecommendationType == recommendationType)
                .AsNoTracking()
                .ToListAsync();
        }
    }

}
