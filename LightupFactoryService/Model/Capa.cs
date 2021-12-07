using System;
using System.Collections.Generic;

namespace LightupFactoryService.Model
{
    public partial class Capa:TableMaster
    {
        public string Attachmentsid { get; set; }
        public string Briefdescription { get; set; }
        public string Capacustomdataid { get; set; }
        public string Capaid { get; set; }
        public string Capaname { get; set; }
        public int? Carresolutionaction { get; set; }
        public string Carseverityid { get; set; }
        public int? Category { get; set; }
        public int? Cdotypeid { get; set; }
        public int? Changecount { get; set; }
        public string Classificationid { get; set; }
        public DateTime? Closedate { get; set; }
        public DateTime? Closedategmt { get; set; }
        public string Closedbyid { get; set; }
        public string Closedescription { get; set; }
        public string Description { get; set; }
        public string Initiatorid { get; set; }
        public string Initiatororganizationid { get; set; }
        public int? Isfrozen { get; set; }
        public int? Issubmitted { get; set; }
        public DateTime? Occurrencedate { get; set; }
        public DateTime? Occurrencedategmt { get; set; }
        public string Organizationid { get; set; }
        public string Origprocessmodeltemplateid { get; set; }
        public string Ownerid { get; set; }
        public string Prioritylevelid { get; set; }
        public string Processmodelid { get; set; }
        public string Proposedresolution { get; set; }
        public string Qualityresolutioncodeid { get; set; }
        public DateTime? Reporteddate { get; set; }
        public DateTime? Reporteddategmt { get; set; }
        public string Reporterid { get; set; }
        public string Reporterorganizationid { get; set; }
        public string Riskassessmentid { get; set; }
        public string Roleid { get; set; }
        public int? Status { get; set; }
        public string Subclassificationid { get; set; }
        public int? Systemicissue { get; set; }
        public int? Triagecomplete { get; set; }
    }
}
