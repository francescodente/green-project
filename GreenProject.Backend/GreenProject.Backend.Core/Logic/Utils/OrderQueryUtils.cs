﻿using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GreenProject.Backend.Core.Logic.Utils
{
    public static class OrderQueryUtils
    {
        public static IQueryable<Order> IncludingDetails(this IQueryable<Order> orders)
        {
            return orders
                .Include(o => o.Details)
                    .ThenInclude(d => d.Item)
                        .ThenInclude(p => p.Prices)
                .Include(o => o.Details)
                    .ThenInclude(d => d.Item)
                        .ThenInclude(s => s.Image);
        }

        public static IQueryable<Order> IncludingDeliveryInfo(this IQueryable<Order> orders)
        {
            return orders
                .Include(o => o.Address)
                    .ThenInclude(a => a.Zone);
        }
    }
}
