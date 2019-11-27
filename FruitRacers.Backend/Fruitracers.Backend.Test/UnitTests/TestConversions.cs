using AutoMapper;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitRacers.Backend.Test.UnitTests
{
    public class TestConversions
    {
        [Test]
        public void TestCartMapper()
        {
            IMapper mapper = MappingUtils.CreateDefaultMapper();

            DateTime date = DateTime.Today;
            TimeSpan start = TimeSpan.FromHours(10);
            Order order = new Order
            {
                OrderId = 1,
                AddressId = 1,
                Address = new Address
                {
                    AddressId = 1,
                    Description = "Address",
                    Latitude = 10,
                    Longitude = 10
                },
                DeliveryDate = date,
                Notes = "Notes",
                TimeSlotId = 1,
                TimeSlot = new TimeSlot
                {
                    TimeSlotId = 1,
                    Weekday = (int)date.DayOfWeek,
                    StartTime = start,
                    FinishTime = start.Add(TimeSpan.FromMinutes(30)),
                    SlotCapacity = 10
                },
                OrderState = (int)OrderState.Cart,
                OrderDetails = Enumerable.Range(1, 2)
                    .Select(i => new OrderDetail
                    {
                        ProductId = i,
                        Quantity = 1,
                        OrderId = 1
                    })
                    .ToList()
            };

            
        }
    }
}
