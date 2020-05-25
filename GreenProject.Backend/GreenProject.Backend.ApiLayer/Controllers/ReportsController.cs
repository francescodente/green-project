using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.ApiLayer.Utils.Csv;
using GreenProject.Backend.Contracts.Reports;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/reports")]
    [RequireLogin(RoleType.Administrator)]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private const string CsvMimeType = "text/csv";

        private readonly IReportsService _reportsService;
        private readonly ICsvFactory _csvFactory;

        public ReportsController(IReportsService reportsService, ICsvFactory csvFactory)
        {
            _reportsService = reportsService;
            _csvFactory = csvFactory;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetDailyOrdersReport([FromQuery] DateTime? date)
        {
            DateTime targetDate = date ?? DateTime.Today;

            IEnumerable<OrderReportModel> records = await _reportsService
                .GetDailyOrdersReport(targetDate);

            return CsvFile(_csvFactory.DailyOrders(records, targetDate));
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetDailyRequestedProductsReport([FromQuery] DateTime? date)
        {
            DateTime targetDate = date ?? DateTime.Today;

            IEnumerable<ProductReportModel> records = await _reportsService
                .GetDailyRequestedProductsReport(targetDate);

            return CsvFile(_csvFactory.DailyProducts(records, targetDate));
        }

        [HttpGet("supplierorder")]
        public async Task<IActionResult> GetDailySupplierReport([FromQuery] DateTime? date, [FromQuery] IEnumerable<int> categories)
        {
            DateTime targetDate = date ?? DateTime.Today;

            IEnumerable<SupplierProductReportModel> records = await _reportsService
                .GetDailySupplierReport(targetDate, categories);

            return CsvFile(_csvFactory.SupplierOrder(records, targetDate));
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenueReport([FromQuery] DateTime? date)
        {
            DateTime targetDate = date ?? DateTime.Today;

            IEnumerable<DailyRevenueModel> records = await _reportsService
                .GetRevenueReport(targetDate);

            return CsvFile(_csvFactory.Revenue(records, targetDate));
        }

        private IActionResult CsvFile(CsvReport report)
        {
            return File(report.Content, CsvMimeType, report.FileName);
        }
    }
}