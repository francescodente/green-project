using FluentValidation;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;

namespace FruitRacers.Backend.ApiLayer.Validation
{
    public abstract class UserInputValidator<T> : AbstractValidator<UserInputDto<T>>
        where T : RoleDto
    {
        public UserInputValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }

    public class PersonUserInputValidator : UserInputValidator<PersonDto>
    {

    }

    public class SupplierUserInputValidator : UserInputValidator<SupplierDto>
    {

    }

    public class CustomerBusinessUserInputValidator : UserInputValidator<CustomerBusinessDto>
    {

    }
}
