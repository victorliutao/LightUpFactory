using System;
using System.Collections.Generic;

namespace LightupFactoryService.Model
{
    public partial class Supplier:TableMaster
    {
      
        public string Description { get; set; }
      
        public string Notes { get; set; }
        public string Supplierid { get; set; }
        public string Suppliername { get; set; }
    }
}
