using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class Category
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Tags> Tags { get; set; }
    }
}
