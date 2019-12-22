using FluentValidation;
using FruitRacers.Backend.ApiLayer.Validation.Configuration;
using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users.Roles;
using Microsoft.Extensions.Options;

namespace FruitRacers.Backend.ApiLayer.Validation
{
    public abstract class RegistrationValidator<T> : AbstractValidator<RegistrationDto<T>>
        where T : RoleDto
    {
        public RegistrationValidator(IOptions<PasswordValidationSettings> passwordOptions)
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(passwordOptions.Value.MinimumLength, passwordOptions.Value.MaximumLength);
        }
    }

    public class PersonRegistrationValidator : RegistrationValidator<PersonDto>
    {
        public PersonRegistrationValidator(IOptions<PasswordValidationSettings> passwordOptions)
            : base(passwordOptions)
        {

        }
    }

    public class SupplierRegistrationValidator : RegistrationValidator<SupplierDto>
    {
        public SupplierRegistrationValidator(IOptions<PasswordValidationSettings> passwordOptions)
            : base(passwordOptions)
        {

        }
    }

    public class CustomerBusinessRegistrationValidator : RegistrationValidator<CustomerBusinessDto>
    {
        public CustomerBusinessRegistrationValidator(IOptions<PasswordValidationSettings> passwordOptions)
            : base(passwordOptions)
        {

        }
    }
}
