using FluentValidation;
using GreenProject.Backend.Contracts.Errors;
using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Contracts.Users.Roles;

namespace GreenProject.Backend.ApiLayer.Validation
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
