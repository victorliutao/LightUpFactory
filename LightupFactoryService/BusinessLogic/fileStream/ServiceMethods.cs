using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightupFactoryService.Model;
using Newtonsoft.Json;

namespace LightupFactoryService.BusinessLogic.fileStream
{
    public class ServiceMethods
    {
        /// <summary>
        /// 注册新的服务方法
        /// </summary>
        /// <returns></returns>
        public ServiceRegister createNewMethod() {
            ServiceRegister model = new ServiceRegister();
            model.ServiceId = Guid.NewGuid().ToString("N");
            model.ServiceName = "test";
            return model;
        }

        /// <summary>
        /// 将对象转换为Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string convertListToJson(string contentStr)
        {
            jsonStructure model = new jsonStructure();
            model.updateTime = DateTime.Now;
            List<ServiceRegister> sres = new List<ServiceRegister>();
            for (int i = 0; i < 5; i++)
            {
                sres.Add(createNewMethod());
            }
            model.data = sres;
            string jsonstr = "";
            jsonstr = JsonConvert.SerializeObject(model);
            return jsonstr;
        }

        public List<ServiceRegister> generateNewList()
        {
            List<ServiceRegister> sres = new List<ServiceRegister>();
            for (int i = 0; i < 5; i++)
            {
                sres.Add(createNewMethod());
            }
            return sres;
        }

        /// <summary>
        /// 将Json Str转换为List
        /// </summary>
        /// <param name="jsonstr"></param>
        /// <returns></returns>
        public List<ServiceMethods> getFromStr(string jsonstr)
        {
            List<ServiceMethods> List = JsonConvert.DeserializeObject<List<ServiceMethods>>(jsonstr);
            return List;
        }
    }

    class jsonStructure { 
        public DateTime updateTime { get; set; }
        public object data { get; set; }
    }
}
