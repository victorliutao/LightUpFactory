using System;
using System.Collections.Generic;

namespace LightupFactoryService.Model
{
    public partial class Product: TableMaster
    {

        public string Bomid { get; set; }
        public string Brandname { get; set; }
        public string Catalognumber { get; set; }
       
        public decimal Currentcost { get; set; }
        public string Customerid { get; set; }
        public string Customerproductnumber { get; set; }
        public string Description { get; set; }
        public string Devicetype { get; set; }
        public string Documentsetid { get; set; }
        public string Eco { get; set; }
        
        public string Erpbomid { get; set; }
        public string Erprouteid { get; set; }
        public string Glentity { get; set; }
      
        public int Inspectall { get; set; }
        public int Inventorycontrolled { get; set; }
        public int Isfrozen { get; set; }
        public int Isphantom { get; set; }
        public int Lotcontrolled { get; set; }
        public string Modelnumber { get; set; }
        public string Notes { get; set; }
        public decimal Plannedcost { get; set; }
        public string Productfamilyid { get; set; }
        public string Productid { get; set; }
        public string Productrevision { get; set; }
        public string Producttypeid { get; set; }
        public int Serialcontrolled { get; set; }
        public int Status { get; set; }
        public decimal Stdcost { get; set; }
        public decimal Stdstartqty { get; set; }
        public decimal Stdstartqty2 { get; set; }
        public string Stdstartuom2id { get; set; }
        public string Stdstartuomid { get; set; }
        public int Stockpointcontrolled { get; set; }
        public string Subfactory { get; set; }
        public decimal Targetcycletime { get; set; }
        public decimal Targetdurationperunit { get; set; }
        public decimal Targetfinalyield { get; set; }
        public decimal Targetrolledthroughputyield { get; set; }
        public decimal Targetunitsperhour { get; set; }
        public string Trainingreqgroupid { get; set; }
        public string Workflowid { get; set; }
    }
}
