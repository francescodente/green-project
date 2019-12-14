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
    }
}
