using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Data.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<AppUser?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<AppUser?> GetByUserNameAsync(string userName)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<List<AppUser>> GetUsersByRoleAsync(UserRole userRole)
        {
            return await _dbSet.Where(x => x.UserRole == userRole).ToListAsync();
        }

        public async Task<List<AppUser>> GetUsersWithAnswersAsync()
        {
            return await _dbSet.Include(x => x.UserAnswers).ToListAsync();
        }

        public async Task<List<AppUser>> GetUsersWithNotificationsAsync()
        {
            return await _dbSet.Include(x => x.UserNotifications).ToListAsync();
        }

        public async Task<List<AppUser>> GetUsersWithPerformanceSummariesAsync()
        {
            return await _dbSet.Include(x => x.UserPerformanceSummaries).ToListAsync();
        }

        public async Task<List<AppUser>> GetUsersWithRecommendationsAsync()
        {
            return await _dbSet.Include(x => x.UserRecommendations).ToListAsync();
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> UserNameExistsAsync(string userName)
        {
            return await _dbSet.AnyAsync(x => x.UserName == userName);
        }
    }
} 