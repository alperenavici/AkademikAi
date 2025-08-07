using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class Topics
    {
        public Guid Id { get; set; }
        public string TopicName { get; set; } // e.g., "Geometry", "Algebra", "Thermodynamics"
        public Guid SubjectId { get; set; } // Foreign key to Subject
        public Guid? ParentTopicId { get; set; } // alt konu üst konu
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation Properties
        public Subject Subject { get; set; }
        public Topics? ParentTopic { get; set; }
        public ICollection<Topics> SubTopics { get; set; } = new HashSet<Topics>();
        public ICollection<QuestionsTopic> QuestionsTopics { get; set; } = new HashSet<QuestionsTopic>();
    }
}
