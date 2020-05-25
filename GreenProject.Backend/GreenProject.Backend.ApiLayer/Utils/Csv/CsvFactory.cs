using CsvHelper;
using CsvHelper.Configuration;
using GreenProject.Backend.Contracts.Reports;
using GreenProject.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Utils.Csv
{
    public class CsvFactory : ICsvFactory
    {
        private readonly CsvSettings _settings;

        public CsvFactory(CsvSettings settings)
        {
            _settings = settings;
        }

        private byte[] CreateReportContent(Action<CsvWriter> writeAction)
        {
            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding(_settings.Encoding)))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.GetCultureInfo(_settings.CultureInfo)))
                {
                    csv.Configuration.Delimiter = _settings.Delimiter;
                    writeAction(csv);
                }

                return stream.ToArray();
            }
        }

        private byte[] CreateReportContentFromClassMap<T>(IEnumerable<T> records, ClassMap classMap)
        {
            return CreateReportContent(csv =>
            {
                csv.Configuration.RegisterClassMap(classMap);
                csv.WriteRecords(records);
            });
        }

        public CsvReport DailyOrders(IEnumerable<OrderReportModel> records, DateTime date)
        {
            ClassMap map = new CsvMappings.OrderReportModelMap(_settings.DailyOrders);

            return new CsvReport
            {
                FileName = string.Format(_settings.DailyOrders.FileName, date),
                Content = CreateReportContentFromClassMap(records, map)
            };
        }

        public CsvReport DailyProducts(IEnumerable<ProductReportModel> records, DateTime date)
        {
            IEnumerable<string> productNames = records
                .SelectMany(m => m.ProductQuantities.Keys)
                .Distinct()
                .OrderBy(s => s);

            ClassMap map = new CsvMappings.ProductReportModelMap(
                _settings.DailyProducts,
                productNames,
                CultureInfo.GetCultureInfo(_settings.CultureInfo));

            return new CsvReport
            {
                FileName = string.Format(_settings.DailyProducts.FileName, date),
                Content = CreateReportContentFromClassMap(records, map)
            };
        }

        public CsvReport SupplierOrder(IEnumerable<SupplierProductReportModel> records, DateTime date)
        {
            ClassMap map = new CsvMappings.SupplierProductReportModelMap(_settings.SupplierOrder);

            return new CsvReport
            {
                FileName = string.Format(_settings.SupplierOrder.FileName, date),
                Content = CreateReportContentFromClassMap(records, map)
            };
        }

        public CsvReport Revenue(IEnumerable<DailyRevenueModel> records, DateTime date)
        {
            ClassMap map = new CsvMappings.DailyRevenueModelMap(
                _settings.Revenue,
                _settings.SupportedIvaValues,
                CultureInfo.GetCultureInfo(_settings.CultureInfo));

            return new CsvReport
            {
                FileName = string.Format(_settings.Revenue.FileName, date),
                Content = CreateReportContentFromClassMap(records, map)
            };
        }
    }
}
