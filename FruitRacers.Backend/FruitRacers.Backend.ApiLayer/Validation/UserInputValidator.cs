using FluentValidation;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;

namespace FruitRacers.Backend.ApiLayer.Validation
{
    public class UserInputValidator : AbstractValidator<UserInputDto>
    {
        public UserInputValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
