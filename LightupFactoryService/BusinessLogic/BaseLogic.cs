using LightupFactoryService.ContextStr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.BusinessLogic
{
    /// <summary>
    /// 基础类，level1.
    /// </summary>
    public class BaseLogic
    {
        /// <summary>
        /// 存储操作者的UserId, 2022-6-3, 在提交时赋值。
        /// </summary>
        public string Base_UserId { get; set; }
        /// <summary>
        /// 2022-2-8，刘涛，通用方法1：获取GUID
        /// </summary>
        /// <returns></returns>
        public string getGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 2022-3-3, 根据输入的digit,构造Random数
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public string getRandom(int digits) {
            string ramdomStr = "";
            Random ranMeth = new Random();
            for (int i = 0; i < digits; i++) {
                string rand = ranMeth.Next(0, 9).ToString();
                ramdomStr += rand;
            }
            return ramdomStr;
        }
    }
}
