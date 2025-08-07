using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Core.DTOs
{
    public class SubjectDto
    {
        public Guid Id { get; set; }
        public string SubjectName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class SubjectCreateDto
    {
        public string SubjectName { get; set; }
        public string? Description { get; set; }
    }

    public class SubjectUpdateDto
    {
        public string SubjectName { get; set; }
        public string? Description { get; set; }
    }

    public class SubjectWithTopicsDto
    {
        public Guid Id { get; set; }
        public string SubjectName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public List<TopicDto> Topics { get; set; } = new List<TopicDto>();
    }

    public class TopicDto
    {
        public Guid Id { get; set; }
        public string TopicName { get; set; }
        public Guid SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public Guid? ParentTopicId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class TopicCreateDto
    {
        public string TopicName { get; set; }
        public Guid SubjectId { get; set; }
        public Guid? ParentTopicId { get; set; }
    }

    public class TopicUpdateDto
    {
        public string TopicName { get; set; }
        public Guid SubjectId { get; set; }
        public Guid? ParentTopicId { get; set; }
    }
}
