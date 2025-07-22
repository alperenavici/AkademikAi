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
        public int CorrectAnswers { get; set; }
        public  Users User { get; set; }
        public Topics Topic { get; set; }
    }
}
