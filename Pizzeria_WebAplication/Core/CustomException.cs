using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CustomException : Exception
    {
        public List<ValidationResult> Errors { get; private set; }

        public CustomException(List<ValidationResult> errors)
        {
            Errors = errors;
        }
    }
}
