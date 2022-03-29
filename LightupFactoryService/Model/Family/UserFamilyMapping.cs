using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    /// <summary>
    /// 用于及Family/Member对应关系
    /// 2022-2-28
    /// 
    /// </summary>
    public class UserFamilyMapping:TableMaster
    {
        [Key]
        public string UserFamilyMapId { get; set; }
        public string UserId { get; set; }
        /// <summary>
        /// 借用字段，存储电话号码
        /// </summary>
        public string FamilyId { get; set; }
        public string MemberId { get; set; }
        /// <summary>
        /// 角色：1-家庭管理者；2-家庭编辑者；3-家庭成员
        /// </summary>
        public string RoleId { get; set; }
    }
}
