using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string SubjectName { get; set; } // e.g., "Mathematics", "Physics", "Chemistry"
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation Properties
        public ICollection<Topics> Topics { get; set; } = new HashSet<Topics>();
    }
}
