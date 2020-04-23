using GreenProject.Backend.Entities.Utils;

namespace GreenProject.Backend.Contracts.Orders
{
    public class OrderPricesDto
    {
        public Money Subtotal { get; set; }
        public Money Iva { get; set; }
        public Money ShippingCost { get; set; }
        public Money Total => Subtotal + Iva + ShippingCost;
    }
}
