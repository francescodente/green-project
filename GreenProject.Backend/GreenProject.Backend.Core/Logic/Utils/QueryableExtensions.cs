using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic.Utils
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

        public static async Task<PagedCollection<TDto>> ToPagedCollection<TEntity, TDto>(
            this IQueryable<TEntity> repository,
            PaginationFilter pagination,
            Func<TEntity, TDto> mapper)
            where TEntity : class
        {
            int count = await repository.CountAsync();

            IEnumerable<TDto> results = await repository
                .Skip(pagination.PageNumber * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync()
                .Map(entities => entities.Select(mapper));

            return new PagedCollection<TDto>
            {
                PageSize = pagination.PageSize,
                PageNumber = pagination.PageNumber,
                PageCount = (count + pagination.PageSize - 1) / pagination.PageSize,
                Results = results
            };
        }
    }
}
