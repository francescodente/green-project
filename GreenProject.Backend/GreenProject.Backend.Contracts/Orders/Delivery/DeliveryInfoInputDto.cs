using System;

namespace GreenProject.Backend.Contracts.Orders
{
    public class DeliveryInfoInputDto
    {
        public string Notes { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? AddressId { get; set; }
        public int? TimeSlotId { get; set; }
    }
}
