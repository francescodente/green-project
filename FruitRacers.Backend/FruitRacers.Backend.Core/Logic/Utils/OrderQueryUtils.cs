﻿using FruitRacers.Backend.Core.Entities;
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
                            .ThenInclude(u => u.Addresses)
                .Include(o => o.Sections)
                    .ThenInclude(o => o.Details)
                        .ThenInclude(d => d.Product)
                            .ThenInclude(p => p.Prices);
        }

        public static IQueryable<Order> IncludingDeliveryInfo(this IQueryable<Order> orders)
        {
            return orders
                .Include(o => o.Address)
                .Include(o => o.TimeSlotId);
        }
    }
}
