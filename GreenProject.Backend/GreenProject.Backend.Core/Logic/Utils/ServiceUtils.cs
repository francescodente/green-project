using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace GreenProject.Backend.Core.Logic.Utils
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
                .Map(ot => ot.OrElseThrow(() => NotFoundException.TimeSlotWithId(timeSlotId)));

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
    }
}
