using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LightupFactoryService.ContextStr;
using LightupFactoryService.Model;
using LightupFactoryService.BusinessLogic.fileStream;

namespace LightupFactoryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //WeatherForecast
        public IEnumerable<ServiceRegister> Get()
        {
            var rng = new Random();
            //
            //LightUpFactoryContext context = new LightUpFactoryContext();
            //var aql01 = new Aqllevel();
            //aql01.Aqllevelname = "123123";
            //aql01.Aqllevelid = Guid.NewGuid().ToString("N");
            //context.Aqllevel.Add(aql01);
            //context.SaveChanges();

            //测试文件写入
           string path = AppDomain.CurrentDomain.BaseDirectory;//文件安装位置
            //path = AppDomain.CurrentDomain.DynamicDirectory;
            path = @"C:\liutao\LightupFactory\LightupFactoryService\LightupFactoryService\";
               path+= @"/ContextStr/SeedData/testjson.json";
            JsonFile jf = new JsonFile();
            ServiceMethods sm = new ServiceMethods();
            //读取文件内容
            string contentStr = jf.readJsonFile(path);
            #region Option 1: One Row String
            //string contents = sm.convertListToJson(contentStr);

            //jf.writeJsonFile(path, contents);
            #endregion

            #region Option 2: multi rows
            //List<ServiceRegister> list_Sr = sm.generateNewList();
            //jf.writeJsonFile_Multi(path, list_Sr);
            List<ServiceRegister> list= jf.readMultiRow(path);
            #endregion

            return list;
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
