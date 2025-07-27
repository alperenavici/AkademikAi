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
    public class UserRecommendationApiController : ControllerBase
    {
        private readonly IUserRecommendationService _recommendationService;

        public UserRecommendationApiController(IUserRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserRecommendation>>> GetAllRecommendations()
        {
            try
            {
                var recommendations = await _recommendationService.GetAllAsync();
                return Ok(recommendations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRecommendation>> GetRecommendationById(Guid id)
        {
            try
            {
                var recommendation = await _recommendationService.GetByIdAsync(id);
                if (recommendation == null)
                    return NotFound();

                return Ok(recommendation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<UserRecommendation>>> GetUserRecommendations(Guid userId)
        {
            try
            {
                var recommendations = await _recommendationService.GetUserRecommendationsAsync(userId);
                return Ok(recommendations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/active")]
        public async Task<ActionResult<List<UserRecommendation>>> GetActiveUserRecommendations(Guid userId)
        {
            try
            {
                var recommendations = await _recommendationService.GetActiveRecommendationsForUserAsync(userId);
                return Ok(recommendations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/latest")]
        public async Task<ActionResult<UserRecommendation>> GetLatestUserRecommendation(Guid userId)
        {
            try
            {
                var recommendation = await _recommendationService.GetLatestUserRecommendationAsync(userId);
                if (recommendation == null)
                    return NotFound();

                return Ok(recommendation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("type/{recommendationType}")]
        public async Task<ActionResult<List<UserRecommendation>>> GetRecommendationsByType(int recommendationType)
        {
            try
            {
                var recommendations = await _recommendationService.GetRecommendationsByTypeAsync(recommendationType);
                return Ok(recommendations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/topic/{topicId}/check")]
        public async Task<ActionResult<bool>> CheckActiveRecommendationForTopic(Guid userId, Guid topicId, [FromQuery] int recommendationType)
        {
            try
            {
                var hasActive = await _recommendationService.HasActiveRecommendationForTopicAsync(userId, topicId, recommendationType);
                return Ok(hasActive);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserRecommendation>> CreateRecommendation([FromBody] CreateRecommendationDto createRecommendationDto)
        {
            try
            {
                var recommendation = await _recommendationService.CreateRecommendationAsync(
                    createRecommendationDto.UserId, 
                    createRecommendationDto.RecommendationText, 
                    createRecommendationDto.RecommendationType);

                return CreatedAtAction(nameof(GetRecommendationById), new { id = recommendation.Id }, recommendation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRecommendation(Guid id, [FromBody] UpdateRecommendationDto updateRecommendationDto)
        {
            try
            {
                var result = await _recommendationService.UpdateRecommendationAsync(id, updateRecommendationDto.RecommendationText);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("{id}/mark-as-read")]
        public async Task<ActionResult> MarkRecommendationAsRead(Guid id)
        {
            try
            {
                var result = await _recommendationService.MarkRecommendationAsReadAsync(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("{id}/mark-as-applied")]
        public async Task<ActionResult> MarkRecommendationAsApplied(Guid id)
        {
            try
            {
                var result = await _recommendationService.MarkRecommendationAsAppliedAsync(id);
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
        public async Task<ActionResult> DeleteRecommendation(Guid id)
        {
            try
            {
                var result = await _recommendationService.DeleteRecommendationAsync(id);
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

    public class CreateRecommendationDto
    {
        public Guid UserId { get; set; }
        public string RecommendationText { get; set; }
        public int RecommendationType { get; set; }
    }

    public class UpdateRecommendationDto
    {
        public string RecommendationText { get; set; }
    }
} 