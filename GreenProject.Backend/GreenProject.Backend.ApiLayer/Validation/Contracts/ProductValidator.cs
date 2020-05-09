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
    public class ProductInsertionValidator : AbstractValidator<ProductDto.Insertion>
    {
        public ProductInsertionValidator()
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

            RuleFor(x => x.CategoryId)
                .ShouldBeGreaterThan(0);

            RuleFor(x => x.UnitName)
                .ShouldBeInEnum();

            RuleFor(x => x.UnitMultiplier)
                .ShouldBeGreaterThan(0)
                .ShouldHaveScalePrecision(ProductModel.UnitMultiplierScale, ProductModel.UnitMultiplierPrecision);

            RuleForEach(x => x.CompatibleCrates)
                .SetValidator(new CompatibilityValidator())
                .When(x => x.CompatibleCrates != null);
        }
    }

    public class ProductUpdateValidator : AbstractValidator<ProductDto.Update>
    {
        public ProductUpdateValidator()
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

            RuleFor(x => x.CategoryId)
                .ShouldBeGreaterThan(0);

            RuleForEach(x => x.CompatibleCrates)
                .SetValidator(new CompatibilityValidator())
                .When(x => x.CompatibleCrates != null);
        }
    }
}
