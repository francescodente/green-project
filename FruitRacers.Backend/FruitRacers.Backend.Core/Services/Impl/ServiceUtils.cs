using AutoMapper;
using FruitRacers.Backend.Contracts.Filters;
using FruitRacers.Backend.Contracts.Pagination;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
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
            TimeSlot timeSlot = await session
                    .TimeSlots
                    .IncludingOverrides(date, date)
                    .FindOne(t => t.TimeSlotId == timeSlotId)
                    .Then(ot => ot.OrElseThrow(() => new TimeSlotNotFoundException(timeSlotId)));

            int ordersInsideSelectedTimeSlot = await session
                .Orders
                .WithState(OrderState.Confirmed)
                .AfterDate(date)
                .BeforeDate(date)
                .AsEnumerable(o => o.TimeSlotId == timeSlotId)
                .Then(o => o.Count());

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

        public static async Task<PagedCollection<TDto>> PagedCollectionFromRepository<TEntity, TDto>(IReadOnlyRepository<TEntity> repository, PaginationFilter pagination, IMapper mapper)
            where TEntity : class
        {
            Task<int> countTask = repository.Count();
            Task<IEnumerable<TDto>> resultsTask = repository
                .AsPagedEnumerable(pagination.PageNumber, pagination.PageSize)
                .Then(mapper.Map<IEnumerable<TDto>>);

            return new PagedCollection<TDto>
            {
                PageSize = pagination.PageSize,
                PageNumber = pagination.PageNumber,
                PageCount = (await countTask + pagination.PageSize - 1) / pagination.PageSize,
                Results = await resultsTask
            };
        }
    }
}
