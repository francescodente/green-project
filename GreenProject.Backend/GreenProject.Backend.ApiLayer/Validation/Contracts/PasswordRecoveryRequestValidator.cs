using FluentValidation;
using GreenProject.Backend.Contracts.Authentication;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class PasswordRecoveryRequestValidator : AbstractValidator<PasswordRecoveryRequestDto>
    {
        public PasswordRecoveryRequestValidator()
        {
            RuleFor(x => x.Email)
                .ShouldNotBeEmpty()
                .ShouldBeAnEmailAddress();
        }
    }
}
