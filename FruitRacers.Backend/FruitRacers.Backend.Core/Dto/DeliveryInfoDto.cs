using FruitRacers.Backend.Core.Services.Addresses;
using FruitRacers.Backend.Core.Services.TimeSlots;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Cart
{
    public class DeliveryInfoDto
    {
        public AddressDto Address { get; set; }
        public DateTime? Date { get; set; }
        public TimeSlotDto TimeSlot { get; set; }
        public string Notes { get; set; }
    }
}
