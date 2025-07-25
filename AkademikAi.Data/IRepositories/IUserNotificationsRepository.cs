using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface IUserNotificationsRepository
    {

        Task<List<UserNotifications>> GetUserNotificationsByUserIdAsync(Guid userId);
        Task<UserNotifications> GetUserNotificationByIdAsync(Guid notificationId);
        Task<List<UserNotifications>> GetUserNotificationsByTypeAsync(string notificationType);
    }
}
