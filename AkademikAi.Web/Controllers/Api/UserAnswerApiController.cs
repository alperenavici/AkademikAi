using AkademikAi.Entity.Entites;
using AkademikAi.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAnswerApiController : ControllerBase
    {
        private readonly IUserAnswerService _userAnswerService;

        public UserAnswerApiController(IUserAnswerService userAnswerService)
        {
            _userAnswerService = userAnswerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserAnswers>>> GetAllUserAnswers()
        {
            try
            {
                var answers = await _userAnswerService.GetAllAsync();
                return Ok(answers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAnswers>> GetUserAnswerById(Guid id)
        {
            try
            {
                var answer = await _userAnswerService.GetByIdAsync(id);
                if (answer == null)
                    return NotFound();

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<UserAnswers>>> GetUserAnswersByUser(Guid userId)
        {
            try
            {
                var answers = await _userAnswerService.GetUserAnswersByUserIdAsync(userId);
                return Ok(answers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("question/{questionId}")]
        public async Task<ActionResult<List<UserAnswers>>> GetUserAnswersByQuestion(Guid questionId)
        {
            try
            {
                var answers = await _userAnswerService.GetUserAnswersByQuestionIdAsync(questionId);
                return Ok(answers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/question/{questionId}")]
        public async Task<ActionResult<List<UserAnswers>>> GetUserAnswerByUserAndQuestion(Guid userId, Guid questionId)
        {
            try
            {
                var answers = await _userAnswerService.GetUserAnswerByUserAndQuestionAsync(userId, questionId);
                return Ok(answers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/date-range")]
        public async Task<ActionResult<List<UserAnswers>>> GetUserAnswersByDateRange(
            Guid userId, 
            [FromQuery] DateTime startDate, 
            [FromQuery] DateTime endDate)
        {
            try
            {
                var answers = await _userAnswerService.GetUserAnswersByDateRangeAsync(userId, startDate, endDate);
                return Ok(answers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/recent")]
        public async Task<ActionResult<List<UserAnswers>>> GetUserRecentAnswers(
            Guid userId, 
            [FromQuery] int count = 10)
        {
            try
            {
                var answers = await _userAnswerService.GetUserRecentAnswersAsync(userId, count);
                return Ok(answers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/success-rate")]
        public async Task<ActionResult<double>> GetUserSuccessRate(Guid userId)
        {
            try
            {
                var successRate = await _userAnswerService.GetUserSuccessRateAsync(userId);
                return Ok(successRate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/success-rate/topic/{topicId}")]
        public async Task<ActionResult<double>> GetUserSuccessRateByTopic(Guid userId, Guid topicId)
        {
            try
            {
                var successRate = await _userAnswerService.GetUserSuccessRateByTopicAsync(userId, topicId);
                return Ok(successRate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/success-rate/difficulty/{difficultyLevel}")]
        public async Task<ActionResult<double>> GetUserSuccessRateByDifficulty(Guid userId, int difficultyLevel)
        {
            try
            {
                var successRate = await _userAnswerService.GetUserSuccessRateByDifficultyAsync(userId, difficultyLevel);
                return Ok(successRate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/performance-by-topic")]
        public async Task<ActionResult<Dictionary<string, double>>> GetUserPerformanceByTopic(Guid userId)
        {
            try
            {
                var performance = await _userAnswerService.GetUserPerformanceByTopicAsync(userId);
                return Ok(performance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserAnswers>> SubmitAnswer([FromBody] SubmitAnswerDto submitAnswerDto)
        {
            try
            {
                var answer = await _userAnswerService.SubmitAnswerAsync(
                    submitAnswerDto.UserId, 
                    submitAnswerDto.QuestionId, 
                    submitAnswerDto.SelectedOptionId, 
                    submitAnswerDto.IsCorrect);

                return CreatedAtAction(nameof(GetUserAnswerById), new { id = answer.Id }, answer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAnswer(Guid id, [FromBody] UpdateAnswerDto updateAnswerDto)
        {
            try
            {
                var result = await _userAnswerService.UpdateAnswerAsync(
                    id, 
                    updateAnswerDto.SelectedOptionId, 
                    updateAnswerDto.IsCorrect);

                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    public class SubmitAnswerDto
    {
        public Guid UserId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid SelectedOptionId { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class UpdateAnswerDto
    {
        public Guid SelectedOptionId { get; set; }
        public bool IsCorrect { get; set; }
    }
} 