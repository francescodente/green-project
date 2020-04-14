using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Errors
{
    public class PropertyErrorDto
    {
        public string Property { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
    }
}
