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
    public delegate IQueryable<T> QueryWrapper<T>(IQueryable<T> query);

    public delegate IQueryable<TResult> QueryMapper<TSource, TResult>(IQueryable<TSource> query);

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

        public static IQueryable<T> WrapIfPresent<T>(this IQueryable<T> queryable, QueryWrapper<T> queryWrapper)
        {
            if (queryWrapper != null)
            {
                return queryWrapper(queryable);
            }
            return queryable;
        }

        public static async Task<PagedCollection<TDto>> ToPagedCollection<TEntity, TDto>(
            this IQueryable<TEntity> repository,
            PaginationFilter pagination,
            Func<TEntity, TDto> mapper)
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

        public static async Task<PagedCollection<T>> ToPagedCollection<T>(this IQueryable<T> repository, PaginationFilter pagination)
        {
            int count = await repository.CountAsync();

            IEnumerable<T> results = await repository
                .Skip(pagination.PageNumber * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedCollection<T>
            {
                PageSize = pagination.PageSize,
                PageNumber = pagination.PageNumber,
                PageCount = (count + pagination.PageSize - 1) / pagination.PageSize,
                Results = results
            };
        }
    }
}
