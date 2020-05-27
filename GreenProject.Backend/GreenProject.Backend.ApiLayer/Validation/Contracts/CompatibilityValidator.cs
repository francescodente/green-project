using FluentValidation;
using GreenProject.Backend.Contracts.PurchasableItems;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class CompatibilityValidator : AbstractValidator<CompatibilityDto.InputWithCrate>
    {
        public CompatibilityValidator()
        {
            RuleFor(x => x.CrateId)
                .ShouldBeGreaterThan(0);

            RuleFor(x => x.Maximum)
                .ShouldBeGreaterThan(0)
                .When(x => x.Maximum.HasValue);
        }
    }
}
