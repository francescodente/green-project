using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.Errors
{
    public class ErrorDto
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}
