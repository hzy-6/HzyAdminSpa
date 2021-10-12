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
/// 组织机构控制器
/// </summary>
[ControllerDescriptor("0ABFD53B-6BDE-42C6-9F99-E32775BC31DD")]
public class SysOrganizationController : AdminBaseController<SysOrganizationService>
{
    public SysOrganizationController(SysOrganizationService defaultService) : base(defaultService)
    {

    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    [HttpPost("FindList")]
    public async Task<dynamic> FindListAsync([FromBody] SysOrganization search)
    {
        var (expandedRowKeys, data) = await this.DefaultService.FindListAsync(search);

        return new
        {
            expandedRowKeys,
            rows = data
        };
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
    /// <param name="parentId"></param>
    /// <returns></returns>
    [HttpGet("FindForm/{id?}/{parentId?}")]
    public async Task<Dictionary<string, object>> FindFormAsync([FromRoute] Guid id, Guid parentId)
    {
        return await this.DefaultService.FindFormAsync(id, parentId);
    }

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [Transactional]
    [HttpPost("SaveForm")]
    public async Task<SysOrganization> SaveFormAsync([FromBody] SysOrganization form)
    {
        return await this.DefaultService.SaveFormAsync(form);
    }







}