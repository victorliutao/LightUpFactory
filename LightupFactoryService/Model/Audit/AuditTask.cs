using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class AuditTask
	{

        /// <summary>
        /// define the audit task type, got these types:
		///1: member binding
		///2: editor application
		///3: edit content change
		/// </summary>
		public int type { get; set; }
		public string auditTaskId { get; set; }
		public string auditTaskName { get; set; }
		/// <summary>
		/// 审批标题
		/// </summary>
		public string title { get; set; }
		public string contents { get; set; }
		/// <summary>
		/// audit task status: 0: created;2:close
		/// </summary>
		public int status { get; set; }
		/// <summary>
		/// status for approval; 0: 待审批；1：Approved；2:Reject
		/// </summary>
		public int approvalStatus { get; set; }
		// the userid of the audit applicator
		public string applicator { get; set; }
		// the userid of the the auditor, use familyId to get all owners as the auditor of this task
		public string familyId { get; set; }
		public DateTime openDate { get; set; }
		public DateTime closeDate { get; set; }
		public string objectName { get; set; }
		public string objectId { get; set; }
		//record the change content in json format. after audit approved, need to apply the change. also this can provide more information to auditor.
		public string objectChange { get; set; }
	}
}
