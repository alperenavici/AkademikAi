using AkademikAi.Entity.Entites;

namespace AkademikAi.Web.Models
{
    public class PerformanceSummariesViewModel
    {

        public AppUser User { get; set; }               
        public List<UserPerformanceSummaries> PerformanceSummaries { get; set; }
        public List<UserAnswers> UserAnswers { get; set; }
    }
}
