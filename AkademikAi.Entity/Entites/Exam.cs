using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;

namespace AkademikAi.Entity.Entites
{
    public class Exam
    {
        public Guid Id { get; set; }
        public string Title { get; set; } // e.g., Türkiye GENELİ TYT AYT
        public string? Description { get; set; } // e.g., 
        public DateTime StartTime { get; set; } // e.g., 2025-06-01T10:00:0
        public DateTime EndTime { get; set; } // e.g., 2025-06-01T12:00:00
        public int DurationMinutes { get; set; } // sın süresi dakika cinsinden
        public ExamStatus Status { get; set; } // e.g., Scheduled, Ongoing, Completed
        public DateTime CreatedAt { get; set; } // e.g., 2025-01-01T10:00:00


        public ICollection<ExamQuestions> ExamQuestions { get; set; } = new HashSet<ExamQuestions>(); // Sınav soruları ara tablo üzerinden
        public ICollection<ExamParticipant> Participants { get; set; } = new HashSet<ExamParticipant>();
        public ICollection<UserAnswers> UserAnswers { get; set; } = new HashSet<UserAnswers>();// Kullanıcı cevapları

    }
}
