using System;
using System.Collections.Generic;

namespace LightupFactoryService.Model
{
    public partial class Productfamily : TableMaster
    {
        public decimal Currentcost { get; set; }
        public string Description { get; set; }
        public string Documentsetid { get; set; }
        public string Notes { get; set; }
        public decimal Plannedcost { get; set; }
        public string Productfamilyid { get; set; }
        public string Productfamilyname { get; set; }
        public decimal? Stdcost { get; set; }
        public decimal? Stdstartqty { get; set; }
        public decimal? Stdstartqty2 { get; set; }
        public string? Stdstartuom2id { get; set; }
        public string? Stdstartuomid { get; set; }
    }
}
