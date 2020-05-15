using GreenProject.Backend.Contracts.Orders;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.WeeklyOrders
{
    public class WeeklyOrderDto
    {
        public DeliveryInfoDto.Output DeliveryInfo { get; set; }
        public IEnumerable<BookedCrateDto> Crates { get; set; }
        public IEnumerable<OrderDetailDto> ExtraProducts { get; set; }
        public OrderPricesDto Prices { get; set; }
    }
}
