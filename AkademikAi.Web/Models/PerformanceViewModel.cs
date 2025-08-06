using AkademikAi.Entity.Entites;
using System.Collections.Generic;
using System.Linq;

namespace AkademikAi.Web.Models
{
    public class PerformanceViewModel
    {
        public AppUser User { get; set; }
        public List<UserPerformanceSummaries> PerformanceSummaries { get; set; }
        public List<Topics> AllTopics { get; set; }
        public List<UserAnswers> UserAnswers { get; set; }
        public Dictionary<string, double> PerformanceByTopic { get; set; }
        public List<UserPerformanceSummaries> RecentPerformance { get; set; }
        
        // Calculated Statistics
        public int TotalQuestions { get; set; }
        public int TotalCorrectAnswers { get; set; }
        public double AverageSuccessRate { get; set; }
        public double AverageTimePerQuestion { get; set; }
        
        // Weakest Topics
        public List<UserPerformanceSummaries> WeakestTopics { get; set; }
        
        // Recommendations
        public List<PerformanceRecommendation> Recommendations { get; set; }
        
        public PerformanceViewModel()
        {
            PerformanceSummaries = new List<UserPerformanceSummaries>();
            AllTopics = new List<Topics>();
            UserAnswers = new List<UserAnswers>();
            PerformanceByTopic = new Dictionary<string, double>();
            RecentPerformance = new List<UserPerformanceSummaries>();
            WeakestTopics = new List<UserPerformanceSummaries>();
            Recommendations = new List<PerformanceRecommendation>();
        }
    }
 
    
    public class PerformanceRecommendation
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconClass { get; set; }
        public string Type { get; set; } // "weakness", "speed", "motivation", "start"
    }
}
