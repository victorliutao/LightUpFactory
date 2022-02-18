using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.BusinessLogic
{
    public class BaseLogic
    {
        /// <summary>
        /// 2022-2-8，刘涛，通用方法1：获取GUID
        /// </summary>
        /// <returns></returns>
        public string getGuid()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
