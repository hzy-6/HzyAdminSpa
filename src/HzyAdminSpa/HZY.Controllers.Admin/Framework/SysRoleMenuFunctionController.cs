using HZY.Controllers.Admin.ControllersAdmin;
using HZY.EFCore.Attributes;
using HZY.EFCore.Models;
using HZY.Infrastructure;
using HZY.Infrastructure.Filters;
using HZY.Infrastructure.Permission.Attributes;
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
/// 角色菜单功能控制器
/// </summary>
[ControllerDescriptor("BD024F3A-99A7-4407-861C-A016F243F222")]
public class SysRoleMenuFunctionController : AdminBaseController<SysRoleMenuFunctionService>
{
    private readonly SysRoleService _sysRoleService;

    public SysRoleMenuFunctionController(SysRoleMenuFunctionService defaultService,
        SysRoleService sysRoleService) : base(defaultService)
    {
        _sysRoleService = sysRoleService;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="size"></param>
    /// <param name="page"></param>
    /// <param name="search"></param>
    /// <returns></returns>
    [HttpPost("FindList/{size}/{page}")]
    public async Task<PagingViewModel> FindListAsync([FromRoute] int size, [FromRoute] int page, [FromBody] SysRole search)
    {
        return await this._sysRoleService.FindListAsync(page, size, search);
    }


    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [Transactional]
    [HttpPost("SaveForm")]
    public async Task<Guid> SaveFormAsync([FromBody] SysRoleMenuFunctionFormDto form)
    {
        return await this.DefaultService.SaveFormAsync(form);
    }

    #region 角色菜单功能 Tree

    /// <summary>
    /// 获取菜单功能树
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetRoleMenuFunctionTree/{RoleId}")]
    public async Task<object> FindRoleMenuFunctionTreeAsync(Guid roleId)
    {
        var (guids, objects) = await this.DefaultService.GetRoleMenuFunctionTreeAsync(roleId);

        return new { expandedRowKeys = guids, list = objects };
    }

    #endregion
}