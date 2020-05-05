using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenProject.Backend.Core.Logic.Utils
{
    public static class DatabaseViews
    {
        public static IQueryable<User> ActiveUsers(this IDataSession data)
        {
            return data.Users.Where(u => !u.IsDeleted);
        }

        public static IQueryable<User> EnabledUsers(this IDataSession data)
        {
            return data.ActiveUsers().Where(u => u.IsEnabled);
        }

        public static IQueryable<PurchasableItem> ActivePurchasableItems(this IDataSession data)
        {
            return data.PurchasableItems.Where(p => !p.IsDeleted);
        }

        public static IQueryable<PurchasableItem> VisiblePurchasableItems(this IDataSession data)
        {
            return data.ActivePurchasableItems().Where(p => p.IsEnabled);
        }

        public static IQueryable<Product> ActiveProducts(this IDataSession data)
        {
            return data.Products.Where(p => !p.IsDeleted);
        }

        public static IQueryable<Product> VisibleProducts(this IDataSession data)
        {
            return data.ActiveProducts().Where(p => p.IsEnabled);
        }

        public static IQueryable<Crate> ActiveCrates(this IDataSession data)
        {
            return data.Crates.Where(c => !c.IsDeleted);
        }

        public static IQueryable<Crate> VisibleCrates(this IDataSession data)
        {
            return data.ActiveCrates().Where(c => c.IsEnabled);
        }
    }
}
