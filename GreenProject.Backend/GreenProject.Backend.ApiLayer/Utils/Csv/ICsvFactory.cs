using GreenProject.Backend.Contracts.Reports;
using System;
using System.Collections.Generic;

namespace GreenProject.Backend.ApiLayer.Utils.Csv
{
    public interface ICsvFactory
    {
        CsvReport DailyOrders(IEnumerable<OrderReportModel> records, DateTime date);

        CsvReport DailyProducts(IEnumerable<ProductReportModel> records, DateTime date);

        CsvReport SupplierOrder(IEnumerable<SupplierProductReportModel> records, DateTime date);

        CsvReport Revenue(IEnumerable<DailyRevenueModel> records, DateTime date);
    }
}
