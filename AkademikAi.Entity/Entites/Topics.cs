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
        public string TopicName { get; set; } // e.g., "Mathematics", "Science"
        public Guid? ParentTopicId { get; set; } // alt soru üst soru
        
        public ICollection<QuestionsTopic> QuestionsTopics { get; set; }
    }
}
