using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    /// <summary>
    /// liutao,2021-10-06
    /// </summary>
    public class KnowledgePoint: TableMaster
    {
        public string KnowledgePointId { get; set; }

        public string KnowledgePointName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public string ParentId { get; set; }
        public string ClassId { get; set; }

        //added field, 2021-10-12, consider front end requirement
        public string ClassName { get; set; }

        public string ParentName { get; set; }

        // added field 2021-10-12, add change count. key to check whether things changed
        public int changecount { get; set; }
		
		public int sequence {get;set;}
    }
}
