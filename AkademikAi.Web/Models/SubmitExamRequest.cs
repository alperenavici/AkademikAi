using AkademikAi.Core.DTOs;

namespace AkademikAi.Web.Models
{
    public class SubmitExamRequest
    {
        public Guid ExamId { get; set; }
        public List<UserAnswerSubmitDto> Answers { get; set; } = new List<UserAnswerSubmitDto>();
    }
}
