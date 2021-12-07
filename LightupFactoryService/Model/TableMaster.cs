using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class TableMaster
    {
        public int? Is_Delete { get; set; }
        public int? Is_Locked { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public string EnterpriseId { get; set; }
        public string UserId { get; set; }
    }
}
