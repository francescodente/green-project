using GreenProject.Backend.Entities.Utils;
using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Reports
{
    public class DailyRevenueModel
    {
        public DailyRevenueModel()
        {
            IvaValues = new Dictionary<decimal, Money>();
        }

        public DateTime Date { get; set; }
        public IDictionary<decimal, Money> IvaValues { get; set; }
    }
}
