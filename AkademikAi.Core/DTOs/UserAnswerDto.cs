using System;

namespace AkademikAi.Core.DTOs
{
    public class UserAnswerDto
    {
        public Guid QuestionId { get; set; }
        public Guid? SelectedOptionId { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsAnswered { get; set; }
        public int TimeSpent { get; set; } // saniye cinsinden
    }
} 