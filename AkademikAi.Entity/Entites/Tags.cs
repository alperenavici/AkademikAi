using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Entity.Entites
{
    public class Tags
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }
        public Category CategoryId { get; set; }

    }
}
