using FluentValidation;
using GreenProject.Backend.Contracts.Categories;
using GreenProject.Backend.DataAccess.Sql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class CategoryValidator : AbstractValidator<CategoryDto.Input>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.ParentCategoryId)
                .ShouldBeGreaterThan(0);

            RuleFor(x => x.Name)
                .ShouldNotBeEmpty()
                .ShouldHaveMaxLength(CategoryModel.NameSize);

            RuleFor(x => x.Description)
                .ShouldHaveMaxLength(CategoryModel.DescriptionSize);
        }
    }
}
