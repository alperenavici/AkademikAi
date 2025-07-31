using AkademikAi.Entity.Enums;
using Microsoft.AspNetCore.Identity;

namespace AkademikAi.Entity.Entites
{
    public class AppUser: IdentityUser<Guid>
    {
      
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserRole UserRole { get; set; }  // Bu property mutlaka olmalı


        // Navigation Properties
        public ICollection<UserAnswers> UserAnswers { get; set; }
        public ICollection<UserRecommendation> UserRecommendations { get; set; }
        public ICollection<UserNotifications> UserNotifications { get; set; }
        public ICollection<UserPerformanceSummaries> UserPerformanceSummaries { get; set; }



    }
}
