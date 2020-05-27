using GreenProject.Backend.Contracts.Reports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IReportsService
    {
        Task<IEnumerable<OrderReportModel>> GetDailyOrdersReport(DateTime date);

        Task<IEnumerable<ProductReportModel>> GetDailyRequestedProductsReport(DateTime date);

        Task<IEnumerable<SupplierProductReportModel>> GetDailySupplierReport(DateTime date, IEnumerable<int> categories);

        Task<IEnumerable<DailyRevenueModel>> GetRevenueReport(DateTime date);
    }
}
