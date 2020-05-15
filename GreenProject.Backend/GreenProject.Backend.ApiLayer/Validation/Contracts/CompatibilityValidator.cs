﻿using FluentValidation;
using GreenProject.Backend.Contracts.PurchasableItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class CompatibilityValidator : AbstractValidator<CompatibilityDto.Input>
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
