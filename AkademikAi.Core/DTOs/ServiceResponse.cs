using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Core.DTOs
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public required string Message { get; set; }
        public T? Data { get; set; }
    }
} 