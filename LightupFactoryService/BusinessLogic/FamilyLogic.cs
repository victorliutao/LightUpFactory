using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightupFactoryService.ContextStr;
using LightupFactoryService.Model;
using System.Net.Http;
using Newtonsoft.Json;

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
        /// 2022-6-28, 添加显示权限
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
                    if (newSec != null)
                    {
                        section.sectionName = newSec.sectionName;
                        section.updateDate = upTime;
                        //update dataPermission
                        if (newSec.permission == null)
                        {
                            dataPermission dp = new dataPermission();
                            dp.showScope = "3";
                            newSec.permission = dp;
                        }
                        newSec.permission.objectId = section.sectionId;
                        newSec.permission.objectName = "Section";

                        updatedataPermission(_serverDbContext, newSec.permission);

                        //修改 SectionDetail
                        var _SecDetails = _serverDbContext.SectionDetail.Where(r => r.sectionId.Equals(section.sectionId)).ToList();
                        foreach (var _detail in _SecDetails)
                        {
                            //_serverDbContext.Entry()
                            var newDet = newSec.sectionDetails.Where(r => r.detailId.Equals(_detail.detailId)).FirstOrDefault();
                            if (newDet != null)
                            {
                                _detail.contentDesc = newDet.contentDesc;
                                _detail.Is_Delete = newDet.Is_Delete;
                                _detail.updateDate = upTime;

                                //update dataPermission
                                if (newDet.permission == null)
                                {
                                    dataPermission dp = new dataPermission();
                                    dp.showScope = "3";
                                    newDet.permission = dp;
                                }
                                newDet.permission.objectId = _detail.detailId;
                                newDet.permission.objectName = "Paragraph";
                                updatedataPermission(_serverDbContext, newDet.permission);
                            }
                        }
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
                        //2022-6-30， add new data permission instance
                        if (New_section.permission == null)
                        {
                            dataPermission dp = new dataPermission();
                            dp.showScope = "3";
                            New_section.permission = dp;
                        }
                        New_section.permission.objectId = New_section.sectionId;
                        New_section.permission.objectName = "Section";
                        updatedataPermission(_serverDbContext, New_section.permission);
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

                                if (new_sectDetais.permission == null)
                                {
                                    dataPermission dp = new dataPermission();
                                    dp.showScope = "3";
                                    new_sectDetais.permission = dp;
                                }
                                new_sectDetais.permission.objectId = new_sectDetais.detailId;
                                new_sectDetais.permission.objectName = "Paragraph";
                                updatedataPermission(_serverDbContext, new_sectDetais.permission);
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
        /// get story and it's detail infor by storyid
        /// 2022-6-30，增加权限筛选,增加入参，UserId
        /// 将返回值由story,修改为List<Section></Section>
        /// 2022-7-5,增加按照MemberId权限判断
        /// </summary>
        /// <param name="_StoryId"></param>
        /// <param name="_userId"></param>
        /// <returns></returns>
        public List<Section> getStorycont(LightUpFactoryContext context,List<Section> secs,List<SectionDetail> secDetails, List<GroupEdit> groupEdits, List<dataPermission> dataPerms, string _userId,List<string> _memid,string _familyId)
        {
            //2022-7-1, 避免查询内容时，也修改了内容
            //添加Section
            List<Section> secList = new List<Section>();
            foreach (Section sec in secs)
            {
                Section n_sec = new Section();
                var sdp = dataPerms.Where(r => r.objectId.Equals(sec.sectionId) && r.objectName.Equals("Section")).FirstOrDefault();
                if (sdp != null)
                {
                    if (checkPermission(context,sdp, _userId, _memid,_familyId))
                    {
                        n_sec.sectionId = sec.sectionId;
                        n_sec.sectionName = sec.sectionName;
                        n_sec.permission = sdp;
                        secList.Add(n_sec);
                    }
                }
                else
                {
                    //未定义权限，也添加
                    secList.Add(sec);
                }
            }
            //add section detail
            foreach (var section in secList)
            {
                List<SectionDetail> detailsList = new List<SectionDetail>();
                var draftDetails = secDetails.Where(r => r.sectionId.Equals(section.sectionId)).ToList();
                //检查显示权限
                foreach (var secD in draftDetails)
                {
                    var dp = dataPerms.Where(r => r.objectId.Equals(secD.detailId) && r.objectName.Equals("Paragraph")).FirstOrDefault();
                    if (dp != null)
                    {
                        if (checkPermission(context,dp, _userId, _memid, _familyId))
                        {
                            secD.permission = dp;
                            detailsList.Add(secD);
                        }                        
                    }
                    else
                    {
                        detailsList.Add(secD);
                    }
                }
                section.sectionDetails = detailsList;

                //添加groupEdit,2022-4-1
                section.goupEditDetails = groupEdits.Where(r => r.sectionId.Equals(section.sectionId)).ToList();
            }
            return secList;
        }

        /// <summary>
        /// 2022-6-30,判断是否要显示
        /// 2022-7-05, 判断是否是MemberId所对应的范围
        /// </summary>
        /// <param name="dp"></param>
        /// <param name="_UserId"></param>
        /// <returns></returns>
        public bool checkPermission(LightUpFactoryContext context,dataPermission dp, string _UserId, List<string> memid, string _familyId)
        {
            bool checks = false;
            switch (dp.showScope)
            {
                case "3":
                    //公开
                    checks = true;
                    break;
                case "2":
                    //指定的memberId, 判断UserId对应的MemberId是否
                    //2022-7-5， Two use cases, the MemberId is null, the MemberId is not null
                    if (string.IsNullOrEmpty(dp.scopeMemberId))
                    {
                        //case 1:  memberid is null, check if the family id is the same
                        List<string> MapMems = getMemIdsbyUserId(context, _UserId);
                        foreach (string mem in MapMems) {
                            var member = getMemberById(context, mem);
                            if (member != null) {
                                if (member.FamilyId == _familyId || member.marriageFamilyId == _familyId) {
                                    checks = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        //case 2: member id is not null
                        //get mapping memberId by userId
                        List<string> MapMems = getMemIdsbyUserId(context, _UserId);
                        //check if the member in member list
                        foreach (string mem in MapMems) {
                            if (memid.IndexOf(mem) >= 0) {
                                checks = true;
                                break;
                            }
                        }
                    }
                    
                    break;
                case "1":
                    //指定的User,通常为自己
                    if (dp.scopeUserId == _UserId)
                    {
                        checks = true;
                    }
                    else
                    {
                        checks = false;
                    }
                    break;
                default:
                    checks = true;
                    break;
            }
            return checks;
        }

        /// <summary>
        /// 获取Member
        /// </summary>
        /// <param name="context"></param>
        /// <param name="_memId"></param>
        /// <returns></returns>
        public Member getMemberById(LightUpFactoryContext context, string _memId) {
            var mem = context.Member.Where(r => r.MemberId.Equals(_memId)).FirstOrDefault();
            return mem;
        }

        /// <summary>
        /// 获取User Id绑定的MemberIds
        /// </summary>
        /// <param name="context"></param>
        /// <param name="_userId"></param>
        /// <returns></returns>
        private List<string> getMemIdsbyUserId(LightUpFactoryContext context, string _userId) {
            List<string> mapIds = new List<string>();
            var memMaps = context.UserFamilyMapping.Where(r => r.UserId.Equals(_userId) && r.RoleId.Equals("3")).ToList();
            foreach (var mem in memMaps) {
                mapIds.Add(mem.MemberId);
            }
            return mapIds;
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

        /// <summary>
        /// 2022-7-5, 根据storyid, 获取对应的memberid
        /// </summary>
        /// <param name="context"></param>
        /// <param name="_storyId"></param>
        /// <returns></returns>
        public string GetMemberIdbyStoryId(LightUpFactoryContext context, string _storyId) {
            string memId = "";
            var mem = context.Member.Where(r => r.MmeberStorystoryId.Equals(_storyId)).FirstOrDefault();
            if (mem != null)
            {
                memId = mem.MemberId;
            }
            return memId;
        }

        /// <summary>
        /// 2022-7-5，获取指定用户的子孙后代
        /// </summary>
        /// <param name="context"></param>
        /// <param name="_MemberId"></param>
        /// <returns></returns>
        public List<string> GetMemberDecendentsList(LightUpFactoryContext context, string _MemberId) {
            List<string> memList = new List<string>();
            var memRel = context.MemberRelation.Where(r => r.Is_Delete == 0).ToList();//get all member relation
            memList = getChilds(memRel, _MemberId);
            return memList;
        }

        /// <summary>
        /// 2022-7-5, 递归调用，获取所有的child
        /// </summary>
        /// <param name="_memRels"></param>
        /// <param name="_memberId"></param>
        /// <returns></returns>
        private List<string> getChilds(List<MemberRelation> _memRels, string _memberId) {
            List<string> memList = new List<string>();
            var mems = _memRels.Where(r => r.parentId.Equals(_memberId)).ToList();
            foreach (var mem in mems) {
                //判断是否已存在
                if (memList.IndexOf(mem.MemberId) < 0) {
                    //不存在，则添加
                    memList.Add(mem.MemberId);

                    //查看是否还有下级
                    List<string> childList = getChilds(_memRels, mem.MemberId);
                    if (childList.Count > 0)
                    {
                        memList.Concat(childList);
                    }
                }
            }
            return memList;
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

        #region Wechat Related
        public string GetOpenId(string code) {
            string openId = "";
            string appid = "wx74d009b08f67c267";
            string appSecret = "4b1df820563ad9666d2aff43e8ab8f40";
            string url = "https://api.weixin.qq.com/sns/jscode2session?appid=wx74d009b08f67c267&secret=4b1df820563ad9666d2aff43e8ab8f40&js_code="+code+"&grant_type=authorization_code";
            //send get service;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    string s = t.Result;
                    string json = JsonConvert.DeserializeObject(s).ToString();
                    openIdres res = JsonConvert.DeserializeObject<openIdres>(json);
                    openId = res.openid;

                }
            }


            return openId;
        }
        #endregion

    }

    public class openIdres
    {
        public string session_key { get; set; }
        public string openid { get; set; }
    }
}
