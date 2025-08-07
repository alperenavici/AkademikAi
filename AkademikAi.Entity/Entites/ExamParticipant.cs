using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;

namespace AkademikAi.Entity.Entites
{
    public class ExamParticipant
    {
        public Guid UserId { get; set; } // Katılımcı kullanıcının ID'si
        public AppUser User { get; set; } // Katılımcı kullanıcı bilgileri

        public Guid ExamId { get; set; } // Sınavın ID'si
        public Exam Exam { get; set; } // Sınav bilgileri

        public ExamParticipationStatus Status { get; set; }// Katılım durumu (e.g., NotStarted, InProgress, Completed, Abandoned)
        public DateTime? TimeStarted { get; set; } // Sınavın başlama zamanı
        public DateTime? TimFinished { get; set; } // Sınavın bitiş zamanı
        public double? Score { get; set; } // Kullanıcının sınavdan aldığı puan
        public DateTime TimeFinished { get; set; }
    }
}
