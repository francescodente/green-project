using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Entities
{
    public class ZipCode
    {
        public ZipCode()
        {
            Addresses = new HashSet<Address>();
        }

        public string Code { get; set; }
        public string Province { get; set; }
        public string City { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
