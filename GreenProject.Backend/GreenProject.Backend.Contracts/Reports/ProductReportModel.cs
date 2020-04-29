using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Reports
{
    public class ProductReportModel
    {
        public string OrderNumber { get; set; }
        public IDictionary<string, decimal> ProductQuantities { get; set; }
        public decimal? Weight { get; set; }
    }
}