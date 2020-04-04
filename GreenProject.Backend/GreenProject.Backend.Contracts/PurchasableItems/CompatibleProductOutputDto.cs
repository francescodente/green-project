﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public class CompatibleProductOutputDto
    {
        public ProductOutputDto Product { get; set; }
        public int Maximum { get; set; }
        public int Multiplier { get; set; }
    }
}
