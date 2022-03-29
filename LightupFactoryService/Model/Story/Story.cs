using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class Story:TableMaster
    {
        public string storyId { get; set; }
        public string storyName { get; set; }
        public List<Section> storyContent { get; set; }
    }

    public class storyStr { 
        public List<Story> StoryList { get; set; }
    }
}
