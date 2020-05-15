﻿using GreenProject.Backend.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Entities
{
    public class Zone
    {
        public Zone()
        {
            Addresses = new HashSet<Address>();
        }

        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public Money ShippingSurcharge { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<ZoneAvailability> Availabilities { get; set; }
    }
}
