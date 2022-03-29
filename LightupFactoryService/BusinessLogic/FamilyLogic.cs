using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
