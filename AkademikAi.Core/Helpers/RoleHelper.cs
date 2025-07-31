using AkademikAi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Core.Helpers
{
        public static class RoleHelper
        {
            public static IEnumerable<string> GetAllRoles()
            {
                return Enum.GetNames(typeof(UserRole));
            }

            public static string ToRoleString(UserRole role)
            {
                return role.ToString();
            }
        }

    
}
