using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LightupFactoryService.ContextStr;
using LightupFactoryService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LightupFactoryService.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class KnowledgeController : ControllerBase
    {
        private LightUpFactoryContext _serverDbContext;

        public KnowledgeController(LightUpFactoryContext serverDbContext)
        {
            _serverDbContext = serverDbContext;
        }

        [HttpPost("api/GetKnow")]
        //[HttpGet]
        public returnModel GetKnowledges(WebApiContent model)
        {
            returnModel ret = new returnModel();
            
            var list = _serverDbContext.KnowledgePoint.Where(r => r.Is_Delete == 0&&r.EnterpriseId.Equals(model.EnterpriseId)).ToList();
            ret.data = list;
            return ret;
        }

        /// <summary>
        /// 保存知识点
        /// </summary>
        /// <param name="jstr"></param>
        /// <returns></returns>
        [HttpPost("api/UpdateKnow")]
        public returnModel SaveKnowledges(WebApiContent model)
        {
            returnModel ret = new returnModel();
            try
            {
                List<KnowledgePoint> knowList = JsonConvert.DeserializeObject<List<KnowledgePoint>>(model.PostContent.ToString());
                
                var nowList = _serverDbContext.KnowledgePoint.ToList();
                foreach (var item in knowList)
                {
                    //判断是否存在
                    var know = nowList.Where(r => r.KnowledgePointId.Equals(item.KnowledgePointId)).FirstOrDefault();
                    if (know != null)
                    {
                        // 修改
                        //增加change count 判断
                        if (item.changeCount > know.changeCount)
                        {
                            //只有修改之后才更改
                            know.KnowledgePointName = item.KnowledgePointName;
                            know.Description = item.Description;
                            know.ImageUrl = item.ImageUrl;
                            know.ClassId = item.ClassId;
                            know.ParentId = item.ParentId;
                            know.ParentName = item.ParentName;
                            know.ClassName = item.ClassName;
                            know.Is_Delete = item.Is_Delete;
                            know.Is_Locked = item.Is_Locked;
                            know.updateDate = DateTime.Now;
                            know.changeCount = item.changeCount;
							know.sequence=item.sequence;
                        }
                    }
                    else
                    {
                        //创建
                        //item.KnowledgePointId = Guid.NewGuid().ToString("N");
                        item.Is_Delete = 0;
                        item.Is_Locked = 0;
                        item.createDate = DateTime.Now;
                        item.updateDate = DateTime.Now;
                        item.EnterpriseId = model.EnterpriseId;
                        item.UserId = model.UserId;
                        _serverDbContext.KnowledgePoint.Add(item);
                    }
                }
                _serverDbContext.SaveChanges();
                ret.code = 0;
                ret.msg = "保存成功！";
            }
            catch (Exception e)
            {
                ret.code = -1;
                ret.msg = e.ToString();
            }
            return ret;
        }
    }
}
