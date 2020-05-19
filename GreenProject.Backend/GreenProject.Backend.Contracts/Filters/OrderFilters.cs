using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Filters
{
    public class OrderFilters
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public IEnumerable<string> ZipCodes { get; set; }
        public IEnumerable<OrderState> States { get; set; }
    }
}