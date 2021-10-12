using HZY.EFCore.Extensions;
using HZY.EFCore.Models;
using HZY.Infrastructure;
using HZY.Infrastructure.ApiResultManage;
using HZY.Models.DTO;
using HZY.Models.Entities;
using HZY.Models.Entities.Framework;
using HZY.Repositories.Framework;
using HZY.Services.Admin.ServicesAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZY.Services.Admin.Framework;

public class SysOrganizationService : AdminBaseService<SysOrganizationRepository>
{
    public SysOrganizationService(SysOrganizationRepository repository) : base(repository)
    {

    }

    /// <summary>
    /// 获取列表数据
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    public async Task<(List<Guid> expandedRowKeys, List<SysOrganization> res)> FindListAsync(SysOrganization search)
    {
        var query = this.Repository.Select
            .WhereIf(search?.State == null, w => w.State == StateEnum.正常)
            .WhereIf(search?.State != null, w => w.State == search.State)
            .WhereIf(!string.IsNullOrWhiteSpace(search?.Name), w => w.Name.Contains(search.Name))
            ;
        var expandedRowKeys = await query.Select(w => w.Id).ToListAsync();

        var data = await query.Where(w => w.ParentId == null)
            .OrderBy(w => w.OrderNumber)
            .ToListAsync()
            ;

        return (expandedRowKeys, data);
    }

    /// <summary>
    /// 根据id数组删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public async Task DeleteListAsync(List<Guid> ids)
    {
        var sysOrganizations = await this.Repository.Select.Where(w => ids.Contains(w.Id)).ToListAsync();
        await DelTreeSysOrganizationsAsync(sysOrganizations);
    }
    private async Task DelTreeSysOrganizationsAsync(List<SysOrganization> list)
    {
        foreach (var item in list)
        {
            if (item.Children.Count > 0)
                await DelTreeSysOrganizationsAsync(item.Children.ToList());
            await this.Repository.DeleteByIdAsync(item.Id);
        }
    }

    /// <summary>
    /// 查询表单数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    public async Task<Dictionary<string, object>> FindFormAsync(Guid id, Guid parentId)
    {
        var res = new Dictionary<string, object>();
        var form = await this.Repository.FindByIdAsync(id);
        form = form.NullSafe();

        if (id == Guid.Empty)
        {
            var maxNum = await this.Repository.Select
                .WhereIf(parentId == Guid.Empty, w => w.ParentId == null)
                .WhereIf(parentId != Guid.Empty, w => w.ParentId == parentId)
                .MaxAsync(w => w.OrderNumber);
            form.OrderNumber = (maxNum ?? 0) + 1;
        }

        res[nameof(id)] = id == Guid.Empty ? "" : id;
        res[nameof(form)] = form;
        return res;
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public async Task<SysOrganization> SaveFormAsync(SysOrganization form)
    {
        return await this.Repository.InsertOrUpdateAsync(form);
    }



}