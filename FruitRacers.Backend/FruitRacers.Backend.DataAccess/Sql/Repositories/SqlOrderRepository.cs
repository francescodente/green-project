﻿using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlOrderRepository : SqlRepository<Order>, IOrderRepository
    {
        public SqlOrderRepository(FruitracersContext context)
            : base(context, q => q
                .Include(o => o.Address)
                .Include(o => o.TimeSlot))
        {
        }

        public IOrderRepository BelongingTo(int userId)
        {
            this.ChainQueryModification(q => q.Where(o => o.UserId == userId));
            return this;
        }

        public IOrderRepository CartOnly()
        {
            this.ChainQueryModification(q => q.Where(o => o.OrderState == OrderState.Cart));
            return this;
        }

        public IOrderRepository IncludingDetails()
        {
            this.ChainQueryModification(q => q
                .Include(o => o.OrderDetails));
            return this;
        }

        public IOrderRepository IncludingDetailsAndProducts()
        {
            this.ChainQueryModification(q => q
                .Include(o => o.OrderDetails)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.ProductCategories)
                            .ThenInclude(c => c.Category)
                .Include(o => o.OrderDetails)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.Supplier)
                .Include(o => o.OrderDetails)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.Prices));
            return this;
        }
    }
}
