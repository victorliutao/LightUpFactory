using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    public class AuditHistory
    {
		//foriegn key, connect to audit task
		public string auditTaskId { get; set; }
		public string AuditHistoryId { get; set; }
		public string auditTaskHistoryName { get; set; }
		//
		/// <summary>
		/// 1: create, 2: audit
		/// </summary>
		public int auditType { get; set; }
		// 1: pass 2: reject
		public int auditResult { get; set; }
		//audit comments
		public string comments { get; set; }
		//
		/// <summary>
		/// userid who belongs to this task
		/// </summary>
		public string userId { get; set; }
	}
}
