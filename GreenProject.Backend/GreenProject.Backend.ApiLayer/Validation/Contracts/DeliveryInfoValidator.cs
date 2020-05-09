using FluentValidation;
using GreenProject.Backend.Contracts.Orders.Delivery;
using GreenProject.Backend.DataAccess.Sql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class DeliveryInfoValidator : AbstractValidator<DeliveryInfoDto.Input>
    {
        public DeliveryInfoValidator()
        {
            RuleFor(x => x.AddressId)
                .ShouldBeGreaterThan(0);

            RuleFor(x => x.Notes)
                .ShouldHaveMaxLength(OrderModel.NotesSize)
                .When(x => x.Notes != null);
        }
    }
}
