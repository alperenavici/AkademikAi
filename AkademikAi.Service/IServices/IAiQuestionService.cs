using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;

namespace AkademikAi.Service.IServices
{
    public interface IAiQuestionService
    {
        Task<List<Questions>> GenerateQuestionsFromAiAsync(CustomExamCreateDto dto);
        Task<Questions> GenerateSingleQuestionAsync(string subject, string topic, int difficulty, string questionType = "multiple_choice");
    }
}
