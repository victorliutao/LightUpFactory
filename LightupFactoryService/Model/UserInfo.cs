using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class UserInfo
    {
        public int? Is_Delete { get; set; }
        public int? Is_Locked { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public string EnterpriseId { get; set; }
        [Key]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string UserType { get; set; }
        public string User_password { get; set; }
        public string FactoryId { get; set; }
        public string WorkCenterId { get; set; }
        /// <summary>
        /// 借用字段，存放openid， 对应nickname
        /// </summary>
        public string ResourceId { get; set; }
        /// <summary>
        /// 借用字段，存放url， 对应：avatarUrl
        /// </summary>
        public string ResourceGroupId { get; set; }
    }
}
