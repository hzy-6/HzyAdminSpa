using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    using System.Collections;
    using Toolkit;
    using Logic.Class;
    using Entitys.SysClass;
    using DbFrame;
    using System.Threading.Tasks;
    using Entitys;

    public class MemberLogic : BaseLogic
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
                .Query<Member>()
                .Join<Sys_User>(w => w.t1.Member_UserID == w.t2.User_ID)
                .WhereIF(!string.IsNullOrEmpty(Search["Member_Name"].ToStr()), w => w.t1.Member_Name.Contains(Search["Member_Name"].ToStr()))
                .WhereIF(!string.IsNullOrEmpty(Search["User_Name"].ToStr()), w => w.t2.User_Name.Contains(Search["User_Name"].ToStr()));

            if (string.IsNullOrEmpty(Search["sortName"].ToStr()))
                _Query.OrderBy(w => new { desc = w.t1.Member_Num });//默认排序字段
            else
                _Query.OrderBy(w => $"{Search["sortName"].ToStr()} {Search["sortOrder"].ToStr()}");//前端自动排序

            var IQuery = _Query.Select(w => new
            {
                w.t1.Member_Photo,
                w.t1.Member_Num,
                w.t1.Member_Name,
                w.t1.Member_Phone,
                w.t1.Member_Sex,
                w.t2.User_Name,
                w.t1.Member_CreateTime,
                _ukid = w.t1.Member_ID
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
        public async Task<string> Save(Member model, Func<Member, Task<Member>> Call)
        {
            await db.CommitAsync(async () =>
            {
                if (model.Member_ID.ToGuid() == Guid.Empty)
                {
                    model = await Call?.Invoke(model);
                    model.Member_ID = (await db.InsertAsync(model)).ToGuid();
                    if (model.Member_ID.ToGuid() == Guid.Empty) throw new MessageBox(this.ErrorMessage);
                }
                else
                {
                    model = await Call?.Invoke(model);
                    if ((await db.UpdateByIdAsync(model)) == 0) throw new MessageBox(this.ErrorMessage);
                }
            });

            return model.Member_ID.ToGuidStr();
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
                    db.DeleteById<Member>(item);
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
            var _MemberM = db.FindById<Member>(Id);
            var _Sys_UserM = db.FindById<Sys_User>(_MemberM.Member_UserID);

            var _Dictionary = AppBase.ObjectToDictionary(new
            {
                Id,
                User_Name = _Sys_UserM.User_Name
            }, _MemberM);

            return _Dictionary;
        }

        #endregion



    }
}
