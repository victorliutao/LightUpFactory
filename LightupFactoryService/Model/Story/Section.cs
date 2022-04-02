using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class Section : TableMaster
    {
        public string sectionId { get; set; }
        public string storyId { get; set; }
        public string sectionName { get; set; }
        public List<SectionDetail> sectionDetails { get; set; }
        /// <summary>
        /// add group edit
        /// </summary>
        public List<GroupEdit> goupEditDetails { get; set; }

        //2022-2-24, 添加序号
        public int sequence { get; set; }
    }
}
