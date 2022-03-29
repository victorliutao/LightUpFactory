using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LightupFactoryService.ContextStr;
using LightupFactoryService.Model;
using LightupFactoryService.BusinessLogic.fileStream;
using LightupFactoryService.BusinessLogic;

namespace LightupFactoryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private LightUpFactoryContext _serverDbContext;


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
        public retModel Get()
        {
            ReflectClass rc = new ReflectClass();
            retModel model = new retModel();
            return model;
            
        }
    }
}
