using AkademikAi.Core.DTOs;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class UserService : GenericService<AppUser>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork) : base(userRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ActivateUserAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return false;

            
            return true;
        }

        public async Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return false;

            // Password change will be handled by Identity
            return true;
        }

        public async Task<bool> DeactivateUserAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return false;

            
            return true;
        }

        public async Task<List<AppUser>> GetAllAppUserAsync()
        {
            return await _userRepository.GetAllAppUserAsync();
        }

        public async Task<List<UserDto>> GetActiveStudentsAsync()
        {
            var students = await _userRepository.GetByUserRoleAsync(UserRole.Student);
            return students.Select(s => new UserDto
            {
                Name = s.Name,
                Surname = s.Surname,
                UserRole = (int)s.UserRole,
                CreatedAt = s.CreatedAt
            }).ToList();
        }

        public async Task<List<UserDto>> GetTeachersAsync()
        {
            var teachers = await _userRepository.GetByUserRoleAsync(UserRole.Teacher);
            return teachers.Select(t => new UserDto
            {
                Name = t.Name,
                Surname = t.Surname,
                UserRole = (int)t.UserRole,
                CreatedAt = t.CreatedAt
            }).ToList();
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<List<AppUser>> GetByUserRoleAsync(UserRole userRole)
        {
            return await _userRepository.GetByUserRoleAsync(userRole);
        }

        public async Task<AppUser> GetUserByIdAsync(Guid userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<List<AppUser>> GetAppUserByNameAndSurnameAsync(string name, string surname)
        {
            return await _userRepository.GetAppUserByNameAndSurnameAsync(name, surname);
        }

        public async Task<List<AppUser>> GetAppUserByPhoneAsync(string phone)
        {
            return await _userRepository.GetAppUserByPhoneAsync(phone);
        }

        public async Task<AppUser?> RegisterUserAsync(RegisterDto registerDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null) return null;

            var user = new AppUser
            {
                Id = Guid.NewGuid(),
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                UserRole = UserRole.Student, // Default role
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateUserProfileAsync(Guid userId, UserDto userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return false;

            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.UserRole = (UserRole)userDto.UserRole;

            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidateUserAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null) return false;

            // Password validation will be handled by Identity
            return true;
        }
    }
} 