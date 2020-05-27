using FluentValidation;
using GreenProject.Backend.Contracts.PurchasableItems;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class QuantifiedProductValidator : AbstractValidator<QuantifiedProductDto.Input>
    {
        public QuantifiedProductValidator()
        {
            RuleFor(x => x.ProductId)
                .ShouldBeGreaterThan(0);

            RuleFor(x => x.Quantity)
                .ShouldBeGreaterThan(0);
        }
    }
}
