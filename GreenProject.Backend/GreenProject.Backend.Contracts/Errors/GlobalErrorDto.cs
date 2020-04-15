using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Errors
{
    public class GlobalErrorDto
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
