using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.ApiLayer.Utils.Csv;
using GreenProject.Backend.Contracts.Reports;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private const string CsvMimeType = "text/csv";

        private readonly IReportsService reportsService;
        private readonly ICsvFactory csvFactory;

        public ReportsController(IReportsService reportsService, ICsvFactory csvFactory)
        {
            this.reportsService = reportsService;
            this.csvFactory = csvFactory;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetDailyOrdersReport([FromQuery] DateTime? date)
        {
            DateTime targetDate = date ?? DateTime.Today;

            IEnumerable<OrderReportModel> records = await this.reportsService
                .GetDailyOrdersReport(targetDate);

            return CsvFile(this.csvFactory.DailyOrders(records, targetDate));
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetDailyRequestedProductsReport([FromQuery] DateTime? date)
        {
            DateTime targetDate = date ?? DateTime.Today;

            IEnumerable<ProductReportModel> records = await this.reportsService
                .GetDailyRequestedProductsReport(targetDate);

            return CsvFile(this.csvFactory.DailyProducts(records, targetDate));
        }

        [HttpGet("supplierorder")]
        public async Task<IActionResult> GetDailySupplierReport([FromQuery] DateTime? date, [FromQuery] IEnumerable<int> categories)
        {
            DateTime targetDate = date ?? DateTime.Today;

            IEnumerable<SupplierProductReportModel> records = await this.reportsService
                .GetDailySupplierReport(targetDate, categories);

            return CsvFile(this.csvFactory.SupplierOrder(records, targetDate));
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenueReport([FromQuery] DateTime? date)
        {
            DateTime targetDate = date ?? DateTime.Today;

            IEnumerable<DailyRevenueModel> records = await this.reportsService
                .GetRevenueReport(targetDate);

            return CsvFile(this.csvFactory.Revenue(records, targetDate));
        }

        private IActionResult CsvFile(CsvReport report)
        {
            return File(report.Content, CsvMimeType, report.FileName);
        }
    }
}