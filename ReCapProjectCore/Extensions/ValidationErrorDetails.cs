using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectCore.Extensions
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
