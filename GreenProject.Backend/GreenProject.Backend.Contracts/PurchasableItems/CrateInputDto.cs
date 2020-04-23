using GreenProject.Backend.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public class CrateInputDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        public decimal IvaPercentage { get; set; }
        public int Capacity { get; set; }
    }
}
