using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Errors
{
    public class ValidationErrorResponse
    {
        public IEnumerable<ErrorDto> Errors { get; set; }
    }
}
