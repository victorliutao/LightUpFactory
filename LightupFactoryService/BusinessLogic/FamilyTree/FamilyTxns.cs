/*
 作者：刘涛
 时间：2022-2-8
 用途：创建Family
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightupFactoryService.Model;
using Newtonsoft.Json;
using LightupFactoryService.ContextStr;

namespace LightupFactoryService.BusinessLogic
{
    public class FamilyTxns:BaseLogic
    {
        private LightUpFactoryContext _serverDbContext;

        public FamilyTxns(LightUpFactoryContext serverDbContext)
        {
            _serverDbContext = serverDbContext;
        }

        /// <summary>
        /// 创建家族
        /// </summary>
        /// <returns></returns>
        public retModel createNewFamily(string contStr)
        {         
            retModel ret = new retModel();
            Family Model = JsonConvert.DeserializeObject<Family>(contStr);
            Model.FamilyId = getGuid();
            _serverDbContext.Family.Add(Model);
            _serverDbContext.SaveChanges();
            return ret;
        }
    }
}
