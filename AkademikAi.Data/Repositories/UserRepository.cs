using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using Microsoft.EntityFrameworkCore;
using AkademikAi.Entity.Enums;

namespace AkademikAi.Data.Repositories
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<AppUser> GetUserByIdAsync(Guid UserId)
        {
            return _context.Users
                .Include(u => u.UserAnswers)
                .Include(u => u.UserNotifications)
                .Include(u => u.UserRecommendations)
                .Include(u => u.UserPerformanceSummaries)
                .FirstOrDefaultAsync(u => u.Id == UserId);
        }

        public Task<List<AppUser>> GetByUserRoleAsync(UserRole userRole)
        {
            return _context.Users
                .Where(u => u.UserRole == userRole)
                .ToListAsync();
        }

        public Task<AppUser> GetByEmailAsync(string email)
        {
            return _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        public Task<List<AppUser>> GetAllAppUserAsync()
        {
            return _context.Users
                .Include(u => u.UserAnswers)
                .Include(u => u.UserNotifications)
                .Include(u => u.UserRecommendations)
                .Include(u => u.UserPerformanceSummaries)
                .ToListAsync();
        }

        public Task<AppUser> GetUserByEmailAsync(string email)
        {
            return _context.Users
                .Include(u => u.UserAnswers)
                .Include(u => u.UserNotifications)
                .Include(u => u.UserRecommendations)
                .Include(u => u.UserPerformanceSummaries)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

     
        public Task<List<AppUser>> GetAppUserByPhoneAsync(string phone)
        {
            return _context.Users
                .Where(u => u.PhoneNumber.Contains(phone))
                .ToListAsync();
        }

        public Task<List<AppUser>> GetAppUserByNameAndSurnameAsync(string name, string surname)
        {
            return _context.Users
                .Where(u => u.Name.Contains(name) && u.Surname.Contains(surname))
                .ToListAsync();
        }

       
    }
}
