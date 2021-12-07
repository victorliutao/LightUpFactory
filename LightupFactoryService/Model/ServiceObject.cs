using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class ServiceObject
    {
        public string ServiceObjectId { get; set; }
        public string ServiceObjectName { get; set; }
        public string ControllerName { get; set; }
        public string Description { get; set; }
        public string RedirectName { get; set; }
        public string RedirectUrl { get; set; }
    }
}
