using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class QuestionTags
    {
        public Guid QuestionId { get; set; }
        public Guid TagId { get; set; }
        // Navigation Properties
        public Questions Question { get; set; }
        public Tags Tag { get; set; }
    }
}
