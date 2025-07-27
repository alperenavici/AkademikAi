using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface IUserRecommendationService : IGenericService<UserRecommendation>
    {
        Task<List<UserRecommendation>> GetUserRecommendationsAsync(Guid userId);
        Task<UserRecommendation> GetLatestUserRecommendationAsync(Guid userId);
        Task<List<UserRecommendation>> GetUserRecommendationsByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate);
        Task<List<UserRecommendation>> GetActiveRecommendationsForUserAsync(Guid userId);
        Task<List<UserRecommendation>> GetRecommendationsByTypeAsync(int recommendationType);
        Task<bool> HasActiveRecommendationForTopicAsync(Guid userId, Guid topicId, int recommendationType);
        
        Task<UserRecommendation> CreateRecommendationAsync(Guid userId, string recommendationText, int recommendationType);
        Task<bool> UpdateRecommendationAsync(Guid recommendationId, string recommendationText);
        Task<bool> MarkRecommendationAsReadAsync(Guid recommendationId);
        Task<bool> MarkRecommendationAsAppliedAsync(Guid recommendationId);
        Task<List<UserRecommendation>> GetUnreadRecommendationsAsync(Guid userId);
        Task<List<UserRecommendation>> GetAppliedRecommendationsAsync(Guid userId);
        Task<bool> DeleteRecommendationAsync(Guid recommendationId);
    }
} 