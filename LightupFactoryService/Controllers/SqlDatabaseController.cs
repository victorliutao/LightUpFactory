using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightupFactoryService.ContextStr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LightupFactoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlDatabaseController : ControllerBase
    {
        private readonly LightUpFactoryContext _SqlServerDb;

        public SqlDatabaseController(LightUpFactoryContext sqlServerDb)
        {
            _SqlServerDb = sqlServerDb;
        }

        [HttpGet]
        public string Index() {
            try
            {
                _SqlServerDb.Database.Migrate();
                return "ok";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
