using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class QuestionsTopic
    {
        public Guid QuestionId { get; set; }
        public Guid TopicId { get; set; }
        public Questions Question { get; set; }
        public Topics Topic { get; set; }
    }
}
