using FluentValidation.Results;
using GreenProject.Backend.Contracts.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace GreenProject.Backend.ApiLayer.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public const string ValidationResultKey = "validation";

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var result = context.HttpContext.Items[ValidationResultKey] as ValidationResult;

            context.Result = new BadRequestObjectResult(CreateErrorResponse(result));
        }

        private ErrorResponseDto CreateErrorResponse(ValidationResult result)
        {
            if (result == null)
            {
                return new ErrorResponseDto
                {
                    GlobalErrors = GetDefaultGlobalError(),
                    PropertyErrors = Enumerable.Empty<PropertyErrorDto>()
                };
            }

            return new ErrorResponseDto
            {
                GlobalErrors = Enumerable.Empty<GlobalErrorDto>(),
                PropertyErrors = result.Errors.Select(f => new PropertyErrorDto
                {
                    Code = f.ErrorCode,
                    Message = f.ErrorMessage,
                    Property = f.PropertyName
                })
            };
        }

        private IEnumerable<GlobalErrorDto> GetDefaultGlobalError()
        {
            yield return new GlobalErrorDto
            {
                Code = ErrorCodes.Common.UnsupportedValue,
                Message = "The supplied json body is not supported"
            };
        }
    }
}
