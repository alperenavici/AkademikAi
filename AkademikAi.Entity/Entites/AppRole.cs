using AkademikAi.Entity.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class AppRole:IdentityRole<Guid>
    {
        public UserRole UserRole { get; set; }
    }
}
