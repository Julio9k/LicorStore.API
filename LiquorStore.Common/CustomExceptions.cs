using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Common;

public static class CustomExceptions
{
    public class EmailServiceException : Exception
    {
        public EmailServiceException(string message) : base(message)
        {
        }
    }

    public class BusinessException : Exception
    {
        public Dictionary<string, string>? Errors { get; set; }
        public BusinessException(Dictionary<string, string> errors, string message = "") : base(message)
        {
            Errors = errors;
        }
    }

    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message) : base(message)
        {
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}