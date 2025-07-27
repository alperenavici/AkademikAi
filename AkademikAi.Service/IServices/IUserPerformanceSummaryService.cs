using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface IUserPerformanceSummaryService : IGenericService<UserPerformanceSummaries>
    {
        Task<UserPerformanceSummaries> GetUserPerformanceSummaryAsync(Guid userId);
        Task<List<UserPerformanceSummaries>> GetUserPerformanceSummariesByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate);
        Task<UserPerformanceSummaries> GetLatestUserPerformanceSummaryAsync(Guid userId);
        
        Task<UserPerformanceSummaries> CreateOrUpdatePerformanceSummaryAsync(Guid userId);
        Task<bool> UpdatePerformanceSummaryAsync(UserPerformanceSummaries summary);
        Task<List<UserPerformanceSummaries>> GetTopPerformersAsync(int count = 10);
        Task<Dictionary<string, double>> GetAveragePerformanceByTopicAsync();
        Task<List<UserPerformanceSummaries>> GetPerformanceSummariesBySuccessRateRangeAsync(double minRate, double maxRate);
    }
} 