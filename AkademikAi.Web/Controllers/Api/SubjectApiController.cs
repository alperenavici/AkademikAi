using AkademikAi.Core.DTOs;
using AkademikAi.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectApiController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectApiController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubjectDto>>> GetAllSubjects()
        {
            try
            {
                var subjects = await _subjectService.GetActiveSubjectsAsync();
                var subjectDtos = subjects.Select(s => new SubjectDto
                {
                    Id = s.Id,
                    SubjectName = s.SubjectName,
                    Description = s.Description,
                    IsActive = s.IsActive,
                    CreatedAt = s.CreatedAt
                }).ToList();

                return Ok(subjectDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetSubjectById(Guid id)
        {
            try
            {
                var subject = await _subjectService.GetByIdAsync(id);
                if (subject == null)
                    return NotFound();

                var subjectDto = new SubjectDto
                {
                    Id = subject.Id,
                    SubjectName = subject.SubjectName,
                    Description = subject.Description,
                    IsActive = subject.IsActive,
                    CreatedAt = subject.CreatedAt
                };

                return Ok(subjectDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}/topics")]
        public async Task<ActionResult<SubjectWithTopicsDto>> GetSubjectWithTopics(Guid id)
        {
            try
            {
                var subject = await _subjectService.GetSubjectWithTopicsAsync(id);
                if (subject == null)
                    return NotFound();

                var subjectDto = new SubjectWithTopicsDto
                {
                    Id = subject.Id,
                    SubjectName = subject.SubjectName,
                    Description = subject.Description,
                    IsActive = subject.IsActive,
                    Topics = subject.Topics.Where(t => t.IsActive).Select(t => new TopicDto
                    {
                        Id = t.Id,
                        TopicName = t.TopicName,
                        SubjectId = t.SubjectId,
                        SubjectName = subject.SubjectName,
                        ParentTopicId = t.ParentTopicId,
                        IsActive = t.IsActive,
                        CreatedAt = t.CreatedAt
                    }).ToList()
                };

                return Ok(subjectDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SubjectDto>> CreateSubject([FromBody] SubjectCreateDto createSubjectDto)
        {
            try
            {
                var subject = await _subjectService.CreateSubjectAsync(createSubjectDto.SubjectName, createSubjectDto.Description);
                var subjectDto = new SubjectDto
                {
                    Id = subject.Id,
                    SubjectName = subject.SubjectName,
                    Description = subject.Description,
                    IsActive = subject.IsActive,
                    CreatedAt = subject.CreatedAt
                };

                return CreatedAtAction(nameof(GetSubjectById), new { id = subject.Id }, subjectDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubject(Guid id, [FromBody] SubjectUpdateDto updateSubjectDto)
        {
            try
            {
                var result = await _subjectService.UpdateSubjectAsync(id, updateSubjectDto.SubjectName, updateSubjectDto.Description);
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
        public async Task<ActionResult> DeleteSubject(Guid id)
        {
            try
            {
                var result = await _subjectService.DeleteSubjectAsync(id);
                if (!result)
                    return BadRequest("Cannot delete subject with topics");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
