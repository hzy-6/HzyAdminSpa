using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SysClass
{
    using System.Data;
    using System.Collections;
    using Toolkit;
    using Logic.Class;
    using Entitys.SysClass;
    using DbFrame;

    public class Sys_UserLogic : BaseLogic
    {

        #region  增、删、改、查

        /// <summary>
        /// 数据源
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Rows"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        public Task<TableViewModel> FindList(int Page, int Rows, Hashtable Search)
        {
            var _Query = db
                .Query<Sys_User>()
                .Join<Sys_UserRole>(w => w.t1.User_ID == w.t2.UserRole_ID)
                .Join<Sys_Role>(w => w.t2.UserRole_RoleID == w.t3.Role_ID)
                .WhereIF(!string.IsNullOrEmpty(Search["User_Name"].ToStr()), w => w.t1.User_Name.Contains(Search["User_Name"].ToStr()))
                .WhereIF(!string.IsNullOrEmpty(Search["User_LoginName"].ToStr()), w => w.t1.User_LoginName.Contains(Search["User_LoginName"].ToStr()));

            if (string.IsNullOrEmpty(Search["sortName"].ToStr()))
                _Query.OrderBy(w => new { desc = w.t1.User_CreateTime });
            else
                _Query.OrderBy(w => Search["sortName"].ToStr() + " " + Search["sortOrder"].ToStr());//前端自动排序

            var IQuery = _Query.Select(w => new
            {
                w.t1.User_Name,
                w.t1.User_LoginName,
                SqlStr1 = @$"
'当前角色'=STUFF((
          SELECT '、' + b.Role_Name
          FROM [Sys_UserRole] a 
          LEFT JOIN [Sys_Role] b on a.UserRole_RoleID=b.Role_ID
          WHERE a.UserRole_UserID = t1.User_ID
          FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
",
                w.t1.User_Email,
                w.t1.User_CreateTime,
                _ukid = w.t1.User_ID
            });

            IQuery.TakePage(Page, Rows, out int TotalCount)
                //.ToSql(out DbFrame.BaseClass.SQL sql)
                ;

            return this.GetTableViewModel(IQuery, TotalCount, Rows);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RoleIds"></param>
        /// <returns></returns>
        public string Save(Sys_User model, List<Guid> RoleIds)
        {
            db.Commit(() =>
            {
                if (model.User_ID.ToGuid() == Guid.Empty)
                {
                    model.User_Pwd = string.IsNullOrWhiteSpace(model.User_Pwd) ? "123" : model.User_Pwd; //Tools.MD5Encrypt("123");
                    model.User_ID = db.Insert(model).ToGuid();
                    if (model.User_ID.ToGuid() == Guid.Empty) throw new MessageBox(this.ErrorMessage);
                }
                else
                {
                    //如果 密码字段为空，则不修改该密码
                    var _Success = db.UpdateObjectById(model)
                                        .IgnoreColsIF(string.IsNullOrWhiteSpace(model.User_Pwd), w => w.User_Pwd)
                                        .Execute();
                    if (_Success == 0) throw new MessageBox(this.ErrorMessage);
                }

                //
                if (RoleIds.Count > 0)
                {
                    var _Sys_UserRoleList = db.FindList<Sys_UserRole>(w => w.t1.UserRole_UserID == model.User_ID);
                    db.Delete<Sys_UserRole>(w => w.t1.UserRole_UserID == model.User_ID);
                    foreach (var item in RoleIds)
                    {
                        var _Sys_UserRole = _Sys_UserRoleList.Find(w => w.UserRole_RoleID == item);
                        db.Insert(new Sys_UserRole
                        {
                            UserRole_ID = _Sys_UserRole?.UserRole_ID,
                            UserRole_RoleID = item,
                            UserRole_UserID = model.User_ID
                        });
                    }
                }

            });

            return model.User_ID.ToGuidStr();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        public void Delete(List<Guid> Ids)
        {
            db.Commit(() =>
            {
                foreach (var item in Ids)
                {
                    var _Sys_User = db.FindById<Sys_User>(item);
                    if (_Sys_User.User_IsDelete == 2) throw new MessageBox("该信息无法删除！");
                    db.Delete<Sys_UserRole>(w => w.t1.UserRole_UserID == item);
                    db.DeleteById<Sys_User>(item);
                }
            });
        }

        /// <summary>
        /// 表单数据加载
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Dictionary<string, object> LoadForm(Guid? Id)
        {
            var _Sys_User = db.FindById<Sys_User>(Id);
            var RoleIds = db.Query<Sys_UserRole>()
                .Join<Sys_Role>(w => w.t1.UserRole_RoleID == w.t2.Role_ID)
                .Where(w => w.t1.UserRole_UserID == Id)
                .OrderByDesc(w => w.t1.UserRole_CreateTime)
                .Select(w => w.t1.UserRole_RoleID)
                .ToList();
            var AllRoleList = db.Query<Sys_Role>()
                .OrderBy(w => new { SqlStr = $"convert(int,{nameof(w.t1.Role_Num)})" })
                .Select(w => new { w.t1.Role_ID, w.t1.Role_Name })
                .ToList<Dictionary<string, object>>();

            var _Dictionary = AppBase.ObjectToDictionary(new
            {
                Id,
                RoleIds,
                AllRoleList
            }, _Sys_User);

            return _Dictionary;
        }

        #endregion




    }
}
