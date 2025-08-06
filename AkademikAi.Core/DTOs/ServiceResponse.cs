using System.Collections.Generic;

namespace AkademikAi.Core.DTOs
{
    public class ServiceResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<ServiceError> Errors { get; set; } = new List<ServiceError>();

        public static ServiceResponse Success(string message = "İşlem başarılı")
        {
            return new ServiceResponse
            {
                Succeeded = true,
                Message = message
            };
        }

        public static ServiceResponse Failure(string message = "İşlem başarısız")
        {
            return new ServiceResponse
            {
                Succeeded = false,
                Message = message
            };
        }

        public static ServiceResponse Failure(List<ServiceError> errors)
        {
            return new ServiceResponse
            {
                Succeeded = false,
                Errors = errors
            };
        }
    }

    public class ServiceError
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public ServiceError(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
} 