using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public abstract class AbstractItemsService<T> : AbstractService
        where T : PurchasableItem, new()
    {
        public AbstractItemsService(IRequestSession request)
            : base(request)
        {
        }

        protected abstract IQueryable<T> GetDefaultQuery();

        protected Task<T> Require(int itemId, QueryWrapper<T> queryWrapper = null)
        {
            return GetDefaultQuery()
                .Where(i => !i.IsDeleted)
                .WrapIfPresent(queryWrapper)
                .SingleOptionalAsync(p => p.ItemId == itemId)
                .Map(p => p.OrElseThrow(() => NotFoundException.PurchasableItemWithId(itemId)));
        }

        protected Task<PagedCollection<TOutput>> GetPaged<TOutput>(PaginationFilter pagination, PurchasableFilters filters)
        {
            IQueryable<T> items = GetDefaultQuery()
                .VisibleToCustomers();

            if (filters.Categories != null && filters.Categories.Any())
            {
                items = items.Where(p => filters.Categories.Contains(p.CategoryId));
            }

            if (filters.Starred.HasValue)
            {
                items = items.Where(p => p.IsStarred == filters.Starred.Value);
            }

            return items
                .ProjectTo<TOutput>(Mapper.ConfigurationProvider)
                .ToPagedCollection(pagination);
        }

        protected async Task<TOutput> Insert<TOutput>(Action<T> initializer)
        {
            var entity = new T
            {
                IsEnabled = true,
                IsDeleted = false
            };
            initializer(entity);
            Data.PurchasableItems.Add(entity);
            await Data.SaveChangesAsync();
            return Mapper.Map<TOutput>(entity);
        }

        protected async Task<TOutput> Update<TOutput>(int itemId, Action<T> updater, QueryWrapper<T> queryWrapper = null)
        {
            T entity = await Require(itemId, queryWrapper);

            updater(entity);

            await Data.SaveChangesAsync();

            return Mapper.Map<TOutput>(entity);
        }

        protected async Task Delete(int itemId)
        {
            T item = await Require(itemId);

            item.IsDeleted = true;

            await Data.SaveChangesAsync();
        }
    }
}
