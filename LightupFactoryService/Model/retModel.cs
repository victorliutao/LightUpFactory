using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public partial class retModel : TableMaster
    {

        public int code { get; set; }
        public object data { get; set; }
        public int count { get; set; }
        public string msg { get; set; }
        public string objectId { get; set; }
        public decimal sum { get; set; }
    }
}
