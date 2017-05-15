using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo.Entities
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public int PersonId { get; set; }
        public string State { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }

        public virtual Person Person { get; set; }
    }
}
