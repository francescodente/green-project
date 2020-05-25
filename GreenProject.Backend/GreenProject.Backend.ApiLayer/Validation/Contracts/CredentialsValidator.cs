using FluentValidation;
using GreenProject.Backend.Contracts.Authentication;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class CredentialsValidator : AbstractValidator<CredentialsDto>
    {
        public CredentialsValidator()
        {
            RuleFor(x => x.Email)
                .ShouldNotBeEmpty()
                .ShouldBeAnEmailAddress();

            RuleFor(x => x.Password)
                .ShouldNotBeEmpty();
        }
    }
}
