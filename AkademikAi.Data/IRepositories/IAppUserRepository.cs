using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        Task<AppUser> GetByEmailAsync(string email);
        Task<AppUser> GetByUserNameAsync(string userName);
        Task<List<AppUser>> GetUsersByRoleAsync(UserRole userRole);
        Task<List<AppUser>> GetUsersWithAnswersAsync();
        Task<List<AppUser>> GetUsersWithNotificationsAsync();
        Task<List<AppUser>> GetUsersWithPerformanceSummariesAsync();
        Task<List<AppUser>> GetUsersWithRecommendationsAsync();
        Task<bool> UserExistsAsync(string email);
        Task<bool> UserNameExistsAsync(string userName);
    }
} 