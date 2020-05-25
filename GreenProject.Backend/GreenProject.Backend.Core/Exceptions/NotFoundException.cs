using GreenProject.Backend.Contracts.Errors;
using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class NotFoundException : DomainException
    {
        public override string MainErrorCode => _resourceName == null ? ErrorCodes.Common.NotFound : ErrorCodes.Common.ResourceNotFound(_resourceName);

        private readonly string _resourceName;

        private NotFoundException(string message, string resourceName)
            : base(message)
        {
            _resourceName = resourceName;
        }

        public static NotFoundException WithMessage(string message, string resourceName = null)
        {
            return new NotFoundException(message, resourceName);
        }

        public static NotFoundException ResourceWithProperty(string resourceType, string propertyName, object propertyValue)
        {
            return WithMessage($"Unable to find {resourceType} with {propertyName} equal to {propertyValue}", resourceType);
        }

        public static NotFoundException ResourceWithId(string resourceType, int id)
        {
            return ResourceWithProperty(resourceType, "ID", id);
        }

        public static NotFoundException CartItem(int productId)
        {
            return ResourceWithId(nameof(CartItem), productId);
        }

        public static NotFoundException PurchasableItemWithId(int itemId)
        {
            return ResourceWithId(nameof(PurchasableItem), itemId);
        }

        public static NotFoundException Image()
        {
            return WithMessage("Unable to find the requested image", nameof(Image));
        }

        public static NotFoundException ZoneWithZipCode(string zipCode)
        {
            return ResourceWithProperty(nameof(Zone), nameof(Zone.ZipCode), zipCode);
        }

        public static NotFoundException UserWithId(int userId)
        {
            return ResourceWithId(nameof(User), userId);
        }

        public static NotFoundException UserWithEmail(string email)
        {
            return ResourceWithProperty(nameof(User), nameof(User.Email), email);
        }

        public static NotFoundException AddressWithId(int addressId)
        {
            return ResourceWithId(nameof(Address), addressId);
        }

        public static NotFoundException CategoryWithId(int categoryId)
        {
            return ResourceWithId(nameof(Category), categoryId);
        }

        public static NotFoundException OrderWithId(int orderId)
        {
            return ResourceWithId(nameof(Order), orderId);
        }

        public static NotFoundException OrderDetailWithId(int orderDetailId)
        {
            return ResourceWithId(nameof(OrderDetail), orderDetailId);
        }
    }
}
