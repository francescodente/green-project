using FluentValidation;
using GreenProject.Backend.Contracts.Users;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class UserValidator : AbstractValidator<UserDto.Input>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .ShouldNotBeEmpty()
                .ShouldBeAnEmailAddress();
        }
    }
}
