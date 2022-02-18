using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class ServiceRegister
    {
        [Key]
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceObject { get; set; }
        public string Description { get; set; }
    }
}
