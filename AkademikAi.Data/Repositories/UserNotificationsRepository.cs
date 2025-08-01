using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using AkademikAi.Entity.Entites;




namespace AkademikAi.Data.Repositories
{
    public class UserNotificationsRepository:GenericRepository<UserNotifications>, IUserNotificationsRepository
    {
        private readonly AppDbContext _context;
        public UserNotificationsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<UserNotifications>> GetUserNotificationsByUserIdAsync(Guid userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId)
                .ToListAsync();
        }
        public Task<UserNotifications?> GetUserNotificationByIdAsync(Guid notificationId)
        {
            return _context.UserNotifications
                .FirstOrDefaultAsync(un => un.Id == notificationId);
        }

        public Task<List<UserNotifications>> GetUserNotificationsByTypeAsync(string notificationType)
        {
            return _context.UserNotifications
                .Where(un => un.NotificationType == notificationType)
                .ToListAsync();
        }
        public Task<List<UserNotifications>>GetUserNotificationsByCreatedDateAsync(DateTime createdAt)
        {
            return _context.UserNotifications
                .Where(un => un.CreatedAt.Date == createdAt.Date)
                .ToListAsync();
        }

        public Task<UserNotifications?> GetUserNotificationsByNotificationTypeAndUserIdAsync(string notificationType, Guid userId)
        {
            return _context.UserNotifications
                .FirstOrDefaultAsync(un => un.NotificationType == notificationType && un.UserId == userId);
        }

    }
}
