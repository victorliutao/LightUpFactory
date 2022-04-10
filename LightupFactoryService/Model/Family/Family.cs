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

        //创始人编号，2022-2-21
        public string memberId { get; set; }

        //添加Story链接
        public Story FamilyStory { get; set; }

        public string FamilyStorystoryId { get; set; }

        //在世member数量
        public int livingMemQty { get; set; }
        //离世member数量
        public int passedMemQty { get; set; }
        //显示范围：0：public，1：familygroup;2:private;3:only to me
        public int showScope { get; set; }


    }
}
