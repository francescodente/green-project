using FluentValidation;
using GreenProject.Backend.Contracts.Errors;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.DataAccess.Sql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class CrateValidator : AbstractValidator<CrateDto.Input>
    {
        public CrateValidator()
        {
            RuleFor(x => x.Name)
                .ShouldNotBeEmpty()
                .ShouldHaveMaxLength(PurchasableItemModel.NameSize);

            RuleFor(x => x.Description)
                .ShouldNotBeEmpty()
                .ShouldHaveMaxLength(PurchasableItemModel.DescriptionSize);

            RuleFor(x => x.Price)
                .ShouldBeGreaterThanOrEqualTo(0);

            RuleFor(x => x.IvaPercentage)
                .ShouldBeGreaterThanOrEqualTo(0)
                .ShouldHaveScalePrecision(PurchasableItemModel.IvaPercentageScale, PurchasableItemModel.IvaPercentagePrecision);

            RuleFor(x => x.Capacity)
                .ShouldBeGreaterThan(0);
        }
    }
}
