using GreenProject.Backend.Contracts.Reports;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class ReportsService : AbstractService, IReportsService
    {
        public ReportsService(IRequestSession request)
            : base(request)
        {
        }

        public async Task<IEnumerable<OrderReportModel>> GetDailyOrdersReport(DateTime date)
        {
            return await this.Data
                .Orders
                .Where(o => o.DeliveryDate == date)
                .Where(o => o.OrderState != OrderState.Canceled)
                .Select(o => new OrderReportModel
                {
                    OrderNumber = o.OrderNumber,
                    Street = o.Address.Street,
                    HouseNumber = o.Address.HouseNumber,
                    City = o.Address.Zone.City,
                    ZipCode = o.Address.ZipCode,
                    Name = o.Address.Name
                })
                .ToArrayAsync();
        }

        public Task<IEnumerable<ProductReportModel>> GetDailyRequestedProductsReport(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupplierProductReportModel>> GetDailySupplierReport(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
