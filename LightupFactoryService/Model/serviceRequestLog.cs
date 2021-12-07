using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public partial class serviceRequestLog
    {      
        public string serviceRequestLogId { get; set; }
        public Nullable<System.DateTime> requestDate { get; set; }
        public string serviceName { get; set; }
        public string controllerName { get; set; }
        public string actionName { get; set; }
        public string requestParams { get; set; }
        public string txt1 { get; set; }
        public string txt2 { get; set; }
        public string txt3 { get; set; }
        public string EnterpriseId { get; set; }
        public string UserId { get; set; }
        public string httpHead { get; set; }
    }
}
