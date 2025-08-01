using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface IUserPerformanceSummariesRepository : IGenericRepository<UserPerformanceSummaries>
    {
        Task<UserPerformanceSummaries?> GetByUserIdAndTopicIdAsync(Guid userId, Guid topicId);
        Task<List<UserPerformanceSummaries>> GetAllSummariesForUserAsync(Guid userId);
        Task<List<UserPerformanceSummaries>> GetWeakestTopicsForUserAsync(Guid userId, int count = 5);
        Task<UserPerformanceSummaries?> GetUserPerformanceSummaryByUserIdAsync(Guid userId);
        Task<List<UserPerformanceSummaries>> GetUserPerformanceSummariesByUserIdAsync(Guid userId);
    }
}
