using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightupFactoryService.ContextStr;
using LightupFactoryService.Model;

namespace LightupFactoryService.BusinessLogic
{
	public class FamilyTxn : DataObject
	{
		private LightUpFactoryContext _serverDbContext;

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

