using System;
using System.Collections.Generic;

namespace LightupFactoryService.Model
{
    public partial class Unit:TableMaster
    {
       
        public string Description { get; set; }
        public string Filtertags { get; set; }
       
        public int? Isfrozen { get; set; }
        public string Notes { get; set; }
        public string Unitid { get; set; }
        public string Unitname { get; set; }
    }
}
