using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class Users
    {
        public Guid Id { get; set; }
      
        public string Name { get; set; }
        public UserRole UserRole { get;set; }
        public string Phone { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<UserAnswers> UserAnswers { get; set; } 
        public ICollection<UserRecommendation> UserRecommendations { get; set; }
        public ICollection<UserNotifications> UserNotifications { get; set; }
        public ICollection<UserPerformanceSummaries> UserPerformanceSummaries { get; set; }
        


    }
}
