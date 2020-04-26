﻿using GreenProject.Backend.Contracts.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IReportsService
    {
        Task<IEnumerable<OrderReportModel>> GetDailyOrdersReport(DateTime date);

        Task<IEnumerable<ProductReportModel>> GetDailyRequestedProductsReport(DateTime date);

        Task<IEnumerable<SupplierProductReportModel>> GetDailySupplierReport(DateTime date);
    }
}