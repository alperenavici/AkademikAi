using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class Questions
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
       
        public QuestionsDiff  DifficultyLevel { get; set; } // 1: Easy, 2: Medium, 3: Hard
        public string Source { get; set; } //ai or meb
        public bool IsActive { get; set; }
        public string SolutionText { get; set; }
        public Guid? GeneratedForUserId { get; set; }
        public AppUser GeneratedForUser { get; set; }
        public ICollection<QuestionsTopic> QuestionsTopics { get; set; }
        public ICollection<QuestionsOptions> QuestionsOptions { get; set; }
        public ICollection<UserAnswers> UserAnswers { get; set; } // Eksikse ekle


    }
}
