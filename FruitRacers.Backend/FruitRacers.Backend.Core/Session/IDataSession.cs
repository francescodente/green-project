﻿using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Session
{
    public interface IDataSession : IDisposable
    {
        IUserRepository Users { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        ITimeSlotRepository TimeSlots { get; }
        IReadOnlyRepository<Category> Categories { get; }
        IRepository<Address> Addresses { get; }
        IRepository<OrderDetail> OrderDetails { get; }

        Task SaveChanges();
    }
}