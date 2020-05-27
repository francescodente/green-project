using GreenProject.Backend.Entities;
using System.Linq;

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
