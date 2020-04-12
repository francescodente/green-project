namespace GreenProject.Backend.Entities
{
    public class OrderDetailSubProduct
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
    }
}
