using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class TableMaster
    {

        //2022-2-8, 给属性添加默认值
        public int? Is_Delete { get; set; } = 0;

        public int? Is_Locked { get; set; } = 0;
        public int? changeCount { get; set; } = 0;
        public Nullable<System.DateTime> createDate { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> updateDate { get; set; } = DateTime.Now;
        public string EnterpriseId { get; set; }
        public string UserId { get; set; }

        //2022-1-18,添加附加字段
        public string optionField1 { get; set; }
        public string optionField2 { get; set; }
        public string optionField3 { get; set; }

    }
}
