using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class Member: TableMaster
    {
        public string MemberId { get; set; }

        public string MemberName { get; set; }

        public string Description { get; set; }

        public int status { get; set; }

        public int changeCount { get; set; }
        public string gender { get; set; }
        public string Region { get; set; }
        public string FamilyId { get; set; }
    }
}
