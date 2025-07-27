using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class UserAnswers
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid SelectedOptionId { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime AnsweredAt { get; set; }
        public char UserAnswer { get; set; } // e.g., 'A', 'B', 'C', 'D'
        public Users User { get; set; }
        public Questions Question { get; set; }
    }
}
