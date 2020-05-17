using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Filters
{
    public class OrderFilters
    {
        public bool IncludeCanceled { get; set; }
        public bool IgnoreCompleted { get; set; }
        public bool IgnorePending { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public IEnumerable<string> ZipCodes { get; set; }
    }
}