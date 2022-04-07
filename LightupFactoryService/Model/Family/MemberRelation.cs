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
        //Referenct to relation id, can be represent the relation ship with the member and the parent.
        public string RelationShipId { get; set; }

        public string parentId { get; set; }
        //Font end need: 1:spouse， 2： sibling
        public int relationId { get; set; }
        //siblings sequences
        public int childSeq { get; set; }

        //add a family, to denote which family this relation belong to 
        public string familyId {get;set;}


    }
}
