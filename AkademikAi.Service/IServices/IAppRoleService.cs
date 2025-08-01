using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        Task<AppRole> GetByRoleNameAsync(string roleName);
        Task<AppRole> GetByUserRoleAsync(UserRole userRole);
        Task<List<AppRole>> GetRolesByUserRoleAsync(UserRole userRole);
        Task<bool> RoleExistsAsync(string roleName);
        Task<AppRole> CreateRoleAsync(string roleName, UserRole userRole);
        Task<bool> UpdateRoleAsync(Guid roleId, string roleName, UserRole userRole);
        Task<bool> DeleteRoleAsync(Guid roleId);
    }
} 