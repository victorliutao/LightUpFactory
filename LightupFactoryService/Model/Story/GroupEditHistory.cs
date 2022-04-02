using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class GroupEditHistory:TableMaster
    {
        public string GroupEditHistoryId { get; set; }
        public string GroupEditId { get; set; }
        public string modifyName { get; set; }
        public string contents { get; set; }
    }
}
