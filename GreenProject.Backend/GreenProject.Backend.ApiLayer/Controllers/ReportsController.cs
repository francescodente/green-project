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
using GreenProject.Backend.Contracts.Reports;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService reportsService;

        public ReportsController(IReportsService reportsService)
        {
            this.reportsService = reportsService;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetDailyOrdersReport([FromQuery] DateTime? date)
        {
            IEnumerable<OrderReportModel> records = await this.reportsService.GetDailyOrdersReport(date ?? DateTime.Today);

            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }

                return File(stream.ToArray(), "text/csv");
            }
        }
    }
}