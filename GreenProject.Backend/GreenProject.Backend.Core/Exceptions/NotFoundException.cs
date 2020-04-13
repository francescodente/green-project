using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class NotFoundException : DomainException
    {
        private NotFoundException(string message)
            : base(message)
        {

        }

        public static NotFoundException WithMessage(string message)
        {
            return new NotFoundException(message);
        }

        public static NotFoundException ResourceWithProperty(string resourceType, string propertyName, object propertyValue)
        {
            return WithMessage($"Unable to find {resourceType} with {propertyName} equal to {propertyValue}");
        }

        public static NotFoundException ResourceWithId(string resourceType, int id)
        {
            return ResourceWithProperty(resourceType, "ID", id);
        }

        public static NotFoundException CartItem(int productId)
        {
            return ResourceWithId("products in the cart", productId);
        }

        public static NotFoundException PurchasableItemWithId(int itemId)
        {
            return ResourceWithId(nameof(PurchasableItem), itemId);
        }

        public static NotFoundException Image()
        {
            return WithMessage($"Unable to find the requested image");
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
    }
}
