using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Enums
{
    public enum ExamStatus
    {
        Scheduled, // Sınav planlandı
        InProgress, // Sınav devam ediyor
        Completed, // Sınav tamamlandı
        Cancelled, // Sınav iptal edildi
    }
}
