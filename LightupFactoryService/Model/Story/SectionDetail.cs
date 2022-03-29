using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    //add-migration addStory
    public class SectionDetail : TableMaster
    {
        [Key]
        public string detailId { get; set; }
        public int sequence { get; set; }
        public string contentDesc { get; set; }
        public string sectionId { get; set; }
    }
}
