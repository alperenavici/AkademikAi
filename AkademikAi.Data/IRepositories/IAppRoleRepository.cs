using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface IAppRoleRepository : IGenericRepository<AppRole>
    {
        Task<AppRole> GetByRoleNameAsync(string roleName);
        Task<AppRole> GetByUserRoleAsync(UserRole userRole);
        Task<List<AppRole>> GetRolesByUserRoleAsync(UserRole userRole);
        Task<bool> RoleExistsAsync(string roleName);
    }
} 