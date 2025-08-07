using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Enums
{
    public enum ExamParticipationStatus
    {
        Registered, // Sınav için kayıtlı
        Attended, // Sınavı katıldı
        Completed, // Sınavı tamamladı
        Absent, //sınava girmedi
        Started
    }
}
