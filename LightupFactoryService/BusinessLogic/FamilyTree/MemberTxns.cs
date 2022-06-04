/*
 * 2022-2-18，刘涛
 * 更新Member信息
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LightupFactoryService.Model;
using LightupFactoryService.ContextStr;

namespace LightupFactoryService.BusinessLogic
{
    public class MemberTxns : FamilyLogic
    {
        private LightUpFactoryContext _serverDbContext;
        private string _userId;

        public MemberTxns(LightUpFactoryContext serverDbContext,string userId)
        {
            _serverDbContext = serverDbContext;
            _userId = userId;
        }
        /// <summary>
        /// 更新member 信息
        /// 2022-2-18
        /// 2022-3-29, 增加扩展属性
        /// </summary>
        /// <param name="memberStr"></param>
        public retModel updateMemberList(string memberStr)
        {
            retModel ret = new retModel();
            List<Member> memList = JsonConvert.DeserializeObject<List<Member>>(memberStr);
            //按照类型更新
            var currentMems = _serverDbContext.Member;
            foreach (var item in memList)
            {
                //2022-3-30，add recorde to object update history
                ObjectsEditHistory editModel = new ObjectsEditHistory();
                editModel.ObjectsEditHistoryId = getGuid();
                editModel.objectName = "Member";
                editModel.objectId = item.MemberId;
                editModel.changeCount = item.changeCount;
                editModel.userId = item.UserId;
                editModel.updateDate = DateTime.Now;
                editModel.changeContent = JsonConvert.SerializeObject(item);
                _serverDbContext.ObjectsEditHistory.Add(editModel);  

                var mem = currentMems.Where(mem => mem.MemberId.Equals(item.MemberId)).FirstOrDefault();
                if (mem != null)
                {
                    //修改， 2022-3-29，增加根据changeCount来判断是否修改
                    if (item.changeCount > mem.changeCount)
                    {
                        if (1 == 2)
                        {
                            //直接修改成员内容
                            mem.changeCount = item.changeCount;
                            mem.Description = item.Description;
                            mem.FamilyId = item.FamilyId;
                            mem.gender = item.gender;
                            mem.Is_Delete = item.Is_Delete;
                            mem.Is_Locked = item.Is_Locked;
                            mem.MemberName = item.MemberName;
                            mem.Region = item.Region;
                            mem.status = item.status;
                            mem.updateDate = DateTime.Now;
                            mem.UserId = item.UserId;
                            //2022-3-19, 增加member编辑设置
                            mem.Is_PermissionNode = item.Is_PermissionNode;
                            //
                            mem.marriageFamilyId = item.marriageFamilyId;
                            //2022-3-29, 增加Member 扩展字段的更新
                            mem.headImage = item.headImage;
                            mem.dateOfBirth = item.dateOfBirth;
                            mem.dateOfBirthLunar = item.dateOfBirthLunar;
                            mem.dateOfDeath = item.dateOfDeath;
                            mem.dateOfDeathLunar = item.dateOfDeathLunar;
                            mem.templeName = item.templeName;
                            mem.yearName = item.yearName;
                            mem.respectName = item.respectName;
                            mem.firstName = item.firstName;
                            mem.middleName = item.middleName;
                            mem.givenName = item.givenName;
                            mem.callingName = item.callingName;
                            mem.birthDad = item.birthDad;
                            mem.raiseDad = item.raiseDad;
                            mem.birthMom = item.birthMom;
                            mem.raiseMom = item.raiseMom;
                            mem.tombLocation = item.tombLocation;
                            mem.tombDate = item.tombDate;
                        }
                        else {
                            //待审批后再修改成员信息
                            UserInfo curUser = getCurrentUser(_serverDbContext, item.UserId);
                            AuditTxns audits = new AuditTxns(_serverDbContext,item.UserId);//实例化方法，call specified methods
                            AuditTask atmod = new AuditTask();
                            atmod.title = "成员信息修改申请";
                            atmod.contents = curUser.FullName + "(" + curUser.UserName + ")" + "申请修改成员:" + item.MemberName + "的基础信息";
                            atmod.type = 3;
                            atmod.objectId = item.MemberId;//存储user
                            atmod.objectName = "Member";
                            atmod.applicator = item.UserId;
                            atmod.familyId = mem.FamilyId;
                            atmod.objectChange = JsonConvert.SerializeObject(item);//提交申请内容，前台可以解析成页面显示
                            audits.createAuditTask(atmod);
                        }
                       
                    }                   
                }
                else {
                    //创建, 2022-3-8,初始化成员故事
                    List<string> _paras = new List<string>();
                    _paras.Add("描写成员故事");
                    // string _initiSecs = "成员概述,成员大事记";
                    //item.MmeberStory = InitiateStory(item.MmeberStorystoryId, _initiSecs, _paras,item.MemberName+"成员故事");
                    Story sto = new Story();
                    sto.storyId = item.MmeberStorystoryId;
                    item.MmeberStory = sto;
                    _serverDbContext.Member.Add(item);
                }               
            }

            ret.code = 0;
            ret.msg = "保存成功";
            return ret;
        }

        /// <summary>
        /// 更新Relationship 信息
        /// 2022-2-23
        /// </summary>
        /// <param name="memberStr"></param>
        public retModel updateRelationList(string relationStr)
        {
            retModel ret = new retModel();
            List<MemberRelation> memList = JsonConvert.DeserializeObject<List<MemberRelation>>(relationStr);
            //按照类型更新
            var currentMems = _serverDbContext.MemberRelation;
            foreach (var item in memList)
            {
                var mem = currentMems.Where(mem => mem.MemberRelationId.Equals(item.MemberRelationId)).FirstOrDefault();

                if (mem != null)
                {
                    //修改
                    if (item.changeCount > mem.changeCount) {
                        mem.parentId = item.parentId;
                        mem.relationId = item.relationId;
                        mem.Is_Delete = item.Is_Delete;
                        mem.childSeq = item.childSeq;
                        mem.changeCount = item.changeCount;
                        mem.updateDate = DateTime.Now;
                        //2022-4-10，update relation's familyId
                        mem.familyId = item.familyId;
                    }
                   
                }
                else
                {
                    //创建
                    //7 Mar 2022, generate guid from front end
                    //item.MemberRelationId = getGuid();
                    _serverDbContext.MemberRelation.Add(item);
                }
            }
            _serverDbContext.SaveChanges();
            ret.code = 0;
            ret.msg = "保存成功";
            return ret;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="userStr"></param>
        /// <returns></returns>
        public retModel RegisterUser(string userStr) {
            retModel ret = new retModel();
            UserInfo user = JsonConvert.DeserializeObject<UserInfo>(userStr);
            user.UserId = getGuid();//获取guid
            user.Is_Delete = 0;
            user.Is_Locked = 0;
            user.updateDate = DateTime.Now;
            user.createDate = DateTime.Now;

            _serverDbContext.UserInfo.Add(user);
            _serverDbContext.SaveChanges();
            ret.msg = "用户注册成功！";
            ret.code = 0;           
            ret.data = user;
            return ret;
        }

        /// <summary>
        /// User login server, return employee entity
        /// Mar.2. 2022
        /// </summary>
        /// <param name="userStr"></param>
        /// <returns></returns>
        public retModel UserLogin(string userStr) {
            retModel ret = new retModel();
            UserInfo model = JsonConvert.DeserializeObject<UserInfo>(userStr);
            //valiate if credential is correct
            var user = _serverDbContext.UserInfo.Where(r => r.UserName.Equals(model.UserName)).FirstOrDefault();
            if (user == null)
            {
                ret.msg = "用户不存在";
                ret.code = -1;
            }
            else {
                if (user.User_password != model.User_password)
                {
                    ret.msg = "密码不正确";
                    ret.code = -1;
                }
                else {
                    ret.msg = "登录成功";
                    ret.code = 0;
                    ret.data = user;
                }
            }
          
            return ret;
        }

        /// <summary>
        /// 新增用户familyMapping
        /// </summary>
        /// <param name="famMapStr"></param>
        /// <returns></returns>
        public retModel addFmilyMapping(string famMapStr) {
            retModel ret = new retModel();
            UserFamilyMapping model = JsonConvert.DeserializeObject<UserFamilyMapping>(famMapStr);
            model.UserFamilyMapId = getGuid();
            model.updateDate = DateTime.Now;
            model.createDate = DateTime.Now;
            model.Is_Delete = 0;
            model.Is_Locked = 0;
            _serverDbContext.UserFamilyMapping.Add(model);
            _serverDbContext.SaveChanges();
            ret.msg = "用于映射关系";
            ret.code = 0;
            return ret;
        }

        /// <summary>
        /// 2022-2-28,根据用户Id 获取Family List
        /// 7 Mar 2022, solve bug: own family has null value in list; possible history data issue, delete family, but didn't delete the mapping table
        /// </summary>
        /// <param name="userStr"></param>
        /// <returns></returns>
        public retModel getFamilyListByOwner(string userStr)
        {
            retModel ret = new retModel();
            UserInfo model = JsonConvert.DeserializeObject<UserInfo>(userStr);
           List<string> Fam_List = new List<string>();
            var FamilyList = _serverDbContext.Family;
            var userFamMap = _serverDbContext.UserFamilyMapping.Where(r => r.UserId.Equals(model.UserId)&&r.RoleId.Equals("1")).ToList();
            foreach (var userFam in userFamMap) {
                var family = FamilyList.Where(r => r.FamilyId.Equals(userFam.FamilyId)).FirstOrDefault();
                Fam_List.Add(family.FamilyId);
            }
            ret.code = 0;
            ret.msg = "获取管理的Family 清单";
            ret.data = Fam_List;
            return ret;
        }

        /// <summary>
        /// 2022-3-22， 根据角色获取Family 清单
        /// </summary>
        /// <param name="userStr"></param>
        /// <returns></returns>
        public retModel getFamilyListByRole(string userStr)
        {
            retModel ret = new retModel();
            UserFamilyMapping model = JsonConvert.DeserializeObject<UserFamilyMapping>(userStr);
            List<string> Fam_List = new List<string>();
           
            var userFamMap = _serverDbContext.UserFamilyMapping.Where(r => r.UserId.Equals(model.UserId) && r.RoleId.Equals(model.RoleId)).ToList();
            foreach (var userFam in userFamMap)
            {
                Fam_List.Add(userFam.FamilyId);
            }
            ret.code = 0;
            ret.msg = "获取角色对应的Family 清单";
            ret.data = Fam_List;
            return ret;
        }

        /// <summary>
        /// 2022-3-19, 获取用户List
        /// </summary>
        /// <returns></returns>
        public retModel GetUserList(string _UserStr) {
            retModel ret = new retModel();
            var userList = _serverDbContext.UserInfo.Where(r => r.Is_Delete == 0).ToList();
            ret.data = userList;
            return ret;
        }
    }       
}
