using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class UserNotificationService : GenericService<UserNotifications>, IUserNotificationService
    {
        private readonly IUserNotificationsRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserNotificationService(
            IUserNotificationsRepository notificationRepository,
            IUnitOfWork unitOfWork) : base(notificationRepository)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserNotifications> CreateNotificationAsync(Guid userId, string title, string message, string notificationType)
        {
            var notification = new UserNotifications
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Title = title,
                Message = message,
                NotificationType = notificationType,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };

            await _notificationRepository.AddAsync(notification);
            await _unitOfWork.SaveChangesAsync();
            return notification;
        }

        public async Task<bool> CreateBulkNotificationsAsync(List<Guid> userIds, string title, string message, string notificationType)
        {
            var notifications = new List<UserNotifications>();
            foreach (var userId in userIds)
            {
                notifications.Add(new UserNotifications
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Title = title,
                    Message = message,
                    NotificationType = notificationType,
                    IsRead = false,
                    CreatedAt = DateTime.UtcNow
                });
            }

            await _notificationRepository.AddRangeAsync(notifications);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateNotificationAsync(Guid notificationId, string title, string message)
        {
            var notification = await _notificationRepository.GetByIdAsync(notificationId);
            if (notification == null) return false;

            notification.Title = title;
            notification.Message = message;

            _notificationRepository.Update(notification);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserNotifications>> GetUnreadUserNotificationsAsync(Guid userId)
        {
            var notifications = await _notificationRepository.GetUserNotificationsByUserIdAsync(userId);
            return notifications.Where(n => !n.IsRead).ToList();
        }

        public async Task<List<UserNotifications>> GetReadUserNotificationsAsync(Guid userId)
        {
            var notifications = await _notificationRepository.GetUserNotificationsByUserIdAsync(userId);
            return notifications.Where(n => n.IsRead).ToList();
        }

        public async Task<List<UserNotifications>> GetRecentUserNotificationsAsync(Guid userId, int count = 10)
        {
            var notifications = await _notificationRepository.GetUserNotificationsByUserIdAsync(userId);
            return notifications.OrderByDescending(n => n.CreatedAt).Take(count).ToList();
        }

        public async Task<List<UserNotifications>> GetNotificationsByTypeAsync(string notificationType)
        {
            var allNotifications = await _notificationRepository.GetAllAsync();
            return allNotifications.Where(n => n.NotificationType == notificationType).ToList();
        }

        public async Task<bool> MarkAllUserNotificationsAsReadAsync(Guid userId)
        {
            var notifications = await _notificationRepository.GetUserNotificationsByUserIdAsync(userId);
            var unreadNotifications = notifications.Where(n => !n.IsRead).ToList();

            foreach (var notification in unreadNotifications)
            {
                notification.IsRead = true;
                notification.ReadAt = DateTime.UtcNow;
                _notificationRepository.Update(notification);
            }

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAllUserNotificationsAsync(Guid userId)
        {
            var notifications = await _notificationRepository.GetUserNotificationsByUserIdAsync(userId);
            _notificationRepository.RemoveRange(notifications);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNotificationAsync(Guid notificationId)
        {
            var notification = await _notificationRepository.GetByIdAsync(notificationId);
            if (notification == null) return false;

            _notificationRepository.Remove(notification);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetUnreadNotificationCountAsync(Guid userId)
        {
            var notifications = await _notificationRepository.GetUserNotificationsByUserIdAsync(userId);
            return notifications.Count(n => !n.IsRead);
        }

        public async Task<UserNotifications> GetNotificationByIdAsync(Guid notificationId)
        {
            return await _notificationRepository.GetByIdAsync(notificationId);
        }

        public async Task<List<UserNotifications>> GetNotificationsByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate)
        {
            var notifications = await _notificationRepository.GetUserNotificationsByUserIdAsync(userId);
            return notifications.Where(n => n.CreatedAt >= startDate && n.CreatedAt <= endDate).ToList();
        }

        public async Task<List<UserNotifications>> GetUserNotificationsAsync(Guid userId)
        {
            return await _notificationRepository.GetUserNotificationsByUserIdAsync(userId);
        }

        public async Task<bool> MarkNotificationAsReadAsync(Guid notificationId)
        {
            var notification = await _notificationRepository.GetByIdAsync(notificationId);
            if (notification == null) return false;

            notification.IsRead = true;
            notification.ReadAt = DateTime.UtcNow;

            _notificationRepository.Update(notification);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
} 