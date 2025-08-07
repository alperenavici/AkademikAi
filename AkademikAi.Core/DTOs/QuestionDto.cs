using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Core.DTOs
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public List<QuestionOptionDto> Options { get; set; }
    }

    public class  QuestionOptionDto
    {
        public Guid Id { get; set; }
        public string OptionText { get; set; }
        public char Label { get; set; } // e.g., 'A', 'B', 'C', 'D'

    }
}
