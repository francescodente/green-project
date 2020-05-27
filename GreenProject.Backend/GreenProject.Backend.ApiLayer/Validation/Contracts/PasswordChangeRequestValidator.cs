using FluentValidation;
using GreenProject.Backend.ApiLayer.Validation.Configuration;
using GreenProject.Backend.Contracts.Authentication;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class PasswordChangeRequestValidator : AbstractValidator<PasswordChangeRequestDto>
    {
        public PasswordChangeRequestValidator(PasswordValidationSettings settings)
        {
            RuleFor(x => x.NewPassword)
                .ShouldBeAValidPassword(settings);

            RuleFor(x => x.OldPassword)
                .ShouldNotBeEmpty();
        }
    }
}
