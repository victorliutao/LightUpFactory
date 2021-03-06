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

        public MemberTxns(LightUpFactoryContext serverDbContext, string userId)
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
                        else
                        {
                            //待审批后再修改成员信息
                            UserInfo curUser = getCurrentUser(_serverDbContext, item.UserId);
                            AuditTxns audits = new AuditTxns(_serverDbContext, item.UserId);//实例化方法，call specified methods
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
                else
                {
                    if (1 == 2)
                    {
                        //创建, 2022-3-8,初始化成员故事
                        //添加audit，add family
                        List<string> _paras = new List<string>();
                        _paras.Add("描写成员故事");
                        // string _initiSecs = "成员概述,成员大事记";
                        //item.MmeberStory = InitiateStory(item.MmeberStorystoryId, _initiSecs, _paras,item.MemberName+"成员故事");
                        Story sto = new Story();
                        sto.storyId = item.MmeberStorystoryId;
                        item.MmeberStory = sto;
                        _serverDbContext.Member.Add(item);
                    }
                    else
                    {
                        //待审批后再修改成员信息
                        UserInfo curUser = getCurrentUser(_serverDbContext, item.UserId);
                        AuditTxns audits = new AuditTxns(_serverDbContext, item.UserId);//实例化方法，call specified methods
                        AuditTask atmod = new AuditTask();
                        atmod.title = "创建成员申请";
                        atmod.contents = curUser.FullName + "(" + curUser.UserName + ")" + "申请创建成员:" + item.MemberName + "的基础信息";
                        atmod.type = 3;
                        atmod.objectId = item.MemberId;//存储user
                        atmod.objectName = "Member_Create";
                        atmod.applicator = item.UserId;
                        atmod.familyId = item.FamilyId;
                        atmod.objectChange = JsonConvert.SerializeObject(item);//提交申请内容，前台可以解析成页面显示
                        audits.createAuditTask(atmod);
                    }

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
                    if (item.changeCount > mem.changeCount)
                    {
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
        public retModel RegisterUser(string userStr)
        {
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
        public retModel UserLogin(string userStr)
        {
            retModel ret = new retModel();
            UserInfo model = JsonConvert.DeserializeObject<UserInfo>(userStr);
            //valiate if credential is correct
            var user = _serverDbContext.UserInfo.Where(r => r.UserName.Equals(model.UserName)).FirstOrDefault();
            if (user == null)
            {
                ret.msg = "用户不存在";
                ret.code = -1;
            }
            else
            {
                if (user.User_password != model.User_password)
                {
                    ret.msg = "密码不正确";
                    ret.code = -1;
                }
                else
                {
                    ret.msg = "登录成功";
                    ret.code = 0;
                    ret.data = user;
                }
            }

            return ret;
        }

        /// <summary>
        /// 2022-6-18, login with user login
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel wechatLogin(string paraStr)
        {
            retModel ret = new retModel();
            UserInfo model = JsonConvert.DeserializeObject<UserInfo>(paraStr);
            string openid = GetOpenId(model.WorkCenterId);//借用WorkCenterId 存储微信用户的code
            var user = _serverDbContext.UserInfo.Where(r => r.ResourceId.Equals(openid)).FirstOrDefault();
            if (user != null)
            {
                //openid 已存在
                ret.code = 0;
                ret.msg = "Login validation success";
                ret.data = user;
            }
            else
            {
                //open id 不存在，绑定已有用户，或注册新用户
                var user2 = _serverDbContext.UserInfo.Where(r => r.UserName.Equals(model.UserName)).FirstOrDefault();
                if (user2 != null)
                {
                    //user 已存在， 判断是更新openid, 还是新创建用户
                    if (model.Is_Delete == 1)
                    {
                        //已存在，更新openid
                        user2.ResourceId = openid;
                        user2.ResourceGroupId = model.ResourceGroupId;
                        user2.updateDate = DateTime.Now;

                        ret.code = 0;
                        ret.data = user2;
                        ret.msg = "用户信息更新成功";
                    }
                    else
                    {
                        //用户名已存在，需要更新用户名之后再创建用户
                        model.UserName += getRandom(4);//添加4位随机数
                        model.UserId = getGuid();
                        model.Is_Delete = 0;
                        model.Is_Locked = 0;
                        model.updateDate = DateTime.Now;
                        model.createDate = DateTime.Now;
                        model.ResourceId = openid;
                        _serverDbContext.UserInfo.Add(model);
                        ret.code = 0;
                        ret.data = model;
                        ret.msg = "新用户创建成功";
                    }
                }
                else
                {
                    //user 不存在，创建新user
                    model.UserId = getGuid();
                    model.Is_Delete = 0;
                    model.Is_Locked = 0;
                    model.updateDate = DateTime.Now;
                    model.createDate = DateTime.Now;
                    model.ResourceId = openid;
                    _serverDbContext.UserInfo.Add(model);
                    ret.code = 0;
                    ret.data = model;
                    ret.msg = "新用户创建成功";
                }

            }
            return ret;
        }

        /// <summary>
        /// 新增用户familyMapping
        /// 2022-7-19，添加一个家族只允许绑定一个人的限制
        /// </summary>
        /// <param name="famMapStr"></param>
        /// <returns></returns>
        public retModel addFmilyMapping(string famMapStr)
        {
            retModel ret = new retModel();
            UserFamilyMapping model = JsonConvert.DeserializeObject<UserFamilyMapping>(famMapStr);
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
            }           
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
        /// 2022-7-14， 删除用户家庭绑定
        /// </summary>
        /// <param name="ParaStr"></param>
        /// <returns></returns>
        public retModel deleteFamilyMapping(string ParaStr)
        {
            retModel ret = new retModel();
            UserFamilyMapping model = JsonConvert.DeserializeObject<UserFamilyMapping>(ParaStr);
            var umps = _serverDbContext.UserFamilyMapping.Where(r => r.FamilyId.Equals(model.FamilyId)
            && r.UserId.Equals(model.UserId)
            && r.RoleId.Equals(model.RoleId)).ToList();
            foreach (var item in umps)
            {
                _serverDbContext.UserFamilyMapping.Remove(item);
            }
            ret.msg = "绑定信息删除成功！";
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
            var userFamMap = _serverDbContext.UserFamilyMapping.Where(r => r.UserId.Equals(model.UserId) && r.RoleId.Equals("1")).ToList();
            foreach (var userFam in userFamMap)
            {
                var family = FamilyList.Where(r => r.FamilyId.Equals(userFam.FamilyId)).FirstOrDefault();
                Fam_List.Add(family.FamilyId);
            }


            ret.code = 0;
            ret.msg = "获取绑定的家庭信息";
            ret.data = Fam_List;
            return ret;
        }

        /// <summary>
        /// 2022-3-22， 根据角色获取Family 清单
        /// /// July 18 2022, dispaly user binding family according to new requirement, need to display family name and binding user name
        /// </summary>
        /// <param name="userStr"></param>
        /// <returns></returns>
        public retModel getFamilyListByRole(string userStr)
        {
            retModel ret = new retModel();
            UserFamilyMapping model = JsonConvert.DeserializeObject<UserFamilyMapping>(userStr);

            //July 18 2022, modify get onwner info methods
            if (model.RoleId == "3")
            {
                var mybindFam = (from aa in _serverDbContext.UserFamilyMapping
                                 join bb in _serverDbContext.Family on aa.FamilyId equals bb.FamilyId
                                 join cc in _serverDbContext.Member on aa.MemberId equals cc.MemberId
                                 where aa.UserId == model.UserId && aa.RoleId == "3"&&aa.Is_Locked==0
                                 select new
                                 {
                                     bb.FamilyName,
                                     bb.GivenName,
                                     cc.MemberName,
                                     aa.UserFamilyMapId,
                                     aa.FamilyId,
                                     aa.MemberId
                                 }).ToList();
                ret.code = 0;
                ret.msg = "获取角色绑定的Family 清单";
                ret.data = mybindFam;
                return ret;
            }
            else
            {
                List<string> Fam_List = new List<string>();

                var userFamMap = _serverDbContext.UserFamilyMapping.Where(r => r.UserId.Equals(model.UserId) && r.RoleId.Equals(model.RoleId)&&r.Is_Locked==0&&r.Is_Delete==0).ToList();
                foreach (var userFam in userFamMap)
                {
                    Fam_List.Add(userFam.FamilyId);
                }
                ret.code = 0;
                ret.msg = "获取角色对应的Family 清单";
                ret.data = Fam_List;
                return ret;
            }
        }

        /// <summary>
        /// 2022-3-19, 获取用户List
        /// </summary>
        /// <returns></returns>
        public retModel GetUserList(string _UserStr)
        {
            retModel ret = new retModel();
            var userList = _serverDbContext.UserInfo.Where(r => r.Is_Delete == 0).ToList();
            ret.data = userList;
            return ret;
        }
    }
}
