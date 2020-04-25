using GreenProject.Backend.Entities;

namespace GreenProject.Backend.Contracts.Reports
{
    public class SupplierProductReportModel
    {
        public string Product { get; set; }
        public decimal Quantity { get; set; }
        public UnitName UnitName { get; set; }
    }
}