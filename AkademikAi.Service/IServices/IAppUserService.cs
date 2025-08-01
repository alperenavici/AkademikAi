using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface IAppUserService : IGenericService<AppUser>
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
        Task<AppUser> CreateUserAsync(string email, string userName, string name, string surname, UserRole userRole);
        Task<bool> UpdateUserAsync(Guid userId, string name, string surname, UserRole userRole);
        Task<bool> DeleteUserAsync(Guid userId);
        Task<bool> ChangeUserRoleAsync(Guid userId, UserRole newRole);
    }
} 