using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class AppUserService : GenericService<AppUser>, IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(IAppUserRepository appUserRepository, IUnitOfWork unitOfWork) 
            : base(appUserRepository)
        {
            _appUserRepository = appUserRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _appUserRepository.GetByEmailAsync(email);
        }

        public async Task<AppUser> GetByUserNameAsync(string userName)
        {
            return await _appUserRepository.GetByUserNameAsync(userName);
        }

        public async Task<List<AppUser>> GetUsersByRoleAsync(UserRole userRole)
        {
            return await _appUserRepository.GetUsersByRoleAsync(userRole);
        }

        public async Task<List<AppUser>> GetUsersWithAnswersAsync()
        {
            return await _appUserRepository.GetUsersWithAnswersAsync();
        }

        public async Task<List<AppUser>> GetUsersWithNotificationsAsync()
        {
            return await _appUserRepository.GetUsersWithNotificationsAsync();
        }

        public async Task<List<AppUser>> GetUsersWithPerformanceSummariesAsync()
        {
            return await _appUserRepository.GetUsersWithPerformanceSummariesAsync();
        }

        public async Task<List<AppUser>> GetUsersWithRecommendationsAsync()
        {
            return await _appUserRepository.GetUsersWithRecommendationsAsync();
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            return await _appUserRepository.UserExistsAsync(email);
        }

        public async Task<bool> UserNameExistsAsync(string userName)
        {
            return await _appUserRepository.UserNameExistsAsync(userName);
        }

        public async Task<AppUser> CreateUserAsync(string email, string userName, string name, string surname, UserRole userRole)
        {
            if (await UserExistsAsync(email))
            {
                throw new InvalidOperationException($"User with email '{email}' already exists.");
            }

            if (await UserNameExistsAsync(userName))
            {
                throw new InvalidOperationException($"User with username '{userName}' already exists.");
            }

            var user = new AppUser
            {
                Email = email,
                UserName = userName,
                Name = name,
                Surname = surname,
                UserRole = userRole,
                CreatedAt = DateTime.UtcNow
            };

            await _appUserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UpdateUserAsync(Guid userId, string name, string surname, UserRole userRole)
        {
            var user = await _appUserRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.Name = name;
            user.Surname = surname;
            user.UserRole = userRole;

            _appUserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await _appUserRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            _appUserRepository.Remove(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeUserRoleAsync(Guid userId, UserRole newRole)
        {
            var user = await _appUserRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.UserRole = newRole;

            _appUserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
} 