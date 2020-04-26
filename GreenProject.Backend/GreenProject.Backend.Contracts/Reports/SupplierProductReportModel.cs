using GreenProject.Backend.Entities;

namespace GreenProject.Backend.Contracts.Reports
{
    public class SupplierProductReportModel
    {
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public string UnitName { get; set; }
    }
}