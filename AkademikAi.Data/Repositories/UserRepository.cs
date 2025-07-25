using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using Microsoft.EntityFrameworkCore;
using AkademikAi.Entity.Enums;
using AkademikAi.Data.IRepositories;

namespace AkademikAi.Data.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task<Users> GetUserByIdAsync(Guid UserId)
        {
            return _context.Users
                .Include(u => u.UserAnswers)
                .Include(u => u.UserNotifications)
                .Include(u => u.UserRecommendations)
                .Include(u => u.UserPerformanceSummaries)
                .FirstOrDefaultAsync(u => u.Id == UserId);
        }

        public Task<List<Users>> GetByUserRoleAsync(UserRole userRole)
        {
            return _context.Users
                .Where(u => u.UserRole == userRole)
                .ToListAsync();
        }

        public Task<Users> GetByEmailAsync(string email)
        {
            return _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        public Task<List<Users>> GetAllUsersAsync()
        {
            return _context.Users
                .Include(u => u.UserAnswers)
                .Include(u => u.UserNotifications)
                .Include(u => u.UserRecommendations)
                .Include(u => u.UserPerformanceSummaries)
                .ToListAsync();
        }

        public Task<Users> GetUserByEmailAsync(string email)
        {
            return _context.Users
                .Include(u => u.UserAnswers)
                .Include(u => u.UserNotifications)
                .Include(u => u.UserRecommendations)
                .Include(u => u.UserPerformanceSummaries)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

     
        public Task<List<Users>> GetUsersByPhoneAsync(string phone)
        {
            return _context.Users
                .Where(u => u.Phone.Contains(phone))
                .ToListAsync();
        }

        public Task<List<Users>> GetUsersByNameAndSurnameAsync(string name, string surname)
        {
            return _context.Users
                .Where(u => u.Name.Contains(name) && u.Surname.Contains(surname))
                .ToListAsync();
        }

       
    }
}
