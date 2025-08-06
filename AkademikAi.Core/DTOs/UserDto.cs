using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Core.DTOs
{
    public class UserDto
    {
        
        public required string Name { get; set; } 
        public required string Surname { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public int UserRole { get; set; }// 0: öğrenci, 1: öğretmen, 2: admin
        public DateTime CreatedAt { get; set; }
    }
}
