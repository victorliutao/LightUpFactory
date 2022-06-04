using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightupFactoryService.ContextStr;
using LightupFactoryService.Model;

namespace LightupFactoryService.BusinessLogic
{
    /// <summary>
    /// Family 和 Member的公用方法类，被继承，Level2
    /// </summary>
    public class FamilyLogic:BaseLogic
    {
        public string renderRoleid(string roleId) {
            string roleName = "";
            switch (roleId) {
                case "1":
                    roleName = "管理者";
                    break;
                case "2":
                    roleName = "编辑者";
                    break;
                case "3":
                    roleName = "成员";
                    break;
            }
            return roleName;
        }
        /// <summary>
        /// 2022-3-7, 初始化Story, 用于在新建Family， 新建用户时创建
        /// </summary>
        /// <returns></returns>
        public Story InitiateStory(string _storyId,string _IntialSection,List<string> _secDeList,string _storyName) {
            Story Famsto = new Story();
            Famsto.storyId = _storyId;
            Famsto.storyName = _storyName;
            Famsto.createDate = DateTime.Now;
            Famsto.updateDate = DateTime.Now;
            Famsto.Is_Locked = 0;
            Famsto.Is_Delete = 0;
            //string DefSection = "姓氏起源,家族大事件";
            string[] secs = _IntialSection.Split(',');
            List<Section> secList = new List<Section>();
            for (int i = 0; i < secs.Length; i++)
            {
                string secId = getGuid();
                secList.Add(new Section
                {
                    sectionId = secId,
                    sectionName = secs[i],
                    createDate = DateTime.Now,
                    updateDate = DateTime.Now,
                    Is_Delete = 0,
                    Is_Locked = 0,
                    sectionDetails = intiateSecDetail(_secDeList, secId)
                });
            }
            Famsto.storyContent = secList;
            return Famsto;
        }

        /// <summary>
        /// 初始化段落
        /// </summary>
        /// <returns></returns>
        private List<SectionDetail> intiateSecDetail(List<string> _sectionDetails,string _sectionId) {
            List<SectionDetail> secDeList = new List<SectionDetail>();
            foreach (var desc in _sectionDetails)
            {
                SectionDetail sde = new SectionDetail();
                sde.sectionId = _sectionId;
                sde.detailId = getGuid();
                sde.contentDesc = desc;
                secDeList.Add(sde);
            }     
            return secDeList;
        }

        /// <summary>
        /// 保存故事，2022-6-3
        /// </summary>
        /// <param name="_serverDbContext"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public retModel saveFamStory(LightUpFactoryContext _serverDbContext, Story model)
        {
            retModel ret = new retModel();
            DateTime upTime = DateTime.Now;
            var _stories = _serverDbContext.Story.Where(r => r.storyId.Equals(model.storyId)).FirstOrDefault();
            if (_stories != null)
            {
                //update 第一层对象               
                _stories.updateDate = upTime;
                _stories.storyName = model.storyName;

                var _Sections = _serverDbContext.Section.Where(r => r.storyId.Equals(_stories.storyId)).ToList();
                //read from data base
                var secDetails = _serverDbContext.SectionDetail;

                //修改 Section
                foreach (var section in _Sections)
                {
                    var newSec = model.storyContent.Where(r => r.sectionId.Equals(section.sectionId)).FirstOrDefault();
                    section.sectionName = newSec.sectionName;
                    section.updateDate = upTime;
                    //修改 SectionDetail
                    var _SecDetails = _serverDbContext.SectionDetail.Where(r => r.sectionId.Equals(section.sectionId)).ToList();
                    foreach (var _detail in _SecDetails)
                    {
                        //_serverDbContext.Entry()
                        var newDet = newSec.sectionDetails.Where(r => r.detailId.Equals(_detail.detailId)).FirstOrDefault();
                        _detail.contentDesc = newDet.contentDesc;
                        _detail.Is_Delete = newDet.Is_Delete;
                        _detail.updateDate = upTime;
                    }
                }

                //need to find those were new added
                foreach (var New_section in model.storyContent)
                {
                    var store_sec = _Sections.Where(r => r.sectionId.Equals(New_section.sectionId)).FirstOrDefault();
                    if (store_sec == null)
                    {
                        //this is a new section
                        New_section.storyId = model.storyId;
                        _serverDbContext.Section.Add(New_section);
                        //Please test is the section detail will be added automatically?
                    }
                    else
                    {
                        //the section is exist, need to check if new section detail added
                        foreach (var new_sectDetais in New_section.sectionDetails)
                        {
                            //check if the section detail already exist
                            var store_secDet = secDetails.Where(r => r.detailId.Equals(new_sectDetais.detailId)).FirstOrDefault();
                            if (store_secDet == null)
                            {
                                //this is a new paragraph in this section
                                new_sectDetais.sectionId = new_sectDetais.sectionId;
                                _serverDbContext.SectionDetail.Add(new_sectDetais);
                            }
                        }
                    }
                }
            }
            else
            {
                _serverDbContext.Story.Add(model);
            }

            ret.msg = "保存成功！";
            return ret;
        }

        /// <summary>
        /// 获取story对应的家庭编号，2022-6-3
        /// 1. 家庭故事，2.个人故事
        /// </summary>
        /// <param name="context"></param>
        /// <param name="_storyId"></param>
        /// <returns></returns>
        public string GetStoryFamilyId(LightUpFactoryContext context, string _storyId) {
            string FamilyId = "";
            //判断是否为Family的故事id
            var fam = context.Family.Where(r => r.FamilyStorystoryId.Equals(_storyId)).FirstOrDefault();
            if (fam != null)
            {
                FamilyId = fam.FamilyId;
            }
            else {
                //判断是否为Member的故事id
                var mem = context.Member.Where(r => r.MmeberStorystoryId.Equals(_storyId)).FirstOrDefault();
                if (mem != null) {
                    //获取member的Family Id, 一个人可能有两个Family，有可能是spouse Family的更改，但是却由主family
                    FamilyId = mem.FamilyId;
                }
            }

            return FamilyId;
        }

        #region ObjectUpdateRecords, 2022-3-30
        /// <summary>
        /// 
        /// </summary>
        public void createObjectUpdate() { 
            
        }
        #endregion

        #region Audit related function
        /// <summary>
        /// Get current user info
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="_UserId"></param>
        /// <returns></returns>
        public UserInfo getCurrentUser(LightUpFactoryContext _context, string _UserId)
        {
            UserInfo user = _context.UserInfo.Where(r => r.UserId.Equals(_UserId)).FirstOrDefault();
            return user;
        }

        #endregion
    }
}
