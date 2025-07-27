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
    public class UserPerformanceApiController : ControllerBase
    {
        private readonly IUserPerformanceSummaryService _performanceService;

        public UserPerformanceApiController(IUserPerformanceSummaryService performanceService)
        {
            _performanceService = performanceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserPerformanceSummaries>>> GetAllPerformanceSummaries()
        {
            try
            {
                var summaries = await _performanceService.GetAllAsync();
                return Ok(summaries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserPerformanceSummaries>> GetPerformanceSummaryById(Guid id)
        {
            try
            {
                var summary = await _performanceService.GetByIdAsync(id);
                if (summary == null)
                    return NotFound();

                return Ok(summary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<UserPerformanceSummaries>> GetUserPerformanceSummary(Guid userId)
        {
            try
            {
                var summary = await _performanceService.GetUserPerformanceSummaryAsync(userId);
                if (summary == null)
                    return NotFound();

                return Ok(summary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/latest")]
        public async Task<ActionResult<UserPerformanceSummaries>> GetLatestUserPerformanceSummary(Guid userId)
        {
            try
            {
                var summary = await _performanceService.GetLatestUserPerformanceSummaryAsync(userId);
                if (summary == null)
                    return NotFound();

                return Ok(summary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/date-range")]
        public async Task<ActionResult<List<UserPerformanceSummaries>>> GetUserPerformanceSummariesByDateRange(
            Guid userId, 
            [FromQuery] DateTime startDate, 
            [FromQuery] DateTime endDate)
        {
            try
            {
                var summaries = await _performanceService.GetUserPerformanceSummariesByDateRangeAsync(userId, startDate, endDate);
                return Ok(summaries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("top-performers")]
        public async Task<ActionResult<List<UserPerformanceSummaries>>> GetTopPerformers([FromQuery] int count = 10)
        {
            try
            {
                var topPerformers = await _performanceService.GetTopPerformersAsync(count);
                return Ok(topPerformers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("average-performance-by-topic")]
        public async Task<ActionResult<Dictionary<string, double>>> GetAveragePerformanceByTopic()
        {
            try
            {
                var averagePerformance = await _performanceService.GetAveragePerformanceByTopicAsync();
                return Ok(averagePerformance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("by-success-rate-range")]
        public async Task<ActionResult<List<UserPerformanceSummaries>>> GetPerformanceSummariesBySuccessRateRange(
            [FromQuery] double minRate, 
            [FromQuery] double maxRate)
        {
            try
            {
                var summaries = await _performanceService.GetPerformanceSummariesBySuccessRateRangeAsync(minRate, maxRate);
                return Ok(summaries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("user/{userId}/create-or-update")]
        public async Task<ActionResult<UserPerformanceSummaries>> CreateOrUpdatePerformanceSummary(Guid userId)
        {
            try
            {
                var summary = await _performanceService.CreateOrUpdatePerformanceSummaryAsync(userId);
                if (summary == null)
                    return BadRequest("No answers found for user");

                return Ok(summary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePerformanceSummary(Guid id, [FromBody] UserPerformanceSummaries summary)
        {
            try
            {
                summary.Id = id;
                var result = await _performanceService.UpdatePerformanceSummaryAsync(summary);
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
} 