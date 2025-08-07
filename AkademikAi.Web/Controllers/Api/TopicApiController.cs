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
    public class TopicApiController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicApiController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Topics>>> GetAllTopics()
        {
            try
            {
                var topics = await _topicService.GetAllAsync();
                return Ok(topics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("main")]
        public async Task<ActionResult<List<Topics>>> GetMainTopics()
        {
            try
            {
                var topics = await _topicService.GetMainTopicsAsync();
                return Ok(topics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Topics>> GetTopicById(Guid id)
        {
            try
            {
                var topic = await _topicService.GetByIdAsync(id);
                if (topic == null)
                    return NotFound();

                return Ok(topic);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}/subtopics")]
        public async Task<ActionResult<List<Topics>>> GetSubTopics(Guid id)
        {
            try
            {
                var subTopics = await _topicService.GetSubTopicsAsync(id);
                return Ok(subTopics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("by-subject/{subjectId}")]
        public async Task<ActionResult<List<Topics>>> GetTopicsBySubject(Guid subjectId)
        {
            try
            {
                var topics = await _topicService.GetTopicsBySubjectIdAsync(subjectId);
                return Ok(topics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}/with-subtopics")]
        public async Task<ActionResult<Topics>> GetTopicWithSubTopics(Guid id)
        {
            try
            {
                var topic = await _topicService.GetTopicWithSubTopicsAsync(id);
                if (topic == null)
                    return NotFound();

                return Ok(topic);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("hierarchy")]
        public async Task<ActionResult<List<Topics>>> GetTopicHierarchy()
        {
            try
            {
                var hierarchy = _topicService.GetTopicHierarchyAsync();
                return Ok(hierarchy);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("question-counts")]
        public async Task<ActionResult<Dictionary<string, int>>> GetTopicQuestionCounts()
        {
            try
            {
                var counts = await _topicService.GetTopicQuestionCountsAsync();
                return Ok(counts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("by-question-count")]
        public async Task<ActionResult<List<Topics>>> GetTopicsByQuestionCount([FromQuery] int minQuestionCount = 0)
        {
            try
            {
                var topics = await _topicService.GetTopicsByQuestionCountAsync(minQuestionCount);
                return Ok(topics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Topics>> CreateTopic([FromBody] CreateTopicDto createTopicDto)
        {
            try
            {
                var topic = await _topicService.CreateTopicAsync(createTopicDto.TopicName, createTopicDto.SubjectId, createTopicDto.ParentTopicId);
                return CreatedAtAction(nameof(GetTopicById), new { id = topic.Id }, topic);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTopic(Guid id, [FromBody] UpdateTopicDto updateTopicDto)
        {
            try
            {
                var result = await _topicService.UpdateTopicAsync(id, updateTopicDto.TopicName, updateTopicDto.SubjectId, updateTopicDto.ParentTopicId);
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
        public async Task<ActionResult> DeleteTopic(Guid id)
        {
            try
            {
                var result = await _topicService.DeleteTopicAsync(id);
                if (!result)
                    return BadRequest("Cannot delete topic with sub-topics or questions");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    public class CreateTopicDto
    {
        public string TopicName { get; set; }
        public Guid SubjectId { get; set; }
        public Guid? ParentTopicId { get; set; }
    }

    public class UpdateTopicDto
    {
        public string TopicName { get; set; }
        public Guid SubjectId { get; set; }
        public Guid? ParentTopicId { get; set; }
    }
} 