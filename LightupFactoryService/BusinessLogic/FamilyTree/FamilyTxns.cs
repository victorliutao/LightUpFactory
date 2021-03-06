/*
 作者：刘涛
 时间：2022-2-8
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
    public class FamilyTxns : FamilyLogic
    {
        private LightUpFactoryContext _serverDbContext;
        private string _userId;

        public FamilyTxns(LightUpFactoryContext serverDbContext, string userId)
        {
            _serverDbContext = serverDbContext;
            _userId = userId;
        }

        /// <summary>
        /// 创建家族
        /// 2022-2-28，增加用户id与Familyid，使用optionField1记录Owner Userid
        /// 2022-3-5, 增加家庭故事
        /// </summary>
        /// <returns></returns>
        public retModel createNewFamily(string contStr)
        {
            retModel ret = new retModel();
            Family Model = JsonConvert.DeserializeObject<Family>(contStr);
            //增加默认故事

            List<string> _paras = new List<string>();
            _paras.Add("描写家庭相关的内容");

            Story famStory = new Story();
            famStory.storyId = Model.FamilyStorystoryId;
            Model.FamilyStory = famStory;
            Model.optionField2 = getRandom(4);

            //增加关联关系
            if (Model.optionField1 != null)
            {
                UserFamilyMapping maps = new UserFamilyMapping();
                maps.UserFamilyMapId = getGuid();
                maps.FamilyId = Model.FamilyId;
                maps.UserId = Model.optionField1;
                maps.RoleId = "1";//默认角色为家庭管理人员
                maps.updateDate = DateTime.Now;
                maps.createDate = DateTime.Now;
                maps.Is_Delete = 0;
                maps.Is_Locked = 0;
                _serverDbContext.UserFamilyMapping.Add(maps);
            }
            //添加Family
            _serverDbContext.Family.Add(Model);

            ret.data = Model;
            return ret;
        }

        /// <summary>
        /// 更新member 信息
        /// 2022-2-23
        /// </summary>
        /// <param name="memberStr"></param>
        public retModel updateFamilyList(string memberStr)
        {
            retModel ret = new retModel();
            List<Family> memList = JsonConvert.DeserializeObject<List<Family>>(memberStr);
            //按照类型更新
            var currentMems = _serverDbContext.Family;
            foreach (var item in memList)
            {
                var mem = currentMems.Where(mem => mem.FamilyId.Equals(item.FamilyId)).FirstOrDefault();
                if (mem != null && item.changeCount > mem.changeCount)
                {
                    //2022-4-21，add recorde to object update history
                    ObjectsEditHistory editModel = new ObjectsEditHistory();
                    editModel.ObjectsEditHistoryId = getGuid();
                    editModel.objectName = "Family";
                    editModel.objectId = item.FamilyId;
                    editModel.changeCount = item.changeCount;
                    editModel.userId = item.UserId;
                    editModel.updateDate = DateTime.Now;
                    editModel.changeContent = JsonConvert.SerializeObject(item);
                    _serverDbContext.ObjectsEditHistory.Add(editModel);

                    if (1 == 2)
                    {
                        //直接对Family信息进行修改。
                        mem.memberId = item.memberId;
                        mem.changeCount = item.changeCount;
                        mem.Description = item.Description;
                        mem.Address = item.Address;
                        mem.City = item.City;
                        mem.county = item.county;
                        mem.FamilyName = item.FamilyName;
                        mem.GivenName = item.GivenName;
                        mem.Is_Delete = item.Is_Delete;
                        mem.Is_Locked = item.Is_Locked;
                        mem.Province = item.Province;
                        mem.zipcode = item.zipcode;
                        mem.updateDate = DateTime.Now;
                        mem.UserId = item.UserId;
                        mem.memberId = item.memberId;
                        mem.optionField1 = item.optionField1;
                        mem.optionField2 = item.optionField2;
                        mem.optionField3 = item.optionField3;
                        //增加Family属性
                        mem.showScope = item.showScope;
                    }
                    else
                    {
                        //??修改Family和Member,如何在审批后让内容生效？
                        UserInfo curUser = getCurrentUser(_serverDbContext, item.UserId);
                        AuditTxns audits = new AuditTxns(_serverDbContext, item.UserId);//实例化方法，call specified methods
                        AuditTask atmod = new AuditTask();
                        atmod.title = "家庭信息修改申请";
                        atmod.contents = curUser.FullName + "(" + curUser.UserName + ")" + "申请修改家庭:" + item.FamilyName + "的基础信息";
                        atmod.type = 3;
                        atmod.objectId = item.FamilyId;//存储user
                        atmod.objectName = "Family";
                        atmod.applicator = item.UserId;
                        atmod.familyId = mem.FamilyId;
                        atmod.objectChange = JsonConvert.SerializeObject(item);//提交申请内容，前台可以解析成页面显示
                        audits.createAuditTask(atmod);
                    }



                }
                else
                {
                    //创建，2022-5-11，
                    //item.optionField2 = getRandom(4);
                    //_serverDbContext.Family.Add(item);
                }
            }

            ret.code = 0;
            ret.msg = "保存成功";
            return ret;
        }

        /// <summary>
        /// 修改Family Story
        /// 1. nested object, need to use foreach to update them.
        /// 2. if some instance added, need figure out that has been added.
        /// </summary>
        /// <param name="storyStr"></param>
        /// <returns></returns>
        public retModel updateFamilyStory(string storyStr)
        {
            retModel ret = new retModel();
            Story model = JsonConvert.DeserializeObject<Story>(storyStr);
            ret = saveStory(model);
            return ret;
        }

        //2022-07-01，add userid logic save
        private retModel saveStory(Story model)
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
                        if (newDet != null)
                        {
                            _detail.contentDesc = newDet.contentDesc;
                            _detail.Is_Delete = newDet.Is_Delete;
                            _detail.updateDate = upTime;
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
        /// 批量更新故事内容
        /// </summary>
        /// <param name="StoryList"></param>
        /// <returns></returns>
        public retModel updateStoryList(string StoryList)
        {
            retModel ret = new retModel();
            storyStr story_List = JsonConvert.DeserializeObject<storyStr>(StoryList);
            foreach (Story model in story_List.StoryList)
            {
                if (1 == 2)
                {
                    ret = saveStory(model);
                }
                else
                {
                    //启用审核，审核后再保存成功
                    //待审批后再修改成员信息
                    UserInfo curUser = getCurrentUser(_serverDbContext, _userId);
                    AuditTxns audits = new AuditTxns(_serverDbContext, _userId);//实例化方法，call specified methods
                    AuditTask atmod = new AuditTask();
                    atmod.title = "故事信息修改申请";
                    atmod.contents = curUser.FullName + "(" + curUser.UserName + ")" + "申请修改故事:" + model.storyName + "内容";
                    atmod.type = 3;
                    atmod.objectId = model.storyId;//存储user
                    atmod.objectName = "Story";
                    atmod.applicator = _userId;
                    atmod.familyId = GetStoryFamilyId(_serverDbContext, model.storyId);
                    atmod.objectChange = JsonConvert.SerializeObject(model);//提交申请内容，前台可以解析成页面显示
                    audits.createAuditTask(atmod);

                    ret.code = 0;
                    ret.msg = "修改信息提交成功";
                }

            }
            return ret;
        }

      
        /// <summary>
        /// Refresh Family Invitation code, store in the Family Table.
        /// invitation code store in family.OptionField2
        /// </summary>
        /// <param name="FamilyStr"> include family id</param>
        /// <returns></returns>
        public retModel RefreshFamilyInvitCode(string FamilyStr)
        {
            retModel ret = new retModel();
            Family model = JsonConvert.DeserializeObject<Family>(FamilyStr);
            var fam = _serverDbContext.Family.Where(r => r.FamilyId.Equals(model.FamilyId)).FirstOrDefault();
            fam.optionField2 = getRandom(4);

            ret.code = 0;
            ret.msg = fam.optionField2;
            return ret;
        }


        /// <summary>
        /// 获取Family List/ Member List, RelationList
        /// 2022-4-24， 仅获取权限为公开的内容
        /// </summary>
        /// <param name="FamilyStr"></param>
        /// <returns></returns>
        public retModel getAllFamily(string FamilyStr)
        {
            retModel ret = new retModel();
            retFamilyMembers retContents = new retFamilyMembers();
            Family model = JsonConvert.DeserializeObject<Family>(FamilyStr);
            //2022-3-24, render Family top Member Name.
            var famList = (from a in _serverDbContext.Family
                           join b in _serverDbContext.Member on a.memberId equals b.MemberId into memList
                           from bList in memList.DefaultIfEmpty()
                           where a.Is_Delete == 0
                           && (a.showScope == 1||a.showScope==0) //显示公开的family
                           select new Family
                           {
                               FamilyId = a.FamilyId,
                               FamilyName = a.FamilyName,
                               Description = a.Description,
                               createDate = a.createDate,
                               Address = a.Address,
                               FamilyStorystoryId = a.FamilyStorystoryId,
                               GivenName = a.GivenName,
                               memberId = a.memberId,
                               changeCount = a.changeCount,
                               Is_Delete = a.Is_Delete,
                               Is_Locked = a.Is_Locked,
                               optionField1 = a.optionField1,
                               optionField2 = a.optionField2,
                               optionField3 = bList.MemberName != null ? bList.MemberName : ""// handle null value
                           }
                     ).ToList();
            retContents.FamilyList = famList;

            // get member List from 
            //var memberList = _serverDbContext.Member.ToList();
            // retContents.memberList = memberList;

            //get relationList from members
            // var relationList = _serverDbContext.MemberRelation.ToList();
            //  retContents.relationList = relationList;

            //var storyList = _serverDbContext.Story.ToList();
            ////补全story info
            //foreach (var sto in storyList)
            //{
            //    Story res = getStory(sto.storyId);
            //    sto.storyContent = res.storyContent;
            //}
            //retContents.storyList = storyList;

            ret.code = 0;
            ret.data = retContents;
            return ret;
        }

        /// <summary>
        /// 2022-5-7, 根据FamilyId，获取
        /// 2022-6-30, 根据权限获取获取内容
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel getFamilyData(string paraStr)
        {
            retModel ret = new retModel();
            Family model = JsonConvert.DeserializeObject<Family>(paraStr);
            retFamilyMembers retContents = new retFamilyMembers();

            //get member list by family Id
            var memberList = _serverDbContext.Member.Where(r => r.FamilyId.Equals(model.FamilyId)).ToList();
            retContents.memberList = memberList;

            //get member relation list by family Id
            var relationList = _serverDbContext.MemberRelation.Where(r => r.familyId.Equals(model.FamilyId)).ToList();
            retContents.relationList = relationList;

            //get stories by family Id.
            //2022-5-22, if FamilyStorystoryId is not null
            if (!string.IsNullOrEmpty(model.FamilyStorystoryId))
            {
                List<Story> storyList = _serverDbContext.Story.ToList();
                List<Story> fiStoryList = new List<Story>();              
                //add family story,获取了story的全部内容，包含了story content
                Story famstory = storyList.Where(r => r.storyId.Equals(model.FamilyStorystoryId)).FirstOrDefault();
                if (famstory != null)
                {
                    famstory.optionField1 = "FamilyStory";
                    fiStoryList.Add(famstory);
                }

                //add member stories
                foreach (var sto in memberList)
                {
                    Story memSto = storyList.Where(r => r.storyId.Equals(sto.MmeberStorystoryId)).FirstOrDefault();
                    if (memSto != null)
                    {
                        famstory.optionField1 = "MemberStory";
                        fiStoryList.Add(memSto);
                    }
                }

                //补全story info
                foreach (var sto in fiStoryList)
                {
                   
                    List<GroupEdit> groupEdits = _serverDbContext.GroupEdit.ToList();
                    List<dataPermission> dataPerms = _serverDbContext.dataPermission.ToList();//查询所有的dataPermission
                   
                    //LINQ Query syntax:
                    var secD = from a in _serverDbContext.SectionDetail
                                     where a.sectionId != null
                                     select a;
                    List<Section> secs = (from b in _serverDbContext.Section
                                          where b.storyId == sto.storyId && b.Is_Delete == 0
                                          select b).ToList();
                    List<SectionDetail> secDetails = secD.ToList();
                    #region 2022-7-5, 获取判断 by Member 判断权限的基础数据
                    //2022-7-5, Prepare validation data for Member permission.
                    string _FamilyId = GetStoryFamilyId(_serverDbContext, sto.storyId); ;
                    List<string> _DecMems = new List<string>();
                    if (sto.optionField1 == "MemberStory")
                    {
                        //get members who is child of the member which the storyid belong to, 
                        string memberId = GetMemberIdbyStoryId(_serverDbContext, sto.storyId);
                        if (!string.IsNullOrEmpty(memberId))
                        {
                            _DecMems = GetMemberDecendentsList(_serverDbContext, memberId);
                        }                        
                    }
                    #endregion

                    sto.storyContent = getStorycont(_serverDbContext,secs, secDetails, groupEdits, dataPerms,model.UserId,_DecMems,_FamilyId);
                   
                }
                retContents.storyList = fiStoryList;
            }
            ret.code = 0;
            ret.data = retContents;
            return ret;
        }

        /// <summary>
        /// 添加家族编辑者/
        /// 2022-3-21, 检查是否已经存在
        /// 2022-5-24，增加audit Taks请求
        /// 2022-7-25, 为申请成为家庭编辑者添加请求
        /// </summary>
        /// <param name="ParaStr"></param>
        /// <returns></returns>
        public retModel addFamilyEditor(string ParaStr)
        {
            retModel ret = new retModel();
            UserFamilyMapping model = JsonConvert.DeserializeObject<UserFamilyMapping>(ParaStr);
            //check if mapping already exist; add more criteria: member, roleId
            var userMap = _serverDbContext.UserFamilyMapping.Where(r => r.FamilyId.Equals(model.FamilyId) && r.UserId.Equals(model.UserId) && r.MemberId.Equals(model.MemberId) && r.RoleId == model.RoleId).FirstOrDefault();
            if (userMap == null)
            {
                model.UserFamilyMapId = getGuid();
                model.Is_Delete = 0;
                if (model.RoleId == "3")
                {
                    // add validation, by familyid, by userid, by roleid
                    var ufm = _serverDbContext.UserFamilyMapping.Where(r => r.FamilyId.Equals(model.FamilyId) && r.UserId.Equals(model.UserId) && r.RoleId.Equals("3")).FirstOrDefault();
                    if (ufm != null)
                    {
                        //already existe
                        ret.code = -1;
                        var mem = _serverDbContext.Member.Where(r => r.MemberId.Equals(ufm.MemberId)).FirstOrDefault();
                        ret.msg = "您已经绑定过该家族的成员:" + mem.MemberName;
                        if (ufm.Is_Locked == 1)
                        {
                            ret.msg += ", 状态为待审批，请联系管理审批通过";
                        }
                        return ret;
                    }
                    model.Is_Locked = 1;//lock at first, waiting for audit finish, change status to 0

                    //add audit history
                    //render user infor.
                    var userName = _serverDbContext.UserInfo.Where(r => r.UserId.Equals(model.UserId)).FirstOrDefault();
                    var member = _serverDbContext.Member.Where(r => r.MemberId.Equals(model.MemberId)).FirstOrDefault();
                    var familyName = _serverDbContext.Family.Where(r => r.FamilyId.Equals(model.FamilyId)).FirstOrDefault();
                    AuditTxns audits = new AuditTxns(_serverDbContext, model.UserId);//实例化方法，call specified methods
                    AuditTask atmod = new AuditTask();
                    atmod.title = "家庭成员绑定申请";
                    atmod.contents = "用户" + userName.FullName + "(" + userName.UserName + "),申请绑定" + familyName.FamilyName + "的成员" + member.MemberName + "。请审核！";
                    atmod.type = 1;
                    atmod.objectId = model.UserFamilyMapId;//存储user
                    atmod.objectName = "UserFamilyMapping";
                    atmod.applicator = model.UserId;
                    atmod.familyId = model.FamilyId;
                    atmod.objectChange = ParaStr;//提交申请内容，前台可以解析成页面显示
                    audits.createAuditTask(atmod);

                    //1011-07-19,修改添加成功后的返回内容格式
                    ret.data = new
                    {
                        familyId = model.FamilyId,
                        familyName = familyName.FamilyName,
                        givenName = familyName.GivenName,
                        memberId = member.MemberId,
                        memberName = member.MemberName,
                        userFamilyMapId = model.UserFamilyMapId
                    };
                }
                else if (model.RoleId == "2")
                {
                    // add validation, by familyid, by userid, by roleid
                    var ufm = _serverDbContext.UserFamilyMapping.Where(r => r.FamilyId.Equals(model.FamilyId) && r.UserId.Equals(model.UserId) && r.RoleId.Equals("2")).FirstOrDefault();
                    if (ufm != null)
                    {
                        //already existe
                        ret.code = -1;                        
                        ret.msg = "您已经申请了该家族的编辑者" ;
                        if (ufm.Is_Locked == 1)
                        {
                            ret.msg += ", 状态为待审批，请联系管理审批通过";
                        }
                        return ret;
                    }
                    model.Is_Locked = 1;//lock at first, waiting for audit finish, change status to 0

                    //add audit history
                    //render user infor.
                    var userName = _serverDbContext.UserInfo.Where(r => r.UserId.Equals(model.UserId)).FirstOrDefault();
                    var member = _serverDbContext.Member.Where(r => r.MemberId.Equals(model.MemberId)).FirstOrDefault();
                    var familyName = _serverDbContext.Family.Where(r => r.FamilyId.Equals(model.FamilyId)).FirstOrDefault();
                    AuditTxns audits = new AuditTxns(_serverDbContext, model.UserId);//实例化方法，call specified methods
                    AuditTask atmod = new AuditTask();
                    atmod.title = "家庭编辑者申请";
                    atmod.auditTaskName = model.optionField1;//借用audit Task Name来存储申请原因
                    atmod.contents = "用户" + userName.FullName + "(" + userName.UserName + "),申请成为" + familyName.FamilyName + "的编辑者，请审核！";
                    atmod.type = 2;
                    atmod.objectId = model.UserFamilyMapId;//存储user
                    atmod.objectName = "UserFamilyMapping";
                    atmod.applicator = model.UserId;
                    atmod.familyId = model.FamilyId;
                    atmod.objectChange = ParaStr;//提交申请内容，前台可以解析成页面显示
                    audits.createAuditTask(atmod);
                }
                else {
                    model.Is_Locked = 0;
                }

                model.createDate = DateTime.Now;
                model.updateDate = DateTime.Now;
                _serverDbContext.UserFamilyMapping.Add(model);
            }
            else
            {
                if (userMap.Is_Delete == 0)
                {
                    ret.code = -1;
                    ret.msg = "已存在";
                }
                else
                {
                    userMap.Is_Delete = 0;
                    userMap.updateDate = DateTime.Now;
                }
            }
            return ret;
        }

        /// <summary>
        /// 2022-3-20, 获取fanmilyEditor信息, Render成前端需要的样式
        /// 2022-7-25, 增加根据RoleId筛选,排除成员绑定，role id=3
        /// </summary>
        /// <param name="ParaStr"></param>
        /// <returns></returns>
        public retModel getFamilyEditor(string ParaStr)
        {
            retModel ret = new retModel();
            UserFamilyMapping model = JsonConvert.DeserializeObject<UserFamilyMapping>(ParaStr);
            
            var EditList = (from a in _serverDbContext.UserFamilyMapping
                            join b in _serverDbContext.UserInfo on a.UserId equals b.UserId
                            where a.Is_Delete == 0 && a.FamilyId.Equals(model.FamilyId) && b.Is_Delete == 0 &&a.RoleId!="3"
                            orderby a.createDate
                            select new
                            {
                                a.UserFamilyMapId,
                                a.UserId,
                                b.UserName,
                                a.RoleId,
                                a.MemberId
                            }
                           ).ToList();

            ret.data = EditList;
            return ret;
        }

        /// <summary>
        /// 2022-3-21,修改
        /// </summary>
        /// <param name="parastr"></param>
        /// <returns></returns>
        public retModel updateUserMapping(string parastr)
        {
            retModel ret = new retModel();
            UserFamilyMapping model = JsonConvert.DeserializeObject<UserFamilyMapping>(parastr);
            var ufm = _serverDbContext.UserFamilyMapping.Where(r => r.UserFamilyMapId.Equals(model.UserFamilyMapId)).FirstOrDefault();
            ufm.MemberId = model.MemberId;
            ufm.RoleId = model.RoleId;
            ufm.updateDate = DateTime.Now;
            return ret;
        }

        /// <summary>
        /// 删除数据,2022-3-21
        /// </summary>
        /// <param name="parastr"></param>
        /// <returns></returns>
        public retModel DeleteUserMapping(string parastr)
        {
            retModel ret = new retModel();
            UserFamilyMapping model = JsonConvert.DeserializeObject<UserFamilyMapping>(parastr);
            var ufm = _serverDbContext.UserFamilyMapping.Where(r => r.UserFamilyMapId.Equals(model.UserFamilyMapId)).FirstOrDefault();
            ufm.Is_Delete = 1;
            ufm.updateDate = DateTime.Now;
            return ret;
        }

        /// <summary>
        /// 根据Family Id 单独获取FamilyInfo;
        /// 2022-4-2
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel getFamilyById(string paraStr)
        {
            retModel ret = new retModel();
            Family model = JsonConvert.DeserializeObject<Family>(paraStr);
            var fam = _serverDbContext.Family.Where(r => r.FamilyId.Equals(model.FamilyId)).FirstOrDefault();
            ret.data = fam;
            return ret;
        }

        /// <summary>
        /// 2022-5-17， get family by invit code
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel getFamilyByInviteCode(string paraStr)
        {
            retModel ret = new retModel();
            Family model = JsonConvert.DeserializeObject<Family>(paraStr);
            var fam = _serverDbContext.Family.Where(r => r.optionField2.Equals(model.optionField2)).FirstOrDefault();
            if (fam != null)
            {
                ret.data = fam;
                ret.msg = "获取family信息";
            }
            else
            {
                ret.code = -1;
                ret.msg = "获取family对象失败";
            }


            return ret;
        }


        /// <summary>
        /// 2022-4-26
        /// Get Family by FamilyId List
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel getFamilyByIdList(string paraStr)
        {
            retModel ret = new retModel();
            List<string> famIds = JsonConvert.DeserializeObject<List<string>>(paraStr);
            //List<Family> famList = JsonConvert.DeserializeObject<List<Family>>(paraStr);
            //List<string> famIds = new List<string>();
            //foreach (var fam in famList) {
            //    famIds
            //}
            var Fams = _serverDbContext.Family.Where(r => famIds.Contains(r.FamilyId)).ToList();
            ret.data = Fams;
            return ret;
        }

        #region Family Square
        /// <summary>
        /// create new Family Square
        /// 2022-4-11
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel createFamilySquar(string paraStr)
        {
            retModel ret = new retModel();
            FamilySquare model = JsonConvert.DeserializeObject<FamilySquare>(paraStr);
            model.Is_Delete = 0;
            model.Is_Locked = 0;
            model.updateDate = DateTime.Now;
            model.createDate = DateTime.Now;
            _serverDbContext.FamilySquare.Add(model);
            return ret;
        }

        /// <summary>
        /// update Family Square info
        /// 2022-4-11
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel updateFamilySquare(string paraStr)
        {
            retModel ret = new retModel();
            FamilySquare model = JsonConvert.DeserializeObject<FamilySquare>(paraStr);
            FamilySquare fs = _serverDbContext.FamilySquare.Where(r => r.FamilySquareId.Equals(model.FamilySquareId)).FirstOrDefault();
            // compare change count
            if (model.changeCount > fs.changeCount)
            {
                fs.updateDate = DateTime.Now;
                fs.FamilySquareName = model.FamilySquareName;
                fs.changeCount = model.changeCount;
                fs.Description = model.Description;
                fs.ShowScope = model.ShowScope;
                fs.optionField1 = model.optionField1;
                fs.optionField2 = model.optionField2;
                fs.optionField3 = model.optionField3;
                //change family square details, delete current, add create new;
                var currentDetails = _serverDbContext.FamilySquareDetails.Where(r => r.familySquareId.Equals(model.FamilySquareId)).ToList();
                foreach (var item in currentDetails)
                {
                    _serverDbContext.FamilySquareDetails.Remove(item);
                }
                // add new details
                foreach (var item in model.FamilyDetails)
                {
                    _serverDbContext.FamilySquareDetails.Add(item);
                }
            }

            return ret;
        }

        /// <summary>
        /// Delete a family Square
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel DeleteFamilySquare(string paraStr)
        {
            retModel ret = new retModel();
            FamilySquare model = JsonConvert.DeserializeObject<FamilySquare>(paraStr);
            FamilySquare fs = _serverDbContext.FamilySquare.Where(r => r.FamilySquareId.Equals(model.FamilySquareId)).FirstOrDefault();
            fs.Is_Delete = 1;
            fs.updateDate = DateTime.Now;
            return ret;
        }

        /// <summary>
        /// 获取Family Square, 用途： 1. 获取user编辑的Square,2.根据SquareId获取Square；3. 页面显示，根据ShowCode来查询FamilySquare
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel getFamilySquare(string paraStr)
        {
            retModel ret = new retModel();
            FamilySquare model = JsonConvert.DeserializeObject<FamilySquare>(paraStr);
            List<FamilySquare> Fs = _serverDbContext.FamilySquare.Where(r => r.Is_Delete == 0 && r.UserId != null).ToList();


            if (!string.IsNullOrEmpty(model.UserId))
            {
                //根据UserId获取已编辑的Family Square, 用于展示和编辑
                var neFs = Fs.Where(r => r.UserId.Equals(model.UserId)).ToList();
                Fs = neFs;
            }
            if (!string.IsNullOrEmpty(model.FamilySquareId))
            {
                //根据Family SquareId 获取对象

                Fs = Fs.Where(r => r.FamilySquareId.Equals(model.FamilySquareId)).ToList();
            }
            if (model.ShowScope != 0)
            {
                //根据显示权限筛选
                Fs = Fs.Where(r => r.ShowScope == model.ShowScope).ToList();
            }
            //Render Family Square Detail
            //2022-4-19, add family square whild loading
            List<FamilySquareDetails> FsDetails = _serverDbContext.FamilySquareDetails.ToList();
            foreach (var item in Fs)
            {
                item.FamilyDetails = FsDetails.Where(r => r.familySquareId.Equals(item.FamilySquareId)).ToList();
            }
            //TBD
            ret.data = Fs;
            return ret;
        }
        #endregion

    }

    public class retFamilyMembers
    {
        public List<Family> FamilyList { get; set; }
        public object memberList { get; set; }
        public List<MemberRelation> relationList { get; set; }
        //2022-3-12, add story list, geting from server
        public List<Story> storyList { get; set; }
    }
}
