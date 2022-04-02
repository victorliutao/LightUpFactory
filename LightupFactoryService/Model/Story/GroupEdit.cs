using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class GroupEdit:TableMaster
    {
        public string GroupEditId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
       public string sectionId { get; set; }
        public int sequence { get; set; }
    }
}
