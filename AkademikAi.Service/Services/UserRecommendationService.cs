using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class UserRecommendationService : GenericService<UserRecommendation>, IUserRecommendationService
    {
        private readonly IUserRecommendationRepository _recommendationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRecommendationService(
            IUserRecommendationRepository recommendationRepository,
            IUnitOfWork unitOfWork) : base(recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserRecommendation> CreateRecommendationAsync(Guid userId, string recommendationText, int recommendationType)
        {
            var recommendation = new UserRecommendation
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                RecommendationText = recommendationText,
                RecommendationType = recommendationType,
                IsRead = false,
                IsApplied = false,
                CreatedAt = DateTime.UtcNow
            };

            await _recommendationRepository.AddAsync(recommendation);
            await _unitOfWork.SaveChangesAsync();
            return recommendation;
        }

        public async Task<List<UserRecommendation>> GetActiveRecommendationsForUserAsync(Guid userId)
        {
            var recommendations = await _recommendationRepository.GetUserRecommendationsByUserIdAsync(userId);
            return recommendations.Where(r => !r.IsApplied).ToList();
        }

        public async Task<List<UserRecommendation>> GetRecommendationsByTypeAsync(int recommendationType)
        {
            var recommendations = await _recommendationRepository.GetRecommendationsByTypeAsync(recommendationType);
            return recommendations;
        }

        public async Task<bool> HasActiveRecommendationForTopicAsync(Guid userId, Guid topicId, int recommendationType)
        {
            return await _recommendationRepository.HasActiveRecommendationForTopicAsync(userId, topicId, recommendationType);
        }

        public async Task<bool> DeleteRecommendationAsync(Guid recommendationId)
        {
            var recommendation = await _recommendationRepository.GetByIdAsync(recommendationId);
            if (recommendation == null) return false;

            _recommendationRepository.Remove(recommendation);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserRecommendation>> GetAppliedRecommendationsAsync(Guid userId)
        {
            var recommendations = await _recommendationRepository.GetUserRecommendationsByUserIdAsync(userId);
            return recommendations.Where(r => r.IsApplied).ToList();
        }

        public async Task<UserRecommendation> GetLatestUserRecommendationAsync(Guid userId)
        {
            var recommendations = await _recommendationRepository.GetUserRecommendationsByUserIdAsync(userId);
            return recommendations.OrderByDescending(r => r.CreatedAt).FirstOrDefault();
        }

        public async Task<List<UserRecommendation>> GetUnreadRecommendationsAsync(Guid userId)
        {
            var recommendations = await _recommendationRepository.GetUserRecommendationsByUserIdAsync(userId);
            return recommendations.Where(r => !r.IsRead).ToList();
        }

        public async Task<List<UserRecommendation>> GetUserRecommendationsAsync(Guid userId)
        {
            return await _recommendationRepository.GetUserRecommendationsByUserIdAsync(userId);
        }

        public async Task<List<UserRecommendation>> GetUserRecommendationsByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate)
        {
            var recommendations = await _recommendationRepository.GetUserRecommendationsByUserIdAsync(userId);
            return recommendations.Where(r => r.CreatedAt >= startDate && r.CreatedAt <= endDate).ToList();
        }

        public async Task<bool> MarkRecommendationAsAppliedAsync(Guid recommendationId)
        {
            var recommendation = await _recommendationRepository.GetByIdAsync(recommendationId);
            if (recommendation == null) return false;

            recommendation.IsApplied = true;
            recommendation.AppliedAt = DateTime.UtcNow;

            _recommendationRepository.Update(recommendation);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkRecommendationAsReadAsync(Guid recommendationId)
        {
            var recommendation = await _recommendationRepository.GetByIdAsync(recommendationId);
            if (recommendation == null) return false;

            recommendation.IsRead = true;
            recommendation.ReadAt = DateTime.UtcNow;

            _recommendationRepository.Update(recommendation);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRecommendationAsync(Guid recommendationId, string recommendationText)
        {
            var recommendation = await _recommendationRepository.GetByIdAsync(recommendationId);
            if (recommendation == null) return false;

            recommendation.RecommendationText = recommendationText;

            _recommendationRepository.Update(recommendation);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
} 