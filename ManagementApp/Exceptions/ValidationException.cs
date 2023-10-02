using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Management.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationException(ValidationResult result)
        {
            foreach(var i in result.Errors)
            {
                Errors.Add(i.ErrorMessage);
            }
        }
    }
}
 