using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Errors
{
    public class ErrorResponseDto
    {
        public IEnumerable<PropertyErrorDto> PropertyErrors { get; set; }
        public IEnumerable<GlobalErrorDto> GlobalErrors { get; set; }
    }
}
