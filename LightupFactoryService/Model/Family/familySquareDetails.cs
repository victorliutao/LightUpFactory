using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class FamilySquareDetails
    {
        public string FamilySquareDetailsId { get; set; }
        public string FamilySquareDetailsName { get; set; }
        //使用对象
        public Family Family { get; set; }
    }
}
