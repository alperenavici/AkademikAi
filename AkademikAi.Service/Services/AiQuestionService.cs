using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace AkademikAi.Service.Services
{
    public class AiQuestionService : IAiQuestionService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AiQuestionService> _logger;
        private readonly ISubjectService _subjectService;
        private readonly ITopicService _topicService;
        private readonly string _aiBaseUrl = "http://127.0.0.1:8081";

        public AiQuestionService(HttpClient httpClient, ILogger<AiQuestionService> logger, 
                               ISubjectService subjectService, ITopicService topicService)
        {
            _httpClient = httpClient;
            _logger = logger;
            _subjectService = subjectService;
            _topicService = topicService;
        }

        public async Task<List<Questions>> GenerateQuestionsFromAiAsync(CustomExamCreateDto dto)
        {
            try
            {
                var subjectName = await GetSubjectName(dto.SubjectId);
                var topicName = await GetTopicName(dto.TopicId);
                
                _logger.LogInformation($"AI soru üretimi başlıyor - Ders: {subjectName}, Konu: {topicName}, Zorluk: {dto.Difficulty}, Soru Sayısı: {dto.QuestionCount}");
                
                var requestData = new
                {
                    subject = subjectName,
                    topic = topicName,
                    difficulty = GetDifficultyString(dto.Difficulty),
                    question_count = dto.QuestionCount,
                    question_type = "multiple_choice"
                };

                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                _logger.LogInformation($"AI servisi URL: {_aiBaseUrl}/generate_questions");
                _logger.LogInformation($"İstek verisi: {json}");

                var response = await _httpClient.PostAsync($"{_aiBaseUrl}/generate_questions", content);
                
                _logger.LogInformation($"AI servisi yanıtı: StatusCode={response.StatusCode}, ReasonPhrase={response.ReasonPhrase}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"AI servisi hata detayı: {errorContent}");
                    throw new Exception($"AI servisi hatası: {response.StatusCode} - {response.ReasonPhrase}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var aiQuestions = JsonSerializer.Deserialize<List<AiQuestionResponse>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (aiQuestions == null || !aiQuestions.Any())
                {
                    throw new Exception("AI servisinden soru alınamadı.");
                }

                var questions = new List<Questions>();
                foreach (var aiQuestion in aiQuestions)
                {
                                    var question = new Questions
                {
                    Id = Guid.NewGuid(),
                    QuestionText = aiQuestion.question,
                    DifficultyLevel = (QuestionsDiff)dto.Difficulty,
                    Source = "ai",
                    IsActive = true,
                    SolutionText = "",
                    GeneratedForUserId = null
                };

                // Seçenekleri ekle
                question.QuestionsOptions = new List<QuestionsOptions>();
                var optionLabels = new[] { 'A', 'B', 'C', 'D' };
                for (int i = 0; i < aiQuestion.options.Count; i++)
                {
                    question.QuestionsOptions.Add(new QuestionsOptions
                    {
                        Id = Guid.NewGuid(),
                        QuestionId = question.Id,
                        OptionText = aiQuestion.options[i],
                        Label = optionLabels[i],
                        IsCorrect = aiQuestion.options[i] == aiQuestion.correct_answer,
                        OptionOrder = i + 1
                    });
                }

                // Konu ilişkisini ekle
                question.QuestionsTopics = new List<QuestionsTopic>
                {
                    new QuestionsTopic
                    {
                        Id = Guid.NewGuid(),
                        QuestionId = question.Id,
                        TopicId = dto.TopicId
                    }
                };

                    questions.Add(question);
                }

                return questions;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AI soru üretimi sırasında hata oluştu");
                throw new Exception($"AI soru üretimi başarısız: {ex.Message}");
            }
        }

        public async Task<Questions> GenerateSingleQuestionAsync(string subject, string topic, int difficulty, string questionType = "multiple_choice")
        {
            try
            {
                var requestData = new
                {
                    subject = subject,
                    topic = topic,
                    difficulty = GetDifficultyString(difficulty),
                    question_count = 1,
                    question_type = questionType
                };

                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_aiBaseUrl}/generate_questions", content);
                
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"AI servisi hatası: {response.StatusCode} - {response.ReasonPhrase}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var aiQuestions = JsonSerializer.Deserialize<List<AiQuestionResponse>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (aiQuestions == null || !aiQuestions.Any())
                {
                    throw new Exception("AI servisinden soru alınamadı.");
                }

                var aiQuestion = aiQuestions.First();
                var question = new Questions
                {
                    Id = Guid.NewGuid(),
                    QuestionText = aiQuestion.question,
                    DifficultyLevel = (QuestionsDiff)difficulty,
                    Source = "ai",
                    IsActive = true,
                    SolutionText = "",
                    GeneratedForUserId = null
                };

                // Seçenekleri ekle
                question.QuestionsOptions = new List<QuestionsOptions>();
                var optionLabels = new[] { 'A', 'B', 'C', 'D' };
                for (int i = 0; i < aiQuestion.options.Count; i++)
                {
                    question.QuestionsOptions.Add(new QuestionsOptions
                    {
                        Id = Guid.NewGuid(),
                        QuestionId = question.Id,
                        OptionText = aiQuestion.options[i],
                        Label = optionLabels[i],
                        IsCorrect = aiQuestion.options[i] == aiQuestion.correct_answer,
                        OptionOrder = i + 1
                    });
                }

                return question;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Tek AI soru üretimi sırasında hata oluştu");
                throw new Exception($"AI soru üretimi başarısız: {ex.Message}");
            }
        }

        private string GetDifficultyString(int difficulty)
        {
            return difficulty switch
            {
                1 => "easy",
                2 => "medium", 
                3 => "hard",
                0 => "mixed",
                _ => "medium"
            };
        }

        private async Task<string> GetSubjectName(Guid subjectId)
        {
            try
            {
                var subject = await _subjectService.GetByIdAsync(subjectId);
                return subject?.SubjectName ?? "Bilinmeyen Ders";
            }
            catch
            {
                return "Bilinmeyen Ders";
            }
        }

        private async Task<string> GetTopicName(Guid topicId)
        {
            try
            {
                var topic = await _topicService.GetByIdAsync(topicId);
                return topic?.TopicName ?? "Bilinmeyen Konu";
            }
            catch
            {
                return "Bilinmeyen Konu";
            }
        }
    }

    // AI servisinden gelen yanıt için model
    public class AiQuestionResponse
    {
        public string question { get; set; } = string.Empty;
        public List<string> options { get; set; } = new List<string>();
        public string correct_answer { get; set; } = string.Empty;
        public string explanation { get; set; } = string.Empty;
    }
}
