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
    }
}
