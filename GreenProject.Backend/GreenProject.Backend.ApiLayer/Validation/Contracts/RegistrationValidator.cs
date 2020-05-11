using FluentValidation;
using GreenProject.Backend.ApiLayer.Validation.Configuration;
using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Contracts.Errors;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class RegistrationValidator : AbstractValidator<RegistrationDto>
    {
        public RegistrationValidator(PasswordValidationSettings passwordSettings)
        {
            RuleFor(x => x.Password)
                .ShouldBeAValidPassword(passwordSettings);
        }
    }
}
