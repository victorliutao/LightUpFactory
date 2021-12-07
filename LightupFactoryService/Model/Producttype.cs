using System;
using System.Collections.Generic;

namespace LightupFactoryService.Model
{
    public partial class Producttype : TableMaster
    {
       
        public string Description { get; set; }
      
        public int? Isfrozen { get; set; }
        public string Notes { get; set; }
        public string Producttypeid { get; set; }
        public string Producttypename { get; set; }
    }
}
