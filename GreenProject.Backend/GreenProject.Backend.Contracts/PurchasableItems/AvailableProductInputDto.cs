using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public class AvailableProductInputDto
    {
        public int ProductId { get; set; }
        public int Multiplier { get; set; }
        public int Maximum { get; set; }
    }
}
