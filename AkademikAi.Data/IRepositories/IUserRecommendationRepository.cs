using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface IUserRecommendationRepository : IGenericRepository<UserRecommendation>
    {
        Task<List<UserRecommendation>> GetActiveRecommendationsForUserAsync(Guid userId);
        Task<bool> HasActiveRecommendationForTopicAsync(Guid userId, Guid topicId, int recommendationType);
        Task<List<UserRecommendation>> GetRecommendationsByTypeAsync(int recommendationType);
        Task<List<UserRecommendation>> GetUserRecommendationsByUserIdAsync(Guid userId);
    }
}
