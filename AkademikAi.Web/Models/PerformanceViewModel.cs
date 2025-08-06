using AkademikAi.Entity.Entites;
using AkademikAi.Core.DTOs;
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
        public List<DailyActivityDto> ActivitiesLastYear { get; set; }

        // Calculated Statistics
        public int TotalQuestions { get; set; }
        public int PreviousTotalQuestions { get; set; }

        public int TotalCorrectAnswers { get; set; }
        public double AverageSuccessRate { get; set; }
        public double PreviousAverageSuccessRate { get; set; }
        public double AverageTimePerQuestion { get; set; }

        public double TotalQuestionsPercentageChange =>
                CalculatePercentageChange(PreviousTotalQuestions, TotalQuestions);
        public double SuccessRatePercentageChange =>
                CalculatePercentageChange(PreviousAverageSuccessRate, AverageSuccessRate);


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
            ActivitiesLastYear = new List<DailyActivityDto>();
        }


        private double CalculatePercentageChange(double oldValue, double newValue)
        {
            if (oldValue == 0) return 100; // veya senin için mantıklı bir değer
            return ((newValue - oldValue) / oldValue) * 100;
        }


        public class PerformanceRecommendation
        {
            public DateTime Date { get; set; }
            public int QuestionNumber { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string IconClass { get; set; }
            public string Type { get; set; } // "weakness", "speed", "motivation", "start"
        }
    }
}
