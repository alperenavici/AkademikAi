using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class AppRoleService : GenericService<AppRole>, IAppRoleService
    {
        private readonly IAppRoleRepository _appRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AppRoleService(IAppRoleRepository appRoleRepository, IUnitOfWork unitOfWork) 
            : base(appRoleRepository)
        {
            _appRoleRepository = appRoleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppRole> GetByRoleNameAsync(string roleName)
        {
            return await _appRoleRepository.GetByRoleNameAsync(roleName);
        }

        public async Task<AppRole> GetByUserRoleAsync(UserRole userRole)
        {
            return await _appRoleRepository.GetByUserRoleAsync(userRole);
        }

        public async Task<List<AppRole>> GetRolesByUserRoleAsync(UserRole userRole)
        {
            return await _appRoleRepository.GetRolesByUserRoleAsync(userRole);
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _appRoleRepository.RoleExistsAsync(roleName);
        }

        public async Task<AppRole> CreateRoleAsync(string roleName, UserRole userRole)
        {
            if (await RoleExistsAsync(roleName))
            {
                throw new InvalidOperationException($"Role '{roleName}' already exists.");
            }

            var role = new AppRole
            {
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                UserRole = userRole
            };

            await _appRoleRepository.AddAsync(role);
            await _unitOfWork.SaveChangesAsync();

            return role;
        }

        public async Task<bool> UpdateRoleAsync(Guid roleId, string roleName, UserRole userRole)
        {
            var role = await _appRoleRepository.GetByIdAsync(roleId);
            if (role == null)
            {
                return false;
            }

            role.Name = roleName;
            role.NormalizedName = roleName.ToUpper();
            role.UserRole = userRole;

            _appRoleRepository.Update(role);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRoleAsync(Guid roleId)
        {
            var role = await _appRoleRepository.GetByIdAsync(roleId);
            if (role == null)
            {
                return false;
            }

            _appRoleRepository.Remove(role);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
} 