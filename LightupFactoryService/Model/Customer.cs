using System;
using System.Collections.Generic;

namespace LightupFactoryService.Model
{
    public partial class Customer : TableMaster
    {
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string Customerid { get; set; }
        public string Customername { get; set; }
        public string Description { get; set; }
        public string Faxnumber { get; set; }
        public int? Isfrozen { get; set; }
        public string Notes { get; set; }
        public string Phonenumber { get; set; }
        public string State { get; set; }
        public string Website { get; set; }
        public string Zipcode { get; set; }
    }
}
