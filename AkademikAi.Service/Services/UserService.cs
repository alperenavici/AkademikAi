using AkademikAi.Core.DTOs;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class UserService : GenericService<Users>, IUserService
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

            // User activation logic can be added here
            // For now, we'll just return true as the user exists
            return true;
        }

        public async Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return false;

            var currentPasswordHash = HashPassword(currentPassword);
            if (user.PasswordHash != currentPasswordHash) return false;

            user.PasswordHash = HashPassword(newPassword);
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeactivateUserAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return false;

            // User deactivation logic can be added here
            // For now, we'll just return true as the user exists
            return true;
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
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

        public async Task<Users> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<List<Users>> GetByUserRoleAsync(UserRole userRole)
        {
            return await _userRepository.GetByUserRoleAsync(userRole);
        }

        public async Task<Users> GetUserByIdAsync(Guid userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<List<Users>> GetUsersByNameAndSurnameAsync(string name, string surname)
        {
            return await _userRepository.GetUsersByNameAndSurnameAsync(name, surname);
        }

        public async Task<List<Users>> GetUsersByPhoneAsync(string phone)
        {
            return await _userRepository.GetUsersByPhoneAsync(phone);
        }

        public async Task<Users> RegisterUserAsync(RegisterDto registerDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null) return null;

            var user = new Users
            {
                Id = Guid.NewGuid(),
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Email,
                PasswordHash = HashPassword(registerDto.Password),
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

            var passwordHash = HashPassword(loginDto.Password);
            return user.PasswordHash == passwordHash;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
} 