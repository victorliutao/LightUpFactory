using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class dataPermission : TableMaster
    {
        public string dataPermissionId { get; set; }
        /// <summary>
        /// define what this about,could be section
        /// </summary>
        public string objectName { get; set; }

        /// <summary>
        /// the instance id of the corresponding object instance
        /// </summary>
        public string objectId { get; set; }

        /// <summary>
        /// permission detail: 1: to user it self;2: to specified member, need to refer to another field;3: ToAll, which means this is for public, no need to add constraint
        /// </summary>
        public string showScope { get; set; }

        /// <summary>
        /// combined with showScope(1)
        /// </summary>
        public string scopeUserId { get; set; }

        /// <summary>
        /// combined with showScope(2)
        /// </summary>
        public string scopeMemberId { get; set; }

    }
}
