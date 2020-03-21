using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Contracts.TimeSlots;
using System;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class DeliveryInfoOutputDto
    {
        public string Notes { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public AddressOutputDto Address { get; set; }
        public TimeSlotDto TimeSlot { get; set; }
    }
}
