using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    /// <summary>
    /// 2022-3-30, 对象修改历史记录
    /// </summary>
    public class ObjectsEditHistory
    {
        public string ObjectsEditHistoryId { get; set; }
        public string objectName { get; set; }
        public string objectId { get; set; }
        public int? changeCount { get; set; }
        /// <summary>
        /// 保存修改内容
        /// </summary>
        public string changeContent { get; set; }
        public string userId { get; set; }
        public DateTime updateDate { get; set; }
    }
}
