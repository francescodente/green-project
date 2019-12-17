using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Contracts.TimeSlots;
using System;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class DeliveryInfoOutputDto : AbstractDeliveryInfoDto
    {
        public AddressOutputDto Address { get; set; }
        public TimeSlotDto TimeSlot { get; set; }
    }
}
