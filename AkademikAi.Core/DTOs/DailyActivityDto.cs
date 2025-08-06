using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Core.DTOs
{
    public class DailyActivityDto
    {
        public DateTime Date { get; set; }
        public int TotalScore { get; set; }
        public int QuestionCount { get; set; }
    }
}
