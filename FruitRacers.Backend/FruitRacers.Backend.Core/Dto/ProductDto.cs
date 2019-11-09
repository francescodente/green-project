using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Products
{
    public class ProductDto<T>
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<T> Categories { get; set; }
    }
}
