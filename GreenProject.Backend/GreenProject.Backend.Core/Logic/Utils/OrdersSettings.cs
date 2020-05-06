using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Logic.Utils
{
    public class OrdersSettings
    {
        public int LockTimeSpanInDays { get; set; }
        public int WeeklyOrderRenewTimeInDays { get; set; }
        public bool IgnoreOrdersLock { get; set; }
    }
}
