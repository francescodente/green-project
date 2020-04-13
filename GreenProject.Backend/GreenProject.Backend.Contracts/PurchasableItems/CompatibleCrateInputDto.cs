using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public class CompatibleCrateInputDto
    {
        public int CrateId { get; set; }
        public int Multiplier { get; set; }
        public int? Maximum { get; set; }
    }
}
