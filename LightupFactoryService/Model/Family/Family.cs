using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class Family : TableMaster
    {
        public string FamilyId { get; set; }
        //家族名
        public string FamilyName { get; set; }

        //姓氏
        public string GivenName { get; set; }


        //家族描述
        public string Description { get; set; }


        //地址
        public string Address { get; set; }

        //区/县
        public string county { get; set; }

        //城市
        public string City { get; set; }

        //省
        public string Province { get; set; }

        //地区code
        public string zipcode { get; set; }

    }
}
