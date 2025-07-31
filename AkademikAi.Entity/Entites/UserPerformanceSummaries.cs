using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class UserPerformanceSummaries
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TopicId { get; set; } 
        public int TotalAnsweredQuestions { get; set; }
        public int TotalQuestionsAnswered { get; set; }
        public int CorrectAnswers { get; set; }
        public double SuccessRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public AppUser User { get; set; }
        public Topics Topic { get; set; }
    }
}
