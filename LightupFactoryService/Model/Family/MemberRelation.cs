using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class MemberRelation:TableMaster
    {
        public string MemberRelationId { get; set; }
        public string MemberId { get; set; }
        public string RelationShipId { get; set; }

        public string parentId { get; set; }
        //前端关系id, 1:配偶， 2： 子女
        public int relationId { get; set; }
        //子女顺序
        public int childSeq { get; set; }


    }
}
