using AkademikAi.Entity.Entites;

namespace AkademikAi.Web.Models
{
    public class DashboardViewModel
    {

        public AppUser User { get; set; }
        public List<UserPerformanceSummaries> PerformanceSummaries { get; set; }
        public List<UserPerformanceSummaries> WeakestTopics { get; set; }
        public List<Topics> AllTopics { get; set; }
        public List<UserAnswers> UserAnswers { get; set; }
        public Dictionary<string, double> PerformanceByTopic { get; set; }
        public List<UserPerformanceSummaries> RecentPerformance { get; set; }

    }
}
