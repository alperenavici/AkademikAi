using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface IUserNotificationService : IGenericService<UserNotifications>
    {
        Task<List<UserNotifications>> GetUserNotificationsAsync(Guid userId);
        Task<List<UserNotifications>> GetUnreadUserNotificationsAsync(Guid userId);
        Task<List<UserNotifications>> GetReadUserNotificationsAsync(Guid userId);
        Task<UserNotifications> GetNotificationByIdAsync(Guid notificationId);
        Task<List<UserNotifications>> GetNotificationsByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate);
        Task<List<UserNotifications>> GetRecentUserNotificationsAsync(Guid userId, int count = 10);
        Task<List<UserNotifications>> GetNotificationsByTypeAsync(string notificationType);
        
        Task<UserNotifications> CreateNotificationAsync(Guid userId, string title, string message, string notificationType);
        Task<bool> CreateBulkNotificationsAsync(List<Guid> userIds, string title, string message, string notificationType);
        Task<bool> UpdateNotificationAsync(Guid notificationId, string title, string message);
        Task<bool> MarkNotificationAsReadAsync(Guid notificationId);
        Task<bool> MarkAllUserNotificationsAsReadAsync(Guid userId);
        Task<bool> DeleteNotificationAsync(Guid notificationId);
        Task<bool> DeleteAllUserNotificationsAsync(Guid userId);
        Task<int> GetUnreadNotificationCountAsync(Guid userId);
    }
} 