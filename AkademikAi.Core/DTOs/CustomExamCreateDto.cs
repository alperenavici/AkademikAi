using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Core.DTOs
{
    public class CustomExamCreateDto
    {
        public string TestName { get; set; }
        public Guid SubjectId { get; set; }
        public Guid TopicId { get; set; }
        public int QuestionCount { get; set; }
        public int DurationMinutes { get; set; }
        public int Difficulty { get; set; } // 1: Easy, 2: Medium, 3: Hard, 0: Mixed
    }
}
