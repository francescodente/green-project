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
        private readonly CsvSettings settings;

        public CsvFactory(CsvSettings settings)
        {
            this.settings = settings;
        }

        private byte[] CreateReportContent(Action<CsvWriter> writeAction)
        {
            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding(this.settings.Encoding)))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.GetCultureInfo(this.settings.CultureInfo)))
                {
                    csv.Configuration.Delimiter = this.settings.Delimiter;
                    writeAction(csv);
                }

                return stream.ToArray();
            }
        }

        private byte[] CreateReportContentFromClassMap<T>(IEnumerable<T> records, ClassMap classMap)
        {
            return this.CreateReportContent(csv =>
            {
                csv.Configuration.RegisterClassMap(classMap);
                csv.WriteRecords(records);
            });
        }

        public CsvReport DailyOrders(IEnumerable<OrderReportModel> records, DateTime date)
        {
            ClassMap map = new CsvMappings.OrderReportModelMap(this.settings.DailyOrders);

            return new CsvReport
            {
                FileName = string.Format(this.settings.DailyOrders.FileName, date),
                Content = this.CreateReportContentFromClassMap(records, map)
            };
        }

        public CsvReport DailyProducts(IEnumerable<ProductReportModel> records, DateTime date)
        {
            IEnumerable<string> productNames = records
                .SelectMany(m => m.ProductQuantities.Keys)
                .Distinct()
                .OrderBy(s => s);

            ClassMap map = new CsvMappings.ProductReportModelMap(
                this.settings.DailyProducts,
                productNames,
                CultureInfo.GetCultureInfo(this.settings.CultureInfo));

            return new CsvReport
            {
                FileName = string.Format(this.settings.DailyProducts.FileName, date),
                Content = this.CreateReportContentFromClassMap(records, map)
            };
        }

        public CsvReport SupplierOrder(IEnumerable<SupplierProductReportModel> records, DateTime date)
        {
            ClassMap map = new CsvMappings.SupplierProductReportModelMap(this.settings.SupplierOrder);

            return new CsvReport
            {
                FileName = string.Format(this.settings.SupplierOrder.FileName, date),
                Content = this.CreateReportContentFromClassMap(records, map)
            };
        }
    }
}
