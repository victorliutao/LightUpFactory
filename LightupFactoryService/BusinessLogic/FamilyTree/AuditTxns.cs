/*
 作者：刘涛
 时间：2022-5-23
 用途：消息中心构建
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
    public class AuditTxns:FamilyLogic
    {
        private LightUpFactoryContext _serverDbContext;
        private string _userId;

        public AuditTxns(LightUpFactoryContext serverDbContext,string userId)
        {
            _serverDbContext = serverDbContext;
            _userId = userId;
        }
        /// <summary>
        /// 2022-05-23,
        /// create an audit task.
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel createAuditTask(AuditTask model) {
            retModel ret = new retModel();
            //initiate status
            model.auditTaskId = getGuid();
            model.status = 0;
            model.approvalStatus = 0;
            model.openDate = DateTime.Now;
            
            //initiat audit history
            AuditHistory ah = new AuditHistory();
            ah.AuditHistoryId = getGuid();
            ah.auditTaskId = model.auditTaskId;
            ah.auditTaskHistoryName = "创建任务";
            ah.auditType = 1;
            ah.userId = model.applicator;//发起人作为该

            _serverDbContext.AuditHistory.Add(ah);
            _serverDbContext.AuditTask.Add(model);
            return ret;
        }

        /// <summary>
        /// 2022-0523，修改audit Task
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel updateAuditTask(string paraStr) {
            retModel ret = new retModel();
            AuditTask model = JsonConvert.DeserializeObject<AuditTask>(paraStr);
            var at = _serverDbContext.AuditTask.Where(r => r.auditTaskId.Equals(model.auditTaskId)).FirstOrDefault();
            at.status = model.status;
            at.approvalStatus = model.approvalStatus;
            at.closeDate = DateTime.Now;

            // add a audit update to history
            AuditHistory ah = new AuditHistory();
            ah.AuditHistoryId = getGuid();
            ah.auditTaskId = at.auditTaskId;
            ah.auditTaskHistoryName = "审批任务";
            ah.auditType = 2;
            ah.userId = model.applicator;//使用applicator来传递审批人信息
            _serverDbContext.AuditHistory.Add(ah);

            //审批的后续操作
            if (at.approvalStatus == 1)
            {
                //修改Family
                if (at.objectName == "Family")
                {
                    var mem = _serverDbContext.Family.Where(r => r.FamilyId.Equals(at.objectId)).FirstOrDefault();
                    Family item = JsonConvert.DeserializeObject<Family>(at.objectChange);
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
                else if (at.objectName == "Member")
                {
                    var mem = _serverDbContext.Member.Where(r => r.MemberId.Equals(at.objectId)).FirstOrDefault();
                    Member item = JsonConvert.DeserializeObject<Member>(at.objectChange);
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
                else if (at.objectName == "Story")
                {
                    Story item = JsonConvert.DeserializeObject<Story>(at.objectChange);
                    saveFamStory(_serverDbContext, item);
                }
                else if (at.objectName == "Member_Create") {
                    Member item = JsonConvert.DeserializeObject<Member>(at.objectChange);
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
            }
            ret.code = 0;
            ret.msg = "audit finish";
            return ret;
        }

        public retModel getAuditTasks(string paraStr) {
            retModel ret = new retModel();
            AuditTask model = JsonConvert.DeserializeObject<AuditTask>(paraStr);
            //all filter audit task by many conditions
            var auditTasks = _serverDbContext.AuditTask.Where(r => r.status == 0).ToList();//step 1: query for all open task
            var filAuditTasks = auditTasks;
            //determin user by user id;
            //use case 1: get my to approval list; use applicator to denote the owner input
            if (!string.IsNullOrEmpty(model.applicator))
            {
                //get my to do list; need to mapping with user mapping table.get the family list of this user who act as ownner.
                var usermaps = _serverDbContext.UserFamilyMapping.Where(r => r.UserId.Equals(model.applicator) && r.RoleId.Equals("1")).ToList();//get alls the owned families for the owner user id
                                                                                                                                                 //use join to get the list.
                filAuditTasks = (from a in auditTasks
                                 join b in usermaps on a.familyId equals b.FamilyId
                                 join c in _serverDbContext.UserInfo on a.applicator equals c.UserId
                                 select new AuditTask
                                 {
                                     auditTaskId=a.auditTaskId,
                                     type = a.type,
                                     status = a.status,
                                     title=a.title,
                                     applicator = c.FullName,// get applicator's name by mapping with userinfo
                                     contents=a.contents,
                                     openDate=a.openDate,
                                     objectChange=a.objectChange,
                                     objectName=a.objectName
                                 }
                               ).OrderByDescending(s=>s.openDate).ToList();

            }

            ret.data = filAuditTasks;
            ret.msg = "获取待审核内容成功";
            
            return ret;
        }

        /// <summary>
        /// 获取Object修改历史记录,2022-6-6, 根据ObjectId查询对象查询
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns></returns>
        public retModel getObjectHistory(string paraStr) {
            retModel ret = new retModel();
            ObjectsEditHistory model = JsonConvert.DeserializeObject<ObjectsEditHistory>(paraStr);
            var objList = _serverDbContext.ObjectsEditHistory.Where(r => r.objectId.Equals(model.objectId)).OrderByDescending(s=>s.changeCount).ToList();

            //render user name by user id
            var newList = (from a in objList
                           join b in _serverDbContext.UserInfo on a.userId equals b.UserId
                           select new ObjectsEditHistory
                           {
                               changeContent = a.changeContent,
                               updateDate = a.updateDate,
                               userId = b.FullName + "("+b.UserName+")"
                           }).ToList();
            
            ret.data = newList;
            ret.code = 0;
            return ret;
        }
    }
}
