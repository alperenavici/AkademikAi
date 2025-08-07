using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;

namespace AkademikAi.Entity.Entites
{
    public class ExamQuestions
    {
        public Guid ExamId { get; set; } // Sınavın ID'si
        public Exam Exam { get; set; }
        public Guid QuestionId { get; set; } // Soru ID'si
        public Questions Question { get; set; }
        public int QuestionOrder { get; set; } // Soru sırası sınavda

    }
}
