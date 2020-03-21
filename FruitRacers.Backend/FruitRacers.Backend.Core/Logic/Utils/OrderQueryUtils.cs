using FruitRacers.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FruitRacers.Backend.Core.Logic.Utils
{
    public static class OrderQueryUtils
    {
        public static IQueryable<Order> IncludingSections(this IQueryable<Order> orders)
        {
            return orders
                .Include(o => o.Sections)
                    .ThenInclude(s => s.Supplier)
                        .ThenInclude(s => s.User)
                            .ThenInclude(u => u.DefaultAddress)
                .Include(o => o.Sections)
                    .ThenInclude(o => o.Details)
                        .ThenInclude(d => d.Product)
                            .ThenInclude(p => p.Prices);
        }

        public static IQueryable<Order> IncludingDeliveryInfo(this IQueryable<Order> orders)
        {
            return orders
                .Include(o => o.Address)
                .Include(o => o.TimeSlot);
        }

        public static IQueryable<OrderSection> IncludingDeliveryInfo(this IQueryable<OrderSection> sections)
        {
            return sections
                .Include(s => s.Order)
                    .ThenInclude(o => o.Address)
                .Include(s => s.Order)
                    .ThenInclude(o => o.TimeSlotId);
        }
    }
}
