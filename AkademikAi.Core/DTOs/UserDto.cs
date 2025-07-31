using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Core.DTOs
{
    public class UserDto
    {
        
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int UserRole { get; set; }// 0: öğrenci, 1: öğretmen, 2: admin
        public DateTime CreatedAt { get; set; }
    }
}
