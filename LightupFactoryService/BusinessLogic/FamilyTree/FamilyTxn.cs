using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ssyst;
using LightupFactoryService.Model;

namespace LightupFactoryService
{
	public class FamilyTxn : DataObject
	{
		private myContext _serverDbContext;

		public FamilyTxn(LightUpFactoryContext serverDbContext)
		{
			_serverDbContext = serverDbContext;
		}

		/// <summary>
		/// 添加家庭，2022-01-18
		/// </summary>
		/// <param name="fam"></param>

		public retModel CreateFamily(Family fam)
		{ 
			
		}
	}
}

