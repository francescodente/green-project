using GreenProject.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenProject.Backend.Core.Logic.Utils
{
    public static class ItemQueryUtils
    {
        public static IQueryable<T> VisibleToCustomers<T>(this IQueryable<T> query)
            where T : PurchasableItem
        {
            return query.Where(i => i.IsEnabled && !i.IsDeleted);
        }
    }
}
