using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Utils.Csv
{
    public class CsvSettings
    {
        public string Encoding { get; set; }
        public string Delimiter { get; set; }
        public CsvReportSettings DailyOrders { get; set; }
        public CsvReportSettings DailyProducts { get; set; }
        public CsvReportSettings SupplierOrder { get; set; }
        public CsvReportSettings Revenue { get; set; }
    }
}
