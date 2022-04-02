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

       
        public string gender { get; set; }
        public string Region { get; set; }
        /// <summary>
        /// 当前居住地
        /// </summary>
        public string residence { get; set; }
        //this is born family
        public string FamilyId { get; set; }
        //2022-3-25, Family Id after marriage relation
        public string marriageFamilyId { get; set; }

        public Story MmeberStory { get; set; }

        public string MmeberStorystoryId { get; set; }

        /// <summary>
        /// 2022-3-19,增加成员Flag，可用于分配编辑者
        /// </summary>
        public int Is_PermissionNode { get; set; }

        #region 扩展属性，2022-3-29
        /// <summary>
        /// 头像图片地址
        /// </summary>
        public string headImage { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string dateOfBirth { get; set; }
        /// <summary>
        /// 农历生日
        /// </summary>
        public string dateOfBirthLunar { get; set; }
        /// <summary>
        /// 忌日
        /// </summary>
        public string dateOfDeath { get; set; }
        /// <summary>
        /// 农历忌日
        /// </summary>
        public string dateOfDeathLunar { get; set; }
        /// <summary>
        /// 庙号：如清世祖
        /// </summary>
        public string templeName { get; set; }
        /// <summary>
        /// 年号，如：康熙
        /// </summary>
        public string yearName { get; set; }
        /// <summary>
        /// 谥号，如： 孝康仁皇后
        /// </summary>
        public string respectName { get; set; }
        /// <summary>
        /// 名
        /// </summary>
        public string firstName { get; set; }
        /// <summary>
        /// 中间名/字
        /// </summary>
        public string middleName { get; set; }
        /// <summary>
        /// 姓氏
        /// </summary>
        public string givenName { get; set; }
        /// <summary>
        /// 号，如苏东坡，号东坡先生
        /// </summary>
        public string callingName { get; set; }
        /// <summary>
        /// 生父
        /// </summary>
        public string birthDad { get; set; }
        /// <summary>
        /// 养父
        /// </summary>
        public string raiseDad { get; set; }
        /// <summary>
        /// 生母
        /// </summary>
        public string birthMom { get; set; }
        /// <summary>
        /// 养母
        /// </summary>
        public string raiseMom { get; set; }
        /// <summary>
        /// 坟地
        /// </summary>
        public string tombLocation { get; set; }
        /// <summary>
        /// 立碑日期
        /// </summary>
        public string tombDate { get; set; }
        #endregion
    }
}
