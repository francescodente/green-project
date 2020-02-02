using FluentValidation;
using FruitRacers.Backend.Contracts.Users.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer.Validation
{
    public abstract class AbstractBusinessValidator<T> : AbstractValidator<T>
        where T : BusinessDto
    {
        public AbstractBusinessValidator()
        {
            RuleFor(x => x.BusinessName)
                .NotEmpty();

            RuleFor(x => x.LegalForm)
                .NotEmpty();

            RuleFor(x => x.Pec)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Sdi)
                .NotEmpty();

            RuleFor(x => x.VatNumber)
                .NotEmpty();
        }
    }
}
