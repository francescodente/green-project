using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Dto
{
    public abstract class ProductDto<T>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<T> Categories { get; set; }
    }
}
