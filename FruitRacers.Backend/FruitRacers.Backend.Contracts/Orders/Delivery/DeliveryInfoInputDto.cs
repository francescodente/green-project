using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class DeliveryInfoInputDto : AbstractDeliveryInfoDto
    {
        public int? AddressId { get; set; }
        public int? TimeSlotId { get; set; }
    }
}
