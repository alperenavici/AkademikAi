using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class TopicService : GenericService<Topics>, ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IQuestionTopicRepository _questionTopicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TopicService(
            ITopicRepository topicRepository,
            IQuestionTopicRepository questionTopicRepository,
            IUnitOfWork unitOfWork) : base(topicRepository)
        {
            _topicRepository = topicRepository;
            _questionTopicRepository = questionTopicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Topics> CreateTopicAsync(string topicName, Guid? parentTopicId = null)
        {
            var topic = new Topics
            {
                Id = Guid.NewGuid(),
                TopicName = topicName,
                ParentTopicId = parentTopicId
            };

            await _topicRepository.AddAsync(topic);
            await _unitOfWork.SaveChangesAsync();
            return topic;
        }

        public async Task<bool> DeleteTopicAsync(Guid topicId)
        {
            var topic = await _topicRepository.GetByIdAsync(topicId);
            if (topic == null) return false;

            // Check if topic has sub-topics
            var subTopics = await GetSubTopicsAsync(topicId);
            if (subTopics.Any()) return false; // Cannot delete topic with sub-topics

            // Check if topic has questions
            var questionTopics = await _questionTopicRepository.GetWhereAsync(qt => qt.TopicId == topicId);
            if (questionTopics.Any()) return false; // Cannot delete topic with questions

            _topicRepository.Remove(topic);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Dictionary<string, int>> GetAveragePerformanceByTopicAsync()
        {
            // This would typically involve joining with user answers and calculating averages
            // For now, returning empty dictionary as placeholder
            return new Dictionary<string, int>();
        }

        public async Task<List<Topics>> GetMainTopicsAsync()
        {
            return await _topicRepository.GetWhereAsync(t => t.ParentTopicId == null);
        }

        public async Task<List<Topics>> GetPerformanceSummariesBySuccessRateRangeAsync(double minRate, double maxRate)
        {
            // This would typically involve complex queries with user performance data
            // For now, returning empty list as placeholder
            return new List<Topics>();
        }

        public async Task<List<Topics>> GetSubTopicsAsync(Guid parentTopicId)
        {
            return await _topicRepository.GetWhereAsync(t => t.ParentTopicId == parentTopicId);
        }

        public async Task<List<Topics>> GetTopicHierarchyAsync()
        {
            // This would return a hierarchical structure of topics
            // For now, returning empty list as placeholder
            return new List<Topics>();
        }

        public async Task<List<Topics>> GetTopicsByQuestionCountAsync(int minQuestionCount = 0)
        {
            var topics = await _topicRepository.GetAllAsync();
            var topicsWithCount = new List<Topics>();

            foreach (var topic in topics)
            {
                var questionCount = await _questionTopicRepository.CountAsync(qt => qt.TopicId == topic.Id);
                if (questionCount >= minQuestionCount)
                {
                    topicsWithCount.Add(topic);
                }
            }

            return topicsWithCount;
        }

        public async Task<Dictionary<string, int>> GetTopicQuestionCountsAsync()
        {
            var topics = await _topicRepository.GetAllAsync();
            var topicCounts = new Dictionary<string, int>();

            foreach (var topic in topics)
            {
                var count = await _questionTopicRepository.CountAsync(qt => qt.TopicId == topic.Id);
                topicCounts[topic.TopicName] = count;
            }

            return topicCounts;
        }

        public async Task<Topics> GetTopicWithSubTopicsAsync(Guid topicId)
        {
            var topic = await _topicRepository.GetByIdAsync(topicId);
            if (topic == null) return null;

            // Load sub-topics
            var subTopics = await GetSubTopicsAsync(topicId);
            // Note: In a real implementation, you might want to use navigation properties
            // or implement a more sophisticated loading mechanism

            return topic;
        }

        public async Task<List<Topics>> GetTopPerformersAsync(int count = 10)
        {
            // This would typically involve complex queries with user performance data
            // For now, returning empty list as placeholder
            return new List<Topics>();
        }

        public async Task<bool> UpdateTopicAsync(Guid topicId, string topicName, Guid? parentTopicId = null)
        {
            var topic = await _topicRepository.GetByIdAsync(topicId);
            if (topic == null) return false;

            topic.TopicName = topicName;
            topic.ParentTopicId = parentTopicId ?? Guid.Empty;

            _topicRepository.Update(topic);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
} 