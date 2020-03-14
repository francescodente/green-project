using FruitRacers.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitRacers.Backend.Core.Entities.Extensions
{
    public static class UserExtensions
    {
        public static IEnumerable<RoleType> GetRoleTypes(this User user)
        {
            if (user.Administrator != null)
            {
                yield return RoleType.Administrator;
            }
            if (user.DeliveryCompany != null)
            {
                yield return RoleType.DeliveryCompany;
            }
            if (user.Person != null)
            {
                yield return RoleType.Person;
            }
            if (user.Supplier != null)
            {
                yield return RoleType.Supplier;
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
            if (user.DefaultAddressId == address.AddressId)
            {
                user.DefaultAddressId = null;
            }
            user.Addresses.Remove(address);
        }
    }
}
