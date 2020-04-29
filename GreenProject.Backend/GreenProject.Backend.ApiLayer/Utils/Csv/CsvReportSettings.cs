using System.Collections.Generic;

namespace GreenProject.Backend.ApiLayer.Utils.Csv
{
    public class CsvReportSettings
    {
        public string FileName { get; set; }
        public IDictionary<string, string> HeaderNames { get; set; }
    }
}