namespace GreenProject.Backend.Contracts.Orders
{
    public class OrderPricesDto
    {
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Total => SubTotal + Iva + ShippingCost;
    }
}
