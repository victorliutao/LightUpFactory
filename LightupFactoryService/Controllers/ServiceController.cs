using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LightupFactoryService.Model;
using LightupFactoryService.ContextStr;

namespace LightupFactoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private LightUpFactoryContext _serverDbContext;

        public ServiceController(LightUpFactoryContext serverDbContext)
        {
            _serverDbContext = serverDbContext;
        }
        
        /// <summary>
        /// 统一服务入口
        /// 刘涛，2021-8-24
        /// </summary>
        /// <param name="cont"></param>
        /// <returns></returns>
        public retModel PostData(WebApiContent cont)
        {
            retModel ret = new retModel();
            //记录服务信息,记录发起时间
            DateTime start = DateTime.Now;
            string serviceRequestLogId= Guid.NewGuid().ToString("N");
            serviceRequestLog log = new serviceRequestLog();
            log.serviceRequestLogId = serviceRequestLogId;
            //添加服务日志
            if (log.controllerName != "LogQueryController")
            {
                ServiceContent sr = getServiceById(cont.ServiceId);
                CreateNewLog(new serviceRequestLog { serviceRequestLogId = serviceRequestLogId, serviceName = sr.serviceName, controllerName = sr.controllerName, actionName = sr.actionName, requestParams = cont.PostContent + "", EnterpriseId = cont.EnterpriseId, UserId = cont.UserId });
            }
            //记录执行时间
            DateTime end = DateTime.Now;
            TimeSpan ts = end.Subtract(start);
            int sencond = ts.Milliseconds;
            log.txt3 = sencond.ToString();//服务执行的时长，单位为：毫秒
            if (log.txt2.Length > 1000)
            {
                log.txt2 = log.txt2.Substring(0, 1000);
            }

            //排除LogQuery本身的方法，不添加日志，//2020-03-26
            if (log.controllerName != "LogQueryController")
            {
                //ServiceLog.getInstance().UpdateLog(log);
            }
            return ret;
        }

        /// <summary>
        /// 获取服务信息
        /// </summary>
        /// <param name="ServiceId"></param>
        /// <returns></returns>
        public ServiceContent getServiceById(string ServiceId)
        {
            ServiceContent sc = new ServiceContent();
            //var serviceRej = _serverDbContext.ServiceRegister.Where(r => r.ServiceId.Equals(ServiceId)).FirstOrDefault();
            //sc.actionName = serviceRej.ServiceName;
            //if (serviceRej != null)
            //{
            //    var serviceObj = _serverDbContext.ServiceObject.Where(r => r.ServiceObjectId.Equals(serviceRej.ServiceObjectId)).FirstOrDefault();
            //    sc.serviceName = serviceObj.ServiceObjectName;
            //    sc.controllerName = serviceObj.ControllerName;
            //}
            return sc;
        }

        /// <summary>
        /// 添加服务日志
        /// </summary>
        /// <param name="model"></param>
        private void CreateNewLog(serviceRequestLog model) {
            _serverDbContext.serviceRequestLog.Add(model);
            _serverDbContext.SaveChanges();
        }

        /// <summary>
        /// 修改服务日志
        /// </summary>
        /// <param name="model"></param>
        private void UpdateServiceLog(serviceRequestLog model)
        {
            var sl = _serverDbContext.serviceRequestLog.Where(r => r.serviceRequestLogId.Equals(model.serviceRequestLogId)).FirstOrDefault();
            sl.txt1 = model.txt1;
            sl.txt2 = model.txt2;
            sl.txt3 = model.txt3;
            _serverDbContext.SaveChanges();
        }
    }

    /// <summary>
    /// 服务传递内容
    /// </summary>
    public class WebApiContent
    {
        public string EnterpriseId { get; set; }
        public string UserId { get; set; }
        public string HttpHead { get; set; }
        //服务id，能够对应controller和action
        public string ServiceId { get; set; }
        public object PostContent { get; set; }
        //增加Json string
        public string JsonStr { get; set; }

        //增加页数
        public int limit { get; set; }
        public int page { get; set; }
    }

    /// <summary>
    /// 服务信息
    /// </summary>
    public class ServiceContent { 
        public string serviceName { get; set; }
        public string controllerName { get; set; }
        public string actionName { get; set; }
    }

    /// <summary>
    /// 服务返回信息
    /// </summary>
    public class returnModel {
        public int code { get; set; }
        public object data { get; set; }
        public int count { get; set; }
        public string msg { get; set; }
        public string objectId { get; set; }
        public decimal sum { get; set; }
    }
}
