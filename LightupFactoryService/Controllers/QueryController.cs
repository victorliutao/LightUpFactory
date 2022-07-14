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
    public class QueryController : ControllerBase
    {
        private LightUpFactoryContext _serverDbContext;

        public QueryController(LightUpFactoryContext serverDbContext)
        {
            _serverDbContext = serverDbContext;
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
            ServiceController scs = new ServiceController(_serverDbContext);
            retModel ret = new retModel();
            //记录服务信息,记录发起时间
            DateTime start = DateTime.Now;
            string serviceRequestLogId = Guid.NewGuid().ToString("N");

            string ErrorMsg = "";
            //2022-6-3,存储基础变量到BaseLogic类
            BaseLogic baseMethods = new BaseLogic();
            baseMethods.Base_UserId = cont.UserId;

            //获取Service,并反射类执行
            ServiceContent sr = scs.getServiceById(cont.ServiceId);
            //serviceRequestLog serviceLog = new serviceRequestLog { serviceRequestLogId = serviceRequestLogId, serviceName = sr.serviceName, controllerName = sr.controllerName, actionName = sr.actionName, requestParams = cont.PostContent + "", EnterpriseId = cont.EnterpriseId, UserId = cont.UserId };
            //CreateNewLog(serviceLog);

            try
            {
                ReflectClass rc = new ReflectClass();
                ret = rc.CreateMethod("LightupFactoryService.BusinessLogic." + sr.controllerName, sr.serviceName, cont.PostContent.ToString(), _serverDbContext, cont.UserId);

            }
            catch (Exception e)
            {
                //serviceLog.txt2 = e.ToString();
                ret.code = -99;
                ret.msg = "query not work! please check";
            }

            //记录执行时间
            //DateTime end = DateTime.Now;
            //TimeSpan ts = end.Subtract(start);
            //int sencond = ts.Milliseconds;
            //serviceLog.txt3 = sencond.ToString();//服务执行的时长，单位为：毫秒
            //UpdateServiceLog(serviceLog);
            //update execution log

            return ret;
        }

    }
}
