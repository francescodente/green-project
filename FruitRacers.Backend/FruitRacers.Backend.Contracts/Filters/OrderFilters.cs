using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.Filters
{
    public class OrderFilters
    {
        public bool IncludeCanceled { get; set; }
        public bool IgnoreCompleted { get; set; }
        public bool IgnorePending { get; set; }
    }
}