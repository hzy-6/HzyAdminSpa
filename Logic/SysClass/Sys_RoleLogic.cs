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

    public class Sys_RoleLogic : BaseLogic
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
                .Query<Sys_Role>()
                .WhereIF(!string.IsNullOrEmpty(Search["Role_Name"].ToStr()), w => w.t1.Role_Name.Contains(Search["Role_Name"].ToStr()));

            if (string.IsNullOrEmpty(Search["sortName"].ToStr()))
                _Query.OrderBy(w => new { w.t1.Role_Num });
            else
                _Query.OrderBy(w => Search["sortName"].ToStr() + " " + Search["sortOrder"].ToStr());//前端自动排序

            var IQuery = _Query.Select(w => new
            {
                w.t1.Role_Num,
                w.t1.Role_Name,
                w.t1.Role_Remark,
                w.t1.Role_CreateTime,
                _ukid = w.t1.Role_ID
            });

            IQuery.TakePage(Page, Rows, out int TotalCount);

            return this.GetTableViewModel(IQuery, TotalCount, Rows);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Save(Sys_Role model)
        {
            db.Commit(() =>
            {
                if (model.Role_ID.ToGuid() == Guid.Empty)
                {
                    model.Role_ID = db.Insert(model).ToGuid();
                    if (model.Role_ID == Guid.Empty) throw new MessageBox(this.ErrorMessage);
                }
                else
                {
                    if (db.UpdateById(model) == 0) throw new MessageBox(this.ErrorMessage);
                }
            });

            return model.Role_ID.ToGuidStr();
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
                    var _Sys_RoleM = db.FindById<Sys_Role>(item);
                    if (_Sys_RoleM.Role_IsDelete == 2) throw new MessageBox("该信息无法删除！");
                    db.DeleteById<Sys_Role>(item);
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
            var _Sys_Role = db.FindById<Sys_Role>(Id);

            var _Form = ObjectToHashtable(new
            {
                Id
            }, _Sys_Role);

            return _Form;
        }

        #endregion


    }
}
