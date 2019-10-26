using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers.Admin.Sys
{
    using System.Collections;
    using Entitys.SysClass;
    using Logic;
    using Logic.SysClass;
    using Microsoft.AspNetCore.Http;
    using DbFrame;
    using Logic.Class;
    using Toolkit;

    /// <summary>
    /// 菜单管理
    /// </summary>
    public class MenusController : AdminBaseController
    {
        protected Sys_MenuLogic _Logic = new Sys_MenuLogic();

        #region 增、删、改、查

        /// <summary>
        /// 数据源
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Rows"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        [NonAction]
        protected override async Task<TableViewModel> DataSourceAsync(int Page, int Rows, Hashtable Search) => await _Logic.FindList(Page, Rows, Search);

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="_IFormCollection"></param>
        /// <returns></returns>
        [HttpGet(nameof(ExportExcel)), AppService.ApiCheckTokenFilter]
        public async Task<IActionResult> ExportExcel(IFormCollection _IFormCollection) =>
            File(AppBase.HandleExportExcel(await this.FindList(1, 999999, _IFormCollection)), Tools.GetFileContentType[".xls"].ToStr(), Guid.NewGuid().ToString() + ".xls");

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="Page">页码</param>
        /// <param name="Rows">每页显示多少条</param>
        /// <param name="_IFormCollection">参数</param>
        /// <returns></returns>
        [HttpPost(nameof(FindList)), AppService.ApiCheckTokenFilter]
        public async Task<TableViewModel> FindList(int Page, int Rows, IFormCollection _IFormCollection)
        {
            _Logic._Account = this._Account;//将当前用户信息传入 Logic层
            var _HashtableQuery = this.FormCollectionToHashtable(_IFormCollection);
            var _DataViewModel = await this.DataSourceAsync(Page, Rows, _HashtableQuery);
            return _DataViewModel;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <param name="FunctionIds">菜单功能集合</param>
        /// <returns></returns>
        [HttpPost(nameof(Save)), AppService.ApiCheckTokenFilter]
        public IActionResult Save(Sys_Menu model, List<Guid> FunctionIds)
        {
            this.FormKey = _Logic.Save(model, FunctionIds);
            return Json();
        }

        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="Id">Id集合</param>
        /// <returns></returns>
        [HttpPost(nameof(Delete)), AppService.ApiCheckTokenFilter]
        public IActionResult Delete(List<Guid> Id)
        {
            _Logic.Delete(Id);
            return Json();
        }

        /// <summary>
        /// 加载表单
        /// </summary>
        /// <param name="Id">主表Id</param>
        /// <returns></returns>
        [HttpPost(nameof(LoadForm)), AppService.ApiCheckTokenFilter]
        public IActionResult LoadForm(Guid? Id) => Json(new { status = 1, Form = _Logic.LoadForm(Id) });

        #endregion

        #region 其他

        /// <summary>
        /// 获取菜单列表 以及 页面按钮权限
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SysTree)), AppService.ApiCheckTokenFilter]
        public async Task<IActionResult> SysTree()
        {
            _Logic._Account = this._Account;

            var allList = await _Logic.GetMenuByRoleIDAsync(this._Account);

            return Json(new
            {
                status = 1,
                userName = this._Account.UserName,
                list = _Logic.CreateMenus(Guid.Empty, allList),
                allList = allList,
                powerState = await _Logic.GetPowerState(allList)
            });
        }

        /// <summary>
        /// 获取菜单功能树
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Tree)), AppService.ApiCheckTokenFilter]
        public async Task<IActionResult> Tree()
        {
            var _Sys_MenuList = await db.Query<Sys_Menu>().OrderBy(w => w.t1.Menu_Num).ToListAsync();
            var _Sys_FunctionList = await db.Query<Sys_Function>().OrderBy(w => w.SqlStr($"convert(int,{nameof(w.t1.Function_Num)})")).ToListAsync();
            var _Sys_MenuFunctionList = await db.Query<Sys_MenuFunction>().OrderBy(w => w.t1.MenuFunction_CreateTime).ToListAsync();
            List<Guid> DefaultExpandedKeys = new List<Guid>();
            List<string> DefaultCheckedKeys = new List<string>();

            var _Tree = _Logic.GetTree(Guid.Empty, _Sys_MenuList, _Sys_FunctionList, _Sys_MenuFunctionList, DefaultExpandedKeys, DefaultCheckedKeys);

            return Json(new
            {
                status = 1,
                tree = _Tree,
                defaultExpandedKeys = DefaultExpandedKeys,
                defaultCheckedKeys = DefaultCheckedKeys
            });
        }

        #endregion

    }
}