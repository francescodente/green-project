using FluentValidation;
using GreenProject.Backend.Contracts.Support;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class SupportRequestValidator : AbstractValidator<SupportRequestDto>
    {
        public SupportRequestValidator()
        {
            RuleFor(x => x.SenderEmail)
                .ShouldNotBeEmpty()
                .ShouldBeAnEmailAddress();

            RuleFor(x => x.Subject)
                .ShouldNotBeEmpty()
                .ShouldHaveMaxLength(50);

            RuleFor(x => x.Body)
                .ShouldNotBeEmpty()
                .ShouldHaveMaxLength(4000);
        }
    }
}
