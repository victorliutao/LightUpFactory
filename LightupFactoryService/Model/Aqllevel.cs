using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class Aqllevel:TableMaster
    {
        public string Aqllevelid { get; set; }
        public string Aqllevelname { get; set; }
       // public int? Cdotypeid { get; set; }
       // public int? Changecount { get; set; }
       //  public string Changehistoryid { get; set; }
        public string Description { get; set; }
        public string Filtertags { get; set; }
        //public int? Iconid { get; set; }
        public int? Isfrozen { get; set; }
        public string Notes { get; set; }
    }
}
