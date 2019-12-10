using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Entities.Abstractions
{
    public class AbstractBusiness : AbstractRole
    {
        public string VatNumber { get; set; }
        public string BusinessName { get; set; }
        public string Sdi { get; set; }
        public string Pec { get; set; }
        public string LegalForm { get; set; }
        public bool IsValid { get; set; }
    }
}
