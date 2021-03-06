using GreenProject.Backend.Contracts.Errors;

namespace GreenProject.Backend.Core.Exceptions
{
    public class CartEmptyException : DomainException
    {
        public CartEmptyException()
            : base("Unable to confirm the order because the shopping cart is empty")
        {

        }

        public override string MainErrorCode => ErrorCodes.Cart.Empty;
    }
}
