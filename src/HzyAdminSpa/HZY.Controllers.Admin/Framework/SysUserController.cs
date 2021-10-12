using HZY.Controllers.Admin.ControllersAdmin;
using HZY.EFCore.Attributes;
using HZY.EFCore.Models;
using HZY.Infrastructure;
using HZY.Infrastructure.Filters;
using HZY.Infrastructure.Permission.Attributes;
using HZY.Model.BO;
using HZY.Models.DTO;
using HZY.Models.Entities.Framework;
using HZY.Repositories.Framework;
using HZY.Services.Accounts;
using HZY.Services.Admin.Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZY.Controllers.Admin.Framework;

/// <summary>
/// 系统账号管理
/// </summary>
[ControllerDescriptor("38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D")]
public class SysUserController : AdminBaseController<SysUserService>
{
    private readonly IAccountService _accountService;
    private readonly SysMenuService _sysMenuService;
    private readonly SysOrganizationService _sysOrganizationService;

    public SysUserController(SysUserService defaultService,
        IAccountService accountService,
        SysMenuService sysMenuService,
        SysOrganizationService sysOrganizationService) : base(defaultService)
    {
        _accountService = accountService;
        _sysMenuService = sysMenuService;
        _sysOrganizationService = sysOrganizationService;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="size"></param>
    /// <param name="page"></param>
    /// <param name="search"></param>
    /// <returns></returns>
    //[ApiResourceCacheFilter(1)]
    [HttpPost("FindList/{size}/{page}")]
    public async Task<PagingViewModel> FindListAsync([FromRoute] int size, [FromRoute] int page, [FromBody] SysUser search)
    {
        return await this.DefaultService.FindListAsync(page, size, search);
    }

    /// <summary>
    /// 根据id数组删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [Transactional]
    [HttpPost("DeleteList")]
    public async Task<bool> DeleteListAsync([FromBody] List<Guid> ids)
    {
        await this.DefaultService.DeleteListAsync(ids);
        return true;
    }

    /// <summary>
    /// 查询表单数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("FindForm/{id?}")]
    public async Task<Dictionary<string, object>> FindFormAsync([FromRoute] Guid id)
    {
        return await this.DefaultService.FindFormAsync(id);
    }

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [Transactional]
    [HttpPost("SaveForm")]
    public async Task<SysUser> SaveFormAsync([FromBody] SysUserFormDto form)
    {
        return await this.DefaultService.SaveFormAsync(form);
    }

    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    [ApiResourceCacheFilter(10)]
    [HttpPost("ExportExcel")]
    public async Task<FileContentResult> ExportExcelAsync([FromBody] SysUser search)
        => this.File(await this.DefaultService.ExportExcelAsync(search), Tools.GetFileContentType[".xls"].ToStr(),
            $"{Guid.NewGuid()}.xls");

    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <returns></returns>
    [ApiResourceCacheFilter(2)]
    [HttpGet("info")]
    public async Task<AccountInfo> GetUserInfoAsync()
    {
        var userInfo = this._accountService.GetAccountInfo();
        var sysMenus = await this._sysMenuService.GetMenusByCurrentRoleAsync();
        //设置菜单 Map
        var sysMenusMap = this._sysMenuService.CreateMenus(Guid.Empty, sysMenus);
        userInfo.Menus = sysMenusMap;
        //设置菜单权限
        userInfo.MenuPowers = await this._sysMenuService.GetPowerByMenusAsync(sysMenus);

        return userInfo;
    }

    /// <summary>
    /// 获取部门树
    /// </summary>
    /// <returns></returns>
    [HttpPost("SysOrganizationTree")]
    public async Task<dynamic> GetSysDepartmentTreeAsync()
    {
        var (expandedRowKeys, data) = await this._sysOrganizationService.FindListAsync(null);

        return new
        {
            expandedRowKeys,
            rows = await this.DefaultService.GetSysDepartmentTreeAsync(data)
        };
    }


}