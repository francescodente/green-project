using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class Supplier : AbstractBusiness
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public string Description { get; set; }
        public int? LogoImageId { get; set; }
        public int? BackgroundImageId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<OrderSection> ReceivedOrders { get; set; }
        public virtual Image LogoImage { get; set; }
        public virtual Image BackgroundImage { get; set; }
    }
}
