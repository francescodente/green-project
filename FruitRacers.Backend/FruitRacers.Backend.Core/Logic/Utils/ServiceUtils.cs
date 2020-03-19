using AutoMapper;
using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Pagination;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Logic.Utils;
using FruitRacers.Backend.Core.Utils.Session;
using FruitRacers.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace FruitRacers.Backend.Core.Logic.Utils
{
    public static class ServiceUtils
    {
        public static void RequireOwnership(int resourceOwnerId, int userId)
        {
            if (resourceOwnerId != userId)
            {
                throw new UnauthorizedUserAccessException(userId);
            }
        }

        public static void RequireOwnershipOrAdminRole(int userId, IUserSession session)
        {
            if (session.HasRole(RoleType.Administrator))
            {
                return;
            }
            RequireOwnership(userId, session.UserId);
        }

        public static async Task<(TimeSlot, int)> FindTimeSlotWithActualCapacity(IDataSession session, int timeSlotId, DateTime date)
        {
            // TODO: optimize and verify correctness
            TimeSlot timeSlot = await session
                .TimeSlots
                .IncludeFilter(t => t.TimeSlotOverrides.Where(o => o.Date == date))
                .SingleOptionalAsync(t => t.TimeSlotId == timeSlotId)
                .Map(ot => ot.OrElseThrow(() => new TimeSlotNotFoundException(timeSlotId)));

            int ordersInsideSelectedTimeSlot = await session
                .Orders
                .Where(o => o.OrderState == OrderState.Pending)
                .Where(o => o.DeliveryDate == date)
                .Where(o => o.TimeSlotId == timeSlotId)
                .CountAsync();

            int capacityOverride = timeSlot
                .TimeSlotOverrides
                .Select(o => o.Offset)
                .SingleOptional()
                .OrElse(0);

            int capacity = timeSlot.SlotCapacity + capacityOverride - ordersInsideSelectedTimeSlot;

            return (timeSlot, capacity);
        }

        public static IOptional<CustomerType> GetCustomerType(IUserSession user)
        {
            if (user.HasRole(RoleType.CustomerBusiness))
            {
                return Optional.Of(CustomerType.Business);
            }
            if (user.HasRole(RoleType.Person))
            {
                return Optional.Of(CustomerType.Person);
            }
            return Optional.Empty<CustomerType>();
        }

        public static async Task<PagedCollection<TDto>> PagedCollectionFromQuery<TEntity, TDto>(
            IQueryable<TEntity> query,
            PaginationFilter pagination,
            IMapper mapper)
            where TEntity : class
        {
            return await PagedCollectionFromQuery(query, pagination, mapper.Map<TDto>);
        }

        public static async Task<PagedCollection<TDto>> PagedCollectionFromQuery<TEntity, TDto>(
            IQueryable<TEntity> repository,
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
