using FluentValidation;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.DataAccess.Sql.Model;

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
