namespace GreenProject.Backend.Core.Entities
{
    public class BookedCrateProduct
    {
        public int OrderId { get; set; }
        public int CrateId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
    }
}
