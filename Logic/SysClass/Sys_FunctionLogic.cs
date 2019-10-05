using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SysClass
{
    using System.Collections;
    using Toolkit;
    using Logic.Class;
    using Entitys.SysClass;
    using DbFrame;

    public class Sys_FunctionLogic : BaseLogic
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
            var IQuery = db
                .Query<Sys_Function>()
                .WhereIF(!string.IsNullOrEmpty(Search["Function_Name"].ToStr()), w => w.t1.Function_Name.Contains(Search["Function_Name"].ToStr()));

            if (string.IsNullOrEmpty(Search["sortName"].ToStr()))
                IQuery.OrderBy(w => new { w.t1.Function_Num });
            else
                IQuery.OrderBy(w => Search["sortName"].ToStr() + " " + Search["sortOrder"].ToStr());//前端自动排序

            IQuery.Select(w => new
            {
                w.t1.Function_Num,
                w.t1.Function_Name,
                w.t1.Function_ByName,
                w.t1.Function_CreateTime,
                _ukid = w.t1.Function_ID
            });

            IQuery.TakePage(Page, Rows, out int TotalCount);

            return this.GetTableViewModel(IQuery, TotalCount, Rows);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Save(Sys_Function model)
        {
            db.Commit(() =>
            {
                if (model.Function_ID.ToGuid() == Guid.Empty)
                {
                    model.Function_ID = db.Insert(model).ToGuid();
                    if (model.Function_ID.ToGuid() == Guid.Empty) throw new MessageBox(this.ErrorMessage);
                }
                else
                {
                    if (db.UpdateById(model) == 0) throw new MessageBox(this.ErrorMessage);
                }
            });

            return model.Function_ID.ToGuidStr();
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
                    db.DeleteById<Sys_Function>(item);
                }
            });
        }

        /// <summary>
        /// 表单数据加载
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Hashtable LoadForm(Guid? Id)
        {
            var _Sys_Function = db.FindById<Sys_Function>(Id);

            var _Form = AppBase.ObjectToHashtable(new
            {
                Id
            }, _Sys_Function);

            return _Form;
        }

        #endregion
    }
}
