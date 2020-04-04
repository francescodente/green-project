using GreenProject.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GreenProject.Backend.Core.Logic.Utils
{
    public static class UserQueryUtils
    {
        public static IQueryable<User> IncludingAddresses(this IQueryable<User> users)
        {
            return users
                .Include(u => u.Addresses)
                .Include(u => u.DefaultAddress);
        }

        public static IQueryable<User> IncludingRoles(this IQueryable<User> users)
        {
            return users
                .IncludingCustomerRoles()
                .Include(u => u.DeliveryCompany);
        }

        public static IQueryable<User> IncludingCart(this IQueryable<User> users)
        {
            return users
                .Include(u => u.CartItems)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(p => p.Prices);
        }

        public static IQueryable<User> IncludingCustomerRoles(this IQueryable<User> users)
        {
            return users
                .Include(u => u.Person)
                .Include(u => u.CustomerBusiness);
        }
    }
}
