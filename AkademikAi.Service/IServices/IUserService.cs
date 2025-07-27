using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface IUserService : IGenericService<Users>
    {
        Task<Users> GetUserByIdAsync(Guid userId);
        Task<List<Users>> GetByUserRoleAsync(UserRole userRole);
        Task<Users> GetByEmailAsync(string email);
        Task<List<Users>> GetAllUsersAsync();
        Task<Users> GetUserByEmailAsync(string email);
        Task<List<Users>> GetUsersByPhoneAsync(string phone);
        Task<List<Users>> GetUsersByNameAndSurnameAsync(string name, string surname);
        
        Task<bool> ValidateUserAsync(LoginDto loginDto);
        Task<Users> RegisterUserAsync(RegisterDto registerDto);
        Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
        Task<bool> UpdateUserProfileAsync(Guid userId, UserDto userDto);
        
        Task<List<UserDto>> GetActiveStudentsAsync();
        Task<List<UserDto>> GetTeachersAsync();
        Task<bool> DeactivateUserAsync(Guid userId);
        Task<bool> ActivateUserAsync(Guid userId);
    }
} 