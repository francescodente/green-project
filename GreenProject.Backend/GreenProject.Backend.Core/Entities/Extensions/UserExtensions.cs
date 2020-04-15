using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenProject.Backend.Core.Entities.Extensions
{
    public static class UserExtensions
    {
        public static IEnumerable<RoleType> GetRoleTypes(this User user)
        {
            if (user.IsAdministrator)
            {
                yield return RoleType.Administrator;
            }
            if (user.DeliveryCompany != null)
            {
                yield return RoleType.DeliveryMan;
            }
            if (user.Person != null)
            {
                yield return RoleType.Person;
            }
            if (user.CustomerBusiness != null)
            {
                yield return RoleType.CustomerBusiness;
            }
        }

        public static string GetCustomerName(this User user)
        {
            if (user.CustomerBusiness != null)
            {
                return user.CustomerBusiness.BusinessName;
            }
            if (user.Person != null)
            {
                return string.Format("{0} {1}", user.Person.FirstName, user.Person.LastName);
            }
            return null;
        }

        public static IOptional<CustomerType> GetCustomerType(this User user)
        {
            if (user.CustomerBusiness != null)
            {
                return Optional.Of(CustomerType.Business);
            }
            if (user.Person != null)
            {
                return Optional.Of(CustomerType.Person);
            }
            return Optional.Empty<CustomerType>();
        }

        private static CustomerType RequireCustomerType(this User user)
        {
            return user.GetCustomerType().OrElseThrow(() => new MissingPurchasePermissionException());
        }

        public static void AddAddress(this User user, Address address)
        {
            if (user.Addresses.Count == 0)
            {
                user.DefaultAddress = address;
            }
            user.Addresses.Add(address);
        }

        public static void DeleteAddress(this User user, Address address)
        {
            bool isDefault = user.DefaultAddressId == address.AddressId;
            if (isDefault && user.IsSubscribed)
            {
                throw new DefaultAddressDeletionException();
            }
            user.Addresses.Remove(address);
            if (isDefault)
            {
                user.DefaultAddressId = user.Addresses.FirstOrDefault()?.AddressId;
            }
        }

        public static void AddProductToCart(this User user, Product product, int quantity)
        {
            CustomerType customerType = user.RequireCustomerType();

            user.CartItems
                .SingleOptional(i => i.ProductId == product.ItemId)
                .IfPresent(i => i.Quantity += quantity)
                .IfAbsent(() => user.CartItems.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                }));
        }

        public static void UpdateCartItemQuantity(this User user, int productId, int quantity)
        {
            user.CartItems
                .SingleOptional(i => i.ProductId == productId)
                .IfPresent(i => i.Quantity = quantity)
                .OrElseThrow(() => NotFoundException.CartItem(productId));
        }

        public static void RemoveProductFromCart(this User user, int productId)
        {
            CartItem item = user.CartItems
                .SingleOptional(i => i.ProductId == productId)
                .OrElseThrow(() => NotFoundException.CartItem(productId));

            user.CartItems.Remove(item);
        }
    }
}
