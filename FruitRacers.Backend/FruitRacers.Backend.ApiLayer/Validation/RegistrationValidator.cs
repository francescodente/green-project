using FluentValidation;
using FruitRacers.Backend.ApiLayer.Validation.Configuration;
using FruitRacers.Backend.Contracts.Authentication;

namespace FruitRacers.Backend.ApiLayer.Validation
{
    public class RegistrationValidator : AbstractValidator<RegistrationDto>
    {
        public RegistrationValidator(PasswordValidationSettings passwordSettings)
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(passwordSettings.MinimumLength, passwordSettings.MaximumLength);
        }
    }
}
