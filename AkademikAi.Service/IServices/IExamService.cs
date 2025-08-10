using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface IExamService
    {
        Task<List<ExamListDto>> GetAllExamsAsync();
        Task<List<ExamListDto>> GetAdminExamsOnlyAsync(); // Sadece admin sınavları
        Task<ExamDetailDto> GetExamForStudentAsync(Guid examId, Guid userId);
        Task CreateExamAsync(ExamCreateDto examCreateDto);
        Task RegisterUserForExamAsync(Guid examId, Guid userId);
        Task StartExamForUserAsync(Guid examId, Guid userId);
        Task<Guid> CreateCustomExamFromUserRequestAsync(CustomExamCreateDto dto, Guid userId);
        Task<List<ExamHistoryDto>> GetUserExamHistoryAsync(Guid userId);
        Task<List<ExamListDto>> GetUserRegisteredExamsAsync(Guid userId);
        Task UpdateExamStatusAsync(Guid examId, ExamStatus status);

        Task<double> SubmitAndScoreExamAsync(Guid examId, Guid userId, List<UserAnswerSubmitDto> answers);
    }
}
