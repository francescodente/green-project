using FluentValidation;
using FruitRacers.Backend.ApiLayer.Validation.Configuration;
using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users.Roles;
using Microsoft.Extensions.Options;

namespace FruitRacers.Backend.ApiLayer.Validation
{
    public class RegistrationValidator : AbstractValidator<RegistrationDto>
    {
        public RegistrationValidator(IOptions<PasswordValidationSettings> passwordOptions)
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(passwordOptions.Value.MinimumLength, passwordOptions.Value.MaximumLength);
        }
    }
}
