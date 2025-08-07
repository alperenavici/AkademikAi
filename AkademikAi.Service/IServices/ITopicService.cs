using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface ITopicService : IGenericService<Topics>
    {
        Task<List<Topics>> GetMainTopicsAsync();
        Task<List<Topics>> GetSubTopicsAsync(Guid parentTopicId);
        Task<List<Topics>> GetTopicsBySubjectIdAsync(Guid subjectId);
        Task<Topics?> GetTopicWithSubTopicsAsync(Guid topicId);
        List<Topics> GetTopicHierarchyAsync();
        
        Task<Topics> CreateTopicAsync(string topicName, Guid subjectId, Guid? parentTopicId = null);
        Task<bool> UpdateTopicAsync(Guid topicId, string topicName, Guid subjectId, Guid? parentTopicId = null);
        Task<bool> DeleteTopicAsync(Guid topicId);
        Task<List<Topics>> GetTopicsByQuestionCountAsync(int minQuestionCount = 0);
        Task<Dictionary<string, int>> GetTopicQuestionCountsAsync();
        Dictionary<string, int> GetAveragePerformanceByTopicAsync();
        List<Topics> GetPerformanceSummariesBySuccessRateRangeAsync(double minRate, double maxRate);
        List<Topics> GetTopPerformersAsync(int count = 10);
    }
} 