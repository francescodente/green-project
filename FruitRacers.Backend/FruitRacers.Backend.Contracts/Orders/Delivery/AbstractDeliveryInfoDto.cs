using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.Orders
{
    public abstract class AbstractDeliveryInfoDto
    {
        public string Notes { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
