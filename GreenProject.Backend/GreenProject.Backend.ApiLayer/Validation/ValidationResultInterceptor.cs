using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using GreenProject.Backend.ApiLayer.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Validation
{
    public class ValidationResultInterceptor : IValidatorInterceptor
    {
        public ValidationResult AfterMvcValidation(ControllerContext controllerContext, ValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {
                controllerContext.HttpContext.Items.Add(ValidationFilter.VALIDATION_RESULT_KEY, result);
            }
            return result;
        }

        public ValidationContext BeforeMvcValidation(ControllerContext controllerContext, ValidationContext validationContext)
        {
            return validationContext;
        }
    }
}
