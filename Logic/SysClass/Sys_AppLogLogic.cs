using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.SysClass
{
    using System.Collections;
    using Toolkit;
    using Logic.Class;
    using Entitys.SysClass;
    using DbFrame;
    using System.Threading.Tasks;

    public class Sys_AppLogLogic : BaseLogic
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
            var STime = string.Empty;
            var ETime = string.Empty;
            if (!string.IsNullOrWhiteSpace(Search["AppLog_CreateTime"].ToStr()))
            {
                STime = Search["AppLog_CreateTime"].ToStr().Split('~')[0];
                ETime = Search["AppLog_CreateTime"].ToStr().Split('~')[1];
            }

            var _Query = db
                .Query<Sys_AppLog>()
                .Join<Sys_User>(w => w.t1.AppLog_UserID == w.t2.User_ID)
                .WhereIF(!string.IsNullOrWhiteSpace(Search["AppLog_Api"].ToStr()), w => w.t1.AppLog_Api.Contains(Search["AppLog_Api"].ToStr()))
                .WhereIF(!string.IsNullOrWhiteSpace(Search["AppLog_IP"].ToStr()), w => w.t1.AppLog_IP.Contains(Search["AppLog_IP"].ToStr()))
                .WhereIF(!string.IsNullOrWhiteSpace(Search["AppLog_Parameter"].ToStr()), w => w.t1.AppLog_Parameter.Contains(Search["AppLog_Parameter"].ToStr()))
                .WhereIF(!string.IsNullOrWhiteSpace(Search["AppLog_CreateTime"].ToStr()), w => w.t1.AppLog_CreateTime >= STime.ToDateTime() & w.t1.AppLog_CreateTime <= ETime.ToDateTime());

            if (string.IsNullOrEmpty(Search["sortName"].ToStr()))
                _Query.OrderBy(w => new { desc = w.t1.AppLog_CreateTime });
            else
                _Query.OrderBy(w => Search["sortName"].ToStr() + " " + Search["sortOrder"].ToStr());//前端自动排序

            var IQuery = _Query.Select(w => new
            {
                w.t1.AppLog_IP,
                w.t1.AppLog_Api,
                操作人 = w.t2.User_Name,
                w.t1.AppLog_CreateTime,
                _ukid = w.t1.AppLog_ID
            });

            IQuery.TakePage(Page, Rows, out int TotalCount);

            return this.GetTableViewModel(IQuery, TotalCount, Rows);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Save(Sys_AppLog model)
        {
            db.Commit(() =>
            {
                if (model.AppLog_ID.ToGuid() == Guid.Empty)
                {
                    model.AppLog_ID = db.Insert(model).ToGuid();
                    if (model.AppLog_ID.ToGuid() == Guid.Empty) throw new MessageBox(this.ErrorMessage);
                }
                else
                {
                    if (db.UpdateById(model) == 0) throw new MessageBox(this.ErrorMessage);
                }
            });

            return model.AppLog_ID.ToGuidStr();
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
                    db.DeleteById<Sys_AppLog>(item);
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
            var _Sys_AppLog = db.FindById<Sys_AppLog>(Id);
            var _Sys_User = db.FindById<Sys_User>(_Sys_AppLog.AppLog_UserID);

            var _Dictionary = AppBase.ObjectToDictionary(new
            {
                Id,
                UserName = _Sys_User.User_Name
            }, _Sys_AppLog);

            return _Dictionary;
        }

        #endregion



    }
}
