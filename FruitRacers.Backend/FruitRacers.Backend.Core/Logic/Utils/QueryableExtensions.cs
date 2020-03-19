using FruitRacers.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Logic.Utils
{
    public static class QueryableExtensions
    {
        public static Task<IOptional<T>> FirstOptionalAsync<T>(this IQueryable<T> queryable)
            where T : class
        {
            return queryable.FirstOrDefaultAsync().Map(t => t.AsOptional());
        }

        public static Task<IOptional<T>> FirstOptionalAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> predicate)
            where T : class
        {
            return queryable.FirstOrDefaultAsync(predicate).Map(t => t.AsOptional());
        }

        public static Task<IOptional<T>> SingleOptionalAsync<T>(this IQueryable<T> queryable)
            where T : class
        {
            return queryable.SingleOrDefaultAsync().Map(t => t.AsOptional());
        }

        public static Task<IOptional<T>> SingleOptionalAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> predicate)
            where T : class
        {
            return queryable.SingleOrDefaultAsync(predicate).Map(t => t.AsOptional());
        }
    }
}
