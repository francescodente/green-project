using FluentValidation.Results;
using GreenProject.Backend.Contracts.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public const string VALIDATION_RESULT_KEY = "validation";

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            ValidationResult result = context.HttpContext.Items[VALIDATION_RESULT_KEY] as ValidationResult;

            ErrorResponseDto errorResponse = new ErrorResponseDto
            {
                GlobalErrors = Enumerable.Empty<GlobalErrorDto>(),
                PropertyErrors = result.Errors.Select(f => new PropertyErrorDto
                {
                    Code = f.ErrorCode,
                    Message = f.ErrorMessage,
                    Property = f.PropertyName
                })
            };

            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }
}
