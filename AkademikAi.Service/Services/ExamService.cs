using AkademikAi.Core.DTOs;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using AutoMapper;

namespace AkademikAi.Service.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IGenericRepository<UserAnswers> _userAnswersRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ExamService(IExamRepository examRepository, IGenericRepository<UserAnswers> userAnswersRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _examRepository = examRepository;
            _userAnswersRepository = userAnswersRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateExamAsync(ExamCreateDto examCreateDto)
        {
            var exam = _mapper.Map<Exam>(examCreateDto);
            exam.Status = ExamStatus.Scheduled;
            exam.CreatedAt = DateTime.UtcNow;

            int order = 1;
            foreach (var questionId in examCreateDto.QuestionIds)
            {
                exam.ExamQuestions.Add(new ExamQuestions
                {
                    QuestionId = questionId,
                    QuestionOrder = order++
                });
            }

            await _examRepository.AddAsync(exam);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ExamListDto>> GetAllExamsAsync()
        {
            var exams = await _examRepository.GetActiveAndUpcomingExamsAsync();
            return _mapper.Map<List<ExamListDto>>(exams);
        }

        public async Task<ExamDetailDto> GetExamForStudentAsync(Guid examId, Guid userId)
        {
            var exam = await _examRepository.GetByIdAsync(examId);

            if (exam == null || exam.Status == ExamStatus.Cancelled)
                throw new InvalidOperationException("Sınav bulunamadı veya iptal edilmiş.");

            var participant = await _examRepository.GetParticipantAsync(userId, examId);
            if (participant == null)
                throw new InvalidOperationException("Bu sınava kayıtlı değilsiniz.");

            if (exam.Status != ExamStatus.InProgress)
                throw new InvalidOperationException("Sınav henüz başlamadı veya bitmiş.");

            if (participant.Status == ExamParticipationStatus.Completed)
                throw new InvalidOperationException("Bu sınavı zaten tamamladınız.");

            var examWithQuestions = await _examRepository.GetExamWithQuestionsAndOptionsAsync(examId);
            return _mapper.Map<ExamDetailDto>(examWithQuestions);
        }

        public async Task RegisterUserForExamAsync(Guid examId, Guid userId)
        {
            var exam = await _examRepository.GetByIdAsync(examId);
            if (exam.StartTime <= DateTime.UtcNow)
                throw new InvalidOperationException("Kayıt süresi dolmuş bir sınava kayıt olunamaz.");

            var isAlreadyRegistered = await _examRepository.IsUserRegisteredForExam(userId, examId);
            if (isAlreadyRegistered)
                throw new InvalidOperationException("Bu sınava zaten kayıtlısınız.");

            var newParticipant = new ExamParticipant
            {
                UserId = userId,
                ExamId = examId,
                Status = ExamParticipationStatus.Registered
            };
            await _examRepository.AddParticipantAsync(newParticipant);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task StartExamForUserAsync(Guid examId, Guid userId)
        {
            var participant = await _examRepository.GetParticipantAsync(userId, examId);
            if (participant == null || participant.Status != ExamParticipationStatus.Registered)
            {
                throw new InvalidOperationException("Sınava başlamak için uygun durumda değilsiniz.");
            }

            participant.Status = ExamParticipationStatus.Started;
            participant.TimeStarted = DateTime.UtcNow;
            _examRepository.UpdateParticipant(participant); 

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<double> SubmitAndScoreExamAsync(Guid examId, Guid userId, List<UserAnswerSubmitDto> answers)
        {
            var exam = await _examRepository.GetExamWithQuestionsAndOptionsAsync(examId);
            if (exam == null) throw new InvalidOperationException("Sınav bulunamadı.");

            var participant = await _examRepository.GetParticipantAsync(userId, examId);
            if (participant == null || participant.Status != ExamParticipationStatus.Started)
            {
                throw new InvalidOperationException("Sınavı bitirmek için uygun durumda değilsiniz.");
            }

            int correctCount = 0;
            var correctAnswers = exam.ExamQuestions
                .SelectMany(eq => eq.Question.QuestionsOptions)
                .Where(o => o.IsCorrect)
                .ToDictionary(o => o.QuestionId, o => o.Id);

            foreach (var userAnswer in answers)
            {
                bool isCorrect = correctAnswers.TryGetValue(userAnswer.QuestionId, out var correctId) && correctId == userAnswer.SelectedOptionId;
                if (isCorrect)
                {
                    correctCount++;
                }

                var answerEntity = new UserAnswers
                {
                    UserId = userId,
                    QuestionId = userAnswer.QuestionId,
                    SelectedOptionId = userAnswer.SelectedOptionId,
                    IsCorrect = isCorrect,
                    AnsweredAt = DateTime.UtcNow,
                    ExamId = examId
                };
                await _userAnswersRepository.AddAsync(answerEntity);
            }

            double score = (exam.ExamQuestions.Any()) ? (double)correctCount / exam.ExamQuestions.Count * 100 : 0;

            participant.Status = ExamParticipationStatus.Completed;
            participant.TimeFinished = DateTime.UtcNow;
            participant.Score = score;
            _examRepository.UpdateParticipant(participant);

            
            await _unitOfWork.SaveChangesAsync();

            return Math.Round(score, 2);
        }
    }
}
