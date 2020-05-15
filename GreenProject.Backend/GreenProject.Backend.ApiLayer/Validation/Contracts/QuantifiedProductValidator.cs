using FluentValidation;
using GreenProject.Backend.Contracts.PurchasableItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
