using GreenProject.Backend.Contracts.Filters;
using GreenProject.Backend.Contracts.Pagination;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Utils.Session;
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

        protected Task<T> Require(int itemId, Func<IQueryable<T>, IQueryable<T>> queryWrapper = null)
        {
            return this.GetDefaultQuery()
                .Where(i => !i.IsDeleted)
                .WrapIfPresent(queryWrapper)
                .SingleOptionalAsync(p => p.ItemId == itemId)
                .Map(p => p.OrElseThrow(() => NotFoundException.PurchasableItemWithId(itemId)));
        }

        protected Task<PagedCollection<TOutput>> GetPaged<TOutput>(PaginationFilter pagination, PurchasableFilters filters)
        {
            IQueryable<T> items = this.GetDefaultQuery()
                .VisibleToCustomers()
                .Include(p => p.Prices)
                .Include(p => p.Image);

            items = filters.Categories != null && filters.Categories.Any()
                ? items.Where(p => filters.Categories.Contains(p.CategoryId))
                : items;

            return items.ToPagedCollection(pagination, this.Mapper.Map<TOutput>);
        }

        protected async Task<TOutput> Insert<TOutput>(Action<T> initializer)
        {
            T entity = new T
            {
                IsEnabled = true,
                IsDeleted = false
            };
            initializer(entity);
            this.Data.PurchasableItems.Add(entity);
            await this.Data.SaveChangesAsync();
            return this.Mapper.Map<TOutput>(entity);
        }

        protected async Task<TOutput> Update<TOutput>(int itemId, Action<T> updater, Func<IQueryable<T>, IQueryable<T>> queryWrapper = null)
        {
            T entity = await this.Require(itemId, queryWrapper);

            updater(entity);

            await this.Data.SaveChangesAsync();

            return this.Mapper.Map<TOutput>(entity);
        }

        protected async Task Delete(int itemId)
        {
            T item = await this.Require(itemId);

            item.IsDeleted = true;

            await this.Data.SaveChangesAsync();
        }
    }
}
