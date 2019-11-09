using System;

namespace FruitRacers.Backend.Core.Dto
{
    public class DeliveryInfoDto
    {
        public AddressDto Address { get; set; }
        public DateTime? Date { get; set; }
        public TimeSlotDto TimeSlot { get; set; }
        public string Notes { get; set; }
    }
}
