using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class QuestionsOptions
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string OptionText { get; set; }
        public char Label { get; set; } // e.g., 'A', 'B', 'C', 'D'
        public bool IsCorrect { get; set; } 
        public Questions Question { get; set; } 
    }
}
