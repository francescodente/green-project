using FluentValidation;
using GreenProject.Backend.ApiLayer.Validation.Configuration;
using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Contracts.Errors;

namespace GreenProject.Backend.ApiLayer.Validation
{
    public class RegistrationValidator : AbstractValidator<RegistrationDto>
    {
        public RegistrationValidator(PasswordValidationSettings passwordSettings)
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithErrorCode(ErrorCodes.Common.MissingValue)
                .Length(passwordSettings.MinimumLength, passwordSettings.MaximumLength).WithErrorCode(ErrorCodes.Common.IncorrectFormat);
        }
    }
}
