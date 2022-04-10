using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class FamilySquare:TableMaster
    {
        public string FamilySquareId { get; set; }
        public string FamilySquareName { get; set; }
        public string Description { get; set; }
        public int ShowScope { get; set; }
        public List<FamilySquareDetails> FamilyDetails { get; set; }

    }
}
