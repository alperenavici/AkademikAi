using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionApiController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly ITopicService _topicService;

        public QuestionApiController(IQuestionService questionService, ITopicService topicService)
        {
            _questionService = questionService;
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Questions>>> GetAllQuestions()
        {
            try
            {
                var questions = await _questionService.GetAllAsync();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("active")]
        public async Task<ActionResult<List<Questions>>> GetActiveQuestions()
        {
            try
            {
                var questions = await _questionService.GetActiveQuestionsAsync();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Questions>> GetQuestionById(Guid id)
        {
            try
            {
                var question = await _questionService.GetQuestionByIdAsync(id);
                if (question == null)
                    return NotFound();

                return Ok(question);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Questions>>> GetQuestionsByUser(Guid userId)
        {
            try
            {
                var questions = await _questionService.GetQuestionsByUserIdAsync(userId);
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("topic/{topicId}")]
        public async Task<ActionResult<List<Questions>>> GetQuestionsByTopic(Guid topicId)
        {
            try
            {
                var questions = await _questionService.GetQuestionsByTopicIdAsync(topicId);
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("difficulty/{difficulty}")]
        public async Task<ActionResult<List<Questions>>> GetQuestionsByDifficulty(int difficulty)
        {
            try
            {
                var difficultyEnum = (QuestionsDiff)difficulty;
                var questions = await _questionService.GetQuestionsByDifficultyAsync(difficultyEnum);
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("random")]
        public async Task<ActionResult<List<Questions>>> GetRandomQuestions([FromQuery] int count = 10, [FromQuery] int? difficulty = null, [FromQuery] Guid? topicId = null)
        {
            try
            {
                QuestionsDiff? difficultyEnum = difficulty.HasValue ? (QuestionsDiff)difficulty.Value : null;
                var questions = await _questionService.GetRandomQuestionsAsync(count, difficultyEnum, topicId);
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Questions>> CreateQuestion([FromBody] CreateQuestionDto createQuestionDto)
        {
            try
            {
                var question = new Questions
                {
                    QuestionText = createQuestionDto.QuestionText,
                    DifficultyLevel = createQuestionDto.DifficultyLevel,
                    Source = createQuestionDto.Source,
                    SolutionText = createQuestionDto.SolutionText,
                    GeneratedForUserId = createQuestionDto.GeneratedForUserId
                };

                var createdQuestion = await _questionService.CreateQuestionAsync(question, createQuestionDto.TopicIds, createQuestionDto.Options);
                return CreatedAtAction(nameof(GetQuestionById), new { id = createdQuestion.Id }, createdQuestion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateQuestion(Guid id, [FromBody] UpdateQuestionDto updateQuestionDto)
        {
            try
            {
                var question = new Questions
                {
                    Id = id,
                    QuestionText = updateQuestionDto.QuestionText,
                    DifficultyLevel = updateQuestionDto.DifficultyLevel,
                    Source = updateQuestionDto.Source,
                    SolutionText = updateQuestionDto.SolutionText,
                    IsActive = updateQuestionDto.IsActive
                };

                var result = await _questionService.UpdateQuestionAsync(question, updateQuestionDto.TopicIds, updateQuestionDto.Options);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuestion(Guid id)
        {
            try
            {
                var result = await _questionService.DeactivateQuestionAsync(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("{id}/activate")]
        public async Task<ActionResult> ActivateQuestion(Guid id)
        {
            try
            {
                var result = await _questionService.ActivateQuestionAsync(id);
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

    public class CreateQuestionDto
    {
        public string QuestionText { get; set; }
        public QuestionsDiff DifficultyLevel { get; set; }
        public string Source { get; set; }
        public string SolutionText { get; set; }
        public Guid GeneratedForUserId { get; set; }
        public List<Guid> TopicIds { get; set; }
        public List<string> Options { get; set; }
    }

    public class UpdateQuestionDto
    {
        public string QuestionText { get; set; }
        public QuestionsDiff DifficultyLevel { get; set; }
        public string Source { get; set; }
        public string SolutionText { get; set; }
        public bool IsActive { get; set; }
        public List<Guid> TopicIds { get; set; }
        public List<string> Options { get; set; }
    }
} 