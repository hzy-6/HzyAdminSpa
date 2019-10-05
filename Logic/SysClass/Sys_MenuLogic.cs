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

    public class Sys_MenuLogic : BaseLogic
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
                .Query<Sys_Menu>()
                .Join<Sys_Menu>(w => w.t1.Menu_ParentID == w.t2.Menu_ID)
                .WhereIF(string.IsNullOrEmpty(Search["Menu_ID"].ToStr()), w => w.t1.Menu_ParentID == null)
                .WhereIF(!string.IsNullOrEmpty(Search["Menu_ID"].ToStr()), w => w.t1.Menu_ParentID == Search["Menu_ID"].ToGuid())
                .WhereIF(!string.IsNullOrEmpty(Search["Menu_Name"].ToStr()), w => w.t1.Menu_Name.Contains(Search["Menu_Name"].ToStr()));

            if (string.IsNullOrEmpty(Search["sortName"].ToStr()))
                _Query.OrderBy(w => new { w.t1.Menu_Num });
            else
                _Query.OrderBy(w => Search["sortName"].ToStr() + " " + Search["sortOrder"].ToStr());//前端自动排序

            var IQuery = _Query.Select(w => new
            {
                w.t1.Menu_Name,
                w.t1.Menu_Url,
                父级菜单 = w.t2.Menu_Name,
                w.t1.Menu_Num,
                w.t1.Menu_Icon,
                SqlString = $"case when t1.{nameof(w.t1.Menu_IsShow)}=2 then '隐藏' else '显示' end {nameof(w.t1.Menu_IsShow)}",
                w.t1.Menu_CreateTime,
                _ukid = w.t1.Menu_ID
            });

            IQuery.TakePage(Page, Rows, out int TotalCount);

            return this.GetTableViewModel(IQuery, TotalCount, Rows);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <param name="FunctionIds"></param>
        /// <returns></returns>
        public string Save(Sys_Menu model, List<Guid> FunctionIds)
        {
            model.Menu_IsShow = 1;

            db.Commit(() =>
            {
                if (model.Menu_ID.ToGuid() == Guid.Empty)
                {
                    model.Menu_ID = db.Insert(model).ToGuid();
                    if (model.Menu_ID.ToGuid().Equals(Guid.Empty)) throw new MessageBox(this.ErrorMessage);
                }
                else
                {
                    if (db.UpdateById(model) == 0) throw new MessageBox(this.ErrorMessage);
                }

                //
                if (FunctionIds.Count > 0)
                {
                    var _Sys_MenuFunctionList = db.FindList<Sys_MenuFunction>(w => w.t1.MenuFunction_MenuID == model.Menu_ID);
                    db.Delete<Sys_MenuFunction>(w => w.t1.MenuFunction_MenuID == model.Menu_ID);
                    foreach (var item in FunctionIds)
                    {
                        var _Sys_MenuFunction = _Sys_MenuFunctionList.Find(w => w.MenuFunction_FunctionID == item);
                        db.Insert(new Sys_MenuFunction
                        {
                            MenuFunction_ID = _Sys_MenuFunction?.MenuFunction_ID,
                            MenuFunction_FunctionID = item,
                            MenuFunction_MenuID = model.Menu_ID
                        });
                    }
                }
            });
            return model.Menu_ID.ToGuidStr();
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
                    //删除菜单的功能
                    db.Delete<Sys_RoleMenuFunction>(w => w.t1.RoleMenuFunction_MenuID == item);
                    db.Delete<Sys_MenuFunction>(w => w.t1.MenuFunction_MenuID == item);
                    db.DeleteById<Sys_Menu>(item);
                }
            });
        }

        /// <summary>
        /// 表单数据加载
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public object LoadForm(Guid? Id)
        {
            var _Sys_Menu = db.FindById<Sys_Menu>(Id);
            //var _Parent_Menu = db.FindById<Sys_Menu>(_Sys_Menu.Menu_ParentID);
            var AllFunctionList = db.Query<Sys_Function>()
              .OrderBy(w => new { SqlStr = $"convert(int,{nameof(w.t1.Function_Num)})" })
              .Select(w => new { w.t1.Function_ID, w.t1.Function_Name, w.t1.Function_ByName })
              .ToList<Dictionary<string, object>>();
            var FunctionIds = db.Query<Sys_MenuFunction>(w => w.t1.MenuFunction_MenuID == Id).Select(w => w.t1.MenuFunction_FunctionID).ToList();

            var _Dictionary = AppBase.ObjectToDictionary(new
            {
                Id,
                AllFunctionList,
                FunctionIds
            }, _Sys_Menu);

            return _Dictionary;
        }

        #endregion

        #region  创建系统左侧菜单

        /// <summary>
        /// 根据角色ID 获取菜单
        /// </summary>
        /// <returns></returns>
        public async Task<List<Sys_Menu>> GetMenuByRoleIDAsync(Account _Account)
        {
            var _Sys_MenuAllList = await db.Query<Sys_Menu>(w => w.t1.Menu_IsShow == 1).OrderBy(w => w.t1.Menu_Num).ToListAsync();
            if (_Account.IsSuperManage) return _Sys_MenuAllList;

            var _Sys_MenuList = await db
                .Query<Sys_RoleMenuFunction>(w => w.In(w.t1.RoleMenuFunction_RoleID, _Account.RoleIDList))
                .Join<Sys_Function>(w => w.t1.RoleMenuFunction_FunctionID == w.t2.Function_ID)
                .Join<Sys_Menu>(w => w.t1.RoleMenuFunction_MenuID == w.t3.Menu_ID)
                .Where(w => w.t2.Function_ByName == "Have")
                .Select(w => w.t3)
                .ToSql(out DbFrame.BaseClass.SQL Sql)
                .ToListAsync<Sys_Menu>();

            var _New_Sys_MenuList = new List<Sys_Menu>();

            for (int i = 0; i < _Sys_MenuList.Count; i++)
            {
                var item = _Sys_MenuList[i];
                if (!_Sys_MenuList.Any(w => w.Menu_ID == item.Menu_ParentID.ToGuid()) & !_New_Sys_MenuList.Any(w => w.Menu_ID == item.Menu_ParentID.ToGuid()))
                {
                    var _Menu = _Sys_MenuAllList.Find(w => w.Menu_ID == item.Menu_ParentID);
                    if (_Menu != null) _New_Sys_MenuList.Add(_Menu);
                }
                if (!_New_Sys_MenuList.Any(w => w.Menu_ID == item.Menu_ID)) _New_Sys_MenuList.Add(item);
            }

            return _New_Sys_MenuList.OrderBy(w => w.Menu_Num).ToList();
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="_Sys_MenuList"></param>
        public List<object> CreateMenus(Guid Id, List<Sys_Menu> _Sys_MenuList)
        {
            var _Menus = new List<object>();
            List<Sys_Menu> _MenuItem = null;
            if (Id == Guid.Empty)
                _MenuItem = _Sys_MenuList.Where(w => w.Menu_ParentID == null || w.Menu_ParentID == Guid.Empty).ToList();
            else
                _MenuItem = _Sys_MenuList.Where(w => w.Menu_ParentID == Id).ToList();

            foreach (var item in _MenuItem)
            {
                _Menus.Add(new
                {
                    id = item.Menu_ID,
                    name = item.Menu_Name,
                    path = item.Menu_Url,
                    icon = item.Menu_Icon,
                    children = this.CreateMenus(item.Menu_ID, _Sys_MenuList)
                });
            }
            return _Menus;
        }

        /// <summary>
        /// 获取拥有的菜单对象的权限
        /// </summary>
        /// <param name="_Sys_MenuList"></param>
        /// <returns></returns>
        public async Task<List<Dictionary<string, object>>> GetPowerState(List<Sys_Menu> _Sys_MenuList)
        {
            var _Sys_FunctionList = await db
                .Query<Sys_Function>()
                .OrderBy(w => w.t1.Function_Num)
                .ToListAsync();

            var _Sys_MenuFunctionList = await db
               .Query<Sys_MenuFunction>()
               .ToListAsync();

            var _Sys_RoleMenuFunctionList = await db
                .Query<Sys_RoleMenuFunction>(w => w.In(w.t1.RoleMenuFunction_RoleID, this._Account.RoleIDList))
                .ToListAsync();

            List<Dictionary<string, object>> _PowerStateList = new List<Dictionary<string, object>>();

            foreach (var item in _Sys_MenuList)
            {
                var _PowerState = new Dictionary<string, object>();

                if (this._Account.IsSuperManage)
                {
                    foreach (var _Sys_Function in _Sys_FunctionList)
                    {
                        var ispower = _Sys_MenuFunctionList.Any(w => w.MenuFunction_MenuID == item.Menu_ID && w.MenuFunction_FunctionID == _Sys_Function.Function_ID);
                        if (_Sys_Function.Function_ByName == "Have" | item.Menu_ParentID == AppConfig.SysMenuID) ispower = true;
                        _PowerState.Add(_Sys_Function.Function_ByName, ispower);
                    }
                }
                else
                {
                    foreach (var _Sys_Function in _Sys_FunctionList)
                    {
                        if (this._Account.RoleIDList?.Count > 0)
                        {
                            var ispower = _Sys_RoleMenuFunctionList.Any(w =>
                                this._Account.RoleIDList.Contains(w.RoleMenuFunction_RoleID.ToGuid()) &&
                                w.RoleMenuFunction_MenuID == item.Menu_ID &&
                                w.RoleMenuFunction_FunctionID == _Sys_Function.Function_ID);
                            _PowerState.Add(_Sys_Function.Function_ByName, ispower);
                        }
                        else
                        {
                            _PowerState.Add(_Sys_Function.Function_ByName, false);
                        }
                    }
                }
                _PowerState["MenuID"] = item.Menu_ID;
                _PowerStateList.Add(_PowerState);
            }

            return _PowerStateList;
        }

        /// <summary>
        /// 根据菜单获取权限
        /// </summary>
        /// <param name="_Sys_Menu"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, object>> GetPowerStateByMenu(Sys_Menu _Sys_Menu)
        {
            var _Sys_FunctionList = await db
                .Query<Sys_Function>()
                .OrderBy(w => w.t1.Function_Num)
                .ToListAsync();

            var _Sys_MenuFunctionList = await db
               .Query<Sys_MenuFunction>(w => w.t1.MenuFunction_MenuID == _Sys_Menu.Menu_ID)
               .ToListAsync();

            var _Sys_RoleMenuFunctionList = await db
                .Query<Sys_RoleMenuFunction>(w => w.In(w.t1.RoleMenuFunction_RoleID, this._Account.RoleIDList))
                .ToListAsync();

            var _PowerState = new Dictionary<string, object>();

            if (this._Account.IsSuperManage)
            {
                foreach (var item in _Sys_FunctionList)
                {
                    var ispower = _Sys_MenuFunctionList.Any(w => w.MenuFunction_MenuID == _Sys_Menu.Menu_ID && w.MenuFunction_FunctionID == item.Function_ID);
                    if (item.Function_ByName == "Have" | _Sys_Menu.Menu_ParentID == AppConfig.SysMenuID) ispower = true;
                    _PowerState.Add(item.Function_ByName, ispower);
                }
            }
            else
            {
                foreach (var item in _Sys_FunctionList)
                {
                    if (this._Account.RoleIDList?.Count > 0)
                    {
                        var ispower = _Sys_RoleMenuFunctionList.Any(w =>
                            this._Account.RoleIDList.Contains(w.RoleMenuFunction_RoleID.ToGuid()) &&
                            w.RoleMenuFunction_MenuID == _Sys_Menu.Menu_ID &&
                            w.RoleMenuFunction_FunctionID == item.Function_ID);
                        _PowerState.Add(item.Function_ByName, ispower);
                    }
                    else
                    {
                        _PowerState.Add(item.Function_ByName, false);
                    }
                }
            }

            return _PowerState;
        }

        #endregion  左侧菜单

        #region 创建菜单 功能 树
        /// <summary>
        /// 获取菜单与功能树
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="_Sys_MenuList"></param>
        /// <param name="_Sys_FunctionList"></param>
        /// <param name="_Sys_MenuFunctionList"></param>
        /// <param name="_DefaultExpandedKeys"></param>
        /// <param name="_DefaultCheckedKeys"></param>
        /// <returns></returns>
        public List<object> GetTree(Guid Id, List<Sys_Menu> _Sys_MenuList, List<Sys_Function> _Sys_FunctionList, List<Sys_MenuFunction> _Sys_MenuFunctionList, List<Guid> _DefaultExpandedKeys, List<string> _DefaultCheckedKeys)
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
                if (_Sys_MenuList.Any(w => w.Menu_ParentID == item.Menu_ID))
                {
                    _DefaultExpandedKeys.Add(item.Menu_ID);

                    _children = this.GetTree(item.Menu_ID, _Sys_MenuList, _Sys_FunctionList, _Sys_MenuFunctionList, _DefaultExpandedKeys, _DefaultCheckedKeys);
                }
                else
                {
                    //if (string.IsNullOrWhiteSpace(item.Menu_Url)) continue;
                    //遍历功能
                    foreach (var _Function in _Sys_FunctionList)
                    {
                        //判断是否 该菜单下 是否勾选了 该功能
                        var _Sys_MenuFunction_Any = _Sys_MenuFunctionList.Any(w =>
                         w.MenuFunction_FunctionID == _Function.Function_ID &&
                         w.MenuFunction_MenuID == item.Menu_ID);

                        var id = $"{item.Menu_ID}${_Function.Function_ID}";
                        if (_Sys_MenuFunction_Any) _DefaultCheckedKeys.Add(id);

                        _children.Add(new
                        {
                            id = id,
                            label = $"{_Function.Function_Name}/{_Function.Function_ByName}({ _Function.Function_Num })",
                            disabled = true,
                            children = new ArrayList()
                        });
                    }

                }

                _Menus.Add(new
                {
                    id = item.Menu_ID,
                    label = $"{item.Menu_Name}/{item.Menu_Num}",
                    disabled = true,
                    children = _children
                });
            }

            return _Menus;
        }

        #endregion


    }
}
