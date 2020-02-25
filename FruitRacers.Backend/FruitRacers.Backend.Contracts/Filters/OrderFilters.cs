using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.Filters
{
    public class OrderFilters
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IncludeCanceled { get; set; }
        public bool IgnoreCompleted { get; set; }
        public bool IgnorePending { get; set; }
    }
}