using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class DiagnosticReports
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }    
        public string ReportTitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public AppUser User { get; set; }
        public Exam Exam { get; set; }
        public ICollection<Exam> Exams{ get; set; }
        public ICollection<UserRecommendation> UserRecommendations { get; set; }
    }
}
