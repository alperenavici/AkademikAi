using AkademikAi.Core.DTOs;
using System.ComponentModel.DataAnnotations;

namespace AkademikAi.Web.Models
{
    public class SolveViewModel
    {
        [Required]
        public List<UserAnswerDto> UserAnswers { get; set; } = new List<UserAnswerDto>();
        
        public Guid TopicId { get; set; }
        public string TopicName { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        public int NullAnswers { get; set; }
        public double SuccessRate { get; set; }
        public string CreatedBy { get; set; }
        public int TimeSpent { get; set; } // saniye cinsinden
    }
} 