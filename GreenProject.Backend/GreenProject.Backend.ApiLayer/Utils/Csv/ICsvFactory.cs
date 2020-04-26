using GreenProject.Backend.Contracts.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Utils.Csv
{
    public interface ICsvFactory
    {
        CsvReport DailyOrders(IEnumerable<OrderReportModel> records, DateTime date);

        CsvReport DailyProducts(IEnumerable<ProductReportModel> records, DateTime date);

        CsvReport SupplierOrder(IEnumerable<SupplierProductReportModel> records, DateTime date);
    }
}
