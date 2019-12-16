using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.Errors
{
    public class ValidationErrorResponse
    {
        public IEnumerable<ErrorDto> Errors { get; set; }
    }
}
