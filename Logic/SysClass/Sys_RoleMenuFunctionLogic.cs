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

    public class Sys_RoleMenuFunctionLogic : BaseLogic
    {

        #region  增、删、改、查

        /// <summary>
        /// 保存角色功能树
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="MenuId"></param>
        /// <param name="FunctionIds"></param>
        /// <returns></returns>
        public async Task Save(Guid RoleId, Guid MenuId, List<Guid> FunctionIds)
        {
            var _Sys_RoleMenuFunctionList = db.Query<Sys_RoleMenuFunction>(w => w.t1.RoleMenuFunction_RoleID == RoleId & w.t1.RoleMenuFunction_MenuID == MenuId);

            await db.CommitAsync(async () =>
            {
                await db.DeleteAsync<Sys_RoleMenuFunction>(w => w.t1.RoleMenuFunction_RoleID == RoleId & w.t1.RoleMenuFunction_MenuID == MenuId);
                if (FunctionIds.Count == 0) return;
                foreach (var item in FunctionIds)
                {
                    await db.InsertAsync(() => new Sys_RoleMenuFunction
                    {
                        RoleMenuFunction_MenuID = MenuId,
                        RoleMenuFunction_RoleID = RoleId,
                        RoleMenuFunction_FunctionID = item
                    });
                }
            });
        }

        /// <summary>
        /// 表单数据加载
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Hashtable LoadForm()
        {
            var _Sys_RoleList = db.Query<Sys_Role>().OrderBy(w => w.SqlStr($"convert(int,{nameof(w.t1.Role_Num)})")).ToList<Dictionary<string, object>>();

            foreach (var item in _Sys_RoleList)
            {
                item["State"] = _Sys_RoleList.IndexOf(item) == 0 ? 1 : 0;
            }

            var _Form = ObjectToHashtable(new
            {
                status = 1,
                Sys_RoleList = _Sys_RoleList
            });

            return _Form;
        }
        #endregion

        /// <summary>
        /// 角色权限树
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="_Sys_MenuList"></param>
        /// <param name="_Sys_FunctionList"></param>
        /// <param name="_Sys_MenuFunctionList"></param>
        /// <param name="_Sys_RoleMenuFunctionList"></param>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public List<object> GetTree(Guid Id, List<Sys_Menu> _Sys_MenuList, List<Sys_Function> _Sys_FunctionList, List<Sys_MenuFunction> _Sys_MenuFunctionList, List<Sys_RoleMenuFunction> _Sys_RoleMenuFunctionList)
        {
            var _Menus = new List<object>();
            List<Sys_Menu> _MenuItem = null;
            if (Id == Guid.Empty)
                _MenuItem = _Sys_MenuList.Where(w => w.Menu_ParentID == null || w.Menu_ParentID == Guid.Empty).ToList();
            else
                _MenuItem = _Sys_MenuList.Where(w => w.Menu_ParentID == Id).ToList();

            foreach (var item in _MenuItem)
            {
                var _children = new List<object>();
                var _Functions = new List<object>();
                var _CheckFunction = new List<object>();
                if (_Sys_MenuList.Any(w => w.Menu_ParentID == item.Menu_ID))
                {
                    _children = this.GetTree(item.Menu_ID, _Sys_MenuList, _Sys_FunctionList, _Sys_MenuFunctionList, _Sys_RoleMenuFunctionList);
                }
                else
                {
                    //if (string.IsNullOrWhiteSpace(item.Menu_Url)) continue;
                    //遍历功能
                    foreach (var _Function in _Sys_FunctionList)
                    {
                        //判断是否 该菜单下 是否勾选了 该功能
                        var _Sys_MenuFunction_Any = _Sys_MenuFunctionList.Any(w =>
                         w.MenuFunction_MenuID == item.Menu_ID &&
                         w.MenuFunction_FunctionID == _Function.Function_ID);

                        if (!_Sys_MenuFunction_Any) continue;

                        var id = $"{_Function.Function_ID}";

                        _Functions.Add(new
                        {
                            id,
                            //label = $"{_Function.Function_Name}/{_Function.Function_ByName}/{_Function.Function_Num}"
                            label = _Function.Function_Name
                        });

                        //判断该角色 对应的菜单和功能是否存在
                        var _Any = _Sys_RoleMenuFunctionList.Any(w =>
                          w.RoleMenuFunction_MenuID == item.Menu_ID &&
                          w.RoleMenuFunction_FunctionID == _Function.Function_ID);

                        if (_Any) _CheckFunction.Add(id);

                    }

                }

                _Menus.Add(new
                {
                    id = item.Menu_ID,
                    label = $"{item.Menu_Name}/{item.Menu_Num}",
                    children = _children,
                    functions = _Functions,
                    checkFunction = _CheckFunction
                });
            }

            return _Menus;
        }





    }
}
