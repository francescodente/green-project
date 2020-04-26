using CsvHelper;
using CsvHelper.Configuration;
using GreenProject.Backend.Contracts.Reports;
using GreenProject.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
            using (StreamWriter writer = new StreamWriter(stream))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = "|";
                    csv.Configuration.UseNewObjectForNullReferenceMembers = false;
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

            CsvReportSettings settings = this.settings.DailyProducts;

            return new CsvReport
            {
                FileName = string.Format(settings.FileName, date),
                Content = this.CreateReportContent(csv =>
                {
                    csv.WriteField(settings.HeaderNames[nameof(ProductReportModel.OrderNumber)]);
                    productNames.ForEach(csv.WriteField);
                    csv.WriteField(settings.HeaderNames[nameof(ProductReportModel.Weight)]);
                    csv.NextRecord();

                    records.ForEach(r =>
                    {
                        csv.WriteField(r.OrderNumber);
                        productNames
                            .Select(n => r.ProductQuantities.GetValueAsOptional(n).Map(q => q.ToString()).OrElse(""))
                            .ForEach(csv.WriteField);
                        csv.WriteField(r.Weight);
                        csv.NextRecord();
                    });
                })
            };
        }

        public CsvReport SupplierOrder(IEnumerable<SupplierProductReportModel> records, DateTime date)
        {
            ClassMap map = null;

            return new CsvReport
            {
                FileName = string.Format(this.settings.SupplierOrder.FileName, date),
                Content = this.CreateReportContentFromClassMap(records, map)
            };
        }
    }
}
