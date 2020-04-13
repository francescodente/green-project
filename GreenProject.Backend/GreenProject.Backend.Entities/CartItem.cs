using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Entities
{
    public class CartItem
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
