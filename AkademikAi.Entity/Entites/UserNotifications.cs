using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class UserNotifications
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string NotificationType { get; set; } // e.g., "exam", "test", "topic_reminder"
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public Users User { get; set; } 
    }
}
