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
    public class AppRoleRepository : GenericRepository<AppRole>, IAppRoleRepository
    {
        public AppRoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<AppRole> GetByRoleNameAsync(string roleName)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public async Task<AppRole> GetByUserRoleAsync(UserRole userRole)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.UserRole == userRole);
        }

        public async Task<List<AppRole>> GetRolesByUserRoleAsync(UserRole userRole)
        {
            return await _dbSet.Where(x => x.UserRole == userRole).ToListAsync();
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _dbSet.AnyAsync(x => x.Name == roleName);
        }
    }
} 