using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class Enterprise
    {
        public int? Is_Delete { get; set; }
        public int? Is_Locked { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public string EnterpriseId { get; set; }
        public string UserId { get; set; }
        public string EnterpriseName { get; set; }
        public string Description { get; set; }
        public string contactPerson { get; set; }
        public string Telephone { get; set; }
       
        public string EnterpriseCode { get; set; }
        public string ext1 { get; set; }
        public string ext2 { get; set; }
        public string ext3 { get; set; }
    }
}
