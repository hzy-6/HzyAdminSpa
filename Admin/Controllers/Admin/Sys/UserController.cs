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
    using Toolkit;

    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserController : AdminBaseController
    {
        protected Sys_UserLogic _Logic = new Sys_UserLogic();

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
        /// <param name="RoleIds">角色Id</param>
        /// <returns></returns>
        [HttpPost(nameof(Save)), AppService.ApiCheckTokenFilter]
        public IActionResult Save(Sys_User model, List<Guid> RoleIds)
        {
            this.FormKey = _Logic.Save(model, RoleIds);

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
        public IActionResult LoadForm(Guid? Id)
        {
            return Json(new
            {
                status = 1,
                Form = _Logic.LoadForm(Id)
            });
        }

        #endregion

        #region 其他

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetPowerState)), AppService.ApiCheckTokenFilter]
        public async Task<IActionResult> GetPowerState(Guid MenuId)
        {
            if (MenuId == Guid.Empty) throw new MessageBox("参数MenuId不能为空!");

            var _Sys_Menu = await db.FindByIdAsync<Sys_Menu>(MenuId);

            return Json(new
            {
                status = 1,
                powerState = await new Sys_MenuLogic().GetPowerStateByMenu(_Sys_Menu)
            });
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="OldPwd"></param>
        /// <param name="NewPwd"></param>
        /// <returns></returns>
        [HttpPost(nameof(UpdatePassword)), AppService.ApiCheckTokenFilter]
        public async Task<IActionResult> UpdatePassword(string OldPwd, string NewPwd)
        {
            if (string.IsNullOrWhiteSpace(OldPwd)) throw new MessageBox("请输入旧密码!");
            if (string.IsNullOrWhiteSpace(NewPwd)) throw new MessageBox("请输入新密码!");
            var _Sys_User = await db.FindByIdAsync<Sys_User>(this._Account.UserID);
            if (_Sys_User.User_Pwd != OldPwd) throw new MessageBox("旧密码不正确!");
            await db.UpdateAsync(() => new Sys_User
            {
                User_Pwd = NewPwd
            }, w => w.t1.User_ID == this._Account.UserID);
            return Json();
        }

        #endregion



    }
}