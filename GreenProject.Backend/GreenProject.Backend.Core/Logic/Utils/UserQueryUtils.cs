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
                .Include(u => u.Person)
                .Include(u => u.CustomerBusiness)
                .Include(u => u.Supplier)
                .Include(u => u.DeliveryCompany)
                .Include(u => u.Administrator);
        }
    }
}
