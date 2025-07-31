using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface IUserService : IGenericService<AppUser>
    {
        Task<AppUser> GetUserByIdAsync(Guid userId);
        Task<List<AppUser>> GetByUserRoleAsync(UserRole userRole);
        Task<AppUser> GetByEmailAsync(string email);
        Task<List<AppUser>> GetAllAppUserAsync();
        Task<AppUser> GetUserByEmailAsync(string email);
        Task<List<AppUser>> GetAppUserByPhoneAsync(string phone);
        Task<List<AppUser>> GetAppUserByNameAndSurnameAsync(string name, string surname);
        
        Task<bool> ValidateUserAsync(LoginDto loginDto);
        Task<AppUser> RegisterUserAsync(RegisterDto registerDto);
        Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
        Task<bool> UpdateUserProfileAsync(Guid userId, UserDto userDto);
        
        Task<List<UserDto>> GetActiveStudentsAsync();
        Task<List<UserDto>> GetTeachersAsync();
        Task<bool> DeactivateUserAsync(Guid userId);
        Task<bool> ActivateUserAsync(Guid userId);
    }
} 