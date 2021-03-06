using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LightupFactoryService.Model;
using LightupFactoryService.ContextStr;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using LightupFactoryService.BusinessLogic;
using LightupFactoryService.BusinessLogic.fileStream;



namespace LightupFactoryService.Controllers
{
    [EnableCors("PolicyTest")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private LightUpFactoryContext _serverDbContext;

        public ServiceController(LightUpFactoryContext serverDbContext)
        {
            _serverDbContext = serverDbContext;
        }

        [HttpGet]
        public retModel Get()
        {
            retModel ret = new retModel();
            ReflectClass rc = new ReflectClass();
           ret = rc.CreateMethod("LightupFactoryService.BusinessLogic." + "FamilyTxns", "getAllFamily", "{}", _serverDbContext,"");
            return ret;
        }

        public retModel PostMe()
        {
            retModel ret = new retModel();
            ret.msg = "you get me";
            return ret;
        }

        /// <summary>
        /// 统一服务入口
        /// 刘涛，2021-8-24
        /// </summary>
        /// <param name="cont"></param>
        /// <returns></returns>
        //[EnableCors("PolicyTest")]
        [HttpPost]
        public retModel Post(WebApiContent cont)
        {
            retModel ret = new retModel();
            //记录服务信息,记录发起时间
            DateTime start = DateTime.Now;
            string serviceRequestLogId = Guid.NewGuid().ToString("N");

            string ErrorMsg = "";
            //2022-6-3,存储基础变量到BaseLogic类
            BaseLogic baseMethods = new BaseLogic();
            baseMethods.Base_UserId = cont.UserId;

            //获取Service,并反射类执行
            ServiceContent sr = getServiceById(cont.ServiceId);
            serviceRequestLog serviceLog = new serviceRequestLog { serviceRequestLogId = serviceRequestLogId, serviceName = sr.serviceName, controllerName = sr.controllerName, actionName = sr.actionName, requestParams = cont.PostContent + "", EnterpriseId = cont.EnterpriseId, UserId = cont.UserId };
            CreateNewLog(serviceLog);

            try
            {
                ReflectClass rc = new ReflectClass();
                ret = rc.CreateMethod("LightupFactoryService.BusinessLogic." + sr.controllerName, sr.serviceName, cont.PostContent.ToString(), _serverDbContext,cont.UserId);

            }
            catch (Exception e)
            {
                serviceLog.txt2 = e.ToString();
                ret.code = -99;
                ret.msg = "something went wrong, please check";
            }
            
            //记录执行时间
            DateTime end = DateTime.Now;
            TimeSpan ts = end.Subtract(start);
            int sencond = ts.Milliseconds;
            serviceLog.txt3 = sencond.ToString();//服务执行的时长，单位为：毫秒
            UpdateServiceLog(serviceLog);
            //update execution log

            return ret;
        }

        /// <summary>
        /// 获取服务信息
        /// 2022-02-08, 从json串获取service内容
        /// </summary>
        /// <param name="ServiceId"></param>
        /// <returns></returns>
        public ServiceContent getServiceById(string ServiceId)
        {
            ServiceContent sc = new ServiceContent();
            //step1： read from localfile
            JsonFile jf = new JsonFile();
            string path = @"C:\liutao\configure\ServiceMethod.txt";
            //path += @"/ContextStr/SeedData/ServiceMethod.txt";
            List<ServiceRegister> methodList = jf.readMultiRow(path);
            //step2: get service method content by serviceid
            var method = methodList.Where(r => r.ServiceId.Equals(ServiceId)).FirstOrDefault();
            if (method != null)
            {
                sc.serviceName = method.ServiceName;
                sc.controllerName = method.ServiceObject;
            }
            return sc;
        }

        /// <summary>
        /// 添加服务日志
        /// </summary>
        /// <param name="model"></param>
        private void CreateNewLog(serviceRequestLog model)
        {
            model.requestDate = DateTime.Now;
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
    public class ServiceContent
    {
        public string serviceName { get; set; }
        public string controllerName { get; set; }
        public string actionName { get; set; }
    }

    /// <summary>
    /// 服务返回信息
    /// </summary>
    public class returnModel
    {
        public int code { get; set; }
        public object data { get; set; }
        public int count { get; set; }
        public string msg { get; set; }
        public string objectId { get; set; }
        public decimal sum { get; set; }
    }
}
