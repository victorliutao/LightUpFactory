/*
 作者：刘涛
 时间：2022-3-31
 用途：创建Family
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightupFactoryService.Model;
using Newtonsoft.Json;
using LightupFactoryService.ContextStr;

namespace LightupFactoryService.BusinessLogic
{
    public class StoryTxns : BaseLogic
    {
        private LightUpFactoryContext _serverDbContext;
        private string _userId;
        public StoryTxns(LightUpFactoryContext serverDbContext,string userId)
        {
            _serverDbContext = serverDbContext;
            _userId = userId;
        }

        /// <summary>
        /// 新建写作编辑项目
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel addGroupEdit(string paraStr) {
            retModel ret = new retModel();
            GroupEdit model = JsonConvert.DeserializeObject<GroupEdit>(paraStr);
            model.updateDate = DateTime.Now;
            model.createDate = DateTime.Now;
            model.Is_Delete = 0;
            model.Is_Locked = 0;
            _serverDbContext.GroupEdit.Add(model);
            return ret;
        }

        /// <summary>
        /// 获取协同编辑内容
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel getGroupEdit(string paraStr) {
            retModel ret = new retModel();
            GroupEdit model = JsonConvert.DeserializeObject<GroupEdit>(paraStr);
            var ge = _serverDbContext.GroupEdit.Where(r => r.GroupEditId.Equals(model.GroupEditId)).FirstOrDefault();
            ret.data = ge;
            return ret;
        }

        /// <summary>
        /// 增加共享编辑的内容
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel addGroupEditInstance(string paraStr) {
            retModel ret = new retModel();
            GroupEditHistory model = JsonConvert.DeserializeObject<GroupEditHistory>(paraStr);
            model.GroupEditHistoryId = getGuid();
            model.updateDate = DateTime.Now;
            model.createDate = DateTime.Now;
            model.Is_Delete = 0;
            model.Is_Locked = 0;
            _serverDbContext.GroupEditHistory.Add(model);
            ret.msg = "协同编辑提交成功";
            return ret;
        }

        /// <summary>
        /// 根据storyId获取协同编辑的内容
        /// </summary>
        /// <returns></returns>
        public retModel getGroupEditInstanceByStoryId(string paraStr) {
            retModel ret = new retModel();
            Section model = JsonConvert.DeserializeObject<Section>(paraStr);
            var geList = (from a in _serverDbContext.GroupEditHistory
                          join b in _serverDbContext.GroupEdit on a.GroupEditId equals b.GroupEditId
                          join c in _serverDbContext.Section on b.sectionId equals c.sectionId
                          where c.storyId == model.storyId
                          orderby a.createDate ascending
                          select new GroupEditHistory
                          {
                              GroupEditHistoryId = a.GroupEditHistoryId,
                              GroupEditId = a.GroupEditId,
                              optionField1 = b.sectionId,//借用optionField1来表示SectionId
                              optionField2=b.title,//借用optionalField2来表示协同编辑的Title
                              contents = a.contents,
                              modifyName = a.modifyName,
                              createDate = a.createDate
                          }).ToList();
            ret.data = geList;
            return ret;
        }
    }
}
