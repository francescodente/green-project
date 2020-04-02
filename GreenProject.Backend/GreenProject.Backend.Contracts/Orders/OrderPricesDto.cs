namespace GreenProject.Backend.Contracts.Orders
{
    public class OrderPricesDto
    {
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Total => Subtotal + Iva + ShippingCost;
    }
}
